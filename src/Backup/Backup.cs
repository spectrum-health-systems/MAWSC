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
