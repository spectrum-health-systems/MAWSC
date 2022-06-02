// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.FetchStaging.cs
// Get the staging source from a repository.
// bb220602.083119

using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class FetchStaging
    {
        internal static void SoupToNuts(MawscSettings mawscSettings)
        {
            BackupStaging.SoupToNuts(mawscSettings);
            CleanStaging.FetchLocation(mawscSettings);

            var targetFile = $"{mawscSettings.TemporaryDirectory}{mawscSettings.RepositoryBranch}"; // config

            GetFromUrl(mawscSettings.RepositoryUrl, targetFile);
            UncompressStagingSource(targetFile);

            var sessionBackupDirectory = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}/";
            var targetDirectory        = $"{targetFile}/{mawscSettings.RepositoryName}-{mawscSettings.RepositoryBranch}";

            CopyTo(targetFile, sessionBackupDirectory, targetDirectory, mawscSettings.StagingFetchDirectory);
        }

        /// <summary>Fetch staging sourcecode from a URL.</summary>
        /// <param name="mawscSettings">MAWSC session settings.</param>
        private static void GetFromUrl(string repositoryUrl, string targetFile)
        {
            Du.Internet.DownloadZipFromUrl(repositoryUrl, $"{targetFile}.zip");
        }

        private static void UncompressStagingSource(string targetFile)
        {
            Du.WithArchive.Uncompress($"{targetFile}.zip", $"{targetFile}/");

        }

        private static void CopyTo(string targetFile, string sessionBackupDirectory, string targetDirectory,
                                   string stagingFetchDirectory)
        {
            Du.WithFile.MoveUsingFileName($"{targetFile}.zip", $"{sessionBackupDirectory}");

            Du.WithDirectory.CopyRecursively($"{targetDirectory}/src/", stagingFetchDirectory);
        }

    }
}