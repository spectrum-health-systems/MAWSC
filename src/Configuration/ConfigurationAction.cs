// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.ConfigurationAction.cs
// Configuration actions
// b220531.094752

using MAWSC.Logging;

namespace MAWSC.Configuration
{
    internal class ConfigurationAction
    {
        /// <summary>Recreate the configuration file with default values.</summary>
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
            var defaultSettings = new MawscSettings()
            {
                ConfigurationDirectory    = $@"./AppData/Config/",
                LogDirectory              = $@"./AppData/Logs/",
                BackupDirectory           = $@"./AppData/Backup/",
                TemporaryDirectory        = $@"./AppData/Temp/",
                RepositoryName            = "name-of-your-repository",
                RepositoryUrl             = "path/to/your/web/service/repository/url",
                RepositorySrcDirectory    = "path/to/your/repository/src/",
                StagingSourceDirectory    = $@"./AppData/Staging_source/",
                StagingTargetDirectory    = "/path/to/your/staging/web/service/target/",
                ProductionSourceDirectory = "/path/to/your/production/web/service/source/",
                ProductionTargetDirectory = "/path/to/your/production/web/service/target/",
                ApplicationVersion        = "set-at-runtime",
                SessionTimestamp          = "set-at-runtime",
                LogfilePath               = "set-at-runtime",
                MawscCommand              = "set-at-runtime",
                MawscAction               = "set-at-runtime",
                MawscOption               = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<MawscSettings>(defaultSettings, $@"{configurationFilePath}");

            ExportLog.ToConsole(Logging.LogMessage.ConfigurationFileReset());
        }
    }
}