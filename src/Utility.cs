// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// Common utilities used bt MAWS Commander.
// b220131.115810

namespace MAWSC
{
    internal class Utility
    {
        /// <summary>
        /// Things to do when MAWS Commander starts.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        public static void MawscStart(ref string logContent)
        {
            Log.GenerateLogContentIntro(ref logContent);
        }

        /// <summary>
        /// Things to do when MAWS Commander exits.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="exitCode">"0" for no errors, "1" for errors.</param>
        public static void MawscFinish(string logContent, int exitCode)
        {
            /* Since this is the last thing MAWS Commander does, we don't pass logContent as a reference. Also, if you
             * pass anything other than a "0" (no errors) for exitCode, the "Type MAWSC -help" stuff will be included
             * in logContent and displayed on the console.
             */
            Log.GenerateLogContentIntro(logContent, exitCode);
            Environment.Exit(exitCode);
        }

        /// <summary>
        /// Force an argument to be trimmed, lowercase, and remove dashes.
        /// </summary>
        /// <param name="argToReduce">The argument to reduce.</param>
        /// <returns>A nice looking argument (e.g., "--Argument1" -> "argument1")</returns>
        public static string ReduceArg(string argToReduce)
        {
            /* Users can pass an argument as "argument", "-ARGUMENT", "--ArGuMeNt", or whatever combination of cases and
             * leading hyphens, and they will all be converted to "argument".
             */
            return argToReduce.Trim().ToLower().Replace("-", "");
        }

        /// <summary>
        /// Recursively move a directory.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="sourceDir">The directory to move from.</param>
        /// <param name="targetDir">The directory to move to.</param>
        /// <remarks>Directories/sub-directories are always moved recursively.</remarks>
        public static void MoveDir(ref string logContent, string sourceDir, string targetDir)
        {
            /* Before we do anything else, let's make sure that the source and target directories exist.
             */
            ConfirmDirExists(ref logContent, sourceDir, false);
            ConfirmDirExists(ref logContent, targetDir, true);

            /* Get information about the directory we are moving, and any sub-directories that exist.
             */
            var dirToMove                  = new DirectoryInfo(sourceDir);
            DirectoryInfo[]? subDirsToMove = GetSubDirs(sourceDir, targetDir);

            /* Move all files in the sourceDir to the targetDir
             */
            foreach(FileInfo file in dirToMove.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                Log.AppendAndShowMsg(ref logContent, "[ MOVE] ", $"{file}", "MOVING");
                file.MoveTo(targetFilePath);
                Log.AppendAndShowMsg(ref logContent, "[ MOVE] ", $"{file}", "MOVED");
            }

            /* If there are any sub-directories in sourceDir, move all of the files in that sub-directory to the
             * targetDir. 
             */
            foreach(DirectoryInfo subDir in subDirsToMove)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
                MoveDir(ref logContent, subDir.FullName, newTargetDir);
            }
        }

        /// <summary>
        /// Recursively copy a directory.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="sourceDir">The directory to copy from.</param>
        /// <param name="targetDir">The directory to copy to.</param>
        /// <remarks>Directories/sub-directories are always copied recursively.</remarks>
        public static void CopyDir(ref string logContent, string sourceDir, string targetDir)
        {
            /* Before we do anything else, let's make sure that the source and target directories exist.
             */
            ConfirmDirExists(ref logContent, sourceDir, false);
            ConfirmDirExists(ref logContent, targetDir, true);

            /* Get information about the directory we are moving, and any sub-directories that exist.
             */
            var dirToCopy                  = new DirectoryInfo(sourceDir);
            DirectoryInfo[]? subDirsToCopy = GetSubDirs(sourceDir, targetDir);

            /* Copy all files in the sourceDir to the targetDir
             */
            foreach(FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                Log.AppendAndShowMsg(ref logContent, "[ COPY] ", $"{file}", "COPYING");
                file.CopyTo(targetFilePath);
                Log.AppendAndShowMsg(ref logContent, "[ COPY] ", $"{file}", "COPIED");
            }

            /* If there are any sub-directories in sourceDir, copy all of the files in that sub-directory to the
             * targetDir. 
             */
            foreach(DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
                CopyDir(ref logContent, subDir.FullName, newTargetDir);
            }
        }

        /// <summary>
        /// Verify a directory exists, and optionally create it if it does not.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="dirToConfirm">The directory to confirm the existance of.</param>
        /// <param name="createIfNonexistant">Create the directory if it doesn't exits (true), or do nothing (false)</param>
        public static void ConfirmDirExists(ref string logContent, string dirToConfirm, bool createIfNonexistant)
        {
            /* Any directory that needs to be confirmed is required for MAWS Commander to function properly, so if the
             * directory doesn't exist, one of two things will happen:
             * 
             *  1. if "createIfNonexistant" is true, the directory will be created.
             *  2. if "createIfNonexistant" is false, MAWS Commander will exit.
             */
            if(!Directory.Exists(dirToConfirm))
            {
                if(createIfNonexistant)
                {
                    Directory.CreateDirectory(dirToConfirm);
                }
                else
                {
                    Log.AppendAndShowMsg(ref logContent, "[ ERROR] ", $"{dirToConfirm} does not exist.", "INVALID");
                    Utility.MawscFinish(logContent, 1);
                }
            }
        }

        /// <summary>
        /// Refresh a directory by deleting it, then creating it.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="dirTorefresh">The directory to refresh.</param>
        public static void RefreshDir(ref string logContent, string dirToRefresh)
        {
            // TODO Probably a better way to do this.
            Log.AppendAndShowMsg(ref logContent, "[REFRESH] ", "Refreshing {dirToRefresh}", "REFRESHING");
            if(Directory.Exists(dirToRefresh))
            {
                Directory.Delete(dirToRefresh, true);
                Directory.CreateDirectory(dirToRefresh);
            }
            Log.AppendAndShowMsg(ref logContent, "[REFRESH] ", "{dirToRefresh} refreshed", "REFRESED");
        }

        /// <summary>
        /// Copy files.
        /// </summary>
        /// <param name="filesToCopy">The files to copy.</param>
        /// <param name="sourceDir">The source directory.</param>
        /// <param name="targetDir">The target directory.</param>
        public static void CopyFiles(List<string> filesToCopy, string sourceDir, string targetDir)
        {
            foreach(var fileToCopy in filesToCopy)
            {
                string targetFilePath = Path.Combine(targetDir, $"{targetDir}{fileToCopy}");
                File.Copy($"{sourceDir}{fileToCopy}", targetFilePath);
            }
        }

        /// <summary>
        /// Get directory information, and make sure sub-directories in sourceDir exist on targetDir.
        /// </summary>
        /// <param name="sourceDir">The source directory.</param>
        /// <param name="targetDir">The target directory.</param>
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
    }
}
