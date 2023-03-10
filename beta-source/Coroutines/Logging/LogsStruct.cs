using System;
using System.Diagnostics;
using System.Text;
using OctokittyDISCORD.Coroutines;
using OctokittyDISCORD.Coroutines.Base;

namespace OctokittyDISCORD.Coroutines.Logging
{
    ///  <summary>
    ///  An evolutioned <see langword="sealed"/> <see langword="class"/> which is working with logging methods and context.
    /// </summary>
    /// 
    public sealed class LogsStruct : BaseStruct
    {
        ///  <summary>
        ///  A <see langword="const 32-bit integer"/> representing how much frames every <see cref="StackFrame">stackframe</see> is skipping.
        /// </summary>
        /// 
        private const int STACK_FRAMES = 2;

        ///  <summary>
        ///  A substruct <see langword="class"/> defining methods which working with <see cref="Console">console</see> output.
        /// </summary>
        /// 
        public static class Scream
        {
            ///  <summary>
            ///  A method to print custom <see langword="string"/> message with formatting into IO and red color.
            /// </summary>
            ///  <param name="message">
            ///  A custom <see langword="string"/> parameter defining message of an event.
            /// </param>
            ///  <param name="code_pos">
            ///  A custom <see langword="string"/> parameter defining in which code's group event happened.
            /// </param>
            /// 
            public static void Error(string message, string code_pos = "DEFAULT")
            {
                var stackframe = new StackFrame(STACK_FRAMES);

                string? method_name = stackframe.GetMethod()?.Name;
                string? method_type = stackframe.GetMethod()?.GetType()?.Name;

                string audit_path = AUDITS_PATH + "audits-" + GetCurrentDate() + ".logs";

                if(!File.Exists(audit_path))
                    UtilsStruct.PrepareLogs(audit_path);

                string audit_constr = $"[ERROR/{code_pos}]:[STACKFRAME: {method_name}/{method_type}] {message}";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(audit_constr);

                /* 
                 * Appending/writing bytes data into audit file (of current date's session),
                 * its faster and we declaring encoding at start. 
                 */

                using (var writer = File.OpenWrite(audit_path))
                {
                    byte[] contents = Encoding.UTF8.GetBytes(audit_constr);

                    UtilsStruct.InjectBytesIO(audit_path, contents);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            ///  <summary>
            ///  A method to print custom exception with formatting into IO and red color.
            /// </summary>
            ///  <param name="exception">
            ///  A generic type <see cref="Exception">exception</see> which will be thrown in IO and code.
            /// </param>
            ///  <param name="code_pos">
            ///  A custom <see langword="string"/> parameter defining in which code's group event happened.
            /// </param>
            /// 
            public static void Error(Exception exception, string code_pos = "DEFAULT")
            {
                var stackframe = new StackFrame(STACK_FRAMES);

                string? method_name = stackframe.GetMethod()?.Name;
                string? method_type = stackframe.GetMethod()?.GetType()?.Name;

                string audit_path = AUDITS_PATH + "audits-" + GetCurrentDate() + ".logs";

                if(!File.Exists(audit_path))
                    UtilsStruct.PrepareLogs(audit_path);

                string? exception_source = exception.Source;

                if (exception_source == null)
                    exception_source = "NULL";

                string exception_message = exception.Message;

                string audit_constr = $"[ERROR/{code_pos}]:[STACKFRAME: {method_name}/{method_type}] [SOURCE={(exception_source).ToUpper()}] {exception_message}";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(audit_constr);

                /* 
                 * Appending/writing bytes data into audit file (of current date's session),
                 * its faster and we declaring encoding at start. 
                 */

                using (var writer = File.OpenWrite(audit_path))
                {
                    byte[] contents = Encoding.UTF8.GetBytes(audit_constr);

                    UtilsStruct.InjectBytesIO(audit_path, contents);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }


            ///  <summary>
            ///  A method to print custom <see langword="string"/> message with formatting into IO and yellow color.
            /// </summary>
            ///  <param name="message">
            ///  A custom <see langword="string"/> parameter defining message of an event.
            /// </param>
            ///  <param name="code_pos">
            ///  A custom <see langword="string"/> parameter defining in which code's group event happened.
            /// </param>
            ///  <param name="is_io">
            ///  A <see langword="boolean"/> representing will method write message into audit.
            /// </param>
            /// 
            public static void Warn(string message, string code_pos = "DEFAULT", bool is_io = false)
            {
                var stackframe = new StackFrame(STACK_FRAMES);

                string? method_name = stackframe.GetMethod()?.Name;
                string? method_type = stackframe.GetMethod()?.GetType()?.Name;

                string audit_path = AUDITS_PATH + "audits-" + GetCurrentDate() + ".logs";

                if(!File.Exists(audit_path))
                    UtilsStruct.PrepareLogs(audit_path);

                string audit_constr = $"[ERROR/{code_pos}]:[STACKFRAME: {method_name}/{method_type}] {message}";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(audit_constr);

                /* 
                 * Appending/writing bytes data into audit file (of current date's session),
                 * its faster and we declaring encoding at start. 
                 */

                if (is_io)
                {
                    using (var writer = File.OpenWrite(audit_path))
                    {
                        byte[] contents = Encoding.UTF8.GetBytes(audit_constr);

                        UtilsStruct.InjectBytesIO(audit_path, contents);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            ///  <summary>
            ///  A method to print custom <see langword="string"/> message with formatting into IO and green color.
            /// </summary>
            ///  <param name="message">
            ///  A custom <see langword="string"/> parameter defining message of an event.
            /// </param>
            ///  <param name="code_pos">
            ///  A custom <see langword="string"/> parameter defining in which code's group event happened.
            /// </param>
            ///  <param name="is_io">
            ///  A <see langword="boolean"/> representing will method write message into audit.
            /// </param>
            /// 
            public static void Success(string message, string code_pos = "DEFAULT", bool is_io = false)
            {
                var stackframe = new StackFrame(STACK_FRAMES);

                string? method_name = stackframe.GetMethod()?.Name;
                string? method_type = stackframe.GetMethod()?.GetType()?.Name;

                string audit_path = AUDITS_PATH + "audits-" + GetCurrentDate() + ".logs";

                if(!File.Exists(audit_path))
                    UtilsStruct.PrepareLogs(audit_path);

                string audit_constr = $"[ERROR/{code_pos}]:[STACKFRAME: {method_name}/{method_type}] {message}";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(audit_constr);

                /* 
                 * Appending/writing bytes data into audit file (of current date's session),
                 * its faster and we declaring encoding at start. 
                 */

                if (is_io)
                {
                    using (var writer = File.OpenWrite(audit_path))
                    {
                        byte[] contents = Encoding.UTF8.GetBytes(audit_constr);

                        UtilsStruct.InjectBytesIO(audit_path, contents);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            ///  <summary>
            ///  A method to print custom <see langword="string"/> message with formatting into IO and white color.
            /// </summary>
            ///  <param name="message">
            ///  A custom <see langword="string"/> parameter defining message of an event.
            /// </param>
            ///  <param name="code_pos">
            ///  A custom <see langword="string"/> parameter defining in which code's group event happened.
            /// </param>
            ///  <param name="is_io">
            ///  A <see langword="boolean"/> representing will method write message into audit.
            /// </param>
            /// 
            public static void Log(string message, string code_pos = "DEFAULT", bool is_io = false)
            {
                var stackframe = new StackFrame(STACK_FRAMES);

                string? method_name = stackframe.GetMethod()?.Name;
                string? method_type = stackframe.GetMethod()?.GetType()?.Name;

                string audit_path = AUDITS_PATH + "audits-" + GetCurrentDate() + ".logs";

                if(!File.Exists(audit_path))
                    UtilsStruct.PrepareLogs(audit_path);

                string audit_constr = $"[ERROR/{code_pos}]:[STACKFRAME: {method_name}/{method_type}] {message}";

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(audit_constr);

                /* 
                 * Appending/writing bytes data into audit file (of current date's session),
                 * its faster and we declaring encoding at start. 
                 */

                if (is_io)
                {
                    using (var writer = File.OpenWrite(audit_path))
                    {
                        byte[] contents = Encoding.UTF8.GetBytes(audit_constr);

                        UtilsStruct.InjectBytesIO(audit_path, contents);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}