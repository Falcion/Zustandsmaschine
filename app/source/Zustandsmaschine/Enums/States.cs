using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustandsmaschine.Enums
{
    public enum States
    {
        UNKNOWN,
        FAILED,
        SKIPPED,
        PROCESSING,
        SUCCESSFUL,
    }

    public enum Shifts
    {
        BEGIN,
        PAUSE,
        RESUME,
        EXIT,
        STOP,
    }
}
