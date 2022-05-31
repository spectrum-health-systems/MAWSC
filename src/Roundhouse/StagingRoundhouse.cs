// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.Staging.cs
// Staging roundhouse.
// b220526.080326

using MAWSC.Configuration;
using MAWSC.Staging;

namespace MAWSC.Roundhouse
{

    internal class StagingRoundhouse
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
                case "b":
                case "backup":
                    BackupStaging.Source(mawscSettings);
                    BackupStaging.Target(mawscSettings);
                    break;

                case "d":
                case "deploy":
                    ParseOptionDeploy(mawscSettings);
                    break;

                case "f":
                case "fetch":
                    BackupStaging.Source(mawscSettings);
                    BackupStaging.Target(mawscSettings);
                    FetchStaging.FromUrl(mawscSettings);
                    break;

                case "r":
                case "refresh":
                    BackupStaging.Source(mawscSettings);
                    BackupStaging.Target(mawscSettings);
                    FetchStaging.FromUrl(mawscSettings);
                    break;

                case "i":
                case "info":
                case "information":
                case "not-passed":
                default:
                    //MAWSC.Logging.Export.ToEverywhere(Logging.Message.ConfigurationInformationRequest(mawscSettings), mawscSettings.LogfilePath);
                    break;
            }

        }


        internal static void ParseOptionDeploy(MawscSettings mawscSettings)
        {
            switch(mawscSettings.MawscOption)
            {
                case "a":
                case "all":
                    DeployStaging.All(mawscSettings);
                    break;

                case "m":
                case "minimal":
                    DeployStaging.Minimal(mawscSettings);
                    break;

                case "not-passed":
                default:
                    DeployStaging.Minimal(mawscSettings);
                    break;
            }
        }
    }
}
