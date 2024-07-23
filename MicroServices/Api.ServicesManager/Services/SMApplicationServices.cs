using Api.ServicesManager.Contracts;
using Api.ServicesManager.MicroService.QuartzMS;
using Api.ServicesManager.MicroService.WFileManager;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
            SMApplicationServicesContract.T1.StartAllServices cmd => _host.RunAsync(),
            SMApplicationServicesContract.T1.StopAllServices cmd => Task.Run(() => _host.StopAsync()),
            SMApplicationServicesContract.T1.GetServices cmd => _host.Services ,
            _ => Task.CompletedTask
            
        };
    }
}
