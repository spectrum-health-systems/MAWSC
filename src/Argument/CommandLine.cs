// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

namespace MAWSC.Argument
{
    internal class CommandLine
    {
        /////// <summary>
        /////// Verifies that at least one argument was passed via the command line.
        /////// </summary>
        /////// <param name="passedArgumentss">Arguments passed via the command line.</param>
        ////internal static void VerifyArgumentsPassed(string[] commandLineArguments)
        ////{
        ////    /* We aren't testing for valid arguments yet, just their existance. If there aren't
        ////     * any passed arguments, we can't do anything. If that's the case, let the user
        ////     * know via the console (don't write a log file), and exit MAWSC.
        ////     */
        ////    if(commandLineArguments.Length == 0)
        ////    {
        ////        var logNoArgumentsPassedMessage = MAWSC.Log.Component.CommandLineArgumentsMissing();
        ////        MAWSC.Log.Export.ToConsole(logNoArgumentsPassedMessage);
        ////        MAWSC.Maintenance.Finalize(1);
        ////    }
        ////}

        /// <summary>
        /// Get the MAWSC command, action, and option.
        /// </summary>
        /// <param name="commandLineArguments">Arguments passed via the command line.</param>
        /// <returns></returns>
        internal static Dictionary<string, string> GetArgumentValues(string[] commandLineArguments)
        {
            return new Dictionary<string, string>
            {
                {"mawscCommand", MAWSC.Argument.Command.GetValue(commandLineArguments) },
                {"mawscAction",  MAWSC.Argument.Action.GetValue(commandLineArguments) },
                {"mawscOption",  MAWSC.Argument.Option.GetValue(commandLineArguments) },
            };
        }
    }
}