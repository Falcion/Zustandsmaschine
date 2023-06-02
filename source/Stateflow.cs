using Zustand.Subjects;

namespace Zustand
{
    public class Stateflow
    {
        private States _state;
        private Shifts _shift;

        private long _code = 0;

        private Stateflow? _inner = null;

        #region Constructors
        public Stateflow()
        {
            _state = new States();
            _shift = new Shifts();

            CalculateCode();
        }

        public Stateflow(Shifts shift)
        {
            _state = new States();
            _shift = shift;

            CalculateCode();
        }

        public Stateflow(Shifts shift, Stateflow? inner)
        {
            _state = new States();
            _shift = shift;

            _inner = inner;

            CalculateCode();
        }

        public Stateflow(States state)
        {
            _state = state;
            _shift = new Shifts();

            CalculateCode();
        }

        public Stateflow(States state, Stateflow? inner)
        {
            _state = state;
            _shift = new Shifts();

            _inner = inner;

            CalculateCode();
        }

        public Stateflow(Stateflow inner)
        {
            _state = inner.State;
            _shift = inner.Shift;

            _inner = inner;

            CalculateCode();
        }

        public Stateflow(Stateflow? inner, States state, Shifts shift)
        {
            _state = state;
            _shift = shift;

            _inner = inner;

            CalculateCode();
        }
        #endregion
        #region Instance updaters
        public void Update(States state)
        {
            _state = state;

            CalculateCode();
        }

        public void Update(States state, Stateflow? inner)
        {
            _state = state;

            _inner = inner;

            CalculateCode();
        }

        public void Update(Shifts shift)
        {
            _shift = shift;

            CalculateCode();
        }

        public void Update(Shifts shift, Stateflow? inner)
        {
            _shift = shift;

            _inner = inner;

            CalculateCode();
        }

        public void Update(Stateflow? inner)
        {
            if (inner == null)
                Flush();

            CalculateCode();
        }

        public void Update(Stateflow? inner, States state, Shifts shift)
        {
            _state = state;
            _shift = shift;

            _inner = inner;

            CalculateCode();
        }
        #endregion

        public void Flush()
        {
            _state = new States();
            _shift = new Shifts();

            // We didn't "nullify" code and inner for conceptual purposes: etc for debug
        }

        private void CalculateCode()
        {
            _code = _state.Weight + _shift.Weight;

            if (_inner != null)
            {
                _inner.CalculateCode();

                _code = _inner.Code;
            }
        }

        public States State => _state;
        public Shifts Shift => _shift;
        public long Code => _code;

        public override string ToString()
        {
            return string.Format("State: {0}, Shift: {1}, Code: {2}", _state.Name, _shift.Name, _code);
        }

        public static bool operator >(Stateflow left, Stateflow right)
        {
            return left.Code > right.Code;
        }

        public static bool operator <(Stateflow left, Stateflow right)
        {
            return left.Code < right.Code;
        }

#pragma warning disable S3875
        public static bool operator ==(Stateflow? left, Stateflow? right)
#pragma warning restore S3875
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }


        public static bool operator !=(Stateflow? left, Stateflow? right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Stateflow)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return this == (Stateflow)obj;
        }


        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
