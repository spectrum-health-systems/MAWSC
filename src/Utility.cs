// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Utilities.
// b220126.170648


namespace MAWSC
{
    public class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        public static string MawscStart()
        {
            var logMsgStart = $"[MAWSC] Started...{Environment.NewLine}";
            Console.WriteLine(logMsgStart);

            return logMsgStart;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void MawscFinish(string logMessage)
        {
            var logMsgFinish = $"[MAWSC] Exiting...";
            Console.WriteLine(logMsgFinish);

            var logContent = $"{logMessage}" +
                             $"{logMsgFinish}";

            Log.WriteToFile(logContent);

            Environment.Exit(1);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CopyDirectory(string sourceDir, string destinationDir)
        {
            var directoryToCopy      = new DirectoryInfo(sourceDir);
            var subDirectoriesToCopy = GetRecursiveDirectories(sourceDir, destinationDir);

            Log.ToScreen($"[ INFO] Working with directory: {directoryToCopy}...{Environment.NewLine}");

            foreach(FileInfo file in directoryToCopy.GetFiles())
            {
                Log.ToScreen($"  -> Copying file: {directoryToCopy}...");
                var targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
                Log.ToScreen($"COPIED.{Environment.NewLine}");
            }

            foreach(DirectoryInfo subDirectory in subDirectoriesToCopy)
            {
                var newDestinationDir = Path.Combine(destinationDir, subDirectory.Name);
                CopyDirectory(subDirectory.FullName, newDestinationDir);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public static void MoveDirectory(string sourceDir, string destinationDir)
        {
            ConfirmDirectoryExists(destinationDir);

            var dir  = new DirectoryInfo(sourceDir);
            var dirs = GetRecursiveDirectories(sourceDir, destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach(FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.MoveTo(targetFilePath);
            }

            foreach(DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                MoveDirectory(subDir.FullName, newDestinationDir);
            }
            var breaker=0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo GetDirectoryInfo(string sourceDir, string destinationDir)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists, and create it if it does not.
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
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists, and create it if it does not.
            if(!dir.Exists)
            {
                Directory.CreateDirectory(destinationDir);
            }

            // Cache directories before we start copying
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
                Log.ToScreen($"[ INFO] Creating directory: {directoryToConfirm}...");
                Directory.CreateDirectory(directoryToConfirm);
                Log.ToScreen($"CREATED.{Environment.NewLine}");
            }
        }
    }
}
