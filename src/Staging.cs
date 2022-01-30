// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Staging environment.
// bb220129.142505

namespace MAWSC
{
    public class Staging
    {
        /*
         */
        const string BackupDirectoryRoot   = $@"C:\MyAvatool\MAWS\Staging\Backup";
        const string IisStagingDirectory   = $@"C:\AvatoolWebService\MAWS_Staging\";
        const string GitHubStagingSource   = $@"C:\MyAvatool\MAWS\Staging\src\";
        const string AvatoolTemporaryFiles = $@"C:\MyAvatool\Temp\";

        /// <summary>
        /// Parse the passed arguments for Staging processes.
        /// </summary>
        public static void ParseArguments(string[] args, string logMessage)
        {
            var mawscCommand ="";
            var mawscAction  ="";

            /* There has to be at least one Staging argument passed, otherwise just exit.
             */
            if(args.Length == 1)
            {
                logMessage = Log.AppendAndShow(logMessage, "[ ERROR] ", $"Not enough arguments passed (Arg[1] does not exist)", "INVALID");
                Utility.MawscFinish(logMessage, 1);
            }
            else
            {
                mawscCommand = args[1].Trim().ToLower().Replace("-", "");

                if(args.Length == 3)
                {
                    mawscAction = args[2].Trim().ToLower().Replace("-", "");
                }
            }

            /* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
             */
            //var secondArgument = args[1].Trim().ToLower().Replace("-", "");

            switch(mawscCommand)
            {
                case "d":
                case "dep":
                case "deploy":
                    logMessage = Log.AppendAndShow(logMessage, "[ CHECK] ", $"Arg[1] \"{args[1]}\"", "VALID");
                    Deploy(logMessage, mawscAction);
                    break;

                default:
                    logMessage = Log.AppendAndShow(logMessage, "[ ERROR] ", $"Arg[1] \"{args[1]}\"", "INVALID");
                    Utility.MawscFinish(logMessage, 1);
                    break;
            }
        }

        /// <summary>
        /// Deploy a new version of MAWS to the IIS Staging environment.
        /// </summary>
        private static void Deploy(string logMessage, string mawscAction)
        {
            var backupDestination   = GetBackupDirectory(ref logMessage);
            var IisStagingDirectory = GetStagingIisDirectory(ref logMessage);

            if(mawscAction == "minimal")
            {
            }

            BackupIisStaging(ref logMessage, backupDestination, IisStagingDirectory);

            if(mawscAction == "minimal")
            {
                logMessage = Log.AppendAndShow(logMessage, "[  INFO] ", "Performing a minimal delete of the current the IIS Staging environment", "< INFO");
                MinimalDeleteIisStagingDirectory(ref logMessage, IisStagingDirectory);
            }
            else
            {
                logMessage = Log.AppendAndShow(logMessage, "[  INFO] ", "Performing a complete delete of the current IIS Staging environment", "< INFO");
                DeleteIisStagingDirectory(ref logMessage, IisStagingDirectory);
            }




            CreateIisStagingDirectory(ref logMessage, IisStagingDirectory);

            if(mawscAction == "full")
            {
                logMessage = Log.AppendAndShow(logMessage, "[  INFO] ", "Performing a full copy of the IIS Staging environment", "< INFO");
                FullCopyGitHubSourceToIisStaging(ref logMessage, IisStagingDirectory);
            }
            else if(mawscAction == "minimal")
            {
                logMessage = Log.AppendAndShow(logMessage, "[  INFO] ", "Performing a minimal copy of the IIS Staging environment", "< INFO");
                MinimalCopyGitHubSourceToIisStaging(ref logMessage, IisStagingDirectory);
            }
            else
            {
                logMessage = Log.AppendAndShow(logMessage, "[  INFO] ", "Performing a standard copy of the IIS Staging environment", "< INFO");
                StandardCopyGitHubSourceToIisStaging(ref logMessage, IisStagingDirectory);
            }


            logMessage += $"{Environment.NewLine}" +
                          $"Deployment to staging complete!{Environment.NewLine}";
        }

        /// <summary>
        /// Create the backup directory.
        /// </summary>
        /// <returns></returns>
        private static string GetBackupDirectory(ref string logMessage)
        {
            var currentDateTime = DateTime.Now.ToString("yyMMddHHmmss");
            var backupDirectory = $@"{BackupDirectoryRoot}\{currentDateTime}";

            logMessage = Log.AppendAndShow(logMessage, "[CREATE] ", $"{backupDirectory}\\", "<- CREATING");
            Utility.ConfirmDirectoryExists(backupDirectory);
            logMessage = Log.AppendAndShow(logMessage, "[CREATE] ", $"{backupDirectory}\\", "CREATED");

            return backupDirectory;
        }

        /// <summary>
        /// Get the IIS Staging directory, or exit if it doesn't exist.
        /// </summary>
        /// <returns></returns>
        private static string GetStagingIisDirectory(ref string logMessage)
        {
            //var stagingIisDirectory = $@"C:\AvatoolWebService\MAWS_Staging\";

            logMessage = Log.AppendAndShow(logMessage, "[ CHECK] ", $"{IisStagingDirectory}", "<- VERIFY");
            if(!Directory.Exists(IisStagingDirectory))
            {
                logMessage = Log.AppendAndShow(logMessage, "[  ERROR] ", $"{IisStagingDirectory}", "DOES NOT EXIST");
                Utility.MawscFinish(logMessage, 1);
            }
            logMessage = Log.AppendAndShow(logMessage, "[ CHECK] ", $"{IisStagingDirectory}", "VALID");

            return IisStagingDirectory;
        }

        /// <summary>
        /// Backup the current Staging IIS directory.
        /// </summary>
        /// <returns></returns>
        private static void BackupIisStaging(ref string logMessage, string backupDestination, string IisStagingDirectory)
        {
            logMessage = Log.AppendAndShow(logMessage, "[BACKUP] ", $"{IisStagingDirectory}", "<- SOURCE");
            logMessage = Log.AppendAndShow(logMessage, "[BACKUP] ", $"{backupDestination}", "<- DESITNATION");
            Utility.MoveDirectory(IisStagingDirectory, backupDestination);
            logMessage = Log.AppendAndShow(logMessage, "[BACKUP] ", $"Backing up Staging environment", "BACKUP COMPLETE");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DeleteIisStagingDirectory(ref string logMessage, string IisStagingDirectory)
        {
            logMessage = Log.AppendAndShow(logMessage, "[DELETE] ", $"{IisStagingDirectory}", "<- DELETING");
            Directory.Delete(IisStagingDirectory, true);
            logMessage = Log.AppendAndShow(logMessage, "[DELETE] ", $"{IisStagingDirectory}", "DELETED");
        }

        private static void MoveRequiredFiles(ref string logMessage, string IisStagingDirectory)
        {
            var filesToKeep = new List<string>
            {
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            Utility.CopyFiles(filesToKeep, IisStagingDirectory, AvatoolTemporaryFiles);
        }


        private static void MinimalDeleteIisStagingDirectory(ref string logMessage, string IisStagingDirectory)
        {
            var filesToKeep = new List<string>
            {
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            logMessage = Log.AppendAndShow(logMessage, "[DELETE] ", $"{IisStagingDirectory}", "<- DELETING");
            Utility.CopyFiles(filesToKeep, IisStagingDirectory, AvatoolTemporaryFiles);
            Directory.Delete(IisStagingDirectory, true);
            logMessage = Log.AppendAndShow(logMessage, "[DELETE] ", $"{IisStagingDirectory}", "DELETED");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateIisStagingDirectory(ref string logMessage, string IisStagingDirectory)
        {
            logMessage = Log.AppendAndShow(logMessage, "[CREATE] ", $"{IisStagingDirectory}", "<- CREATING");
            Utility.ConfirmDirectoryExists(IisStagingDirectory);
            logMessage = Log.AppendAndShow(logMessage, "[CREATE] ", $"{IisStagingDirectory}", "CREATED");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void FullCopyGitHubSourceToIisStaging(ref string logMessage, string IisStagingDirectory)
        {
            //var stagingGitHubSrc = $@"C:\MyAvatool\MAWS\Staging\src\";
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"{IisStagingDirectory}", "<- DESTINATION");
            Utility.CopyDirectory(GitHubStagingSource, IisStagingDirectory);
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");

        }

        private static void MinimalCopyGitHubSourceToIisStaging(ref string logMessage, string IisStagingDirectory)
        {
            var directoriesToCopy = new List<string>
            {
                "bin"
            };

            var filesToCopy = new List<string>
            {
                "MAWS.asmx",
                "MAWS.asmx.cs",
            };

            var filesToMove = new List<string>
            {
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"{IisStagingDirectory}", "<- DESTINATION");

            foreach(var directoryToCopy in directoriesToCopy)
            {
                Utility.CopyDirectory($"{GitHubStagingSource}{directoryToCopy}", $"{IisStagingDirectory}{directoryToCopy}");
            }

            Utility.CopyFiles(filesToCopy, $"{GitHubStagingSource}", $"{IisStagingDirectory}");
            Utility.CopyFiles(filesToMove, $"{AvatoolTemporaryFiles}", $"{IisStagingDirectory}");
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");
        }

        private static void StandardCopyGitHubSourceToIisStaging(ref string logMessage, string IisStagingDirectory)
        {
            var directoriesToCopy = new List<string>
            {
                "bin"
            };

            var filesToCopy = new List<string>
            {
                "MAWS.asmx",
                "MAWS.asmx.cs",
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"{IisStagingDirectory}", "<- DESTINATION");

            foreach(var directoryToCopy in directoriesToCopy)
            {
                Utility.CopyDirectory($"{GitHubStagingSource}{directoryToCopy}", $"{IisStagingDirectory}{directoryToCopy}");
            }

            Utility.CopyFiles(filesToCopy, $"{GitHubStagingSource}", $"{IisStagingDirectory}");

            //Utility.CopyDirectory(GitHubStagingSource, IisStagingDirectory);
            logMessage = Log.AppendAndShow(logMessage, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");
        }
    }
}