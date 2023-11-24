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

        public State? State => _state;
        public Shift? Shift => _shift;

        public Stateflow? Inner => _inner;

        public bool IsDefined => is_defined;
    }
}
