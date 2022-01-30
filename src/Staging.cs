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
        const string BackupRoot          = $@"C:\MyAvatool\MAWS\Staging\Backup";
        const string IisStagingDir       = $@"C:\AvatoolWebService\MAWS_Staging\";
        const string GitHubStagingSource = $@"C:\MyAvatool\MAWS\Staging\src\";
        const string AvatoolTempDir      = $@"C:\MyAvatool\Temp\";

        /// <summary>
        /// Parse the passed arguments for Staging processes.
        /// </summary>
        public static void ParseArgs(ref string logContent, string[] passedArgs)
        {
            var mawscCommand ="";
            var mawscAction  ="";

            /* There has to be at least one Staging argument passed, otherwise just exit.
             */
            if(passedArgs.Length == 1)
            {
                Log.AppendAndShow(ref logContent, "[ ERROR] ", $"Not enough arguments passed (Arg[1] does not exist)", "INVALID");
                Utility.MawscFinish(logContent, 1);
            }
            else
            {
                mawscCommand = Utility.ReduceArg(passedArgs[1]);

                if(passedArgs.Length == 3)
                {
                    mawscAction = Utility.ReduceArg(passedArgs[2]);
                }
            }

            switch(mawscCommand)
            {
                case "d":
                case "dep":
                case "deploy":
                    Log.AppendAndShow(ref logContent, "[ CHECK] ", $"Arg[1] \"{passedArgs[1]}\"", "VALID");
                    Deploy(ref logContent, mawscAction);
                    break;

                default:
                    Log.AppendAndShow(ref logContent, "[ ERROR] ", $"Arg[1] \"{passedArgs[1]}\"", "INVALID");
                    Utility.MawscFinish(logContent, 1);
                    break;
            }
        }

        /// <summary>
        /// Deploy a new version of MAWS to the IIS Staging environment.
        /// </summary>
        private static void Deploy(ref string logContent, string mawscAction)
        {
            var backupDestination   = GetBackupDirectory(ref logContent);
            var IisStagingDirectory = GetStagingIisDirectory(ref logContent);

            //////if(mawscAction == "minimal")
            //////{
            //////    Utility.RefreshDir(ref logContent, $"{AvatoolTemporaryFiles}");
            //////    CopyRequiredFiles(ref logContent, IisStagingDirectory);
            //////}

            BackupIisStaging(ref logContent, backupDestination, IisStagingDirectory);

            //////if(mawscAction == "minimal")
            //////{
            //////    Log.AppendAndShow(ref logContent, "[  INFO] ", "Performing a minimal delete of the current the IIS Staging environment", "< INFO");
            //////    MinimalDeleteIisStagingDirectory(ref logContent, IisStagingDirectory);
            //////}
            //////else
            //////{
            Log.AppendAndShow(ref logContent, "[  INFO] ", "Performing a complete delete of the current IIS Staging environment", "< INFO");
            ////DeleteIisStagingDir(ref logContent, IisStagingDirectory);
            //////}




            ////CreateIisStagingDirectory(ref logContent, IisStagingDirectory);

            Utility.RefreshDir(ref logContent, IisStagingDirectory);

            if(mawscAction == "full")
            {
                Log.AppendAndShow(ref logContent, "[  INFO] ", "Performing a full copy of the IIS Staging environment", "< INFO");
                FullCopyGitHubSourceToIisStaging(ref logContent, IisStagingDirectory);
            }
            else if(mawscAction == "minimal")
            {
                Log.AppendAndShow(ref logContent, "[  INFO] ", "Performing a minimal copy of the IIS Staging environment", "< INFO");
                MinimalCopyGitHubSourceToIisStaging(ref logContent, IisStagingDirectory);
            }
            else
            {
                Log.AppendAndShow(ref logContent, "[  INFO] ", "Performing a standard copy of the IIS Staging environment", "< INFO");
                StandardCopyGitHubSourceToIisStaging(ref logContent, IisStagingDirectory);
            }


            logContent += $"{Environment.NewLine}" +
                          $"Deployment to staging complete!{Environment.NewLine}";
        }

        /// <summary>
        /// Create the backup directory.
        /// </summary>
        /// <returns></returns>
        private static string GetBackupDirectory(ref string logContent)
        {
            var currentDateTime = DateTime.Now.ToString("yyMMddHHmmss");
            var backupDirectory = $@"{BackupRoot}\{currentDateTime}";

            Log.AppendAndShow(ref logContent, "[CREATE] ", $"{backupDirectory}\\", "<- CREATING");
            Utility.ConfirmDirExists(ref logContent, backupDirectory, true);
            Log.AppendAndShow(ref logContent, "[CREATE] ", $"{backupDirectory}\\", "CREATED");

            return backupDirectory;
        }

        /// <summary>
        /// Get the IIS Staging directory, or exit if it doesn't exist.
        /// </summary>
        /// <returns></returns>
        private static string GetStagingIisDirectory(ref string logContent)
        {
            //var stagingIisDirectory = $@"C:\AvatoolWebService\MAWS_Staging\";

            Log.AppendAndShow(ref logContent, "[ CHECK] ", $"{IisStagingDir}", "<- VERIFY");
            if(!Directory.Exists(IisStagingDir))
            {
                Log.AppendAndShow(ref logContent, "[  ERROR] ", $"{IisStagingDir}", "DOES NOT EXIST");
                Utility.MawscFinish(logContent, 1);
            }
            Log.AppendAndShow(ref logContent, "[ CHECK] ", $"{IisStagingDir}", "VALID");

            return IisStagingDir;
        }

        /// <summary>
        /// Backup the current Staging IIS directory.
        /// </summary>
        /// <returns></returns>
        private static void BackupIisStaging(ref string logContent, string backupDestination, string IisStagingDirectory)
        {
            Log.AppendAndShow(ref logContent, "[BACKUP] ", $"{IisStagingDirectory}", "<- SOURCE");
            Log.AppendAndShow(ref logContent, "[BACKUP] ", $"{backupDestination}", "<- DESITNATION");
            Utility.MoveDir(ref logContent, IisStagingDirectory, backupDestination);
            Log.AppendAndShow(ref logContent, "[BACKUP] ", $"Backing up Staging environment", "BACKUP COMPLETE");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DeleteIisStagingDir(ref string logContent, string IisStagingDir)
        {
            Log.AppendAndShow(ref logContent, "[DELETE] ", $"{IisStagingDir}", "<- DELETING");
            Directory.Delete(IisStagingDir, true);
            Log.AppendAndShow(ref logContent, "[DELETE] ", $"{IisStagingDir}", "DELETED");
        }

        private static void CopyRequiredFiles(ref string logMessage, string IisStagingDirectory)
        {
            var filesToKeep = new List<string>
            {
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            Utility.CopyFiles(filesToKeep, IisStagingDirectory, AvatoolTempDir);
        }


        private static void MinimalDeleteIisStagingDirectory(ref string logContent, string IisStagingDir)
        {
            var filesToKeep = new List<string>
            {
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            Log.AppendAndShow(ref logContent, "[DELETE] ", $"{IisStagingDir}", "<- DELETING");
            Utility.CopyFiles(filesToKeep, IisStagingDir, AvatoolTempDir);
            Directory.Delete(IisStagingDir, true);
            Log.AppendAndShow(ref logContent, "[DELETE] ", $"{IisStagingDir}", "DELETED");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateIisStagingDirectory(ref string logContent, string IisStagingDir)
        {
            Log.AppendAndShow(ref logContent, "[CREATE] ", $"{IisStagingDir}", "<- CREATING");
            Utility.ConfirmDirExists(ref logContent, IisStagingDir, true);
            Log.AppendAndShow(ref logContent, "[CREATE] ", $"{IisStagingDir}", "CREATED");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void FullCopyGitHubSourceToIisStaging(ref string logContent, string IisStagingDir)
        {
            //var stagingGitHubSrc = $@"C:\MyAvatool\MAWS\Staging\src\";
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"{IisStagingDir}", "<- DESTINATION");
            Utility.CopyDir(ref logContent, GitHubStagingSource, IisStagingDir);
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");

        }

        private static void MinimalCopyGitHubSourceToIisStaging(ref string logContent, string IisStagingDir)
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

            Log.AppendAndShow(ref logContent, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"{IisStagingDir}", "<- DESTINATION");

            foreach(var directoryToCopy in directoriesToCopy)
            {
                Utility.CopyDir(ref logContent, $"{GitHubStagingSource}{directoryToCopy}", $"{IisStagingDir}{directoryToCopy}");
            }

            Utility.CopyFiles(filesToCopy, $"{GitHubStagingSource}", $"{IisStagingDir}");
            Utility.CopyFiles(filesToMove, $"{AvatoolTempDir}", $"{IisStagingDir}");
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");
        }

        private static void StandardCopyGitHubSourceToIisStaging(ref string logContent, string IisStagingDir)
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

            Log.AppendAndShow(ref logContent, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"{IisStagingDir}", "<- DESTINATION");

            foreach(var directoryToCopy in directoriesToCopy)
            {
                Utility.CopyDir(ref logContent, $"{GitHubStagingSource}{directoryToCopy}", $"{IisStagingDir}{directoryToCopy}");
            }

            Utility.CopyFiles(filesToCopy, $"{GitHubStagingSource}", $"{IisStagingDir}");

            //Utility.CopyDirectory(GitHubStagingSource, IisStagingDirectory);
            Log.AppendAndShow(ref logContent, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");
        }
    }
}