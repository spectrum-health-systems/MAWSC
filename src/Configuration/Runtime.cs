// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.Runtime.cs
// Setting properties at runtime.
// b220603.191717

using System.Reflection;

namespace MAWSC.Configuration
{
    internal class Runtime
    {
        internal static MawscSettings SetSetting(MAWSC.Configuration.MawscSettings mawsc, string[] commandLineArguments, string sessionTimestamp)
        {

            /* Some of the configuration settings are set at runtime.
             */
            mawsc.SessionTimestamp       = sessionTimestamp;
            mawsc.ApplicationVersion     = Assembly.GetEntryAssembly().GetName().Version.ToString();

            mawsc.LogfilePath            = $"{mawsc.LogDirectory}mawsc-{mawsc.SessionTimestamp}.log";

            mawsc.SessionBackupDirectory = $"{mawsc.BackupDirectory}{mawsc.SessionTimestamp}";

            mawsc.RepositoryUrl = $"https://github.com/spectrum-health-systems/{mawsc.RepositoryName}/archive/refs/heads/{mawsc.RepositoryBranch}.zip";

            var mawscArguments = CommandLine.Arguments.GetArgumentValues(commandLineArguments);

            mawsc.MawscCommand = mawscArguments["mawscCommand"];
            mawsc.MawscAction = mawscArguments["mawscAction"];
            mawsc.MawscOption = mawscArguments["mawscOption"];

            return mawsc;
        }
    }
}


/*
 
 
  "RepositoryName": "MAWS",
  "RepositoryUrl": "https://github.com/spectrum-health-systems/MAWS/archive/refs/heads/v0.60-development.zip",
  "RepositorySrcDirectory": "MAWS-0.60-development/src/",
  "StagingSourceDirectory": "./AppData/Staging_source/",
  "StagingTargetDirectory": "c:/Users/cbanw/Downloads/mawstest/",
 
*/