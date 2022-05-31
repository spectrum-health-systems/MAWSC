// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Maintenance.Startup.cs
// Starup logic for MAWSC.
// b220531.081353 x

using MAWSC.CommandLine;
using MAWSC.Configuration;
using MAWSC.Framework;
using MAWSC.Logging;

namespace MAWSC.Maintenance
{
    internal class MawscStartup
    {
        /// <summary>Verify basic MAWSC requirements.</summary>
        /// <remarks>
        ///     <para>
        ///         - These are the basic requirements that don't rely on the configuration settings, which haven't been set yet.
        ///     </para>
        /// </remarks>
        /// <param name="commandLineArguments">Arguments passed via the command line when MAWSC executes.</param>
        /// <param name="sessionTimestamp">Timestamp for the session.</param>
        internal static void VerifyMawscRequirements(string[] commandLineArguments, string sessionTimestamp)
        { //x
            ValidateConfiguration.FileData();

            CommandLineVerify.ArgumentsPassed(commandLineArguments);

            ExportLog.ToConsole(LogHeader.Top(sessionTimestamp));
        }

        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        internal static void VerifyMawscFramework(MawscSettings mawscSettings)
        { //x
            RefreshFramework.Directories(mawscSettings);

            ExportLog.ToFile(LogHeader.Top(mawscSettings.SessionTimestamp), mawscSettings.LogfilePath);

            ExportLog.ToEverywhere(LogMessage.ArgumentsPassed(mawscSettings), mawscSettings.LogfilePath);

            VerifyFramework.RequiredDirectories(mawscSettings);
        }
    }
}