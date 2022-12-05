﻿using System.Collections.Concurrent;

namespace Cosmos.Reflection;

internal static class StrongTypedCache<T>
{
    public static readonly ConcurrentDictionary<PropertyInfo, Func<T, object>> PropertyValueGetters = new();

    public static readonly ConcurrentDictionary<PropertyInfo, Action<T, object>> PropertyValueSetters = new();
}