namespace MAWSC.Validate
{
    internal class MawscCommand
    {
        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        /// <returns></returns>
        internal static bool IsValid(MAWSC.Configuration.Settings mawscSettings)
        {
            return mawscSettings.ValidCommands.Contains(mawscSettings.MawscCommand);
        }

    }
}
