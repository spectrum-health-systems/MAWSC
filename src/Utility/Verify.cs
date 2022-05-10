// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Utility.Verify.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025

/* =============================================================================
 * About this class
 * =============================================================================
 * Verifies stuff.
 */


namespace MAWSC.Utility
{
    internal class Verify
    {
        /// <summary>
        /// Verifies that at least one argument was passed.
        /// </summary>
        /// <param name="passedArgs">The args[] object.</param>
        internal static void ArgumentsPassed(ref string logContent, string[] passedArgs)
        {
            /* There has to be at least one argument, otherwise we can't do anything, so just exit.
             */
            if(passedArgs.Length == 0)
            {
                Logging.LogContent.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"No arguments passed to MAWSC", "INVALID");
                Utility.MawscStatus.End(logContent, 1);
            }
        }
    }
}
