// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Entry point for MAWSC
// b220127.085201

using MAWSC;

/* Initialize the logMessage for logfiles, and put some space between whatever is currently in the console, and what we
 * will be writing.
 */
var logMessage = Utility.MawscStart();

/* There has to be at least one argument passed, otherwise just exit.
 */
if(args.Length == 0)
{
    var logMsgNoArgs = $"[  ERROR] No arguments passed to MAWSC...[EXITING]{Environment.NewLine}";
    Log.ToScreen(logMsgNoArgs, true);
    Log.WriteToFile(logMsgNoArgs);
    Environment.Exit(1);
}

/* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
 */
var firstArgument = args[0].Trim().ToLower().Replace("-", "");

switch(firstArgument)
{
    case "s":
    case "stage":
    case "staging":
        var logMsgValidArg0 = $"[  CHECK] Value of arg[0] is valid: \"{args[0]}\"...[     OK]{Environment.NewLine}";
        logMessage = Log.AppendAndDisplay(logMessage, logMsgValidArg0);

        //var logMsgValidArg0 = $"[  CHECK] Value of arg[0] is valid: \"{args[0]}\"...[     OK]{Environment.NewLine}";
        //Log.ToScreen(logMsgValidArg0);
        //logMessage += logMsgValidArg0;


        Staging.ParseArguments(args, logMessage);
        Utility.MawscFinish(logMessage);
        break;

    case "p":
    case "prod":
    case "production":
        //Production.ParseArguments(args)
        break;

    case "h":
    case "help":
        //Help.Display()
        break;

    default:
        var logMsgInvalidArg0 = $"[  ERROR] Value of Arg[0] is invalid: \"{args[0]}\"...[EXITING]{Environment.NewLine}";
        Log.ToScreen(logMsgInvalidArg0, true);
        Utility.MawscFinish(logMessage);
        break;
}