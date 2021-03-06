// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Roundhouse.MawscCommandRoundhouse.cs
// MAWSC Command roundhouse.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Configuration;
using MAWSC.Logging;
using MAWSC.Maintenance;

namespace MAWSC.Roundhouse
{
    internal class MawscCommandRoundhouse
    {
        /// <summary> </summary>
        /// <param name="mawsc"></param>
        internal static void ParseCommand(ConfigurationSettings mawsc)
        {
            switch (mawsc.MawscCommand)
            {
                case "h":
                case "help":
                    HelpRoundhouse.ParseAction(mawsc);
                    //Help.DisplayHelp.Complete();
                    break;

                case "c":
                case "config":
                case "configuration":
                    ConfigurationRoundhouse.ParseAction(mawsc);
                    break;

                case "s":
                case "stage":
                case "staging":
                    StagingRoundhouse.ParseAction(mawsc);
                    break;

                default:
                    Console.WriteLine(LogMessage.CommandIsInvalid(mawsc.MawscCommand));
                    MawscTerminate.Gracefully(2);
                    break;
            }
        }
    }
}
