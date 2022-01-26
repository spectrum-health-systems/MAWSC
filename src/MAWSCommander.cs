// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Entry point for MAWSC
// b220126.170648

using MAWSC;

/* Put some space between whatever is currently in the console, and what we will be writing.
 */
Console.WriteLine($"{Environment.NewLine}");

/* There has to be at least one argument passed, otherwise just exit.
 */
if(args.Length == 0)
{
    Log.ToScreen($"[ERROR] No arguments passed (arg[0] does not exist).", true);
    Log.ToFile($"[ERROR] No arguments passed. (arg[0] does not exist)");
    Environment.Exit(1);
}

/* The user can pass arguments as "myarg", "-myarg", or "--myarg", and we'll just turn all of those into "myarg".
 */
var firstArgument = args[0].Trim().ToLower().Replace("-", "");

var logMessage = "";

switch(firstArgument)
{
    case "s":
    case "stage":
    case "staging":
        Log.ToScreen($"[ INFO] Value of arg[0] is valid: \"{args[0]}\" -> \"{firstArgument}\"...");
        logMessage += $"[ INFO] Value of arg[0] is valid: \"{args[0]}\"/\"{firstArgument}\"...{Environment.NewLine}";
        Staging.ParseArguments(args, logMessage);
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
        Log.ToScreen($"[ERROR] Value of Arg[0] is invalid: \"{args[0]}\"/\"{firstArgument}\".", true);
        Log.ToFile($"[ERROR] Value of Arg[0] is invalid: \"{args[0]}\"/\"{firstArgument}\".");
        Environment.Exit(1);
        break;
}