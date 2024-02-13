namespace Zustand.Flow
{
    using Zustand.Flow.Exceptions;

    using Zustand.Subflow;
    using Zustand.Subflow.Interfaces;

    /// <summary>
    /// A class which represents an instance for stateflow
    /// </summary>
    public class Stateflow
    {
        /// <summary>
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </summary>
        private State? _state;
        /// <summary>
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </summary>
        private Shift? _shift;
        
        /// <summary>
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </summary>
        private Stateflow? _inner = null;

        /// <summary>
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </summary>
        private bool is_defined;

        /// <summary>
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </summary>
        public Transdefs? Transdefinition { get; private set; } = null;

        /// <summary>
        /// A signed 64-bit integer value representing an identification key for current instance
        /// </summary>
        private long? _key = null;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Stateflow() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <exception cref="StateflowInitializationException">
        /// Thrown when constructor got by the fact empty instance of parameters, but not null
        /// </exception>
        public Stateflow(State state)
        {
            if (state == State.EMPTY_STATE)
                throw new StateflowInitializationException(this, string.Format("Can't throw an empty {0} with direct initialization through it.",
                                                                 nameof(state)));

            _state = state;
            _shift = null;
            _inner = null;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(State state, Transdefs transdefinition) : this(state)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(State state, Stateflow inner, bool is_defined = false)
        {
            if (state == State.EMPTY_STATE)
                _state = inner.State;
            else
                _state = state;

            _shift = inner.Shift;
            _inner = inner;

            this.is_defined = is_defined;
            Transdefinition = is_defined ? inner.Transdefinition : null;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(State state, Stateflow inner, Transdefs transdefinition) : this(state, 
                                                                                         inner)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <exception cref="StateflowInitializationException">
        /// Thrown when constructor got by the fact empty instance of parameters, but not null
        /// </exception>
        public Stateflow(Shift shift)
        {
            if(_shift == Shift.EMPTY_SHIFT)
                throw new StateflowInitializationException(this, string.Format("Can't throw an empty {0} with direct initialization through it.",
                                                                 nameof(shift)));

            _state = null;
            _shift = shift;
            _inner = null;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(Shift shift, Transdefs transdefinition) : this(shift)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(Shift shift, Stateflow inner, bool is_defined = false)
        {
            if (shift == Shift.EMPTY_SHIFT)
                _shift = inner.Shift;
            else
                _shift = shift;

            _state = inner.State;
            _inner = inner;

            this.is_defined = is_defined;
            Transdefinition = is_defined ? inner.Transdefinition : null;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(Shift shift, Stateflow inner, Transdefs transdefinition) : this(shift, 
                                                                                         inner)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(Stateflow inner, bool is_defined = false)
        {
            _state = inner.State;
            _shift = inner.Shift;

            _inner = inner;

            this.is_defined = is_defined;
            Transdefinition = is_defined ? inner.Transdefinition : null;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(Stateflow inner, Transdefs transdefinition) : this(inner)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(Stateflow inner, State state, Shift shift, bool is_defined = false)
        {
            if (state == State.EMPTY_STATE)
                _state = inner.State;
            else
                _state = state;

            if (shift == Shift.EMPTY_SHIFT)
                _shift = inner.Shift;
            else
                _shift = shift;

            _inner = inner;

            this.is_defined = is_defined;
            Transdefinition = is_defined ? inner.Transdefinition : null;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(Stateflow inner, State state, Shift shift, Transdefs transdefinition) : this(inner,
                                                                                                      state,
                                                                                                      shift)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        /// <param name="recompile">
        /// Boolean parameter which defines would be instance created with empty instances of state and shift or not
        /// </param>
        public Stateflow(Transdefs transdefinition, bool recompile = false) : this()
        {
            if(recompile)
            {
                _state = State.EMPTY_STATE;
                _shift = Shift.EMPTY_SHIFT;
            }

            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <exception cref="StateflowInitializationException">
        /// Thrown when constructor got by the fact empty instance of parameters, but not null
        /// </exception>
        public Stateflow(State state, 
                         Shift shift) : this()
        {
            if (state == State.EMPTY_STATE)
                throw new StateflowInitializationException(this, string.Format("Can't throw an empty {0} with direct initialization through it.",
                                                                 nameof(state)));
            if (shift == Shift.EMPTY_SHIFT)
                throw new StateflowInitializationException(this, string.Format("Can't throw an empty {0} with direct initialization through it.",
                                                                 nameof(shift)));

            _state = state;
            _shift = shift;
        }

        /// <summary>
        /// An internal method which nullifies the transdefinition of current instance
        /// </summary>
        internal void Redetermine()
            => Transdefinition = null;

        /// <summary>
        /// An internal method which redefines the transdefinition of current instance within custom signed 32-bit integer matrix
        /// </summary>
        /// <param name="matrix">
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </param>
        internal void Redetermine(int[,] matrix)
            => Transdefinition?.Redefine(matrix);

        /// <summary>
        /// An internal method which redefines the transdefinition of current instance within another instance of transdefinition
        /// </summary>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> with which current one would be replaced
        /// </param>
        internal void Redetermine(Transdefs transdefinition)
                       => Transdefinition = transdefinition;

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        public void Redirect(State? state)
                        => _state = state;

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        public void Redirect(State? state, Stateflow? inner)
        {
            _state = state;
            _inner = inner;
        }

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        public void Redirect(Shift? shift)
                        => _shift = shift;

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        public void Redirect(Shift? shift, Stateflow? inner)
        {
            _shift = shift;
            _inner = inner;
        }

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        public void Redirect(Stateflow? inner)
                            => _inner = inner;

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        public void Redirect(Stateflow? inner, State? state, Shift? shift)
        {
            _inner = inner;
            _state = state;
            _shift = shift;
        }

        /// <summary>
        /// Method which updates instance of current <see cref="Stateflow"/>
        /// </summary>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        public void Redirect(State state, 
                             Shift shift)
        {
            _state = state;
            _shift = shift;
        }

        /// <summary>
        /// Method which nullifies the transdefinition of current instance and reasserts the boolean parameter of it
        /// </summary>
        public void Translate()
        { 
            Redetermine(); 
            
            Define(false); 
        }

        /// <summary>
        /// Method which redefines the transdefinition of current instance within custom signed 32-bit integer matrix and reasserts the boolean parameter of it
        /// </summary>
        /// <param name="matrix">
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </param>
#pragma warning disable S2368
        public void Translate(int[,] matrix)
#pragma warning restore S2368
        { 
            Redetermine(matrix); 
            
            Define(true); 
        }

        /// <summary>
        /// Method which redefines the transdefinition of current instance within another instance of transdefinition and reasserts the boolean parameter of it
        /// </summary>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> with which current one would be replaced
        /// </param>
        public void Translate(Transdefs transdefinition)
                         => Redetermine(transdefinition); 

        /// <summary>
        /// Method which nullifies every parameter of current instance or defines it to the default value
        /// </summary>
        public void Nullify()
        {
            this._state = null;
            this._shift = null;
            this._inner = null;

            Define(false);

            Transdefinition = null;
        }

        /// <summary>
        /// Method which asserts boolean parameter of transdefinitional behaviour of current instance
        /// </summary>
        /// <param name="value">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public void Define(bool value) 
                => is_defined = value;

        /// <summary>
        /// Method which asserts the identification key of current instance
        /// </summary>
        /// <param name="marker">
        /// A signed 64-bit integer value which represents new identification key for instance
        /// </param>
        public void Mark(long? marker)
                     => _key = marker;

        /// <summary>
        /// <inheritdoc cref="_state"/>
        /// </summary>
        public State? State => _state;
        /// <summary>
        /// <inheritdoc cref="_shift"/>
        /// </summary>
        public Shift? Shift => _shift;

        /// <summary>
        /// <inheritdoc cref="_inner"/>
        /// </summary>
        public Stateflow? Inner => _inner;

        /// <summary>
        /// <inheritdoc cref="is_defined"/>
        /// </summary>
        public bool IsDefined => is_defined;

        /// <summary>
        /// <inheritdoc cref="_key"/>
        /// </summary>
        public long? Key => _key;
    }

    /// <summary>
    /// A class which represents an instance for stateflow
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of value which stateflow will storage as it's designation
    /// </typeparam>
    public class Stateflow<T> : Stateflow where T : notnull
    {
        /// <summary>
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </summary>
        public T? Designation { get; set; }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        public Stateflow(T designation) : base()
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        public Stateflow(T designation, State state) : base(state)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, State state, Transdefs transdefinition) : base(state, 
                                                                                       transdefinition)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="is_defined">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, State state, Stateflow inner, bool is_defined = false) : base(state, 
                                                                                                      inner, is_defined)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, State state, Stateflow inner, Transdefs transdefinition) : base(state, 
                                                                                                        inner, 
                                                                                                        transdefinition)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        public Stateflow(T designation, Shift shift) : base(shift)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation"></param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, Shift shift, Transdefs transdefinition) : base(shift, 
                                                                                       transdefinition)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(T designation, Shift shift, Stateflow inner, bool is_defined = false) : base(shift, 
                                                                                                      inner, is_defined)
        { 
            Designation = designation; 
        }
        
        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, Shift shift, Stateflow inner, Transdefs transdefinition) : base(shift, 
                                                                                                        inner, 
                                                                                                        transdefinition)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(T designation, Stateflow inner, bool is_defined = false) : base(inner, is_defined)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, Stateflow inner, Transdefs transdefinition) : base(inner,
                                                                                           transdefinition)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="is_defined">
        /// Boolean parameter which defines does stateflow is using transdefinitions in it's behaviour
        /// </param>
        public Stateflow(T designation, Stateflow inner, State state, Shift shift, bool is_defined = false) : base(inner, 
                                                                                                                   state, 
                                                                                                                   shift, is_defined)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Stateflow"/> which represents inner stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        public Stateflow(T designation, Stateflow inner, State state, Shift shift, Transdefs transdefinition) : base(inner, 
                                                                                                                     state, 
                                                                                                                     shift, 
                                                                                                                     transdefinition)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="transdefinition">
        /// An instance of <see cref="Subflow.Transdefs"/> which represents the side effects of transdefinitions between states of inner instance
        /// </param>
        /// <param name="recompile">
        /// Boolean parameter which defines would be instance created with empty instances of state and shift or not
        /// </param>
        public Stateflow(T designation, Transdefs transdefinition, bool recompile = false) : base(transdefinition, recompile)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        /// <param name="state">
        /// An instance of <see cref="Subflow.State"/> which represents the shift of the current instance 
        /// </param>
        /// <param name="shift">
        /// An instance of <see cref="Subflow.Shift"/> which represents the shift of the current instance 
        /// </param>
        public Stateflow(T designation, State state,
                                        Shift shift) : base(state,
                                                            shift)
        { 
            Designation = designation; 
        }

        /// <summary>
        /// Method which redefines the value of the designation of the instance of the <see cref="Stateflow{T}"/> 
        /// </summary>
        /// <param name="designation">
        /// A generic type <typeparamref name="T"/> value representing designation of the instance of the stateflow
        /// </param>
        public void Reassign(T? designation)
               => Designation = designation;

        /// <summary>
        /// Method which nullifies by setting to the default value the designation of the instance of the <see cref="Stateflow{T}"/>
        /// </summary>
        public void Renullify()
               => Designation = default;
    }
}
