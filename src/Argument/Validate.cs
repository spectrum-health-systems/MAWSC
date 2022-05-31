﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================


// MAWSC.Argument.Validate.cs
// Validate argument data.
// b220526.080326

namespace MAWSC.Argument
{
    internal class Validate
    {
        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        /// <returns></returns>
        internal static bool AreValid(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return mawscSettings.ValidCommands.Contains(mawscSettings.MawscCommand)
                && mawscSettings.ValidActions.Contains(mawscSettings.MawscAction)
                && mawscSettings.ValidOptions.Contains(mawscSettings.MawscOption);
        }
    }
}
