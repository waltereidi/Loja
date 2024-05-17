using Topshelf;
using MicroServices.Integrations.QuartzScheduler;

namespace Api.TopShelfServicesManager.Services
{
    
    public class TopShelfQuartzScheduler : ServiceControl
    {
        public static MicroServices.Integrations.QuartzScheduler.QuartzScheduler _quartz = new();
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
