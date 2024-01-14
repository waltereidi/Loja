using Dominio.loja.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.CustomEntities
{
    public class LoginResponse
    {
        public Clients Clients { get; set; }
        public string Authorization { get; set; }

        public LoginResponse(Clients client , string issuer , string jwtKey)
        {
            Clients = client;
            Clients.Password = null;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var Sectoken = new JwtSecurityToken(issuer, issuer, null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            Authorization =new JwtSecurityTokenHandler().WriteToken(Sectoken);
        }
    }
    
}
