> [MAWS][1] &gt; [Sourcecode documentation][2]

<br>
<div align="center">
  <img src="../../.github/Logos/maws-logo-commander-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWSC SOURCODE DOCUMENTATION
  </h1>

<!-- In order for this block to render properly, it needs to be seperate from the <div> tag, and left-justified. -->
[![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>
<br>

# ABOUT THIS DOCUMENT
This is detailed documentation about the MAWSC sourcecode.

Instead of having a ton of comments in the sourcecode, details about the code will be here.

<br>

# ABOUT THE MAWSC SOURCECODE

## Headers
Every class has a standard `**==[ PROJECT ]==**` header thta looks like this:
```
// ========================================[ PROJECT ]=========================================
// MAWSC (MyAvatar Web Service Commander)
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================
```

Every class has a unique `**--[ CLASS ]--**` header that looks like this:
```
// -----------------------------------------[ CLASS ]------------------------------------------
// %ClassName%.cs
// %ShortClassDescription%
// %BuildInformation%
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------
```

The entry point for MAWSC (*MAWSC.cs*) also has an `**=-[ ABOUT ]-=**` header that provides various information and documentation links related to MAWSC. 

## Comments
Attempts have been made to make the MAWS sourcecode as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWS sourcecode:
```
/// XML comments used by Visual Studio
```
```
// Additional code description comment
```
```
/* Single-line narrative comment */
```
```
/* Multiple-line  
 * narrative comment  
 */
```

## Variables

### Variable prefixes

* `sent`  
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.

* `work`  
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 

* `final`  
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

###  Standard casing/trimming of values
Most logic in MAWSC is checked against lowercase values without any leading/trailing whitespace, so (in general) MAWSC will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", MAWSC will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

<br>

# NAMESPACES
Here is where you will find information about all of the MAWSC namespaces, and their sourcecode.

[MAWSC][4]





<details>
<summary>MAWSC.CommandLine</summary>


# `CLASS` Arguments.cs
Handles arguments that are passed via the command line when MAWSC is executed.

## `METHOD` VerifiedPassed()
Verifies that argument(s) were passed.

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* One of the first things MAWSC does when it is executed is verify that arguments were passed.
* If no arguments were passed, we will let the user know, and exit gracefully.
* We aren't testing for valid arguments at this point, only that they (or it) exists.

### `METHOD` GetIndividualArguments()
Separate the passed arguments into individual components.

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* There must be a MAWSC session command value - this will have been verified at this point.
* The MAWSC session action/option are optional, and are set to "unused" if not passed via the command line.
* The `rawArguments` are the arguments directly from the command line (e.g., `-staging` `-d`).
* The `cleanArguments` are the arguments after they have been cleaned. (e.g., `staging d`).

### `METHOD` GetRawArguments()
Separate the passed arguments into individual components.

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* Gets the raw MAWSC session command/action/option from the command line
* These components may contain dashes, and any combination of casing.

### `METHOD` GetRawCommand()
Get the raw MAWS Command.

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* There must be a MAWSC session command value, which will have been verified at this point.

### `METHOD` GetRawAction()
Get the raw MAWS Action.

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* The MAWSC session action is optional.
*-* If an MAWSC session action is not passed, it is set to "unused".

### `METHOD` GetRawOption()
Get the raw MAWS Option.

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* The MAWSC session option is optional.
* If an MAWSC session option is not passed, it is set to "unused".

### `METHOD` CleanRawArguments()
Clean the raw argument components

### Operation
This method is pretty straight forward, and doesn't change.

### Notes
* Components may contain dashes, and any combination of casing.
* The arguments are cleaned up so it's easier to apply logic to them. For example, if an argument can be passed as `-staging` or `-STAGING` or `--StAgInG`, and it will be cleaned up to be `staging`, which makes it easier to test against.

 
</details>






<!--








* [MAWSC](MAWSC.md)
* [MAWSC.CommandLine](MAWSC.CommandLine.md)
* [MAWSC.Configuration](MAWSC.Configuration.md)
* [MAWSC.Framework](MAWSC.Framework.md)
* [MAWSC.Help](MAWSC.Help.md)
* [MAWSC.Logging](MAWSC.Logging.md)
* [MAWSC.Maintenance](MAWSC.Maintenance.md)
* [MAWSC.Requirement](MAWSC.Requirement.md)
* [MAWSC.Roundhouse](MAWSC.Roundhouse.md)
* [MAWSC.Staging](MAWSC.Staging.md)

-->


<br><br><br><br><br><br><br><br>

# ADDITIONAL READING
There is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](
https://github.com/myAvatar-Development-Community/).

> [MAWS][1] &gt; [Sourcecode documentation][2]

[1]: https://github.com/spectrum-health-systems/MAWSC
[2]: ../Sourcecode/MAWSC-Sourcecode.md
[3]: ../Manual/MAWSC-Manual.md
[4]: ../Sourcecode/MAWSC.md



<div align="center">
  <sub>
    Last updated July 5th, 2022
  </sub>
<br>