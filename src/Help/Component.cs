using System.Reflection;

namespace MAWSC.Help
{
    internal class Component
    {
        /// <summary>Create the log message master header.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - The master header string is at the top of each logfile, and always contains the same information.
        ///     </para> 
        /// </remarks>
        /// <returns>Header string for log files.</returns>
        internal static string MasterHeader()
        {
            var applicationVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            var masterHeader = $"========================================{Environment.NewLine}" +
                               $"MAWSC {applicationVersion} HELP{Environment.NewLine}" +
                               $"========================================{Environment.NewLine}";

            return masterHeader;
        }

        /// <summary>Create a log message sub-header.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - The sub-header string is a generic sub-header for log files. Content is determined by the subHeaderText parameter.
        ///     </para>
        /// </remarks>
        /// <returns>Sub-header string for log files.</returns>
        /// <param name="subHeaderText">Sub-header text to be displayed.</param>
        internal static string SubHeader(string subHeaderText)
        {
            return $"----------------------------------------{Environment.NewLine}" +
                   $"{subHeaderText}{Environment.NewLine}" +
                   $"----------------------------------------{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string UsageSyntax()
        {
            return $"{Environment.NewLine}" +
                   $"usage: mawsc <command> [action] [option]{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string Examples()
        {
            return $"{Environment.NewLine}" +
                   $"usage: mawsc <command> [action] [option]{ Environment.NewLine}" +
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
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string MoreInformation()
        {
            return $"For more information, please visit: https://github.com/spectrum-health-systems/MAWSC{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <returns></returns>
        internal static string ValidArguments()
        {
            return $"commands:{ Environment.NewLine}" +
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
        }
    }
}

/*




 */