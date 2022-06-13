# MAWSC: Development Notes

# MAWSC.cs

> Entry point for MAWSC.

## MawscInitializer()

We get the timestamp here, right at the beginning, so we can use the same timestamp throughout the session. Otherwise we might have different timestamps at different times for different things (backups, deployments, etc.)

The initialization process:
1. Verifies the basic requirements that are needed, that don't require configuration settings.
2. Loads the configuration settings (and also creates session-specific settings)
3. Does another round of verifications for things that require configuration settings.
4. Hands things off to the MawscRoundhouse.