// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.SyntaxEngine.Parser.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with passed arguments.
 */


namespace MAWSC
{
    internal class Parser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="passedArgs"></param>
        /// <returns></returns>
        internal static string GetMawscCommand(string[] commandLineArguments)
        {
            /* Has to be at least one command line argument.
             */
            if(commandLineArguments.Length != 0)
            {
                commandLineArguments[0].Trim().ToLower().Replace("-", "");
            }

            /* The MAWSC "command" is the first argument that is passed when MAWSC is executed,
             * so let's make it easy to work with.
             */
            return commandLineArguments[0].Trim().ToLower().Replace("-", "");
        }
    }
}
