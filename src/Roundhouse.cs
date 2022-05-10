// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Roundhouse.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025

/* =============================================================================
 * About this class
 * =============================================================================
 * Determines what to do.
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
        internal static void ProcessCommand(ref string logContent, string mawscCommand, string[] passedArguments)
        {
            /* Give the users a little wiggle room when typing commands, this way they can use shorthand if they want.
             */
            switch(mawscCommand)
            {
                case "s":
                case "stage":
                case "staging":
                    /* We're going to do something with the MAWS Staging environment!
                     */
                    MAWSC.Logging.LogContent.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"Arg[0] \"{passedArguments[0]}\"", "VALID");
                    //Staging.ParseArgs(ref logContent, passedArguments);
                    MAWSC.Utility.MawscStatus.End(logContent, 0);
                    break;

                case "p":
                case "prod":
                case "production":
                    /* We're going to do something with the MAWS Staging environment! - Future functionality
                     */
                    break;

                case "h":
                case "help":
                    Help.Display.OnCommandLine();
                    break;

                case "reset":
                    MAWSC.Logging.LogContent.AppendAndShowMsg(ref logContent, "[  RESET] ", $"Resetting config.json", "DONE");
                    MAWSC.Settings.ResetToDefault();
                    MAWSC.Utility.MawscStatus.End(logContent, 0);
                    break;

                default:
                    /* An invalid MAWSC command was sent, so just exit.
                     */
                    MAWSC.Logging.LogContent.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"Arg[0] \"{passedArguments[0]}\"", "INVALID");
                    MAWSC.Utility.MawscStatus.End(logContent, 0);
                    break;
            }
        }

    }
}
