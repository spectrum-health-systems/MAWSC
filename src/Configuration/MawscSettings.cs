// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.MawscSettings.cs
// Setting properties
// b220603.191721

namespace MAWSC.Configuration
{
    internal class MawscSettings
    {
        /* Application
         */
        public string SessionTimestamp { get; set; }
        public string ApplicationVersion { get; set; }

        /* Configuration
         */
        public string ConfigurationDirectory { get; set; }

        /* Logging
         */
        public string LogDirectory { get; set; }
        public string LogfilePath { get; set; }

        /* Backups
         */
        public string BackupDirectory { get; set; }
        public string SessionBackupDirectory { get; set; }

        /* Temporary
         */
        public string TemporaryDirectory { get; set; }

        /* Repository
         */
        public string RepositoryName { get; set; }
        public string RepositoryBranch { get; set; }
        public string RepositoryUrl { get; set; }

        /* Staging
         */
        public string StagingFetchDirectory { get; set; }
        public string StagingTestingDirectory { get; set; }

        /* Production
         */
        public string ProductionDirectory { get; set; }

        /* Command line
         */
        public string MawscCommand { get; set; }
        public string MawscAction { get; set; }
        public string MawscOption { get; set; }

        /// <summary></summary>
        /// <param name="commandLineArguments"></param>
        /// <param name="sessionTimestamp"></param>
        /// <returns></returns>
        internal static MawscSettings Initialize(string[] commandLineArguments, string sessionTimestamp)
        {
            MawscSettings mawsc = Load.FromFile();

            mawsc = Runtime.SetSetting(mawsc, commandLineArguments, sessionTimestamp);

            return mawsc;
        }
    }


}