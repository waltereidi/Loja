namespace Api.ServicesManager.Contracts
{
    public class SMApplicationServicesContract
    {
        public class T1
        {
            public record class GetAllServicesState();
            public record class StartAllServices();
            public record class StopAllServices();
        }
    }
}
