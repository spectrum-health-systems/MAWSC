// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.ConfigurationRoundhouse.cs
// Configuration roundhouse.
// b220617.080310
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Manual/Sourcecode/README.md

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Roundhouse
{
    internal class ConfigurationRoundhouse
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <param name="mawsc">tet</param>
        internal static void ParseAction(ConfigurationSettings mawsc)
        {
            switch (mawsc.MawscAction)
            {
                case "r":
                case "reset":
                    ExportLog.ToEverywhere(LogMessage.RequestConfigurationFileReset(), mawsc.SessionLogfilePath);

                    ConfigurationAction.ResetFile();

                    ExportLog.ToEverywhere(LogMessage.ConfigurationInformation(mawsc), mawsc.SessionLogfilePath);

                    break;

                case "i":
                case "info":
                case "information":
                case "unused":
                default:
                    ExportLog.ToEverywhere(LogMessage.RequestConfigurationInformation(), mawsc.SessionLogfilePath);
                    ExportLog.ToEverywhere(LogMessage.ConfigurationInformation(mawsc), mawsc.SessionLogfilePath);
                    break;
            }
        }
    }
}