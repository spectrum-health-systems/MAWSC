﻿// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Log.Component.cs
// Create logfile message components.
// b220518.115916

namespace MAWSC.Log
{
    internal class Component
    {
        internal static string ArgumentsPassed(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"-{ mawscSettings.MawscCommand} [-{ mawscSettings.MawscAction}] [-{ mawscSettings.MawscOption}]";
        }

        internal static string BackupStagingSource(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Environment.NewLine}" +
                   $"           {mawscSettings.StagingSourceDirectory} -> {mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}/";
        }

        internal static string BackupStagingTarget(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"{Environment.NewLine}" +
                   $"           {mawscSettings.StagingTargetDirectory} -> {mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}/";
        }

        internal static string ConfigurationInformation(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"ConfigDirectory: {mawscSettings.ConfigurationDirectory}{Environment.NewLine}" +
                   $"LogDirectory: {mawscSettings.LogDirectory}{Environment.NewLine}" +
                   $"BackupDirectory: {mawscSettings.BackupDirectory}{Environment.NewLine}" +
                   $"TemporaryDirectory: {mawscSettings.TemporaryDirectory}{Environment.NewLine}" +
                   $"StagingSourceDirectory: {mawscSettings.StagingSourceDirectory}{Environment.NewLine}" +
                   $"StagingTargetDirectory: {mawscSettings.StagingSourceDirectory}{Environment.NewLine}" +
                   $"ProductionSourceDirectory: {mawscSettings.ProductionSourceDirectory}{Environment.NewLine}" +
                   $"ProductionTargetDirectory: {mawscSettings.ProductionSourceDirectory}{Environment.NewLine}" +
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

        internal static string StagingInformation(MAWSC.Configuration.Settings mawscSettings)
        {
            return $"Staging source directory: {mawscSettings.StagingSourceDirectory}{Environment.NewLine}" +
                   $"Staging target directory: {mawscSettings.StagingTargetDirectory}{Environment.NewLine}";
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