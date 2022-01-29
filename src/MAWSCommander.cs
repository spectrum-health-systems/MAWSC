// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Entry point for MAWSC
// bb220129.142505

using MAWSC;

/* Initialize the logMessage for logfiles, and put some space between whatever is currently in the console, and what we
 * will be writing.
 */
var logMessage = Utility.MawscStart();

/* There has to be at least one argument passed, otherwise just exit.
 */
if(args.Length == 0)
{
    logMessage = Log.AppendAndDisplay(logMessage, "[  ERROR] ", $"No arguments passed to MAWSC", "INVALID", true);
    Utility.MawscFinish(logMessage);
}

/* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
 */
var firstArgument = args[0].Trim().ToLower().Replace("-", "");

switch(firstArgument)
{
    case "s":
    case "stage":
    case "staging":
        logMessage = Log.AppendAndDisplay(logMessage, "[ CHECK] ", $"Arg[0] \"{args[0]}\"", "VALID");
        Staging.ParseArguments(args, logMessage);
        Utility.MawscFinish(logMessage, 0);
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
        logMessage = Log.AppendAndDisplay(logMessage, "[  ERROR] ", $"Arg[0] \"{args[0]}\"", "INVALID", true);
        Utility.MawscFinish(logMessage);
        break;
}