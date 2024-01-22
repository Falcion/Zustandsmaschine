namespace Zustand.Logs.Interfaces
{
    using Zustand.Logs.Traits;

    public interface ILog 
    {
        public string Message { get; }

        public object Item { get; }

        public Severities Severity { get; }
        public Priorities Priority { get; }
    }
}
