namespace Zustand.Machines.Interfaces
{
    using Zustand.Machines.Interfaces.Assignees;

    public interface IMachine 
    {
        public ulong Data { get; }
        public ulong Flag { get; }

        public Machine.Addons.Broker Broker { get; }
        public Machine.Addons.Sender Sender { get; }

        public void Nullify();

        public void Mark(ulong value, Sums sum);
    }

    public interface IMachine<T> : IMachine where T : notnull
    {
        public Data.Types.Pair<T>? Heartbeat { get; set; }
    }
}
