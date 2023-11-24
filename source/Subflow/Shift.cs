namespace Zustand.Subflow
{
    using Zustand.Subflow.Interfaces;

    public class Shift : ISubflow
    {
        private readonly string _designation = string.Empty;
        private uint _weight = default;
        private bool _stable = default;

        private long key { get; set; } = default;

        public Shift() { }

        private Shift(long key)
        {
            this.key = key > 0 ? key * (-1) : key; 
        }

        public Shift(string designation)
        {
            _designation = designation;
        }

        public Shift(string designation,
                     long key) : this(key)
        {
            _designation = designation;
        }

        public Shift(string designation,
                     uint weight)
        {
            _designation = designation;
            _weight = weight;
        }

        public Shift(string designation,
                     uint weight,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
        }

        public Shift(string designation,
                     uint weight,
                     bool stable)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        public Shift(string designation,
                     uint weight,
                     bool stable,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        public static Shift BEGIN { get; } = new("Begin", 0, true);
        public static Shift PAUSE { get; } = new("Pause", 1, true);
        public static Shift RESUME { get; } = new("Resume", 2, true);
        public static Shift EXIT { get; } = new("Exit", 3, true);
        public static Shift STOP { get; } = new("Stop", 4, true);
        public static Shift SKIP { get; } = new("Skip", 5, true);
        public static Shift PHASE { get; } = new("Phase", 6, false);
        public static Shift STAGE { get; } = new("Stage", 7, false);
        public static Shift MOMENTUM { get; } = new("Momentum", 8, false);
        public static Shift ROLLBACK { get; } = new("Rollback", 9, false);
        public static Shift TIMEOUT { get; } = new("Timeout", 10, false);

        public void Transform(uint delta_weight)
                => this._weight += delta_weight;

        public void Transform(uint delta_weight, int coef)
                => this._weight += (uint)(delta_weight + delta_weight % coef);

        public void Transform(bool delta_stable)
                 => this._stable = delta_stable;

        public void Transform(bool delta_stable, char opers)
        {
            switch (opers)
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

        public void Transform(Shift another_Shift)
        {
            this._weight = (_weight + another_Shift.Weight) / 2;
            this._stable = (_stable ^ another_Shift.Stable);
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

            this.key = default;
        }

        public void Reidentify(long key)
                            => this.key = key;

        public void Reidentify(long key, int coef)
                            => this.key = (key ^ coef);

        public string Designation => _designation;
        public uint Weight => _weight;
        public bool Stable => _stable;

        public long Key => this.key;

        public override string ToString()
        { return _designation; }

        public static Shift operator +(Shift origin, Shift another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("Shifts with different designations can't process their data between them in any form.");
            else
            {
                origin.Transform(another.Weight);
                origin.Transform(another.Stable, '&');

                return origin;
            }
        }

        public static Shift operator -(Shift origin, Shift another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("Shifts with different designations can't process their data between them in any form.");
            else
            {
                origin.Transform(another.Weight, -31);
                /* Specified number is prime that is why it's used in this calcs, no hard-math purposes. */
                origin.Transform(another.Stable, '&');

                return origin;
            }
        }

        public static Shift operator *(Shift origin, Shift another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("Shifts with different designations can't process their data between them in any form.");
            else
            {
                var weights_calc = (uint)Math.Sqrt(another.Weight
                                                 * another.Weight - origin.Weight);

                origin.Transform(weights_calc);
                origin.Transform(another.Stable, '|');

                return origin;
            }
        }

        public static Shift operator /(Shift origin, Shift another)
        {
            if (origin.Designation != another.Designation)
                throw new ArgumentException("Shifts with different designations can't process their data between them in any form.");
            else
            {
                var weights_calc = (uint)Math.Sqrt(another.Weight
                                                 + another.Weight / origin.Weight);

                origin.Transform(weights_calc);
                origin.Transform(another.Stable, '|');

                return origin;
            }
        }

        public static Shift EMPTY_SHIFT { get; } = new();
    }
}
