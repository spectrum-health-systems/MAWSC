// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Configuration.MawscSettings.cs
// Setting properties
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using System.Reflection;

namespace MAWSC.Configuration
{
    internal class ConfigurationSettings
    {
        public string SessionTimestamp { get; set; }
        public string ApplicationVersion { get; set; }
        public string ConfigurationDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string SessionLogfilePath { get; set; }
        public string BackupDirectory { get; set; }
        public string SessionBackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }
        public string RepositoryLocation { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryBranch { get; set; }
        public string RepositoryZipUrl { get; set; }
        public string StagingFetchDirectory { get; set; }
        public string StagingTestingDirectory { get; set; }
        public string ProductionDirectory { get; set; }
        public string MawscCommand { get; set; }
        public string MawscAction { get; set; }
        public string MawscOption { get; set; }

        /// <summary>Get the MAWSC configuration settings for the session.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <param name="sessionTimestamp">Session timestamp created at execution.</param>
        /// <returns>MAWSC configuration settings.</returns>
        internal static ConfigurationSettings Initialize(string[] arguments, string sessionTimestamp)
        {
            ConfigurationSettings mawsc = ConfigurationFile.Load();

            return GetRuntimeValues(mawsc, arguments, sessionTimestamp);
        }

        /// <summary>Get a few session-specific settings.</summary>
        /// <param name="mawsc">MAWSC settings</param>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <param name="sessionTimestamp">Session timestamp created at execution.</param>
        /// <returns>MAWSC sessions</returns>
        internal static ConfigurationSettings GetRuntimeValues(ConfigurationSettings mawsc, string[] arguments, string sessionTimestamp)
        {
            mawsc.SessionTimestamp = sessionTimestamp;
            mawsc.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawsc.SessionLogfilePath = $"{mawsc.LogDirectory}mawsc-{mawsc.SessionTimestamp}.log";
            mawsc.SessionBackupDirectory = $"{mawsc.BackupDirectory}{mawsc.SessionTimestamp}";
            mawsc.RepositoryZipUrl = $"{mawsc.RepositoryLocation}{mawsc.RepositoryName}/archive/refs/heads/{mawsc.RepositoryBranch}.zip";

            var mawscArguments = CommandLine.Arguments.GetIndividualArguments(arguments);

            mawsc.MawscCommand = mawscArguments["mawscCommand"];
            mawsc.MawscAction = mawscArguments["mawscAction"];
            mawsc.MawscOption = mawscArguments["mawscOption"];

            return mawsc;
        }
    }
}