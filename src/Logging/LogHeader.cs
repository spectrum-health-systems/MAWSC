// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Logging.LogHeader.cs
// Logging headers.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWSC-Sourcecode.md

using System.Reflection;

namespace MAWSC.Logging
{
    internal class LogHeader
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="backupText"></param>
        /// <returns></returns>
        internal static string Backup(string backupText)
        {
            return $"[BACKUP  ] {backupText}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="backupText"></param>
        /// <returns></returns>
        internal static string Error(string errorText)
        {
            return $"[ERROR   ] {errorText}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="infoHeaderText"></param>
        /// <returns></returns>
        internal static string Info(string infoText)
        {
            return $"[INFO    ] {infoText}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="requestHeaderText"></param>
        /// <returns></returns>
        internal static string Request(string requestText)
        {
            return $"[REQUEST ] {requestText}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="verifyText"></param>
        /// <returns></returns>
        internal static string Verify(string verifyText)
        {
            return $"[VERIFY  ] {verifyText}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <param name="validateText"></param>
        /// <returns></returns>
        internal static string Validate(string validateText)
        {
            return $"[VALIDATE] {validateText}";
        }

        /// <summary>Create a log message sub-header.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - The sub-header string is a generic sub-header for log files. Content is determined by the subHeaderText parameter.
        ///     </para>
        /// </remarks>
        /// <returns>Sub-header string for log files.</returns>
        /// <param name="subText">Sub-header text to be displayed.</param>
        internal static string Sub(string subText)
        {
            return $"{Environment.NewLine}" +
                   $"----------------------------------------{Environment.NewLine}" +
                   $"{subText}{Environment.NewLine}" +
                   $"----------------------------------------{Environment.NewLine}";
        }

        /// <summary>Create the log message master header.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - The master header string is at the top of each logfile, and always contains the same information.
        ///     </para> 
        /// </remarks>
        /// <returns>Header string for log files.</returns>
        internal static string Top(string sessionTimestamp)
        {
            var applicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            return $"========================================{Environment.NewLine}" +
                   $"MAWSC {applicationVersion} ({sessionTimestamp}){Environment.NewLine}" +
                   $"========================================{Environment.NewLine}" +
                   $"[STARTING]";
        }
    }
}
