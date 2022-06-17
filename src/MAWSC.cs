// ============================================================================ [ v1.99.00.00 ]
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ================================================================= [ 220617.091527-devbuild ]

// MAWSC.cs
// Entry point for MAWSC.
// b220617.080310
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Manual/Sourcecode/README.md

/* --------------------------------------------------------------------------------------------
 * About MAWSC
 * --------------------------------------------------------------------------------------------
 * MyAvatar Web Service Commander (MAWSC) is a command-line maintenance utility for the
 * MyAvatar Web Service (MAWS), although it can be use to help maintain any custom web service
 * for myAvatar™.
 
 * README: https://github.com/spectrum-health-systems/MAWSC#readme
 * Changelog: https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/CHANGELOG.md
 * Roadmap: https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/ROADMAP.md
 * Known issues: https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/KNOWN-ISSUES.md
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

static void MawscInitializer(string[] arguments)
{
    Console.Clear();

    var sessionTimestamp = DateTime.Now.ToString("MMddyy-HHmmss");

    VerifyRequirements.Startup(arguments, sessionTimestamp);

    ConfigurationSettings mawsc = ConfigurationSettings.Initialize(arguments, sessionTimestamp);

    VerifyFramework.Startup(mawsc);

    MawscCommandRoundhouse.ParseCommand(mawsc);
}