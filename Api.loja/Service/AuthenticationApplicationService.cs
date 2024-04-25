using Api.loja.Contracts;
using Api.loja.Data;
using Framework.loja.Dto.Models;
using Framework.loja.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using System.Reflection;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        public AuthenticationApplicationService(IConfiguration configuration ,StoreContext context )
        {
            _configuration = configuration;
            _context = context;
        }

        public Task Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case AuthenticationContract.V1.LoginRequest cmd : return HandleAuthentication(cmd);
                        
                default: return null; break;
            }
            return null;
        }

        private Task HandleAuthentication(AuthenticationContract.V1.LoginRequest command) 
        {
            
            return ;
        }

        public void test() { }
        public Task<ControllerResponse<T>> HandleCreate<T>(T dataSource) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<ControllerResponse<T>> HandleDelete<T>(T dataSource, Action<T> operation) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<ControllerResponse<T>> HandleUpdate<T>(T dataSource, Action<T> operation) where T : class
        {
            throw new NotImplementedException();
        }

    }
}
