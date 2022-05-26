// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Framework.Refresh.cs
// Refresh framework components.
// b220526.080326

namespace MAWSC.Framework
{
    internal class Refresh
    {
        internal static void Directories(MAWSC.Configuration.Settings mawscSettings)
        {
            Du.WithDirectory.RefreshRecursively(mawscSettings.TemporaryDirectory);
        }
    }
}
