﻿// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Help.DisplayHelp.cs
// Display help information on the console.
// b220615.085103
// https://github.com/spectrum-health-systems/MAWSC/blob/main/doc/Sourcecode/README.md

using MAWSC.Maintenance;

namespace MAWSC.Help
{
    internal class DisplayHelp
    {
        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        internal static void ForDefault()
        {
            Console.Clear();

            var helpMessage = HelpComponent.HelpHeader("") +
                              HelpComponent.UsageSyntaxHelp("<-command> [-action] [-option]") +
                              HelpComponent.DefaultHelp() +
                              HelpComponent.MoreInformationHelp();

            Console.WriteLine(helpMessage);

            MawscTerminate.Gracefully(0);
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        internal static void ForConfiguration()
        {
            Console.Clear();

            var helpHeaderSubText = $"{Environment.NewLine}" +
                                    $"[Configuration command]{Environment.NewLine}" +
                                    $"{ Environment.NewLine}";

            var helpMessage = HelpComponent.HelpHeader(helpHeaderSubText) +
                              HelpComponent.UsageSyntaxHelp("-configuration [-action] [-option]") +
                              HelpComponent.ConfigurationHelp() +
                              HelpComponent.MoreInformationHelp();

            Console.WriteLine(helpMessage);

            MawscTerminate.Gracefully(0);
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        internal static void ForStaging()
        {
            Console.Clear();

            var helpHeaderSubText = $"{Environment.NewLine}" +
                                    $"[Staging command]{Environment.NewLine}" +
                                    $"{ Environment.NewLine}";

            var helpMessage = HelpComponent.HelpHeader(helpHeaderSubText) +
                              HelpComponent.UsageSyntaxHelp("-staging [-action] [-option]") +
                              HelpComponent.StagingHelp() +
                              HelpComponent.MoreInformationHelp();

            Console.WriteLine(helpMessage);

            MawscTerminate.Gracefully(0);
        }

        /// <summary></summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b><br/>
        ///         -
        ///     </para>
        /// </remarks>
        internal static void ForProduction()
        {
            Console.Clear();

            var helpHeaderSubText = $"{Environment.NewLine}" +
                                    $"[Production command]{Environment.NewLine}" +
                                    $"{ Environment.NewLine}";

            var helpMessage = HelpComponent.HelpHeader(helpHeaderSubText) +
                              HelpComponent.UsageSyntaxHelp("-production [-action] [-option]") +
                              HelpComponent.ProductionHelp() +
                              HelpComponent.MoreInformationHelp();

            Console.WriteLine(helpMessage);

            MawscTerminate.Gracefully(0);
        }
    }
}