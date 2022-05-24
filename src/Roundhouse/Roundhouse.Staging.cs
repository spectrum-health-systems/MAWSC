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
            internal static void ParseAction(MAWSC.Configuration.Settings mawscSettings)
            {

                switch(mawscSettings.MawscAction)
                {
                    case "b":
                    case "backup":
                        MAWSC.Staging.Backup.Source(mawscSettings);
                        MAWSC.Staging.Backup.Target(mawscSettings);
                        break;

                    case "d":
                    case "deploy":
                        MAWSC.Staging.Deploy.All(mawscSettings);
                        break;

                    case "f":
                    case "fetch":
                        MAWSC.Staging.Fetch.FromUrl(mawscSettings);
                        break;

                    case "r":
                    case "refresh":
                        MAWSC.Staging.Backup.Source(mawscSettings);
                        MAWSC.Staging.Backup.Target(mawscSettings);
                        MAWSC.Staging.Fetch.FromUrl(mawscSettings);
                        break;

                    case "i":
                    case "info":
                    case "information":
                    case "not-passed":
                    default:
                        //MAWSC.Log.Export.ToEverywhere(Log.Message.ConfigurationInformationRequest(mawscSettings), mawscSettings.LogfilePath);
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
