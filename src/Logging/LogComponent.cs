// ========================================[ PROJECT ]=========================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// -----------------------------------------[ CLASS ]------------------------------------------
// MAWSC.Logging.LogComponent.cs
// Logging components.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------

using MAWSC.Configuration;

namespace MAWSC.Logging
{
    internal class LogComponent
    {
        /// <summary></summary>
        /// <param name="mawsc"></param>
        /// <returns></returns>
        internal static string ArgumentsPassed(ConfigurationSettings mawsc)
        {
            return $"-{mawsc.MawscCommand} [-{mawsc.MawscAction}] [-{mawsc.MawscOption}]";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string BackupStagingSource(string stagingFetchDirectory, string sessionBackupDirectory)
        {
            return $"{Environment.NewLine}" +
                   $"           {stagingFetchDirectory} -> {sessionBackupDirectory}/";
        }

        /// <summary></summary>
        /// <returns></returns> 
        internal static string BackupStagingTarget(ConfigurationSettings mawsc)
        {
            return $"{Environment.NewLine}" +
                   $"           {mawsc.StagingTestingDirectory} -> {mawsc.BackupDirectory}{mawsc.SessionTimestamp}/";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string ConfigurationInformation(ConfigurationSettings mawsc)
        {
            return $"ConfigDirectory: {mawsc.ConfigurationDirectory}{Environment.NewLine}" +
                   $"LogDirectory: {mawsc.LogDirectory}{Environment.NewLine}" +
                   $"BackupDirectory: {mawsc.BackupDirectory}{Environment.NewLine}" +
                   $"TemporaryDirectory: {mawsc.TemporaryDirectory}{Environment.NewLine}" +
                   $"StagingSourceDirectory: {mawsc.StagingFetchDirectory}{Environment.NewLine}" +
                   $"StagingTargetDirectory: {mawsc.StagingFetchDirectory}{Environment.NewLine}" +
                   $"ProductionSourceDirectory: {mawsc.ProductionDirectory}{Environment.NewLine}" +
                   $"ProductionTargetDirectory: {mawsc.ProductionDirectory}{Environment.NewLine}" +
                   $"Application version: {mawsc.ApplicationVersion}{Environment.NewLine}" +
                   $"SessionTimestamp: {mawsc.SessionTimestamp}{Environment.NewLine}" +
                   $"LogfilePath: {mawsc.SessionLogfilePath}{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"For a list of valid commands/actions/options, please type: \"mawsc -help\"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string StagingInformation(ConfigurationSettings mawsc)
        {
            var assemblyVersion = Staging.StagingInformation.GetWebServiceVersion(mawsc);

            var lastFetchedDate = Staging.StagingInformation.GetLastFetchedTimestamp(mawsc);

            return $"Name: {mawsc.RepositoryName}{Environment.NewLine}" +
                   $"Branch: {mawsc.RepositoryBranch}{Environment.NewLine}" +
                   $"Version: {assemblyVersion}{Environment.NewLine}" +
                   $"Last fetched: {lastFetchedDate}{Environment.NewLine}" +
                   $"Fetch location directory: {mawsc.StagingFetchDirectory}{Environment.NewLine}" +
                   $"Testing location directory: {mawsc.StagingTestingDirectory}{Environment.NewLine}" +
                   $"Deployment location directory: {mawsc.ProductionDirectory}{Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string ConfigurationFileWillBeReset()
        {
            return $"Configuration file will be created.";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string ConfigurationFileHasBeenReset()
        {

            return "Configuration file has been reset.";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string FrameworkRequiredDirectoriesVerified(string verificationMessage)
        {
            return $"{verificationMessage}";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string SessionBackupDirectoryVerified()
        {
            return ": Verified.";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string TypeForHelp()
        {
            return $"{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $">>> Type \"mawsc -help\" for help{Environment.NewLine}";
        }
    }
}