namespace Cosmos.Text
{
    public static class IgnoreCaseExtensions
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

        internal static IgnoreCase X(this bool b)
        {
            return b switch
            {
                true => IgnoreCase.TRUE,
                false => IgnoreCase.FALSE
            };
        }
    }
}