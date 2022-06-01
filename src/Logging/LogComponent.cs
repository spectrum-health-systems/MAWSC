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

namespace MAWSC.Logging
{
    internal class LogComponent
    {
        internal static string ArgumentsPassed(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"-{ mawscSettings.MawscCommand} [-{ mawscSettings.MawscAction}] [-{ mawscSettings.MawscOption}]";
        }

        internal static string BackupStagingSource(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{Environment.NewLine}" +
                   $"           {mawscSettings.StagingFetchDirectory} -> {mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}/";
        }

        internal static string BackupStagingTarget(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{Environment.NewLine}" +
                   $"           {mawscSettings.StagingTestingDirectory} -> {mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}/";
        }

        internal static string ConfigurationInformation(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"ConfigDirectory: {mawscSettings.ConfigurationDirectory}{Environment.NewLine}" +
                   $"LogDirectory: {mawscSettings.LogDirectory}{Environment.NewLine}" +
                   $"BackupDirectory: {mawscSettings.BackupDirectory}{Environment.NewLine}" +
                   $"TemporaryDirectory: {mawscSettings.TemporaryDirectory}{Environment.NewLine}" +
                   $"StagingSourceDirectory: {mawscSettings.StagingFetchDirectory}{Environment.NewLine}" +
                   $"StagingTargetDirectory: {mawscSettings.StagingFetchDirectory}{Environment.NewLine}" +
                   $"ProductionSourceDirectory: {mawscSettings.ProductionDirectory}{Environment.NewLine}" +
                   $"ProductionTargetDirectory: {mawscSettings.ProductionDirectory}{Environment.NewLine}" +
                   $"Application version: {mawscSettings.ApplicationVersion}{Environment.NewLine}" +
                   $"SessionTimestamp: {mawscSettings.SessionTimestamp}{Environment.NewLine}" +
                   $"LogfilePath: {mawscSettings.LogfilePath}{Environment.NewLine}" +
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

        internal static string StagingInformation(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"Staging source directory: {mawscSettings.StagingFetchDirectory}{Environment.NewLine}" +
                   $"Staging target directory: {mawscSettings.StagingTestingDirectory}{Environment.NewLine}";
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