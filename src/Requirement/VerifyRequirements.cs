// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Requirements.VerifyRequirements.cs
// Verify MAWSC requirements.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.CommandLine;
using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Requirements
{
    internal class VerifyRequirements
    {
        /// <summary>Verify basic MAWSC requirements.</summary>
        /// <remarks>
        ///     <para>
        ///         - These are the basic requirements that don't rely on the configuration settings, which haven't been set yet.
        ///         - Log information is only sent to the console, since we technically haven't verified the framework yet.
        ///     </para>
        /// </remarks>
        /// <param name="commandLineArguments">Arguments passed via the command line when MAWSC executes.</param>
        /// <param name="sessionTimestamp">Timestamp for the session.</param>
        internal static void Startup(string[] commandLineArguments, string sessionTimestamp)
        {
            ConfigurationFile.Verify();

            Arguments.VerifyPassed(commandLineArguments);

            ExportLog.ToConsole(LogHeader.Top(sessionTimestamp));
        }
    }
}
