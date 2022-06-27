// ========================================[ PROJECT ]=========================================
// DU
// A library for .NET C#
// https://github.com/aprettycoolprogram/du)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// ========================================[ PROJECT ]=========================================

// Du.WithInternet.cs
// Does things with the internet.
// vX.X.X.X-b220526.091354 (standalone version for MAWSC 2.0)

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