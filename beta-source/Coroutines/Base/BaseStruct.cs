namespace OctokittyDISCORD.Coroutines.Base
{
    ///  <summary>
    ///  A base <see langword="abstract"/> <see langword="class"/> for all coroutines classes.
    /// </summary>
    /// 
    public abstract class BaseStruct
    {
        ///  <summary>
        ///  A predescribed <see langword="string"/> path to an ENV's folder config with JSON formatting.
        /// </summary>
        /// 
        public const string CONFIG_FOLDER = "settings/";

        ///  <summary>
        ///  A predescribed <see langword="string"/> path to an ENV config with JSON formatting.
        /// </summary>
        /// 
        public const string CONFIG_PATH = "settings/config.json";

        ///  <summary>
        ///  A predescribed <see langword="string"/> path to an audit's journal directory.
        /// </summary>
        /// 
        public const string AUDITS_PATH = "audit-journals/";

        ///  <summary>
        ///  Function formatting now's date into a <see langword="string"/>.
        /// </summary>
        ///  <returns>
        ///  A <see langword="string"/> representing a time formatted in locale time with fully <see cref="DateTime.Now">described date</see>.
        /// </returns>
        /// 
        public static string GetCurrentDate()
        {
            string formattedDate = DateTime.Now.ToString("dd/MM/yyyy");

            return formattedDate;
        }

        ///  <summary>
        ///  Function formatting now's date time into a <see langword="string"/>.
        /// </summary>
        ///  <returns>
        ///  A <see langword="string"/> representing a time formatted in locale time with fully <see cref="DateTime.Now">described time</see>.
        /// </returns>
        /// 
        public static string GetCurrentTime()
        {
            string formattedTime = DateTime.Now.ToString("HH/mm/ss/s");

            return formattedTime;
        }
    }
}
