// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Backup.cs
// Backup stuff.
// b220526.080326

namespace MAWSC
{
    internal class Backup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscSettings"></param>
        internal static void VerifySessionBackupDirectory(MAWSC.Configuration.Settings mawscSettings)
        {
            var sessionBackupDirectory = $"{mawscSettings.BackupDirectory}{mawscSettings.SessionTimestamp}";

            Du.WithDirectory.ConfirmDirectoryExists(sessionBackupDirectory);

            MAWSC.Log.Export.ToConsole(MAWSC.Log.Message.SessionBackupDirectoryVerify());
        }
    }
}
