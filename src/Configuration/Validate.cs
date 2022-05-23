// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.Validate.cs
// Validate configuration data.
// b220523.131302 -

namespace MAWSC.Configuration
{
    internal class Validate
    {
        /// <summary>Verify a valid configuration file exists.</summary>
        /// <remarks>
        ///     <para>
        ///         Recreate./AppData/Config/mawsc-config.json if the file:
        ///         <list type ="bullet">
        ///             <item>
        ///                 <term>Does not exist</term>
        ///                 <description>The configuration file is required.</description>
        ///             </item>
        ///             <item>
        ///                 <term>Is not enclosed properly</term>
        ///                 <description>JSON formatted files are enclosed in brackets, so if the configuration file doesn't start with a <b>{</b> and end with a <b>}</b>, it's not valid JSON data.JSON formatted files are enclosed in brackets, so if the configuration file doesn't start with a <b>{</b> and end with a <b>}</b>, it's not valid JSON data.</description>
        ///             </item>
        ///             <item>
        ///                 <term>Is too short</term>
        ///                 <description>There are at least 5 configuration settings, so if the configuration file must contain<br/> more than 5 lines.</description>
        ///             </item>
        ///         </list>    
        ///     </para>
        /// </remarks>
        internal static void Data()
        {
            var configurationFile  = MAWSC.Configuration.Common.GetDefaultFilePath();

            if(!File.Exists($@"{configurationFile}"))
            {
                Action.Reset();
            }
            else
            {
                var fileContents       = File.ReadAllLines(configurationFile);
                var fileEnclosureValid = fileContents[0] == "{" && fileContents[^1] == "}";

                if(!fileEnclosureValid || fileContents.Length < 5)
                {
                    Action.Reset();
                }
            }
        }
    }
}