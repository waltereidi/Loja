using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Api.ServicesManager.MicroService.WFileManager;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Api.ServicesManager.MicroService
{
    
    public class HostedServices : IHostedServices 
    {
        private readonly IHost _host;
        private List<Service> Services { get; set; }
        public record class Service( IHostedService hotedService, Type type, bool IsRunning);
        public record class ServiceResponse(string service, bool IsRunning);

        public HostedServices()
        {
            string[] windowsServiceArgs = [];
            var builder = Host.CreateApplicationBuilder(windowsServiceArgs);
            
            builder.Services.AddHostedService<QuartzMS>();
            builder.Services.AddHostedService<WFileManagerMS>();
            _host = builder.Build();

            //Add here another micro service
        }
        private void StartServiceList()
        {
            Services = new();
            _host.Services
                    .GetServices<IHostedService>()
                    .ToList()
                    .ForEach(f => Services.Add(new Service( f , f.GetType(), false)));
        }

        public async Task UpdateServiceState(bool isRunning, Type service)
        {
            //Is there a service with different state from the requested?
            if( Services.Any(x=>x.type == service && x.IsRunning != isRunning))
            {
                await Services.First( s=> s.type == service )
                    .hotedService
                    .StartAsync(CancellationToken.None)
                    .ContinueWith(_ =>
                    {
                        var hostedService = Services.First(x => x.type == service);
                        Services = Services.Where(x => x.GetType() != service).ToList();
                        Services.Add(new Service( hostedService.hotedService , hostedService.type, isRunning));
                    });
                //Get the service from the service type in hosted services
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<bool> GetState(Type service )=> Services
            .Where(x => x.type == service )
            .Select(s => s.IsRunning)
            .First();

        public async Task<IEnumerable<ServiceResponse>> GetAllServicesState() => Services
            .Select(s => new ServiceResponse(s.type.Name,  s.IsRunning));

        public async Task EnableAllServices() => await _host.StartAsync()
            .ContinueWith(x =>
            {
                Services = Services
                .Select(s => new Service( s.hotedService, s.type , true))
                .ToList();
            });
        public async Task DisableAllServices() => await _host
            .StopAsync()
            .ContinueWith(x =>
            {
                Services = Services
                .Select(x => new Service(x.hotedService ,x.type , true))
                .ToList();
            });
    }
}
