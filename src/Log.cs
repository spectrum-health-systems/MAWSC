// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// MAWSC logging.
// b220127.144311

namespace MAWSC
{
    internal class Log
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string AppendAndDisplay(string origLogMsg, string logPrefix, string newLogMessage, string logSuffix, bool displayHelp = false)
        {
            var logMsgLine = BuildLogMsg(logPrefix, newLogMessage, logSuffix);

            if(displayHelp)
            {
                ToScreen(logMsgLine, true);
            }
            else
            {
                ToScreen(logMsgLine, false);
            }

            return $"{origLogMsg}{logMsgLine}{Environment.NewLine}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string BuildLogMsg(string logPrefix, string logMsg, string logSuffix)
        {
            var prefixAndMsg   = $"{logPrefix}{logMsg}";
            var totalMsgLength = prefixAndMsg.Length + logSuffix.Length;
            var dotString      = "";

            if(totalMsgLength <= 79)
            {
                dotString = new string('.', 80 - totalMsgLength);
            }

            return $"{prefixAndMsg}{dotString}{logSuffix}";
        }

        /// <summary>
        /// Write a log to a file.
        /// </summary>
        public static void WriteToFile(string logContent)
        {
            var logDirectory    = $@"C:\MyAvatool\MAWSC\Logs";
            var currentDateTime = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
            var logfilePath     = $"{logDirectory}/{currentDateTime}.log";

            File.WriteAllText(logfilePath, logContent);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ToScreen(string msgToDisplay, bool displayHelp)
        {
            /* If there was a fatal error, let the user know what it was, and point them to help information.
             */
            var displayContents = displayHelp
                ? $"{msgToDisplay}" +
                  $"{Environment.NewLine}" +
                  $"Please type \"MAWSC --help\" for more information"
                : msgToDisplay;

            Console.WriteLine($"{displayContents}");
        }
    }
}