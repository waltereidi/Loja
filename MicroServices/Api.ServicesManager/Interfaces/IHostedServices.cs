using Api.ServicesManager.MicroService;

namespace Api.ServicesManager.Interfaces
{
    public interface IHostedServices
    {
        IEnumerable<Type> GetHostedService();
        void UpdateServiceState(bool isRunning, Type service);
        bool GetState(Type service);
        IEnumerable<Service> GetServicesState();

    }
}
