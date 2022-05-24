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
                        ParseOptionDeploy(mawscSettings);
                        break;

                    case "f":
                    case "fetch":
                        MAWSC.Staging.Backup.Source(mawscSettings);
                        MAWSC.Staging.Backup.Target(mawscSettings);
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

        internal static void ParseOptionDeploy(MAWSC.Configuration.Settings mawscSettings)
        {
            switch(mawscSettings.MawscOption)
            {
                case "a":
                case "all":
                    MAWSC.Staging.Deploy.All(mawscSettings);
                    break;

                case "m":
                case "minimal":
                    MAWSC.Staging.Deploy.Minimal(mawscSettings);
                    break;

                case "not-passed":
                default:
                    MAWSC.Staging.Deploy.Minimal(mawscSettings);
                    break;
            }
        }

    }
}
