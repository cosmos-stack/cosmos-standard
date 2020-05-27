namespace Cosmos.Conversions.Mapper
{
    internal static class DefaultMapperCache
    {
        /// <summary>
        /// Gets a default mapper instance.
        /// </summary>
        public static IObjectMapper Instance = new DefaultMapper();
    }
}