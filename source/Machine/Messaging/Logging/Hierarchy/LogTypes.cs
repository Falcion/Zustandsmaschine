using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Machine.Messaging.Logging.Hierarchy
{
    /// <summary>
    /// 
    /// </summary>
    public enum LogTypes : uint
    {
        /// <summary>
        /// 
        /// </summary>
        INFO,
        /// <summary>
        /// 
        /// </summary>
        WARN,
        /// <summary>
        /// 
        /// </summary>
        ERROR,
        /// <summary>
        /// 
        /// </summary>
        FATAL,
        /// <summary>
        /// 
        /// </summary>
        TRACE,
        /// <summary>
        /// 
        /// </summary>
        STACK,
        /// <summary>
        /// 
        /// </summary>
        DEBUG,
    }
}
