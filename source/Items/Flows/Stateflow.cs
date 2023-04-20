using Zustandsmaschine.Enums;
using Zustandsmaschine.Items.Interfaces;

namespace Zustandsmaschine.Items.Flows
{
    /// <summary>
    /// A class which represents stateflow and its basic instance
    /// </summary>
    public class Stateflow : IFlow
    {
        /// <summary>
        /// Enum classified value representing state of current flow
        /// </summary>
        private States? state;
        /// <summary>
        /// Enum classified value representing shift of current flow
        /// </summary>
        private Shifts? shift;

        /// <summary>
        /// Classified value representing inner stateflow of double powered instance for flow
        /// </summary>
        private Stateflow? stateflow;

        /// <summary>
        /// A 32-bit integer value representing integer hash of given instance and degree of current unsync and instability of the flow
        /// </summary>
        private int? code;

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        public Stateflow()
        {
            this.state = new States();
            this.shift = new Shifts();

            this.stateflow = null;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        public Stateflow(States? state)
        {
            this.state = state;
            this.shift = null;

            this.stateflow = null;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public Stateflow(States? state, Stateflow? stateflow)
        {
            this.state = state;
            this.shift = stateflow?.Shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        public Stateflow(Shifts? shift)
        {
            this.state = null;
            this.shift = shift;

            this.stateflow = null;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public Stateflow(Shifts? shift, Stateflow? stateflow)
        {
            this.state = stateflow?.State;
            this.shift = shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public Stateflow(Stateflow? stateflow)
        {
            this.state = stateflow?.State;
            this.shift = stateflow?.Shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public Stateflow(States? state, Shifts? shift, Stateflow? stateflow)
        {
            this.state = state;
            this.shift = shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        /// <param name="code">
        /// A 32-bit integer value representing integer hash of given instance and degree of current unsync and instability of the flow for current instance
        /// </param>
        public Stateflow(States? state, Shifts? shift, Stateflow? stateflow, int? code)
        {
            this.state = state;
            this.shift = shift;

            this.stateflow = stateflow;

            this.code = code;
        }

        /// <summary>
        /// Constructor of instance for stateflow
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        public Stateflow(States? state, Shifts? shift)
        {
            this.state = state;
            this.shift = shift;

            this.stateflow = null;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        public void Update(States? state)
        {
            this.state = state;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public void Update(States? state, Stateflow? stateflow)
        {
            this.state = state;
            this.shift = stateflow?.Shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        public void Update(Shifts? shift)
        {
            this.shift = shift;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public void Update(Shifts? shift, Stateflow? stateflow)
        {
            this.shift = shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public void Update(Stateflow? stateflow)
        {
            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        public void Update(States? state, Shifts? shift, Stateflow? stateflow)
        {
            this.state = state;
            this.shift = shift;

            this.stateflow = stateflow;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow for current instance
        /// </param>
        /// <param name="code">
        /// A 32-bit integer value representing integer hash of given instance and degree of current unsync and instability of the flow for current instance
        /// </param>
        public void Update(States? state, Shifts? shift, Stateflow? stateflow, int? code)
        {
            this.state = state;
            this.shift = shift;

            this.stateflow = stateflow;

            this.code = code;
        }

        /// <summary>
        /// Method updating params of current instance of flow with given arrangement
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow for current instance
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow for current instance
        /// </param>
        public void Update(States? state, Shifts? shift)
        {
            this.state = state;
            this.shift = shift;

            this.code = GenHASH(this.state, this.shift, this.stateflow);
        }

        /// <summary>
        /// Method clearing current params of instance and randomizing current code for instability check
        /// </summary>
        public void Flush()
        {
            this.state = new States();
            this.shift = new Shifts();

            this.stateflow = null;

            this.code = new Random().Next(int.MinValue, 
                                          int.MaxValue);
        }

        /// <summary>
        /// Static function generating default unchecked integer hash from given instance of a stateflow
        /// </summary>
        /// <param name="state">
        /// Enum classified value representing state of current flow
        /// </param>
        /// <param name="shift">
        /// Enum classified value representing shift of current flow
        /// </param>
        /// <param name="stateflow">
        /// Classified value representing inner stateflow of double powered instance for flow
        /// </param>
        /// <returns>
        /// A 32-bit integer value representing integer hash of given instance and degree of current unsync and instability of the flow
        /// </returns>
        protected static int GenHASH(States? state, Shifts? shift, Stateflow? stateflow)
        {
            unchecked
            {
                int hash = 17;
                hash *= 31 + state.GetHashCode();
                hash *= 31 + shift.GetHashCode();

                if (stateflow != null)
                    hash *= 31 + stateflow.GetHashCode();
                else
                    hash *= 31 + int.Abs(state.GetHashCode() - shift.GetHashCode());

                return hash;
            }
        }

        /// <summary>
        /// Enum classified value representing state of current flow
        /// </summary>
        public States? State { get { return this.state; } }
        /// <summary>
        /// Enum classified value representing shift of current flow
        /// </summary>
        public Shifts? Shift { get { return this.shift; } }

        /// <summary>
        /// Classified value representing inner stateflow of double powered instance for flow
        /// </summary>
        public Stateflow? Flow { get { return this.stateflow; } }

        /// <summary>
        /// A 32-bit integer value representing integer hash of given instance and degree of current unsync and instability of the flow
        /// </summary>
        public int? Code {  get { return this.code; } }
    }
}