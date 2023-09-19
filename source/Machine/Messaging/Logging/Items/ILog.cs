using Zustand.Exceptions.General;
using Zustand.Machine.Messaging.Logging.Hierarchy;

namespace Zustand.Machine.Messaging.Logging.Items
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 
        /// </summary>
        public float Entropy { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// 
        /// </summary>
        public int Pos { get; }

        /// <summary>
        /// 
        /// </summary>
        [AllowOverrideDuringInitialization]
        public LogSeverity Severity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [AllowOverrideDuringInitialization]
        public LogTypes LogType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void RecreateLog(string message, int id, int pos, LogSeverity severity, LogTypes type);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILog<T> : ILog where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public new float Entropy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsValueUpstreamIo { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void RecreateValue(T value, bool isValueUpstreamIo);
    }
}
