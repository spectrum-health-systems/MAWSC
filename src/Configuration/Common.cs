namespace MAWSC.Configuration
{
    internal class Common
    {

        /// <summary>Get the MAWSC configuration default filepath.</summary>
        /// <remarks>
        ///     <para>
        ///         <b><u>NOTES</u></b>
        ///         - The default filepath is <i>./AppData/Config/mawsc-config.json</i>.
        ///     </para>
        /// </remarks>
        /// <returns>Default configuration file path.</returns>
        internal static string GetDefaultFilePath()
        {
            return $@"./AppData/Config/mawsc-config.json";
        }
    }
}
