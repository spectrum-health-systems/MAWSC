﻿// =============================================================================
// DU
// A library for .NET C#
// https://github.com/aprettycoolprogram/du)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// =============================================================================

// Du.WithString.cs
// Does things with strings.
// v1.0.0.0-b220518.115916+ApprenticeWizard

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

