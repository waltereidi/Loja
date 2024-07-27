using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Api.ServicesManager.MicroService.WFileManager;


namespace Api.ServicesManager.MicroService
{
    public record class Service(Type service, bool IsRunning);
    public record class ServiceResponse(string service, bool IsRunning);
    
    public class HostedServices : IHostedServices
    {
        private readonly IHost _host;
        private List<Service> Services { get; set; }

        public HostedServices(IHost host)
        {
            string[] windowsServiceArgs = [];
            var builder = Host.CreateApplicationBuilder(windowsServiceArgs);
            
            builder.Services.AddHostedService<QuartzMS>();
            builder.Services.AddHostedService<WFileManagerMS>();
            //Add here another micro service
            
            Services = new();
            Services.Add(new Service(typeof(QuartzMS), false));
            Services.Add(new Service(typeof(WFileManagerMS), false));
            //include here the added microservice to monitored services 

            _host = host;
        }

        public async Task UpdateServiceState(bool isRunning, Type service)
        {
            //Is there a service with different state from the requested?
            if( Services.Where(x => x.service != service).Any(x=>x.IsRunning != isRunning))
            {
                //Get the service from the service type in hosted services
                var hostedService = _host.Services
                    .GetServices<IHostedService>()
                    .FirstOrDefault(s => s.GetType() == service);

                await hostedService
                    .StartAsync(CancellationToken.None)
                    .ContinueWith(_ =>
                    {
                        Services = Services.Where(x => x.service != service).ToList();
                        Services.Add(new Service(service, isRunning));
                    });
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<bool> GetState(Type service)=> Services
            .Where(x => x.service == service)
            .Select(s => s.IsRunning)
            .First();

        public async Task<IEnumerable<ServiceResponse>> GetAllServicesState() => Services
            .Select(s => new ServiceResponse(s.service.Name, s.IsRunning));


        public async Task<IEnumerable<Type>> GetHostedService() => Services
            .Select(x => x.service)
            .ToList();

        public async Task EnableAllServices() => await _host.StartAsync()
                .ContinueWith(x =>
                {
                    Services = Services
                    .Select(x => new Service(x.service, true))
                    .ToList();
                });


        public async Task DisableAllServices() => await _host
                .StopAsync()
                .ContinueWith(x =>
                {
                    Services = Services
                    .Select(x => new Service(x.service, true))
                    .ToList();
                });

    }
}
