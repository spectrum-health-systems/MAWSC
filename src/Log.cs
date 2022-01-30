// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Loggin logic for MAWS Commander
// b220130.083155

namespace MAWSC
{
    internal class Log
    {
        /// <summary>
        /// Show a log message on the console, and add it to the existing logContent.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="logMsgPrefix">The prefix for the log message (e.g., "[  CHECK] ")</param>
        /// <param name="logMsg">The log message (e.g., "Checking value").</param>
        /// <param name="logMsgSuffix">The suffix for the log message (e.g., "OK")</param>
        /// <returns></returns>
        public static string AppendAndShow(string logContent, string logMsgPrefix, string logMsg, string logMsgSuffix)
        {
            var logMsgComplete = BuildLogMsgLine(logMsgPrefix, logMsg, logMsgSuffix);

            Console.WriteLine(logMsgComplete);

            return $"{logContent}{logMsgComplete}{Environment.NewLine}";
        }

        /// <summary>
        /// Build a nice looking message line.
        /// </summary>
        /// <param name="logMsgPrefix">The prefix for the log message (e.g., "[  CHECK] ")</param>
        /// <param name="logMsg">The log message (e.g., "Checking value").</param>
        /// <param name="logMsgSuffix">The suffix for the log message (e.g., "OK")</param>
        /// <returns></returns>
        private static string BuildLogMsgLine(string logMsgPrefix, string logMsg, string logMsgSuffix)
        {
            /* This creates a nice looking 80-character message.
             * 
             * ex. "[  CREATE] Creating a file....................OK
             */
            var prefixAndMsg                = $"{logMsgPrefix}{logMsg}";
            var prefixAndMsgAndSuffixLength = prefixAndMsg.Length + logMsgSuffix.Length;

            /* If the length of the completed line is less than 77, fill the rest with dots. Otherwise, just put three
             * dots between the prefix/msg and suffix. There isn't a cutoff, so lines >80 characters won't look great.
             */
            var dotString = prefixAndMsgAndSuffixLength <= 77
                ? new string('.', 80 - prefixAndMsgAndSuffixLength)
                : "...";

            return $"{prefixAndMsg}{dotString}{logMsgSuffix}";
        }

        /// <summary>
        /// Write logContents to a file.
        /// </summary>
        /// <param name="logContent"></param>
        public static void WriteToFile(string logContent)
        {
            var logDirectory    = $@"C:\MyAvatool\MAWSC\Logs";
            var currentDateTime = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
            var logfilePath     = $"{logDirectory}/{currentDateTime}.log";

            File.WriteAllText(logfilePath, logContent);
        }
    }
}