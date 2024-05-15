using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using QuartzScheduler.Interfaces;

namespace MicroServices.Integrations.QuartzScheduler
{
    public class QuartzScheduler : IQuartzScheduler, ILogProvider
    {
        private readonly StdSchedulerFactory _factory;
        private IScheduler _scheduler { get; set; }
        public QuartzScheduler()
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            _factory = new StdSchedulerFactory();

        }
        public async void SetScheduler()
        {
            _scheduler = await _factory.GetScheduler();
        }

        public async void Start()
        {
            await _scheduler.Start();
        }

        public async void ShutDown()
        {
            await _scheduler.Shutdown();
        }

        public void RemoveJob(IJobDetail job)
        {
            throw new NotImplementedException();
        }

        public async void CreateJob<T>(string jobName, string group, CronExpression cronExpression)
        {
            var job = JobBuilder.Create(typeof(T))
                        .WithIdentity($"{jobName}_Job", group)
                        .Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity($"{ jobName }_Trigger", group)
            .WithCronSchedule(cronExpression.CronExpressionString)
            .ForJob($"{jobName}_Job", group)
            .Build();

            await _scheduler.ScheduleJob(job, trigger);
        }

        public Logger GetLogger(string name)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
        {
            throw new NotImplementedException();
        }


    }
}