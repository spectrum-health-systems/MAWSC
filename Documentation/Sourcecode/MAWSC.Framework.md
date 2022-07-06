> Last updated 7.5.2022

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt; **MAWSC.Framework**

***

<br>

<div align="center">

  <img src="../../.github//Logos/maws-logo-commander-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)](https://github.com/spectrum-health-systems/MAWSC)&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)](../Manual/MAWSC-Manual.md)&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)](MAWSC-Sourcecode.md)

</div>

<br>

# `NAMESPACE` MAWSC.Framework
Logic for MAWSC framework.

<br>

***

## `CLASS` RefreshFramework.cs
Refresh framework components.

### `METHOD` Directories()
Refresh MAWSC framework directories.

### Operation
TBD.

### Notes
* Directories are refreshed recursively.
* Currently onlt the temporary directory is refreshed.

<br>

***

## `CLASS` VerifyFramework.cs
Refresh framework components.

### `METHOD` Startup()
Verify the MAWSC framework.

### Operation
TBD.

### Notes
* Verify the framework (directories, data, etc.)
* We'll jumpstart the logfile with the header we created earlier, then write log information everywhere going forward.

### `METHOD` RequiredDirectories()
Verify that required directories exist, and create them if they don't.

### Operation
TBD.

### Notes
None.

### `METHOD` SessionBackupDirectory()
TBD

### Operation
TBD.

### Notes
* The session backup directory is where anything related to this MAWSC session is backed up to.


***

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt; **MAWSC.Framework**