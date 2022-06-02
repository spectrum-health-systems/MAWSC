// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.ConfigurationRoundhouse.cs
// Configuration roundhouse.
// b220526.080326

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Roundhouse
{
    internal class ConfigurationRoundhouse
    {
        /// <summary></summary>
        /// <param name="mawsc">tet</param>
        internal static void ParseAction(MawscSettings mawsc)
        {
            switch(mawsc.MawscAction)
            {
                case "r":
                case "reset":
                    ExportLog.ToEverywhere(LogMessage.RequestConfigurationFileReset(), mawsc.LogfilePath);

                    ConfigurationAction.ResetConfigurationFile();

                    ExportLog.ToEverywhere(LogMessage.ConfigurationInformation(mawsc), mawsc.LogfilePath);

                    break;

                case "i":
                case "info":
                case "information":
                case "not-passed":
                default:
                    ExportLog.ToEverywhere(LogMessage.RequestConfigurationInformation(), mawsc.LogfilePath);

                    break;
            }
        }
    }
}