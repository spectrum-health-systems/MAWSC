# MAWSC: Development Notes

[MAWSC](#mawsc)<br>
[MAWSC.CommandLine](#mawsccommmandline)<br>

# MAWSC

## MAWSC.cs

> Entry point for MAWSC.

## MAWSC.MawscInitializer()

We get the timestamp here, right at the beginning, so we can use the same timestamp throughout the session. Otherwise we might have different timestamps at different times for different things (backups, deployments, etc.)

The initialization process:
1. Verifies the basic requirements that are needed, that don't require configuration settings.
2. Loads the configuration settings (and also creates session-specific settings)
3. Does another round of verifications for things that require configuration settings.
4. Hands things off to the MawscRoundhouse.

# MAWSC.CommandLine

## Arguments.cs

> Processes the command line arguments that are passed to MAWSC at execution.

### Arguments.VerifiedPassed()

- One of the first things MAWSC does when it is executed is verify that arguments were passed.
- If no arguments were passed, we will let the user know, and exit gracefully.
- We aren't testing for valid arguments at this point, only that they (or it) exists.

### GetIndividualComponents()

The `rawComponents` are the arguments directly from the command line (e.g., `-staging -d`)











# MAWSC.Requirement

## VerifyRequirement.Startup

Verify the following, neither of which require configuration settings:
1. The configuration file exists, and is valid
2. Arguments were passed