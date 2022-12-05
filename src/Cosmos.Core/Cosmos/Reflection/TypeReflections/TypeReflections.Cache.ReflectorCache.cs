using System.Collections.Concurrent;

namespace Cosmos.Reflection;

/// <summary>
/// Reflection Utilities.
/// </summary>
public static partial class TypeReflections
{
    internal static class ReflectorCacheUtils<TMemberInfo, TReflector> where TMemberInfo : notnull
    {
        private static readonly ConcurrentDictionary<TMemberInfo, TReflector> Dictionary = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TReflector GetOrAdd(TMemberInfo key, Func<TMemberInfo, TReflector> factory)
        {
            return Dictionary.GetOrAdd(key, factory);
        }
    }
}