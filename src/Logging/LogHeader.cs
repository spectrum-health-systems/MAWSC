// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Logging.LogHeader.cs
// Logging headers.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using System.Reflection;

namespace MAWSC.Logging
{
    internal class LogHeader
    {
        /// <summary></summary>
        /// <param name="backupText"></param>
        /// <returns></returns>
        internal static string Backup(string backupText)
        {
            return $"[BACKUP  ] {backupText}";
        }

        /// <summary></summary>
        /// <param name="backupText"></param>
        /// <returns></returns>
        internal static string Error(string errorText)
        {
            return $"[ERROR   ] {errorText}";
        }

        /// <summary></summary>
        /// <param name="infoHeaderText"></param>
        /// <returns></returns>
        internal static string Info(string infoText)
        {
            return $"[INFO    ] {infoText}";
        }

        /// <summary></summary>
        /// <param name="requestHeaderText"></param>
        /// <returns></returns>
        internal static string Request(string requestText)
        {
            return $"[REQUEST ] {requestText}";
        }

        /// <summary></summary>
        /// <param name="verifyText"></param>
        /// <returns></returns>
        internal static string Verify(string verifyText)
        {
            return $"[VERIFY  ] {verifyText}";
        }

        /// <summary></summary>
        /// <param name="validateText"></param>
        /// <returns></returns>
        internal static string Validate(string validateText)
        {
            return $"[VALIDATE] {validateText}";
        }

        /// <summary>Create a log message sub-header.</summary>
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
