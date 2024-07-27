using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Framework.loja.Interfaces;

using static Api.ServicesManager.Contracts.SMApplicationServicesContract;


namespace Api.ServicesManager.Services
{
    
    public class SMApplicationServices : IApplicationService
    {
        private IHostedServices _host;
        public SMApplicationServices(IHostedServices host)
        {
            _host = host;
        }

        public async Task<object?> Handle(object command) => command switch
        {
            T1.StartAllServices cmd => _host.EnableAllServices(),
            T1.StopAllServices cmd => _host.DisableAllServices(),
            T1.GetAllServicesState cmd => await _host.GetAllServicesState(),
            _ => throw new InvalidOperationException("")
        };



    }
}
