using Api.ServicesManager.MicroService;

namespace Api.ServicesManager.Interfaces
{
    public interface IHostedServices
    {
        Task UpdateServiceState(bool isRunning, Type service);
        Task<bool> GetState(Type service);
        Task<IEnumerable<HostedServices.ServiceResponse>> GetAllServicesState();
        Task EnableAllServices();
        Task DisableAllServices();

    }
}
