// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

namespace MAWSC.Staging
{
    internal class Backup
    {
        internal static void Source(MAWSC.Configuration.Settings mawscSettings)
        {
            var stagingSourceDirectory = mawscSettings.StagingSourceDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            MAWSC.Log.Export.ToConsole(Log.Message.BackupStagingSourceRequest(mawscSettings));
            MAWSC.Log.Export.ToConsole(Log.Message.BackupStagingSource(mawscSettings));

            Du.WithArchive.DirectoryAsFullname(stagingSourceDirectory, backupDirectory);
        }

        internal static void Target(MAWSC.Configuration.Settings mawscSettings)
        {
            var stagingTargetDirectory = mawscSettings.StagingTargetDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            MAWSC.Log.Export.ToConsole(Log.Message.BackupStagingTargetRequest(mawscSettings));
            MAWSC.Log.Export.ToConsole(Log.Message.BackupStagingTarget(mawscSettings));

            Du.WithArchive.DirectoryAsFullname(stagingTargetDirectory, backupDirectory);
        }
    }
}
