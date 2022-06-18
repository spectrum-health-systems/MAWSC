// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.StagingInformation.cs
// Get information about the staging environment.
// b220617.080310
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Manual/MAWSC-Manual.md#sourcecode

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Staging
{
    internal class StagingInformation
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>  
        /// <param name="mawsc"></param>
        internal static void Display(ConfigurationSettings mawsc)
        {
            ExportLog.ToConsole(LogMessage.RequestStagingInformation());
            ExportLog.ToConsole(LogMessage.StagingInformation(mawsc));
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>  
        /// <param name="mawsc"></param>
        /// <returns></returns>
        internal static string GetWebServiceVersion(ConfigurationSettings mawsc)
        {
            var assemblyVersion = "unknown";

            var assemblyInfoPath = $"{mawsc.StagingFetchDirectory}Properties/AssemblyInfo.cs";

            if (File.Exists(assemblyInfoPath))
            {
                var assemblyInfo = File.ReadAllLines(assemblyInfoPath);

                foreach (var line in assemblyInfo)
                {
                    if (line.StartsWith("[assembly: AssemblyVersion"))
                    {
                        var start = line.IndexOf("\"");
                        var sub = line.Substring(start + 1);
                        var end = sub.IndexOf("\"");
                        assemblyVersion = sub.Substring(0, end);
                    }
                }
            }

            return assemblyVersion;
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>  
        /// <param name="mawsc"></param>
        /// <returns></returns>
        internal static string GetLastFetchedTimestamp(ConfigurationSettings mawsc)
        {
            var lastFetchedDate = "unknown";

            if (Directory.Exists(mawsc.StagingFetchDirectory))
            {
                lastFetchedDate = Directory.GetCreationTime(mawsc.StagingFetchDirectory).ToString();

            }

            return lastFetchedDate;
        }
    }
}