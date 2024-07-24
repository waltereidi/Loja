using Quartz;

namespace MicroServices.Integrations.QuartzScheduler.Interfaces
{
    public interface IQuartzScheduler
    {
        Task Start();
        Task Stop();
        Task CreateJob(string jobName, string group , CronExpression cronExpression , Type t);
        IScheduler _scheduler { get; set; }
        
    }
}
