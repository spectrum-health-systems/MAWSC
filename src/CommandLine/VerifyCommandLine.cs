// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.CommandLine.Verify.cs
// Verify command line data.
// b220607.090446

namespace MAWSC.CommandLine
{
    internal class VerifyCommandLine
    {
        /// <summary>Verify at least one argument was passed via the command line.</summary>
        /// <remarks>
        ///     <para>
        ///         - We aren't testing for valid arguments yet, just their existance.<br/>
        ///         - If there aren't any passed arguments, we can't do anything, so let the user know via the console (don't write a log file), and exit MAWSC.
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        internal static void ArgumentsPassed(string[] arguments)
        {
            if(arguments.Length == 0)
            {
                Logging.ExportLog.ToConsole(Logging.LogMessage.ArgumentsMissing());

                Maintenance.MawscTerminate.Gracefully(1);
            }
        }
    }
}