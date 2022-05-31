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

namespace MAWSC.Logging
{
    internal class LogMessage
    {
        internal static string ArgumentsMissing()
        {
            return $"{LogHeader.Error("Missing command line arguments.")}" +
                   $"{LogComponent.TypeForHelp()}";
        }

        internal static string ArgumentsPassed(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Info("Passed command line arguments: ")}" +
                   $"{LogComponent.ArgumentsPassed(mawscSettings)}";
        }

        internal static string BackupStagingSource(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Backup("Backing up current staging source ")}" +
                   $"{LogComponent.BackupStagingSource(mawscSettings)}";
        }

        internal static string BackupStagingSourceRequest(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Request("Backup current staging source.")}";
        }


        internal static string BackupStagingTarget(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Backup("Backing up current staging target.")}" +
                   $"{LogComponent.BackupStagingTarget(mawscSettings)}";
        }

        internal static string BackupStagingTargetRequest(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Request("Backup current staging target.")}";
        }

        internal static string CommandIsInvalid(string mawscCommand)
        {
            return $"{LogHeader.Error($"Invalid command: \"{mawscCommand}\"")}" +
                   $"{LogComponent.TypeForHelp()}";
        }

        internal static string ConfigurationInformation(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Sub("Configuration information")}" +
                   $"{LogComponent.ConfigurationInformation(mawscSettings)}";
        }

        internal static string ConfigurationInformationRequest(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{LogHeader.Request("Configuration information")}" +
                   $"{LogMessage.ConfigurationInformation(mawscSettings)}";
        }

        internal static string ConfigurationFileInvalid()
        {
            return $"{MAWSC.Logging.LogHeader.Error("Invalid configuration file.")}" +
                   $"{LogComponent.ConfigurationFileWillBeReset()}";
        }

        internal static string ConfigurationFileNotFound()
        {
            return $"{MAWSC.Logging.LogHeader.Error("Configuration file not found...")}" +
                   $"{LogComponent.ConfigurationFileWillBeReset()}";
        }

        internal static string ConfigurationFileResetRequest()
        {
            return $"{MAWSC.Logging.LogHeader.Request("Reset configuration file.")}";
        }

        internal static string ConfigurationFileReset()
        {
            return $"{MAWSC.Logging.LogHeader.Info("Resetting configuration file...")}" +
                   $"{LogComponent.ConfigurationFileHasBeenReset()}";
        }

        internal static string VerifyFrameworkRequiredDirectories(string verificationMessage)
        {
            return $"{MAWSC.Logging.LogHeader.Verify("Required framework directories.")}" +
                   $"{LogComponent.FrameworkRequiredDirectoriesVerified(verificationMessage)}";
        }

        internal static string SessionBackupDirectoryVerify()
        {
            return $"{LogHeader.Verify("Session backup directory")}" +
                   $"{LogComponent.SessionBackupDirectoryVerified()}";
        }


        internal static string StagingInformationRequest(MAWSC.Configuration.MawscSettings mawscSettings)
        {
            return $"{MAWSC.Logging.LogHeader.Request("Staging information")}" +
                   $"{LogComponent.StagingInformation(mawscSettings)}";
        }
    }
}
