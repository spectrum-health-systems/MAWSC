// =============================================================================
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

namespace MAWSC.Staging
{
    internal class DeployStaging
    {
        internal static void Components(MawscSettings mawscSettings)
        {
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
            var stagingSrcDirectory = $"{mawscSettings.StagingFetchDirectory}{mawscSettings.RepositorySrcDirectory}";

            Du.WithDirectory.RefreshRecursively(mawscSettings.StagingTestingDirectory);

            Du.WithDirectory.MoveRecursively(stagingSrcDirectory, mawscSettings.StagingTestingDirectory);
        }

        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        private static void Minimal(MawscSettings mawscSettings)
        {
            var stagingSrcDirectory = $"{mawscSettings.StagingFetchDirectory}{mawscSettings.RepositorySrcDirectory}";

            Du.WithDirectory.RefreshRecursively(mawscSettings.StagingTestingDirectory);

            Du.WithDirectory.CopyRecursively($"{stagingSrcDirectory}bin/", $"{mawscSettings.StagingTestingDirectory}bin/");

            var filesToCopy = new List<string>()
            {
                $"{mawscSettings.RepositoryName}.asmx",
                $"{mawscSettings.RepositoryName}.asmx.cs",
                $"packages.config",
                $"Web.config",
                $"Web.Debug.config",
                $"Web.Release.config",
            };

            Du.WithFile.CopyFiles(filesToCopy, stagingSrcDirectory, mawscSettings.StagingTestingDirectory);
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