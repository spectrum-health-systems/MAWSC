// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Configuration.Properties.cs
// UPDATED: 220518.081922
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* ==========================================================================================-|
 * About this class
 * =============================================================================
 * This is a partial that contains the properties for the MAWSC.Configuration.cs class.
 * 
 * >>> WARNING <<<
 * MAWSC is designed to be portable, so it's highly recommended that you leave these
 * configuration settings at their default! 
 * 
 * The only setting you need to modify for your organization is "ProductionDirectory", and you
 * do that by editing the ./AppData/Config/mawsc-config.json and changing thisline:
 * 
 *      "ProductionDirectory": "<path/to/your/web/service/",
 *      
 * to
 * 
 *      "ProductionDirectory": "path/to/your/production/web/service/>",
 */

namespace MAWSC
{
    internal partial class Configuration
    {
        public string ConfigurationDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string BackupDirectory { get; set; }
        public string TemporaryDirectory { get; set; }
        public string StagingDirectory { get; set; }
        public string ProductionDirectory { get; set; }
        public List<string> ValidCommands { get; set; }
        public List<string> ValidActions { get; set; }
        public List<string> ValidOptions { get; set; }
        public string ApplicationVersion { get; set; }
        public string SessionTimestamp { get; set; }
        public string LogfilePath { get; set; }
    }
}
