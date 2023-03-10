using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustandsmaschine.Exceptions
{
    [Serializable]
    public sealed class StateflowNullableException : Exception
    {
        public StateflowNullableException() { }

        public StateflowNullableException(string message) : base(message) { }

        public StateflowNullableException(string message, Exception inner) : base(message, inner) { }

        public StateflowNullableException(string message, Stateflow state) : base(message + ": " + state.ToString()) { }

        private StateflowNullableException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
