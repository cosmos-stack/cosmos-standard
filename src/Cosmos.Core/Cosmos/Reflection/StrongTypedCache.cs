﻿using System.Collections.Concurrent;
using System.Reflection;

namespace Cosmos.Reflection
{
    public static class StrongTypedCache<T>
    {
        public static readonly ConcurrentDictionary<PropertyInfo, Func<T, object>> PropertyValueGetters = new();

        public static readonly ConcurrentDictionary<PropertyInfo, Action<T, object>> PropertyValueSetters = new();
    }
}