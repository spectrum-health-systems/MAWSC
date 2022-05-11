// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Utility.MawscStatus.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220509.112813

/* =============================================================================
 * About this class
 * =============================================================================
 * Logic for MAWSC status changes.
 */

namespace MAWSC.Utility
{
    internal class MawscStatus
    {
        ///////// <summary>
        ///////// 
        ///////// </summary>
        ///////// <param name="logContent"></param>
        //////internal static Configuration Start()
        //////{
        //////    var mawscConfiguration = MAWSC.Configuration.Load();

        //////    var logMessageStart               = Log.Content.StartMessage();
        //////    var logMessageConfigurationInfo   = MAWSC.Log.Content.ConfigurationInfo(mawscConfiguration);
        //////    var logMessageRequiredDirectories = MAWSC.Utility.Verify.RequiredDirectories(mawscConfiguration);

        //////    var logMessage = $"{logMessageStart}{Environment.NewLine}" +
        //////                     $"{logMessageConfigurationInfo}{Environment.NewLine}" +
        //////                     $"{logMessageRequiredDirectories}{Environment.NewLine}";

        //////    Log.Export.ToEverywhere(logMessage.Trim(), mawscConfiguration.LogfilePath);

        //////    return mawscConfiguration;
        //////}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="exitCode"></param>
        internal static void End(string logContent, int exitCode)
        {
            /* Since this is the last thing MAWS Commander does, we don't pass logContent as a reference. Also, if you
             * pass anything other than a "0" (no errors) for exitCode, the "Type MAWSC -help" stuff will be included
             * in logContent and displayed on the console.
             */

            //MAWSC.Logging.Content.BuildEndMessage(logContent, exitCode);
            Environment.Exit(exitCode);
        }
    }
}