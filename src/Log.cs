// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// Loggin logic for MAWS Commander
// b20130.101224

using System.Reflection;

namespace MAWSC
{
    internal class Log
    {
        /// <summary>
        /// Generate the start of the log information.
        /// </summary>
        /// <param name="logContent">Existing logContent.</param>
        public static void GenerateLogContentIntro(ref string logContent)
        {
            Version? mawscVersion = Assembly.GetEntryAssembly().GetName().Version;

            logContent += $"{Environment.NewLine}" +
                          $"================================================================================{Environment.NewLine}" +
                          $"MAWS Commander {mawscVersion} started{Environment.NewLine}" +
                          $"================================================================================{Environment.NewLine}";

            Console.WriteLine(logContent);
        }

        /// <summary>
        /// Append a single log message to logContent, and also show that log message on the console.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="logMsgPrefix">The prefix for the log message (e.g., "[  CHECK] ")</param>
        /// <param name="logMsg">The log message (e.g., "Checking value").</param>
        /// <param name="logMsgSuffix">The suffix for the log message (e.g., "OK")</param>
        /// <returns></returns>
        public static void AppendAndShow(ref string logContent, string logMsgPrefix, string logMsg, string logMsgSuffix)
        {
            var logMsgFinal = BuildLogMsgLine(logMsgPrefix, logMsg, logMsgSuffix);

            Console.WriteLine(logMsgFinal);

            logContent = $"{logContent}{logMsgFinal}{Environment.NewLine}";
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
        /// 
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="exitCode"></param>
        public static void EndLogging(string logContent, int exitCode)
        {
            logContent += $"{Environment.NewLine}" +
              $"================================================================================{Environment.NewLine}" +
              $"MAWS Commander exiting{Environment.NewLine}" +
              $"================================================================================{Environment.NewLine}";

            /* An exitCode that != 0 means something went wrong, and we should prompt the user to view the help details.
             */
            if(exitCode != 0)
            {
                logContent += $"{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"Please type \"MAWSC --help\" for more information";
            }

            Console.WriteLine(logContent);
            Log.WriteToFile(logContent);
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