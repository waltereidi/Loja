using Framework.loja.Interfaces;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        public Task Handle(object command)
        {
            switch(command)
            {
                case Authentication.V1.LoginRequest:
                    
            }

        }
    }
}
