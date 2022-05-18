// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Configuration.cs
// UPDATED: 220513.093416
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this (partial) class
 * =============================================================================
 * Does stuff with configuration settings.
 */

using System.Reflection;

namespace MAWSC
{
    internal partial class Configuration
    {
        /// <summary>
        /// Verify a valid configuration file exists.
        /// </summary>
        internal static void Validate()
        {
            /* If any of the following conditions are true, recreate the configuration file:
             * 
             *  1. mawsc-config.json doesn't exist
             *  2. mawsc-config.json starts with "{" and ends with "}"
             *  3. mawsc-config.json starts with is a minimum of 5 lines long
             */

            var configurationFilePath  = MAWSC.Configuration.GetDefaultConfigurationFilePath();
            var validConfigurationFile = true;

            if(!File.Exists($@"{configurationFilePath}"))
            {
                //validConfigurationFile = false;
                MAWSC.Configuration.Action.Reset();
            }
            else
            {
                var fileContents = File.ReadAllLines(configurationFilePath);

                var fileEnclosureValid = fileContents[0].StartsWith("{")
                                      && fileContents[fileContents.Length].EndsWith("}");

                if(!fileEnclosureValid || fileContents.Length < 5)
                {
                    //validConfigurationFile = false;
                    MAWSC.Configuration.Action.Reset();
                }
            }

            //if(!validConfigurationFile)
            //{
            //    MAWSC.Configuration.Action.Reset();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static string GetDefaultConfigurationFilePath()
        {
            /* The configuration file path is the only hard-coded component of MAWSC. This
             * should not be modified.
             */
            return $@"./AppData/Config/mawsc-config.json";
        }

        /// <summary>
        /// Loads configuration settings from a file.
        /// </summary>
        /// <returns></returns>
        internal static Configuration Load()
        {
            var configurationFileName = GetDefaultConfigurationFilePath();

            /* The configuration file is required for MAWSC to function, so if it doesn't exist
             * we will create a new file with default values.
             */
            if(!File.Exists($@"{configurationFileName}"))
            {
                MAWSC.Configuration.Action.Reset();
            }

            /* Get the configuration settings from the configuration file.
             */
            Configuration mawscConfiguration = Du.WithJson.DeserializeFromFile<Configuration>(configurationFileName);

            /* There are a few configuration settings we need to set that are specific to this session.
             */
            mawscConfiguration.SessionTimestamp   = DateTime.Now.ToString("MMddyy-HHmmss");
            mawscConfiguration.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawscConfiguration.LogfilePath        = $"{mawscConfiguration.LogDirectory}mawsc-{mawscConfiguration.SessionTimestamp}.log";

            return mawscConfiguration;
        }

        internal static void ProcessAction(string mawscAction, string mawscOption, Configuration mawscConfiguration)
        {
            if(mawscConfiguration.ValidActions.Contains(mawscAction))
            {
                switch(mawscAction)
                {
                    case "r":
                    case "reset":
                        Configuration.Action.Reset();
                        MAWSC.Maintenance.Finalize(0);
                        break;

                    default:
                        // Catch here.
                        break;
                }


            }
        }
    }
}