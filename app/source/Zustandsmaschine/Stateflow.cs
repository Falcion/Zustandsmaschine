using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustandsmaschine.Enums;
using Zustandsmaschine.Exceptions;

namespace Zustandsmaschine
{
    public class Stateflow
    {
        private States? _state;
        private Shifts? _shift;

        private int _hash;

        public Stateflow()
        {
            _state = new States();
            _shift = new Shifts();
        }

        public Stateflow(States? state, Shifts? shift)
        {
            _state = state;
            _shift = shift;
        }

        public Stateflow(States? state)
        {
            _state = state;
            _shift = null;
        }

        public Stateflow(Shifts? shift)
        {
            _state = null;
            _shift = shift;
        }

        public Stateflow(Stateflow? stateflow)
        {
            if (stateflow == null)
                throw new StateflowNullableException();
        }

        public void Update(States? state, Shifts? shift)
        {
            _state = state;
            _shift = shift;

            _hash = state.GetHashCode() + shift.GetHashCode();
        }

        public void Flush()
        {
            _state = new States();
            _shift = new Shifts();

            Update(_state, _shift);
        }

        public States? State { get { return _state; } }
        public Shifts? Shift { get { return _shift; } }

        public int Hash { get { return _hash; } }
    }
}
