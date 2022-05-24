namespace MAWSC.Framework
{
    internal class Refresh
    {
        internal static void Directories(MAWSC.Configuration.Settings mawscSettings)
        {
            Du.WithDirectory.RefreshRecursively(mawscSettings.TemporaryDirectory);
        }
    }
}
