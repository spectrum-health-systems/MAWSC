namespace MAWSC.Argument
{
    internal class Validate
    {
        /// <summary></summary>
        /// <param name="mawscSettings"></param>
        /// <returns></returns>
        internal static bool AreValid(MAWSC.Configuration.Settings mawscSettings)
        {
            return mawscSettings.ValidCommands.Contains(mawscSettings.MawscCommand)
                && mawscSettings.ValidActions.Contains(mawscSettings.MawscAction)
                && mawscSettings.ValidOptions.Contains(mawscSettings.MawscOption);
        }
    }
}
