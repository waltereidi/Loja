using Api.TopShelfServicesManager.Contracts;
using Api.TopShelfServicesManager.MicroService;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.ServiceProcess;
using static Api.TopShelfServicesManager.Contracts.TopShelfContract;

namespace Api.TopShelfServicesManager.Services
{
    public class TopShelfApplicationService : IApplicationService
    {

        private readonly IConfiguration _configuration;
        private readonly ServiceController _windowsService;
        public TopShelfApplicationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _windowsService = new ServiceController(configuration.GetSection("TopShelfServiceName").Value , "walter");
        }
        public Task Handle(object command) => command switch
        {
            T1.StopQuartz c => HandleCommand(WindowsServiceCommand.QuartzStop),
            T1.StartQuartz c => HandleCommand(WindowsServiceCommand.QuartzStart),
        };

        private async Task HandleCommand(WindowsServiceCommand command)
        {
            _windowsService.ExecuteCommand((int)command);
        }
    }
}
