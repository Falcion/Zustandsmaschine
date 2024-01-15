namespace Zustand.Machine.Exceptions
{
    /// <summary>
    /// An exception instance which represents exception thrown when the assembler is null or empty
    /// </summary>
#pragma warning disable S3925
    public class AssemblerNullableException : Exception
#pragma warning restore S3925
    {
        /// <summary>
        /// A nullable instance of class which represents assembler in which exception was caused
        /// </summary>
        private readonly Assembler? _value = null;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public AssemblerNullableException() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="value">
        /// A nullable instance of class which represents assembler in which exception was caused
        /// </param>
        public AssemblerNullableException(Assembler? value)
        {
            _value = value;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="value">
        /// A nullable instance of class which represents assembler in which exception was caused
        /// </param>
        /// <param name="message"></param>
        public AssemblerNullableException(Assembler? value, string message)
                                                            : base(message)
        {
            _value = value;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="value">
        /// A nullable instance of class which represents assembler in which exception was caused
        /// </param>
        /// <param name="message">
        /// A string value representing the message with which exception is constructed
        /// </param>
        /// <param name="inner">
        /// An exception instance which represents the inner exception of this one instance
        /// </param>
        public AssemblerNullableException(Assembler? value, string message, 
                                                         Exception inner)
                                                            : base(message, 
                                                                   inner)
        {
            _value = value;
        }

        /// <summary>
        /// A nullable instance of class which represents assembler in which exception was caused
        /// </summary>
        public Assembler? Value => _value;
    }
}
