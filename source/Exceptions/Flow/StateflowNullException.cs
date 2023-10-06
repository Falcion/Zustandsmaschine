using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Flow;

namespace Zustand.Exceptions.Flow
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
#pragma warning disable S3925
    public class StateflowNullException : Exception
#pragma warning restore S3925
    {
        private readonly Stateflow? _object;

        /// <summary>
        /// 
        /// </summary>
        public StateflowNullException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateflow"></param>
        public StateflowNullException(Stateflow stateflow) : base("")
        {
            _object = stateflow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateflow"></param>
        /// <param name="message"></param>
        public StateflowNullException(Stateflow stateflow, string message) : base(message)
        {
            _object = stateflow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        protected StateflowNullException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public Stateflow? Object => _object;
    }
}
