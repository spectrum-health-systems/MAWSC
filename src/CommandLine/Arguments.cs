﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.CommandLine.Arguments.cs
// Command line stuff.
// b220603.190907

using MAWSC.Configuration;

namespace MAWSC.CommandLine
{
    internal class Arguments
    {
        /// <summary>
        /// Get the MAWSC command, action, and option.
        /// </summary>
        /// <param name="commandLineArguments">Arguments passed via the command line.</param>
        /// <returns></returns>
        internal static Dictionary<string, string> GetArgumentValues(string[] commandLineArguments)
        {
            return new Dictionary<string, string>
            {
                {"mawscCommand", GetCommandValue(commandLineArguments) },
                {"mawscAction",  GetActionValue(commandLineArguments) },
                {"mawscOption",  GetOptionValue(commandLineArguments) },
            };
        }

        /// <summary>
        /// Get the MAWSC action from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC action.</returns>
        internal static string GetActionValue(string[] commandLineArguments)
        {
            return commandLineArguments.Length >= 2
                ? commandLineArguments[1].Trim().ToLower().Replace("-", "")
                : "not-passed";
        }

        /// <summary>
        /// Get the MAWSC command from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC command.</returns>
        internal static string GetCommandValue(string[] commandLineArguments)
        {
            return commandLineArguments[0].Trim().ToLower().Replace("-", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscCommand"></param>
        /// <param name="validCommands"></param>
        /// <returns></returns>
        internal static bool Validate(string mawscCommand, List<string> validCommands)
        {
            return validCommands.Contains(mawscCommand);
        }

        /// <summary>
        /// wetrw
        /// </summary>
        /// <param name="mawscCommand">tet</param>
        /// <param name="mawsc">tet</param>
        internal static void Process(MawscSettings mawsc)
        {
            /* If the "help" argument was passed, show the help screen and exit.
             */
            if(mawsc.MawscCommand.StartsWith("h"))
            {
                MAWSC.Help.DisplayHelp.ForDefault();
                MAWSC.Maintenance.MawscTerminate.Gracefully(0);
            }
            else
            {
                //MAWSC.Maintenance.Initialize(mawscArguments, mawscConfiguration);

                ////if(mawscArguments["mawscCommand"].StartsWith("c"))
                ////{
                ////    MAWSC.Configuration.Roundhouse.ProcessAction(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscSettings);
                ////}
                ////else if(mawscArguments["mawscCommand"].StartsWith("p"))
                ////{
                ////    //CommandProduction(mawscConfiguration);
                ////}
                ////else if(mawscArguments["mawscCommand"].StartsWith("s"))
                ////{
                ////    //MAWSC.Staging.Roundhouse.Process(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);

                ////}
            }
        }

        /// <summary>
        /// Get the MAWSC option from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC option.</returns>
        internal static string GetOptionValue(string[] commandLineArguments)
        {
            return commandLineArguments.Length >= 3
                ? commandLineArguments[2].Trim().ToLower().Replace("-", "")
                : "not-passed";
        }
    }
}