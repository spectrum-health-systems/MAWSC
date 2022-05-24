namespace MAWSC.Staging
{
    internal class Fetch
    {
        internal static void FromUrl(MAWSC.Configuration.Settings mawscSettings)
        {
            var downloadFilePath = $"{mawscSettings.TemporaryDirectory}web-service-from-url.zip";

            Du.Internet.DownloadZipFromUrl(mawscSettings.RepositoryUrl, downloadFilePath);

            var extractFilePath = $"{mawscSettings.TemporaryDirectory}web-service-repository/";

            Du.WithArchive.Uncompress(downloadFilePath, extractFilePath);

            Du.WithFile.MoveUsingFileName(downloadFilePath, $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}/");

            Du.WithDirectory.RefreshRecursively(mawscSettings.StagingSourceDirectory);

            Du.WithDirectory.MoveRecursively(extractFilePath, mawscSettings.StagingSourceDirectory);
        }
    }
}
