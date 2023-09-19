using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zustand.Machine.Messaging.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggerJSONIO
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
        public void WriteJSON(string serialized_object)
        {
            CheckEnvironment();

            File.AppendAllText(LogPath, serialized_object, encoding: Encoding.UTF8);
        }

        public void WriteJSON(object? message)
        {
            CheckEnvironment();

            var contents = System.Text.Json.JsonSerializer.Deserialize<Array>(File.ReadAllText(LogPath, Encoding.UTF8));

            if(contents == null)
#pragma warning disable S3928
                throw new ArgumentNullException(nameof(contents), "Environment for logger is broken, please, check the IO submodule or recreate the logs file!");
#pragma warning restore S3928

            Array new_contents = new dynamic[contents.Length+1];

            Array.Copy(contents, new_contents, contents.Length);

            new_contents.SetValue(message, contents.Length);
                
            var data = JsonSerializer.Serialize(new_contents);

            File.WriteAllText(LogPath, data, encoding: Encoding.UTF8);
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
