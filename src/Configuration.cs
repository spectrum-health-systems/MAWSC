// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Configuration.cs
// UPDATED: 220511.113459
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Does stuff with configuration settings.
 */

using System.Reflection;

namespace MAWSC
{
    internal class Configuration
    {
        /* These directories *should not* be modified, as they contain data that MAWSC requires
         * to function, and shouldn't be changed unless you really, really have a reason to
         * change them. It's recommended that you leave these alone.
         */
        public string ConfigDirectory { get; set; }
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
        /// Loads configuration settings from a file.
        /// </summary>
        /// <returns></returns>
        internal static Configuration Load()
        {
            /* The configuration file path is the only hard-coded component of MAWSC. This
             * should not be modified.
             */
            var configurationFileName = $@"./AppData/Config/mawsc-config.json";

            /* The configuration file is required for MAWSC to function, so if it doesn't exist
             * we will create a new file with default values.
             */
            if(!File.Exists($@"{configurationFileName}"))
            {
                ResetToDefault();
            }

            /* Get the configuration settings from the configuration file.
             */
            Configuration mawscConfiguration = Du.WithJson.DeserializeFromFile<Configuration>($@"./AppData/Config/mawsc-config.json");

            /* There are a few configuration settings we need to set that are specific to this session.
             */
            mawscConfiguration.SessionTimestamp   = DateTime.Now.ToString("MMddyy-HHmmss");
            mawscConfiguration.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawscConfiguration.LogfilePath        = $"{mawscConfiguration.LogDirectory}mawsc-{mawscConfiguration.SessionTimestamp}.log";

            return mawscConfiguration;
        }

        /// <summary>
        /// Reset the configuration file to default settings.
        /// </summary>
        internal static void ResetToDefault()
        {
            var configurationFileName = $@"./AppData/Config/mawsc-config.json";

            if(File.Exists($@"{configurationFileName}"))
            {
                File.Delete(configurationFileName);
                File.Create(configurationFileName);
            }

            var defaultSettings = new Configuration()
            {
                ConfigDirectory                = $@"./AppData/Config/",
                LogDirectory                   = $@"./AppData/Log/",
                BackupDirectory                = $@"./AppData/Backup/",
                TemporaryDirectory             = $@"./AppData/Temp/",
                SourceStagingDirectory         = $@"./AppData/Staging-source/",
                DestinationStagingDirectory    = $@"./AppData/Staging-destination/",
                SourceProductionDirectory      = $@"./AppData/Production-source/",
                DestinationProductionDirectory = $@"./AppData/Production-destination/",
                ValidCommands = new List<string>
                {
                    "h", "help",
                    "s", "stage", "staging",
                    "p", "prod", "production",
                    "c", "config", "configuration"
                },
                ValidActions = new List<string>
                {
                    "d", "deploy",
                    "r", "reset"
                },
                ValidOptions = new List<string>
                {
                    "t", "tbd",
                },
                ApplicationVersion             = "set-at-runtime",
                SessionTimestamp               = "set-at-runtime",
                LogfilePath                    = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<Configuration>(defaultSettings, $@"{defaultSettings.ConfigDirectory}mawsc-config.json");
        }
    }
}