﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Configuration.MawscSettings.cs
// Setting properties
// b220617.080310
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Manual/MAWSC-Manual.md#sourcecode

using System.Reflection;

namespace MAWSC.Configuration
{
    internal class ConfigurationSettings
    {
        public string SessionTimestamp { get; set; }
        public string ApplicationVersion { get; set; }
        public string ConfigurationDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string SessionLogfilePath { get; set; }
        public string BackupDirectory { get; set; }
        public string SessionBackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }
        public string RepositoryLocation { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryBranch { get; set; }
        public string RepositoryZipUrl { get; set; }
        public string StagingFetchDirectory { get; set; }
        public string StagingTestingDirectory { get; set; }
        public string ProductionDirectory { get; set; }
        public string MawscCommand { get; set; }
        public string MawscAction { get; set; }
        public string MawscOption { get; set; }

        /// <summary>Get the MAWSC configuration settings for the session.</summary>
        /// <param name="arguments">Arguments passed via the command line.</param>
        /// <param name="sessionTimestamp">Session timestamp created at execution.</param>
        /// <returns>MAWSC configuration settings.</returns>
        internal static ConfigurationSettings Initialize(string[] arguments, string sessionTimestamp)
        {
            ConfigurationSettings mawsc = ConfigurationFile.Load();

            mawsc = GetRuntimeValues(mawsc, arguments, sessionTimestamp);

            return mawsc;
        }

        ///// <summary>Load MAWSC configuration settings from the configuration file.</summary>
        ///// <returns>Configuration settings.</returns>
        //internal static ConfigurationSettings LoadFromFile()
        //{
        //    var configurationFile = ConfigurationSettings.GetDefaultFilePath();

        //    if (!File.Exists($@"{configurationFile}"))
        //    {
        //        ConfigurationAction.ResetFile();
        //    }

        //    ConfigurationSettings mawscSettings = Du.WithJson.DeserializeFromFile<ConfigurationSettings>(configurationFile);

        //    return mawscSettings;
        //}

        ///// <summary>Get the MAWSC configuration default filepath.</summary>
        ///// <remarks>
        /////     <para>
        /////         <b><u>NOTES</u></b><br/>   
        /////         - It is recommended that you leave the default filepath as <i>./AppData/Config/mawsc-config.json</i>.
        /////     </para>
        ///// </remarks>
        ///// <returns>Default configuration file path.</returns>
        //internal static string GetDefaultFilePath()
        //{
        //    return $@"./AppData/Config/mawsc-config.json";
        //}

        /// <summary>Get a few session-specific settings.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - Load default settings from the external file.<br/>
        ///         - Set some runtime-specific values.
        ///     </para>
        /// </remarks>
        /// <param name="mawsc"></param>
        /// <param name="arguments"></param>
        /// <param name="sessionTimestamp"></param>
        /// <returns></returns>
        internal static ConfigurationSettings GetRuntimeValues(MAWSC.Configuration.ConfigurationSettings mawsc, string[] arguments, string sessionTimestamp)
        {
            mawsc.SessionTimestamp = sessionTimestamp;
            mawsc.ApplicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            mawsc.SessionLogfilePath = $"{mawsc.LogDirectory}mawsc-{mawsc.SessionTimestamp}.log";
            mawsc.SessionBackupDirectory = $"{mawsc.BackupDirectory}{mawsc.SessionTimestamp}";
            mawsc.RepositoryZipUrl = $"{mawsc.RepositoryLocation}{mawsc.RepositoryName}/archive/refs/heads/{mawsc.RepositoryBranch}.zip";

            var mawscArguments = CommandLine.Arguments.GetIndividualArguments(arguments);

            mawsc.MawscCommand = mawscArguments["mawscCommand"];
            mawsc.MawscAction = mawscArguments["mawscAction"];
            mawsc.MawscOption = mawscArguments["mawscOption"];

            return mawsc;
        }

        ///// <summary>Verify a valid configuration file exists.</summary>
        ///// <remarks>
        /////     <para>
        /////         Recreate./AppData/Config/mawsc-config.json if the file:
        /////         <list type ="bullet">
        /////             <item>
        /////                 <term>Does not exist</term>
        /////                 <description>The configuration file is required.</description>
        /////             </item>
        /////             <item>
        /////                 <term>Is not enclosed properly</term>
        /////                 <description>JSON formatted files are enclosed in brackets, so if the configuration file doesn't start with a <b>{</b> and end with a <b>}</b>, it's not valid JSON data.JSON formatted files are enclosed in brackets, so if the configuration file doesn't start with a <b>{</b> and end with a <b>}</b>, it's not valid JSON data.</description>
        /////             </item>
        /////             <item>
        /////                 <term>Is too short</term>
        /////                 <description>There are at least 5 configuration settings, so if the configuration file must contain more than 5 lines.</description>
        /////             </item>
        /////         </list>
        /////     </para>
        /////     <para>
        /////         - This is a quick-and-dirty test!
        /////     </para> 
        ///// </remarks>
        //internal static void FileData()
        //{
        //    var configurationFilePath = ConfigurationFile.GetDefaultFilePath();

        //    if (!File.Exists($@"{configurationFilePath}"))
        //    {
        //        ExportLog.ToConsole(Logging.LogMessage.ConfigurationFileNotFound());
        //        ConfigurationAction.ResetFile();
        //    }
        //    else
        //    {
        //        var fileContents = File.ReadAllLines(configurationFilePath);
        //        var fileEnclosureValid = fileContents[0] == "{" && fileContents[^1] == "}";

        //        if (!fileEnclosureValid || fileContents.Length < 5)
        //        {
        //            ExportLog.ToConsole(Logging.LogMessage.ConfigurationFileInvalid());
        //            ConfigurationAction.ResetFile();
        //        }
        //    }
        //}
    }
}

/*
  "RepositoryName": "MAWS",
  "RepositoryUrl": "https://github.com/spectrum-health-systems/MAWS/archive/refs/heads/v0.60-development.zip",
  "RepositorySrcDirectory": "MAWS-0.60-development/src/",
  "StagingSourceDirectory": "./AppData/Staging_source/",
  "StagingTargetDirectory": "c:/Users/cbanw/Downloads/mawstest/",
*/