namespace MAWSC.Configuration
{
    internal class Roundhouse
    {
        /// <summary>
        /// Process a configuration action.
        /// </summary>
        /// <param name="mawscAction"></param>
        /// <param name="mawscOption"></param>
        /// <param name="mawscConfiguration"></param>
        internal static void ProcessAction(string mawscAction, string mawscOption, Settings mawscSettings)
        {
            if(mawscSettings.ValidActions.Contains(mawscAction))
            {
                switch(mawscAction)
                {
                    case "r":
                    case "reset":
                        Configuration.Action.Reset();
                        MAWSC.Terminate.Gracefully(0);
                        break;

                    default:
                        // Catch here.
                        break;
                }
            }
        }
    }
}
