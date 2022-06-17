# MAWSC.Configuration
[ Back to [MAWSC Sourcecode documentation](Sourcecode.md) ]
***
<br>

[Configuration.Action.cs](#configurationaction)<br>
[Configuration.Settings.cs](#configurationsettings)

<br>

***

<br>

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

# **ConfigurationSettings.cs**
> Configuration setting properties, and methods related to those settings.

## Properties

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

runtime
github
user defined values


### ConfigurationSettings.Initialize()



### ConfigurationSettings.LoadFromFile()

### ConfigurationSettings.GetDefaultFilePath()

### ConfigurationSettings.GetRuntimeValues()

### ConfigurationSettings.FileData()

<br>

***
<br>

[ Back to [MAWSC Sourcecode documentation](Sourcecode.md) ]