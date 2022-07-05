> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC.Configuration namespace**

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

# **`NAMESPACE`** MAWSC.Configuration

</div>

## About this namespace

The **MAWSC.Configuration** namespace processes the configuration data/files that are required for MAWSC to function.

## Classes

This namespace has a multiple classes that handle configuration/setting data.

<details>
<summary>
  <b>ConfigurationAction.cs</b><br>
  <i>Logic for configuration file/data actions.</i>
</summary>
This class resets the configuration file to default values.

***

### `ResetFile()`
Recreate the configuration file with default values.

#### Operation
1. If the configuration file exists, delete it.
2. Create a new defaultSettings object with the default setting values.
3. Serialize that data as a JSON-formatted file, and write it to a local file.

#### Notes
* This method recreates the MAWSC configuration file with default values, so if there is an existing configuration file, it is deleted, so be careful with this.
* **(2)** It's recommended that you leave these values as they are, and make any modifications to the configuration file itself.
* **(1)**, **(3)** The filePath of the configuration file is hardcoded into MAWSC so there is one source that defines what that path is.

</details>

<br>

<details>
<summary>
  <b>ConfigurationFile.cs</b><br>
  <i>Logic related to the configuration file.</i>
</summary>
Various things to do with the MAWSC configuration file.

***

### `GetDefaultFilePath()`
Get the MAWSC configuration default filepath.

#### Operation
1. Return the path to the MAWSC configuration file.

#### Notes
* The filePath of the configuration file is hardcoded into MAWSC so there is one source that defines what that path is.
* **(1)** This value should be `./AppData/Config/mawsc-config.json`, and should not be modified.

***

### `Verify()`
Verify the configuration file exists, and that it (probably) contains valid data.

#### Operation
1. Get the hardcoded configurationFilePath.
2. If the configuration file doesn't exist, recreate it with default values.
3. If the configuration file does exist, test to make sure it (probably) contains valid data.

#### Notes
* In order for this to work correctly, the configuration file needs to be written as indented JSON-formatted data (which MAWSC does by default when recreating the file).
* The tests that are done to verify the configuration file contains valid data are quick-and-dirty.
* **(3)** In order for an existing configuration file to (probably) be valid, it must:
   - *Start with a "{" and end with a "}"*  
      Valid JSON-formatted files are enclosed in {} brackets, so if the configuration file doesnt start and end with them, it's not a valid JSON data file.
   - *Contain at least five (5) lines of data*..
      There are more than five configuration settings, so there should be at least 5 lines of data in the configuration file.

***

### `Load()`
Load MAWSC settings from the configuration file.

#### Operation
1. Get the hardcoded configurationFilePath.
2. If the configuration file doesn't exist, recreate it with default values.
3. Return a `mawscSettings` object containing the values from the configuration file.

#### Notes
* If ./AppData/Config/mawsc-config.json doesn't exist, a new configuration file will be created with default setting values.

</details>

<br>

<details>
<summary>
  <b>ConfigurationSettings.cs</b><br>
  <i>Contains setting properties, and logic related to those properties.</i>
</summary>
This class contains both the MAWSC settings properties, and logic related to those properties.

***

## PROPERTIES

`SessionTimestamp`  
*Created at runtime*  
The session timestamp, used throughout the session. This way we have a single timestamp that is used, and not different timestamps for different things.  

`ApplicationVersion`<br>
*Created at runtime*<br>
The version of MAWSC that is being used.<br>

`ConfigurationDirectory`<br>
*Default value: "./AppData/Config/"*<br>
The directory where the mawsc-config.json file is located. This is hardcoded, and therefore shouldn't be changed.

`LogDirectory`<br>
*Default value: "./AppData/Logs/"*<br>
The directory where logfiles are created.

`SessionLogfilePath`<br>
*Created at runtime: "./AppData/Logs/mawsc-%SessionTimestamp%.log"*<br>
The path to the session logfile, which contains log information for the session.

`BackupDirectory`<br>
*Default value: "./AppData/Backup/"*<br>
The directory where backup files are stored.

`SessionBackupDirectory`<br>
*Created at runtime: "./AppData/Backup/%SessionTimestamp%/*<br>
The directory where session backup files are stored.

`TempDirectory`<br>
*Default value: "./AppData/Temp/*<br>
The directory where temporary files are stored. By default this is "./AppData/Temp/". This directory is deleted/recreated when MAWSC is executed.

`RepositoryLocation`<br>
*User defined value*<br>
The base level URL of the account that contains the repository you are using. Using an the Spectrum Health Systems GitHub accoung (**https://github.com/spectrum-health-systems/**) as an example, this value would be **https://github.com/spectrum-health-systems/**.

`RepositoryName`<br>
*User defined value*<br>
The name of the repository that contains the web service you are using. Using an the MAWSC GitHub respository (**https://github.com/spectrum-health-systems/MAWSC**) as an example, this value would be **MAWSC**.

`RepositoryBranch`<br>
*User defined value*<br>
The name of the repository branch that contains the web service you are using. Using an the MAWSC development branch (**https://github.com/spectrum-health-systems/MAWSC/tree/development**) as an example, this value would be **development**. If you are using the main/master branch, leave this set to **""**.

`RepositoryZipUrl`<br>
*Created at runtime: "%RepositoryLocation%/%RepositoryName%/archive/refs/heads/%RepositoryBranch%.zip*<br>
The URL of zip archive for the repository you are using, built using the **RepositoryLocation**, **RepositoryName**, and **RepositoryBranch**. Using the examples above would look like **https://github.com/spectrum-health-systems/MAWSC/archive/refs/heads/development.zip**

`StagingFetchDirectory`<br>
*Default value: "./AppData/Staging-fetch/*<br>
The directory where the repository archive will be downloaded.

`StagingTestingDirectory`<br>
*User defined value*<br>
The directory where the staging source will be copied to for testing. For example:
"/path/to/your/web/service/testing/".

`ProductionDirectory`<br>
*User defined value*<br>
The directory where your production web service is located. For example:
"/path/to/your/web/service/production/".

`MawscCommand `<br>
*Created at runtime: "arg[0]*<br>
The MAWSC Command passed via command line when MAWSC is executed. This is required, and MAWSC will exit gracefully if it does not exist.

`MawscAction `<br>
*Created at runtime: "arg[1]*<br>
The (optional) MAWSC Action passed via command line when MAWSC is executed.

`MawscOption `<br>
*Created at runtime: "arg[2]*<br>
The (optional) MAWSC Option passed via command line when MAWSC is executed.


</details>







***

> [MAWS][1] &gt; [Sourcecode][2] &gt;  **MAWSC.CommandLine namespace**

[1]: https://github.com/spectrum-health-systems/MAWSC
[2]: ../Sourcecode/MAWSC-Sourcecode.md
[3]: ../Manual/MAWSC-Manual.md
[4]: ../Sourcecode/MAWSC-Sourcecode.md#standard-casingtrimming-of-values

<div align="center">
  <sub>
    Last updated July 5th, 2022
  </sub>
<br>










## `CLASS` ConfigurationSettings.cs
Configuration setting properties, and methods related to those settings.

## `PROPERTIES`

`SessionTimestamp`<br>
*Created at runtime*<br>
The session timestamp, used throughout the session. This way we have a single timestamp that is used, and not different timestamps for different things.<br>

`ApplicationVersion`<br>
*Created at runtime*<br>
The version of MAWSC that is being used.<br>

`ConfigurationDirectory`<br>
*Default value: "./AppData/Config/"*<br>
The directory where the mawsc-config.json file is located. This is hardcoded, and therefore shouldn't be changed.

`LogDirectory`<br>
*Default value: "./AppData/Logs/"*<br>
The directory where logfiles are created.

`SessionLogfilePath`<br>
*Created at runtime: "./AppData/Logs/mawsc-%SessionTimestamp%.log"*<br>
The path to the session logfile, which contains log information for the session.

`BackupDirectory`<br>
*Default value: "./AppData/Backup/"*<br>
The directory where backup files are stored.

`SessionBackupDirectory`<br>
*Created at runtime: "./AppData/Backup/%SessionTimestamp%/*<br>
The directory where session backup files are stored.

`TempDirectory`<br>
*Default value: "./AppData/Temp/*<br>
The directory where temporary files are stored. By default this is "./AppData/Temp/". This directory is deleted/recreated when MAWSC is executed.

`RepositoryLocation`<br>
*User defined value*<br>
The base level URL of the account that contains the repository you are using. Using an the Spectrum Health Systems GitHub accoung (**https://github.com/spectrum-health-systems/**) as an example, this value would be **https://github.com/spectrum-health-systems/**.

`RepositoryName`<br>
*User defined value*<br>
The name of the repository that contains the web service you are using. Using an the MAWSC GitHub respository (**https://github.com/spectrum-health-systems/MAWSC**) as an example, this value would be **MAWSC**.

`RepositoryBranch`<br>
*User defined value*<br>
The name of the repository branch that contains the web service you are using. Using an the MAWSC development branch (**https://github.com/spectrum-health-systems/MAWSC/tree/development**) as an example, this value would be **development**. If you are using the main/master branch, leave this set to **""**.

`RepositoryZipUrl`<br>
*Created at runtime: "%RepositoryLocation%/%RepositoryName%/archive/refs/heads/%RepositoryBranch%.zip*<br>
The URL of zip archive for the repository you are using, built using the **RepositoryLocation**, **RepositoryName**, and **RepositoryBranch**. Using the examples above would look like **https://github.com/spectrum-health-systems/MAWSC/archive/refs/heads/development.zip**

`StagingFetchDirectory`<br>
*Default value: "./AppData/Staging-fetch/*<br>
The directory where the repository archive will be downloaded.

`StagingTestingDirectory`<br>
*User defined value*<br>
The directory where the staging source will be copied to for testing. For example:
"/path/to/your/web/service/testing/".

`ProductionDirectory`<br>
*User defined value*<br>
The directory where your production web service is located. For example:
"/path/to/your/web/service/production/".

`MawscCommand `<br>
*Created at runtime: "arg[0]*<br>
The MAWSC Command passed via command line when MAWSC is executed. This is required, and MAWSC will exit gracefully if it does not exist.

`MawscAction `<br>
*Created at runtime: "arg[1]*<br>
The (optional) MAWSC Action passed via command line when MAWSC is executed.

`MawscOption `<br>
*Created at runtime: "arg[2]*<br>
The (optional) MAWSC Option passed via command line when MAWSC is executed.

### Notes
* These settings are stored in the MAWSC configuration file, which is located at ./AppData/Config/mawsc-config.json.
* If a setting is a *User defined value*, you will need to modify the configuration file prior to executing MAWSC. Failure to do so will result in MAWSC not functioning correctly.
* If a setting has a *Default value*, it is highly recommended that you leave the setting at that value.
* If a setting is *Created at runtime*, the value in the configuration file will be replaced by a session value when MAWSC is executed.
* Repository values assume that GitHub is being used for version control. Other version control solutions may not work without modifying the sourcecode.

### `METHOD` Initialize()
> Load MAWSC settings from the configuration file.

### Operation
1. Load the default settings from the external configuration file
2. Set a few session-specific values at runtime

### Notes
None.

### `METHOD` GetRuntimeValues()
> Get a few session-specific settings.

### Operation
TBD.

### Notes
The following values are set at runtime, and are specific to this session:

```
SessionTimestamp
ApplicationVersion
SessionLogfilePath
SessionBackupDirectory
RepositryZipUrl
MawscCommand
MawscAction
MawscOption
```

***

[MAWS](https://github.com/spectrum-health-systems/MAWSC) &gt; [Sourcecode](../Sourcecode/MAWSC-Sourcecode.md) &gt;  **MAWSC.Configuration**