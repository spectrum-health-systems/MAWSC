// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.FetchStaging.cs
// Fetch the staging source from a repository.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md

using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class FetchStaging
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>  
        /// <param name="mawsc"></param>
        internal static void SoupToNuts(ConfigurationSettings mawsc)
        {
            BackupStaging.SoupToNuts(mawsc);
            CleanStaging.FetchLocation(mawsc);

            var targetFile = $"{mawsc.TemporaryDirectory}{mawsc.RepositoryBranch}"; // config

            GetFromUrl(mawsc.RepositoryZipUrl, targetFile);
            UncompressStagingSource(targetFile);

            var sessionBackupDirectory = $"{mawsc.BackupDirectory}{mawsc.SessionTimestamp}/";
            var targetDirectory = $"{targetFile}/{mawsc.RepositoryName}-{mawsc.RepositoryBranch}";

            CopyTo(targetFile, sessionBackupDirectory, targetDirectory, mawsc.StagingFetchDirectory);
        }

        /// <summary>Fetch staging sourcecode from a URL.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <param name="mawscSettings">MAWSC session settings.</param>
        private static void GetFromUrl(string repositoryUrl, string targetFile)
        {
            Du.Internet.DownloadZipFromUrl(repositoryUrl, $"{targetFile}.zip");
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <param name="targetFile"></param>
        private static void UncompressStagingSource(string targetFile)
        {
            Du.WithArchive.Uncompress($"{targetFile}.zip", $"{targetFile}/");
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <param name="targetFile"></param>
        /// <param name="sessionBackupDirectory"></param>
        /// <param name="targetDirectory"></param>
        /// <param name="stagingFetchDirectory"></param>
        private static void CopyTo(string targetFile, string sessionBackupDirectory, string targetDirectory,
                                   string stagingFetchDirectory)
        {
            Du.WithFile.MoveUsingFileName($"{targetFile}.zip", $"{sessionBackupDirectory}");

            Du.WithDirectory.CopyRecursively($"{targetDirectory}/src/", stagingFetchDirectory);
        }

    }
}