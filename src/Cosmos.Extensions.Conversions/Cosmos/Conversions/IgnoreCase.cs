namespace Cosmos.Conversions
{
    /// <summary>
    /// Ignore case
    /// </summary>
    public enum IgnoreCase
    {
        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// True
        /// </summary>
        TRUE,

        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// False
        /// </summary>
        FALSE
    }

    internal static class IgnoreCaseExtensions
    {
        public static bool X(this IgnoreCase ignoreCase)
        {
            return ignoreCase switch
            {
                IgnoreCase.TRUE  => true,
                IgnoreCase.FALSE => false,
                _                => false
            };
        }

        public static IgnoreCase X(this bool b)
        {
            return b switch
            {
                true  => IgnoreCase.TRUE,
                false => IgnoreCase.FALSE
            };
        }
    }
}