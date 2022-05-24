namespace MAWSC
{
    internal partial class Roundhouse
    {
        internal class Staging
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

                    case "s":
                    case "stage":
                    case "staging":
                        Roundhouse.Staging.Parse(mawscSettings);
                        break;


                    case "none":
                    default:
                        MAWSC.Staging.Information.Display(mawscSettings);
                        break;
                }

            }
        }




        //    /* If the "help" argument was passed, show the help screen and exit.
        //     */
        //    if(mawscSettings.MawscCommand == "h" || mawscSettings.MawscCommand == "help")
        //    {
        //        Help.Display.Complete();

        //        MAWSC.Maintenance.Terminate.Gracefully(0);
        //    }
        //    else
        //    {
        //        switch(mawscSettings.MawscCommand)
        //        {
        //            case "s":
        //            case "stage":
        //            case "staging":
        //                Staging.Roundhouse.Parse(mawscSettings);
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
