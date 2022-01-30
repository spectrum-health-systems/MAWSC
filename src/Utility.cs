// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Common utilities used bt MAWS Commander.
// b20130.101224

namespace MAWSC
{
    public class Utility
    {
        /// <summary>
        /// Things to do when MAWS Commander starts.
        /// </summary>
        public static void MawscStart(ref string logContent)
        {
            Log.StartLogging(ref logContent);
        }

        /// <summary>
        /// Things to do when MAWS Commander exits.
        /// </summary>
        public static void MawscFinish(string logContent, int exitCode)
        {
            Log.EndLogging(logContent, exitCode);
            Environment.Exit(exitCode);
        }

        /// <summary>
        /// Force an argument to be trimmed, lowercase, and remove dashes.
        /// </summary>
        /// <param name="argToReduce">The argument to reduce.</param>
        /// <returns>A nice looking argument (e.g., "--Argument1" -> "argument1")</returns>
        public static string ReduceArg(string argToReduce)
        {
            return argToReduce.Trim().ToLower().Replace("-", "");
        }

        /// <summary>
        /// Copy all files and subdirectories from a source to a destination.
        /// </summary>
        public static void CopyDir(ref string logContent, string sourceDir, string targetDir)
        {
            ConfirmDirExists(ref logContent, sourceDir, false);
            ConfirmDirExists(ref logContent, targetDir, true);

            var dirToCopy     = new DirectoryInfo(sourceDir);
            var subDirsToCopy = GetSubDirs(sourceDir, targetDir);

            foreach(FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                Log.AppendAndShow(ref logContent, "[ CHECK] ", $"test", "VALID");
                file.CopyTo(targetFilePath);
            }

            foreach(DirectoryInfo subDirectory in subDirsToCopy)
            {
                string newDestinationDir = Path.Combine(targetDir, subDirectory.Name);
                CopyDir(ref logContent, subDirectory.FullName, newDestinationDir);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CopyFiles(List<string> filesToCopy, string sourceDir, string targetDir)
        {
            foreach(var fileToCopy in filesToCopy)
            {
                string targetFilePath = Path.Combine(targetDir, $"{targetDir}{fileToCopy}");
                File.Copy($"{sourceDir}{fileToCopy}", targetFilePath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void MoveDir(ref string logContent, string sourceDir, string targetDir)
        {
            ConfirmDirExists(ref logContent, targetDir, true);


            var dirToMove     = new DirectoryInfo(sourceDir);
            var subDirsToMove = GetSubDirs(sourceDir, targetDir);

            foreach(FileInfo file in dirToMove.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                file.MoveTo(targetFilePath);
            }

            foreach(DirectoryInfo subDir in subDirsToMove)
            {
                string newDestinationDir = Path.Combine(targetDir, subDir.Name);
                MoveDir(ref logContent, subDir.FullName, newDestinationDir);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo GetDirInfo(string sourceDir, string targetDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if(!dir.Exists)
            {
                Directory.CreateDirectory(targetDir);
            }

            return dir;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if(!dir.Exists)
            {
                Directory.CreateDirectory(targetDir);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ConfirmDirExists(ref string logContent, string dirToConfirm, bool createIfNonexistant)
        {
            if(!Directory.Exists(dirToConfirm))
            {
                if(createIfNonexistant)
                {
                    Directory.CreateDirectory(dirToConfirm);
                }
                else
                {
                    Log.AppendAndShow(ref logContent, "[ ERROR] ", $"{dirToConfirm} does not exist.", "INVALID");
                    Utility.MawscFinish(logContent, 1);
                }
            }
        }

        public static void RefreshDir(ref string logContent, string dirToRefresh)
        {
            if(Directory.Exists(dirToRefresh))
            {
                Directory.Delete(dirToRefresh, true);
                Directory.CreateDirectory(dirToRefresh);
            }

        }


    }
}
