// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// Staging environment.
// b220131.125532

namespace MAWSC
{
    internal class Staging
    {
        /* Let's define a bunch of constants here, that way if you need to make changes (which you probably will), you
         * just need to make them once.
         */
        const string BackupRoot          = $@"C:\MyAvatool\MAWS\Staging\Backup";
        const string IisStagingDir       = $@"C:\AvatoolWebService\MAWS_Staging\";
        const string GitHubStagingSource = $@"C:\MyAvatool\MAWS\src\";
        const string AvatoolTempDir      = $@"C:\MyAvatool\Temp\";

        /// <summary>
        /// Parse the passed arguments for Staging processes.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="passedArgs">All of the arguments that were passed on the command-line.</param>
        public static void ParseArgs(ref string logContent, string[] passedArgs)
        {
            /* The MAWS Commander "action" is the second argument that is passed when MAWSC is executed. If there was an
             * (optional) third argument passed, that is the MAWS Commander "option". We'll be updating these inside of
             * the loop below, so let's initialize them now.
             */
            var mawscAction ="";
            var mawscOption ="";

            /* There has to be at least one Staging argument passed, otherwise we can't do anything, so just exit.
             */
            if(passedArgs.Length == 1)
            {
                Log.AppendAndShowMsg(ref logContent, "[ ERROR] ", $"Not enough arguments passed (Arg[1] does not exist)", "INVALID");
                Utility.MawscFinish(logContent, 1);
            }
            else
            {
                /* Let's make it easy to work with the MAWSC command.
                 */
                mawscAction = Utility.ReduceArg(passedArgs[1]);

                if(passedArgs.Length == 3)
                {
                    /* If an (optional) third argument was passed, that's the MAWSC option, so let's make it easy to
                     * work with.
                     */
                    mawscOption = Utility.ReduceArg(passedArgs[2]);
                }
            }

            /* Give the users a little wiggle room when typing commands, this way they can use shorthand if they want.
             */
            switch(mawscAction)
            {
                case "d":
                case "dep":
                case "deploy":
                    /* Let's deploy the MAWS Staging environment!
                     */
                    Log.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"Arg[1] \"{passedArgs[1]}\"", "VALID");
                    Deploy(ref logContent, mawscOption);
                    break;

                default:
                    /* An invalid MAWSC action was sent, so just exit.
                     */
                    Log.AppendAndShowMsg(ref logContent, "[ ERROR] ", $"Arg[1] \"{passedArgs[1]}\"", "INVALID");
                    Utility.MawscFinish(logContent, 1);
                    break;
            }
        }

        /// <summary>
        /// Deploy a new version of MAWS to the IIS Staging environment.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="mawscOption">Any options that were passed on the command-line (can be empty).</param>
        private static void Deploy(ref string logContent, string mawscOption)
        {
            /* Determine the Staging backup and IIS locations.
             */
            var backupDir     = GetBackupDir(ref logContent);
            var IisStagingDir = GetStagingIisDir(ref logContent);

            BackupIisStaging(ref logContent, backupDir, IisStagingDir);
            //////Log.AppendAndShow(ref logContent, "[  INFO] ", "Performing a complete delete of the current IIS Staging environment", "<- INFO");
            Utility.RefreshDir(ref logContent, IisStagingDir);

            switch(mawscOption)
            {
                case "full":
                    /* The IIS Staging directory will be removed, and the entire GitHub src/ will be copied to the IIS Staging directory
                     */
                    Log.AppendAndShowMsg(ref logContent, "[  INFO] ", "Performing a full copy of the IIS Staging environment", "<- INFO");
                    FullCopyGitHubSourceToIisStaging(ref logContent, IisStagingDir);
                    break;

                case "minimal":
                default:
                    /* The IIS Staging directory will be removed, but only required files from GitHub src/ will be copied to the IIS Staging directory. This is
                     * the default behavior, if no options are passed to MAWSC.
                     */
                    Log.AppendAndShowMsg(ref logContent, "[  INFO] ", "Performing a minimal copy of the IIS Staging environment", "<- INFO");
                    MinimalCopyGitHubSourceToIisStaging(ref logContent, IisStagingDir);
                    break;
            }

            logContent += $"{Environment.NewLine}" +
                          $"Deployment to staging complete!{Environment.NewLine}";
        }

        /// <summary>
        /// Backup the current Staging IIS directory.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="backupDir">The directory to backup to.</param>
        /// <param name="IisStagingDir">The directory to backup from.</param>
        private static void BackupIisStaging(ref string logContent, string backupDir, string IisStagingDir)
        {
            /* Create log entries so the user can easily tell what the souce/destination is, backup the IIS directory,
             * then let the user know the backup is complete.
             */
            Log.AppendAndShowMsg(ref logContent, "[BACKUP] ", $"{IisStagingDir}", "<- SOURCE");
            Log.AppendAndShowMsg(ref logContent, "[BACKUP] ", $"{backupDir}", "<- DESITNATION");
            Utility.MoveDir(ref logContent, IisStagingDir, backupDir);
            Log.AppendAndShowMsg(ref logContent, "[BACKUP] ", $"Backing up Staging environment", "BACKUP COMPLETE");
        }

        /// <summary>
        /// Get the backup directory, and create it if it doesn't exist.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <returns>The backup directory name.</returns>
        private static string GetBackupDir(ref string logContent)
        {
            var currentDateTime = DateTime.Now.ToString("yyMMddHHmmss");
            var backupDirectory = $@"{BackupRoot}\{currentDateTime}";

            Log.AppendAndShowMsg(ref logContent, "[CREATE] ", $"{backupDirectory}\\", "<- CREATING");
            Utility.ConfirmDirExists(ref logContent, backupDirectory, true);
            Log.AppendAndShowMsg(ref logContent, "[CREATE] ", $"{backupDirectory}\\", "CREATED");

            return backupDirectory;
        }

        /// <summary>
        /// Get the IIS Staging directory, or exit if it doesn't exist.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <returns>The IIS Staging directory.</returns>
        private static string GetStagingIisDir(ref string logContent)
        {
            //var stagingIisDirectory = $@"C:\AvatoolWebService\MAWS_Staging\";

            Log.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"{IisStagingDir}", "<- VERIFY");
            if(!Directory.Exists(IisStagingDir))
            {
                Log.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"{IisStagingDir}", "DOES NOT EXIST");
                Utility.MawscFinish(logContent, 1);
            }
            Log.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"{IisStagingDir}", "VALID");

            return IisStagingDir;
        }

        /// <summary>
        /// Copy the entire GitHub/src directory to the IIS Staging directory.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="IisStagingDir">The IIS Staging directory.</param>
        private static void FullCopyGitHubSourceToIisStaging(ref string logContent, string IisStagingDir)
        {
            //var stagingGitHubSrc = $@"C:\MyAvatool\MAWS\Staging\src\";
            Log.AppendAndShowMsg(ref logContent, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            Log.AppendAndShowMsg(ref logContent, "[  COPY] ", $"{IisStagingDir}", "<- DESTINATION");
            Utility.CopyDir(ref logContent, GitHubStagingSource, IisStagingDir);
            Log.AppendAndShowMsg(ref logContent, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");

        }

        /// <summary>
        /// Only copy required files in GitHub/src directory to the IIS Staging directory.
        /// </summary>
        /// <param name="logContent">The existing content for the logfile.</param>
        /// <param name="IisStagingDir">The IIS Staging directory.</param>
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

            Log.AppendAndShowMsg(ref logContent, "[  COPY] ", $"{GitHubStagingSource}", "<- SOURCE");
            Log.AppendAndShowMsg(ref logContent, "[  COPY] ", $"{IisStagingDir}", "<- DESTINATION");

            foreach(var directoryToCopy in directoriesToCopy)
            {
                Utility.CopyDir(ref logContent, $"{GitHubStagingSource}{directoryToCopy}", $"{IisStagingDir}{directoryToCopy}");
            }

            Utility.CopyFiles(filesToCopy, $"{GitHubStagingSource}", $"{IisStagingDir}");
            Utility.CopyFiles(filesToMove, $"{AvatoolTempDir}", $"{IisStagingDir}");
            Log.AppendAndShowMsg(ref logContent, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");
        }
    }
}