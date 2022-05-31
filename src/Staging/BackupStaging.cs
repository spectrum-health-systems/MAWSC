// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.BackupStaging.cs
// Backup the current staging source.
// b220531.110901

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Staging
{
    internal class BackupStaging
    {
        internal static void Source(MawscSettings mawscSettings)
        {
            var stagingSourceDirectory = mawscSettings.StagingSourceDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            ExportLog.ToConsole(Logging.LogMessage.BackupStagingSourceRequest(mawscSettings));
            ExportLog.ToConsole(Logging.LogMessage.BackupStagingSource(mawscSettings));

            Du.WithArchive.DirectoryAsFullname(stagingSourceDirectory, backupDirectory);
        }

        internal static void Target(MawscSettings mawscSettings)
        {
            var stagingTargetDirectory = mawscSettings.StagingTargetDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            ExportLog.ToConsole(Logging.LogMessage.BackupStagingTargetRequest(mawscSettings));
            ExportLog.ToConsole(Logging.LogMessage.BackupStagingTarget(mawscSettings));

            Du.WithArchive.DirectoryAsFullname(stagingTargetDirectory, backupDirectory);
        }
    }
}
