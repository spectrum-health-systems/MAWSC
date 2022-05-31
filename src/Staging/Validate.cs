// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.Validate.cs
// Validate staging information.
// b220526.080326

namespace MAWSC.Staging
{
    internal class Validate
    {
        internal static bool IsValid(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return mawscSettings.ValidActions.Contains(mawscSettings.MawscAction);
        }
    }
}
