﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.StagingInformation.cs
// Get information about the staging environment.
// b220603.190907

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Staging
{
    internal class StagingInformation
    {
        /// <summary></summary>
        /// <param name="mawsc"></param>
        internal static void Display(MawscSettings mawsc)
        {
            ExportLog.ToConsole(LogMessage.RequestStagingInformation());
            ExportLog.ToConsole(LogMessage.StagingInformation(mawsc));
        }

        /// <summary></summary>
        /// <param name="mawsc"></param>
        /// <returns></returns>
        internal static string GetWebServiceVersion(MawscSettings mawsc)
        {
            var assemblyVersion = "unknown";

            var assemblyInfoPath = $"{mawsc.StagingFetchDirectory}Properties/AssemblyInfo.cs";

            if(File.Exists(assemblyInfoPath))
            {
                var assemblyInfo = File.ReadAllLines(assemblyInfoPath);

                foreach(var line in assemblyInfo)
                {
                    if(line.StartsWith("[assembly: AssemblyVersion"))
                    {
                        var start = line.IndexOf("\"");
                        var sub = line.Substring(start +1);
                        var end = sub.IndexOf("\"");
                        assemblyVersion = sub.Substring(0, end);
                    }
                }
            }

            return assemblyVersion;
        }

        /// <summary></summary>
        /// <param name="mawsc"></param>
        /// <returns></returns>
        internal static string GetLastFetchedTimestamp(MawscSettings mawsc)
        {
            var lastFetchedDate = "unknown";

            if(Directory.Exists(mawsc.StagingFetchDirectory))
            {
                lastFetchedDate = Directory.GetCreationTime(mawsc.StagingFetchDirectory).ToString();

            }

            return lastFetchedDate;
        }
    }
}
