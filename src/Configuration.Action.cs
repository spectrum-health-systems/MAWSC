// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Configuration.Action.cs
// UPDATED: 220518.081922
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * A partial class that contains the logic for MAWSC.Configuration.cs
 */

namespace MAWSC
{
    internal partial class Configuration
    {
        internal class Action
        {
            /// <summary>
            /// Reset the configuration file to default settings.
            /// </summary>
            internal static void Reset()
            {
                var configurationFilePath = MAWSC.Configuration.GetDefaultConfigurationFilePath();

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
                    ProductionDirectory    = "<path/to/your/web/service/>",
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