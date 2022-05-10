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

namespace MAWSC
{
    internal class Settings
    {
        public string ConfigDirectory { get; set; }
        public string BackupDirectoryRoot { get; set; }
        public string TemporaryDirectory { get; set; }
        public string SourceStagingDirectory { get; set; }
        public string DestinationStagingDirectory { get; set; }
        public string SourceProductionDirectory { get; set; }
        public string DestinationProductionDirectory { get; set; }

        //internal static Settings Load()
        //{



        //}

        internal static void ResetToDefault()
        {
            var defaultSettings = new Settings()
            {
                ConfigDirectory                = $@"./AppData/Config/",
                BackupDirectoryRoot            = $@"./AppData/Backup/",
                TemporaryDirectory             = $@"./AppData/Temp/",
                SourceStagingDirectory         = $@"./AppData/Staging-source/",
                DestinationStagingDirectory    = $@"./AppData/Staging-destination",
                SourceProductionDirectory      = $@"./AppData/Production-source/",
                DestinationProductionDirectory = $@"./AppData/Production-destination/",
            };

            Du.WithJson.SerializeToIndentedFile<Settings>(defaultSettings, $@"{defaultSettings.ConfigDirectory}config.json");
        }
    }
}