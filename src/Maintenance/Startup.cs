// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Help.Display.cs
// Display help information on the console.
// b220526.080326

namespace MAWSC.Maintenance
{
    internal class Startup
    {
        internal static void CheckRequirements
            (string[] commandLineArguments, string sessionTimestamp)
        {
            Log.Export.ToConsole(Log.Header.Top(sessionTimestamp));

            Configuration.Validate.Data();

            Argument.Verify.Passed(commandLineArguments);
        }

        internal static void CheckFramework(Configuration.Settings mawscSettings)
        {
            Framework.Refresh.Directories(mawscSettings);

            Log.Export.ToFile(Log.Header.Top(mawscSettings.SessionTimestamp), mawscSettings.LogfilePath);

            Log.Export.ToEverywhere(Log.Message.ArgumentsPassed(mawscSettings), mawscSettings.LogfilePath);

            Framework.Verify.Directories(mawscSettings);

            Backup.VerifySessionBackupDirectory(mawscSettings);
        }
    }
}