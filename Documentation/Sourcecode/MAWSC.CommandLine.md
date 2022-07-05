> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC.CommandLine namespace**

<br>
<br>
<div align="center">
  <img src="../../.github//Logos/maws-logo-commander-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWSC SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>

<div align="center">

# **`NAMESPACE`** MAWSC.CommandLine

</div>

## About this namespace
The **MAWSC.CommandLine** namespace contains logic that handles the arguments that are passed via the command line when a new MAWSC session is initialzied.

This namespace has a single class that contains multiple methods that handle command line arguments.

<details>
<summary>
  <b>Arguments.cs</b><br>
  <i>Handles arguments that are passed via the command line when MAWSC is executed.</i>
</summary>

TBD

***

### `VerifiedPassed()`
Verifies that argument(s) were passed.

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* One of the first things MAWSC does when it is executed is verify that arguments were passed.
* If no arguments were passed, we will let the user know, and exit gracefully.
* We aren't testing for valid arguments at this point, only that they (or it) exists.

***

### `GetIndividualArguments()`
Separate the passed arguments into individual components.

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* There must be a MAWSC session command value - this will have been verified at this point.
* The MAWSC session action/option are optional, and are set to "unused" if not passed via the command line.
* The `rawArguments` are the arguments directly from the command line (e.g., `-staging` `-d`).
* The `cleanArguments` are the arguments after they have been cleaned. (e.g., `staging d`).

***

### `GetRawArguments()`
Separate the passed arguments into individual components.

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* Gets the raw MAWSC session command/action/option from the command line
* These components may contain dashes, and any combination of casing.

***

### `GetRawCommand()`
Get the raw MAWS Command.

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* There must be a MAWSC session command value, which will have been verified at this point.

***

### `GetRawAction()`
Get the raw MAWS Action.

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* The MAWSC session action is optional.
*-* If an MAWSC session action is not passed, it is set to "unused".

***

### `GetRawOption()`
Get the raw MAWS Option.

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* The MAWSC session option is optional.
* If an MAWSC session option is not passed, it is set to "unused".

***

### `CleanRawArguments()`
Clean the raw argument components

#### Operation
This method is pretty straight forward, and doesn't change.

#### Notes
* Components may contain dashes, and any combination of casing.
* The arguments are cleaned up so it's easier to apply logic to them. For 

</details>

<br>

***

> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC.CommandLine namespace**

[1]: https://github.com/spectrum-health-systems/MAWSC
[2]: ../Sourcecode/MAWSC-Sourcecode.md
[3]: ../Manual/MAWSC-Manual.md

<div align="center">
  <sub>
    Last updated July 5th, 2022
  </sub>
<br>