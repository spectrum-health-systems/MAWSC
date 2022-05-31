// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.Backup.cs
// Backup the current staging source.
// b220526.080326

namespace MAWSC.Staging
{
    internal class Backup
    {
        internal static void Source(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            var stagingSourceDirectory = mawscSettings.StagingSourceDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            MAWSC.Logging.ExportLog.ToConsole(Logging.LogMessage.BackupStagingSourceRequest(mawscSettings));
            MAWSC.Logging.ExportLog.ToConsole(Logging.LogMessage.BackupStagingSource(mawscSettings));

            Du.WithArchive.DirectoryAsFullname(stagingSourceDirectory, backupDirectory);
        }

        internal static void Target(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            var stagingTargetDirectory = mawscSettings.StagingTargetDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            MAWSC.Logging.ExportLog.ToConsole(Logging.LogMessage.BackupStagingTargetRequest(mawscSettings));
            MAWSC.Logging.ExportLog.ToConsole(Logging.LogMessage.BackupStagingTarget(mawscSettings));

            Du.WithArchive.DirectoryAsFullname(stagingTargetDirectory, backupDirectory);
        }
    }
}
