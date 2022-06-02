// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Logging.LogComponent.cs
// Logging components.
// b220531.085407

using MAWSC.Configuration;

namespace MAWSC.Logging
{
    internal class LogComponent
    {
        internal static string ArgumentsPassed(MawscSettings mawsc)
        {
            return $"-{ mawsc.MawscCommand} [-{ mawsc.MawscAction}] [-{ mawsc.MawscOption}]";
        }

        internal static string BackupStagingSource(string stagingFetchDirectory, string sessionBackupDirectory)
        {
            return $"{Environment.NewLine}" +
                   $"           {stagingFetchDirectory} -> {sessionBackupDirectory}/";
        }

        internal static string BackupStagingTarget(MawscSettings mawsc)
        {
            return $"{Environment.NewLine}" +
                   $"           {mawsc.StagingTestingDirectory} -> {mawsc.BackupDirectory}{mawsc.SessionTimestamp}/";
        }

        internal static string ConfigurationInformation(MawscSettings mawsc)
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
                   $"LogfilePath: {mawsc.LogfilePath}{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"For a list of valid commands/actions/options, please type: \"mawsc -help\"{Environment.NewLine}";
        }

        internal static string ConfigurationFileWillBeReset()
        {
            return $"Configuration file will be created.";
        }

        internal static string ConfigurationFileHasBeenReset()
        {

            return "Configuration file has been reset.";
        }

        internal static string FrameworkRequiredDirectoriesVerified(string verificationMessage)
        {
            return $"{verificationMessage}";
        }

        internal static string StagingInformation(MawscSettings mawsc)
        {
            return $"Staging source directory: {mawsc.StagingFetchDirectory}{Environment.NewLine}" +
                   $"Staging target directory: {mawsc.StagingTestingDirectory}{Environment.NewLine}";
        }

        internal static string SessionBackupDirectoryVerified()
        {
            return ": Verified.";
        }

        internal static string TypeForHelp()
        {
            return $"{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $">>> Type \"mawsc -help\" for help{Environment.NewLine}";
        }
    }
}