// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

namespace MAWSC.Staging
{
    internal class Deploy
    {
        internal static void All(MAWSC.Configuration.Settings mawscSettings)
        {
            var stagingSrcDirectory = $"{mawscSettings.StagingSourceDirectory}{mawscSettings.RepositorySrcDirectory}";

            Du.WithDirectory.RefreshRecursively(mawscSettings.StagingTargetDirectory);

            Du.WithDirectory.MoveRecursively(stagingSrcDirectory, mawscSettings.StagingTargetDirectory);
        }
    }
}
