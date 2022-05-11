// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Utility.Maintenance.cs
// UPDATED: 220511.104821
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Maintenance stuff.
 */

namespace MAWSC.Utility
{
    internal class Maintenance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        internal static void Initialize(string mawscCommand, string mawscAction, string mawscOption, Configuration mawscConfiguration)
        {
            var logHeader = MAWSC.Log.Component.Header();
            var logCommandLineArguments = MAWSC.Log.Component.CommandLineArguments(mawscCommand, mawscAction, mawscOption);
            var logConfigurationInfo = MAWSC.Log.Component.ConfigurationInfo(mawscConfiguration);
            var logRequiredDirectories = MAWSC.Utility.Verify.RequiredDirectories(mawscConfiguration);

            var logMessage = $"{logHeader}{Environment.NewLine}" +
                             $"{logCommandLineArguments}{Environment.NewLine}" +
                             $"{logConfigurationInfo}{Environment.NewLine}" +
                             $"{logRequiredDirectories}{Environment.NewLine}";

            Log.Export.ToEverywhere(logMessage, mawscConfiguration.LogfilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        internal static void Finalize(int exitCode)
        {
            if(exitCode == 0)
            {
                Console.WriteLine($">>> MAWSC Exiting gracefully (Exit code {exitCode})...");
            }
            else
            {
                Console.WriteLine($">>> MAWSC Exiting with error (Exit code {exitCode})...");
            }

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Environment.Exit(exitCode);
        }
    }
}
