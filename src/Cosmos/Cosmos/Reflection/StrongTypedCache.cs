using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cosmos.Reflection
{
    internal static class StrongTypedCache<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static readonly ConcurrentDictionary<PropertyInfo, Func<T, object>> PropertyValueGetters = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static readonly ConcurrentDictionary<PropertyInfo, Action<T, object>> PropertyValueSetters = new();
    }
}