namespace Cosmos.Collections.Pagination.Internals;

internal static class Int32Extensions
{
    public static bool IsValid(this int? int32Value)
    {
        return int32Value is not null;
    }
}