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
The **MAWSC.CommandLine** namespace processes the command line arguments that are passed to MAWSC at execution.

## Classes
This namespace has a single class that contains multiple methods that handle command line arguments.

<details>
<summary>
  <b>Arguments.cs</b><br>
  <i>Handles arguments that are passed via the command line when MAWSC is executed.</i>
</summary>
This class does various things with passed arguments, such as verifying arguments were passed and splitting arguments into individual components.

***

### `VerifiedPassed()`
Verify at least one argument was passed via the command line.

#### Operation
1. Check to see if the length of `args[]` is `0`, and exit gracefully if it is.

#### Notes
* MAWSC requires at least one argument to work correctly. If the user didn't pass any arguments, MAWSC won't be able to do anything, so we'll exit gracefully.
* One of the first things MAWSC does when it is executed is verify that arguments were passed.
* We aren't testing for valid arguments at this point, only that they (or it) exists.

***

### `GetIndividualComponents()`
Get the individual components of the passed arguments.

#### Operation
1. Get the individual argument components.
2. Return nice looking component values.

#### Notes
* The `rawComponents` are the individual arguments as they were originally passed via the command line (e.g., `-staging` or `-d`).
* The `cleanArguments` are the arguments after they have been cleaned. (e.g., `staging d`).
* **(2)** We return "clean" values for the individual components. For more information, please see [this documentation][4].

***

### `GetRawComponents()`
Get individual raw MAWSC Command/Action/Option for a specific session.

#### Operation
1. Create and return a dictionary of the individaul argument components.

#### Notes
* The `rawComponents` are the individual arguments as they were originally passed via the command line (e.g., `-staging` or `-d`).
* These components may contain dashes, and any combination of casing.

***

### `GetRawCommand()`
Get the raw MAWSC Command for the session.

#### Operation
1. Return the MAWSC Command value

#### Notes
* There must be a MAWSC session command value, which will have been verified if we are here.
* We aren't testing for valid arguments at this point.
* **(1)** The MAWSC Command is located in `args[0]`

***

### `GetRawAction()`
Get the raw MAWSC Action for the session.

#### Operation
1. If `args[]` has two or more values, then use the return the second value as the MAWSC Action
2. If `args[]` only has one value, the MAWSC Action will be returned as "unused".

#### Notes
* The MAWSC Action is optional.
* **(1)** The MAWSC Command is located in `args[1]`

***

### `GetRawOption()`
Get the raw MAWSC Option for the session.

#### Operation
1. If `args[]` has three or more values, then use the return the third value as the MAWSC Action
2. If `args[]` only has two values, the MAWSC Command will be returned as "unused".

#### Notes
* The MAWSC Option is optional.
* Arguments beyond `args[2]` are ignored.
* **(1)** The MAWSC Command is located in `args[2]`

***

### `CleanRawComponents()`
Clean the MAWSC Command/Action/Option components.

#### Operation
1. Remove any trailing/leading whitespace from each component
2. Convert each component to lowercase
3. Replace any "-" characters with ""

#### Notes
* For more information as to why we cleanup these components, please see [this documentation][4].

</details>

<br>

***

> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC.CommandLine namespace**

[1]: https://github.com/spectrum-health-systems/MAWSC
[2]: ../Sourcecode/MAWSC-Sourcecode.md
[3]: ../Manual/MAWSC-Manual.md
[4]: MAWSC-Sourcecode.md#standard-casingtrimming-of-values


<div align="center">
  <sub>
    Last updated July 5th, 2022
  </sub>
<br>