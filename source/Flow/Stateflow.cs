namespace Zustand.Flow
{
    using Zustand.Flow.Exceptions;

    using Zustand.Subflow;

    public class Stateflow
    {
        private State? _state;
        private Shift? _shift;
        
        private Stateflow? _inner = null;

        private bool is_defined;

        public Transdefs? Transdefinition { get; private set; } = null;

        private long? _key = null;

        #region [Constructors]:

        public Stateflow() { }

        public Stateflow(State state)
        {
            if (state == State.EMPTY_STATE)
                throw new StateflowInitializationException(this, string.Format("Can't throw an empty {0} with direct initialization through it.",
                                                                 nameof(state)));

            _state = state;
            _shift = null;
            _inner = null;
        }

        public Stateflow(State state, Transdefs transdefinition) : this(state)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

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

        public Stateflow(State state, Stateflow inner, Transdefs transdefinition) : this(state, 
                                                                                         inner)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        public Stateflow(Shift shift)
        {
            if(_shift == Shift.EMPTY_SHIFT)
                throw new StateflowInitializationException(this, string.Format("Can't throw an empty {0} with direct initialization through it.",
                                                                 nameof(shift)));

            _state = null;
            _shift = shift;
            _inner = null;
        }

        public Stateflow(Shift shift, Transdefs transdefinition) : this(shift)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

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

        public Stateflow(Shift shift, Stateflow inner, Transdefs transdefinition) : this(shift, 
                                                                                         inner)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

        public Stateflow(Stateflow inner, bool is_defined = false)
        {
            _state = inner.State;
            _shift = inner.Shift;

            _inner = inner;

            this.is_defined = is_defined;
            Transdefinition = is_defined ? inner.Transdefinition : null;
        }

        public Stateflow(Stateflow inner, Transdefs transdefinition) : this(inner)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

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

        public Stateflow(Stateflow inner, State state, Shift shift, Transdefs transdefinition) : this(inner,
                                                                                                      state,
                                                                                                      shift)
        {
            this.is_defined = true;
            Transdefinition = transdefinition;
        }

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

        #endregion

        internal void Redetermine()
          => Transdefinition = null;

        internal void Redetermine(int[,] matrix)
            => Transdefinition?.Redefine(matrix);

        internal void Redetermine(Transdefs transdefinition)
                       => Transdefinition = transdefinition;

        public void Redirect(State? state)
                        => _state = state;

        public void Redirect(State? state, Stateflow? inner)
        {
            _state = state;
            _inner = inner;
        }

        public void Redirect(Shift? shift)
                        => _shift = shift;

        public void Redirect(Shift? shift, Stateflow? inner)
        {
            _shift = shift;
            _inner = inner;
        }

        public void Redirect(Stateflow? inner)
                            => _inner = inner;

        public void Redirect(Stateflow? inner, State? state, Shift? shift)
        {
            _inner = inner;
            _state = state;
            _shift = shift;
        }

        public void Translate()
                { Redetermine(); Define(false); }

#pragma warning disable S2368
        public void Translate(int[,] matrix)
#pragma warning restore S2368
                       { Redetermine(matrix); Define(true); }

        public void Translate(Transdefs transdefinition)
                          { Redetermine(transdefinition); }

        public void Nullify()
        {
            this._state = null;
            this._shift = null;
            this._inner = null;

            Define(false);

            Transdefinition = null;
        }

        public void Define(bool value) 
                => is_defined = value;

        public void Mark(long? marker)
                     => _key = marker;

        public State? State => _state;
        public Shift? Shift => _shift;

        public Stateflow? Inner => _inner;

        public bool IsDefined => is_defined;

        public long? Key => _key;
    }

    public class Stateflow<T> : Stateflow where T : notnull
    {
        public T? Designation { get; set; } = default(T);

        #region [Constructors]:

        public Stateflow(T designation) : base()
        { Designation = designation; }

        public Stateflow(T designation, State state) : base(state)
        { Designation = designation; }

        public Stateflow(T designation, State state, Transdefs transdefinition) : base(state, 
                                                                                       transdefinition)
        { Designation = designation; }

        public Stateflow(T designation, State state, Stateflow inner, bool is_defined = false) : base(state, 
                                                                                                      inner, is_defined)
        { Designation = designation; }

        public Stateflow(T designation, State state, Stateflow inner, Transdefs transdefinition) : base(state, 
                                                                                                        inner, 
                                                                                                        transdefinition)
        { Designation = Designation; }

        public Stateflow(T designation, Shift shift) : base(shift)
        { Designation = Designation; }

        public Stateflow(T designation, Shift shift, Transdefs transdefinition) : base(shift, 
                                                                                       transdefinition)
        { Designation = Designation; }

        public Stateflow(T designation, Shift shift, Stateflow inner, bool is_defined = false) : base(shift, 
                                                                                                      inner, is_defined)
        { Designation = Designation; }

        public Stateflow(T designation, Shift shift, Stateflow inner, Transdefs transdefinition) : base(shift, 
                                                                                                        inner, 
                                                                                                        transdefinition)
        { Designation = Designation; }

        public Stateflow(T designation, Stateflow inner, bool is_defined = false) : base(inner, is_defined)
        { Designation = Designation; }

        public Stateflow(T designation, Stateflow inner, Transdefs transdefinition) : base(inner,
                                                                                           transdefinition)
        { Designation = Designation; }

        public Stateflow(T designation, Stateflow inner, State state, Shift shift, bool is_defined = false) : base(inner, 
                                                                                                                   state, 
                                                                                                                   shift, is_defined)
        { Designation = Designation; }

        public Stateflow(T designation, Stateflow inner, State state, Shift shift, Transdefs transdefinition) : base(inner, 
                                                                                                                     state, 
                                                                                                                     shift, 
                                                                                                                     transdefinition)
        { Designation = Designation; }

        public Stateflow(T designation, Transdefs transdefinition, bool recompile = false) : base(transdefinition, recompile)
        { Designation = Designation; }

        #endregion

        public void Reassign(T? designation)
               => Designation = designation;

        public void Renullify()
               => Designation = default(T);
    }
}
