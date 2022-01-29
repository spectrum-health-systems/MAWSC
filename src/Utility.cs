// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Utilities.
// bb220129.142505

using System.Reflection;

namespace MAWSC
{
    public class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        public static string MawscStart()
        {
            var ver = Assembly.GetEntryAssembly().GetName().Version;

            var logMsgStart = $"{Environment.NewLine}" +
                              $"================================================================================{Environment.NewLine}" +
                              $"MAWS Commander {ver} started{Environment.NewLine}" +
                              $"================================================================================{Environment.NewLine}";

            Console.WriteLine(logMsgStart);

            return logMsgStart;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void MawscFinish(string logMessage, int exitCode = 1)
        {
            var logMsgFinish = $"{Environment.NewLine}" +
                              $"================================================================================{Environment.NewLine}" +
                              $"MAWS Commander exiting{Environment.NewLine}" +
                              $"================================================================================{Environment.NewLine}";

            Console.WriteLine(logMsgFinish);

            var logContent = $"{logMessage}" +
                             $"{logMsgFinish}";

            Log.WriteToFile(logContent);

            Environment.Exit(exitCode);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CopyDirectory(string sourceDir, string destinationDir)
        {
            ConfirmDirectoryExists(destinationDir);

            var dirToCopy      = new DirectoryInfo(sourceDir);
            var subDirsToCopy = GetRecursiveDirectories(sourceDir, destinationDir);

            foreach(FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            foreach(DirectoryInfo subDirectory in subDirsToCopy)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDirectory.Name);
                CopyDirectory(subDirectory.FullName, newDestinationDir);
            }

        }

        public static void CopyFiles(List<string> filesToCopy, string sourceDir, string destinationDir)
        {
            foreach(var fileToCopy in filesToCopy)
            {
                string targetFilePath = Path.Combine(destinationDir, $"{destinationDir}{fileToCopy}");
                File.Copy($"{sourceDir}{fileToCopy}", targetFilePath);
            }
        }
        //public static void MoveFiles(List<string> filesToMove, string destinationDir, string sourceDir)
        //{
        //    foreach(var fileToMove in filesToMove)
        //    {
        //        File.Copy($"{sourceDir}{fileToMove}", destinationDir);
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        public static void MoveDirectory(string sourceDir, string destinationDir)
        {
            ConfirmDirectoryExists(destinationDir);

            var dirToMove     = new DirectoryInfo(sourceDir);
            var subDirsToMove = GetRecursiveDirectories(sourceDir, destinationDir);

            foreach(FileInfo file in dirToMove.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.MoveTo(targetFilePath);
            }

            foreach(DirectoryInfo subDir in subDirsToMove)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                MoveDirectory(subDir.FullName, newDestinationDir);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo GetDirectoryInfo(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if(!dir.Exists)
            {
                Directory.CreateDirectory(destinationDir);
            }

            return dir;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo[] GetRecursiveDirectories(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if(!dir.Exists)
            {
                Directory.CreateDirectory(destinationDir);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ConfirmDirectoryExists(string directoryToConfirm)
        {
            /* Since we are going to create a directory no matter what, we'll just update the user via the console, and not worry
             * about upating the logMessage here.
             */
            if(!Directory.Exists(directoryToConfirm))
            {
                Directory.CreateDirectory(directoryToConfirm);
            }
        }
    }
}
