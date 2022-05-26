// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Validate.MawscCommand.cs
// Validate MAWSC Command data.
// b220526.080326

namespace MAWSC.Validate
{
    internal class MawscCommand
    {
        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        /// <returns></returns>
        internal static bool IsValid(MAWSC.Configuration.Settings mawscSettings)
        {
            return mawscSettings.ValidCommands.Contains(mawscSettings.MawscCommand);
        }
    }
}