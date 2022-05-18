// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

namespace MAWSC.Argument
{
    internal class Command
    {
        /// <summary>
        /// Get the MAWSC command from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC command.</returns>
        internal static string GetValue(string[] commandLineArguments)
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
        /// <param name="mawscConfiguration">tet</param>
        internal static void Process(Dictionary<string, string> mawscArguments, Configuration mawscConfiguration)
        {
            /* If the "help" argument was passed, show the help screen and exit.
             */
            if(mawscArguments["mawscCommand"].StartsWith("h"))
            {
                MAWSC.Help.Display.OnCommandLine();
                MAWSC.Maintenance.Finalize(0);
            }
            else
            {
                //MAWSC.Maintenance.Initialize(mawscArguments, mawscConfiguration);

                if(mawscArguments["mawscCommand"].StartsWith("c"))
                {
                    MAWSC.Configuration.ProcessAction(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);
                }
                else if(mawscArguments["mawscCommand"].StartsWith("p"))
                {
                    //CommandProduction(mawscConfiguration);
                }
                else if(mawscArguments["mawscCommand"].StartsWith("s"))
                {
                    //MAWSC.Staging.Roundhouse.Process(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);

                }
            }
        }

    }
}