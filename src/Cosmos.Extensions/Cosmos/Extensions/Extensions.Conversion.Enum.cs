using System;
using Cosmos.Conversions.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {
        private static TTo CastEnumToNumericProxy<TTo>(Type enumType, object fromObj, Type targetObjType, TTo defaultVal) {
            try {
                if(targetObjType == typeof(byte))
                    return EnumsNET.Enums.ToByte(enumType, fromObj).As<TTo>();
                if(targetObjType == typeof(sbyte))
                    return EnumsNET.Enums.ToSByte(enumType, fromObj).As<TTo>();
                if (targetObjType == typeof(short))
                    return EnumsNET.Enums.ToInt16(enumType, fromObj).As<TTo>();
                if (targetObjType == typeof(ushort))
                    return EnumsNET.Enums.ToUInt16(enumType, fromObj).As<TTo>();
                if (targetObjType == typeof(int))
                    return EnumsNET.Enums.ToInt32(enumType, fromObj).As<TTo>();
                if(targetObjType ==typeof(uint))
                    return EnumsNET.Enums.ToUInt32(enumType, fromObj).As<TTo>();
                if(targetObjType == typeof(long))
                    return EnumsNET.Enums.ToInt64(enumType, fromObj).As<TTo>();
                if(targetObjType == typeof(ulong))
                    return EnumsNET.Enums.ToUInt64(enumType, fromObj).As<TTo>();
                return defaultVal;
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str) where TEnum : struct
            => StringEnumHelper<TEnum>.To(str);

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str">     </param>
        /// <param name="ignoreCase"> 是否区分大小写 </param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase) where TEnum : struct
            => StringEnumHelper<TEnum>.To(str, ignoreCase);

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, TEnum defaultVal) where TEnum : struct
            => StringEnumHelper<TEnum>.To(str, defaultVal: defaultVal);

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase, TEnum defaultVal) where TEnum : struct
            => StringEnumHelper<TEnum>.To(str, ignoreCase, defaultVal);
    }
}