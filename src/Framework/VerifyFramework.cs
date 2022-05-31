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
        /// <summary>Verify that required directories exist, and create them if they don't.</summary>
        /// <returns>Log message.</returns>
        internal static void RequiredDirectories(MawscSettings mawscSettings)
        { //x
            var requiredDirectories = new List<string>
            {
                mawscSettings.ConfigurationDirectory,
                mawscSettings.LogDirectory,
                mawscSettings.BackupDirectory,
                mawscSettings.StagingSourceDirectory,
                mawscSettings.TemporaryDirectory
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

            ExportLog.ToEverywhere(LogMessage.VerifyFrameworkRequiredDirectories(logContent), mawscSettings.LogfilePath);

            /* Also verify the session backup directory.
             */
            SessionBackupDirectory(mawscSettings.BackupDirectory, mawscSettings.SessionTimestamp);
        }

        /// <summary>Verify that the session backup directory exists, and create it if it does not.</summary>
        /// <param name="sessionBackupDirectory"></param>
        /// <param name="sessionTimeStamp"></param>
        internal static void SessionBackupDirectory(string sessionBackupDirectory, string sessionTimeStamp)
        {
            Du.WithDirectory.ConfirmDirectoryExists($"{sessionBackupDirectory}{sessionTimeStamp}");
            ExportLog.ToConsole(MAWSC.Logging.LogMessage.SessionBackupDirectoryVerify());
        }

    }
}