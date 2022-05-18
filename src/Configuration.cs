// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.cs
// Partial class that contains general logic for MAWSC.Configuration.cs.
// b220518.115916

using System.Reflection;

namespace MAWSC
{
    internal partial class Configuration
    {
        /// <include file='MawscDoc.xml' path='doc/configuration[@name="Validate"]/*' />
        internal static void Validate()
        {
            var configurationFile  = MAWSC.Configuration.GetDefaultFilePath();

            if(!File.Exists($@"{configurationFile}"))
            {
                MAWSC.Configuration.Action.Reset();
            }
            else
            {
                var fileContents = File.ReadAllLines(configurationFile);

                var fileEnclosureValid = fileContents[0] == "{" && fileContents[^1] == "}";

                if(!fileEnclosureValid || fileContents.Length < 5)
                {
                    MAWSC.Configuration.Action.Reset();
                }
            }
        }

        /// <include file='MawscDoc.xml' path='doc/configuration[@name="Load"]/*' />
        internal static Configuration Load()
        {
            var configurationFile = GetDefaultFilePath();

            if(!File.Exists($@"{configurationFile}"))
            {
                MAWSC.Configuration.Action.Reset();
            }

            Configuration mawscConfiguration = Du.WithJson.DeserializeFromFile<Configuration>(configurationFile);

            mawscConfiguration.SessionTimestamp   = DateTime.Now.ToString("MMddyy-HHmmss");
            mawscConfiguration.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawscConfiguration.LogfilePath        = $"{mawscConfiguration.LogDirectory}mawsc-{mawscConfiguration.SessionTimestamp}.log";

            return mawscConfiguration;
        }

        /// <include file='MawscDoc.xml' path='doc/configuration[@name="ProcessAction"]/*' />
        internal static void ProcessAction(string mawscAction, string mawscOption, Configuration mawscConfiguration)
        {
            if(mawscConfiguration.ValidActions.Contains(mawscAction))
            {
                switch(mawscAction)
                {
                    case "r":
                    case "reset":
                        Configuration.Action.Reset();
                        MAWSC.Maintenance.Finalize(0);
                        break;

                    default:
                        // Catch here.
                        break;
                }
            }
        }

        /// <include file='MawscDoc.xml' path='doc/configuration[@name="GetDefaultFilePath"]/*' />
        private static string GetDefaultFilePath()
        {
            return $@"./AppData/Config/mawsc-config.json";
        }
    }
}