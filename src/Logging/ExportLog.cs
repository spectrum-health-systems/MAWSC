// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Logging.ExportLog.cs
// Exports log data to the command line and/or a local file.
// b220531.085400 x

namespace MAWSC.Logging
{
    internal class ExportLog
    {
        /// <summary>Display log information on the console.</summary>
        /// <param name="logMessage">Log message to display.</param>
        internal static void ToConsole(string logMessage)
        { //x
            Console.WriteLine(logMessage);
        }

        /// <summary>Display log information on the console, and write it to a file.</summary>
        /// <param name="logMessage">Log message to display.</param>
        /// <param name="logfilePath">Logfile path.</param>
        internal static void ToEverywhere(string logMessage, string logfilePath)
        { //x
            ExportLog.ToFile(logMessage, logfilePath);
            ExportLog.ToConsole(logMessage);
        }

        /// <summary>Write log information to a file.</summary>
        /// <param name="logMessage">Log message to display.</param>
        /// <param name="logfilePath">Logfile path.</param>
        internal static void ToFile(string logMessage, string logfilePath)
        { //x
            Du.WithFile.AppendText(logMessage, logfilePath);
        }
    }
}