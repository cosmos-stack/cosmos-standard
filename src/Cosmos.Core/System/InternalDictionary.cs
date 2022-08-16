namespace System;

internal static class InternalDictionary
{
    private static class Cache<D, K, V> where D : IDictionary<K, V>, new()
    {
        public static readonly D Empty = new();
    }

    public static D ForEmpty<D, K, V>() where D : IDictionary<K, V>, new()
    {
        return Cache<D, K, V>.Empty;
    }
}