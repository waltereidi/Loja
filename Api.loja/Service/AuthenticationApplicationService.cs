using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using System.Data.Entity.Core;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        public Authentication _auth;
        private readonly string _issuer;
        private readonly string _key;
        public AuthenticationApplicationService(IConfiguration configuration ,StoreContext context )
        {
            _configuration = configuration;
            _context = context;
            _issuer = _configuration.GetSection("Jwt:Issuer").Value ?? throw new ArgumentNullException("Jwt Not configured");
            _key = _configuration.GetSection("Jwt:Key").Value ?? throw new ArgumentNullException("Jwt Not configured");
        }

        public Task Handle(object command) => command switch
        {
            AuthenticationContract.V1.LoginRequest cmd => HandleAuthentication(cmd),
            _ => Task.CompletedTask
        };
            

        private async Task HandleAuthentication(AuthenticationContract.V1.LoginRequest cmd) 
        {
            if (!_context.clients.Any(x => x.Email == cmd.Email && x.Password == cmd.Password))
                throw new ObjectNotFoundException("User not found");

            _auth = new(_context.clients.First(x=>x.Email==cmd.Email && x.Password == cmd.Password) , _issuer , _key);
        }


    }
}
