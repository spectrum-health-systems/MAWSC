// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Argument.Action.cs
// UPDATED: 220513.105244
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Logic for MAWSC actions.
 */

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
                : "none";
        }

        internal static void Validate()
        {
            // TODO
        }

    }
}