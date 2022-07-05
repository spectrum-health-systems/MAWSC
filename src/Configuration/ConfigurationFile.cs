// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Configuration.ConfigurationFile.cs
// Logic related to the configuration file.
// b220705.133118
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Logging;

namespace MAWSC.Configuration
{
    internal class ConfigurationFile
    {
        /// <summary>Get the MAWSC configuration default filepath.</summary>
        /// <returns>Default configuration file path.</returns>
        internal static string GetDefaultFilePath() => $@"./AppData/Config/mawsc-config.json";

        /// <summary>Verify the configuration file exists, and that it (probably) contains valid data.</summary>
        internal static void Verify()
        {
            var configurationFilePath = GetDefaultFilePath();

            if (!File.Exists($@"{configurationFilePath}"))
            {
                ExportLog.ToConsole(LogMessage.ConfigurationFileNotFound());
                ConfigurationAction.ResetFile();
            }
            else
            {
                var fileContents = File.ReadAllLines(configurationFilePath);
                var fileEnclosureValid = fileContents[0] == "{" && fileContents[^1] == "}";

                if (!fileEnclosureValid || fileContents.Length < 5)
                {
                    ExportLog.ToConsole(LogMessage.ConfigurationFileInvalid());
                    ConfigurationAction.ResetFile();
                }
            }
        }

        /// <summary>Load MAWSC configuration settings from the configuration file.</summary>
        /// <returns>MAWSC settings.</returns>
        internal static ConfigurationSettings Load()
        {
            var configurationFile = ConfigurationFile.GetDefaultFilePath();

            if (!File.Exists($@"{configurationFile}"))
            {
                ConfigurationAction.ResetFile();
            }

            return Du.WithJson.DeserializeFromFile<ConfigurationSettings>(configurationFile);
        }
    }
}