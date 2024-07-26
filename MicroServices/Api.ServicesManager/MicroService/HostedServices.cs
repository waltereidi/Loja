using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Api.ServicesManager.MicroService.WFileManager;


namespace Api.ServicesManager.MicroService
{
    public record class Service(Type service, bool IsRunning);
    public record class ServiceResponse(string service, bool IsRunning);
    public class HostedServices : IHostedServices
    {
        private List<Service> Services { get; set; }

        public HostedServices()
        {
            Services = new();
            Services.Add(new Service(typeof( QuartzMS ) , false));
            Services.Add(new Service(typeof( WFileManagerMS ), false));
        }

        public void UpdateServiceState(bool isRunning, Type service)
        {
            Services = Services.Where(x => x.service != service).ToList();
            Services.Add(new Service(service, isRunning));
        }

        public bool GetState(Type service)
        {
            return Services.Where(x => x.service == service).Select(s=>s.IsRunning).First();
        }

        public IEnumerable<ServiceResponse> GetAllServicesState()
        { 
                return Services.Select(s=> new ServiceResponse( s.service.Name, s.IsRunning));
        }

        public IEnumerable<Type> GetHostedService()
        {
            return Services.Select(x => x.service).ToList();
        }

        public void EnableAllServices()
        {
            Services= Services
                .Select(x => new Service( x.service ,true))
                .ToList();
        }

        public void DisableAllServices()
        {
            Services = Services
                .Select(x => new Service(x.service, true))
                .ToList();
        }
    }
}
