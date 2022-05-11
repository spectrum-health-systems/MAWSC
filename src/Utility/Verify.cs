// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Utility.Verify.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025

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
        /// Verifies that at least one argument was passed.
        /// </summary>
        /// <param name="passedArgumentss">The args[] object.</param>
        /// <returns>A log message</returns>
        internal static void ArgumentsPassed(string[] commandLineArguments)
        {
            if(commandLineArguments.Length == 0)
            {
                var logNoArgumentsPassedMessage = MAWSC.Log.Component.NoArgumentsPassed();
                MAWSC.Log.Export.ToConsole(logNoArgumentsPassedMessage);
                MAWSC.Utility.Maintenance.Finalize(1);
            }
        }

        internal static string RequiredDirectories(Configuration mawscConfiguration)
        {
            var logRequiredDirectories = $"------------------------------{Environment.NewLine}" +
                                         $"Verifying required directories{Environment.NewLine}" +
                                         $"------------------------------{Environment.NewLine}";

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