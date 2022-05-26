// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Logging.Message.cs
// Logging message.
// b220526.080326

namespace MAWSC.Log
{
    internal class Message
    {
        internal static string ArgumentsMissing()
        {
            return $"{Header.Error("Missing command line arguments.")}" +
                   $"{Component.TypeForHelp()}";
        }

        internal static string ArgumentsPassed(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Info("Passed command line arguments: ")}" +
                   $"{Component.ArgumentsPassed(mawscSettings)}";
        }

        internal static string BackupStagingSource(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Backup("Backing up current staging source ")}" +
                   $"{Component.BackupStagingSource(mawscSettings)}";
        }

        internal static string BackupStagingSourceRequest(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Request("Backup current staging source.")}";
        }


        internal static string BackupStagingTarget(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Backup("Backing up current staging target.")}" +
                   $"{Component.BackupStagingTarget(mawscSettings)}";
        }

        internal static string BackupStagingTargetRequest(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Request("Backup current staging target.")}";
        }

        internal static string CommandIsInvalid(string mawscCommand)
        {
            return $"{Header.Error("Invalid command: \"{mawscCommand}\"")}" +
                   $"{Component.TypeForHelp()}";
        }

        internal static string ConfigurationInformation(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Sub("Configuration information")}" +
                   $"{Component.ConfigurationInformation(mawscSettings)}";
        }

        internal static string ConfigurationInformationRequest(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Header.Request("Configuration information")}" +
                   $"{Message.ConfigurationInformation(mawscSettings)}";
        }

        internal static string ConfigurationFileInvalid()
        {
            return $"{MAWSC.Log.Header.Error("Invalid configuration file.")}" +
                   $"{Component.ConfigurationFileWillBeReset()}";
        }

        internal static string ConfigurationFileNotFound()
        {
            return $"{MAWSC.Log.Header.Error("Configuration file not found...")}" +
                   $"{Component.ConfigurationFileWillBeReset()}";
        }

        internal static string ConfigurationFileResetRequest()
        {
            return $"{MAWSC.Log.Header.Request("Reset configuration file.")}";
        }

        internal static string ConfigurationFileReset()
        {
            return $"{MAWSC.Log.Header.Info("Resetting configuration file...")}" +
                   $"{Component.ConfigurationFileHasBeenReset()}";
        }

        internal static string FrameworkDirectoryRequirementsVerify(string verificationMessage)
        {
            return $"{MAWSC.Log.Header.Verify("Required framework directories.")}" +
                   $"{Component.FrameworkRequiredDirectoriesVerified(verificationMessage)}";
        }

        internal static string SessionBackupDirectoryVerify()
        {
            return $"{Header.Verify("Session backup directory")}" +
                   $"{Component.SessionBackupDirectoryVerified()}";
        }


        internal static string StagingInformationRequest(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{MAWSC.Log.Header.Request("Staging information")}" +
                   $"{Component.StagingInformation(mawscSettings)}";
        }
    }
}
