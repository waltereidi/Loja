
using Topshelf;

namespace Api.TopShelfServicesManager
{
    public class TopShelf
    {
        public TopShelf()
        {
            HostFactory.Run(c =>
            {
                c?.EnablePauseAndContinue();
                c?.EnableShutdown();

                c?.OnException(ex => Console.WriteLine(ex.Message));
                c?.RunAsLocalService();
                c?.StartAutomaticallyDelayed();
                c?.SetDescription(string.Intern("MicroServices Manager"));
                c?.SetDisplayName(string.Intern("NexusMeidator"));
                c?.SetServiceName(string.Intern("NexusMediator"));
                c?.EnableServiceRecovery(r =>
                {
                    r?.OnCrashOnly();
                    r?.RestartService(1); //first
                    r?.RestartService(1); //second
                    r?.RestartService(1); //subsequents
                    r?.SetResetPeriod(0);
                });
            });
            Console.ReadLine();
            }
        }
    }
