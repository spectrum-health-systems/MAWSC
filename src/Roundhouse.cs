// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Roundhouse.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025

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
        /// <param name="logContent"></param>
        /// <param name="mawscCommand"></param>
        /// <param name="passedArguments"></param>
        internal static void ProcessCommand(string mawscCommand, string[] commandLineArguments)
        {
            if(mawscCommand == "h" || mawscCommand == "help")
            {
                MAWSC.Help.Display.OnCommandLine();
                MAWSC.Utility.Maintenance.Finalize(0);
            }
            else
            {
                var mawscConfiguration = MAWSC.Configuration.Load();

                MAWSC.Utility.Maintenance.Initialize(mawscConfiguration, commandLineArguments);

                switch(mawscCommand)
                {
                    case "s":
                    case "stage":
                    case "staging":
                        //var logMessage = "STAGE";
                        //MAWSC.Log.Export.ToEverywhere(logMessage, mawscConfiguration.LogfilePath);
                        //////MAWSC.Logging.Content.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"Arg[0] \"{passedArguments[0]}\"", "VALID");
                        //Staging.ParseArgs(ref logContent, passedArguments);
                        MAWSC.Utility.Maintenance.Finalize(0);
                        break;

                    case "p":
                    case "prod":
                    case "production":
                        /* We're going to do something with the MAWS Staging environment! - Future functionality
                         */
                        break;

                    case "reset":
                        //////MAWSC.Logging.Content.AppendAndShowMsg(ref logContent, "[  RESET] ", $"Resetting config.json", "DONE");
                        MAWSC.Configuration.ResetToDefault();
                        //MAWSC.Utility.MawscStatus.End( 0);
                        break;

                    default:
                        /* An invalid MAWSC command was sent, so just exit.
                         */
                        //////MAWSC.Logging.Content.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"Arg[0] \"{passedArguments[0]}\"", "INVALID");
                        //MAWSC.Utility.MawscStatus.End(logContent, 0);
                        break;
                }
            }
        }
    }
}
