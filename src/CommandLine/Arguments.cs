// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.CommandLine.Arguments.cs
// Processes the command line arguments that are passed to MAWSC at execution.
// b220608.105635

namespace MAWSC.CommandLine
{
    internal class Arguments
    {
        /// <summary>Verify at least one argument was passed via the command line.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - We aren't testing for valid arguments yet, just their existance.<br/>
        ///         - If there aren't any passed arguments, we can't do anything, so let the user know via the console (don't write a log file), and exit MAWSC.
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        internal static void VerifyPassed(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Logging.ExportLog.ToConsole(Logging.LogMessage.ArgumentsMissing());

                Maintenance.MawscTerminate.Gracefully(1);
            }
        }

        /// <summary>
        /// Get individual MAWSC session command/action/option.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - Gets the raw MAWSC session command/action/option from the command line.<br/>
        ///     - Components may contain dashes, and any combination of casing.<br/>
        ///     - There must be a MAWSC session command value, which will have been verified at this point.<br/>
        ///     - The MAWSC session action/option are optional, and are set to "unused" if not passed via the command line.<br/>
        ///     - The MAWSC session command/action/option values are cleaned up so it's easier to apply logic to them.<br/>
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        internal static Dictionary<string, string> GetIndividualArguments(string[] arguments)
        {
            Dictionary<string, string> rawArguments = GetRawComponents(arguments);
            Dictionary<string, string> cleanArguments = CleanRawComponents(rawArguments);

            return cleanArguments;
        }

        /// <summary>
        /// Get individual MAWSC session command, action, and option.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - Gets the raw MAWSC session command/action/option from the command line.<br/>
        ///     - These components may contain dashes, and any combination of casing.
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        private static Dictionary<string, string> GetRawComponents(string[] arguments)
        {
            return new Dictionary<string, string>()
            {
                {"mawscCommand", GetRawCommand(arguments)},
                {"mawscAction",  GetRawAction(arguments) },
                {"mawscOption",  GetRawOption(arguments) },
            };
        }

        /// <summary>
        /// Get MAWSC session command.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - There must be a MAWSC session command value, which will have been verified at this point.
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWSC session command.</returns>
        private static string GetRawCommand(string[] arguments)
        {
            return arguments[0];
        }

        /// <summary>
        /// Get individual MAWSC session action.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - The MAWSC session action is optional.<br/>
        ///     - If an MAWSC session action is not passed, it is set to "unused".
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWSC session action.</returns>
        private static string GetRawAction(string[] arguments)
        {
            return (arguments.Length >= 2)
                ? arguments[1]
                : "unused";
        }

        /// <summary>
        /// Get individual MAWSC session option.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - The MAWSC session option is optional.<br/>
        ///     - If an MAWSC session option is not passed, it is set to "unused".
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWSC session option.</returns>
        private static string GetRawOption(string[] arguments)
        {
            return (arguments.Length >= 3)
                ? arguments[2]
                : "unused";
        }

        /// <summary>
        /// Clean MAWSC session command/action/option.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     <b><u>NOTES</u></b><br/>
        ///     - The MAWSC session command/action/option values are cleaned up so it's easier to apply logic to them.
        ///     </para>
        /// </remarks>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        private static Dictionary<string, string> CleanRawComponents(Dictionary<string, string> rawComponents)
        {
            var cleanComponents = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in rawComponents)
            {
                cleanComponents[item.Key] = item.Value.Trim().ToLower().Replace("-", "");
            }

            return cleanComponents;
        }
    }
}