using System;
using Cosmos.Conversions.Determiners;

namespace Cosmos.Conversions.Common.Core
{
    internal static class EnumConvX
    {
        public static TEnum ObjToEnum<TEnum>(object obj, TEnum defaultVal = default) where TEnum : struct, Enum
        {
            return StringEnumDeterminer<TEnum>.To(StrConvX.ObjectSafeToString(obj), defaultVal: defaultVal);
        }

        public static object ObjToEnum(object obj, Type enumType, object defaultVal = default)
        {
            return StringEnumDeterminer.To(StrConvX.ObjectSafeToString(obj), enumType, defaultVal: defaultVal);
        }

        public static TEnum StringToEnum<TEnum>(string str, bool ignoreCase = false) where TEnum : struct, Enum
        {
            return StringEnumDeterminer<TEnum>.To(str, ignoreCase);
        }

        public static TEnum StringToEnum<TEnum>(string str, TEnum defaultVal, bool ignoreCase = false) where TEnum : struct, Enum
        {
            return StringEnumDeterminer<TEnum>.To(str, ignoreCase, defaultVal);
        }

        public static object StringToEnum(string str, Type enumType, bool ignoreCase = false)
        {
            return StringEnumDeterminer.To(str, enumType, ignoreCase);
        }

        public static object StringToEnum(string str, Type enumType, object defaultVal, bool ignoreCase = false)
        {
            return StringEnumDeterminer.To(str, enumType, ignoreCase, defaultVal);
        }

        public static TEnum? ObjToNullableEnum<TEnum>(object obj) where TEnum : struct, Enum
        {
            var enumStr = StrConvX.ObjectSafeToString(obj);
            if (StringEnumDeterminer<TEnum>.Is(enumStr))
                return StringEnumDeterminer<TEnum>.To(enumStr);
            return null;
        }

        public static object ObjToNullableEnum(object obj, Type enumType)
        {
            var enumStr = StrConvX.ObjectSafeToString(obj);
            if (StringEnumDeterminer.Is(enumStr, enumType))
                return StringEnumDeterminer.To(enumStr, enumType);
            return null;
        }

        public static TEnum? StringToNullableEnum<TEnum>(string str, bool ignoreCase = false) where TEnum : struct, Enum
        {
            if (StringEnumDeterminer<TEnum>.Is(str, ignoreCase))
                return StringEnumDeterminer<TEnum>.To(str, ignoreCase);
            return null;
        }

        public static object StringToNullableEnum(string str, Type enumType, bool ignoreCase = false)
        {
            if (StringEnumDeterminer.Is(str, enumType, ignoreCase))
                return StringEnumDeterminer.To(str, enumType, ignoreCase);
            return null;
        }
    }
}