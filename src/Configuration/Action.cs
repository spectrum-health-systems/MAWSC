// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.cs
// Partial class that contains action logic for MAWSC.Configuration.cs.
// b220518.115916

namespace MAWSC.Configuration
{
    internal class Action
    {
        /// <summary>Recreate the configuration file with default values.</summary>
        internal static void Reset()
        {
            var configurationFilePath = MAWSC.Configuration.Common.GetDefaultFilePath();

            if(File.Exists($@"{configurationFilePath}"))
            {
                File.Delete(configurationFilePath);
            }

            /* It's recommended that you leave these values as they are, and make any
             * modifications to the configuration file itself.
             */
            var defaultSettings = new Settings()
            {
                ConfigurationDirectory = $@"./AppData/Config/",
                LogDirectory           = $@"./AppData/Log/",
                BackupDirectory        = $@"./AppData/Backup/",
                TemporaryDirectory     = $@"./AppData/Temp/",
                StagingDirectory       = $@"./AppData/Staging-source/",
                ProductionDirectory    = "path/to/your/web/service/",
                ValidCommands = new List<string>
                    {
                        "h",
                        "help",
                        "s",
                        "stage",
                        "staging",
                        "p",
                        "prod",
                        "production",
                        "c",
                        "config",
                        "configuration"
                    },
                ValidActions = new List<string>
                    {
                        "d",
                        "deploy",
                        "r",
                        "reset"
                    },
                ValidOptions = new List<string>
                    {
                        "t",
                        "tbd",
                    },
                ApplicationVersion = "set-at-runtime",
                SessionTimestamp   = "set-at-runtime",
                LogfilePath        = "set-at-runtime",
                MawscCommand       = "set-at-runtime",
                MawscAction      = "set-at-runtime",
                MawscOption      = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<Settings>(defaultSettings, $@"{configurationFilePath}");

            /* Logging variables are setup a little differently here.
             */
            var sessionTimestamp             = DateTime.Now.ToString("MMddyy-HHmmss");
            var logfilePath                  = $"{defaultSettings.LogDirectory}mawsc-{sessionTimestamp}.log";
            var logConfigurationResetMessage = MAWSC.Log.Component.ConfigurationReset();
            MAWSC.Log.Export.ToEverywhere(logConfigurationResetMessage, logfilePath);
        }
    }

}