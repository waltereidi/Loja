using System;
using System.Threading.Tasks;

using Quartz;
using Quartz.Impl;
using QuartzScheduler.Interfaces;

namespace QuartzSampleApp
{
    public class QuartzScheduler : IQuartzScheduler
    {
        private readonly StdSchedulerFactory _factory;
        private IScheduler _scheduler { get; set; }
        public QuartzScheduler() 
        {
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

        public void AddJob()
        {
            throw new NotImplementedException();
        }

        public void RemoveJob()
        {
            throw new NotImplementedException();
        }

        public void AddTrigger()
        {
            throw new NotImplementedException();
        }

        public void RemoveTrigger()
        {
            throw new NotImplementedException();
        }
    }
}