// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.StagingRoundhouse.cs
// Staging roundhouse.
// b220601.163655

using MAWSC.Configuration;
using MAWSC.Staging;

namespace MAWSC.Roundhouse
{
    internal class StagingRoundhouse
    {
        internal static void ParseAction(MawscSettings mawscSettings)
        {

            switch(mawscSettings.MawscAction)
            {
                case "b":
                case "backup":
                    BackupStaging.SoupToNuts(mawscSettings);
                    break;

                case "d":
                case "deploy":
                    DeployStaging.SoupToNuts(mawscSettings);
                    break;

                case "f":
                case "fetch":
                    FetchStaging.SoupToNuts(mawscSettings);
                    break;

                case "r":
                case "refresh":
                    RefreshStaging.SoupToNuts(mawscSettings);
                    break;

                case "i":
                case "info":
                case "information":
                case "not-passed":
                default:
                    StagingInformation.Display(mawscSettings);
                    break;
            }

        }
    }
}