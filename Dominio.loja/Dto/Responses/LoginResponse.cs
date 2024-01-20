﻿using Dominio.loja.Entity;
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
        public string Authorization { get; set; }
        public LoginResponse(Clients client , string issuer , string jwtKey)
        {
            Clients = client;
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, Clients.PermissionsGroup.Name.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer ,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Authorization =new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
