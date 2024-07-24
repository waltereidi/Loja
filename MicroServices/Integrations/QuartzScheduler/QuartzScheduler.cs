using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using MicroServices.Integrations.QuartzScheduler.Interfaces;

namespace MicroServices.Integrations.QuartzScheduler
{
    
    public class QuartzScheduler : IQuartzScheduler, ILogProvider 
    {
        private readonly StdSchedulerFactory _factory;
        public IScheduler _scheduler { get; set; }
        public static int variable { get; set; }
        public QuartzScheduler()
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            _factory = new StdSchedulerFactory();
           
        }
        public async Task Start()
        {
            _scheduler = await _factory.GetScheduler();

            await _scheduler.Start();

            ScheduleOnStart scheduleOnStart = new();

            scheduleOnStart.ServicesToScheduleOnStart
                .ForEach( async f => CreateJob(f.jobName, f.group, f.cron, f.t));
        }
        public async Task Stop()=> await _scheduler.Shutdown(true);

        public async Task CreateJob(string jobName, string group, CronExpression cronExpression , Type t)
        {

            var job = JobBuilder.Create(t)
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

        public void RemoveJob(IJobDetail job)
        {
            throw new NotImplementedException();
        }

    }
}