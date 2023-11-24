using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Subflow.Interfaces
{
    public interface ISubflow
    {
        public string Designation { get; }

        public uint Weight { get; }
        public bool Stable { get; }

        public long Key { get; }

        public void Transform(uint delta_weight);
        public void Transform(uint delta_weight, int coef);
        public void Transform(bool delta_stable);
        public void Transform(bool delta_stable, char opers);
        public void Transform(ISubflow another_flow);

        public void Irrationalize();

        public void Parallel();

        public void Nullify();

        public void Reidentify(long key);
        public void Reidentify(long key, int coef);    
    }
}
