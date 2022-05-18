// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Maintenance.cs
// Maintenance utilities.
// b220518.115916

namespace MAWSC
{
    internal class Maintenance
    {
        /// <include file='MawscDoc.xml' path='doc/maintenance[@name="Finalize"]/*' />
        internal static void Finalize(int exitCode)
        {
            if(exitCode == 0)
            {
                Console.WriteLine($">>> MAWSC Exiting gracefully (Exit code {exitCode})...");
            }
            else
            {
                Console.WriteLine($">>> MAWSC Exiting with error (Exit code {exitCode})...");
            }

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Environment.Exit(exitCode);
        }
    }
}
