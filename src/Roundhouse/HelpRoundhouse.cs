// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.HelpRoundhouse.cs
// Help roundhouse.
// b220617.080310
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Manual/Sourcecode/README.md

using MAWSC.Configuration;

namespace MAWSC.Roundhouse
{
    internal class HelpRoundhouse
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="mawscCommand">tet</param>
        /// <param name="mawsc">tet</param>
        internal static void ParseAction(ConfigurationSettings mawsc)
        {

            switch (mawsc.MawscAction)
            {
                case "c":
                case "config":
                case "configuration":
                    MAWSC.Help.DisplayHelp.ForConfiguration();
                    break;

                case "p":
                case "prod":
                case "production":
                    break;

                case "s":
                case "stage":
                case "staging":
                    MAWSC.Help.DisplayHelp.ForStaging();
                    break;

                case "r":
                case "refresh":
                    break;

                case "unused":
                default:
                    MAWSC.Help.DisplayHelp.ForDefault();
                    break;
            }
        }
    }
}