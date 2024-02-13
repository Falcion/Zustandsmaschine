using Zustand.Attributes;

namespace Zustand.Subflow
{
    using Zustand.Subflow.Interfaces;

    /// <summary>
    /// A class which represents the shift of the stateflow
    /// </summary>
    public sealed class Shift : ISubflow, IComparable<Shift>, IEquatable<Shift>, IEqualityComparer<Shift>
    {
        /// <summary>
        /// A string value which represents the designation value of the current shift
        /// </summary>
        private readonly string _designation = string.Empty;
        /// <summary>
        /// An unsigned 32-bit integer value which represents the weight of the current shift
        /// </summary>
        private uint _weight = default;
        /// <summary>
        /// Boolean parameter which defines the common stable representation of the current shift
        /// </summary>
        private bool _stable = default;

        /// <summary>
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </summary>
#pragma warning disable IDE1006
        private long _key { get; set; } = default;
#pragma warning restore IDE1006

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Shift() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        private Shift(long key)
        {
            this._key = key > 0 ? key * (-1) : key; 
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        public Shift(string designation)
        {
            _designation = designation;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        public Shift(string designation,
                     long key) : this(key)
        {
            _designation = designation;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current shift
        /// </param>
        public Shift(string designation,
                     uint weight)
        {
            _designation = designation;
            _weight = weight;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current shift
        /// </param>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        public Shift(string designation,
                     uint weight,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current shift
        /// </param>
        /// <param name="stable">
        /// Boolean parameter which defines the common stable representation of the current shift
        /// </param>
        public Shift(string designation,
                     uint weight,
                     bool stable)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current shift
        /// </param>
        /// <param name="stable">
        /// Boolean parameter which defines the common stable representation of the current shift
        /// </param>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        public Shift(string designation,
                     uint weight,
                     bool stable,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        /// <summary>
        /// Function which returns an instance of <see cref="Shift"/> from defaults within given designation
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the shift
        /// </param>
        /// <returns>
        /// A static instance of <see cref="Shift"/> which contains given designation value
        /// </returns>
        public static Shift GetFromDefaults(string designation)
        {
            string upper_designation = designation.ToUpper();

            return upper_designation switch
            {
                "BEGIN" => BEGIN,
                "PAUSE" => PAUSE,
                "RESUME" => RESUME,
                "EXIT" => EXIT,
                "STOP" => STOP,
                "SKIP" => SKIP,
                "PHASE" => PHASE,
                "STAGE" => STAGE,
                "MOMENTUM" => MOMENTUM,
                "ROLLBACK" => ROLLBACK,
                "TIMEOUT" => TIMEOUT,
                _ => EMPTY_SHIFT,
            };
        }

        /// <summary>
        /// Function which returns an instance of <see cref="Shift"/> in format of <see cref="ISubflow"/> from defaults within given designation
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current shift
        /// </param>
        /// <returns>
        /// A static instance of <see cref="Shift"/> in format of <see cref="ISubflow"/> which contains given designation value
        /// </returns>
        public static ISubflow GetInterfaces(string designation)
        {
            return (GetFromDefaults(designation) as ISubflow);
        }

        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Begin", 0, true)]
        public static Shift BEGIN { get; } = new("Begin", 0, true);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Pause", 1, true)]
        public static Shift PAUSE { get; } = new("Pause", 1, true);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Resume", 2, true)]
        public static Shift RESUME { get; } = new("Resume", 2, true);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Exit", 3, true)]
        public static Shift EXIT { get; } = new("Exit", 3, true);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Stop", 4, true)]
        public static Shift STOP { get; } = new("Stop", 4, true);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Skip", 5, true)]
        public static Shift SKIP { get; } = new("Skip", 5, true);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Phase", 6, false)]
        public static Shift PHASE { get; } = new("Phase", 6, false);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Stage", 7, false)]
        public static Shift STAGE { get; } = new("Stage", 7, false);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Momentum", 8, false)]
        public static Shift MOMENTUM { get; } = new("Momentum", 8, false);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Rollback", 9, false)]
        public static Shift ROLLBACK { get; } = new("Rollback", 9, false);
        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents correspondive default combination
        /// </summary>
        [Shift("Timeout", 10, false)]
        public static Shift TIMEOUT { get; } = new("Timeout", 10, false);

        /// <summary>
        /// Method which appends the weight of current instance by given value
        /// </summary>
        /// <param name="delta_weight">
        /// An unsigned 32-bit integer value which represents weight added to the current instance
        /// </param>
        public void Transform(uint delta_weight)
                => this._weight += delta_weight;

        /// <summary>
        /// Method which appends the weight of current instance by combination of given value and coefficient
        /// </summary>
        /// <param name="delta_weight">
        /// An unsigned 32-bit integer value which represents weight added to the current instance
        /// </param>
        /// <param name="coef">
        /// A signed 32-bit integer value which represents coefficient with which combination of weights would be found
        /// </param>
        public void Transform(uint delta_weight, int coef)
         => this._weight += (uint)(delta_weight + delta_weight % coef);

        /// <summary>
        /// Method which changes current value of stable parameter for current instance
        /// </summary>
        /// <param name="delta_stable">
        /// Boolean parameter which represents new value of stable parameter in current instance
        /// </param>
        public void Transform(bool delta_stable)
                 => this._stable = delta_stable;

        /// <summary>
        /// Method which changes current value of stable parameter for current instance within given boolean operator mode
        /// </summary>
        /// <param name="delta_stable">
        /// Boolean parameter which represents new value of stable parameter in current instance
        /// </param>
        /// <param name="opers">
        /// A char value which represents type of logical operation which would be used with current instance stable parameter
        /// </param>
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

        /// <summary>
        /// Method which transforms current instance from the given one
        /// </summary>
        /// <param name="another_Shift">
        /// An instance of <see cref="Shift"/> which represents other shift of subflow
        /// </param>
        public void Transform(Shift another_Shift)
        {
            this._weight = (_weight + another_Shift.Weight) / 2;
            this._stable = (_stable ^ another_Shift.Stable);
        }

        /// <summary>
        /// Method which transforms current instance from the given interface
        /// </summary>
        /// <param name="another_flow">
        /// An instance of <see cref="ISubflow"/> which represents other subflow's instance data
        /// </param>
        public void Transform(ISubflow another_flow)
        {
            this._weight = (this._weight + another_flow.Weight) / 2;
#pragma warning disable IDE0054
            this._stable = (this._stable ^ another_flow.Stable);
#pragma warning restore IDE0054
        }

        /// <summary>
        /// Method which sets stable parameter by default as unstable
        /// </summary>
        public void Irrationalize()
        => this._stable = false;

        /// <summary>
        /// Method which reassembles non-essential data of instance within specified behavior
        /// </summary>
        public void Parallel()
        {
            this._weight = 0;
            this._stable = !_stable;
        }

        /// <summary>
        /// Method which resets every non-essential value to default
        /// </summary>
        public void Nullify()
        {
            this._weight = default;
            this._stable = default;

            this._key = default;
        }

        /// <summary>
        /// Method which changes the identity of current instance through key
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        public void Reidentify(long key)
                     => this._key = key;

        /// <summary>
        /// Method which changes the identity of current instance through combination of key and coefficient
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        /// <param name="coef">
        /// A signed 32-bit integer value which represents coefficient with which combination of weights would be found
        /// </param>
        public void Reidentify(long key, int coef)
                     => this._key = key* coef;

        /// <summary>
        /// <inheritdoc cref="_designation"/>
        /// </summary>
        public string Designation => _designation;
        /// <summary>
        /// <inheritdoc cref="_weight"/>
        /// </summary>
        public uint Weight => _weight;
        /// <summary>
        /// <inheritdoc cref="_stable"/>
        /// </summary>
        public bool Stable => _stable;

        /// <summary>
        /// <inheritdoc cref="_key"/>
        /// </summary>
        public long Key => this._key;

        /// <summary>
        /// An overriden default method which converts object to string
        /// </summary>
        /// <returns>
        /// A string value which represents the designation value of the current shift
        /// </returns>
        public override string ToString() => _designation;

        /// <summary>
        /// An instance of <see cref="ISubflow"/> which represents this subflow's instance data
        /// </summary>
        public ISubflow Instance => this;

        /// <summary>
        /// An operator cast for mathematical operation of addition
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Shift"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Shift"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Shift"/> which represents shift after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// An operator cast for mathematical operation of subtraction
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Shift"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Shift"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Shift"/> which represents shift after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// An operator cast for mathematical operation of multiplication
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Shift"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Shift"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Shift"/> which represents shift after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// An operator cast for mathematical operation of division
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Shift"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Shift"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Shift"/> which represents shift after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// A static instance of the <see cref="Shift"/> which represents an empty subflow
        /// </summary>
        public static Shift EMPTY_SHIFT { get; } = new();

        public static implicit operator Shift(Tuple<string, uint,
                                                            bool>? tuple)
        {
            return new Shift(tuple?.Item1 ?? string.Empty,
                             tuple?.Item2 ?? default,
                             tuple?.Item3 ?? default);
        }

        public static bool operator ==(Shift? shift1,
                                       Shift? shift2)
        {
            if (ReferenceEquals(shift1,
                               shift2))
                return true;

            if (shift1 is null && shift2 is null)
                return true;
            if (shift1 is null || shift2 is null)
                return false;

            string design1 = shift1.Designation.ToLower(),
                   design2 = shift2.Designation.ToLower();

            if (design1 != design2)
                return false;
            if (shift1.Stable != shift2.Stable)
                return false;
            if (shift1.Weight != shift2.Weight)
                return false;

            return true;
        }

        public static bool operator !=(Shift? shift1,
                                       Shift? shift2)
        {
            return !(shift1 == shift2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Shift another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Shift? other)
        {
            if (other is null)
                return false;

            return this == other;
        }

        public bool Equals(Shift? shift1,
                           Shift? shift2)
        {
            if (shift1 == null && shift2 == null) return true;
            if (shift1 == null || shift2 == null) return false;

            return shift1 == shift2;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Designation,
                                    this.Weight,
                                    this.Stable,
                                    this.Key);
        }

        public int GetHashCode(Shift shift)
        {
            return HashCode.Combine(shift.Designation,
                                    shift.Weight,
                                    shift.Stable,
                                    shift.Key);
        }

        public int CompareTo(Shift? other)
        {
            if (other is null)
                return 1;

            int comparison_weight = _weight.CompareTo(other.Weight),
                comparison_stable = _stable.CompareTo(other.Stable);

            if (comparison_weight != 0) return comparison_weight;
            if (comparison_stable != 0) return comparison_stable;

            int comparison_designation = string.Compare(_designation,
                                                   other.Designation, StringComparison.InvariantCultureIgnoreCase);

            if (comparison_designation != 0) return comparison_designation;

            return Key.CompareTo(other.Key);
        }

        public static bool operator >(Shift left, Shift right)
        {
            if (ReferenceEquals(left, right))
            {
                return false;
            }

            if (ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Shift left, Shift right)
        {
            if (ReferenceEquals(left, right))
            {
                return false;
            }

            if (ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(Shift left, Shift right)
        {
            if (ReferenceEquals(left, right))
            {
                return false;
            }

            if (ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Shift left, Shift right)
        {
            if (ReferenceEquals(left, right))
            {
                return false;
            }

            if (ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) <= 0;
        }
    }
}
