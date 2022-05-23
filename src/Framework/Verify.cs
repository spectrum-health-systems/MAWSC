// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Framework.Verify.cs
// Verify framework components.
// b220523.131302 -


namespace MAWSC.Framework
{
    internal class Verify
    {
        /// <summary>Verify that required directories exist, and create them if they don't.</summary>
        /// <returns>Log message.</returns>
        internal static string Directories(MAWSC.Configuration.Settings mawscSettings)
        {
            //var mawscConfiguration = MAWSC.Configuration.Load.FromFile();

            var requiredDirectories = new List<string>
            {
                mawscSettings.ConfigurationDirectory,
                mawscSettings.LogDirectory,
                mawscSettings.BackupDirectory,
                mawscSettings.TemporaryDirectory
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
