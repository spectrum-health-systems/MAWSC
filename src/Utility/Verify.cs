// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Utility.Verify.cs
// UPDATED: 220511.104821
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Verifies stuff.
 */

namespace MAWSC.Utility
{
    internal class Verify
    {
        /// <summary>
        /// Verifies that at least one argument was passed via the command line.
        /// </summary>
        /// <param name="passedArgumentss">Arguments passed via the command line.</param>
        internal static void ArgumentsPassed(string[] commandLineArguments)
        {
            /* In order to do anything, MAWSC needs - at a minimum - a command passed as an 
             * argument via the command line. If there aren't any passed arguments, we can't do
             * anything, so just exit MAWSC.
             */
            if(commandLineArguments.Length == 0)
            {
                var logNoArgumentsPassedMessage = MAWSC.Log.Component.NoArgumentsPassed();
                MAWSC.Log.Export.ToConsole(logNoArgumentsPassedMessage);
                MAWSC.Utility.Maintenance.Finalize(1);
            }
        }

        /// <summary>
        /// Verify that required directories exist, and create them if they don't.
        /// </summary>
        /// <param name="mawscConfiguration">MAWSC configuration settings.</param>
        /// <returns>A log message.</returns>
        internal static string RequiredDirectories(Configuration mawscConfiguration)
        {
            var logRequiredDirectories = $"------------------------------{Environment.NewLine}" +
                                         $"Verifying required directories{Environment.NewLine}" +
                                         $"------------------------------{Environment.NewLine}";

            /* By default, these directories are always going to be in ./AppData/. If you have
             * modified these values in the mawsc-config.json file, they should still work, but
             * that hasn't been tested.
             */
            var requiredDirectories = new List<string>
            {
                mawscConfiguration.ConfigDirectory,
                mawscConfiguration.LogDirectory,
                mawscConfiguration.BackupDirectory,
                mawscConfiguration.TemporaryDirectory
            };

            foreach(var requiredDirectory in requiredDirectories)
            {
                if(!Directory.Exists(requiredDirectory))
                {
                    logRequiredDirectories += $"{requiredDirectory} does not exist.{Environment.NewLine}";
                    _=Directory.CreateDirectory(requiredDirectory);
                    logRequiredDirectories += $"{requiredDirectory} created.{Environment.NewLine}";
                }
                else
                {
                    logRequiredDirectories += $"{requiredDirectory} exists.{Environment.NewLine}";
                }
            }

            return logRequiredDirectories;
        }
    }
}