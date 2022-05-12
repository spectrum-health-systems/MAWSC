// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Roundhouse.cs
// UPDATED: 220512.114404
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
        internal static void Process(string[] commandLineArguments)
        {
            var mawscArguments = GetMawscArguments(commandLineArguments);

            var mawscConfiguration = MAWSC.Configuration.Load();

            if(mawscConfiguration.ValidCommands.Contains(mawscArguments["mawscCommand"]))
            {
                ProcessCommand(mawscArguments, mawscConfiguration);
            }
            else
            {
                InvalidCommand(mawscArguments["mawscCommand"]);
            }
        }

        private static Dictionary<string, string> GetMawscArguments(string[] commandLineArguments)
        {
            var mawscArguments = new Dictionary<string, string>
            {
                {"mawscCommand", "none" },
                {"mawscAction",  "none" },
                {"mawscOption",  "none" },
            };

            mawscArguments["mawscCommand"] = commandLineArguments[0].Trim().ToLower().Replace("-", "");

            if(commandLineArguments.Length == 2)
            {
                mawscArguments["mawscAction"] = commandLineArguments[1].Trim().ToLower().Replace("-", "");
            }

            if(commandLineArguments.Length == 3)
            {
                mawscArguments["mawscOption"] = commandLineArguments[2].Trim().ToLower().Replace("-", "");
            }

            return mawscArguments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscCommand"></param>
        /// <param name="mawscConfiguration"></param>
        private static void ProcessCommand(Dictionary<string, string> mawscArguments, Configuration mawscConfiguration)
        {
            /* If the "help" argument was passed, show the help screen and exit.
             */
            if(mawscArguments["mawscCommand"].StartsWith("h"))
            {
                CommandHelp();
            }
            else
            {
                MAWSC.Utility.Maintenance.Initialize(mawscArguments, mawscConfiguration);
                //ProcessCommander(mawscCommand, mawscConfiguration);

                if(mawscArguments["mawscCommand"].StartsWith("c"))
                {
                    CommandConfiguration(mawscConfiguration);
                }
                else if(mawscArguments["mawscCommand"].StartsWith("p"))
                {
                    CommandProduction(mawscConfiguration);
                }
                else if(mawscArguments["mawscCommand"].StartsWith("s"))
                {
                    CommmandStaging(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);
                }
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
