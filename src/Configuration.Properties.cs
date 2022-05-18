// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.Properties.cs
// Partial class that contains class properties for MAWSC.Configuration.cs.
// b220518.115916

namespace MAWSC
{
    internal partial class Configuration
    {
        public string ConfigurationDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string BackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }
        public string StagingDirectory { get; set; }
        public string ProductionDirectory { get; set; }
        public List<string> ValidCommands { get; set; }
        public List<string> ValidActions { get; set; }
        public List<string> ValidOptions { get; set; }
        public string ApplicationVersion { get; set; }
        public string SessionTimestamp { get; set; }
        public string LogfilePath { get; set; }
    }
}