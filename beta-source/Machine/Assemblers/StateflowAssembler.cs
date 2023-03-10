using OctokittyDISCORD.Items.Enums;
using OctokittyDISCORD.Items.Exceptions.State;

using OctokittyDISCORD.Machine.Subjects;
using System.ComponentModel.DataAnnotations;

namespace OctokittyDISCORD.Machine.Assemblers
{
    public class StateflowAssembler
    {
        private Stateflow? stateflow;

        private States? state;
        private Shifts? shift;

        public StateflowAssembler()
        {
            this.stateflow = new Stateflow();

            this.state = stateflow?.State;
            this.shift = stateflow?.Shift;
        }

        public StateflowAssembler(Stateflow? stateflow)
        {
            this.stateflow = stateflow;

            this.state = stateflow?.State;
            this.shift = stateflow?.Shift;
        }

        public StateflowAssembler(Stateflow? stateflow, States state, Shifts shift) : this(stateflow)
        {
            this.stateflow = stateflow;

            this.state = state;
            this.shift = shift;
        }

        public void Assemble(States? state)
        {
            this.state = state;
        }

        public void Assemble(Shifts? shift)
        {
            this.shift = shift;
        }

        public void Assemble(Stateflow? stateflow)
        {
            this.stateflow = stateflow;

            this.state = stateflow?.State;
            this.shift = stateflow?.Shift;
        }

        public void Assemble(Stateflow? stateflow, States? state, Shifts? shift)
        {
            this.stateflow = stateflow;

            this.state = state;
            this.shift = shift;
        }

        public void Disassemble()
        {
            this.stateflow = new Stateflow();

            this.state = new States();
            this.shift = new Shifts();
        }
    }
}