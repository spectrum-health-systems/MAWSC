namespace MAWSC.Staging
{
    internal class Validate
    {
        internal static bool IsValid(MAWSC.Configuration.Settings mawscSettings)
        {
            return mawscSettings.ValidActions.Contains(mawscSettings.MawscAction);
        }
    }
}
