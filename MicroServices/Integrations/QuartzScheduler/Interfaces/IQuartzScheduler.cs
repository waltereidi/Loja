using Quartz;

namespace QuartzScheduler.Interfaces
{
    public interface IQuartzScheduler
    {
        void Start();
        void ShutDown();
        void RemoveJob(IJobDetail job);
        void CreateJob<T>(string jobName, string group , CronExpression cronExpression);
        void SetScheduler();

    }
}
