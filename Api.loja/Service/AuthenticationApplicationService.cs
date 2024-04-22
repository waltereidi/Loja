using Api.loja.Contracts;
using Framework.loja.Dto.Models;
using Framework.loja.Interfaces;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        public Task<ControllerResponse<T>> Handle<T>(object command) where T : class
        {
            switch (command)
            {
                case Authentication.V1.LoginRequest:; break;
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
