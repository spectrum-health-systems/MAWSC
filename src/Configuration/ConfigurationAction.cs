// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.ConfigurationAction.cs
// Configuration action logic
// -b220607+dev090457

using MAWSC.Logging;

namespace MAWSC.Configuration
{
    internal class ConfigurationAction
    {
        /// <summary>
        /// Recreate the configuration file with default values.
        /// </summary>
        internal static void ResetConfigurationFile()
        {
            var configurationFilePath = ConfigurationInformation.GetDefaultFilePath();

            if(File.Exists($@"{configurationFilePath}"))
            {
                File.Delete(configurationFilePath);
            }

            /* It's recommended that you leave these values as they are, and make any
             * modifications to the configuration file itself.
             */

            /* RepositoryName   = "MAWS"
             * RepositoryBranch = "development"
             * 
             */
            var defaultSettings = new MawscSettings()
            {
                SessionTimestamp          = "set-at-runtime",
                ApplicationVersion        = "set-at-runtime",
                ConfigurationDirectory    = $@"./AppData/Config/",
                LogDirectory              = $@"./AppData/Logs/",
                LogfilePath               = "set-at-runtime",
                BackupDirectory           = $@"./AppData/Backup/",
                SessionBackupDirectory    = "set-at-runtime",
                TemporaryDirectory        = $@"./AppData/Temp/",
                RepositoryName            = "name-of-your-repository",
                RepositoryBranch          = "name-of-your-repository-branch",
                RepositoryUrl             = "set-at-runtime",
                StagingFetchDirectory     = $@"./AppData/Staging_fetch/",
                StagingTestingDirectory   = "/path/to/your/web/service/testing/environment/",
                ProductionDirectory       = "/path/to/your/web/service/production/environment/",
                MawscCommand              = "set-at-runtime",
                MawscAction               = "set-at-runtime",
                MawscOption               = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<MawscSettings>(defaultSettings, $@"{configurationFilePath}");

            ExportLog.ToConsole(Logging.LogMessage.ConfigurationFileReset());
        }
    }
}