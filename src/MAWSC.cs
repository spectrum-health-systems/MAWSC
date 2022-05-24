// ============================================================================================
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================
//
// v1.2.0.0-b220524+dev142834
//
// --------------------------------------------------------------------------------------------
// About MAWSC
// --------------------------------------------------------------------------------------------
// MyAvatool Web Service Commander (MAWSC) is a command-line maintenance utility for the
// MyAvatool Web Service (MAWS), although it can be use to help maintain any custom web service
// for myAvatar™.
// 
// Please see the README:
//
//  https://github.com/spectrum-health-systems/MAWSC#readme
//
// For more myAvatar™ related development, please visit the myAvatar™ Development Community:
//
//  https://github.com/myAvatar-Development-Community
//
// ---------------------------------------------------------
// About this sourcecode
// ---------------------------------------------------------
// Attempts have been made to make this sourcecode as human-readable as possible, but since
// other organizations may use MAWSC, it is heavily comment everything as well - sometimes
// even in places where it is very clear as to what the code does.
// 
// You will find three types of comments in this sourcecode:
// 
//  /// XML comments used by Visual Studio
//  // Additional information
//  /* Narrative
//   * comments
//   * / 
// 
// Please do not remove any of the sourcecode comments!

// MAWSC.cs
// Entry point for MAWSC
// b220524.090813

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

/*

ERROR CODES

0: No error
1: Arguments missing
2: Invalid command was passed.
3: Invalid action was passed
4: Invalid option was passed.

 */