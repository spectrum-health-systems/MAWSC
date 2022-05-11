﻿// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.MAWSC.cs
// UPDATED: 220511.104821
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v1.2.0.0-b220511+dev104717

/* ============================================================================================
 * About this project
 * ============================================================================================
 * MyAvatool Web Service Commander (MAWSC) is a command-line maintenance utility for the
 * MyAvatool Web Service (MAWS), although it can be use to help maintain any custom web service
 * for myAvatar™.
 * 
 * ----------------------------------------
 * Read the README!
 * ----------------------------------------
 * To learn more about MAWSC, and how you can use it at your organization, read the README!
 * 
 *      https://github.com/spectrum-health-systems/MAWSC#readme
 *         
 * -----------------------------------------
 * MAWSC development
 * ----------------------------------------- 
 * To learn more about how MAWSC is developed, check out these resources:
 * 
 *  - MAWSC development branch:
 *      https://github.com/spectrum-health-systems/MAWSC/blob/development/
 *   
 *  - Interesting (?) development notes/data/thoughts:
 *      https://github.com/spectrum-health-systems/MAWSC/tree/development/doc/dev
 *  
 * -----------------------------------------
 * The myAvatar Development Community
 * ----------------------------------------- 
 * Check out the myAvatar™ Development Community for other myAvatar™-related development:
 * 
 *      https://github.com/myAvatar-Development-Community
 * 
 * -----------------------------------------
 * Notes about this code
 * -----------------------------------------
 * I've tried to make this sourcecode as human-readable as possible, but since other
 * organizations may use MAWS I've decided to heavily comment everything as well - sometimes
 * even in places where it is very clear as to what the code does.
 * 
 * I know this goes against best practice, but I want to make sure that my code is as clear as
 * possible as to what it's doing, and how it's doing it.
 * 
 * You will find three types of comments in this sourcecode:
 *
 *  /// XML comments used by Visual Studio
 *  
 *  // Additional information
 *  
 *  /* Narrative comments
 *   * / 
 * 
 * Please do not remove any of the sourcecode comments!
 */


/* =============================================================================
 * About this class
 * =============================================================================
 * This is the entry point for MAWSC.
 */

StartApp(args);

/// <summary>
/// Start MAWSC.
/// </summary>
static void StartApp(string[] commandLineArguments)
{
    /* Start fresh.
     */
    Console.Clear();

    /* Verify that command line arguments have been passed. If no arguments were
     * passed, MAWSC will exit.
     */
    MAWSC.Utility.Verify.ArgumentsPassed(commandLineArguments);

    /* Process the MAWSC command.
     */
    MAWSC.Roundhouse.ProcessCommand(commandLineArguments);
}