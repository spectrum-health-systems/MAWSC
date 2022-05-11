// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Roundhouse.cs
// UPDATED: 220511.104821
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * MAWSC roundhouse
 */

namespace MAWSC
{
    internal class Roundhouse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandLineArguments"></param>
        internal static void ProcessCommand(string[] commandLineArguments)
        {
            var mawscCommand = commandLineArguments[0].Trim().ToLower().Replace("-", "");

            var mawscAction = "none";

            if(commandLineArguments.Length == 2)
            {
                mawscAction = commandLineArguments[1].Trim().ToLower().Replace("-", "");
            }

            var mawscOption = "none";

            if(commandLineArguments.Length == 3)
            {
                mawscOption = commandLineArguments[2].Trim().ToLower().Replace("-", "");
            }

            var mawscConfiguration = MAWSC.Configuration.Load();

            if(mawscConfiguration.ValidCommands.Contains(mawscCommand))
            {
                ProcessCommander(mawscCommand, mawscAction, mawscOption, mawscConfiguration);
            }
            else
            {
                InvalidCommand(mawscCommand);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscCommand"></param>
        /// <param name="mawscConfiguration"></param>
        private static void ProcessCommander(string mawscCommand, string mawscAction, string mawscOption, Configuration mawscConfiguration)
        {
            /* If the "help" argument was passed, show the help screen and exit.
             */
            if(mawscCommand.StartsWith("h"))
            {
                CommandHelp();
            }
            else
            {
                MAWSC.Utility.Maintenance.Initialize(mawscCommand, mawscAction, mawscOption, mawscConfiguration);
                //ProcessCommander(mawscCommand, mawscConfiguration);

                if(mawscCommand.StartsWith("c"))
                {
                    CommandConfiguration(mawscConfiguration);
                }
                else if(mawscCommand.StartsWith("p"))
                {
                    CommandProduction(mawscConfiguration);
                }
                else if(mawscCommand.StartsWith("s"))
                {
                    CommmandStaging(mawscAction, mawscOption, mawscConfiguration);
                }

                ////switch(mawscCommand)
                ////    {
                ////        case "c":
                ////        case "config":
                ////        case "configuration":
                ////            ProcessConfiguration(mawscConfiguration);
                ////            break;

                ////        case "s":
                ////        case "stage":
                ////        case "staging":
                ////            ProcessStaging(mawscConfiguration);
                ////            break;

                ////        case "p":
                ////        case "prod":
                ////        case "production":
                ////            ProcessProduction(mawscConfiguration);
                ////            break;



                ////        default:
                ////            /* An invalid MAWSC command was sent, so just exit.
                ////             */
                ////            //////MAWSC.Logging.Content.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"Arg[0] \"{passedArguments[0]}\"", "INVALID");
                ////            //MAWSC.Utility.MawscStatus.End(logContent, 0);
                ////            break;
                ////    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CommandHelp()
        {
            MAWSC.Help.Display.OnCommandLine();
            MAWSC.Utility.Maintenance.Finalize(0);
        }

        private static void InvalidCommand(string mawscCommand)
        {
            var logInvalidCommandPassed = MAWSC.Log.Component.InvalidCommandPassed(mawscCommand);
            Console.WriteLine(logInvalidCommandPassed);
            MAWSC.Utility.Maintenance.Finalize(2);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        private static void CommandProduction(Configuration mawscConfiguration)
        {
            MAWSC.Utility.Maintenance.Finalize(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        private static void CommmandStaging(string mawscAction, string mawscOption, Configuration mawscConfiguration)
        {
            //var logMessage = "STAGE";
            //MAWSC.Log.Export.ToEverywhere(logMessage, mawscConfiguration.LogfilePath);
            //////MAWSC.Logging.Content.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"Arg[0] \"{passedArguments[0]}\"", "VALID");
            //Staging.ParseArgs(ref logContent, passedArguments);
            MAWSC.Utility.Maintenance.Finalize(0);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        private static void DefaultFallthrough(Configuration mawscConfiguration)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        private static void CommandConfiguration(Configuration mawscConfiguration)
        {

        }
    }
}
