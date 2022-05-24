// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

using System.Reflection;

namespace MAWSC.Configuration
{
    internal class Runtime
    {
        internal static void SetSetting(MAWSC.Configuration.Settings mawscSettings, string[] commandLineArguments)
        {

            /* Some of the configuration settings are set at runtime.
             */
            mawscSettings.SessionTimestamp   = DateTime.Now.ToString("MMddyy-HHmmss");
            mawscSettings.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawscSettings.LogfilePath        = $"{mawscSettings.LogDirectory}mawsc-{mawscSettings.SessionTimestamp}.log";

            mawscSettings.MawscCommand = MawscCommand.Transform(commandLineArguments);
            ////mawscSettings.MawscAction = mawscArguments["mawscAction"];
            ////mawscSettings.MawscOption = mawscArguments["mawscOption"];

        }
    }
}
