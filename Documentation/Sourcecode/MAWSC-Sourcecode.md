> Last updated 6.27.22

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC Sourcecode documentation**

***

<br>

<div align="center">

  <img src="../../.github/Logos/maws-logo-commander-512x256.png" alt="MAWS logo" width="256">
  <h1> 
    MAWSC SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)](https://github.com/spectrum-health-systems/MAWSC)&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)](../Manual/MAWSC-Manual.md)&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)](MAWSC-Sourcecode.md)

</div>

<br>

# ABOUT THIS DOCUMENT
This is detailed documentation about the MAWSC sourcecode, which includes:

* Information about sourcecode [comments](#sourcecode-comments) and [variables](#variables).
* Detailed information about each [namespace](#namespaces), and the classes and methods within.

# SOURCECODE

## HEADERS
Every class has a standard **==[ PROJECT ]==** header thta looks like this:
```
// ========================================[ PROJECT ]=========================================
// MAWSC (MyAvatar Web Service Commander)
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWSC
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================
```

Every class has a unique **--[ CLASS ]--** header that looks like this:
```
// -----------------------------------------[ CLASS ]------------------------------------------
// %ClassName%.cs
// %ShortClassDescription%
// %BuildInformation%
// Sourcode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------
```

The entry point for MAWSC (*MAWSC.cs*) also has an **=-[ ABOUT ]-=** header that provides various information and documentation links related to MAWSC. 

## COMMENTS
Attempts have been made to make the MAWS sourcecode as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWS sourcecode:
```
/// XML comments used by Visual Studio

// Additional code description comment

/* Single-line narrative comment */

/* Multiple-line
 * narrative comment
*/

```

# VARIABLES

## Variable prefixes

* `sent`<br>
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.

* `work`<br>
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 

* `final`<br>
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

##  Standard casing/trimming of values
Most logic in MAWSC is checked against lowercase values without any leading/trailing whitespace, so (in general) MAWSC will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_AValue_`" (where the `_` character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", MAWSC will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

# NAMESPACES
* [MAWSC](MAWSC.md)
* [MAWSC.CommandLine](MAWSC.CommandLine.md)
* [MAWSC.Configuration](MAWSC.Configuration.md)
* [MAWSC.Requirement](MAWSC.Requirement.md)

# ADDITIONAL READING
There is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](
https://github.com/myAvatar-Development-Community/).

***

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC Sourcecode documentation**