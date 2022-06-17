# MAWSC.CommandLine

[Arguments.cs](argumentscs)

## Arguments.cs
> Process the command line arguments that are passed to MAWSC at execution.

### Arguments.VerifiedPassed()
- One of the first things MAWSC does when it is executed is verify that arguments were passed.
- If no arguments were passed, we will let the user know, and exit gracefully.
- We aren't testing for valid arguments at this point, only that they (or it) exists.

### GetIndividualArguments()
- There must be a MAWSC session command value - this will have been verified at this point.
- The MAWSC session action/option are optional, and are set to "unused" if not passed via the command line.
- The `rawArguments` are the arguments directly from the command line (e.g., `-staging` `-d`).
- The `rawArguments` are the arguments after they have been cleaned. (e.g., `staging d`).

### GetRawArguments()
- Gets the raw MAWSC session command/action/option from the command line
- These components may contain dashes, and any combination of casing.

### GetRawCommand()
- There must be a MAWSC session command value, which will have been verified at this point.

### GetRawAction()
- The MAWSC session action is optional.
- If an MAWSC session action is not passed, it is set to "unused".

### GetRawOption()
- The MAWSC session option is optional.
- If an MAWSC session option is not passed, it is set to "unused".

### CleanRawArguments()
- Components may contain dashes, and any combination of casing.
- The arguments are cleaned up so it's easier to apply logic to them. For example, if an argument can be passed as `-staging` or `-STAGING` or `--StAgInG`, and it will be cleaned up to be `staging`, which makes it easier to test against.