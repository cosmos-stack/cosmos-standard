using System;
using Cosmos.Conversions.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
        /// <summary>
        /// Is Enum
        /// </summary>
        /// <param name="str"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static bool IsEnum(this string str, Type enumType) => StringEnumHelper.Is(str, enumType);

        /// <summary>
        /// Is Enum
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static bool IsEnum<TEnum>(this string str) where TEnum : struct => StringEnumHelper<TEnum>.Is(str);
    }
}