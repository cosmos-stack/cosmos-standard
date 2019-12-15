using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class ReflectionExtensions {
        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TTypeInstance"></typeparam>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static TTypeInstance CreateInstance<TTypeInstance>(this Type type, params object[] args)
            => Types.CreateInstance<TTypeInstance>(type, args);
    }
}