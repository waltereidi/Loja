using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.CustomEntities
{
    public class LoginResponse
    {
        public Clients Clients { get; set; }
        public string Token { get; set; }
        
        public LoginResponse(Clients client , string issuer , string jwtKey)
        {
            List<Claim> listClaim = new List<Claim>();
            client.PermissionsGroup.PermissionsRelations.ToList().ForEach(f => listClaim.Add(new Claim(ClaimTypes.Role ,f.Permissions.Name)));


            Clients = client;
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(listClaim),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer ,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Token =new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
