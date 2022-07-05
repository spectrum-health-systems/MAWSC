// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Staging.CleanStaging.cs
// Refresh
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Configuration;

namespace MAWSC.Staging
{

    /// <summary>
    ///   <br />
    /// </summary>
    internal class CleanStaging
    {
        /// <summary></summary>
        /// <param name="mawsc"></param>
        internal static void FetchLocation(ConfigurationSettings mawsc)
        {
            Du.WithDirectory.RefreshRecursively(mawsc.StagingFetchDirectory);
        }
    }
}
