using Zustand.Blocks.Items;

namespace Zustand.Machine.Messaging.Logging.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public Pair<string>? LogPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsIoActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsJsonMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isIoActive"></param>
        /// <param name="isJsonMode"></param>
        public LoggerConfig(bool isIoActive = true, bool isJsonMode = false)
        {
            IsIoActive = isIoActive;

            IsJsonMode = isJsonMode;

            if (!isJsonMode)
                LogPath = new Pair<string>("logs", $"{DateTime.Now.ToString("yyyy-MM-dd")}.logs");
            else
                LogPath = new Pair<string>("logs-json", $"{DateTime.Now.ToString("yyyy-MM-dd")}.json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isIoActive"></param>
        /// <param name="isJsonMode"></param>
        public LoggerConfig(string path, bool isIoActive = true, bool isJsonMode = false)
        {
            LogPath = new Pair<string>(Path.GetDirectoryName(path), Path.GetFileName(path));

            IsIoActive = isIoActive;
            IsJsonMode = isJsonMode;
        }
    }
}
