# MAWSC.Configuration
> Back to [MAWSC Sourcecode documentation](README.md)
***
<br>

[Configuration.Action](#configurationaction)<br>
[Configuration.Settings](#configurationsettings)

***

## **ConfigurationAction.cs**
> Logic for configuration actions

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
> Recreate the configuration file with default values.

Properties:
```
SessionTimestamp
ApplicationVersion
ConfigurationDirectory
LogDirectory
LogfilePath
```
### ConfigurationSettings.Initialize()

### ConfigurationSettings.LoadFromFile()

### ConfigurationSettings.GetDefaultFilePath()

### ConfigurationSettings.GetRuntimeValues()

### ConfigurationSettings.FileData()

<br>

***
<br>

> Back to [MAWSC Sourcecode documentation](README.md)