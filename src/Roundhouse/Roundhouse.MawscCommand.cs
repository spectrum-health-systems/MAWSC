// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.MawscCommand.cs
// MAWSC Command roundhouse.
// b220526.080326

namespace MAWSC
{
    internal partial class Roundhouse
    {
        private class MawscCommand
        {
            /// <summary>
            /// wetrw
            /// </summary>
            /// <param name="mawscCommand">tet</param>
            /// <param name="mawscSettings">tet</param>
            internal static void Parse(MAWSC.Configuration.Settings mawscSettings)
            {
                switch(mawscSettings.MawscCommand)
                {
                    case "h":
                    case "help":
                        Help.Display.Complete();
                        break;

                    case "c":
                    case "config":
                    case "configuration":
                        Roundhouse.Configuration.ParseAction(mawscSettings);
                        break;

                    case "s":
                    case "stage":
                    case "staging":
                        Roundhouse.Staging.ParseAction(mawscSettings);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
