using System;
using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions {
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions {
        /// <summary>
        /// Convert <see cref="string"/> to TEnum.
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str) where TEnum : struct, Enum => EnumConv.StringToEnum<TEnum>(str);

        /// <summary>
        /// Convert <see cref="string"/> to TEnum.
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str">     </param>
        /// <param name="ignoreCase"> 是否区分大小写 </param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase) where TEnum : struct, Enum => EnumConv.StringToEnum<TEnum>(str, ignoreCase);

        /// <summary>
        /// Convert <see cref="string"/> to TEnum.
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, TEnum defaultVal) where TEnum : struct, Enum => EnumConv.StringToEnum(str, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to TEnum. 
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase, TEnum defaultVal) where TEnum : struct, Enum => EnumConv.StringToEnum(str, defaultVal, ignoreCase);
    }
}