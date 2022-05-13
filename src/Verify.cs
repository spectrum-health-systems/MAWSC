// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Utility.Verify.cs
// UPDATED: 220513.093416
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Verifies stuff.
 */

namespace MAWSC
{
    internal class Verify
    {
        /// <summary>
        /// Verify that MAWSC requirements exist.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        internal static void Requirements(string[] commandLineArguments)
        {
            /* MAWSC requires valid JSON-formatted configuration file named:
             * 
             *  ./AppData/Config/mawsc-config.json
             * 
             * If the configuration file doesn't exists, or isn't valid, a file with the
             * default settings will be created.
             */
            MAWSC.Configuration.Validate();

            /* Since MAWSC is a command line interface, it requires at least one command line
             * argument to do anything. At this point we are just verifying that an argument
             * has been passed, validation will occur as needed.
             */
            MAWSC.CommandLine.VerifyArgumentsPassed(commandLineArguments);

            /* There are a number of directories that MAWSC needs, so if they don't already
             * exist, they will be created.
             */
            MAWSC.Verify.RequiredDirectories();
        }

        /// <summary>
        /// Verify that required directories exist, and create them if they don't.
        /// </summary>
        /// <param name="mawscConfiguration">MAWSC configuration settings.</param>
        /// <returns>A log message.</returns>
        private static string RequiredDirectories()
        {
            /* Load the configuration file, which contains the list of required directories.
             * This probably isn't the most efficient way to do this, but it's easy and keep
             * things compartmentalized.
             */
            var mawscConfiguration = MAWSC.Configuration.Load();

            /* By default, these directories are always going to be in ./AppData/*. If you have
             * modified these values in the mawsc-config.json file, they should still work, but
             * that hasn't been tested.
             */
            var requiredDirectories = new List<string>
            {
                mawscConfiguration.ConfigurationDirectory,
                mawscConfiguration.LogDirectory,
                mawscConfiguration.BackupDirectory,
                mawscConfiguration.TemporaryDirectory
            };

            var logSubHeader = MAWSC.Log.Component.SubHeader("Verifying required directories");
            var logContent   = "";

            /* The majority of MAWSC logging is taken care of by MAWS.Log.Components.cs, but
             * since this update is just via the console, we'll take care of logging directly.
             */
            foreach(var requiredDirectory in requiredDirectories)
            {
                if(!Directory.Exists(requiredDirectory))
                {
                    logContent += $"{requiredDirectory} does not exist.{Environment.NewLine}";
                    _=Directory.CreateDirectory(requiredDirectory);
                    logContent += $"{requiredDirectory} created.{Environment.NewLine}";
                }
                else
                {
                    logContent += $"{requiredDirectory} exists.{Environment.NewLine}";
                }
            }

            return $"{logSubHeader}" +
                   $"{logContent}";
        }
    }
}