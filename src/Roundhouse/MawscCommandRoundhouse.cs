// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.MawscCommandRoundhouse.cs
// MAWSC Command roundhouse.
// b220531.093659

using MAWSC.Configuration;
using MAWSC.Logging;
using MAWSC.Maintenance;

namespace MAWSC.Roundhouse
{
    internal class MawscCommandRoundhouse
    {
        /// <summary> </summary>
        /// <param name="mawscSettings"></param>
        internal static void ParseCommand(MawscSettings mawscSettings)
        {
            switch(mawscSettings.MawscCommand)
            {
                case "h":
                case "help":
                    Help.DisplayHelp.Complete();
                    break;

                case "c":
                case "config":
                case "configuration":
                    ConfigurationRoundhouse.ParseAction(mawscSettings);
                    break;

                case "s":
                case "stage":
                case "staging":
                    StagingRoundhouse.ParseAction(mawscSettings);
                    break;

                default:
                    Console.WriteLine(LogMessage.CommandIsInvalid(mawscSettings.MawscCommand));
                    MawscTerminate.Gracefully(2);
                    break;
            }
        }
    }

}
