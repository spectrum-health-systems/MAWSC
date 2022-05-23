namespace MAWSC.MawscCommand
{
    internal class Transform
    {
        /// <summary>
        /// Get the MAWSC command from the command line arguments.
        /// </summary>
        /// <param name="commandLineArguments">Command line arguments.</param>
        /// <returns>The MAWSC command.</returns>
        internal static string Cleaned(string maswcCommand)
        {
            return maswcCommand.Trim().ToLower().Replace("-", "");
        }
    }
}
