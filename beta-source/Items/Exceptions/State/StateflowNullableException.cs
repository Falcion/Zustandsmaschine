using System;
using System.Runtime;
using System.Runtime.Serialization;

namespace OctokittyDISCORD.Items.Exceptions.State
{
    ///  <summary>
    ///  An <see cref="Exception">exception</see> of null <see cref="Stateflow">stateflow's</see> updating instance.
    /// </summary>
    /// 
    ///  <remarks>
    ///  <i>This type of data is a <see cref="SerializableAttribute">serializable</see>: it means it cannot be inherited and can be serialized.</i>
    /// </remarks>
    /// 

    [Serializable]
    public sealed class StateflowNullableException : Exception
    {
        ///  <summary>
        ///  A <see langword="nullable 32-bit integer"/> value representing ID's data of exception.
        /// </summary>
        /// 
        readonly int? data;

        ///  <summary>
        ///  A <see langword="nullable string"/> representing a message of an <see cref="Exception">exception</see>.
        /// </summary>
        /// 
        readonly string? message;

        ///  <summary>
        ///  An inner <see langword="nullable"/> <see cref="Exception">exception</see> of current instance's data if it exists.
        /// </summary>
        readonly Exception? inner;

        ///  <summary>
        ///  A basic constructor of <see cref="StateflowNullableException">exception's</see> instance.
        /// </summary>
        /// 
        public StateflowNullableException() { }

        ///  <summary>
        ///  A constructor of <see cref="StateflowNullableException">exception's</see> instance through <see langword="base"/>.
        /// </summary>
        ///  <param name="data">
        ///  A <see langword="32-bit integer"/> representing an integer (ID) data of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        /// 
        public StateflowNullableException(int data) : base(String.Format("Custom exception with data {0}.", data))
        {
            this.data = data;
        }

        ///  <summary>
        ///  A constructor of <see cref="StateflowNullableException">exception's</see> instance through message and <see langword="base"/>.
        /// </summary>
        ///  <param name="data">
        ///  A <see langword="32-bit integer"/> representing an integer (ID) data of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        ///  <param name="message">
        ///  A <see langword="string"/> representing a message of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        /// 
        public StateflowNullableException(int data, string message) : base(String.Format("Custom exception with data {0}.", data))
        {
            this.data = data;
            this.message = message;
        }

        ///  <summary>
        ///  A constructor of <see cref="StateflowNullableException">exception's</see> instance through message, inner's exception and <see langword="base"/>.
        /// </summary>
        ///  <param name="data">
        ///  A <see langword="32-bit integer"/> representing an integer (ID) data of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        ///  <param name="message">
        ///  A <see langword="string"/> representing a message of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        ///  <param name="inner">
        ///  An <see cref="Exception">inner's exception</see> of current instance's base.
        /// </param>
        /// 
        public StateflowNullableException(int data, string message, Exception inner) : base(String.Format("Custom exception with data {0}.", data))
        {
            this.data = data;
            this.message = message;
            this.inner = inner;
        }

        ///  <summary>
        ///  A constructor of <see cref="StateflowNullableException">exception's</see> instance through message and <see langword="base"/>.
        /// </summary>
        ///  <param name="message">
        ///  A <see langword="string"/> representing a message of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        /// 
        public StateflowNullableException(string message) : base(message)
        {
            this.message = message;
        }

        ///  <summary>
        ///  A constructor of <see cref="StateflowNullableException">exception's</see> instance through message, inner's exception and <see langword="base"/>.
        /// </summary>
        ///  <param name="message">
        ///  A <see langword="string"/> representing a message of an <see cref="StateflowNullableException">exception's</see> instance.
        /// </param>
        ///  <param name="inner">
        ///  An <see cref="Exception">inner's exception</see> of current instance's base.
        /// </param>
        /// 
        public StateflowNullableException(string message, Exception inner) : base(message)
        {
            this.message = message;
            this.inner = inner; 
        }

        ///  <summary>
        ///  Private serializer of <see cref="StateflowNullableException">exception's instance</see>.
        /// </summary>
        ///  <param name="info">
        ///  A <see cref="SerializationInfo">serialization info</see> provided for current instance's serializer.
        /// </param>
        ///  <param name="context">
        ///  A <see cref="StreamingContext">streaming context</see> provided fro current instance's serializer.
        /// </param>
        ///  <exception cref="ArgumentNullException">
        ///  Thrown when provided <see cref="SerializationInfo">serialization info</see> is <see langword="null"/>.
        /// </exception>
        /// 
        private StateflowNullableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            this.data = info.GetInt32(nameof(data));
        }

        /// <summary>
        ///  Function of updating current instance's base data through context and debug-info.
        /// </summary>
        ///  <param name="info">
        ///  A <see cref="SerializationInfo">serialization info</see> provided for current instance's dataserializer.
        /// </param>
        ///  <param name="context">
        ///  A <see cref="StreamingContext">streaming context</see> provided fro current instance's data serializer.
        /// </param>
        ///  <exception cref="ArgumentNullException">
        ///  Thrown when provided <see cref="SerializationInfo">serialization info</see> is <see langword="null"/>.
        /// </exception>
        /// 
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            /* Implementing data into exception's base. */

            info.AddValue(nameof(data), this.data);

            /* And writing it into custom exception's context through updated base. */

            base.GetObjectData(info, context);
        }

        ///  <summary>
        ///  A lambda-function of returning ID's data of exception.
        /// </summary>
        /// 
        public new int? Data => this.data;

        ///  <summary>
        ///  A lambda-function of returning message's data of exception.
        /// </summary>
        /// 
        public new string? Message => this.message;

        ///  <summary>
        ///  A lambda-function of returning inner's data of exception.
        /// </summary>
        /// 
        public Exception? Inner => this.inner;
    }
}