namespace Api.ServicesManager.Contracts
{
    public class QuartzApplicationServicesContract
    {
        public class T1
        {
            public record class StartQuartz();
            public record class StopQuartz();
            public record class GetQuartzState();
        }
    }
}
