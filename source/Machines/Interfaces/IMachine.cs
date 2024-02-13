namespace Zustand.Machines.Interfaces
{
    using Zustand.Machines.Interfaces.Assignees;

    public interface IMachine 
    {
        public ulong Data { get; internal set; }
        public ulong Flag { get; internal set; }

        public Machine.Addons.Broker Broker { get; internal set; }
        public Machine.Addons.Sender Sender { get; internal set; }

        public void Nullify();

        public void Mark(ulong value, Sums sum);
    }

    public interface IMachine<T> : IMachine where T : notnull
    {
        public Data.Types.Pair<T>? Heartbeat { get; set; }
    }
}
