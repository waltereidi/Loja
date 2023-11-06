
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Dominio.loja.Entity;

namespace Dominio.loja.DTO.Requests
{
    public class JwtTokenRequest
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? jwtKey { get; set; }
        public string? issuer { get; set; }
        public Clients? Clients { get; set; }

        public string? GetToken()
        {
            if( Clients?.Email == Login && Clients?.Password == Password )
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var Sectoken = new JwtSecurityToken(issuer, issuer, null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(Sectoken);
            }
            else
            {
                return null; 
            }

            

        }
    }

    

}
