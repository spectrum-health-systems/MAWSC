// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Staging.BackupStaging.cs
// Backup the current staging source.
// b220608.151504

using MAWSC.Configuration;
using MAWSC.Logging;

namespace MAWSC.Staging
{
    internal class BackupStaging
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <param name="mawsc"></param>
        internal static void SoupToNuts(ConfigurationSettings mawsc)
        {
            SourceLocation(mawsc);
            TargetLocation(mawsc);
        }

        /// <summary>Backup the existing staging source location.</summary>
        /// <remarks>
        ///     <para>
        ///         - When you fetch a sourcecode from GitHub, that sourcecode is saved to the StagingSource. We want to back that up prior to fetching new sourcecode, in the event something goes wrong.
        ///     </para>
        /// </remarks>
        /// <param name="mawsc">MAWSC settings.</param>
        private static void SourceLocation(ConfigurationSettings mawsc)
        {
            ExportLog.ToConsole(LogMessage.RequestBackupStagingSource());
            ExportLog.ToConsole(LogMessage.BackupStagingSource(mawsc.StagingFetchDirectory, mawsc.SessionBackupDirectory));

            Du.WithArchive.DirectoryAsFullname(mawsc.StagingFetchDirectory, mawsc.SessionBackupDirectory);
        }

        /// <summary>Backup the existing staging target location.</summary>
        /// <remarks>
        ///     <para>
        ///         - When you deploy sourcecode from StagingSource, that sourcecode is copied to the StagingTarget. We want to back that up prior to fetching new sourcecode, in the event something goes wrong.
        ///     </para>
        /// </remarks>
        /// <param name="mawsc">MAWSC settings.</param>
        private static void TargetLocation(ConfigurationSettings mawsc)
        {
            ExportLog.ToConsole(LogMessage.RequestBackupStagingTarget());
            ExportLog.ToConsole(LogMessage.BackupStagingTarget(mawsc));

            Du.WithArchive.DirectoryAsFullname(mawsc.StagingTestingDirectory, mawsc.SessionBackupDirectory);
        }
    }
}
