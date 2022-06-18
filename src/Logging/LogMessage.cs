// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Logging.LogMessage.cs
// Logging message.
// b220617.080310
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Manual/MAWSC-Manual.md#sourcecode

using MAWSC.Configuration;

namespace MAWSC.Logging
{
    internal class LogMessage
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string ArgumentsMissing()
        {
            return $"{LogHeader.Error("Missing command line arguments.")}" +
                   $"{LogComponent.TypeForHelp()}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string ArgumentsPassed(ConfigurationSettings mawsc)
        {
            return $"{LogHeader.Info("Passed command line arguments: ")}" +
                   $"{LogComponent.ArgumentsPassed(mawsc)}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string BackupStagingSource(string stagingFetchDirectory, string sessionBackupDirectory)
        {
            return $"{LogHeader.Backup("Backing up current staging source...please wait.")}" +
                   $"{LogComponent.BackupStagingSource(stagingFetchDirectory, sessionBackupDirectory)}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string RequestBackupStagingSource()
        {
            return $"{LogHeader.Request("Backup current staging source.")}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string BackupStagingTarget(ConfigurationSettings mawsc)
        {
            return $"{LogHeader.Backup("Backing up current staging target...please wait.")}" +
                   $"{LogComponent.BackupStagingTarget(mawsc)}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string InfoMovingFiles()
        {
            return $"{LogHeader.Info("Moving files...please wait.")}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string RequestBackupStagingTarget()
        {
            return $"{LogHeader.Request("Backup current staging target.")}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string CommandIsInvalid(string mawscCommand)
        {
            return $"{LogHeader.Error($"Invalid command: \"{mawscCommand}\"")}" +
                   $"{LogComponent.TypeForHelp()}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string ConfigurationInformation(ConfigurationSettings mawsc)
        {
            return $"{LogHeader.Sub("Current configuration information:")}" +
                   $"{LogComponent.ConfigurationInformation(mawsc)}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string RequestConfigurationInformation()
        {
            return $"{LogHeader.Request("Configuration information")}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string StagingInformation(ConfigurationSettings mawsc)
        {
            return $"{LogHeader.Sub("Current staging information:")}" +
                   $"{LogComponent.StagingInformation(mawsc)}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string RequestStagingInformation()
        {
            return $"{LogHeader.Request("Staging information")}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string ConfigurationFileInvalid()
        {
            return $"{LogHeader.Error("Invalid configuration file.")}" +
                   $"{LogComponent.ConfigurationFileWillBeReset()}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string ConfigurationFileNotFound()
        {
            return $"{LogHeader.Error("Configuration file not found...")}" +
                   $"{LogComponent.ConfigurationFileWillBeReset()}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string RequestConfigurationFileReset()
        {
            return $"{LogHeader.Request("Reset configuration file.")}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string ConfigurationFileReset()
        {
            return $"{LogHeader.Info("Resetting configuration file...")}" +
                   $"{LogComponent.ConfigurationFileHasBeenReset()}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string VerifyFrameworkRequiredDirectories(string verificationMessage)
        {
            return $"{LogHeader.Verify("Required framework directories.")}" +
                   $"{LogComponent.FrameworkRequiredDirectoriesVerified(verificationMessage)}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string SessionBackupDirectoryVerify()
        {
            return $"{LogHeader.Verify("Session backup directory")}" +
                   $"{LogComponent.SessionBackupDirectoryVerified()}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns> 
        internal static string RequestStagingInformation(ConfigurationSettings mawsc)
        {
            return $"{LogHeader.Request("Staging information")}" +
                   $"{LogComponent.StagingInformation(mawsc)}";
        }
    }
}
