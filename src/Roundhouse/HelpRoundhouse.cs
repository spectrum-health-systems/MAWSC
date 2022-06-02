using MAWSC.Configuration;

namespace MAWSC.Roundhouse
{
    internal class HelpRoundhouse
    {
        /// <summary>
        /// wetrw
        /// </summary>
        /// <param name="mawscCommand">tet</param>
        /// <param name="mawscSettings">tet</param>
        internal static void ParseAction(MawscSettings mawscSettings)
        {

            switch(mawscSettings.MawscAction)
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

                case "not-passed":
                default:
                    MAWSC.Help.DisplayHelp.ForDefault();
                    break;
            }
        }
    }
}