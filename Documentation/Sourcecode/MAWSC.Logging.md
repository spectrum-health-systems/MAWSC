> Last updated 6.28.2022

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC.Logging**

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

# `NAMESPACE` MAWSC.Logging
Exports log data to the command line and/or a local file.

<br>

***

## `CLASS` ExportLog.cs
Verify various MAWSC requirements.

### `METHOD` ToConsole()
Display log information on the console.

### Operation
None.

### Notes
None.

### `METHOD` ToEverywhere()
Display log information on the console, and write it to a file.

### Operation
None.

### Notes
None.

### `METHOD` ToFile()
Write log information to a file. 

### Operation
None.

### Notes
None.

<br>

***

## `CLASS` LogComponents.cs
Log components.

### `METHOD` ArgumentsPassed()
TBD

### Operation
None.

### Notes
None.

### `METHOD` BackupStagingSource()
TBD

### Operation
None.

### Notes
None.

### `METHOD` BackupStagingTarget()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationInformation()
TBD

### Operation
None.

### Notes
None.

### `METHOD` StagingInformation()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationFileWillBeReset()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationFileHasBeenReset()
TBD

### Operation
None.

### Notes
None.

### `METHOD` FrameworkRequiredDirectoriesVerified()
TBD

### Operation
None.

### Notes
None.

### `METHOD` SessionBackupDirectoryVerified()
TBD

### Operation
None.

### Notes
None.

### `METHOD` TypeForHelp()
TBD

### Operation
None.

### Notes
None.

<br>

***

## `CLASS` LogHeader.cs
Logging headers.

### `METHOD` Backup()
TBD

### Operation
None.

### Notes
None.

### `METHOD` Error()
TBD

### Operation
None.

### Notes
None.

### `METHOD` Info()
TBD

### Operation
None.

### Notes
None.

### `METHOD` Request()
TBD

### Operation
None.

### Notes
None.

### `METHOD` Verify()
TBD

### Operation
None.

### Notes
None.

### `METHOD` Validate()
TBD

### Operation
None.

### Notes
None.

### `METHOD` Sub()
Create a log message sub-header.

### Operation
None.

### Notes
* The sub-header string is a generic sub-header for log files. Content is determined by the subHeaderText parameter.

### `METHOD` Top()
Create the log message master header.

### Operation
None.

### Notes
* The master header string is at the top of each logfile, and always contains the same information.

<br>

***

## `CLASS` LogMessage.cs
Logging messages.

### `METHOD` ArgumentsMissing()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ArgumentsPassed()
TBD

### Operation
None.

### Notes
None.

### `METHOD` BackupStagingSource()
TBD

### Operation
None.

### Notes
None.

### `METHOD` RequestBackupStagingSource()
TBD

### Operation
None.

### Notes
None.

### `METHOD` BackupStagingTarget()
TBD

### Operation
None.

### Notes
None.

### `METHOD` InfoMovingFiles()
TBD

### Operation
None.

### Notes
None.

### `METHOD` RequestBackupStagingTarget()
TBD

### Operation
None.

### Notes
None.

### `METHOD` CommandIsInvalid()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationInformation()
TBD

### Operation
None.

### Notes
None.

### `METHOD` RequestConfigurationInformation()
TBD

### Operation
None.

### Notes
None.

### `METHOD` StagingInformation()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationFileInvalid()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationFileNotFound()
TBD

### Operation
None.

### Notes
None.

### `METHOD` RequestConfigurationFileReset()
TBD

### Operation
None.

### Notes
None.

### `METHOD` ConfigurationFileReset()
TBD

### Operation
None.

### Notes
None.

### `METHOD` VerifyFrameworkRequiredDirectories()
TBD

### Operation
None.

### Notes
None.

### `METHOD` SessionBackupDirectoryVerify()
TBD

### Operation
None.

### Notes
None.

### `METHOD` RequestStagingInformation()
TBD

### Operation
None.

### Notes
None.

***

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC.Logging**