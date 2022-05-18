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

namespace MAWSC
{
    internal partial class Configuration
    {
        internal class Action
        {

            /// <include file='MawscDoc.xml' path='doc/configuration[@name="Action.Reset"]/*' />
            internal static void Reset()
            {
                var configurationFilePath = MAWSC.Configuration.GetDefaultFilePath();

                if(File.Exists($@"{configurationFilePath}"))
                {
                    File.Delete(configurationFilePath);
                }

                /* It's recommended that you leave these values as they are, and make any
                 * modifications to the configuration file itself.
                 */
                var defaultSettings = new Configuration()
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
                    ApplicationVersion             = "set-at-runtime",
                    SessionTimestamp               = "set-at-runtime",
                    LogfilePath                    = "set-at-runtime",
                };

                Du.WithJson.SerializeToIndentedFile<Configuration>(defaultSettings, $@"{configurationFilePath}");
            }
        }
    }
}