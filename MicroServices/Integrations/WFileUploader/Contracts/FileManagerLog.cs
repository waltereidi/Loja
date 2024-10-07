

namespace WFileManager.Contracts
{
    public class FileManagerLog
    {
        private record Event(DateTime eventTime, string description, bool success, string? type);
        private List<Event> Events { get; set; }
        public bool Success { get => !Events.Any(x => !x.success); }
        public virtual string ErrorLog { get => Events.Aggregate("", (agg, next) => next.success ? agg : $"{agg}\n {next.type??""} {next.description}"); }

        public FileManagerLog() 
        {
            Events = new();
        }
        public virtual void AddEvent(string description, bool success , string? type = null) => Events.Add(new(DateTime.Now, description, success , type));

        

    }
}
