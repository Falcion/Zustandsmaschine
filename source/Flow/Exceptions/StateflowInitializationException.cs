namespace Zustand.Flow.Exceptions
{
    /// <summary>
    /// A class which represents an instance of <see cref="Exception"/> caused by error in constructing an instance for <see cref="Stateflow"/>
    /// </summary>
    public class StateflowInitializationException : Exception
    {
        /// <summary>
        /// An instance of <see cref="Stateflow"/> which caused an exception
        /// </summary>
        private readonly Stateflow? _data = null;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public StateflowInitializationException() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="data">
        /// An instance of <see cref="Stateflow"/> which caused an exception
        /// </param>
        public StateflowInitializationException(Stateflow data) : 
                                              base(Format(data))
        { _data = data; }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="data">
        /// An instance of <see cref="Stateflow"/> which caused an exception
        /// </param>
        /// <param name="message">
        /// A string value which represents a message for an instance of <see cref="Exception"/>
        /// </param>
        public StateflowInitializationException(Stateflow data, string message) 
                                                                : base(message)
        { _data = data; }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="data">
        /// An instance of <see cref="Stateflow"/> which caused an exception
        /// </param>
        /// <param name="message">
        /// A string value which represents a message for an instance of <see cref="Exception"/>
        /// </param>
        /// <param name="inner">
        /// An instance of <see cref="Exception"/> which represents inner exception for this one
        /// </param>
        public StateflowInitializationException(Stateflow data, string message, 
                                                             Exception inner) : 
                                                                  base(message, 
                                                                       inner)
        { _data = data; }

        /// <summary>
        /// An instance of <see cref="Stateflow"/> which caused an exception
        /// </summary>
        public Stateflow? Cause => _data;

        /// <summary>
        /// Private static method which formats string message for current instance
        /// </summary>
        /// <param name="data">
        /// An object which represents data storaged by current instance
        /// </param>
        /// <returns>
        /// A string value which represents a message for an instance of <see cref="Exception"/>
        /// </returns>
        private static string Format(object data)
        {
            return string.Format(string.Format("Exception was caused by null stateflow: {0}", data));
        }
    }
}
