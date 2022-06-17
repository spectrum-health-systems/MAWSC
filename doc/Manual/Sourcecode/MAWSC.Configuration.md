# MAWSC.Configuration
[ Back to [MAWSC Sourcecode documentation](Sourcecode.md) ]
***
<br>

[Configuration.Action.cs](#configurationaction)<br>
[Configuration.Settings.cs](#configurationsettings)

***

## **ConfigurationAction.cs**
Logic for configuration actions.

### ConfigurationAction.ResetFile()
* If the configuration file exists, it is deleted and then recreated.
* It's recommended that you leave these values as they are, and make any modifications to the configuration file itself.
* You will need to modify the following settings for your organization:
    - `RepositoryBranch`<br>
       Name of the repository branch (e.g., "development"). If you are using the main branch, leave this set to "".
    - `StagingTestingDirectory`<br>
       The directory that contains the web service sourcode that you test against (e.g., "C:\MyWebsites\MyWebService\Testing\".
    - `ProductionDirectory`<br>
       The directory that contains the web service sourcode using in production (e.g., "C:\MyWebsites\MyWebService\Production\".>

## **ConfigurationSettings.cs**
Recreate the configuration file with default values.

### Properties

`SessionTimestamp` (*Created at runtime*)<br>
The session timestamp. This is created at execution time, and is used throughout the session. This way we have a single timestamp that is used, and not different timestamps for different things.

`ApplicationVersion` (*Created at runtime*)<br>
The version of MAWSC that is being used.

`ConfigurationDirectory`<br>
The directory where the mawsc-config.json file is located. By default this is "./AppData/Config/", and that shouldn't be changed, since it is hardcoded.

`LogDirectory`<br>
The directory where logfiles are created. By default this is "./AppData/Logs/"

`SessionLogfilePath` (*Created at runtime*)<br>
The path to the session logfile, which contains log information for the session. By default this is "./AppData/Logs/mawsc-%SessionTimestamp%.log"..

`BackupDirectory`<br>
The directory where backup files are stored. By default this is "./AppData/Backup/".

`SessionBackupDirectory` (*Created at runtime*)<br>
The directory where session backup files are stored. By default this is "./AppData/Backup/%SessionTimestamp%/".

`TempDirectory`<br>
The directory where temporary files are stored. By default this is "./AppData/Temp/". This directory is deleted/recreated when MAWSC is executed.

`RepositoryLocation`<br>
The base level URL of the account that contains the repository you are using. Using an the Spectrum Health Systems GitHub accoung (**https://github.com/spectrum-health-systems/**) as an example, this value would be **https://github.com/spectrum-health-systems/**.

`RepositoryName`<br>
The name of the repository that contains the web service you are using. Using an the MAWSC GitHub respository (**https://github.com/spectrum-health-systems/MAWSC**) as an example, this value would be **MAWSC**.

`RepositoryBranch`<br>
The name of the repository branch that contains the web service you are using. Using an the MAWSC development branch (**https://github.com/spectrum-health-systems/MAWSC/tree/development**) as an example, this value would be **development**.

`RepositoryUrl` (*Created at runtime*)<br>
The URL of the account that contains the repository you are using, built using the **RepositoryLocation**, **RepositoryLocation**, and **RepositoryLocation**. Using the examples above would look like **https://github.com/spectrum-health-systems/MAWSC/tree/development**


Using an the MAWSC development branch (*"https://github.com/spectrum-health-systems/MAWSC/tree/development"*) as an example, this value would be *"development"*.



$"https://github.com/spectrum-health-systems/{mawsc.RepositoryName}/archive/refs/heads/{mawsc.RepositoryBranch}.zip";



runtime
github



### ConfigurationSettings.Initialize()



### ConfigurationSettings.LoadFromFile()

### ConfigurationSettings.GetDefaultFilePath()

### ConfigurationSettings.GetRuntimeValues()

### ConfigurationSettings.FileData()

<br>

***
<br>

[ Back to [MAWSC Sourcecode documentation](Sourcecode.md) ]