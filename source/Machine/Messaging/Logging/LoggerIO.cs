using System.Text;

namespace Zustand.Machine.Messaging.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggerIO
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _dirpath;
        /// <summary>
        /// 
        /// </summary>
        private readonly string _filename;
        /// <summary>
        /// 
        /// </summary>
        private readonly bool _upstream;

        /// <summary>
        /// 
        /// </summary>
        private bool _isDiffEnv = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirpath"></param>
        /// <param name="filename"></param>
        /// <param name="upstream"></param>
        public LoggerIO(string dirpath, string filename, bool upstream = true)
        {
            _dirpath = dirpath;
            _filename = filename;

            _upstream = upstream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="upstream"></param>
        public LoggerIO(string path, bool upstream = true)
        {
            _dirpath = Path.GetDirectoryName(path) ?? "";
            _filename = Path.GetFileName(path);

            _upstream = upstream;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckEnvironment()
        {
            if (!string.IsNullOrEmpty(_dirpath) && !Directory.Exists(_dirpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(_dirpath);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (!File.Exists(LogPath))
                File.Create(LogPath);

            string? checkingEnv = Environment.GetEnvironmentVariable("LOG_MODULE_PATH", EnvironmentVariableTarget.Process);

            if (!string.IsNullOrEmpty(checkingEnv))
            {
                Environment.SetEnvironmentVariable("ZUSTAND_CUSTOM_PARAM_LOG_MODULE_PATH", LogPath, 
                                                                EnvironmentVariableTarget.Process);
                _isDiffEnv = true;
            }
            else
            {
                Environment.SetEnvironmentVariable("LOG_MODULE_PATH", LogPath, EnvironmentVariableTarget.Process);
                _isDiffEnv = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string? GetEnvLogPath()
        {
            if (_isDiffEnv)
                return Environment.GetEnvironmentVariable("ZUSTAND_CUSTOM_PARAM_LOG_MODULE_PATH", 
                        EnvironmentVariableTarget.Process);
            else
                return Environment.GetEnvironmentVariable("LOG_MODULE_PATH",
                        EnvironmentVariableTarget.Process);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDiffEnv"></param>
        /// <returns></returns>
        public static string? GetEnvLogPath(bool isDiffEnv)
        {
            if (isDiffEnv)
                return Environment.GetEnvironmentVariable("ZUSTAND_CUSTOM_PARAM_LOG_MODULE_PATH",
                        EnvironmentVariableTarget.Process);
            else
                return Environment.GetEnvironmentVariable("LOG_MODULE_PATH",
                        EnvironmentVariableTarget.Process);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void WriteText(string? message)
        {
            CheckEnvironment();

            File.AppendAllText(LogPath, message, encoding: Encoding.UTF8);
        }

        /// <summary>
        /// 
        /// </summary>
        public string LogPath { get { return Path.Combine(_dirpath, _filename); } }
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpstreamIo => _upstream;
    }
}
