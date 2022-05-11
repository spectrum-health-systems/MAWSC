// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Du.WithString.cs
// UPDATED: 220511.104821 (v1.0-ApprenticeWizard)
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with strings.
 */

namespace MAWSC.Du
{
    internal class WithString
    {
        /// <summary>
        /// Convert a string to a string[].
        /// </summary>
        /// <param name="workString">The string to convert.</param>
        /// <param name="delimiter">The delimiter used to seperate the lines.</param>
        /// <returns></returns>
        public static string[] ToArray(string workString, char delimiter)
        {
            // Not tested as of 5-10-22

            return workString.Split(delimiter);
        }
    }
}

