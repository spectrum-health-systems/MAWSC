// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Settings.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220509.112805 

/* =============================================================================
 * About this class
 * =============================================================================
 * Does stuff with settings.
 */

using System.Reflection;

namespace MAWSC
{
    internal class Configuration
    {
        /* These directories should not be modified!
         */
        public string ConfigDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string BackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }

        /* These directories should be modified for your organization.
         */
        public string SourceStagingDirectory { get; set; }
        public string DestinationStagingDirectory { get; set; }
        public string SourceProductionDirectory { get; set; }
        public string DestinationProductionDirectory { get; set; }

        /* These are set at runtime.
         */
        public string ApplicationVersion { get; set; }
        public string SessionTimestamp { get; set; }
        public string LogfilePath { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static Configuration Load()
        {
            /* This is the one place where something needs to be hard-coded.
             */
            var configurationFileName = $@"./AppData/Config/mawsc-config.json";

            if(!File.Exists($@"{configurationFileName}"))
            {
                ResetToDefault();
            }

            Configuration mawscConfiguration = Du.WithJson.DeserializeFromFile<Configuration>($@"./AppData/Config/mawsc-config.json");

            mawscConfiguration.SessionTimestamp   = DateTime.Now.ToString("MMddyy-HHmmss");
            mawscConfiguration.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawscConfiguration.LogfilePath        = $"{mawscConfiguration.LogDirectory}mawsc-{mawscConfiguration.SessionTimestamp}.log";

            return mawscConfiguration;
        }

        /// <summary>
        /// 
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
                SessionTimestamp               = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<Configuration>(defaultSettings, $@"{defaultSettings.ConfigDirectory}mawsc-config.json");
        }
    }
}