// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.CleanStaging.cs
// Refresh
// b220608.151504

using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class CleanStaging
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <param name="mawsc"></param>
        internal static void FetchLocation(ConfigurationSettings mawsc)
        {
            Du.WithDirectory.RefreshRecursively(mawsc.StagingFetchDirectory);
        }
    }
}
