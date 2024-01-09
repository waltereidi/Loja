using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.loja.Queue
{
    public class Queue : IQueue
    {
        public static int counter = 0;
        public async Task<string?> ShowMessage()
        {
            counter++;
            Test();
            return counter.ToString();
        }
        private async Task Test()
        {
            Task.Delay(2000);
            Console.WriteLine($"{counter} countersdsd.");
        }
    }

    public interface IQueue
    {
        Task<string> ShowMessage();
    }
}
