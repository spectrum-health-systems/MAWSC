// MAWSC - MAWS Commander: Command-line utilities for MAWS
// https://github.com/aprettycoolprogram/MAWSC
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// Version 1.0.3
//
// Entry point for MAWS Commander.
// b220131.115810

/* ====================
 * ABOUT MAWS COMMANDER
 * ====================
 * 
 * MAWS Commander (MAWSC) is a command-line utility for the MyAvatool Web Service (MAWS).
 * 
 * --------------------
 * HOW TO USE
 * --------------------
 * To use MAWSC, type "MAWSC" at the command-line, and pass a minimum of two arguments, a "command" and an "action". For
 * example, to update the MAWS Staging environment on the IIS server with the current sourcode on GitHub:
 * 
 *      $ MAWSC -staging -deploy
 *      
 * To display MAWS Commander help on the console, type:
 * 
 *      $ MAWSC -help
 *      
 * To learn more about how to use MAWS Commander, please read the MAWS Commander Manual:
 * 
 *      http://link
 *      
 * ---------------------
 * NOTES ABOUT THIS CODE
 * ---------------------
 * The MAWS Commander sourcecode is heavily commented, sometimes even in places where it is very clear as to what the
 * code does. Since this code may be used/modified by other organizations, I want to make sure that everything is
 * crystal clear.
 * 
 * Also, I'm passing the "logContent" variable by reference, which is less than ideal from a "best practice" point of
 * view. But since logContent is modified *a lot*, and in a linear manner, it ends up being cleaner (to me) than passing
 * it as a value (then returning it each time), or using a global.
 */

using MAWSC;

/* Initialize some things, and since well be passing args[] around, give it a nice name so we remember what it is.
 */
var passedArgs = args;
var logContent = "";

Utility.MawscStart(ref logContent);

/* There has to be at least one argument, otherwise we can't do anything, so just exit.
 */
if(passedArgs.Length == 0)
{
    Log.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"No arguments passed to MAWSC", "INVALID");
    Utility.MawscFinish(logContent, 1);
}

/* The MAWSC "command" is the first argument that is passed when MAWSC is executed, so let's make it easy to work with.
 */
var mawscCommand = Utility.ReduceArg(passedArgs[0]);

/* Give the users a little wiggle room when typing commands, this way they can use shorthand if they want.
 */
switch(mawscCommand)
{
    case "s":
    case "stage":
    case "staging":
        /* We're going to do something with the MAWS Staging environment!
         */
        Log.AppendAndShowMsg(ref logContent, "[ CHECK] ", $"Arg[0] \"{passedArgs[0]}\"", "VALID");
        Staging.ParseArgs(ref logContent, passedArgs);
        Utility.MawscFinish(logContent, 0);
        break;

    case "p":
    case "prod":
    case "production":
        /* We're going to do something with the MAWS Staging environment! - Future functionality
         */
        break;

    case "h":
    case "help":
        /* We're going to do something with the MAWS Commander Help! - Future functionality
         */
        break;

    default:
        /* An invalid MAWSC command was sent, so just exit.
         */
        Log.AppendAndShowMsg(ref logContent, "[  ERROR] ", $"Arg[0] \"{passedArgs[0]}\"", "INVALID");
        Utility.MawscFinish(logContent, 1);
        break;
}