namespace Zustand.Transdefmaschine
{
    using Zustand.Flow;
    using Zustand.Flow.Exceptions;
    using Zustand.Subflow;
    using Zustand.Subflow.Interfaces;
    using Zustand.Data.Types;
    using Zustand.Data.Types.Interfaces;

    using Zustand.Machines.Interfaces;

    public class Transdefachine : IMachine
    {
        private Machine.Addons.Broker _broker = new();
        private Machine.Addons.Sender _sender = new();

        /// <summary>
        /// An unsigned 64-bit integer value representing current differentiates of the sums of current instance of the machine 
        /// </summary>
        private ulong _data = 0;
        /// <summary>
        /// An unsigned 64-bit integer value representing custom digital imprint of the sums of current instance of the machine 
        /// </summary>
        private ulong _flag = 0;

        public Transdefachine() { }

        public Stateflow Basis { get; set; } = new();

        public Transdefs Defin { get; set; } = new();

        public Machine.Addons.Broker Broker => _broker;
        public Machine.Addons.Sender Sender => _sender; 

        public ulong Data => _data;
        public ulong Flag => _flag;
    }

    public class Transdefachine<T> : Transdefachine, IMachine<T> where T : notnull
    {
        public Pair<T>? Heartbeat { get; set; } = default; 
    }
}
