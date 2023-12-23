using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Data.Types.Interfaces
{
    public interface IData
    {
        public void Swap();
        public void Move();

        public void Nullify();
    }
}
