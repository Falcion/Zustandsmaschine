using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Flow.Exceptions
{
    public class StateflowInitializationException : Exception
    {
        public StateflowInitializationException() { }

        public StateflowInitializationException(Stateflow obj, string message) : base(message) { }

        public StateflowInitializationException(Stateflow obj, string message, 
                                                            Exception inner) : 
                                                                 base(message, 
                                                                      inner) { }
    }
}
