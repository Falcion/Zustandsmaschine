using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Flow.Exceptions
{
    public class StateflowInitializationException : Exception
    {
        private readonly Stateflow? _obj = null;

        public StateflowInitializationException() { }

        public StateflowInitializationException(Stateflow obj) : 
                                              base(Format(obj))
        { _obj = obj; }

        public StateflowInitializationException(Stateflow obj, string message) 
                                                               : base(message)
        { _obj = obj; }

        public StateflowInitializationException(Stateflow obj, string message, 
                                                            Exception inner) : 
                                                                 base(message, 
                                                                      inner)
        { _obj = obj; }

        public Stateflow? Obj => _obj;

        private static string Format(object data)
        {
            return string.Format(string.Format("Exception was caused by null stateflow: {0}", data));
        }
    }
}
