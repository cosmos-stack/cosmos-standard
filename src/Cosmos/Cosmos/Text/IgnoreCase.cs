namespace Cosmos.Text
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
                IgnoreCase.TRUE => true,
                IgnoreCase.FALSE => false,
                _ => false
            };
        }

        public static IgnoreCase X(this bool b)
        {
            return b switch
            {
                true => IgnoreCase.TRUE,
                false => IgnoreCase.FALSE
            };
        }
    }

    internal static class IgnoreCaseHelper
    {
        public static char[] FillChars(char[] chars)
        {
            var t = new char[chars.Length * 2];
            for (var i = 0; i < chars.Length; i++)
            {
                t[i * 2] = char.ToLowerInvariant(chars[i]);
                t[i * 2 + 1] = char.ToUpperInvariant(chars[i]);
            }

            return t;
        }
    }
}