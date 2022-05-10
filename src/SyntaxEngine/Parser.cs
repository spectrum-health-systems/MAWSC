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


namespace MAWSC.SyntaxEngine
{
    internal class Parser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="passedArgs"></param>
        /// <returns></returns>
        internal static string GetCommand(string[] passedArguments)
        {
            /* The MAWSC "command" is the first argument that is passed when MAWSC is executed,
             * so let's make it easy to work with.
             */
            return passedArguments[0].Trim().ToLower().Replace("-", "");
        }

    }
}
