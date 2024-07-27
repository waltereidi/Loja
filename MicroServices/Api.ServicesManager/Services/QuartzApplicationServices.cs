using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService.Quartz;
using Framework.loja.Interfaces;

using static Api.ServicesManager.Contracts.QuartzApplicationServicesContract;

namespace Api.ServicesManager.Services
{
    public class QuartzApplicationServices : IApplicationService
    {
        private IHostedServices _services;
        public QuartzApplicationServices(IHostedServices services)
        {
            _services = services;
        }

        public async Task<object?> Handle(object command) => command switch
        {
            T1.StartQuartz cmd =>  _services.UpdateServiceState(true, typeof(QuartzMS)),
            T1.StopQuartz cmd => _services.UpdateServiceState(false, typeof(QuartzMS)),
            T1.GetQuartzState cmd =>await _services.GetState(typeof(QuartzMS)),
            _ => throw new InvalidOperationException("")
        };



    }
}
