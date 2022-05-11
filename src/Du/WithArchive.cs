// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Du.WithArchive.cs
// UPDATED: 220511.104821 (v1.0-ApprenticeWizard)
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with archives.
 */

using System.IO.Compression;

namespace MAWSC.Du
{
    internal class WithArchive
    {
        /// <summary>
        /// Archives a directory.
        /// </summary>
        /// <param name="sourceDirectory">Directory to archive.</param>
        /// <param name="targetDirectory">Directory to create the archive.</param>
        /// <remarks>Creates a timestamped archive file (e.g., "101222-210101.zip"</remarks>
        internal static void DirectoryAsTimestamp(string sourceDirectory, string targetDirectory)
        {
            // Not tested as of 5-10-22

            /* Archived directories will have a name using this format:
             * 
             *      "path/to/archive/MMddyy-HHmmss.zip"
             */

            /* Strip existing trailing slash to make path names clearer later.
             */
            sourceDirectory     = Du.WithDirectory.RemoveTrailingSlash(sourceDirectory);
            targetDirectory     = Du.WithDirectory.RemoveTrailingSlash(targetDirectory);

            var currentDateTime = DateTime.Now.ToString("MMddyy-HHmmss");
            var targetFilePath  = $@"{targetDirectory}/{currentDateTime}.zip";

            ZipFile.CreateFromDirectory($"{sourceDirectory}/", targetFilePath);
        }

        /// <summary>
        /// Archives a directory.
        /// </summary>
        /// <param name="sourceDirectory">Directory to archive.</param>
        /// <param name="targetDirectory">Directory to create the archive.</param>
        internal static void DirectoryAsFullnameTimestamp(string sourceDirectory, string targetDirectory)
        {
            // Not tested as of 5-10-22

            /* Archived directories will have a name using this format:
             * 
             *      "path/to/archive/file/name-of-directory-that-is-archived-MMddyy-HHmmss.zip"
             *      
             * Since the archive filename will be the entire filepath, which in some cases will
             * be long enough to cause issues, so be careful.
             */

            /* Strip existing trailing slash to make path names clearer later.
             */
            sourceDirectory     = Du.WithDirectory.RemoveTrailingSlash(sourceDirectory);
            targetDirectory     = Du.WithDirectory.RemoveTrailingSlash(targetDirectory);

            var archiveFileName = sourceDirectory.Replace("\\","-" );
            var currentDateTime = DateTime.Now.ToString("MMddyy-HHmmss");
            var targetFilePath  = $@"{targetDirectory}/{archiveFileName}-{currentDateTime}.zip";

            ZipFile.CreateFromDirectory($"{sourceDirectory}/", targetFilePath);
        }
    }
}
