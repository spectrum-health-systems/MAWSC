// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Du.WithDirectory.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v1.0-b220510.065025 (ApprenticeWizard)

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with directories.
 */

namespace MAWSC.Du
{
    internal class WithDirectory
    {
        /// <summary>
        /// Remove a trailing dash in a directory path, if it exists.
        /// </summary>
        /// <param name="directoryPath">Directory path to check.</param>
        /// <returns></returns>
        internal static string RemoveTrailingSlash(string directoryPath)
        {
            // Not tested as of 5-10-22

            if(directoryPath.EndsWith("\\"))
            {
                directoryPath = directoryPath.Remove(directoryPath.Length - 1);

            }

            return directoryPath;
        }

        /// <summary>
        /// Verify a directory exists, and optionally create it if it does not.
        /// </summary>
        /// <param name="directoryToConfirm">The directory to confirm the existance of.</param>
        /// <param name="createIfNonexistant">Create the directory if it doesn't exits (true), or do nothing (false)</param>
        /// <returns></returns>
        internal static void ConfirmDirectoryExists(string directoryToConfirm, bool createIfNonexistant = true)
        {
            // Not tested as of 5-10-22

            if(!Directory.Exists(directoryToConfirm))
            {
                if(createIfNonexistant)
                {
                    Directory.CreateDirectory(directoryToConfirm);
                }
            }
        }

        /// <summary>
        /// Recursively copy a directory and it's subdirectories.
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        public static void CopyRecursively(string sourceDirectory, string targetDirectory)
        {
            // Not tested as of 5-10-22

            /* Before we do anything else, let's make sure that the source and target directories exist.
             */
            ConfirmDirectoryExists(sourceDirectory);
            ConfirmDirectoryExists(targetDirectory);

            /* Get information about the directory we are moving, and any sub-directories that exist.
             */
            var directoryToCopy                  = new DirectoryInfo(sourceDirectory);
            DirectoryInfo[] subDirectoriesToCopy = GetSubDirs(sourceDirectory, targetDirectory);

            /* Copy all files in the sourceDir to the targetDir
             */
            foreach(FileInfo file in directoryToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDirectory, file.Name);
                file.CopyTo(targetFilePath);
            }

            /* If there are any sub-directories in sourceDir, copy all of the files in that sub-directory to the
             * targetDir. 
             */
            foreach(DirectoryInfo subDirectory in subDirectoriesToCopy)
            {
                string targetSubDirectory = Path.Combine(targetDirectory, subDirectory.Name);
                CopyRecursively(subDirectory.FullName, targetSubDirectory);
            }
        }

        /// <summary>
        /// Recursively move a directory and it's subdirectories.
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        internal static void MoveRecursively(string sourceDirectory, string targetDirectory)
        {
            // Not tested as of 5-10-22

            /* Before we do anything else, let's make sure that the source and target directories exist.
             */
            ConfirmDirectoryExists(sourceDirectory);
            ConfirmDirectoryExists(targetDirectory);

            /* Get information about the directory we are moving, and any sub-directories that exist.
             */
            var directoryToMove                  = new DirectoryInfo(sourceDirectory);
            DirectoryInfo[] subDirectoriesToMove = GetSubDirs(sourceDirectory, targetDirectory);

            /* Move all files in the source to the target
             */
            foreach(FileInfo file in directoryToMove.GetFiles())
            {
                // TODO put some try...catches in here to catch exeptions.
                string targetFilePath = Path.Combine(targetDirectory, file.Name);
                file.MoveTo(targetFilePath);
            }

            /* If there are any sub-directories in sourceDir, move all of the files in that sub-directory to the
             * targetDir. 
             */
            foreach(DirectoryInfo subDir in subDirectoriesToMove)
            {
                string targetSubDirectory = Path.Combine(targetDirectory, subDir.Name);
                MoveRecursively(subDir.FullName, targetSubDirectory);
            }
        }

        /// <summary>
        /// Get directory information, and make sure sub-directories in sourceDir exist on targetDir.
        /// </summary>
        /// <param name="sourceDirectory">The source directory.</param>
        /// <param name="targetDirectory">The target directory.</param>
        private static DirectoryInfo[] GetSubDirs(string sourceDirectory, string targetDirectory)
        {
            // Not tested as of 5-10-22

            var dir = new DirectoryInfo(sourceDirectory);

            if(!dir.Exists)
            {
                Directory.CreateDirectory(targetDirectory);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }

        /// <summary>
        /// Refresh a directory by deleting it, then creating it.
        /// </summary>
        /// <param name="dirTorefresh">The directory to refresh.</param>
        public static void RefreshRecursively(string sourceDirectory)
        {
            // Not tested as of 5-10-22

            // TODO Probably a better way to do this.
            if(Directory.Exists(sourceDirectory))
            {
                Directory.Delete(sourceDirectory, true);
                Directory.CreateDirectory(sourceDirectory);
            }
        }
    }
}
