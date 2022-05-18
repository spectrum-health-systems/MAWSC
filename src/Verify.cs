// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Utility.Verify.cs
// Verify and validate variouse data.
// b220518.115916

namespace MAWSC
{
    internal class Verify
    {
        /// <include file='MawscDoc.xml' path='doc/verify[@name="Requirements"]/*' />
        internal static void Requirements(string[] commandLineArguments)
        {
            MAWSC.Configuration.Validate();
            MAWSC.Verify.ArgumentsPassed(commandLineArguments);
            MAWSC.Verify.DirectoriesExist();
        }

        /// <include file='MawscDoc.xml' path='doc/verify[@name="Arguments"]/*' />
        private static void ArgumentsPassed(string[] commandLineArguments)
        {
            if(commandLineArguments.Length == 0)
            {
                var logNoArgumentsPassedMessage = MAWSC.Log.Component.CommandLineArgumentsMissing();
                MAWSC.Log.Export.ToConsole(logNoArgumentsPassedMessage);
                MAWSC.Maintenance.Finalize(1);
            }
        }

        /// <include file='MawscDoc.xml' path='doc/verify[@name="DirectoriesExist"]/*' />
        private static string DirectoriesExist()
        {
            var mawscConfiguration = MAWSC.Configuration.Load();

            var requiredDirectories = new List<string>
            {
                mawscConfiguration.ConfigurationDirectory,
                mawscConfiguration.LogDirectory,
                mawscConfiguration.BackupDirectory,
                mawscConfiguration.TemporaryDirectory
            };

            var logSubHeader = MAWSC.Log.Component.SubHeader("Verifying required directories");
            var logContent   = "";

            /* The majority of MAWSC logging is taken care of by MAWS.Log.Components.cs, but
             * since this update is just via the console, we'll take care of logging directly.
             */
            foreach(var requiredDirectory in requiredDirectories)
            {
                if(!Directory.Exists(requiredDirectory))
                {
                    logContent += $"{requiredDirectory} does not exist.{Environment.NewLine}";
                    _=Directory.CreateDirectory(requiredDirectory);
                    logContent += $"{requiredDirectory} created.{Environment.NewLine}";
                }
                else
                {
                    logContent += $"{requiredDirectory} exists.{Environment.NewLine}";
                }
            }

            return $"{logSubHeader}" +
                   $"{logContent}";
        }
    }
}