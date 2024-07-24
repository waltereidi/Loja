using Api.ServicesManager.Contracts;
using Api.ServicesManager.MicroService.QuartzMS;
using Api.ServicesManager.MicroService.WFileManager;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ServiceProcess;
using System.Text;
using static Api.ServicesManager.Contracts.SMApplicationServicesContract;

namespace Api.ServicesManager.Services
{
    public class SMApplicationServices : IApplicationService
    {
        private readonly HostApplicationBuilder _builder;
        private readonly IHost _host;
        public SMApplicationServices()
        {
            string[] windowsServiceArgs = [];
            _builder = Host.CreateApplicationBuilder(windowsServiceArgs);
            _builder.Services.AddHostedService<QuartzMS>();
            _builder.Services.AddHostedService<WFileManagerMS>();
            _host = _builder.Build();


        }

        public async Task<object?> Handle(object command) => command switch
        {
            T1.StartAllServices cmd => _host.StartAsync(),
            T1.StopAllServices cmd => Task.Run(() => _host.StopAsync()),
            T1.GetServices cmd => _host.Services ,
            T1.StartQuartz cmd => StartQuartz() , 
            _ => Task.CompletedTask
            
        };

        private object StartQuartz()
        {
            var hostedServices = _host.Services.GetServices<IHostedService>().ToList();
            var service = hostedServices.FirstOrDefault(s => s.GetType().Name == "QuartzMS");
            if (service != null)
            {
                service.StartAsync(CancellationToken.None);
            }
            return true;

        }
    }
}
