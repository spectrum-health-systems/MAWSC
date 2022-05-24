namespace MAWSC.Du
{
    internal class Internet
    {
        public static void DownloadZipFromUrl(string sourceUrl, string targetFilePath)
        {
            var webClient = new System.Net.WebClient();
            webClient.DownloadFile(sourceUrl, targetFilePath);
        }
    }
}