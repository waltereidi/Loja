using Api.TopShelfServicesManager.MicroService;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using System.ServiceProcess;
using static Api.TopShelfServicesManager.Contracts.TopShelfContract;

namespace Api.TopShelfServicesManager.Services
{
    public class TopShelfApplicationService : IApplicationService
    {

        private readonly IConfiguration _configuration;
        public Authentication _auth;
        public TopShelfApplicationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task Handle(object command) => command switch
        {
            T1.StopQuartz c => Task.CompletedTask
        };
    }
}
