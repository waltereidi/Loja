namespace Api.ServicesManager.Contracts
{
    public class SMApplicationServicesContract
    {
        public class T1
        {
            public record class GetServices();
            public record class StartAllServices();
            public record class StopAllServices();
            public record class StartQuartz();
            public record class StopQuartz();
            public record class StartWFileManager();
            public record class StopWFileManager();
        }
    }
}
