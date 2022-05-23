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
