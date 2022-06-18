<!-- b220618.093429 -->

[MAWSC](../../../) &gt; [MAWSC Manual](../MAWSC-Manual.md) &gt; [Sourcecode documentation](../Sourcecode/MAWSC.Configuration.md) &gt; **MAWSC.Configuration**

















<br>

<div align="center">

  <img src="../../../.github/Logo/maws-logo-commander-512x256.png" alt="MAWSC logo" width="384">
  <h2>
  MAWSC Manual
  </h2>

</div>

<br>

<div align="center">

  [![CHANGELOG](https://img.shields.io/badge/CHANGELOG-00c0c0?style=for-the-badge)](doc/CHANGELOG.md)&nbsp;&nbsp;&nbsp;[![ROADMAP](https://img.shields.io/badge/ROADMAP-00c0c0?style=for-the-badge)](doc/ROADMAP.md)&nbsp;&nbsp;&nbsp;[![KNOWN ISSUES](https://img.shields.io/badge/KNOWN%20ISSUES-00c0c0?style=for-the-badge)](doc/KNOWN-ISSUES.md)

</div>

***


# **ConfigurationAction.cs**
> Logic for configuration actions.

## ConfigurationAction.ResetFile()
* If the configuration file exists, it is deleted and then recreated.
* It's recommended that you leave these values as they are, and make any modifications to the configuration file itself.
* You will need to modify the following settings for your organization:
    - `RepositoryBranch`<br>
       Name of the repository branch (e.g., "development"). If you are using the main branch, leave this set to "".
    - `StagingTestingDirectory`<br>
       The directory that contains the web service sourcode that you test against (e.g., "C:\MyWebsites\MyWebService\Testing\".
    - `ProductionDirectory`<br>
       The directory that contains the web service sourcode using in production (e.g., "C:\MyWebsites\MyWebService\Production\".>

<br>

***

<br>

# **ConfigurationFile.cs**

## ConfigurationFile.GetDefaultFilePath()
> Get the MAWSC configuration default filepath.

By default, the path is "./AppData/Config/mawsc-config.json" by default.

It is recommended that you do not modify the default configuration file path.

## ConfigurationFile.Verify()
> Verify the configuration file exists, and that it (probably) contains valid data.

In order for an existing configuration file to (probably) be valid, it must:
   1. Start with a "{" and end with a "}"<br>
      Valid JSON-formatted files are enclosed in {} brackets, so if the configuration file doesnt start and end with them, it's not a valid JSON data file.
   2. Contain at least five (5) lines of data<br>
      There are more than five configuration settings, so there should be at least 5 lines of data in the configuration file.

Keep in mind that:
* This is a quick-and-dirty test
* In order for this to work correctly, the configuration file needs to be written as indented JSON-formatted data, which MAWSC does by default.

## ConfigurationFile.Load()
> Load MAWSC settings from the configuration file.

* If ./AppData/Config/mawsc-config.json doesn't exist, a new configuration file will be created with default setting values.

<br>

***

<br>

# **ConfigurationSettings.cs**
> Configuration setting properties, and methods related to those settings.

## Properties

### Notes
* These settings are stored in the MAWSC configuration file, which is located at ./AppData/Config/mawsc-config.json.
* If a setting is a *User defined value*, you will need to modify the configuration file prior to executing MAWSC. Failure to do so will result in MAWSC not functioning correctly.
* If a setting has a *Default value*, it is highly recommended that you leave the setting at that value.
* If a setting is *Created at runtime*, the value in the configuration file will be replaced by a session value when MAWSC is executed.
* Repository values assume that GitHub is being used for version control. Other version control solutions may not work without modifying the sourcecode.

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

## ConfigurationSettings.Initialize()
Get the MAWSC configuration settings for the session by:
1. Loading the default settings from the external configuration file
2. Setting a few values at runtime

## ConfigurationSettings.GetRuntimeValues()
Get a few session-specific settings.

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



<br>

***
<br>

[ Back to [MAWSC Sourcecode documentation](Sourcecode.md) ]