// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Staging environment.
// b220126.170648

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
                var logMsgNoArg1 = $"[ERROR] Not enough arguments passed (arg[1] does not exist).{Environment.NewLine}";
                logMessage = Log.AppendAndDisplay(logMessage, logMsgNoArg1);
                ////Log.ToScreen(logMsgNoArg1, true);
                ////logMessage += logMsgNoArg1;
                Utility.MawscFinish(logMessage);
            }

            /* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
             */
            var secondArgument = args[1].Trim().ToLower().Replace("-", "");

            switch(secondArgument)
            {
                case "d":
                case "dep":
                case "deploy":
                    var logMsgStagingDeploy = $"[ INFO] Argument \"{args[1]}\" (arg[1]) is valid.{Environment.NewLine}";
                    logMessage = Log.AppendAndDisplay(logMessage, logMsgStagingDeploy);

                    //////Log.ToScreen(logMsgStagingDeploy);
                    //////logMessage += logMsgStagingDeploy;
                    Deploy(logMessage);

                    break;

                default:
                    var logMsgStagingError = $"[ERROR] Invalid Arg1: \"{args[1]}\" -> \"{secondArgument}\".";
                    Log.ToScreen(logMsgStagingError, true);
                    logMessage += logMsgStagingError;
                    Utility.MawscFinish(logMessage);

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Deploy(string logMessage)
        {
            /* Create the backup directory
             */
            var backupDirectoryRoot = $@"C:\MyAvatool\MAWS\Staging\Backup";
            var logMsgCreateBackupDirStart = $"[ INFO] Creating Staging backup directory in \"{backupDirectoryRoot}\\\"...{Environment.NewLine}";
            logMessage = Log.AppendAndDisplay(logMessage, logMsgCreateBackupDirStart);
            //////Log.ToScreen(logMsgCreateBackupDirectoryStart);
            //////logMessage += logMsgCreateBackupDirectoryStart;

            var backupDirectory = CreateBackupDirectory(backupDirectoryRoot);

            var logMsgCreateBackupDirectoryComplete = $"        Directory \"{backupDirectory}\"\\ CREATED.{Environment.NewLine}";
            Log.ToScreen(logMsgCreateBackupDirectoryComplete);
            logMessage += logMsgCreateBackupDirectoryComplete;

            /* Verify that the Staging IIS directory exists.
             */
            var stagingIisDirectory = $@"C:\AvatoolWebService\MAWS_Staging\";
            var logMsgVerifyStagingIisDirectory = $"[ INFO] Verifying the Staging IIS directory (\"{stagingIisDirectory}\" exists...{Environment.NewLine})";
            Log.ToScreen(logMsgVerifyStagingIisDirectory);
            logMessage += logMsgVerifyStagingIisDirectory;

            VerifyStagingIisDirectory(logMessage, stagingIisDirectory);

            var logMsgStagingIisDirectoryVerified = $"       Staging IIS directory (\"{stagingIisDirectory}\") does exist...OK.{Environment.NewLine}";
            Log.ToScreen(logMsgStagingIisDirectoryVerified);
            logMessage += logMsgStagingIisDirectoryVerified;

            /* Backup the current Staging IIS directory.
             */
            var logMsgBackupStagingIisDirectoryStart = $"[ INFO] Creating timestamped backup of current Staging IIS directory...{Environment.NewLine}";
            Log.ToScreen(logMsgBackupStagingIisDirectoryStart);
            logMessage += logMsgBackupStagingIisDirectoryStart;

            Utility.MoveDirectory(stagingIisDirectory, backupDirectory);

            //BackupStagingIisDirectory(stagingIisDirectory, backupDirectory);

            var logMsgBackupStagingIisDirectoryFinish = $"        Copied \"{stagingIisDirectory}\" to \"{stagingIisDirectory}\"...OK.{Environment.NewLine}";
            Log.ToScreen(logMsgBackupStagingIisDirectoryFinish);
            logMessage += logMsgBackupStagingIisDirectoryFinish;

            /* Refresh the Staging IIS directory.
             */
            var logMsgRefreshStagingIisDirectoryStart = $"[ INFO] Refreshing Staging IIS directory...{Environment.NewLine}";
            Log.ToScreen(logMsgRefreshStagingIisDirectoryStart);
            logMessage += logMsgRefreshStagingIisDirectoryStart;

            var logMsgDeleteStagingIisDirectoryStart = $"        Deleting Staging IIS directory...";
            Log.ToScreen(logMsgDeleteStagingIisDirectoryStart);
            logMessage += logMsgDeleteStagingIisDirectoryStart;

            Directory.Delete(stagingIisDirectory, true);

            var logMsgDeleteStagingIisDirectoryFinish = $"        COMPLETE.{Environment.NewLine}";
            Log.ToScreen(logMsgDeleteStagingIisDirectoryFinish);
            logMessage += logMsgDeleteStagingIisDirectoryFinish;

            var logMsgRecreateStagingIisDirectoryStart = $"        Recreating Staging IIS directory...";
            Log.ToScreen(logMsgRecreateStagingIisDirectoryStart);
            logMessage += logMsgRecreateStagingIisDirectoryStart;

            Utility.ConfirmDirectoryExists(stagingIisDirectory);

            var logMsgRecreateStagingIisDirectoryFinish = $"        COMPLETE.{Environment.NewLine}";
            Log.ToScreen(logMsgRecreateStagingIisDirectoryFinish);
            logMessage += logMsgRecreateStagingIisDirectoryFinish;

            var logMsgCopyGitHubSourceStart = $"[ INFO] Copying GitHub Staging src\\...{Environment.NewLine}";
            Log.ToScreen(logMsgCopyGitHubSourceStart);
            logMessage += logMsgCopyGitHubSourceStart;

            var stagingGitHubSrc = $@"C:\MyAvatool\MAWS\Staging\src\";
            Utility.CopyDirectory(stagingGitHubSrc, stagingIisDirectory);

            var logMsgCopyGitHubSourceFinish = $"        COMPLETE...{Environment.NewLine}";
            Log.ToScreen(logMsgCopyGitHubSourceFinish);
            logMessage += logMsgCopyGitHubSourceFinish;

            Utility.MawscFinish(logMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        private static string CreateBackupDirectory(string backupDirectoryRoot)
        {
            var currentDateTime = DateTime.Now.ToString("yyMMddHHmmss");
            var backupDirectory = $@"{backupDirectoryRoot}\{currentDateTime}";
            Utility.ConfirmDirectoryExists(backupDirectory);

            return backupDirectory;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void VerifyStagingIisDirectory(string logMessage, string stagingIisDirectory)
        {
            /* If the Staging IIS directory doesn't exist, we will write whatever we have for the logfile, then exit.
             */
            if(!Directory.Exists(stagingIisDirectory))
            {
                var logMsgStagingIisDirectoryDoesNotExist = $"[ERROR] Staging IIS directory does not exist.{Environment.NewLine}";
                Log.ToScreen(logMsgStagingIisDirectoryDoesNotExist);
                logMessage += logMsgStagingIisDirectoryDoesNotExist;
                Utility.MawscFinish(logMessage);
            }
        }

        ///////// <summary>
        ///////// 
        ///////// </summary>
        //////private static void BackupStagingIisDirectory(string stagingIisDirectory, string backupDirectory)
        //////{
        //////    Utility.MoveDirectory(stagingIisDirectory, backupDirectory);
        //////}

        ///////// <summary>
        ///////// 
        ///////// </summary>
        //////private static void CleanStagingIisDirectory(string stagingIisDirectory)
        //////{
        //////    /* Since we know the stagingIisDirectory exists, we'll just update the user via the console, and not worry
        //////     * about upating the logMessage here.
        //////     */
        //////    Log.ToScreen($"[ INFO] Cleaning Staging IIS directory...");
        //////    Directory.Delete(stagingIisDirectory, true);
        //////    Log.ToScreen($"COMPLETE.{Environment.NewLine}");
        //////}

        /////////////// <summary>
        ///////// 
        ///////// </summary>
        //////private static void RefreshStagingIisDirectory(string stagingIisDirectory)
        //////{
        //////    /* Since we know the stagingIisDirectory exists, we'll just update the user via the console, and not worry
        //////     * about upating the logMessage here.
        //////     */
        //////    Log.ToScreen($"[ INFO] Refreshing Staging IIS directory...");
        //////    Utility.ConfirmDirectoryExists(stagingIisDirectory);
        //////    Log.ToScreen($"COMPLETE.{Environment.NewLine}");
        //////}

        ///////// <summary>
        ///////// 
        ///////// </summary>
        //////private static void CopyGitHubSourceToIis(string stagingGitHubSrc, string stagingIisDirectory)
        //////{
        //////    /* Since we know the both the stagingGitHubSrc and stagingIisDirectory exist, we'll just update the user via
        //////     * the console, and not worry about upating the logMessage here.
        //////     */
        //////    Log.ToScreen($"[ INFO] Copying repository src to IIS...");
        //////    Utility.CopyDirectory(stagingGitHubSrc, stagingIisDirectory);
        //////}
    }
}
