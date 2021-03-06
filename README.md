<!-- b220618.120857 -->

<div align="center">

  <img src="https://img.shields.io/badge/WARNING-THIS%20IS%20BETA%20SOFTWARE-FF160C?style=for-the-badge">

</div>

<br>

***

<br>

<div align="center">

  <img src=".github/Logos/maws-logo-commander-512x256.png" alt="MAWSC logo" width="384">
  <h3> 
  Tools and utilities for custom myAvatar™ web services
  </h3>

  <br>

  <img src="https://img.shields.io/badge/status-active-brightgreen?style=flat">&nbsp;
  [![License](https://img.shields.io/github/license/spectrum-health-systems/MAWSC?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)&nbsp;
  [![GitHub release](https://img.shields.io/github/v/release/spectrum-health-systems/MAWSC?style=flat)](https://github.com/spectrum-health-systems/MAWSC/releases)&nbsp;
  [![Issues](https://img.shields.io/github/issues/spectrum-health-systems/MAWSC?style=flat)](https://github.com/spectrum-health-systems/MAWSC/issues)&nbsp;
  [![Pulls](https://img.shields.io/github/issues-pr/spectrum-health-systems/MAWSC?style=flat)](https://github.com/spectrum-health-systems/MAWSC/pulls)

  <br>

  <img src=".github/Screenshots/Readme/mawsc-repository-screenshot.png" alt="MAWSC screenshot" width="384">
  <h5> 
  The MAWSC command line interface
  </h5>

  <br>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-00c0c0?style=for-the-badge)](https://github.com/spectrum-health-systems/MAWSC)&nbsp;&nbsp;&nbsp;[![CHANGELOG](https://img.shields.io/badge/CHANGELOG-007474?style=for-the-badge)](Documentation/Changelog.md)&nbsp;&nbsp;&nbsp;[![ROADMAP](https://img.shields.io/badge/ROADMAP-007474?style=for-the-badge)](Documentation/Roadmap.md)&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-007474?style=for-the-badge)](Documentation/Manual/MAWSC-Manual.md)&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-007474?style=for-the-badge)](Documentation/Sourcecode/MAWSC-Sourcecode.md)

</div>

<br>

# ABOUT

MAWS Commander (MAWSC) is a command-line interface for the [**MyAvatar Web Service (MAWS)**](https://github.com/spectrum-health-systems/MAWS), although it can be used to help maintain any custom web service for myAvatar™.

Testing web services is a tedious process that is prone to error, so I created MAWSC to take the human element out of the equation. The result is a deployment process that is faster, safer, and easily repeatable.

MAWSC is a portable application, and is easy to install and use.

## Features

* Written in .NET 6 C#, so it's cross platform (in theory)
* Displays various information about your web service environments
* Allows basic administration of your web service environments
* Automatically downloads web service sourcecode from a repository
* All session actions are backed up and logged to the console and local logfiles
* Extremely configurable

## Built with

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

# GETTING STARTED

## Prerequisites

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* A myAvatar custom web service (for example, [**MAWS**](https://github.com/spectrum-health-systems/MAWS))
* Microsoft Windows Operating System

## Before you begin

MAWSC is developed and tested on Windows 10 and Windows Server 2019.

While MAWSC is (in theory) cross-platform, it has not been tested on non-Windows Operating Systems. I would imagine any incompatibility would revolve around the way each OS handles filepaths.

## Initial setup

Before you use MAWSC, you will need to:
1. [Install MAWSC](#installing)
2. [Configure MAWSC](#configuring)

### Installing

MAWSC is a portable application, so it doesn't need to be installed. Just follow these steps:
1. Download the [latest release]() of MAWSC
2. Extract the "mawsc-release-X-x-x-x.zip to a directory of your choosing

If you add the directory where you installed MAWSC to your environment path, you can execute MAWSC from anywhere. Otherwise, you will need to be in the folder that contains `MAWSC.exe`.

### Configuring

MAWSC uses an external configuration file to store settings. When you first install MAWSC, that configuration file doesn't exist.

To create it, navigate to the directory where you extracted MAWSC, and type:

```
mawsc -configuration -reset
```

This will create a configuration file named `./AppData/Config/mawsc-config.json`.

The default contents of the configuration file are:

```
{
  "SessionTimestamp": "set-at-runtime",
  "ApplicationVersion": "set-at-runtime",
  "ConfigurationDirectory": "./AppData/Config/",
  "LogDirectory": "./AppData/Logs/",
  "LogfilePath": "set-at-runtime",
  "BackupDirectory": "./AppData/Backup/",
  "SessionBackupDirectory": "set-at-runtime",
  "TemporaryDirectory": "./AppData/Temp/",
  "RepositoryName": "name-of-your-repository",
  "RepositoryBranch": "name-of-your-repository-branch",
  "RepositoryUrl": "set-at-runtime",
  "StagingFetchDirectory": "./AppData/Staging_fetch/",
  "StagingTestingDirectory": "/path/to/your/web/service/testing/environment/",
  "ProductionDirectory": "/path/to/your/web/service/production/environment/",
  "MawscCommand": "set-at-runtime",
  "MawscAction": "set-at-runtime",
  "MawscOption": "set-at-runtime"
}
```

You will need to modify the following settings for your organization. Keep in mind the repository settings use GitHub as an example, and will need to be modified if you use another version control platform.

#### RepositoryName

The name of your repository. For example, if the URL to your repository is...
```
https://github.com/spectrum-health-systems/MAWS
```
...your `RepositoryName` would be `MAWS`

#### RepositoryBranch

The name of the branch you are using. If you are using the main branch of a repository, leave this set to `""`

If you are using a non-main branch of a repository, the URL probably looks like this...
```
https://github.com/spectrum-health-systems/MAWS/tree/0.60-development

```
...and your `RepositoryName` would be `0.60-development`

#### StagingTestingDirectory

This is the location of your staging environment that you use to test web service functionality. It might look like this:
```
C:\MyWebsites\MyWebService\Testing\
```

#### ProductionDirectory

This is the location of your production environment of your web service. It might look like this:
```
C:\MyWebsites\MyWebService\Production\

```

# USING

MAWSC is a command line interface application, so everything you'll be doing, you'll be doing by typing text into a terminal window, then pressing "Enter" to execute MAWSC.

## MAWSC Syntax

MAWSC syntax is:
```
mawsc -<command> [-action] [-option]
```

## The MAWSC Command

At a minimum, you'll need to pass a command to MAWSC via the command line by typing:
MAWSC syntax is:
```
mawsc -<command>
```
For example:
```
mawsc -help
```

MAWSC Commands:
* Have a default behavior that doesn't require an action or option to be passed.
* Generally have shortcuts (e.g., `mawsc -h` is the same as `mawsc -help`)
* Can be passed using any casing (e.g., `mawsc -HeLp` is a valid command)
* Do not *have* to start with a `-`, but it's recommended for readability

When MAWSC processes the arguments passed via the command line, it converts everything to lowercase, and removes any `-` characters. This way it's easier to for the logic to process commands/actions/options.

Commands also have shortcuts. For example, instead of typing `mawsc -help`, you could type `mawsc -h`

### Current MAWSC commands

As of version 2.0 of MAWSC, the following commands are valid:

| Command                     | Description                               | Default behavior                        |
|:--------------------------- |:----------------------------------------- |:--------------------------------------- |
| -help, -h                   | Display help information to the console   | Display help overview                   |
| -configuration, -config, -c | Do something with the configuration file  | Display current configuration settings  |
| -staging, -stage, -s        | Do something with the staging environment | Display staging environment information |

## The MAWSC Action

The MAWSC action is optional, and generally indicates that something specific is to be done with the MAWSC command.

For example, to reset the deploy the staging environment to production, type:
```
mawsc -staging -deploy
```
To learn more about what actions are available for different commands, type:
```
mawsc -help <command>
```
For example, to learn about what actions are available for the configuration command, type:
```
mawsc -help staging
```
## The MAWSC Option

The MAWSC option rarely used, and generally indicates that something specific is to be done with the MAWSC action.

For example, by default when you deploy your staging environment to production, only necessary files are deployed. You can override that by typing:
```
mawsc -staging -deploy -all
```
To learn more about what options are available for different actions, type:
```
mawsc -help <command>
```
For example, to learn about what options are available for the -deploy action of the -staging command, type:
```
mawsc -help staging
```

# Updating

Since MAWSC is portable, you just need to replace the old version with the new version.

# Uninstalling
Since MAWSC is portable, you just need to delete the location where Archiwizator resides.





