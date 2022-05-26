// =============================================================================
// MAWSC: MyAvatar Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

// MAWSC.Help.Display.cs
// Display help information on the console.
// b220526.080326

namespace MAWSC.Help
{
    internal class Display
    {
        internal static void Complete()
        {
            Console.Clear();

            var helpMessage = Component.HelpHeader() +
                              Component.UsageSyntax() +
                              Component.ValidArguments() +
                              Component.Examples() +
                              Component.MoreInformation();

            Console.WriteLine(helpMessage);

            MAWSC.Maintenance.Terminate.Gracefully(0);
        }
    }
}