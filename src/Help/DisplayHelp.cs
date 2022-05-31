// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Help.DisplayHelp.cs
// Display help information on the console.
// b220531.093936 x

using MAWSC.Maintenance;

namespace MAWSC.Help
{
    internal class DisplayHelp
    {
        /// <summary>
        /// 
        /// </summary>
        internal static void Complete()
        {
            Console.Clear();

            var helpMessage = HelpComponent.HelpHeader() +
                              HelpComponent.UsageSyntaxHelp() +
                              HelpComponent.ValidArgumentHelp() +
                              HelpComponent.ExampleHelp() +
                              HelpComponent.MoreInformationHelp();

            Console.WriteLine(helpMessage);

            MawscTerminate.Gracefully(0);
        }
    }
}