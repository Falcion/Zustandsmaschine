using System;
using System.Runtime;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography;
using System.Text;

using Zustandsmaschine.Items.Flows;

namespace Zustandsmaschine.Exceptions.Flows
{
    /// <summary>
    /// An exception which assigned to null stateflow instance
    /// </summary>
    [Serializable()]
    public class NullableStateflowException : Exception
    {
        /// <summary>
        /// String value displaying current message of exception
        /// </summary>
        private readonly string? msg;
        /// <summary>
        /// String value displaying custom identifier of exception
        /// </summary>
        private readonly string? idf;
        /// <summary>
        /// Array of byte data in SHA256's format displaying direction of synomibility for exceptions
        /// </summary>
        private readonly byte[]? syn;

        /// <summary>
        /// Exception defining inner instance of exception for base declaration
        /// </summary>
        private readonly Exception? inner;

        /// <summary>
        /// Classified value representing a stateflow from which error had occured
        /// </summary>
        private readonly Stateflow? stateflow;

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        public NullableStateflowException() { }

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="stateflow">
        /// Classified value representing a stateflow from which error had occured for current instance
        /// </param>
        public NullableStateflowException(Stateflow stateflow)
        {
            this.stateflow = stateflow;

            int undercode = stateflow.Code.GetValueOrDefault();

            this.syn = SHA256.HashData(BitConverter.GetBytes(undercode));
        }

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        public NullableStateflowException(string message) : base(message)
        {
            this.msg = message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message));
        }

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing a stateflow from which error had occured for current instance
        /// </param>
        public NullableStateflowException(string message, Stateflow stateflow) : base(message)
        {
            this.msg = message;

            this.stateflow = stateflow;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + $"{stateflow.Code.GetValueOrDefault()}"));
        }

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="identif">
        /// String value displaying custom identifier of exception for current instance
        /// </param>
        public NullableStateflowException(string message, string identif) : base(message)
        {
            this.msg = message;
            this.idf = identif;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + identif));
        }


        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="identif">
        /// String value displaying custom identifier of exception for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing a stateflow from which error had occured for current instance
        /// </param>
        public NullableStateflowException(string message, string identif, Stateflow stateflow) : base(message)
        {
            this.msg = message;
            this.idf = identif;

            this.stateflow = stateflow;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + identif + "/" + $"{stateflow.Code.GetValueOrDefault()}"));
        }

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="inner">
        /// Exception defining inner instance of exception for base declaration for current instance
        /// </param>
        public NullableStateflowException(string message, Exception inner) : base(message, inner)
        {
            this.msg = message;

            string inner_message = inner.Message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + inner_message));
        }

        /// <summary>
        /// Constructor of instance for exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="identif">
        /// String value displaying custom identifier of exception for current instance
        /// </param>
        /// <param name="inner">
        /// Exception defining inner instance of exception for base declaration for current instance
        /// </param>
        public NullableStateflowException(string message, string identif, Exception inner) : base(message, inner)
        {
            this.msg = message;
            this.idf = identif;

            string inner_message = inner.Message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + identif + "/" + inner_message));
        }

        /// <summary>
        /// Constructor of instance for exception
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="identif">
        /// String value displaying custom identifier of exception for current instance
        /// </param>
        /// <param name="inner">
        /// Exception defining inner instance of exception for base declaration for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing a stateflow from which error had occured for current instance
        /// </param>
        public NullableStateflowException(string message, string identif, Exception inner, Stateflow stateflow) : base(message, inner)
        {
            this.msg = message;
            this.idf = identif;

            string inner_message = inner.Message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + identif + "/" + inner_message + "/" + $"{stateflow.Code.GetValueOrDefault()}"));
        }

        /// <summary>
        /// Constructor of instance for an exception
        /// </summary>
        /// <param name="info">
        /// Serialization info parameter defining common data of current serialization process
        /// </param>
        /// <param name="context">
        /// Context parameter of current stream of serialization info in common subprocess
        /// </param>
        protected NullableStateflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.msg = info.GetString("message");
            this.idf = info.GetString("identif");

            this.stateflow = (Stateflow?)info.GetValue("stateflow", typeof(Stateflow));

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(this.msg + "/" + this.idf));
        }

        /// <summary>
        /// Method parsing exceptions data through serialization info
        /// </summary>
        /// <param name="info">
        /// Serialization info parameter defining common data of current serialization process
        /// </param>
        /// <param name="context">
        /// Context parameter of current stream of serialization info in common subprocess
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when serialization stream got nullable information about current serialization process
        /// </exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue("message", this.msg);
            info.AddValue("identif", this.idf);

            info.AddValue("stateflow", this.stateflow);

            base.GetObjectData(info, context);
        }

        /// <summary>
        /// String value displaying current message of exception
        /// </summary>
        public string? MSG { get { return this.msg; } }
        /// <summary>
        /// String value displaying custom identifier of exception
        /// </summary>
        public string? IDF { get { return this.idf; } }

        /// <summary>
        /// Array of byte data in SHA256's format displaying direction of synomibility for exceptions
        /// </summary>
        public byte[]? SYN { get { return this.syn; } }

        /// <summary>
        /// Exception defining inner instance of exception for base declaration
        /// </summary>
        public Exception? Inner { get { return this.inner; } }

        /// <summary>
        /// Classified value representing a stateflow from which error had occured
        /// </summary>
        public Stateflow? Stateflow { get { return this.stateflow; } }
    }
}
