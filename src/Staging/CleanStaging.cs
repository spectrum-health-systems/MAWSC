// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.CleanStaging.cs
// Refresh
// b220603.190907

using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class CleanStaging
    {
        /// <summary></summary>
        /// <param name="mawsc"></param>
        internal static void FetchLocation(MawscSettings mawsc)
        {
            Du.WithDirectory.RefreshRecursively(mawsc.StagingFetchDirectory);
        }
    }
}
