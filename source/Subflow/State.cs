namespace Zustand.Subflow
{
    using Zustand.Subflow.Interfaces;

    /// <summary>
    /// A class which represents the state of the stateflow
    /// </summary>
    public class State : ISubflow
    {
        /// <summary>
        /// A string value which represents the designation value of the current state
        /// </summary>
        private readonly string _designation = string.Empty;
        /// <summary>
        /// An unsigned 32-bit integer value which represents the weight of the current state
        /// </summary>
        private uint _weight = default;
        /// <summary>
        /// Boolean parameter which defines the common stable representation of the current state
        /// </summary>
        private bool _stable = default;

        /// <summary>
        /// A signed 64-bit integer value which represents the private key for current state
        /// </summary>
#pragma warning disable IDE1006
        private long key { get; set; } = default;
#pragma warning restore IDE1006

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public State() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="key"></param>
        private State(long key)
        {
            this.key = key < 0 ? key * (-1) : key;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current state
        /// </param>
        public State(string designation)
        {
            _designation = designation;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current state
        /// </param>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current state
        /// </param>
        public State(string designation,
                     long key) : this(key)
        {
            _designation = designation;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current state
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current state
        /// </param>
        public State(string designation,
                     uint weight)
        {
            _designation = designation;
            _weight = weight;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current state
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current state
        /// </param>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current state
        /// </param>
        public State(string designation,
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
        /// A string value which represents the designation value of the current state
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current state
        /// </param>
        /// <param name="stable">
        /// Boolean parameter which defines the common stable representation of the current state
        /// </param>
        public State(string designation,
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
        /// A string value which represents the designation value of the current state
        /// </param>
        /// <param name="weight">
        /// An unsigned 32-bit integer value which represents the weight of the current state
        /// </param>
        /// <param name="stable">
        /// Boolean parameter which defines the common stable representation of the current state
        /// </param>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current state
        /// </param>
        public State(string designation,
                     uint weight,
                     bool stable,
                     long key) : this(key)
        {
            _designation = designation;
            _weight = weight;
            _stable = stable;
        }

        /// <summary>
        /// Function which returns an instance of <see cref="State"/> from defaults within given designation
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the state
        /// </param>
        /// <returns>
        /// A static instance of <see cref="State"/> which contains given designation value
        /// </returns>
        public static State GetFromDefaults(string designation)
        {
            string upper_designation = designation.ToUpper();

            return upper_designation switch
            {
                "UNKNOWN" => UNKNOWN,
                "SKIPPED" => SKIPPED,
                "PENDING" => PENDING,
                "FAILED" => FAILED,
                "STAGED" => STAGED,
                "ITERATING" => ITERATING,
                "PROCESSING" => PROCESSING,
                "SUCCESSFUL" => SUCCESSFUL,
                "INTERRUPTED" => INTERRUPTED,
                _ => EMPTY_STATE,
            };
        }

        /// <summary>
        /// Function which returns an instance of <see cref="State"/> in format of <see cref="ISubflow"/> from defaults within given designation
        /// </summary>
        /// <param name="designation">
        /// A string value which represents the designation value of the current state
        /// </param>
        /// <returns>
        /// A static instance of <see cref="State"/> in format of <see cref="ISubflow"/> which contains given designation value
        /// </returns>
        public static ISubflow GetInterfaces(string designation)
        {
            return (GetFromDefaults(designation) as ISubflow);
        }

        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State UNKNOWN { get; } = new("Unknown", 0, true);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State SKIPPED { get; } = new("Skipped", 1, true);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State PENDING { get; } = new("Pending", 2, true);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State FAILED { get; } = new("Failed", 3, false);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State STAGED { get; } = new("Staged", 4, false);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State ITERATING { get; } = new("Iterating", 5, false);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State PROCESSING { get; } = new("Processing", 6, true);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State SUCCESSFUL { get; } = new("Successful", 7, true);
        /// <summary>
        /// A static instance of the <see cref="State"/> which represents correspondive default combination
        /// </summary>
        public static State INTERRUPTED { get; } = new("Interrupted", 8, false);

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

        /// <summary>
        /// Method which transforms current instance from the given one
        /// </summary>
        /// <param name="another_state">
        /// An instance of <see cref="State"/> which represents other state of subflow
        /// </param>
        public void Transform(State another_state)
        {
            this._weight = (_weight + another_state.Weight) / 2;
            this._stable = (_stable ^ another_state.Stable);
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

            this.key = default;
        }

        /// <summary>
        /// Method which changes the identity of current instance through key
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current state
        /// </param>
        public void Reidentify(long key)
                            => this.key = key;

        /// <summary>
        /// Method which changes the identity of current instance through combination of key and coefficient
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current state
        /// </param>
        /// <param name="coef">
        /// A signed 32-bit integer value which represents coefficient with which combination of weights would be found
        /// </param>
        public void Reidentify(long key, int coef)
                            => this.key = (key ^ coef);

        /// <summary>
        /// A string value which represents the designation value of the current state
        /// </summary>
        public string Designation => _designation;
        /// <summary>
        /// An unsigned 32-bit integer value which represents the weight of the current state
        /// </summary>
        public uint Weight => _weight;
        /// <summary>
        /// Boolean parameter which defines the common stable representation of the current state
        /// </summary>
        public bool Stable => _stable;

        /// <summary>
        /// A signed 64-bit integer value which represents the private key for current state
        /// </summary>
        public long Key => this.key;

        /// <summary>
        /// An overriden default method which converts object to string
        /// </summary>
        /// <returns>
        /// A string value which represents the designation value of the current state
        /// </returns>
        public override string ToString()
        { return _designation; }

        /// <summary>
        /// An instance of <see cref="ISubflow"/> which represents this subflow's instance data
        /// </summary>
        public ISubflow Instance => this;

        /// <summary>
        /// An operator cast for mathematical operation of addition
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="State"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="State"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="State"/> which represents state after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// An operator cast for mathematical operation of subtraction
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="State"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="State"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="State"/> which represents state after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// An operator cast for mathematical operation of multiplication
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="State"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="State"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="State"/> which represents state after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// An operator cast for mathematical operation of division
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="State"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="State"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="State"/> which represents state after operator cast operation
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string values representing designations are different from each other
        /// </exception>
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

        /// <summary>
        /// A static instance of the <see cref="State"/> which represents an empty subflow
        /// </summary>
        public static State EMPTY_STATE { get; } = new();
    }
}
