﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.StagingInformation.cs
// Get information about the staging source.
// b220531.110901

using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class StagingInformation
    {
        internal static void Display(MawscSettings mawsc)
        {
            var stagingInformation = $"Current staging information:" +
                                     $"Name: {mawsc.RepositoryName}{Environment.NewLine}" +
                                     $"Branch: {mawsc.RepositoryBranch} mmddyy hh:mm:ss{Environment.NewLine}" +
                                     $"Version: mmddyy hh:mm:ss{Environment.NewLine}" +
                                     $"Last fetched: mmddyy hh:mm:ss{Environment.NewLine}" +
                                     $"Last deployed: mmddyy hh:mm:ss{Environment.NewLine}" +
                                     $"Last logfile timestamp: mmddyy hh:mm:ss{Environment.NewLine}" +
                                     $"Logfile directory size: XXXMB{Environment.NewLine}" +
                                     $"Fetch location directory: {mawsc.StagingFetchDirectory} /path/to/{Environment.NewLine}" +
                                     $"Testing location directory: {mawsc.StagingTestingDirectory} /path/to/{Environment.NewLine}" +
                                     $"Deployment location directory: {mawsc.ProductionDirectory}{Environment.NewLine}" +
                                     $"{Environment.NewLine}";
        }
    }
}
