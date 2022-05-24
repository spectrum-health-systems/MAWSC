// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Framework.Verify.cs
// Verify framework components.
// b220523.131302 -


namespace MAWSC.Framework
{
    internal class Verify
    {
        /// <summary>Verify that required directories exist, and create them if they don't.</summary>
        /// <returns>Log message.</returns>
        internal static string Directories(MAWSC.Configuration.Settings mawscSettings)
        {
            var logRequiredDirectoriesMessage    = RequiredDirectories(mawscSettings);
            var logSessionBackupDirectoryMessage = SessionBackupDirectory(mawscSettings);


            //var requiredDirectories = new List<string>
            //{
            //    mawscSettings.ConfigurationDirectory,
            //    mawscSettings.LogDirectory,
            //    mawscSettings.BackupDirectory,
            //    mawscSettings.TemporaryDirectory
            //};

            //var logSubHeader = MAWSC.Log.Component.SubHeader("Verifying required directories");
            //var logContent   = "";

            ///* The majority of MAWSC logging is taken care of by MAWS.Log.Components.cs, but
            // * since this update is just via the console, we'll take care of logging directly.
            // */
            //foreach(var requiredDirectory in requiredDirectories)
            //{
            //    if(!Directory.Exists(requiredDirectory))
            //    {
            //        logContent += $"{requiredDirectory} does not exist.{Environment.NewLine}";
            //        _=Directory.CreateDirectory(requiredDirectory);
            //        logContent += $"{requiredDirectory} created.{Environment.NewLine}";
            //    }
            //    else
            //    {
            //        logContent += $"{requiredDirectory} exists.{Environment.NewLine}";
            //    }
            //}

            return $"{logRequiredDirectoriesMessage}" +
                   $"{logSessionBackupDirectoryMessage}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscSettings"></param>
        /// <returns></returns>
        private static string RequiredDirectories(MAWSC.Configuration.Settings mawscSettings)
        {
            var requiredDirectories = new List<string>
            {
                mawscSettings.ConfigurationDirectory,
                mawscSettings.LogDirectory,
                mawscSettings.BackupDirectory,
                mawscSettings.TemporaryDirectory
            };

            var logSubHeader = MAWSC.Log.Component.SubHeader("Verifying required directories");
            var logContent   = "";

            foreach(var requiredDirectory in requiredDirectories)
            {
                if(!Directory.Exists(requiredDirectory))
                {
                    logContent += $"{requiredDirectory} does not exist.{Environment.NewLine}";
                    _=Directory.CreateDirectory(requiredDirectory);
                    logContent += $"{requiredDirectory} created.{Environment.NewLine}";
                }
                else
                {
                    logContent += $"{requiredDirectory} exists.{Environment.NewLine}";
                }
            }

            return $"{logSubHeader}" +
                   $"{logContent}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscSettings"></param>
        private static string SessionBackupDirectory(MAWSC.Configuration.Settings mawscSettings)
        {
            var logSubHeader = MAWSC.Log.Component.SubHeader("Verifying session backup directory");
            var logContent   = "";

            var sessionBackupDirectory = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            Du.WithDirectory.ConfirmDirectoryExists(sessionBackupDirectory);

            logContent = $"{sessionBackupDirectory} created.";

            return $"{logSubHeader}" +
                   $"{logContent}";
        }
    }
}
