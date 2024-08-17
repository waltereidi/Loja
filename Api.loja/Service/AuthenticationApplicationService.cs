using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Entity;
using Framework.loja.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

using static Api.loja.Contracts.AuthenticationContract;
namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        private readonly string _issuer;
        private readonly string _key;
        public AuthenticationApplicationService(IConfiguration configuration ,StoreContext context )
        {
            _configuration = configuration;
            _context = context;
            _issuer = _configuration.GetSection("Jwt:Issuer").Value ?? throw new ArgumentNullException("Jwt Not configured");
            _key = _configuration.GetSection("Jwt:Key").Value ?? throw new ArgumentNullException("Jwt Not configured");
        }

        public async Task<object?> Handle(object command) => command switch
        {
            AuthenticationContract.V1.Request.LoginRequest cmd => HandleAuthentication(cmd),
            _ => Task.CompletedTask
        };
        private V1.Responses.LoginResponse HandleAuthentication(V1.Request.LoginRequest cmd) 
        {
            if (!_context.clients.Any(x => x.Email == cmd.email && x.Password == cmd.password))
                throw new AuthenticationException("User not found");

            Clients client = _context.clients.First(x => x.Email == cmd.email && x.Password == cmd.password);
            //
            List<Claim> claims = CreateListClaims(client);
            V1.JwtToken token = CreateToken( claims, _issuer, _key);

            V1.ClientInfo clientInfo = CreateClientInfo( client);

            return new(token, clientInfo);
        }
        /// <summary>
        /// Translates client information to be stored in session 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private V1.ClientInfo CreateClientInfo(Clients client)
        {
            return new(
                client.FirstName,
                client.LastName,
                GetNameInitials(client.FirstName, client.LastName)
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
        private List<Claim> CreateListClaims(Clients client)
        {
            List<Claim> listClaim = new();
            //Creates claim from client permissions
            client.PermissionsGroup.PermissionsRelations.ToList().ForEach(f => listClaim.Add(new Claim(ClaimTypes.Role, f.Permissions.Name)));
            return listClaim;
        }


    }
}
