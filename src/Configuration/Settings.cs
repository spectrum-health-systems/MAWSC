// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.Settings.cs
// Setting properties
// b220523.132053 -

namespace MAWSC.Configuration
{
    internal class Settings
    {
        public string ConfigurationDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string BackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }
        public string StagingSourceDirectory { get; set; }
        public string StagingTargetDirectory { get; set; }
        public string ProductionTargetDirectory { get; set; }
        public string ProductionSourceDirectory { get; set; }
        public List<string> ValidCommands { get; set; }
        public List<string> ValidActions { get; set; }
        public List<string> ValidOptions { get; set; }
        public string ApplicationVersion { get; set; }
        public string SessionTimestamp { get; set; }
        public string LogfilePath { get; set; }
        public string MawscCommand { get; set; }
        public string MawscAction { get; set; }
        public string MawscOption { get; set; }


        internal static Settings Initialize(string[] commandLineArguments)
        {
            Settings mawscSettings = Configuration.Load.FromFile();

            mawscSettings = Runtime.SetSetting(mawscSettings, commandLineArguments);

            return mawscSettings;
        }
    }


}