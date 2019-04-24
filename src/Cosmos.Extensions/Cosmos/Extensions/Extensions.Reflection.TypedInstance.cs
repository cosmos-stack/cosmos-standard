using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ReflectionExtensions
    {
        public static TTypeInstance CreateInstance<TTypeInstance>(this Type type, params object[] args)
            => Types.CreateInstance<TTypeInstance>(type, args);
    }
}