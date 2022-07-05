> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC namespace**

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

# **`MAWSC NAMESPACE`**

</div>

# About this namespace
The MAWSC namespace is the entry point for MAWSC, and handles the initialization/startup of a new MAWSC session.

This namespace doesn't have much to it, it just handles the initialization of a new MAWSC session.

# Sourcecode documentation

<details>
<summary>
  <b>MAWSC.cs</b><br>
  <i>Initializes a new MAWSC session</i>
</summary>

This class has a single class, with a single method, that handels the initialization of a new MAWSC session. Most of the heavy lifting is done by other namespaces/classes/methods.

## `MawscInitializer()`
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
* **(2)** We get the date/timestamp at the start of the session, and use the same date/timestamp throughout the session. This way anything related to the specific session will be labeled as such.

<br>

</details>

<br>
<br>

***

> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC namespace**

[1]: https://github.com/spectrum-health-systems/MAWSC
[2]: ../Sourcecode/MAWSC-Sourcecode.md
[3]: ../Manual/MAWSC-Manual.md

<div align="center">
  <sub>
    Last updated July 5th, 2022
  </sub>
<br>