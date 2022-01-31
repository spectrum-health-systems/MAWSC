// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// Loggin logic for MAWS Commander
// b220131.115810

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
        public static void AppendAndShowMsg(ref string logContent, string logMsgPrefix, string logMsg, string logMsgSuffix)
        {
            var logMsgFinal = BuildLogMsg(logMsgPrefix, logMsg, logMsgSuffix);

            Console.WriteLine(logMsgFinal);

            logContent = $"{logContent}{logMsgFinal}{Environment.NewLine}";
        }

        /// <summary>
        /// Build a nice looking message line.
        /// </summary>
        /// <param name="logMsgPrefix">The prefix for the log message (e.g., "[  CHECK] ")</param>
        /// <param name="logMsg">The log message (e.g., "Checking value").</param>
        /// <param name="logMsgSuffix">The suffix for the log message (e.g., "OK")</param>
        /// <returns>A nice looking log message.</returns>
        private static string BuildLogMsg(string logMsgPrefix, string logMsg, string logMsgSuffix)
        {
            /* This creates a nice looking message.
             * 
             * ex. "[  CREATE] Creating a file....................OK
             */
            var prefixAndMsg                = $"{logMsgPrefix}{logMsg}";
            var prefixAndMsgAndSuffixLength = prefixAndMsg.Length + logMsgSuffix.Length;

            string dotString;

            // TODO There is a better way to do this, and maybe make it so subsequent entries (e.g., "MOVE" and "MOVED")
            //      have the same length. And potentially lock a specific length, maybe even just for logfiles.
            /* This makes sure that longer lines look ok.
             */
            if(prefixAndMsgAndSuffixLength <= 77)
            {
                dotString = new string('.', 80 - prefixAndMsgAndSuffixLength);
            }
            else if(prefixAndMsgAndSuffixLength >= 81 && prefixAndMsgAndSuffixLength <= 100)
            {
                dotString = new string('.', 100 - prefixAndMsgAndSuffixLength);
            }
            else if(prefixAndMsgAndSuffixLength >= 101 && prefixAndMsgAndSuffixLength <= 120)
            {
                dotString = new string('.', 120 - prefixAndMsgAndSuffixLength);
            }
            else
            {
                dotString = "...";
            }

            return $"{prefixAndMsg}{dotString}{logMsgSuffix}";
        }

        /// <summary>
        /// Generate the end of the log information.
        /// </summary>
        /// <param name="logContent">Existing logContent.</param>
        /// <param name="exitCode">"0" is no error, "1" is error.</param>
        public static void GenerateLogContentIntro(string logContent, int exitCode)
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
            WriteLogToFile(logContent);
        }

        /// <summary>
        /// Write logContents to a file.
        /// </summary>
        /// <param name="logContent"></param>
        public static void WriteLogToFile(string logContent)
        {
            var logDirectory    = $@"C:\MyAvatool\MAWSC\Logs";
            var currentDateTime = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
            var logfilePath     = $"{logDirectory}/{currentDateTime}.log";

            File.WriteAllText(logfilePath, logContent);
        }
    }
}