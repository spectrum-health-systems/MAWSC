// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.CommandLine.Arguments.cs
// Processes the command line arguments that are passed to MAWSC at execution.
// b220606.131020

namespace MAWSC.CommandLine
{
    internal class Arguments
    {
        /// <summary>Get individual MAWSC session command, action, and option.</summary>
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

        private static string GetRawCommand(string[] arguments) => arguments[0];

        private static string GetRawAction(string[] arguments) => arguments.Length >= 2 ? arguments[1] : "unused";

        private static string GetRawOption(string[] arguments) => arguments.Length >= 3 ? arguments[2] : "unused";

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