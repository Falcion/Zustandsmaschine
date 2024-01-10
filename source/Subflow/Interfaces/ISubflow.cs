namespace Zustand.Subflow.Interfaces
{
    /// <summary>
    /// An interface which represents instance for subflow common data type
    /// </summary>
    public interface ISubflow
    {
        /// <summary>
        /// A string value which represents the designation value of the current shift
        /// </summary>
        public string Designation { get; }

        /// <summary>
        /// An unsigned 32-bit integer value which represents the weight of the current shift
        /// </summary>
        public uint Weight { get; }

        /// <summary>
        /// Boolean parameter which defines the common stable representation of the current shift
        /// </summary>
        public bool Stable { get; }

        /// <summary>
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </summary>
        public long Key { get; }

        /// <summary>
        /// Method which appends the weight of current instance by given value
        /// </summary>
        /// <param name="delta_weight">
        /// An unsigned 32-bit integer value which represents weight added to the current instance
        /// </param>
        public void Transform(uint delta_weight);
        /// <summary>
        /// Method which appends the weight of current instance by combination of given value and coefficient
        /// </summary>
        /// <param name="delta_weight">
        /// An unsigned 32-bit integer value which represents weight added to the current instance
        /// </param>
        /// <param name="coef">
        /// A signed 32-bit integer value which represents coefficient with which combination of weights would be found
        /// </param>
        public void Transform(uint delta_weight, int coef);
        /// <summary>
        /// Method which changes current value of stable parameter for current instance
        /// </summary>
        /// <param name="delta_stable">
        /// Boolean parameter which represents new value of stable parameter in current instance
        /// </param>
        public void Transform(bool delta_stable);
        /// <summary>
        /// Method which changes current value of stable parameter for current instance within given boolean operator mode
        /// </summary>
        /// <param name="delta_stable">
        /// Boolean parameter which represents new value of stable parameter in current instance
        /// </param>
        /// <param name="opers">
        /// A char value which represents type of logical operation which would be used with current instance stable parameter
        /// </param>
        public void Transform(bool delta_stable, char opers);
        /// <summary>
        /// Method which transforms current instance from the given interface
        /// </summary>
        /// <param name="another_flow">
        /// An instance of <see cref="ISubflow"/> which represents other subflow's instance data
        /// </param>
        public void Transform(ISubflow another_flow);

        /// <summary>
        /// Method which sets stable parameter by default as unstable
        /// </summary>
        public void Irrationalize();

        /// <summary>
        /// Method which reassembles non-essential data of instance within specified behavior
        /// </summary>
        public void Parallel();

        /// <summary>
        /// Method which resets every non-essential value to default
        /// </summary>
        public void Nullify();

        /// <summary>
        /// Method which changes the identity of current instance through key
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        public void Reidentify(long key);
        /// <summary>
        /// Method which changes the identity of current instance through combination of key and coefficient
        /// </summary>
        /// <param name="key">
        /// A signed 64-bit integer value which represents the private key for current shift
        /// </param>
        /// <param name="coef">
        /// A signed 32-bit integer value which represents coefficient with which combination of weights would be found
        /// </param>
        public void Reidentify(long key, int coef);
    }
}
