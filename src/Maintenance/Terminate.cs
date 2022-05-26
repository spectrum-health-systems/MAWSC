// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Maintenance.Terminate.cs
// Termination stuff
// b220526.080326

namespace MAWSC.Maintenance
{
    internal class Terminate
    {
        /// <summary>Exit MAWSC.</summary>
        /// <param name="exitCode">Exit code for troubleshooting purposes.</param>
        internal static void Gracefully(int exitCode)
        {
            if(exitCode == 0)
            {
                Console.WriteLine($"{Environment.NewLine}>>> MAWSC Exiting gracefully (Exit code {exitCode})...");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}>>> MAWSC Exiting with error (Exit code {exitCode})...");
            }

            Environment.Exit(exitCode);
        }
    }
}