// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Logging.LogConent.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220509.112805 

/* =============================================================================
 * About this class
 * =============================================================================
 * Log content creation.
 */

using System.Reflection;

namespace MAWSC.Logging
{
    internal class LogContent
    {
        /// <summary>
        /// Build the start of a logfile.
        /// </summary>
        /// <param name="logContent">Existing log content.</param>
        internal static void BuildStartMessage(ref string logContent)
        {
            Version mawscVersion = Assembly.GetEntryAssembly().GetName().Version;

            logContent += $"{Environment.NewLine}" +
                          $"================================================================================{Environment.NewLine}" +
                          $"MAWSC {mawscVersion} started{Environment.NewLine}" +
                          $"================================================================================{Environment.NewLine}";

            /* Write the start message to the console, so the user knows MAWSC has started.
             */
            Console.WriteLine(logContent);
        }

        /// <summary>
        /// Append a log message to logContent.
        /// </summary>
        /// <param name="logContent">Existing log content.</param>
        /// <param name="logMessagePrefix">Prefix for the this message (e.g., "[  CHECK] "</param>
        /// <param name="logMessage">Log message to append (e.g., "Checking value").</param>
        /// <param name="logMessageSuffix">Suffix for the log message (e.g., "OK")</param>
        internal static void AppendAndShowMsg(ref string logContent, string logMessagePrefix, string logMessage, string logMessageSuffix)
        {
            var logMsgFinal = BuildMessage(logMessagePrefix, logMessage, logMessageSuffix);

            logContent = $"{logContent}{logMsgFinal}{Environment.NewLine}";

            /* Write the message to the console, so the user knows what's happening.
             */
            Console.WriteLine(logMsgFinal);
        }

        /// <summary>
        /// Build a nice looking log message (e.g., "[  CREATE] Creating a file....................OK")
        /// </summary>
        /// <param name="logMessagePrefix">Prefix for the this message (e.g., "[  CHECK] "</param>
        /// <param name="logMessage">Log message to append (e.g., "Checking value").</param>
        /// <param name="logMessageSuffix">Suffix for the log message (e.g., "OK")</param>
        /// <returns></returns>
        private static string BuildMessage(string logMessagePrefix, string logMessage, string logMessageSuffix)
        {
            var prefixAndMessage                = $"{logMessagePrefix}{logMessage}";
            var prefixAndMessageAndSuffixLength = prefixAndMessage.Length + logMessageSuffix.Length;

            string dotString;

            // TODO There is a better way to do this, and maybe make it so subsequent entries (e.g., "MOVE" and "MOVED")
            //      have the same length. And potentially lock a specific length, maybe even just for logfiles.
            /* This makes sure that longer lines look ok.
             */
            if(prefixAndMessageAndSuffixLength <= 77)
            {
                dotString = new string('.', 80 - prefixAndMessageAndSuffixLength);
            }
            else if(prefixAndMessageAndSuffixLength >= 81 && prefixAndMessageAndSuffixLength <= 100)
            {
                dotString = new string('.', 100 - prefixAndMessageAndSuffixLength);
            }
            else if(prefixAndMessageAndSuffixLength >= 101 && prefixAndMessageAndSuffixLength <= 120)
            {
                dotString = new string('.', 120 - prefixAndMessageAndSuffixLength);
            }
            else
            {
                dotString = "...";
            }

            return $"{prefixAndMessage}{dotString}{logMessageSuffix}";
        }

        /// <summary>
        /// Build the end of a logfile.
        /// </summary>
        /// <param name="logContent">Existing log content.</param>
        /// <param name="exitCode">The exit code, where 0 = no error and 1 = error.</param>
        internal static void BuildEndMessage(string logContent, int exitCode)
        {
            logContent += $"{Environment.NewLine}" +
              $"================================================================================{Environment.NewLine}" +
              $"MAWSC exiting{Environment.NewLine}" +
              $"================================================================================{Environment.NewLine}";

            /* An exitCode that != 0 means something went wrong, and we should prompt the user to view the help details.
             */
            if(exitCode != 0)
            {
                logContent += $"{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"Please type \"MAWSC --help\" for more information";
            }

            /* Write the message to the console, so the user knows what's happening.
             */
            Console.WriteLine(logContent);

            WriteLogToFile(logContent);
        }

        /// <summary>
        /// Write logContents to a file.
        /// </summary>
        /// <param name="logContent">Existing log content.</param>
        private static void WriteLogToFile(string logContent)
        {
            var logDirectory    = $@"C:\MyAvatool\MAWSC\Logs";
            var currentDateTime = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
            var logfilePath     = $"{logDirectory}/{currentDateTime}.log";

            File.WriteAllText(logfilePath, logContent);
        }
    }
}