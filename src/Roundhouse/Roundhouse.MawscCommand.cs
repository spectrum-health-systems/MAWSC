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
