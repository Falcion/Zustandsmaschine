using Zustand.Machine.Messaging.Logging.Hierarchy;

namespace Zustand.Machine.Messaging.Logging.Items
{
    /// <summary>
    /// 
    /// </summary>
    public class Log : ILog
    {
        #region Private fields
        /// <summary>
        /// 
        /// </summary>
        private float _entropy = -1.0F;

        /// <summary>
        /// 
        /// </summary>
        private string _message = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private int _pos;

        /// <summary>
        /// 
        /// </summary>
        private int _id;

        /// <summary>
        /// 
        /// </summary>
        private LogSeverity _severity = LogSeverity.UNKNOWN;

        /// <summary>
        /// 
        /// </summary>
        private LogTypes _type = LogTypes.INFO;
        #endregion
        #region Public fields
        /// <summary>
        /// 
        /// </summary>
        public float Entropy => _entropy;

        /// <summary>
        /// 
        /// </summary>
        public string Message => _message;
        /// <summary>
        /// 
        /// </summary>
        public int Id => _id;
        /// <summary>
        /// 
        /// </summary>
        public int Pos => _pos;
        /// <summary>
        /// 
        /// </summary>
        public LogSeverity Severity { get => _severity; set => RecreateLog(_message, _id, _pos, value, _type); }
        /// <summary>
        /// 
        /// </summary>
        public LogTypes LogType { get => _type; set => RecreateLog(_message, _id, _pos, _severity, value); }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <param name="pos"></param>
        /// <param name="severity"></param>
        /// <param name="type"></param>
#pragma warning disable S1006
        public void RecreateLog(string message, int id, int pos, LogSeverity severity = LogSeverity.UNKNOWN, LogTypes type = LogTypes.INFO)
#pragma warning restore S1006
        {
            _message = message;
            _id = id;
            _pos = pos;
            _severity = severity;
            _type = type;

            _entropy = float.NaN;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Log<T> : Log, ILog<T> where T : class
    {
        #region Private fields
        /// <summary>
        /// 
        /// </summary>
        private readonly Log _baseLog;

        /// <summary>
        /// 
        /// </summary>
        private T? _value = default;

        /// <summary>
        /// 
        /// </summary>
        private bool _isValueUpstreamIo = false;

        /// <summary>
        /// 
        /// </summary>
        private float _entropy = float.NaN;
        #endregion
        #region Public fields
        /// <summary>
        /// 
        /// </summary>
        public Log BaseLog => _baseLog;

        /// <summary>
        /// 
        /// </summary>
        public T? Value => _value;

        /// <summary>
        /// 
        /// </summary>
        public bool IsValueUpstreamIo => _isValueUpstreamIo;

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable S2292
        public new float Entropy { get => _entropy; set { _entropy = value; } }
#pragma warning restore S2292
        #endregion
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseLog"></param>
        public Log(Log baseLog)
        {
            _baseLog = baseLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseLog"></param>
        /// <param name="value"></param>
        /// <param name="isValueUpstreamIo"></param>
        public Log(Log baseLog, T? value, bool isValueUpstreamIo = false) : this(baseLog)
        {
            _value = value;
            _isValueUpstreamIo = isValueUpstreamIo;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseLog"></param>
        /// <param name="severity"></param>
        /// <param name="type"></param>
#pragma warning disable S1006
        public void RecreateLog(Log baseLog, LogSeverity severity = LogSeverity.UNKNOWN, LogTypes type = LogTypes.INFO)
        {
            _baseLog.RecreateLog(baseLog.Message, baseLog.Id, baseLog.Pos, severity, type);

            _entropy = (float)(Math.Cbrt(baseLog.Entropy * _entropy));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isValueUpstreamIo"></param>
        public void RecreateValue(T value, bool isValueUpstreamIo = false)
        {
            _value = value;
            _isValueUpstreamIo = isValueUpstreamIo;

            _entropy = (float)(Math.Pow(float.E, this.GetHashCode()));
        }
#pragma warning restore S1006
    }
}
