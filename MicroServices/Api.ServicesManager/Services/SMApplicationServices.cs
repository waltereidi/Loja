using Api.ServicesManager.MicroService.QuartzMS;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.ServicesManager.Services
{
    public class SMApplicationServices : IApplicationService
    {
        public SMApplicationServices() 
        {
            string[] windowsServiceArgs = [];
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(windowsServiceArgs);
            builder.Services.AddHostedService<QuartzMS>();


            Task.Run(() => {
                IHost host = builder.Build();
                host.Run();

            });
        }

        public Task Handle(object command) => command switch
        {
            //AuthenticationContract.V1.LoginRequest cmd => HandleAuthentication(cmd),
            _ => Task.CompletedTask
        };
    }
}
