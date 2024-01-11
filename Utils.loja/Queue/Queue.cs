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
        public int counter { get; set; } = 0;
        public List<Task<string>> StoredResults { get; set; } = new List<Task<string>>();
        public List<Thread> StoredThreads { get; set; } = new List<Thread>();
        public List<string> StoredConcurrency { get; set; } = new List<string>();
        private Thread ThreadA;
        private Thread ThreadB;

        public string ShowMessage()
        {
            Task.Run(()=>{
                StoredResults.Add(Test());
                    });
            return counter.ToString();
        }
        private async Task<string> Test()
        {
            await Test2();
            Console.WriteLine($"{counter} countersdsd.");
            return $"sdsd{counter}";
        }
        public void KillThread()
        {
            ThreadB.Interrupt();

        }
        private async Task<string> Test2()
        {
            Console.WriteLine($"{counter} countersdsd.");
            ThreadA = new Thread(Test3);
            ThreadA.Start();
            ThreadB = new Thread(Test3);

            
            ThreadB.Start();
            return $"sdsd{counter}";
        }
        private async void Test3()
        {   
            lock(StoredConcurrency)
            {
                while (true)
                {
                    Thread.Sleep(8000);
                    StoredConcurrency.Add(counter++.ToString());
                }
            }
            
        }
    }

    public interface IQueue
    {
        string ShowMessage();
        List<Task<string>> StoredResults { get; set; }
        List<Thread> StoredThreads { get; set; }
        int counter { get; set; }
        void KillThread();
    }
}
