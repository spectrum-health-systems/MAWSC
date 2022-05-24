// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

namespace MAWSC.Argument
{
    internal class Option
    {
        /// <summary>
        /// Get the MAWSC option from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC option.</returns>
        internal static string GetValue(string[] commandLineArguments)
        {
            return commandLineArguments.Length == 3
                ? commandLineArguments[2].Trim().ToLower().Replace("-", "")
                : "not-passed";
        }

        internal static void Validate()
        {
            // TODO
        }
    }
}