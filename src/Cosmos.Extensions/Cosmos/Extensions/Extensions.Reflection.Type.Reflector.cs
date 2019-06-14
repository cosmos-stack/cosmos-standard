using System;
using AspectCore.Extensions.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ReflectionExtensions
    {
        /// <summary>
        /// Is defined special attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDefined<TAttribute>(this Type type) where TAttribute : Attribute
            => type.GetReflector().IsDefined<TAttribute>();

        /// <summary>
        /// Is not defined special attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNotDefined<TAttribute>(this Type type) where TAttribute : Attribute
            => !type.GetReflector().IsDefined<TAttribute>();
    }
}