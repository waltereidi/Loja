using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Framework.loja.Interfaces;

using static Api.ServicesManager.Contracts.SMApplicationServicesContract;

namespace Api.ServicesManager.Services
{
    public class SMApplicationServices : IApplicationService
    {
        private readonly HostApplicationBuilder _builder;
        private readonly IHost _host;
        private static IHostedServices _services;
        public SMApplicationServices(IHostedServices services)
        {
        }

        public async Task<object?> Handle(object command) => command switch
        {
            T1.StartAllServices cmd => _host.StartAsync().ContinueWith(_=>_services.EnableAllServices()),
            T1.StopAllServices cmd => Task.Run(() => _host
                .StopAsync()
                .ContinueWith(_=>_services.DisableAllServices())),
            T1.StartQuartz cmd => StartQuartz()
                .ContinueWith(_ => { _services.UpdateServiceState(false, typeof(QuartzMS)); return _.Result; }),  
            T1.StopQuartz cmd => StopQuartz()
                .ContinueWith(_=> { _services.UpdateServiceState(false, typeof(QuartzMS)) ; return _.Result; }) ,
            T1.GetServices cmd => await _services.GetAllServicesState(),
            _ => Task.CompletedTask
            
        };

        private async Task<object?> StopQuartz()
        {
            if(!_services.GetState(typeof(QuartzMS)).Result)
                return new { Success = false  , Message = "Service already stoped"};

            var hostedServices = _host.Services.GetServices<IHostedService>().ToList();
            var service = hostedServices.FirstOrDefault(s => s.GetType() == typeof(QuartzMS));
            if (service != null)
            {
                service.StopAsync(CancellationToken.None);
            }

            return new { Success = true , Message = "Service stopped" };
        }

        private async Task<object?> StartQuartz()
        {
            if (_services.GetState(typeof(QuartzMS)).Result)
                return new { Success = false, Message = "Service already started" };

            var hostedServices = _host.Services.GetServices<IHostedService>().ToList();
            var service = hostedServices.FirstOrDefault(s => s.GetType().Name == "QuartzMS");
            if (service != null)
            {
                service.StartAsync(CancellationToken.None);
            }

            return new { Success = true, Message = "Service started" };
        }

    }
}
