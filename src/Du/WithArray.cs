// =============================================================================
// DU
// A library for .NET C#
// https://github.com/aprettycoolprogram/du)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// =============================================================================

// Du.WithArray.cs
// Does things with arrays.
// v0.99.0.0-220523.075036 (standalone version for MAWSC 1.2)

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
