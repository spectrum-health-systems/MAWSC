

namespace MAWSC.Utility
{
    internal class Maintenance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        internal static void Initialize(Configuration mawscConfiguration, string[] commandLineArguments)
        {
            var logHeader = MAWSC.Log.Component.Header();
            Log.Export.ToEverywhere(logHeader, mawscConfiguration.LogfilePath);

            var logCommandLineArguments = MAWSC.Log.Component.CommandLineArguments(commandLineArguments);
            Log.Export.ToEverywhere(logCommandLineArguments, mawscConfiguration.LogfilePath);

            var logConfigurationInfo = MAWSC.Log.Component.ConfigurationInfo(mawscConfiguration);
            Log.Export.ToEverywhere(logConfigurationInfo, mawscConfiguration.LogfilePath);

            var logRequiredDirectories = MAWSC.Utility.Verify.RequiredDirectories(mawscConfiguration);
            Log.Export.ToEverywhere(logRequiredDirectories, mawscConfiguration.LogfilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawscConfiguration"></param>
        internal static void Finalize(int exitCode)
        {
            Console.WriteLine($">>> MAWSC Exiting...[EXIT CODE {exitCode}]{Environment.NewLine}{Environment.NewLine}");
            Environment.Exit(exitCode);
        }
    }
}
