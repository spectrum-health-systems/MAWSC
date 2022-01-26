// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Staging environment.
// b220126.165109

namespace MAWSC
{
    public class Staging
    {
        /// <summary>
        /// Parse the passed arguments for Staging processes.
        /// </summary>
        public static void ParseArguments(string[] args, string logMessage)
        {
            /* There has to be at least one Staging argument passed, otherwise just exit.
             */
            if(args.Length == 1)
            {
                Log.ToScreen($"[ERROR] Not enough arguments passed (arg[1] does not exist).");
                logMessage += $"[ERROR] Not enough arguments passed (arg[1] does not exist).";
                Log.ToFile(logMessage);
                Environment.Exit(1);
            }

            /* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
             */
            var secondArgument = args[1].Trim().ToLower().Replace("-", "");

            //////Log.ToScreen("[ INFO] Argument \"{args[0]}\" (arg[0]) is valid...continuing...");
            //////logMessage += $"[ INFO] Argument \"{args[0]}\" (arg[0]) is valid...{Environment.NewLine}";

            switch(secondArgument)
            {
                case "d":
                case "dep":
                case "deploy":
                    Log.ToScreen($"[ INFO] Argument \"{args[1]}\" (arg[1]) is valid...continuing...");
                    logMessage += $"[ INFO] Argument \"{args[1]}\" (arg[1]) is valid...{Environment.NewLine}";
                    Deploy(logMessage);
                    break;

                default:
                    Log.ToScreen($"[ERROR] Invalid Arg1: \"{args[1]}\"/\"{secondArgument}\".");
                    logMessage += "[ERROR] Invalid Arg1: \"{args[1]}\"/\"{secondArgument}\".";
                    Log.ToFile(logMessage);
                    Environment.Exit(1);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Deploy(string logMessage)
        {
            var currentDateTime = DateTime.Now.ToString("yyMMddHHmmss");
            var currentBackupDirectory = $@"C:\MyAvatool\MAWS\Staging\Backup\{currentDateTime}";

            logMessage = VerifyRequiredDirectories(logMessage, currentBackupDirectory);

            logMessage = BackupStaging(logMessage, currentBackupDirectory);

            logMessage = CopyStagingToIis(logMessage);


            Log.ToFile(logMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string VerifyRequiredDirectories(string logMessage, string currentBackupDirectory)
        {
            if(IisStagingDirectoryExists(logMessage))
            {
                logMessage += $"Verifying IIS Staging directory...FOUND.{Environment.NewLine}";
            }

            if(ConfirmDirectoryExists($@"{currentBackupDirectory}"))
            {
                logMessage += $"Verifying Staging backup directory...FOUND.{Environment.NewLine}";
            }
            else
            {
                logMessage += $"Verifying Staging backup directory...not found...CREATED.{Environment.NewLine}";
            }

            return logMessage;
        }

        private static string CopyStagingToIis(string logMessage)
        {
            logMessage += $"Copying Staging data to IIS directory...";

            var sourceDir = $@"C:\MyAvatool\MAWS\Staging\src\";
            var destintationDir = $@"C:\AvatoolWebService\MAWS_Staging\";

            MoveDirectory(sourceDir, destintationDir, true);
            logMessage += $"COMPLETE.{Environment.NewLine}";

            return logMessage;
        }




        private static string BackupStaging(string logMessage, string currentBackupDirectory)
        {
            logMessage += $"Backing up IIS Staging directory...";

            var sourceDir = $@"C:\AvatoolWebService\MAWS_Staging\";
            var destintationDir = $@"{currentBackupDirectory}";

            MoveDirectory(sourceDir, destintationDir, true);
            logMessage += $"COMPLETE.{Environment.NewLine}";

            logMessage += $"Removing IIS Staging directory...";
            Directory.Delete($@"C:\AvatoolWebService\MAWS_Staging\", true);
            logMessage += $"COMPLETE.{Environment.NewLine}";

            ConfirmDirectoryExists($@"C:\AvatoolWebService\MAWS_Staging\");

            return logMessage;
        }


        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive = true)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if(!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach(FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if(recursive)
            {
                foreach(DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        static void MoveDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if(!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach(FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.MoveTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if(recursive)
            {
                foreach(DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    MoveDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }


        private static bool IisStagingDirectoryExists(string logMessage)
        {
            var stagingBackupDirectory = $@"C:\AvatoolWebService\MAWS_Staging\";

            if(!Directory.Exists(stagingBackupDirectory))
            {
                logMessage += $"Verifying IIS Staging directory...not found...FATAL ERROR.{Environment.NewLine}Exiting MAWSC...";
                Log.ToFile(logMessage);
                Environment.Exit(1);
            }

            return true;
        }

        private static bool ConfirmDirectoryExists(string directoryToConfirm)
        {
            var directoryAlreadyExists = true;

            if(!Directory.Exists(directoryToConfirm))
            {
                Directory.CreateDirectory(directoryToConfirm);
                directoryAlreadyExists = false;
            }

            return directoryAlreadyExists;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private static bool DirectoryExists(string directoryToVerify)
        {
            return Directory.Exists(directoryToVerify);
        }
    }
}
