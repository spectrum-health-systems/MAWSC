// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Roundhouse.cs
// MAWSC roundhouse.
// b220526.080326

namespace MAWSC
{
    internal partial class Roundhouse
    {
        internal static void Parse(MAWSC.Configuration.Settings mawscSettings)
        {
            Roundhouse.MawscCommand.Parse(mawscSettings);
        }
    }
}
