namespace Zustand.Machine
{
    using Zustand.Machine.Exceptions;

    using Zustand.Subflow;
    using Zustand.Subflow.Interfaces;
    using Zustand.Flow;
    using Zustand.Flow.Exceptions;
    using Zustand.Data;
    using Zustand.Data.Types;

    using Zustand.Machines.Interfaces;
    using Zustand.Machines.Interfaces.Assignees;

    /// <summary>
    /// A class representing instance of the methodological state machine for internal and external stateflows
    /// </summary>
    public class Assembler : IMachine
    {
        /// <summary>
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </summary>
        private State? _state = null;
        /// <summary>
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </summary>
        private Shift? _shift = null;

        /// <summary>
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </summary>
        private Stateflow? _inner = null;

        /// <summary>
        /// An unsigned 64-bit integer value representing current differentiates of the sums of current instance of the machine 
        /// </summary>
        private ulong _data = 0;
        /// <summary>
        /// An unsigned 64-bit integer value representing custom digital imprint of the sums of current instance of the machine 
        /// </summary>
        private ulong _flag = 0;

        /// <summary>
        /// A static instance-value of <see cref="Assembler"/> which represents empty assembler without any defined parameters
        /// </summary>
        public static Assembler EMPTY_INSTANCE { get; } = new();

        /// <summary>
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </summary>
        public State? State => _state;
        /// <summary>
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </summary>
        public Shift? Shift => _shift;

        /// <summary>
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </summary>
        public Stateflow? Inner => _inner;

        /// <summary>
        /// An unsigned 64-bit integer value representing current differentiates of the sums of current instance of the machine 
        /// </summary>
        public ulong Data { get => _data; internal set { _data = value; } }
        /// <summary>
        /// An unsigned 64-bit integer value representing custom digital imprint of the sums of current instance of the machine 
        /// </summary>
        public ulong Flag { get => _flag; internal set { _flag = value; } }

        /// <summary>
        /// An instance of a class of <see cref="Addons.Broker"/> in current instance of the machine which instantiates the rebroker system
        /// </summary>
        public Addons.Broker Broker { get; internal set; } = new();
        /// <summary>
        /// An instance of a class of <see cref="Addons.Sender"/> in current instance of the machine which instantiates the reholder system 
        /// </summary>
        public Addons.Sender Sender { get; internal set; } = new();

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Assembler() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="assembler">
        /// An instance of class which represents assembler from which constructor generate this one instance
        /// </param>
        /// <exception cref="AssemblerNullableException">
        /// Thrown when given instance of an assembler is empty or nullable
        /// </exception>
        public Assembler(Assembler assembler)
        {
            if (assembler == EMPTY_INSTANCE)
                throw new ArgumentNullException(nameof(assembler), "Can't create assembler's instance from empty one.");

            _state = assembler.State;
            _shift = assembler.Shift;

            _inner = assembler.Inner;

            _data = assembler.Data;
            _flag = assembler.Flag;

            Broker = assembler.Broker;
            Sender = assembler.Sender;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </param>
        /// <param name="shift">
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </param>
        public Assembler(State state,
                         Shift shift)
        {
            _state = state;
            _shift = shift;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </param>
        /// <param name="shift">
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </param>
        /// <param name="inner">
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </param>
        public Assembler(State state,
                         Shift shift,
                         Stateflow inner) : this(state,
                                                 shift)
        {
            _inner = inner;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </param>
        public Assembler(State state)
        {
            _state = state;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </param>
        /// <param name="assembler">
        /// An instance of class which represents assembler from which constructor generate this one instance
        /// </param>
        public Assembler(State state, Assembler assembler) : this(state)
        {
            if (assembler != EMPTY_INSTANCE)
            {
                _data = assembler.Data;
                _flag = assembler.Flag;

                Broker = assembler.Broker;
                Sender = assembler.Sender;
            }
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </param>
        /// <param name="inner">
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </param>
        public Assembler(State state, Stateflow inner)
        {
            _state = state;
            _shift = inner.Shift;

            _inner = inner;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of a class of <see cref="Subflow.State"/> which represents an inner state of current instance of the machine
        /// </param>
        /// <param name="inner">
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </param>
        /// <param name="assembler">
        /// An instance of class which represents assembler from which constructor generate this one instance
        /// </param>
        public Assembler(State state, Stateflow inner, Assembler assembler) : this(state, 
                                                                                   inner)
        {
            if(assembler != EMPTY_INSTANCE)
            {
                _data = assembler.Data;
                _flag = assembler.Flag;

                Broker = assembler.Broker;
                Sender = assembler.Sender;
            }
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </param>
        public Assembler(Shift shift)
        {
            _shift = shift;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </param>
        /// <param name="assembler">
        /// An instance of class which represents assembler from which constructor generate this one instance
        /// </param>
        public Assembler(Shift shift, Assembler assembler) : this(shift)
        {
            if (assembler != EMPTY_INSTANCE)
            {
                _data = assembler.Data;
                _flag = assembler.Flag;

                Broker = assembler.Broker;
                Sender = assembler.Sender;
            }
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </param>
        /// <param name="inner">
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </param>
        public Assembler(Shift shift, Stateflow inner)
        {
            _state = inner.State;
            _shift = shift;

            _inner = inner;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of a class of <see cref="Subflow.Shift"/> which represents an inner shift of current instance of the machine
        /// </param>
        /// <param name="inner">
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </param>
        /// <param name="assembler">
        /// An instance of class which represents assembler from which constructor generate this one instance
        /// </param>
        public Assembler(Shift shift, Stateflow inner, Assembler assembler) : this(shift,
                                                                                   inner)
        {
            _state = inner.State;
            _shift = shift;

            _inner = inner;

            if (assembler != EMPTY_INSTANCE)
            {
                _data = assembler.Data;
                _flag = assembler.Flag;

                Broker = assembler.Broker;
                Sender = assembler.Sender;
            }
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="inner">
        /// An instance of a class of <see cref="Flow.Stateflow"/> which represents an external subflow of current instance of the machine
        /// </param>
        public Assembler(Stateflow inner)
        {
            _state = inner.State;
            _shift = inner.Shift;

            _inner = inner;
        }

        public void Mark(ulong value, Sums sum)
        {
            switch(sum)
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
            _state = null;
            _shift = null;

            _inner = null;

            _data = 0;
            _flag = 0;
        }
    }

    /// <summary>
    /// A class representing instance of the methodological state machine for internal and external stateflows
    /// </summary>
    /// <typeparam name="T">
    /// A generic-type value which represents the core rotation value of the assembler's instance
    /// </typeparam>
    public class Assembler<T> : Assembler, IMachine<T> where T : notnull
    {
        /// <summary>
        /// An instance value of <see cref="Pair{T}"/> within two generic values which represents inner cycle of finite automaton
        /// </summary>
        public Pair<T>? Heartbeat { get; set; } = default;
    }
}
