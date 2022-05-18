// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Help.Display.cs
// Display help information on the console.
// b220518.115916

namespace MAWSC.Help
{
    internal class Display
    {
        internal static void OnCommandLine()
        {
            var helpHeader  = MAWSC.Log.Component.MasterHeader();
            var helpContent = $"----------{Environment.NewLine}" +
                              $"MAWSC HELP{Environment.NewLine}" +
                              $"----------{Environment.NewLine}" +
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
                              $"For more information, please visit: https://github.com/spectrum-health-systems/MAWSC{ Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"{Environment.NewLine}";

            Console.WriteLine($"{helpHeader}" +
                              $"{helpContent}");
        }
    }
}