namespace Zustand.Transdefmaschine
{
    using Zustand.Flow;
    using Zustand.Flow.Exceptions;
    using Zustand.Subflow;
    using Zustand.Subflow.Interfaces;
    using Zustand.Data.Types;
    using Zustand.Data.Types.Interfaces;

    using Zustand.Machines.Interfaces;
    using Zustand.Machines.Interfaces.Assignees;

    public class Transdefachine : IMachine
    {
        /// <summary>
        /// An unsigned 64-bit integer value representing current differentiates of the sums of current instance of the machine 
        /// </summary>
        private ulong _data = 0;
        /// <summary>
        /// An unsigned 64-bit integer value representing custom digital imprint of the sums of current instance of the machine 
        /// </summary>
        private ulong _flag = 0;

        public Transdefachine() { }

        public Stateflow Basis { get; internal set; } = new();

        public Transdefs Defin { get; internal set; } = new();

        public Machine.Addons.Broker Broker { get; internal set; }
        public Machine.Addons.Sender Sender { get; internal set; }

        public ulong Data { get => _data; internal set { _data = value; } }
        public ulong Flag { get => _flag; internal set { _flag = value; } }

        public void Mark(ulong value, Sums sum)
        {
            switch (sum)
            {
                case Sums.DATA:
                    _data = value;
                    break;
                case Sums.FLAG:
                    _flag = value;
                    break;
                case Sums.ALL:
                    _data = value;
                    _flag = value;
                    break;
                default:
                    throw new ArgumentException("Unknown value representing enum range.", nameof(sum));
            }
        }

        public void Nullify()
        {
            _data = 0;
            _flag = 0;

            Basis = new();
            Defin = new();
        }
    }

    public class Transdefachine<T> : Transdefachine, IMachine<T> where T : notnull
    {
        public Pair<T>? Heartbeat { get; set; } = default; 
    }
}
