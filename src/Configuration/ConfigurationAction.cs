// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.ConfigurationAction.cs
// Logic for configuration actions
// b220617.083043
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWSC-Sourcecode.md

using MAWSC.Logging;

namespace MAWSC.Configuration
{
    internal class ConfigurationAction
    {
        /// <summary>Recreate the configuration file with default values.</summary>
        internal static void ResetFile()
        {
            var configurationFilePath = ConfigurationFile.GetDefaultFilePath();

            if (File.Exists($@"{configurationFilePath}"))
            {
                File.Delete(configurationFilePath);
            }

            var defaultSettings = new ConfigurationSettings()
            {
                SessionTimestamp        = "set-at-runtime",
                ApplicationVersion      = "set-at-runtime",
                ConfigurationDirectory  = $@"./AppData/Config/",
                LogDirectory            = $@"./AppData/Logs/",
                SessionLogfilePath      = "set-at-runtime",
                BackupDirectory         = $@"./AppData/Backup/",
                SessionBackupDirectory  = "set-at-runtime",
                TemporaryDirectory      = $@"./AppData/Temp/",
                RepositoryLocation      = "https://github.com/spectrum-health-systems/",
                RepositoryName          = "name-of-your-repository",
                RepositoryBranch        = "",
                RepositoryZipUrl        = "set-at-runtime",
                StagingFetchDirectory   = $@"./AppData/Staging-fetch/",
                StagingTestingDirectory = "/path/to/your/web/service/testing/environment/",
                ProductionDirectory     = "/path/to/your/web/service/production/environment/",
                MawscCommand            = "set-at-runtime",
                MawscAction             = "set-at-runtime",
                MawscOption             = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<ConfigurationSettings>(defaultSettings, $@"{configurationFilePath}");

            ExportLog.ToConsole(LogMessage.ConfigurationFileReset());
        }
    }
}