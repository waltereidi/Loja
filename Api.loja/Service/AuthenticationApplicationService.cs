using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Events.Authentication;
using Framework.loja.Dto.Models;
using Framework.loja.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core;
using System.Reflection;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        public Authentication _auth;
        public AuthenticationApplicationService(IConfiguration configuration ,StoreContext context )
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case AuthenticationContract.V1.LoginRequest cmd : HandleAuthentication(cmd);break;
                    default:throw new NotImplementedException();
            }
            
        }

        private async Task HandleAuthentication(AuthenticationContract.V1.LoginRequest cmd) 
        {
            if (!_context.clients.Any(x => x.Email == cmd.Email && x.Password == cmd.Password))
                throw new ObjectNotFoundException("User not found");

            _auth = new(_context.clients.First(x=>x.Email==cmd.Email && x.Password == cmd.Password) , _configuration.GetSection("Jwt:Issuer").Value ,_configuration.GetSection("Jwt:Key").Value );
        }


    }
}
