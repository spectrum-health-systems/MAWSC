// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Roundhouse.cs
// UPDATED: 220513.093416
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

/* =============================================================================
 * About this class
 * =============================================================================
 * MAWSC roundhouse
 */

namespace MAWSC
{
    internal class Roundhouse
    {
        ///// <summary>
        ///// Process passed command line arguments
        ///// </summary>
        ///// <param name="commandLineArguments"></param>
        //internal static void Process(string[] commandLineArguments)
        //{
        //    var mawscConfiguration = MAWSC.Configuration.Load();
        //    var mawscArguments     = MAWSC.CommandLine.GetArgumentValues(commandLineArguments);

        //    var commandIsValid = MAWSC.Argument.Command.Validate(mawscArguments["mawscCommand"], mawscConfiguration.ValidCommands);

        //    if(commandIsValid)
        //    {
        //        MAWSC.Argument.Command.Process(mawscArguments, mawscConfiguration);
        //    }
        //    else
        //    {
        //        InvalidCommand(mawscArguments["mawscCommand"]);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mawscCommand"></param>
        ///// <param name="mawscConfiguration"></param>
        //private static void ProcessCommand(Dictionary<string, string> mawscArguments, Configuration mawscConfiguration)
        //{
        //    /* If the "help" argument was passed, show the help screen and exit.
        //     */
        //    if(mawscArguments["mawscCommand"].StartsWith("h"))
        //    {
        //        MAWSC.Help.Display.OnCommandLine();
        //        MAWSC.Maintenance.Finalize(0);
        //    }
        //    else
        //    {
        //        MAWSC.Maintenance.Initialize(mawscArguments, mawscConfiguration);

        //        if(mawscArguments["mawscCommand"].StartsWith("c"))
        //        {
        //            MAWSC.Configuration.ProcessAction(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);
        //        }
        //        else if(mawscArguments["mawscCommand"].StartsWith("p"))
        //        {
        //            CommandProduction(mawscConfiguration);
        //        }
        //        else if(mawscArguments["mawscCommand"].StartsWith("s"))
        //        {
        //            //CommmandStaging(mawscArguments["mawscAction"], mawscArguments["mawscOption"], mawscConfiguration);
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        //private static void CommandHelp()
        //{
        //    MAWSC.Help.Display.OnCommandLine();
        //    MAWSC.Maintenance.Finalize(0);
        //}

        //private static void InvalidCommand(string mawscCommand)
        //{
        //    var logInvalidCommandPassed = MAWSC.Log.Component.InvalidCommandPassed(mawscCommand);
        //    Console.WriteLine(logInvalidCommandPassed);
        //    MAWSC.Maintenance.Finalize(2);
        //}


        /// <summary>
        /// 
        /// </summary>
        ///// <param name="mawscConfiguration"></param>
        //private static void CommandProduction(Configuration mawscConfiguration)
        //{
        //    MAWSC.Maintenance.Finalize(0);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mawscConfiguration"></param>
        //private static void CommmandStaging(string mawscAction, string mawscOption, Configuration mawscConfiguration)
        //{

        //    MAWSC.Staging.Roundhouse.Process(mawscAction, mawscOption, mawscConfiguration);
        //    MAWSC.Maintenance.Finalize(0);
        //}


        /////// <summary>
        /////// 
        /////// </summary>
        /////// <param name="mawscConfiguration"></param>
        ////private static void DefaultFallthrough(Configuration mawscConfiguration)
        ////{
        ////    MAWSC.Configuration.Roundhouse();
        ////}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mawscConfiguration"></param>
        //private static void CommandConfiguration(Configuration mawscConfiguration)
        //{

        //}
    }
}
