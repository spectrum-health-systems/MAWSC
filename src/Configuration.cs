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
        /* This is the one piece of information that is hard-coded in a few places, so don't
         * modify this.
         */
        public string ConfigurationDirectory { get; set; }

        /* These directories *should not* be modified, as they contain data that MAWSC requires
         * to function, and shouldn't be changed unless you really, really have a reason to
         * change them. It's recommended that you leave these alone.
         */
        public string LogDirectory { get; set; }
        public string BackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }

        /* These directories *should* be modified for your organization, and MAWSC won't
         * function properly if you leave them at default. They need to point to your web
         * service source (e.g., a sourcecode repository) and destination (e.g., where you host
         * your web service) for the web service staging and production environments.
         */
        public string SourceStagingDirectory { get; set; }
        public string DestinationStagingDirectory { get; set; }
        public string SourceProductionDirectory { get; set; }
        public string DestinationProductionDirectory { get; set; }

        /* These values correspond to data that MAWSC uses, and should not be changed.
         */
        public List<string> ValidCommands { get; set; }
        public List<string> ValidActions { get; set; }
        public List<string> ValidOptions { get; set; }

        /* These values are set at runtime.
         */
        public string ApplicationVersion { get; set; }
        public string SessionTimestamp { get; set; }
        public string LogfilePath { get; set; }

        /// <summary>
        /// Verify a valid configuration file exists.
        /// </summary>
        internal static void Validate()
        {
            /* We will assume that the configuration file exists, and is valid, but if any of
             * the following test fail, recreate the file:
             * 
             *  1. It doesn't exist
             *  2. Since it's JSON-formatted data, it needs to startstart with "{" and end
             *     with "}"
             *  3. There are 15 configuration settings, so the file needs to be at least 15
             *     lines long
             */

            var configurationFilePath = MAWSC.Configuration.GetDefaultConfigurationFilePath();

            var validConfigurationFile = true;

            if(!File.Exists($@"{configurationFilePath}"))
            {
                validConfigurationFile = false;
            }
            else
            {
                var fileContents = File.ReadAllLines(configurationFilePath);

                if(!fileContents[0].StartsWith("{") && !fileContents[fileContents.Length].EndsWith("}"))
                {
                    validConfigurationFile = false;
                }

                if(fileContents.Length < 15)
                {
                    validConfigurationFile = false;
                }
            }

            if(!validConfigurationFile)
            {
                MAWSC.Configuration.Action.Reset();
            }
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