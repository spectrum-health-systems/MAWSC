using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class CleanStaging
    {
        internal static void FetchLocation(MawscSettings mawscSettings)
        {
            Du.WithDirectory.RefreshRecursively(mawscSettings.StagingFetchDirectory);
        }
    }
}
