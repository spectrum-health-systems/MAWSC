// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.CommandLine.Arguments.cs
// Processes the command line arguments that are passed to MAWSC at execution.
// b220606.132211

namespace MAWSC.CommandLine
{
    internal class Arguments
    {
        /// <summary>
        /// Get individual MAWSC session command, action, and option.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - Gets the raw MAWSC session command/action/option from the command line. These components may contain dashes, and any combination of casing.<br/>
        ///     - There must be a MAWSC session command value, which will have been verified at this point.<br/>
        ///     - The MAWSC session action/option are optional, and are set to "unused" if not passed via the command line.<br/>
        ///     - The MAWSC session command/action/option values are cleaned up so it's easier to apply logic to them.<br/>
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        internal static Dictionary<string, string> GetIndividualComponents(string[] arguments)
        {
            Dictionary<string, string> rawComponents   = GetRawComponents(arguments);
            Dictionary<string, string> cleanComponents = CleanComponents(rawComponents);

            return cleanComponents;
        }
        private static Dictionary<string, string> GetRawComponents(string[] arguments)
        {
            return new Dictionary<string, string>()
            {
                {"mawscCommand", GetRawCommand(arguments)},
                {"mawscAction",  GetRawAction(arguments) },
                {"mawscOption",  GetRawOption(arguments) },
            };
        }

        private static string GetRawCommand(string[] arguments)
        {
            return arguments[0];
        }

        private static string GetRawAction(string[] arguments)
        {
            return (arguments.Length >= 2)
                ? arguments[1]
                : "unused";
        }

        private static string GetRawOption(string[] arguments)
        {
            return (arguments.Length >= 3)
                ? arguments[2]
                : "unused";
        }

        private static Dictionary<string, string> CleanComponents(Dictionary<string, string> rawComponents)
        {
            var cleanComponents = new Dictionary<string, string>();

            foreach(KeyValuePair<string, string> item in rawComponents)
            {
                cleanComponents[item.Key] = item.Value.Trim().ToLower().Replace("-", "");
            }

            return cleanComponents;
        }
    }
}