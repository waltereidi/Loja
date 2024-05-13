using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler.Interfaces
{
    public interface IQuartzScheduler
    {
        void Start();
        void ShutDown();
        void AddJob();
        void RemoveJob();
        void AddTrigger();
        void RemoveTrigger();

    }
}
