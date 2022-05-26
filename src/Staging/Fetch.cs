﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.Fetch.cs
// Get the staging source from a repository.
// b220526.080326

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
