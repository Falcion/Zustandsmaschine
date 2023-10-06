using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Machine.Messaging.Logging.Config;

namespace Zustand.Machine.Messaging.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// 
        /// </summary>
        public static Logger Instance { get => new Logger(); }

        /// <summary>
        /// 
        /// </summary>
        private readonly string? _name;
        /// <summary>
        /// 
        /// </summary>
        private readonly int? _id;

        /// <summary>
        /// 
        /// </summary>
        private readonly LoggerConfig _config;

        /// <summary>
        /// 
        /// </summary>
        public Logger()
        {
            _config = new LoggerConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Logger(LoggerConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        public string? Name => _name;

        /// <summary>
        /// 
        /// </summary>
        public int? Id => _id;

        /// <summary>
        /// 
        /// </summary>
        public LoggerConfig LoggerConfig => _config;
    }
}
