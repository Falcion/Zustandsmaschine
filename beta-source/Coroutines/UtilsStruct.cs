using System;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using OctokittyDISCORD.Coroutines.Base;

using OctokittyDISCORD.Items.Enums;
using OctokittyDISCORD.Items.Exceptions;

using OctokittyDISCORD.Machine.Subjects;

namespace OctokittyDISCORD.Coroutines
{
    ///  <summary>
    ///  A <see langword="sealed"/> <see langword="class"/> representing an utilities module.
    /// </summary>
    /// 
    public sealed class UtilsStruct : BaseStruct
    {
        ///  <summary>
        ///  Creating an ENV-JSON config file for bot's environmental variables.
        /// </summary>
        ///  <returns>
        ///  <see cref="Stateflow"/> representing result of method's task.
        /// </returns>
        /// 
        public static Stateflow PrepareENV()
        {
            /* Initializing instance of an method's state. */

            var method_stateflow = new Stateflow(States.UNKNOWN,
                                                 Shifts.BEGIN);

            if (!Directory.Exists(CONFIG_FOLDER))
                Directory.CreateDirectory(CONFIG_FOLDER);

            if(!File.Exists(CONFIG_PATH))
            {
                method_stateflow.Update(States.PROCESSING, 
                                        Shifts.RESUME);

                JObject JSON = new JObject(new JProperty("DISCORD_TOKEN", ""),
                                           new JProperty("GIT_API_TOKEN", ""),
                                           new JProperty("IGNORING_NULL", ""));

                using (var file = File.CreateText(CONFIG_PATH))
                    using (var writer = new JsonTextWriter(file))
                {
                    JSON.WriteTo(writer);
                }

                method_stateflow.Update(States.SUCCESSFUL, 
                                        Shifts.STOP);
            }
            else
                method_stateflow.Update(States.SKIPPED, 
                                        Shifts.EXIT);

            return method_stateflow;
        }

        ///  <summary>
        ///  Generating sample path of audit's journal file from zero.
        /// </summary>
        ///  <param name="path">
        ///  A <see langword="string"/> representing a path to audit's journal (file).
        /// </param>
        ///  <returns>
        ///  <see cref="Stateflow"/> representing result of method's task.
        /// </returns>
        /// 
        public static Stateflow PrepareLogs(string path)
        {
            if(!Directory.Exists(AUDITS_PATH))
                Directory.CreateDirectory(AUDITS_PATH);

            if(!File.Exists(path))
                File.Create(path);

            return new Stateflow(States.SUCCESSFUL, 
                                 Shifts.STOP);
        }

        ///  <summary>
        ///  Appending/writing buffer's byte into given by path file.
        /// </summary>
        ///  <param name="path">
        ///  A <see langword="string"/> representing a path to audit's journal (file).
        /// </param>
        ///  <param name="bytes">
        ///  An array of <see langword="8-bit integer"/> values representing buffer's contents of file 
        ///  which will be appended.
        /// </param>
        ///  <returns>
        ///  <see cref="Stateflow"/> representing result of method's task.
        /// </returns>
        /// 
        public static Stateflow InjectBytesIO(string path, byte[] bytes)
        {
            /* Initializing instance of an method's state. */

            var method_stateflow = new Stateflow(States.UNKNOWN,
                                                 Shifts.BEGIN);

            if (bytes == null)
            {
                method_stateflow.Update(States.FAILED,
                                        Shifts.EXIT);

                return method_stateflow;
            }

            using(var appender = File.OpenWrite(path))
            {
                var past_bytes = BitConverter.GetBytes(appender.ReadByte());

                method_stateflow.Update(States.PROCESSING, 
                                        Shifts.RESUME);

                if(past_bytes == null)
                {
                    appender.Write(bytes, 0, bytes.Count());

                    appender.Close();
                }
                else
                {
                    byte[] merged_bytes = (byte[]) past_bytes.Concat(bytes);

                    appender.Write(merged_bytes, 0, merged_bytes.Count());

                    appender.Close();
                }

                return method_stateflow;
            }
        }
    }
}