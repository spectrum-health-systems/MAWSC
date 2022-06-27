// =============================================================================
// DU
// A library for .NET C#
// https://github.com/aprettycoolprogram/du)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// =============================================================================

// Du.WithFile.cs
// Does things with files.
// vX.X.X.X-b220526.091354 (standalone version for MAWSC 2.0)

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
        internal static string[] ToStringArray(string filePath, char delimiter)
        {
            // Not tested as of 5-10-22

            var fileContent = File.ReadAllText(filePath);

            return fileContent.Split(delimiter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textToAppend"></param>
        /// <param name="filePath"></param>
        internal static void AppendText(string textToAppend, string filePath)
        {
            if(!File.Exists(filePath))
            {
                using(StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(textToAppend);
                }
            }
            else
            {
                using(StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(textToAppend);
                }
            }
        }

        /// <summary>
        /// Move a file from a source directory to a target directory.
        /// </summary>
        /// <param name="sourcePath">The source path</param>
        /// <param name="targetPath">The target path</param>
        internal static void MoveUsingFileName(string sourcePath, string targetPath)
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
        internal static void CopyFiles(List<string> filesToCopy, string sourceDirectory, string targetDirectory)
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