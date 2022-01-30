// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Entry point for MAWS Commander.
// b20130.101224

/* ====================
 * About MAWS Commander
 * ====================
 */

using MAWSC;

var passedArgs = args;
var logContent = "";

Utility.MawscStart(ref logContent);

if(passedArgs.Length == 0)
{
    /* There has to be at least one argument, otherwise we can't do anything, so just exit.
     */
    Log.AppendAndShow(ref logContent, "[  ERROR] ", $"No arguments passed to MAWSC", "INVALID");
    Utility.MawscFinish(logContent, 1);
}

var mawscPrime = Utility.ReduceArg(passedArgs[0]);

switch(mawscPrime)
{
    case "s":
    case "stage":
    case "staging":
        Log.AppendAndShow(ref logContent, "[ CHECK] ", $"Arg[0] \"{passedArgs[0]}\"", "VALID");
        Staging.ParseArgs(ref logContent, passedArgs);
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
        Log.AppendAndShow(ref logContent, "[  ERROR] ", $"Arg[0] \"{passedArgs[0]}\"", "INVALID");
        Utility.MawscFinish(logContent, 1);
        break;
}