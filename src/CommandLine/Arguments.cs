// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.CommandLine.Arguments.cs
// Processes the command line arguments that are passed to MAWSC at execution.
// b220606.130747

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

        /// <summary>Get raw passed arguments.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - Arguments can be passed with leading dashes, and any case combination. These end up as the rawComponents, which will be cleaned up later.
        ///     </para> 
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Arguments as they were passed via the command line..</returns>
        private static Dictionary<string, string> GetRawComponents(string[] arguments)
        {
            return new Dictionary<string, string>()
            {
                {"mawscCommand", GetRawCommand(arguments)},
                {"mawscAction",  GetRawAction(arguments) },
                {"mawscOption",  GetRawOption(arguments) },
            };
        }

        /// <summary>Get MAWSC session command from the command line.</summary>
        /// <remarks>
        ///     <para>
        ///      <b><u>NOTES</u></b><br/>
        ///      - A MAWSC command is required, and will have been verified at this point.
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWS session command.</returns>
        private static string GetRawCommand(string[] arguments) => arguments[0];

        /// <summary>Get MAWSC session action from the command line.</summary>
        /// <remarks>
        ///     <para>
        ///      <b><u>NOTES</u></b><br/>
        ///      - If a MAWSC action wasn't passsed, it will be set to the default "unused" value.
        ///     </para>
        /// </remarks> 
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWS session action.</returns>
        private static string GetRawAction(string[] arguments) => arguments.Length >= 2 ? arguments[1] : "unused";

        /// <summary>Get MAWSC session option from the command line.</summary>
        /// <remarks>
        ///     <para>
        ///      <b><u>NOTES</u></b><br/>
        ///      - If a MAWSC option wasn't passsed, it will be set to the default "unused" value.
        ///     </para>
        /// </remarks> 
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWS session option.</returns>
        private static string GetRawOption(string[] arguments) => arguments.Length >= 3 ? arguments[2] : "unused";

        /// <summary>Cleanup the MAWSC session command, action, and option.</summary>
        /// <remarks>
        ///     <para>
        ///      <b><u>NOTES</u></b><br/>
        ///      - Removes and dashes, and makes everything lowercase to make the logic around these components easier.
        ///     </para>
        /// </remarks> 
        /// <param name="rawComponents">The MAWSC session command, action, and option as they were passed via the command line.</param>
        /// <returns>Cleaned MAWSC session command, action, and option.</returns>
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