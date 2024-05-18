using Quartz;

namespace MicroServices.Integrations.QuartzScheduler.Interfaces
{
    public interface IQuartzScheduler
    {
        void Start();
        void Stop();
        void CreateJob(string jobName, string group , CronExpression cronExpression , Type t);
        IScheduler _scheduler { get; set; }
    }
}
