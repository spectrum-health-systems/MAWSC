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
        internal static void Current(MAWSC.Configuration.Settings mawscSettings)
        {
            var stagingDirectory = mawscSettings.StagingDirectory;
            var backupDirectory  = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            Du.WithDirectory.ConfirmDirectoryExists(backupDirectory);

            Du.WithArchive.DirectoryAsFullname(stagingDirectory, backupDirectory);



        }
    }
}
