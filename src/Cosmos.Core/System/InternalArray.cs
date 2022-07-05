namespace System;

internal static class InternalArray
{
#if NET452
    private static class Cache<T>
    {
        public static readonly T[] Empty = new T[0];
    }
#endif

    public static T[] ForEmpty<T>()
    {
#if NET452
        return Cache<T>.Empty;
#else
        return Array.Empty<T>();
#endif
    }
}