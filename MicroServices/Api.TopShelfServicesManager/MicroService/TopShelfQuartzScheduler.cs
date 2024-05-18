using MicroServices.Integrations.QuartzScheduler.Interfaces;
using Topshelf;

namespace Api.TopShelfServicesManager.MicroService
{
    
    public class TopShelfQuartzScheduler : ServiceControl
    {
        public MicroServices.Integrations.QuartzScheduler.Interfaces.IQuartzScheduler _quartz = new MicroServices.Integrations.QuartzScheduler.QuartzScheduler();
        public bool Start(HostControl hostControl)
        {
            try
            {
                _quartz.Start();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                _quartz.Stop();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
