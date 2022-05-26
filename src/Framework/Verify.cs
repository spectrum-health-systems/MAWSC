// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Framework.Verify.cs
// Verify framework components.
// b220526.080326

namespace MAWSC.Framework
{
    internal class Verify
    {
        /// <summary>Verify that required directories exist, and create them if they don't.</summary>
        /// <returns>Log message.</returns>
        internal static void Directories(MAWSC.Configuration.Settings mawscSettings)
        {
            //var logRequiredDirectoriesMessage    = RequiredDirectories(mawscSettings);
            //var logSessionBackupDirectoryMessage = SessionBackupDirectory(mawscSettings);

            Verify.RequiredDirectories(mawscSettings);
            //Verify.SessionBackupDirectory(mawscSettings);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscSettings"></param>
        /// <returns></returns>
        private static void RequiredDirectories(MAWSC.Configuration.Settings mawscSettings)
        {
            var requiredDirectories = new List<string>
            {
                mawscSettings.ConfigurationDirectory,
                mawscSettings.LogDirectory,
                mawscSettings.BackupDirectory,
                mawscSettings.StagingSourceDirectory,
                mawscSettings.TemporaryDirectory
            };

            var logContent = "";

            foreach(var requiredDirectory in requiredDirectories)
            {
                logContent += $"{Environment.NewLine}";

                if(!Directory.Exists(requiredDirectory))
                {
                    logContent += $"           {requiredDirectory}: does not exist...";
                    _=Directory.CreateDirectory(requiredDirectory);
                    logContent += $"created...Verified";
                }
                else
                {
                    logContent += $"           {requiredDirectory}: Verified.";
                }
            }

            MAWSC.Log.Export.ToEverywhere(MAWSC.Log.Message.FrameworkDirectoryRequirementsVerify(logContent), mawscSettings.LogfilePath);
        }
    }
}
