// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Du.WithFile.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v1.0-b220510.065025 (ApprenticeWizard)

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with files.
 */

namespace MAWSC.Du
{
    internal class WithFile
    {
        /// <summary>
        /// Converts a file to a string[].
        /// </summary>
        /// <param name="filePath">The filePath to convert.</param>
        /// <param name="delimiter">The delimter used to seperate lines.</param>
        /// <returns></returns>
        public static string[] ToStringArray(string filePath, char delimiter)
        {
            // Not tested as of 5-10-22

            var fileContent = File.ReadAllText(filePath);

            return fileContent.Split(delimiter);
        }

        /// <summary>
        /// Move a file from a source directory to a target directory.
        /// </summary>
        /// <param name="sourcePath">The source path</param>
        /// <param name="targetPath">The target path</param>
        public static void MoveUsingFileName(string sourcePath, string targetPath)
        {
            // Not tested as of 5-10-22

            var sourceNameAndExtension = Path.GetFileName(sourcePath);

            File.Move(sourcePath, $@"{targetPath}{sourceNameAndExtension}");
        }

        /// <summary>
        /// Copy files.
        /// </summary>
        /// <param name="filesToCopy">The files to copy.</param>
        /// <param name="sourceDir">The source directory.</param>
        /// <param name="targetDir">The target directory.</param>
        public static void CopyFiles(List<string> filesToCopy, string sourceDirectory, string targetDirectory)
        {
            // Not tested as of 5-10-22

            foreach(var fileToCopy in filesToCopy)
            {
                string targetFilePath = Path.Combine(targetDirectory, $"{targetDirectory}{fileToCopy}");
                File.Copy($"{sourceDirectory}{fileToCopy}", targetFilePath);
            }
        }
    }
}