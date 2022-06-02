// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Logging.LogMessage.cs
// Logging message.
// bb220531.085425

using MAWSC.Configuration;

namespace MAWSC.Logging
{
    internal class LogMessage
    {
        internal static string ArgumentsMissing()
        {
            return $"{LogHeader.Error("Missing command line arguments.")}" +
                   $"{LogComponent.TypeForHelp()}";
        }

        internal static string ArgumentsPassed(MawscSettings mawsc)
        {
            return $"{LogHeader.Info("Passed command line arguments: ")}" +
                   $"{LogComponent.ArgumentsPassed(mawsc)}";
        }

        internal static string BackupStagingSource(string stagingFetchDirectory, string sessionBackupDirectory)
        {
            return $"{LogHeader.Backup("Backing up current staging source...please wait.")}" +
                   $"{LogComponent.BackupStagingSource(stagingFetchDirectory, sessionBackupDirectory)}";
        }

        internal static string RequestBackupStagingSource()
        {
            return $"{LogHeader.Request("Backup current staging source.")}";
        }

        internal static string BackupStagingTarget(MawscSettings mawsc)
        {
            return $"{LogHeader.Backup("Backing up current staging target...please wait.")}" +
                   $"{LogComponent.BackupStagingTarget(mawsc)}";
        }

        internal static string InfoMovingFiles()
        {
            return $"{LogHeader.Info("Moving files...please wait.")}";
        }

        internal static string RequestBackupStagingTarget()
        {
            return $"{LogHeader.Request("Backup current staging target.")}";
        }

        internal static string CommandIsInvalid(string mawscCommand)
        {
            return $"{LogHeader.Error($"Invalid command: \"{mawscCommand}\"")}" +
                   $"{LogComponent.TypeForHelp()}";
        }

        internal static string ConfigurationInformation(MawscSettings mawsc)
        {
            return $"{LogHeader.Sub("Current configuration information:")}" +
                   $"{LogComponent.ConfigurationInformation(mawsc)}";
        }

        internal static string RequestConfigurationInformation()
        {
            return $"{LogHeader.Request("Configuration information")}";
        }

        internal static string ConfigurationFileInvalid()
        {
            return $"{LogHeader.Error("Invalid configuration file.")}" +
                   $"{LogComponent.ConfigurationFileWillBeReset()}";
        }

        internal static string ConfigurationFileNotFound()
        {
            return $"{LogHeader.Error("Configuration file not found...")}" +
                   $"{LogComponent.ConfigurationFileWillBeReset()}";
        }

        internal static string RequestConfigurationFileReset()
        {
            return $"{LogHeader.Request("Reset configuration file.")}";
        }

        internal static string ConfigurationFileReset()
        {
            return $"{LogHeader.Info("Resetting configuration file...")}" +
                   $"{LogComponent.ConfigurationFileHasBeenReset()}";
        }

        internal static string VerifyFrameworkRequiredDirectories(string verificationMessage)
        {
            return $"{LogHeader.Verify("Required framework directories.")}" +
                   $"{LogComponent.FrameworkRequiredDirectoriesVerified(verificationMessage)}";
        }

        internal static string SessionBackupDirectoryVerify()
        {
            return $"{LogHeader.Verify("Session backup directory")}" +
                   $"{LogComponent.SessionBackupDirectoryVerified()}";
        }


        internal static string RequestStagingInformation(MawscSettings mawsc)
        {
            return $"{LogHeader.Request("Staging information")}" +
                   $"{LogComponent.StagingInformation(mawsc)}";
        }
    }
}
