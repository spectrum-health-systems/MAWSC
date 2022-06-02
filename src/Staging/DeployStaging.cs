﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.DeployStaging.cs
// Deploy the current staging source.
// b220601.161356

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Staging
{
    internal class DeployStaging
    {
        internal static void SoupToNuts(MawscSettings mawscSettings)
        {
            BackupStaging.SoupToNuts(mawscSettings);
            FetchStaging.SoupToNuts(mawscSettings);

            switch(mawscSettings.MawscOption)
            {
                case "a":
                case "all":
                    All(mawscSettings);
                    break;

                case "m":
                case "min":
                case "minimal":
                    Minimal(mawscSettings);
                    break;

                case "not-passed":
                default:
                    break;
            }
        }

        /// <summary></summary>
        /// 
        /// <param name="mawscSettings"></param>
        private static void All(MawscSettings mawscSettings)
        {
            var targetFile = $"{mawscSettings.TemporaryDirectory}{mawscSettings.RepositoryBranch}";

            Du.WithDirectory.RefreshRecursively(mawscSettings.StagingTestingDirectory);

            ExportLog.ToConsole(LogMessage.InfoMovingFiles());
            Du.WithDirectory.MoveRecursively($"{targetFile}/", mawscSettings.StagingTestingDirectory);
        }

        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        private static void Minimal(MawscSettings mawscSettings)
        {
            //var stagingSrcDirectory = $"{mawscSettings.StagingFetchDirectory}{mawscSettings.RepositorySrcDirectory}";

            //Du.WithDirectory.RefreshRecursively(mawscSettings.StagingTestingDirectory);

            ExportLog.ToConsole(LogMessage.InfoMovingFiles());

            //Du.WithDirectory.CopyRecursively($"{stagingSrcDirectory}bin/", $"{mawscSettings.StagingTestingDirectory}bin/");

            //var filesToCopy = new List<string>()
            //{
            //    $"{mawscSettings.RepositoryName}.asmx",
            //    $"{mawscSettings.RepositoryName}.asmx.cs",
            //    $"packages.config",
            //    $"Web.config",
            //    $"Web.Debug.config",
            //    $"Web.Release.config",
            //};

            //Du.WithFile.CopyFiles(filesToCopy, stagingSrcDirectory, mawscSettings.StagingTestingDirectory);
        }
    }
}

/*
 
 
{
  "SessionTimestamp": "set-at-runtime",
  "ApplicationVersion": "set-at-runtime",
  "ConfigurationDirectory": "./AppData/Config/",
  "LogDirectory": "./AppData/Logs/",
  "LogfilePath": "set-at-runtime",
  "BackupDirectory": "./AppData/Backup/",
  "SessionBackupDirectory": "set-at-runtime",
  "TemporaryDirectory": "./AppData/Temp/",
  "RepositoryName": "MAWS",
  "RepositoryBranch": "v0.60-development",
  "RepositoryUrl": "set-at-runtime",
  "StagingFetchDirectory": "./AppData/Staging_fetch/",
  "StagingTestingDirectory": "c:/Users/cbanw/Downloads/mawstest/",
  "ProductionDirectory": "/path/to/your/web/service/production/environment/",
  "MawscCommand": "set-at-runtime",
  "MawscAction": "set-at-runtime",
  "MawscOption": "set-at-runtime"
}
 
*/