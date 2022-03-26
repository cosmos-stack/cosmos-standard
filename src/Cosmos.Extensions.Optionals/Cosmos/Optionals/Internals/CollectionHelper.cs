using System.Collections;

namespace Cosmos.Optionals.Internals;

internal static class CollectionHelper
{
    /// <summary>
    /// To judge whether the collection is null or empty.
    /// </summary>
    /// <param name="coll"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(IEnumerable coll)
    {
        if (coll is null)
            return true;

        return !coll.Cast<object>().Any();
    }

    /// <summary>
    /// To judge whether the collection is null or empty.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="coll"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(IEnumerable<T> coll) => coll is null || !coll.Any();
}