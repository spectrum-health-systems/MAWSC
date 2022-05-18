// =============================================================================
// DU
// A library for .NET C#
// https://github.com/aprettycoolprogram/du)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// =============================================================================

// Du.WithApplication.cs
// Does things with applications.
// v1.0.0.0-b220518.115916+ApprenticeWizard

namespace MAWSC.Du
{
    internal class WithApplication
    {
        /// <summary>
        /// Exit the application, and tell the user why via a pop-up message.
        /// </summary>
        /// <param name="title">Title of the MessageBox</param>
        /// <param name="message">Message for the MessageBox</param>
        internal static void TerminateWithPopup(string title, string message)
        {
            // Not tested as of 5-10-22

            // TODO This doesn't work. Should be an easy fix, so leaving the code here.

            //_=MessageBox.Show(message, title);
            //Environment.Exit(0);
        }
    }
}