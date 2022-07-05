> Last updated 7.5.2022

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC**

***

<br>

<div align="center">

  <img src="../../.github//Logos/maws-logo-commander-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWSC SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)](https://github.com/spectrum-health-systems/MAWSC)&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)](../Manual/MAWSC-Manual.md)&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)](MAWSC-Sourcecode.md)

</div>

<br>

# `NAMESPACE` MAWSC
Main MAWSC namespace. This is the entry point for MAWSC, and handles the initialization/startup of a new MAWSC session.

***

## `CLASS` MAWSC.cs
Main MAWSC class. Doesn't do much, just handles the intial starup logic.

### `METHOD` MawscInitializer()
Initialize a new MAWSC session.

### Operation
1. Clear the console.
2. Get the current MMddyy and HHmmss.
3. Verify the basic MAWSC requirements.
4. Load/set MAWSC settings for the session.
5. Verify the MAWSC framework, and resolve any issues.
6. Process the MAWSC Command/Action/Option.

### Notes
* This class/method is designed to be pretty static, and rarely modified.
* *[2]* We get the date/timestamp at the start of the session, and use the same date/timestamp throughout the session. This way anything related to the specific session will be labeled as such.

***

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC**