// =============================================================================
// MAWSC: MyAvatool Web Service Commander
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================

namespace MAWSC.MawscCommand
{
    internal class Roundhouse
    {
        /// <summary>
        /// wetrw
        /// </summary>
        /// <param name="mawscCommand">tet</param>
        /// <param name="mawscSettings">tet</param>
        internal static void ProcessCommand(MAWSC.Configuration.Settings mawscSettings)
        {
            /* If the "help" argument was passed, show the help screen and exit.
             */
            if(mawscSettings.MawscCommand == "h" || mawscSettings.MawscCommand == "help")
            {
                Help.Display.Complete();

                Terminate.Gracefully(0);
            }
            else
            {
                switch(mawscSettings.MawscCommand)
                {

                }


                ////MAWSC.Maintenance.Initialize(mawscArguments, mawscConfiguration);

                //////if(mawscArguments["mawscCommand"].StartsWith("c"))
                //////{
                //////    MAWSC.Configuration.Roundhouse.ProcessAction(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscSettings);
                //////}
                //////else if(mawscArguments["mawscCommand"].StartsWith("p"))
                //////{
                //////    //CommandProduction(mawscConfiguration);
                //////}
                //////else if(mawscArguments["mawscCommand"].StartsWith("s"))
                //////{
                //////    //MAWSC.Staging.Roundhouse.Process(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);

                //////}
            }
        }
    }
}
