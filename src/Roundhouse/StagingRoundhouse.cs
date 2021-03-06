// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Roundhouse.StagingRoundhouse.cs
// Staging roundhouse.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Configuration;
using MAWSC.Staging;

namespace MAWSC.Roundhouse
{
    internal class StagingRoundhouse
    {
        /// <summary></summary>
        /// <param name="mawsc"></param>
        internal static void ParseAction(ConfigurationSettings mawsc)
        {

            switch (mawsc.MawscAction)
            {
                case "b":
                case "backup":
                    BackupStaging.SoupToNuts(mawsc);
                    break;

                case "d":
                case "deploy":
                    DeployStaging.SoupToNuts(mawsc);
                    break;

                case "f":
                case "fetch":
                    FetchStaging.SoupToNuts(mawsc);
                    break;

                case "r":
                case "refresh":
                    RefreshStaging.SoupToNuts(mawsc);
                    break;

                case "i":
                case "info":
                case "information":
                case "unused":
                default:
                    StagingInformation.Display(mawsc);
                    break;
            }

        }
    }
}