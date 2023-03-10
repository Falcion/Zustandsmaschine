using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustandsmaschine.Exceptions
{
    [Serializable]
    public sealed class StateflowException : Exception
    {
        public StateflowException() { }

        public StateflowException(string message) : base(message) { }

        public StateflowException(string message, Exception inner) : base(message, inner) { }

        public StateflowException(string message, Stateflow state) : base(message + ": " + state.ToString()) { }
    }
}
