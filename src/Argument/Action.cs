// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Argument.Action.cs
// Logic for MAWSC Actions.
// b220524.080525

namespace MAWSC.Argument
{
    internal class Action
    {
        /// <summary>
        /// Get the MAWSC action from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC action.</returns>
        internal static string GetValue(string[] commandLineArguments)
        {
            return commandLineArguments.Length == 2
                ? commandLineArguments[1].Trim().ToLower().Replace("-", "")
                : "not-passed";
        }

        internal static void Validate()
        {
            // TODO
        }

    }
}