// ============================================================================================
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================
//
// v1.2.0.0-b220524+dev080506
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
// b220524.080511

StartApp(args);

static void StartApp(string[] commandLineArguments)
{
    Console.Clear();

    MAWSC.Configuration.Validate.Data();

    MAWSC.Argument.Verify.Passed(commandLineArguments);

    MAWSC.Configuration.Settings mawscSettings = MAWSC.Configuration.Settings.Initialize(commandLineArguments);

    MAWSC.Framework.Verify.Directories(mawscSettings);

    var logMasterHeader = MAWSC.Log.Component.MasterHeader();
    MAWSC.Log.Export.ToEverywhere(logMasterHeader, mawscSettings.LogfilePath);

    if(MAWSC.MawscCommand.Validate.IsValid(mawscSettings))
    {
        MAWSC.MawscCommand.Roundhouse.ProcessCommand(mawscSettings);
        MAWSC.Terminate.Gracefully(1);
    }
    else
    {
        // TODO: Re-enable this.

        //////var logInvalidCommandPassed = MAWSC.Log.Component.InvalidCommandPassed(mawscArguments["mawscCommand"]);
        //////Console.WriteLine(logInvalidCommandPassed);
        //////MAWSC.Maintenance.Finalize(2);
    }
}