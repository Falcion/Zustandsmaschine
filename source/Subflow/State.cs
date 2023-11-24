namespace Zustand.Subflow
{
    using Zustand.Subflow.Interfaces;

    public class State : ISubflow
    {
        private readonly string _designation = string.Empty;
        private uint _weight = default;
        private bool _stable = default;

        private long _key { get; set; } = default;

        public State() { }

        private State(long key)
        {
            this._key = key < 0 ? key * (-1) : key;
        }

        public State(string designation)
        {
            _designation = designation;
        }

        public State(string designation,
                     long key) : this(key)
        {
            _designation = designation;
        }

        public State(string designation,
                     uint weight)
        {
            _designation = designation;
            _weight = weight;
        }

        public State(string designation,
                     uint weight,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
        }

        public State(string designation,
                     uint weight,
                     bool stable)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        public State(string designation,
                     uint weight,
                     bool stable,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        public static State UNKNOWN { get; } = new("Unknown", 0, true);
        public static State SKIPPED { get; } = new("Skipped", 1, true);
        public static State PENDING { get; } = new("Pending", 2, true);
        public static State FAILED { get; } = new("Failed", 3, false);
        public static State STAGED { get; } = new("Staged", 4, false);
        public static State ITERATING { get; } = new("Iterating", 5, false);
        public static State PROCESSING { get; } = new("Processing", 6, true);
        public static State SUCCESSFUL { get; } = new("Successful", 7, true);
        public static State INTERRUPTED { get; } = new("Interrupted", 8, false);

        public void Transform(uint delta_weight)
                => this._weight += delta_weight;

        public void Transform(uint delta_weight, int coef)
                => this._weight += (uint)(delta_weight + delta_weight % coef);

        public void Transform(bool delta_stable)
                 => this._stable = delta_stable;

        public void Transform(bool delta_stable, char opers)
        {
            switch(opers)
            {
                default:
                    Transform(delta_stable);
                    break;
                case '&':
                    this._stable &= delta_stable;
                    break;
                case '^':
                    this._stable ^= delta_stable;
                    break;
                case '|':
                    this._stable |= delta_stable;
                    break;
            }
        }

        public void Transform(State another_state)
        {
            this._weight = (_weight + another_state.Weight) / 2;
            this._stable = (_stable ^ another_state.Stable);
        }

        public void Transform(ISubflow another_flow)
        {
            this._weight = (this._weight + another_flow.Weight) / 2;
            this._stable = (this._stable ^ another_flow.Stable);
        }

        public void Irrationalize()
            => this._stable = false;

        public void Parallel()
        {
            this._weight = 0;
            this._stable = !_stable;
        }

        public void Nullify()
        {
            this._weight = default;
            this._stable = default;

            this._key = default;
        }

        public void Reidentify(long key)
                            => this._key = key;

        public void Reidentify(long key, int coef)
                            => this._key = (key ^ coef);

        public string Designation => _designation;
        public uint Weight => _weight;
        public bool Stable => _stable;

        public long Key => this._key;

        public override string ToString()
        { return _designation; }

        public static State operator +(State origin, State another)
        {
            if(origin.Designation != another.Designation)
                throw new ArgumentException("States with different designations can't process their data between them in any form.");
            else
            {
                origin.Transform(another.Weight);
                origin.Transform(another.Stable, '|');

                return origin;
            }
        }

        public static State operator -(State origin, State another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("States with different designations can't process their data between them in any form.");
            else
            {
                origin.Transform(another.Weight, -31);
                               /* Specified number is prime that is why it's used in this calcs, no hard-math purposes. */
                origin.Transform(another.Stable, '|');

                return origin;
            }
        }

        public static State operator *(State origin, State another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("States with different designations can't process their data between them in any form.");
            else
            {
                var weights_calc = (uint)Math.Sqrt(another.Weight
                                                 * another.Weight - origin.Weight);

                origin.Transform(weights_calc);
                origin.Transform(another.Stable, '&');

                return origin;
            }
        }

        public static State operator /(State origin, State another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("States with different designations can't process their data between them in any form.");
            else
            {
                var weights_calc = (uint)Math.Sqrt(another.Weight
                                                 + another.Weight / origin.Weight);

                origin.Transform(weights_calc);
                origin.Transform(another.Stable, '&');

                return origin;
            }
        }

        public static State EMPTY_STATE { get; } = new();
    }
}