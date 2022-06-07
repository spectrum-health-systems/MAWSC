<!-- b220607.091610 -->

<div align="center">

  <img src="https://img.shields.io/badge/WARNING-THIS%20IS%20BETA%20SOFTWARE-FF160C?style=for-the-badge">

</div>

<br>

<div align="center">

  <img src=".github/Logo/maws-logo-commander-512x256.png" alt="MAWSC logo" width="384">
  <h3>
  Tools and utilities for custom myAvatar™ web services
  </h3>

</div>

<div align="center">

  <img src="https://img.shields.io/badge/status-active-brightgreen?style=flat-square">&nbsp;
  [![License](https://img.shields.io/github/license/spectrum-health-systems/MAWSC?style=flat-square)](https://www.apache.org/licenses/LICENSE-2.0)&nbsp;
  [![GitHub release](https://img.shields.io/github/v/release/spectrum-health-systems/MAWSC?style=flat-square)](https://github.com/spectrum-health-systems/MAWSC/releases)&nbsp;
  [![Issues](https://img.shields.io/github/issues/spectrum-health-systems/MAWSC?style=flat-square)](https://github.com/spectrum-health-systems/MAWSC/issues)&nbsp;
  [![Pulls](https://img.shields.io/github/issues-pr/spectrum-health-systems/MAWSC?style=flat-square)](https://github.com/spectrum-health-systems/MAWSC/pulls)

</div>

***

<div align="center">

  <img src=".github/Readme-resource/Screenshot/mawsc-repository-screenshot.png" alt="MAWSC screenshot" width="384">

</div>

***

<div align="center">

  [![CHANGELOG](https://img.shields.io/badge/CHANGELOG-00c0c0?style=for-the-badge)](doc/CHANGELOG.md)&nbsp;&nbsp;&nbsp;[![ROADMAP](https://img.shields.io/badge/ROADMAP-00c0c0?style=for-the-badge)](doc/ROADMAP.md)&nbsp;&nbsp;&nbsp;[![KNOWN ISSUES](https://img.shields.io/badge/KNOWN%20ISSUES-00c0c0?style=for-the-badge)](doc/KNOWN-ISSUES.md)

</div>

***

  ### CONTENTS
  [ABOUT](#about)<br>
  [GETTING STARTED](#getting-started)<br>
  [INSTALLING](#installing)<br>
  [SETUP](#setup)<br>
  [USING](#using)<br>
  [UPDATING](#updating)<br>
  [UNINSTALLING](#uninstalling)<br>
  [DEVELOPMENT](#development)<br>
  [ADDITIONAL INFORMATION](#additional-information)<br>

***

# ABOUT

MAWS Commander (MAWSC) is a command-line interface for the [**MyAvatar Web Service (MAWS)**](https://github.com/spectrum-health-systems/MAWS), although it can be used to help maintain any custom web service for myAvatar™.

Testing web services is a tedious process that is prone to error, so I created MAWSC to take the human element out of the equation. The result is a deployment process that is faster, safer, and easily repeatable.

## Features

* Written in .NET 6 C#, so it's cross platform
* Displays various information about your web service environments
* Allows basic administration of your web service environments
* Automatically downloads web service sourcecode from a repository
* All session actions are backed up and logged to the console and local logfiles
* Extremely configurable

### Built with

## GETTING STARTED

### Before you begin

MAWSC is a work in progress, and is being developed alongside MAWS. Currently the feature set leans heavily towards development, so it's probably not much use to end-users.

As MAWS continues to be developed, end-user features will be added to MAWSC.

### Prerequisites

* .NET 6
* A [**MAWS**](https://github.com/spectrum-health-systems/MAWS) installation

## INSTALLING

MAWSC is a portable application, so it doesn't need to be installed.

### Windows

1. Download the [latest release](https://github.com/spectrum-health-systems/MAWSC/releases) of MAWSC.
2. Extract the `MAWSC.zip` file to a directory.
3. It is recommended that you add the directory that contains MAWSC.exe to your environment path.

### Other operating systems

Currently MAWSC only supports Microsoft Windows.

## USING

### Verifying directory structure
While in developemnt MAWSC uses the following hard-coded directories:

* IIS Staging backup directory: `C:\MyAvatool\MAWS\Staging\Backup`
* IIS Staging directory: `C:\AvatoolWebService\MAWS_Staging\`
* GitHub src/: `C:\MyAvatool\MAWS\Repository\src\`
* Temporary folder: `C:\MyAvatool\Temp\`

### Commands and Actions

MAWSC needs at least a `command` and an `action` to work.

From a console, type `MAWSC -command -action [-option]`

#### Current commands and actions:

*This section will be updated as MAWSC is developed*

MAWSC can do the following:

* `MAWS -staging -deploy`: Deploy only the necessary files needed for MAWS to run in a staging environemnt.
* `MAWS -staging -deploy -full`: Deploy the entire MAWS source to a staging environemnt.

# UPDATING

Since MAWSC is portable, you just need to replace the old version with the new version.

# UNINSTALLING

Since MAWSC is portable, you just need to delete the location where Archiwizator resides.