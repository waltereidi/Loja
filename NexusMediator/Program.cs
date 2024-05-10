
using NexusMediator.TopShelf;
using Topshelf;

namespace NexusMediator
{
    public  class Program
    {
        
        [STAThread]
        static void Main()
        {
            HostFactory.Run(c =>
            {
                c?.EnablePauseAndContinue();
                c?.EnableShutdown();
                c?.Service<TopShelfServices>();
                c?.OnException(ex => Console.WriteLine(ex.Message));
                c?.RunAsNetworkService();
                c?.StartAutomaticallyDelayed();
                c?.SetDescription(string.Intern("MicroService Manager Sample"));
                c?.SetDisplayName(string.Intern("MicroServiceManager"));
                c?.SetServiceName(string.Intern("MicroServiceManager"));
                c?.EnableServiceRecovery(r =>
                {
                    r?.OnCrashOnly();
                    r?.RestartService(1); //first
                    r?.RestartService(1); //second
                    r?.RestartService(1); //subsequents
                    r?.SetResetPeriod(0);
                });
            });
            ApplicationConfiguration.Initialize();
            Application.Run(new WindowsForms());

        }

    }
}