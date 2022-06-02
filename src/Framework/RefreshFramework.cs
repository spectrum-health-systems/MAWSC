// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Framework.RefreshFramework.cs
// Refresh framework components.
// b220531.085631 x

using MAWSC.Configuration;

namespace MAWSC.Framework
{
    internal class RefreshFramework
    { // x
        /// <summary>Refresh MAWSC framework directories.</summary>
        /// <remarks>
        ///     <para>
        ///         - Currently only the temporary directory is refreshed.
        ///     </para>
        /// </remarks>
        /// <param name="mawsc">Configuration settings.</param>
        internal static void Directories(MawscSettings mawsc)
        {
            Du.WithDirectory.RefreshRecursively(mawsc.TemporaryDirectory);
        }
    }
}