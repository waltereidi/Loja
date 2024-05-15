using Quartz;

namespace QuartzScheduler.Interfaces
{
    public interface IQuartzScheduler
    {
        void Start();
        void Stop();
        void CreateJob<T>(string jobName, string group , CronExpression cronExpression);
        IScheduler _scheduler { get; set; }
    }
}
