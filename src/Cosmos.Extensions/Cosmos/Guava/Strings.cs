namespace Cosmos.Guava
{
    public static class Strings
    {
        public static string NullToEmpty(string @string)
        {
            return @string ?? string.Empty;
        }
    }
}
