// =========================================================== [ v1.99.00.0-b220607+dev122905 ]
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWSC.cs
// Entry point for MAWSC.
// b220607.090226

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

using MAWSC.Configuration;
using MAWSC.Framework;
using MAWSC.Requirements;
using MAWSC.Roundhouse;

MawscInitializer(args);

static void MawscInitializer(string[] commandLineArguments)
{
    Console.Clear();

    var sessionTimestamp = DateTime.Now.ToString("MMddyy-HHmmss");

    VerifyRequirements.Startup(commandLineArguments, sessionTimestamp);

    MawscSettings mawsc = MawscSettings.Initialize(commandLineArguments, sessionTimestamp);

    VerifyFramework.Startup(mawsc);

    MawscCommandRoundhouse.ParseCommand(mawsc);
}