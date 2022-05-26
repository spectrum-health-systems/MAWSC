// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.Load.cs
// Load configuration settings.
// b220526.080326

namespace MAWSC.Configuration
{
    internal class Load
    {
        /// <summary>Load MAWSC settings from the configuration file.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - If the configuration file does not exist, a new configuration file will be created.<br/>
        ///         - The following configuration settings are created at runtime:     
        ///         <list type ="bullet">
        ///             <item>
        ///                 <description>SessionTimestamp</description>
        ///             </item>
        ///             <item>
        ///                 <description>ApplicationVersion</description>
        ///             </item>
        ///             <item>
        ///                 <description>LogfilePath</description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        /// <returns>Configuration settings.</returns>
        internal static Settings FromFile()
        {
            var configurationFile = MAWSC.Configuration.Common.GetDefaultFilePath();

            if(!File.Exists($@"{configurationFile}"))
            {
                Action.Reset();
            }

            Settings mawscSettings = Du.WithJson.DeserializeFromFile<Settings>(configurationFile);


            return mawscSettings;
        }


    }
}