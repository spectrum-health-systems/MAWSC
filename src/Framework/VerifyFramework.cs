// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Framework.VerifyFramework.cs
// Verify framework components.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Framework
{
    internal class VerifyFramework
    {
        /// <summary>Verify the MAWSC framework.</summary>
        /// <param name="mawsc">MAWSC settings.</param>
        internal static void Startup(ConfigurationSettings mawsc)
        {
            RefreshFramework.Directories(mawsc);

            ExportLog.ToFile(LogHeader.Top(mawsc.SessionTimestamp), mawsc.SessionLogfilePath);
            ExportLog.ToEverywhere(LogMessage.ArgumentsPassed(mawsc), mawsc.SessionLogfilePath);

            RequiredDirectories(mawsc);
            SessionBackupDirectory(mawsc.BackupDirectory, mawsc.SessionTimestamp);
        }

        /// <summary>Verify that required directories exist, and create them if they don't.</summary>
        /// <returns>Log message.</returns>
        internal static void RequiredDirectories(ConfigurationSettings mawsc)
        {
            var requiredDirectories = new List<string>
            {
                mawsc.ConfigurationDirectory,
                mawsc.LogDirectory,
                mawsc.BackupDirectory,
                mawsc.StagingFetchDirectory,
                mawsc.TemporaryDirectory
            };

            var logContent = "";

            foreach (var requiredDirectory in requiredDirectories)
            {
                logContent += $"{Environment.NewLine}";

                if (!Directory.Exists(requiredDirectory))
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

            ExportLog.ToEverywhere(LogMessage.VerifyFrameworkRequiredDirectories(logContent), mawsc.SessionLogfilePath);
        }

        /// <summary>Verify that the session backup directory exists, and create it if it does not.</summary>
        /// <param name="sessionBackupDirectory">Backup directory for a MAWSC session.</param>
        /// <param name="sessionTimeStamp">Session timestamp for this session.</param>
        internal static void SessionBackupDirectory(string sessionBackupDirectory, string sessionTimeStamp)
        {
            Du.WithDirectory.ConfirmDirectoryExists($"{sessionBackupDirectory}{sessionTimeStamp}");
            ExportLog.ToConsole(LogMessage.SessionBackupDirectoryVerify());
        }
    }
}