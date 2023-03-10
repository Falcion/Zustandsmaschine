using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OctokittyDISCORD.Items.Enums;
using OctokittyDISCORD.Items.Exceptions.State;

namespace OctokittyDISCORD.Machine.Subjects
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Stateflow
    {
        ///  <summary>
        /// 
        /// </summary>
        /// 
        private States state;

        ///  <summary>
        /// 
        /// </summary>
        private Shifts shift;

        ///  <summary>
        /// 
        /// </summary>
        public Stateflow()
        {
            this.state = new States();
            this.shift = new Shifts();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        public Stateflow(States state, Shifts shift)
        {
            this.state = state;
            this.shift = shift;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public Stateflow(States state)
        {
            this.state = state;
            shift = Shifts.BEGIN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        public Stateflow(Shifts shift)
        {
            state = States.UNKNOWN;
            this.shift = shift;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        /// <exception cref="StateflowNullableException"></exception>
        public void Update(States? state, Shifts? shift)
        {
            if (state == null)
            {
                if (shift == null)
                    throw new StateflowNullableException("When rewriting stateflow's data: an nullable state influence occured!");
                else
                    this.shift = (Shifts)shift;
            }
            else
            {
                if (shift == null)
                    this.state = (States)state;
                else
                {
                    this.state = (States)state;
                    this.shift = (Shifts)shift;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public States State { get; }

        /// <summary>
        /// 
        /// </summary>
        public Shifts Shift { get; }
    }
}
