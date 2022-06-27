// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Help.HelpComponent.cs
// Help components.
// b220617.080310
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documentation/Sourcecode/MAWSC-Sourcecode.md

namespace MAWSC.Help
{
    internal class HelpComponent
    {
        /// <summary>Create the log message master header.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         - The master header string is at the top of each logfile, and always contains the same information.
        ///     </para> 
        /// </remarks>
        /// <returns>Header string for log files.</returns>
        internal static string HelpHeader(string helpSubText)
        {
            return $"----------------------------------------{Environment.NewLine}" +
                   $"MAWSC HELP {Environment.NewLine}" +
                   $"----------------------------------------{Environment.NewLine}" +
                   $"{helpSubText}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        internal static string UsageSyntaxHelp(string usageLine)
        {
            return $"usage: mawsc {usageLine}{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        internal static string DefaultHelp()
        {
            return $"commands:{ Environment.NewLine}" +
                   $"    -c, -configuration     Configuration file{ Environment.NewLine}" +
                   $"    -h, -help              Display this help screen{ Environment.NewLine}" +
                   $"    -s, -staging           Staging environment{ Environment.NewLine}" +
                   $"    -p, -production        Production environment{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"For command-specific help, type \"mawsc -help <command>\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"examples:{ Environment.NewLine}" +
                   $"    \"mawsc -help staging\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"    \"mawsc -help configuration\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        internal static string ConfigurationHelp()
        {
            return $"commands:{ Environment.NewLine}" +
                   $"    -i, -information   View the configuration settings{ Environment.NewLine}" +
                   $"    -r, -reset         Reset the configuration file to default settings{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"examples:{ Environment.NewLine}" +
                   $"    \"mawsc -configuration -i\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"    \"mawsc -c -reset\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        internal static string StagingHelp()
        {
            return $"commands:{ Environment.NewLine}" +
                   $"    -b, -backup        Backup the current staging location{ Environment.NewLine}" +
                   $"    -d, -deploy        Deploy the current staging location to production{ Environment.NewLine}" +
                   $"    -f, -fetch         Fetch staging sourcecode{ Environment.NewLine}" +
                   $"    -i, -information   Display information about the staging environment{ Environment.NewLine}" +
                   $"    -r, -refresh       Backup, fetch, and deploy the staging environment{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"examples:{ Environment.NewLine}" +
                   $"    \"mawsc -staging -b\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"    \"mawsc -s -deploy\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        internal static string ProductionHelp()
        {
            return $"commands:{ Environment.NewLine}" +
                   $"    -b, -backup        Backup the current production location{ Environment.NewLine}" +
                   $"    -i, -information   Display information about the staging environment{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"examples:{ Environment.NewLine}" +
                   $"    \"mawsc -staging -b\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"    \"mawsc -s -information\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks> 
        /// <returns></returns>
        internal static string ExampleHelp()
        {
            return $"examples:{ Environment.NewLine}" +
                   $"    To deploy the staging environment: \"mawsc -s -d\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"    To deploy the production environment: \"mawsc -staging -deploy\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"    To reset the configuration file: \"mawsc -configuration -r\"{ Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        internal static string MoreInformationHelp()
        {
            return $"For more information, please visit: https://github.com/spectrum-health-systems/MAWSC{ Environment.NewLine}";
        }
    }
}