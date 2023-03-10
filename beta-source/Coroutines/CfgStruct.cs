using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using OctokittyDISCORD.Coroutines.Base;
using OctokittyDISCORD.Coroutines.Logging;

using OctokittyDISCORD.Items.Enums;

using OctokittyDISCORD.Machine.Subjects;

namespace OctokittyDISCORD.Coroutines
{
    ///  <summary>
    ///  A <see langword="sealed"/> <see langword="class"/> representing module of methods, fields for work with config.
    /// </summary>
    /// 
    public sealed class CfgStruct : BaseStruct
    {
        ///  <summary>
        ///  A const <see langword="string"/> defined for calculating hashcode for case of an <see cref="Environment.Exit(int)">environment exit</see>.
        /// </summary>
        /// 
        const string BUILT_MESSAGE = "ENV file didn't exist! Generating and creating one-sessioned file, required input!";

        ///  <summary>
        ///  Initializing first instances of ENV configs: or reading it if it has already existed.
        /// </summary>
        ///  <returns>
        ///  <see cref="Stateflow"/> representing result of method's task.
        /// </returns>
        /// 
        public Stateflow Init()
        {
            if(!Directory.Exists(CONFIG_FOLDER))
                Directory.CreateDirectory(CONFIG_FOLDER);

            if(!File.Exists(CONFIG_PATH))
            {
                UtilsStruct.PrepareENV();

                int hashcode = BUILT_MESSAGE.GetHashCode();

                LogsStruct.Scream.Warn("ENV file didn't exist; generating and filling one, it is required to type data in it; shutting down the project", "CONFIG");

                Environment.Exit(hashcode);

                return new Stateflow(States.SUCCESSFUL, Shifts.EXIT);
            }
            else
                return ReturnENV();
        }

        ///  <summary>
        ///  Reading ENV data in JSON formatting with help of: <see cref="Newtonsoft"/>.
        /// </summary>
        ///  <returns>
        ///  <see cref="Stateflow"/> representing result of method's task.
        /// </returns>
        /// 
        public Stateflow ReturnENV()
        {
            /* Initializing instance of an method's state. */

            var method_stateflow = new Stateflow(States.UNKNOWN,
                                                 Shifts.BEGIN);

            using(var source = File.OpenText(CONFIG_PATH))
                using(var reader = new JsonTextReader(source))
            {
                JObject? data = JToken.ReadFrom(reader) as JObject;

                method_stateflow.Update(States.PROCESSING, null);

                if (data == null)
                {
                    LogsStruct.Scream.Error(
                                 new FileNotFoundException("Failed to read an ENV's properties! Restart the bot immediately!"));

                    method_stateflow.Update(States.FAILED, 
                                            Shifts.EXIT);
                }
                else
                {
                    Environment.SetEnvironmentVariable("DISCORD_TOKEN", data["DISCORD_TOKEN"]?.Value<string?>());
                    Environment.SetEnvironmentVariable("GIT_API_TOKEN", data["GIT_API_TOKEN"]?.Value<string?>());

                    Environment.SetEnvironmentVariable("IGNORING_NULL", data["IGNORING_NULL"]?.Value<string?>());

                    method_stateflow.Update(States.SUCCESSFUL, 
                                            Shifts.STOP);
                }
            }

            return method_stateflow;
        }
    }
}