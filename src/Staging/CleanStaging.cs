using MAWSC.Configuration;

namespace MAWSC.Staging
{
    internal class CleanStaging
    {
        internal static void FetchLocation(MawscSettings mawsc)
        {
            Du.WithDirectory.RefreshRecursively(mawsc.StagingFetchDirectory);
        }
    }
}
