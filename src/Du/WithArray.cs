// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Du.WithArray.cs
// UPDATED: 220511.104821 (v1.0-ApprenticeWizard)
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with arrays.
 */

namespace MAWSC.Du
{
    internal class WithArray
    {
        /// <summary>
        /// Converts a string[] to a List<string>.
        /// </summary>
        /// <param name="stringArray">The string[] to convert.</param>
        /// <returns>The contents of the string[] as a List<string>.</returns>
        internal static List<string> ToList(string[] stringArray)
        {
            // Not tested as of 5-10-22

            var listOfStrings = new List<string>();

            foreach(var element in stringArray)
            {
                listOfStrings.Add(element);
            }

            return listOfStrings;
        }
    }
}
