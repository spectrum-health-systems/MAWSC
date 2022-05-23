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
