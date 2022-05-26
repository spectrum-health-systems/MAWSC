// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.Configuration.cs
// Configuration roundhouse.
// b220526.080326

namespace MAWSC
{
    internal partial class Roundhouse
    {
        internal class Configuration
        {
            /// <summary>
            /// wetrw
            /// </summary>
            /// <param name="mawscCommand">tet</param>
            /// <param name="mawscSettings">tet</param>
            internal static void ParseAction(MAWSC.Configuration.Settings mawscSettings)
            {
                switch(mawscSettings.MawscAction)
                {
                    case "r":
                    case "reset":
                        Log.Export.ToEverywhere(Log.Message.ConfigurationFileResetRequest(), mawscSettings.LogfilePath);

                        MAWSC.Configuration.Action.Reset();

                        Log.Export.ToEverywhere(Log.Message.ConfigurationInformation(mawscSettings), mawscSettings.LogfilePath);
                        break;

                    case "i":
                    case "info":
                    case "information":
                    case "not-passed":
                    default:
                        MAWSC.Log.Export.ToEverywhere(Log.Message.ConfigurationInformationRequest(mawscSettings), mawscSettings.LogfilePath);
                        break;
                }
            }
        }
    }
}
