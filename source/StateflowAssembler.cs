using Zustand.Subjects;

namespace Zustand
{
    public class StateflowAssembler
    {
        private Stateflow _stateflow;
        private long _code = 0;

        private readonly Dictionary<int, Stateflow> _interactions = new();

        #region Constructors
        public StateflowAssembler()
        {
            _stateflow = new();

            PostInit();
        }

        public StateflowAssembler(States state)
        {
            _stateflow = new(state);

            PostInit();
        }

        public StateflowAssembler(States state, Stateflow inner)
        {
            _stateflow = new(state, inner);

            PostInit();
        }

        public StateflowAssembler(Shifts shift)
        {
            _stateflow = new(shift);

            PostInit();
        }

        public StateflowAssembler(Shifts shift, Stateflow inner)
        {
            _stateflow = new(shift, inner);

            PostInit();
        }

        public StateflowAssembler(Stateflow inner)
        {
            _stateflow = new(inner);

            PostInit();
        }

        public StateflowAssembler(Stateflow? inner, States state, Shifts shift)
        {
            _stateflow = new(inner, state, shift);

            PostInit();
        }

        #endregion

        #region Updaters
        public void Assemble(States state)
        {
            _stateflow.Update(state);

            PostInit();
        }

        public void Assemble(States state, Stateflow inner)
        {
            _stateflow.Update(state, inner);

            PostInit();
        }

        public void Assemble(Shifts shift)
        {
            _stateflow.Update(shift);

            PostInit();
        }

        public void Assemble(Shifts shift, Stateflow inner)
        {
            _stateflow.Update(shift, inner);

            PostInit();
        }

        public void Assemble(Stateflow inner)
        {
            _stateflow.Update(inner);

            PostInit();
        }

        public void Assemble(Stateflow? inner, States state, Shifts shift)
        {
            _stateflow.Update(inner, state, shift);

            PostInit();
        }

        #endregion

        public void Redeploy(string message)
        {
            Deployment.AddMessage(message);
        }

        public void Redeploy(string message, long codes)
        {
            Deployment.AddMessage(message, codes);
        }

        public void Redeploy(string message, long codes, long scope)
        {
            Deployment.AddMessage(message, codes, scope);
        }

        public void Disassemble()
        {
            _stateflow = new Stateflow();

            _code = 0;
        }

        public void Analyze()
        {
            var shift = _stateflow.Shift;
            var state = _stateflow.State;

            switch (state.Name)
            {
                case "Unknown":
                    if (shift == Shifts.EXIT || shift == Shifts.MOMENTUM)
                    {
                        string message = state.Name + "::" + shift.Name + " is caught in current instance of assembly!";
                        Redeploy(message, message.GetHashCode(), -1);
                    }
                    else
                        _code *= 31 + (long)Math.Pow(_code, 2);
                    break;
                case "Failed":
                    if (shift == Shifts.EXIT || shift == Shifts.MOMENTUM)
                    {
                        string message = state.Name + "::" + shift.Name + " is caught in current instance of assembly!";
                        Redeploy(message, message.GetHashCode(), -1);
                    }
                    break;
                case "Staged":
                    if (shift == Shifts.EXIT || shift == Shifts.STAGE || shift == Shifts.PAUSE)
                    {
                        string message = state.Name + "::" + shift.Name + " is caught in current instance of assembly!";
                        Redeploy(message, message.GetHashCode(), -1);
                    }
                    break;
                case "Skipped":
                    if (shift == Shifts.EXIT || shift == Shifts.STAGE || shift == Shifts.PAUSE)
                    {
                        string message = state.Name + "::" + shift.Name + " is caught in current instance of assembly!";
                        Redeploy(message, message.GetHashCode(), -1);
                    }
                    break;
                case "Processing":
                    if (shift == Shifts.EXIT)
                    {
                        string message = state.Name + "::" + shift.Name + " is caught in current instance of assembly!";
                        Redeploy(message, message.GetHashCode(), -1);
                    }
                    break;
                case "Successful":
                    if (shift == Shifts.STOP)
                    {
                        string message = state.Name + "::" + shift.Name + " is caught in current instance of assembly!";
                        Redeploy(message, message.GetHashCode(), -1);
                    }
                    break;
            }
        }

        public void Analyze(Stateflow flow)
        {
            if (_stateflow.State.Weight > flow.State.Weight && _stateflow.Shift.Weight > flow.Shift.Weight)
            {
                string refcode = "[REF: " + _stateflow.State.Weight.ToString() + ">" + (flow.State.Weight).ToString() + " && " + (_stateflow.Shift.Weight).ToString() + ">" + (flow.Shift.Weight).ToString() + "]";
                string message = "Analyzer of inner stabilizers called within, result - SUCCESS! " + refcode;
                Redeploy(message);
            }
            else if (_stateflow.State.Weight > flow.State.Weight && _stateflow.Shift.Weight < flow.Shift.Weight)
            {
                string refcode = "[REF: " + _stateflow.State.Weight.ToString() + ">" + (flow.State.Weight).ToString() + " && " + (_stateflow.Shift.Weight).ToString() + "<" + (flow.Shift.Weight).ToString() + "]";
                string message = "Analyzer of inner stabilizers called within, result - UNKNOWN! " + refcode;
                Redeploy(message, message.GetHashCode(), -1);
            }
            else if (_stateflow.State.Weight < flow.State.Weight && _stateflow.Shift.Weight > flow.Shift.Weight)
            {
                string refcode = "[REF: " + _stateflow.State.Weight.ToString() + "<" + flow.State.Weight.ToString() + " && " + (_stateflow.Shift.Weight).ToString() + ">" + (flow.Shift.Weight).ToString() + "]";
                string message = "Analyzer of inner stabilizers called within, result - UNKNOWN! " + refcode;
                Redeploy(message, message.GetHashCode(), -1);
            }
            else
            {
                string refcode = "[REF: " + (_stateflow.State.Weight).ToString() + "<" + (flow.State.Weight).ToString() + " && " + (_stateflow.Shift.Weight).ToString() + "<" + (flow.Shift.Weight).ToString() + "]";
                string message = "Analyzer of inner stabilizers called within, result - FAILED! " + refcode;
                Redeploy(message, message.GetHashCode(), -1);
            }
        }

        private void PostInit()
        {
            _interactions.Add(0, _stateflow);

            _code = _stateflow.Code;
        }

        public Stateflow Stateflow => _stateflow;
        public Deployment Deployment { get; } = new Deployment();
        public long Code => _code;

        public Dictionary<int, Stateflow> Interactions => _interactions;
    }
}
