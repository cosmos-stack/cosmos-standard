using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace CosmosStack.Reflection
{
    internal static class StrongTypedCache<T>
    {
        public static readonly ConcurrentDictionary<PropertyInfo, Func<T, object>> PropertyValueGetters = new();

        public static readonly ConcurrentDictionary<PropertyInfo, Action<T, object>> PropertyValueSetters = new();
    }
}