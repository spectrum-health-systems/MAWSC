// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Staging environment.
// b220127.144311

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
                logMessage = Log.AppendAndDisplay(logMessage, "[ ERROR] ", $"Not enough arguments passed (Arg[1] does not exist)", "INVALID", true);
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
                    logMessage = Log.AppendAndDisplay(logMessage, "[ CHECK] ", $"Arg[1] \"{args[1]}\"", "VALID");
                    Deploy(logMessage);
                    break;

                default:
                    logMessage = Log.AppendAndDisplay(logMessage, "[ ERROR] ", $"Arg[1] \"{args[1]}\"", "INVALID", true);
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
            logMessage = Log.AppendAndDisplay(logMessage, "[CREATE] ", $"{backupDirectoryRoot}\\", "CREATING");
            var backupDirectory = CreateBackupDirectory(backupDirectoryRoot);
            logMessage = Log.AppendAndDisplay(logMessage, "[CREATE] ", $"{backupDirectory}", "CREATED");

            /* Verify that the Staging IIS directory exists.
             */
            var stagingIisDirectory = $@"C:\AvatoolWebService\MAWS_Staging\";
            logMessage = Log.AppendAndDisplay(logMessage, "[ CHECK] ", $"{stagingIisDirectory}", "EXISTS?");
            VerifyStagingIisDirectory(logMessage, stagingIisDirectory);
            logMessage = Log.AppendAndDisplay(logMessage, "[ CHECK] ", $"{stagingIisDirectory}", "EXISTS");

            /* Backup the current Staging IIS directory.
             */
            logMessage = Log.AppendAndDisplay(logMessage, "[BACKUP] ", $"{stagingIisDirectory}", "BACKUP SOURCE");
            logMessage = Log.AppendAndDisplay(logMessage, "[BACKUP] ", $"{backupDirectory}", "BACKUP DESITNATION");
            Utility.MoveDirectory(stagingIisDirectory, backupDirectory);
            logMessage = Log.AppendAndDisplay(logMessage, "[BACKUP] ", $"Backing up Staging environment", "BACKUP COMPLETE");

            /* Refresh the Staging IIS directory.
             */
            logMessage = Log.AppendAndDisplay(logMessage, "[DELETE] ", $"{stagingIisDirectory}", "DELETING");
            Directory.Delete(stagingIisDirectory, true);
            logMessage = Log.AppendAndDisplay(logMessage, "[DELETE] ", $"{stagingIisDirectory}", "DELETED");

            logMessage = Log.AppendAndDisplay(logMessage, "[CREATE] ", $"{stagingIisDirectory}", "CREATING");
            Utility.ConfirmDirectoryExists(stagingIisDirectory);
            logMessage = Log.AppendAndDisplay(logMessage, "[CREATE] ", $"{stagingIisDirectory}", "CREATED");

            /* Copy GitHub source to IIS.
             */
            var stagingGitHubSrc = $@"C:\MyAvatool\MAWS\Staging\src\";
            logMessage = Log.AppendAndDisplay(logMessage, "[  COPY] ", $"{stagingGitHubSrc}", "COPY SOURCE");
            logMessage = Log.AppendAndDisplay(logMessage, "[  COPY] ", $"{stagingIisDirectory}", "COPY DESTINATION");
            Utility.CopyDirectory(stagingGitHubSrc, stagingIisDirectory);
            logMessage = Log.AppendAndDisplay(logMessage, "[  COPY] ", $"Copying GitHub Staging to IIS Staging", "COPY COMPLETE");

            logMessage += $"{Environment.NewLine}" +
                          $"Deployment to staging complete!{Environment.NewLine}";

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
                logMessage = Log.AppendAndDisplay(logMessage, "[  ERROR] ", $"{stagingIisDirectory}", "DOES NOT EXIST", true);
                Utility.MawscFinish(logMessage);
            }
        }
    }
}