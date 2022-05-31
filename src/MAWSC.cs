// =========================================================== [ v1.99.00.0-b220531+dev081040 ]
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWSC.cs
// Entry point for MAWSC.
// b220531.081047 x

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
using MAWSC.Maintenance;
using MAWSC.Roundhouse;

StartMawsc(args);

static void StartMawsc(string[] commandLineArguments)
{
    Console.Clear();

    /* We get the timestamp as soon as MAWSC starts, and use it throughout the session. That
     * way logfiles and timestamps will be consistant.
     */
    var sessionTimestamp = DateTime.Now.ToString("MMddyy-HHmmss");

    Startup.VerifyMawscRequirements(commandLineArguments, sessionTimestamp);

    MawscSettings mawscSettings = MAWSC.Configuration.MawscSettings.Initialize(commandLineArguments, sessionTimestamp);

    Startup.VerifyMawscFramework(mawscSettings);

    MawscCommandRoundhouse.ParseCommand(mawscSettings);
}