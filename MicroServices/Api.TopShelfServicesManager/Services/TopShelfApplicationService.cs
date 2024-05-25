using Api.TopShelfServicesManager.Contracts;
using Api.TopShelfServicesManager.MicroService;
using Api.TopShelfServicesManager.MicroService.Quartz;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.ServiceProcess;
using Topshelf;
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
            T1.StartQuartz c =>Task.Run(()=>HandleStartQuartz()),
            T1.StopQuartz c => throw new NotImplementedException(),
        };

        private void HandleStartQuartz()
        {
            HostFactory.Run(c =>
            {

                c?.OnException(ex => Console.WriteLine(ex.Message));
                c?.UseAssemblyInfoForServiceInfo();

                c?.StartManually();
                c?.RunAsLocalSystem();
                // 👇 Add here microservices integrations to be managed
                c?.Service<TopShelfQuartzScheduler>(sc =>
                {
                    sc.ConstructUsing(() => new TopShelfQuartzScheduler());
                    sc.WhenStarted((tc, hostControl) => tc.Start(hostControl));
                    sc.WhenStopped((tc, hostControl) => tc.Stop(hostControl));
                });

            });
        }
    }
}
