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

# **[NAMESPACE]** MAWSC
Main MAWSC namespace.

<br>

***

# `[CLASS]` MAWSC.cs
Main MAWSC class. Doesn't do much, just handles the intial starup logic.

## `[METHOD]` MawscInitializer()
Intializes a new session of MAWSC.

### Details
1. Clear the console.
2. Get the current MMddyy and HHmmss.
3. Verify the basic MAWSC requirements.
4. Load/set MAWSC settings for the session.
5. Verify the MAWSC framework, and resolve any issues.
6. Process the MAWSC Command/Action/Option.

### Notes
* This class/method is designed to be pretty static, and rarely modified.













# MAWSC.cs
> Entry point for MAWSC.

## MAWSC.MawscInitializer()
We get the timestamp here, right at the beginning, so we can use the same timestamp throughout the session. Otherwise we might have different timestamps at different times for different things (backups, deployments, etc.)

The initialization process:
1. Verifies the basic requirements that are needed, that don't require configuration settings.
2. Loads the configuration settings (and also creates session-specific settings)
3. Does another round of verifications for things that require configuration settings.
4. Hands things off to the MawscRoundhouse.