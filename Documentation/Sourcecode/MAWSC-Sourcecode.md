> [MAWS][1] &gt; Sourcecode documentation

<br>
<div align="center">
  <img src="../../.github/Logos/maws-logo-commander-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWSC SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>
<br>

# About the MAWSC sourcecode

This is detailed documentation about the MAWSC sourcecode.

Instead of having a ton of comments in the sourcecode, details about the code will be here.

# Headers

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
// Sourceode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWSC-Sourcecode.md
// --------------------------------------------------------------------------------------------
```

The entry point for MAWSC (*MAWSC.cs*) also has an `**=-[ ABOUT ]-=**` header that provides various information and documentation links related to MAWSC. 

# Comments

Attempts have been made to make the MAWSC sourcecode as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWSC sourcecode:
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

# Variables

## Variable prefixes

* `sent`  
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.

* `work`  
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 

* `final`  
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

##  Standard casing/trimming of values

Most logic in MAWSC is checked against lowercase values without any leading/trailing whitespace, so (in general) MAWSC will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", MAWSC will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

<br>

# Namespaces

Here is where you will find information about all of the MAWSC namespaces, and their sourcecode.

[MAWSC][4]  
[MAWSC.CommandLine][5]  
[MAWSC.Configuration][6]  

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

# Additional reading

There is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](https://github.com/myAvatar-Development-Community/).

<br>

***

> [MAWS][1] &gt; Sourcecode documentation

[1]: https://github.com/spectrum-health-systems/MAWSC
[2]: ../Sourcecode/MAWSC-Sourcecode.md
[3]: ../Manual/MAWSC-Manual.md
[4]: ../Sourcecode/MAWSC.md
[5]: ../Sourcecode/MAWSC.CommandLine.md
[6]: ../Sourcecode/MAWSC.Configuration.md

<div align="center">
  <sub>
    Last updated July 5th, 2022
  </sub>
<br>