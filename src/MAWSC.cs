// ========================================[ PROJECT ]=========================================
// MAWSC (MyAvatar Web Service Commander)
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.cs
// Entry point for MAWSC.
// b220627.084038
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-[ ABOUT MAWSC ]-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// https://github.com/spectrum-health-systems/MAWSC
// Version1.99.0.0
// Build: 220627.085320+devbuild
//
// MyAvatar Web Service Commander (MAWSC) is a command-line maintenance utility for the
// MyAvatar Web Service (MAWS), although it can be use to help maintain any custom web service
// for myAvatar™.
//
// MANUALS
// -------
// Manual: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Manual/MAWSC-Manual.md
// Sourcode: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWSC-Sourcecode.md
//
// PROJECT DOCUMENTATION
// ---------------------
// Readme: https://github.com/spectrum-health-systems/MAWSC#readme
// Changelog: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Changelog.md
// Roadmap: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Roadmap.md
// Known issues: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Known-issues.md
//
// DEVELOPMENT
// -----------
// https://github.com/spectrum-health-systems/MAWSC/tree/development
//
// ADDITIONAL INFORMATION
// ----------------------
// For more myAvatar™ related development, please visit the myAvatar™ Development Community:
//  https://github.com/myAvatar-Development-Community
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

using MAWSC.Configuration;
using MAWSC.Framework;
using MAWSC.Requirements;
using MAWSC.Roundhouse;

MawscInitializer(args);

static void MawscInitializer(string[] arguments)
{
    Console.Clear();

    var sessionTimestamp = DateTime.Now.ToString("MMddyy-HHmmss");

    VerifyRequirements.Startup(arguments, sessionTimestamp);

    ConfigurationSettings mawsc = ConfigurationSettings.Initialize(arguments, sessionTimestamp);

    VerifyFramework.Startup(mawsc);

    MawscCommandRoundhouse.ParseCommand(mawsc);
}