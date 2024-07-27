using Api.ServicesManager.MicroService;

namespace Api.ServicesManager.Interfaces
{
    public interface IHostedServices
    {
        Task<IEnumerable<Type>> GetHostedService();
        Task UpdateServiceState(bool isRunning, Type service);
        Task<bool> GetState(Type service);
        Task<IEnumerable<ServiceResponse>> GetAllServicesState();
        Task EnableAllServices();
        Task DisableAllServices();

    }
}
