// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Framework.VerifyFramework.cs
// Verify framework components.
// b220531.085752 x

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Framework
{
    internal class VerifyFramework
    {
        /// <summary>Verify the MAWSC framework.</summary>
        /// <remarks>
        ///     <para>
        ///         - Now that we have the configuration settings, we can verify the framework.
        ///         - We'll jumpstart the logfile with the header we created earlier, then write log information everywhere going forward.
        ///     </para>
        /// </remarks>
        /// <param name="mawsc"></param>
        internal static void Startup(MawscSettings mawsc)
        { //x
            RefreshFramework.Directories(mawsc);

            ExportLog.ToFile(LogHeader.Top(mawsc.SessionTimestamp), mawsc.LogfilePath);
            ExportLog.ToEverywhere(LogMessage.ArgumentsPassed(mawsc), mawsc.LogfilePath);

            RequiredDirectories(mawsc);
            SessionBackupDirectory(mawsc.BackupDirectory, mawsc.SessionTimestamp);
        }

        /// <summary>Verify that required directories exist, and create them if they don't.</summary>
        /// <returns>Log message.</returns>
        internal static void RequiredDirectories(MawscSettings mawsc)
        { //x
            var requiredDirectories = new List<string>
            {
                mawsc.ConfigurationDirectory,
                mawsc.LogDirectory,
                mawsc.BackupDirectory,
                mawsc.StagingFetchDirectory,
                mawsc.TemporaryDirectory
            };

            var logContent = "";

            foreach(var requiredDirectory in requiredDirectories)
            {
                logContent += $"{Environment.NewLine}";

                if(!Directory.Exists(requiredDirectory))
                {
                    logContent += $"           {requiredDirectory}: does not exist...";
                    Directory.CreateDirectory(requiredDirectory);
                    logContent += $"created...Verified";
                }
                else
                {
                    logContent += $"           {requiredDirectory}: Verified.";
                }
            }

            ExportLog.ToEverywhere(LogMessage.VerifyFrameworkRequiredDirectories(logContent), mawsc.LogfilePath);
        }

        /// <summary>Verify that the session backup directory exists, and create it if it does not.</summary>
        /// <param name="sessionBackupDirectory"></param>
        /// <param name="sessionTimeStamp"></param>
        internal static void SessionBackupDirectory(string sessionBackupDirectory, string sessionTimeStamp)
        {
            Du.WithDirectory.ConfirmDirectoryExists($"{sessionBackupDirectory}{sessionTimeStamp}");
            ExportLog.ToConsole(LogMessage.SessionBackupDirectoryVerify());
        }

    }
}