// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.FileInformation.cs
// Information about the configuration file.
// b220531.083832 x

namespace MAWSC.Configuration
{
    internal class ConfigurationInformation
    {
        /// <summary>Get the MAWSC configuration default filepath.</summary>
        /// <remarks>
        ///     <para>
        ///         - The default filepath is <i>./AppData/Config/mawsc-config.json</i>.
        ///     </para>
        /// </remarks>
        /// <returns>Default configuration file path.</returns>
        internal static string GetDefaultFilePath()
        {
            return $@"./AppData/Config/mawsc-config.json";
        }
    }
}
