// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.ConfigurationAction.cs
// Logic for configuration actions
// b220608.105921

using MAWSC.Logging;

namespace MAWSC.Configuration
{
    internal class ConfigurationAction
    {
        /// <summary>Recreate the configuration file with default values.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - If the configuration file exists, it is deleted and then recreated.<br/>
        ///         - It's recommended that you leave these values as they are, and make any modifications to the configuration file itself.<br/>
        ///         - You will need to modify the following settings for your organization:
        ///         <list type ="bullet">
        ///             <item>
        ///                 <term>RepositoryBranch</term>
        ///                 <description>Name of the repository branch (e.g., "development"). If you are using the main branch, leave this se.</description>
        ///             </item>
        ///             <item>
        ///                 <term>StagingTestingDirectory</term>
        ///                 <description>The directory that contains the web service sourcode that you test against (e.g., "C:\MyWebsites\MyWebService\Testing\".</description>
        ///             </item>
        ///             <item>
        ///                 <term>ProductionDirectory</term>
        ///                 <description>The directory that contains the web service sourcode using in production (e.g., "C:\MyWebsites\MyWebService\Production\".</description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        internal static void ResetFile()
        {
            var configurationFilePath = ConfigurationSettings.GetDefaultFilePath();

            if(File.Exists($@"{configurationFilePath}"))
            {
                File.Delete(configurationFilePath);
            }

            var defaultSettings = new ConfigurationSettings()
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
                RepositoryBranch          = "",
                RepositoryUrl             = "set-at-runtime",
                StagingFetchDirectory     = $@"./AppData/Staging_fetch/",
                StagingTestingDirectory   = "/path/to/your/web/service/testing/environment/",
                ProductionDirectory       = "/path/to/your/web/service/production/environment/",
                MawscCommand              = "set-at-runtime",
                MawscAction               = "set-at-runtime",
                MawscOption               = "set-at-runtime",
            };

            Du.WithJson.SerializeToIndentedFile<ConfigurationSettings>(defaultSettings, $@"{configurationFilePath}");

            ExportLog.ToConsole(LogMessage.ConfigurationFileReset());
        }
    }
}