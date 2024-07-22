using Dominio.loja.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dominio.loja.Events.Authentication
{
    public class LoginAdmin
    {
        public string Email { get; private set; }
        public string Token { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Created_At { get; private set; }
        public DateTime? Expires_At { get; private set; }

        public LoginAdmin(Clients client, string issuer, string jwtKey)
        {
            
            List<Claim> listClaim = new();
            client.PermissionsGroup.PermissionsRelations.ToList().ForEach(f => listClaim.Add(new Claim(ClaimTypes.Role, f.Permissions.Name)));

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(listClaim),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Token = new JwtSecurityTokenHandler().WriteToken(token);
            Email = client.Email;
            FirstName = client.FirstName; 
            LastName = client.LastName;
            Created_At = DateTime.UtcNow;
            Expires_At = tokenDescriptor.Expires.Value;
        }
    }

}
