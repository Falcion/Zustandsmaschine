using System;
using System.Runtime;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Zustandsmaschine.Exceptions.Attributes
{
    /// <summary>
    /// An exception which assigned to nullable attributes of flow instance
    /// </summary>
    [Serializable()]
    public class NullableFlowAttributeException : Exception
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
        /// Constructor of instance for exception of nullable attribute
        /// </summary>
        public NullableFlowAttributeException() { }

        /// <summary>
        /// Constructor of instance for exception of nullable attribute
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        public NullableFlowAttributeException(string message) : base(message)
        {
            this.msg = message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message));    
        }

        /// <summary>
        /// Constructor of instance for exception of nullable attribute
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="identif">
        /// String value displaying custom identifier of exception for current instance
        /// </param>
        public NullableFlowAttributeException(string message, string identif) : base(message)
        {
            this.msg = message;
            this.idf = identif;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + identif));
        }

        /// <summary>
        /// Constructor of instance for exception of nullable attribute
        /// </summary>
        /// <param name="message">
        /// String value displaying current message of exception for current instance
        /// </param>
        /// <param name="inner"></param>
        public NullableFlowAttributeException(string message, Exception inner) : base(message, inner)
        {
            this.msg = message;

            string inner_message = inner.Message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + inner_message));
        }

        /// <summary>
        /// Constructor of instance for exception of nullable attribute
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
        public NullableFlowAttributeException(string message, string identif, Exception inner) : base(message, inner)
        {
            this.msg = message;
            this.idf = identif;

            string inner_message = inner.Message;

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(message + "/" + identif + "/" + inner_message));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NullableFlowAttributeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.msg = info.GetString("message");
            this.idf = info.GetString("identif");

            this.syn = SHA256.HashData(Encoding.Unicode.GetBytes(this.msg + "/" + this.idf));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue("message", this.msg);
            info.AddValue("identif", this.idf);

            base.GetObjectData(info, context);
        }

        /// <summary>
        /// String value displaying current message of exception
        /// </summary>
        public string? MSG { get { return msg; } }
        /// <summary>
        /// String value displaying custom identifier of exception
        /// </summary>
        public string? IDF { get { return idf; } }

        /// <summary>
        /// Array of byte data in SHA256's format displaying direction of synomibility for exceptions
        /// </summary>
        public byte[]? SYN { get { return syn; } }

        /// <summary>
        /// Exception defining inner instance of exception for base declaration
        /// </summary>
        public Exception? Inner { get { return inner;  } }
    }
}
