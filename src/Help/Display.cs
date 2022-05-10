// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Help.Display.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025

/* =============================================================================
 * About this class
 * =============================================================================
 * Displays help information.
 */

using System.Reflection;

namespace MAWSC.Help
{
    internal class Display
    {
        /// <summary>
        /// 
        /// </summary>
        internal static void OnCommandLine()
        {
            Version mawscVersion = Assembly.GetEntryAssembly().GetName().Version;

            var helpMessage = $"{Environment.NewLine}" +
                              $"================================================================================{ Environment.NewLine}" +
                              $"MAWSC {mawscVersion} HELP{Environment.NewLine}" +
                              $"================================================================================{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"usage: mawsc <command> [action] [option]{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"commands:{ Environment.NewLine}" +
                              $"    -s, -stage   Staging environment{ Environment.NewLine}" +
                              $"    -p, -prod    Production environment{ Environment.NewLine}" +
                              $"    -c, -config  Configuration file{ Environment.NewLine}" +
                              $"    -h, -help    Display this help screen{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"actions:{ Environment.NewLine}" +
                              $"    -d, -deploy  Deploy a specific environment{ Environment.NewLine}" +
                              $"    -r, -reset   Reset a specific component{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"examples:{ Environment.NewLine}" +
                              $"    To deploy the staging environment: \"mawsc -s -d\"{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"    To deploy the production environment: \"mawsc -prod -deploy\"{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"    To reset the configuration file: \"mawsc -config -r\"{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"For more information, please visit:{ Environment.NewLine}" +
                              $"    https://github.com/spectrum-health-systems/MAWSC" +
                              $"{Environment.NewLine}" +
                              $"{Environment.NewLine}";

            Console.WriteLine(helpMessage);
        }
    }
}