// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Entry point for MAWS Commander
// b220130.083155

using MAWSC;

/* Initialize the logMessage for logfiles, and put some space between whatever is currently in the console, and what we
 * will be writing.
 */
var logContent = Utility.MawscStart();

/* There has to be at least one argument passed, otherwise exit.e
 */
if(args.Length == 0)
{
    logContent = Log.AppendAndShow(logContent, "[  ERROR] ", $"No arguments passed to MAWSC", "INVALID");
    Utility.MawscFinish(logContent, 1);
}

/* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
 */
var firstArgument = args[0].Trim().ToLower().Replace("-", "");


/* Main logic to determine what needs to be done.
 */
switch(firstArgument)
{
    case "s":
    case "stage":
    case "staging":
        logContent = Log.AppendAndShow(logContent, "[ CHECK] ", $"Arg[0] \"{args[0]}\"", "VALID");
        Staging.ParseArguments(args, logContent);
        Utility.MawscFinish(logContent, 0);
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
        logContent = Log.AppendAndShow(logContent, "[  ERROR] ", $"Arg[0] \"{args[0]}\"", "INVALID");
        Utility.MawscFinish(logContent, 1);
        break;
}