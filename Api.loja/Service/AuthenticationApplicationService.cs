﻿using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Org.BouncyCastle.Utilities.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static Api.loja.Contracts.AuthenticationContract;
using static NPOI.SS.Formula.Functions.Countif;
namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        private readonly string _issuer;
        private readonly string _key;
        private readonly string _googleReCaptcha_v3_SiteKey;
        public AuthenticationApplicationService(IConfiguration configuration ,StoreContext context )
        {
            _configuration = configuration;
            _context = context;
            _issuer = _configuration.GetSection("Jwt:Issuer").Value ?? throw new ArgumentNullException("Jwt Not configured");
            _key = _configuration.GetSection("Jwt:Key").Value ?? throw new ArgumentNullException("Jwt Not configured");
            _googleReCaptcha_v3_SiteKey = _configuration.GetSection("GoogleReCaptcha:Secret_v3").Value ?? throw new ArgumentNullException("Google reCaptcha v3 Secret not configured");
        }

        public async Task<object?> Handle(object command) => command switch
        {
            V1.Request.LoginRequestContext cmd => HandleAuthenticationAdmin(cmd),
            //AuthenticationContract.V1.Request.GetUserInfo cmd => GetUserInfo(cmd),
            _ => throw new InvalidOperationException()
        };  

        private V1.ClientInfo GetUserInfo(V1.Request.GetUserInfo cmd)
        {
            var firtName =cmd.context.Request.Cookies[nameof(V1.ClientInfo.firstName)] ?? throw new UnauthorizedAccessException();
            var lastName =cmd.context.Request.Cookies[nameof(V1.ClientInfo.lastName)] ?? throw new UnauthorizedAccessException(); ;
            var nameInitials = cmd.context.Request.Cookies[nameof(V1.ClientInfo.nameInitials)] ?? throw new UnauthorizedAccessException(); ;
            
            return new V1.ClientInfo(firtName,lastName,nameInitials ,null );
        }

        /// <summary>
        /// 1 - Validate email and password 
        /// 2 - Create JwtClaims
        /// 3 - Create JwtToken
        /// 4 - Create HttpContext Claims
        /// 5 - Set token into cookies to be retrieved on startup jwt configuration
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        private V1.Responses.LoginResponse HandleAuthenticationAdmin(V1.Request.LoginRequestContext cmd) 
        {
            var auth = new Authentication();
            
            if (_context.ipScore.Any(x => x.IpAddress.ToString() == cmd.ip.ToString() ))
            {
                IPScore ipScore = _context.ipScore.First(x => x.IpAddress.ToString() == cmd.ip.ToString());
                auth.SetIpScore( new AuthenticationEvents.Request.CreateIpScore( ipScore));
            }
            else
                auth.SetIpScore(new AuthenticationEvents.Request.CreateIpScore(cmd.ip));

            if(_context.clients.Any(x => x.Email == cmd.login.email && x.Password == cmd.login.password))
            {
                Clients client = _context.clients.First(x => x.Email == cmd.login.email && x.Password == cmd.login.password);
                auth.SetClient( client );
            }
            

            if (_context.auth.Any(x=> 
                x.IPScore.Id == auth._IPScore.Id
                || x.Client.Id == auth._Client.Id
            ))
            {
                IEnumerable<Authentications> authentications = _context.auth.Where(x =>
                x.IPScore.Id == auth._IPScore.Id
                || x.Client.Id == auth._Client.Id);

                auth.SetAuthentications(authentications);
            }

            if (!_context.clients.Any(x => x.Email == cmd.login.email && x.Password == cmd.login.password))
                throw new AuthenticationException("Invalid credentials");

            if( !_context.auth.Any(x=>x.))            


            
            cmd.context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            List<Claim> jwtClaims = CreateJwtListClaims(client);
            V1.JwtToken token = CreateToken(jwtClaims, _issuer, _key);
            V1.ClientInfo clientInfo = CreateClientInfo( client , token);

            SetAuthenticationCookies(clientInfo , cmd.context);            
            

            return new(token, clientInfo);
        }
        private void SetAuthenticationCookies(V1.ClientInfo ci  , HttpContext context)
        {
            
            context.Response.Cookies.Append(nameof(ci.token.createdAt),ci.token.createdAt
                                                               .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                                                               .TotalMilliseconds.ToString());
            
            if(ci.token.expiresAt != null)
                context.Response.Cookies.Append(nameof(ci.token.expiresAt), ci.token.expiresAt.Value
                                                                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                                                                .TotalMilliseconds.ToString());

            context.Response.Cookies.Append(nameof(ci.firstName), ci.firstName);
            context.Response.Cookies.Append(nameof(ci.lastName), ci.lastName);
            context.Response.Cookies.Append(nameof(ci.nameInitials), ci.nameInitials);
            context.Response.Cookies.Append(nameof(ci.token.serializedToken), ci.token.serializedToken);
        }
        /// <summary>
        /// Translates client information to be stored in session 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private V1.ClientInfo CreateClientInfo(Clients client , V1.JwtToken token)
        {
            return new(
                client.FirstName,
                client.LastName,
                GetNameInitials(client.FirstName, client.LastName),
                token
                );
        }
        /// <summary>
        /// Returns first letter from firstname and lastName
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        private string GetNameInitials(string firstName, string lastName)
        {
            string result = "";
            result += firstName.First();
            lastName += lastName.First();
            return result;
        }
        /// <summary>
        /// Creates token to be stored in session <br></br>
        /// Issuer and client must be defined in appSettings configuration
        /// </summary>
        /// <param name="client"></param>
        /// <param name="issuer"></param>
        /// <param name="jwtKey"></param>
        /// <exception cref="ArgumentNullException">Could not generate token, review configurations</exception>
        /// <returns></returns>
        private V1.JwtToken CreateToken(List<Claim> listClaim, string issuer, string jwtKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new(serializedToken ?? throw new ArgumentNullException(nameof(serializedToken)), DateTime.Now, tokenDescriptor.Expires);
        }
        /// <summary>
        ///  Claim used in JWT token creation , this claims will be used in <br></br>
        ///  Authentication attributes 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private List<Claim> CreateJwtListClaims(Clients client)
        {
            List<Claim> listClaim = new();
            //The role claimtype is the role described in
            //authorize custom attributes above controllers
            client.PermissionsGroup.PermissionsRelations.ToList().ForEach(f => listClaim.Add(new Claim(ClaimTypes.Role, f.Permissions.Name)));

            return listClaim;
        }
        /// <summary>
        /// Claim used in SignIn from HttpContext , this content will be used in base controller<br></br>
        /// Session stored values from user 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private List<Claim> CreateContextListClaims(V1.ClientInfo client)
        {
            List<Claim> listClaim = new();
            //Creates claim from client permissions
            listClaim.Add(new Claim(nameof(V1.ClientInfo.token.serializedToken),client.token.serializedToken ));
            listClaim.Add(new Claim(nameof(V1.ClientInfo.token.createdAt), client.token.createdAt.ToString()));
            listClaim.Add(new Claim(nameof(V1.ClientInfo.token.expiresAt), client.token.expiresAt.Value.ToString()));
            listClaim.Add(new Claim(nameof(V1.ClientInfo.firstName), client.firstName));
            listClaim.Add(new Claim(nameof(V1.ClientInfo.lastName), client.lastName));
            listClaim.Add(new Claim(nameof(V1.ClientInfo.nameInitials), client.nameInitials));


            return listClaim;
        }
         /// <summary>
         /// Deprecated
         /// </summary>
         /// <param name="httpContextClaims"></param>
         /// <param name="context"></param>
         /// <returns></returns>
        private async Task HttpContextSignIn( List<Claim> httpContextClaims , HttpContext context)
        {
            var identity = new ClaimsIdentity(httpContextClaims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties();
            props.IsPersistent = true;
            props.ExpiresUtc = DateTime.UtcNow.AddMinutes(120);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        }
        private async Task GoogleReCaptcha_V3_Verify(string response , string ip)
        {
            HttpClient client = new ();
            
            V1.Request.GoogleReCaptcha.v2 content= new("secret" , response , ip);
            
            StringContent st = new(JsonSerializer.Serialize(content));

            var result = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify" , st);
            
            if (result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await result.Content.ReadAsStringAsync();
                var deserializedContent = JsonSerializer.Deserialize<V1.Responses.GoogleReCaptcha.V3_Verify>(responseContent);
                if (deserializedContent.success == false)
                    throw new AuthenticationException($"Unable to authorize Google reCaptcha v3 , score {deserializedContent.score}");
            }
        }

    }
}
