using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Api.ServicesManager.MicroService.WFileManager;
using RabbitMQ.Client;
using static Api.ServicesManager.MicroService.HostedServices;

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
            StartServiceList();
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
            if (Services.Any(x => x.IsRunning != isRunning && x.type == service))
            {
                if (isRunning)
                    StartService(service).RunSynchronously();
                else
                    StopService(service).RunSynchronously();
            }
            else
                throw new InvalidOperationException();
            
        }
        private async Task StartService(Type service) => Services
            .First(s => s.type == service)
            .hotedService
            .StartAsync(CancellationToken.None)
            .ContinueWith(_ =>
            {
                var hostedService = Services.First(x => x.type == service);
                Services.Remove(Services.First(x => x.type == service));
                Services.Add(new Service(hostedService.hotedService, hostedService.type, true));
            }).RunSynchronously();


        private async Task StopService(Type service) => Services
            .First(s => s.type == service)
            .hotedService
            .StopAsync(CancellationToken.None)
            .ContinueWith(_ =>
            {
                var hostedService = Services.First(x => x.type == service);
                Services.Remove(Services.First(x => x.type == service));
                Services.Add(new Service(hostedService.hotedService, hostedService.type, false));
            }).RunSynchronously();

        public async Task<bool> GetState(Type service )=> Services
            .Where(x => x.type == service )
            .Select(s => s.IsRunning)
            .First();

        public async Task<IEnumerable<ServiceResponse>> GetAllServicesState() => Services
            .Select(s => new ServiceResponse(s.type.Name,  s.IsRunning));

        public async Task EnableAllServices() => _host.StartAsync()
            .ContinueWith(x =>
            {
                Services = Services
                .Select(s => new Service( s.hotedService, s.type , true))
                .ToList();
            }).RunSynchronously();
        public async Task DisableAllServices() => _host
            .StopAsync()
            .ContinueWith(x =>
            {
                Services = Services
                .Select(x => new Service(x.hotedService ,x.type , false))
                .ToList();
            }).RunSynchronously();
    }
}
