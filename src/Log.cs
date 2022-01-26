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
        /// <summary>
        /// Write a log to a file.
        /// </summary>
        public static void ToFile(string logMessage)
        {
            var logDirectory    = $@"C:\MyAvatool\MAWSC\Logs";
            var currentDateTime = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
            var logfilePath     = $"{logDirectory}/{currentDateTime}.log";

            var logContent = $"MAWSC logging started..." +
                             $"{Environment.NewLine}" +
                             $"{logMessage}" +
                             $"{Environment.NewLine}" +
                             $"Exiting MAWSC...";

            File.WriteAllText(logfilePath, logContent);
        }

        /// <summary>
        /// Give the user progress updates on the screen.
        /// </summary>
        public static void ToScreen(string displayMessage)
        {
            Console.WriteLine($"  [MAWSC] {displayMessage}{ Environment.NewLine}");
        }

        /* If there was a fatal error, let the user know what it was, and point them to help information.
         */
        public static void ToScreen(string displayMessage, bool displayHelp)
        {
            var displayContents = $"  [MAWSC] {displayMessage}" +
                                  $"{Environment.NewLine}" +
                                  $"{Environment.NewLine}" +
                                  $"  Please type \"MAWSC --help\" for more information";

            Console.WriteLine($"{displayContents}");
        }
    }
}