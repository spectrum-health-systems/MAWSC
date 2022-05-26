// =========================================================== [ v1.99.00.0-b220526+dev080326 ]
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWSC.cs
// Entry point for MAWSC.
// b220526.080326

/* --------------------------------------------------------------------------------------------
 * About MAWSC
 * --------------------------------------------------------------------------------------------
 * MyAvatar Web Service Commander (MAWSC) is a command-line maintenance utility for the
 * MyAvatar Web Service (MAWS), although it can be use to help maintain any custom web service
 * for myAvatar™.
 
 * README: https://github.com/spectrum-health-systems/MAWSC#readme
 * Changelog: https://github.com/spectrum-health-systems/MAWSC/doc/CHANGELOG.md
 * Roadmap: https://github.com/spectrum-health-systems/MAWSC/doc/ROADMAP.md
 * Known issues: https://github.com/spectrum-health-systems/MAWSC/doc/KNOWN-ISSUES.md
 * Development: https://github.com/spectrum-health-systems/MAWSC/tree/development
 *
 * For more myAvatar™ related development, please visit the myAvatar™ Development Community:
 *  https://github.com/myAvatar-Development-Community
 */

StartApp(args);

static void StartApp(string[] commandLineArguments)
{
    Console.Clear();

    var SessionTimestamp = DateTime.Now.ToString("MMddyy-HHmmss");

    MAWSC.Log.Export.ToConsole(MAWSC.Log.Header.Top(SessionTimestamp));

    MAWSC.Configuration.Validate.Data();

    MAWSC.Argument.Verify.Passed(commandLineArguments);

    MAWSC.Configuration.Settings mawscSettings = MAWSC.Configuration.Settings.Initialize(commandLineArguments, SessionTimestamp);

    MAWSC.Framework.Refresh.Directories(mawscSettings);

    MAWSC.Log.Export.ToFile(MAWSC.Log.Header.Top(SessionTimestamp), mawscSettings.LogfilePath);

    MAWSC.Log.Export.ToEverywhere(MAWSC.Log.Message.ArgumentsPassed(mawscSettings), mawscSettings.LogfilePath);

    MAWSC.Framework.Verify.Directories(mawscSettings);

    MAWSC.Backup.VerifySessionBackupDirectory(mawscSettings);

    if(MAWSC.Validate.MawscCommand.IsValid(mawscSettings))
    {
        MAWSC.Roundhouse.Parse(mawscSettings);
        MAWSC.Maintenance.Terminate.Gracefully(0);
    }
    else
    {
        Console.WriteLine(MAWSC.Log.Message.CommandIsInvalid(mawscSettings.MawscCommand));
        MAWSC.Maintenance.Terminate.Gracefully(2);
    }
}