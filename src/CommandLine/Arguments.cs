// ========================================[ PROJECT ]=========================================
// MAWSC (MyAvatar Web Service Commander)
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.CommandLine.Arguments.cs
// Processes the command line arguments that are passed to MAWSC at execution.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Logging;
using MAWSC.Maintenance;

namespace MAWSC.CommandLine
{
    internal class Arguments
    {
        /// <summary>Verify at least one argument was passed via the command line.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        internal static void VerifyPassed(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                ExportLog.ToConsole(LogMessage.ArgumentsMissing());

                MawscTerminate.Gracefully(1);
            }
        }

        /// <summary>Get individual MAWSC session command/action/option.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        internal static Dictionary<string, string> GetIndividualArguments(string[] arguments)
        {
            Dictionary<string, string> rawArguments = GetRawArguments(arguments);
            Dictionary<string, string> cleanArguments = CleanRawArguments(rawArguments);

            return cleanArguments;
        }

        /// <summary>Get individual raw MAWSC session command, action, and option.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        private static Dictionary<string, string> GetRawArguments(string[] arguments)
        {
            return new Dictionary<string, string>()
            {
                {"mawscCommand", GetRawCommand(arguments)},
                {"mawscAction",  GetRawAction(arguments) },
                {"mawscOption",  GetRawOption(arguments) },
            };
        }

        /// <summary>Get raw MAWSC session command.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWSC session command.</returns>
        private static string GetRawCommand(string[] arguments)
        {
            return arguments[0];
        }

        /// <summary>Get raw MAWSC session action.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWSC session action.</returns>
        private static string GetRawAction(string[] arguments)
        {
            return (arguments.Length >= 2)
                ? arguments[1]
                : "unused";
        }

        /// <summary>Get raw MAWSC session option.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>MAWSC session option.</returns>
        private static string GetRawOption(string[] arguments)
        {
            return (arguments.Length >= 3)
                ? arguments[2]
                : "unused";
        }

        /// <summary>Clean MAWSC session arguments.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <returns>Individual command, action, and option values.</returns>
        private static Dictionary<string, string> CleanRawArguments(Dictionary<string, string> arguments)
        {
            var cleanComponents = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in arguments)
            {
                cleanComponents[item.Key] = item.Value.Trim().ToLower().Replace("-", "");
            }

            return cleanComponents;
        }
    }
}