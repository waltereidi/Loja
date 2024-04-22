using Api.loja.Contracts;
using Framework.loja.Dto.Models;
using Framework.loja.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Data.Entity.Infrastructure.DependencyResolution;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        public AuthenticationApplicationService(IConfiguration configuration)
        {

        }
        public Task<ControllerResponse<T>> Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case AuthenticationContract.V1.LoginRequest: ; break;
                default: throw new NotImplementedException();

            }
            return null;
        }

  
        Task<ControllerResponse<T>> IApplicationService.HandleCreate<T>(T dataSource, Action<T> operation)
        {
            throw new NotImplementedException();
            
        }

        Task<ControllerResponse<T>> IApplicationService.HandleDelete<T>(T dataSource, Action<T> operation)
        {
            throw new NotImplementedException();
        }

        Task<ControllerResponse<T>> IApplicationService.HandleUpdate<T>(T dataSource, Action<T> operation)
        {
            throw new NotImplementedException();
        }
    }
}
