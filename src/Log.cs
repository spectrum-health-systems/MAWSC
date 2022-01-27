// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// MAWSC logging.
// b220126.170648

namespace MAWSC
{
    internal class Log
    {
        public static string AppendAndDisplay(string origLogMsg, string newLogMsg, bool displayHelp = false, bool exitMawsc = false)
        {
            if(displayHelp)
            {
                ToScreen(origLogMsg, true);
            }
            else
            {
                ToScreen(origLogMsg, false);
            }

            return origLogMsg + newLogMsg;
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
                ? $"  [MAWSC] {msgToDisplay}" +
                  $"{Environment.NewLine}" +
                  $"{Environment.NewLine}" +
                  $"  Please type \"MAWSC --help\" for more information"
                : msgToDisplay;

            Console.WriteLine($"{displayContents}");
        }
    }
}