using System;
using Cosmos.Conversions.Determiners;

namespace Cosmos.Conversions.Common.Core
{
    internal static class NumConvX
    {
        public static sbyte ObjectToSByte(object obj, sbyte defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is sbyte myself)
                return myself;
            if (obj is string str)
                return StringToSByte(str, defaultVal);
            str = obj.ToString();
            if (StringSByteDeterminer.Is(str))
                return StringToSByte(str, defaultVal);
            try
            {
                return Convert.ToSByte(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static sbyte StringToSByte(string str, sbyte defaultVal = default)
        {
            return StringSByteDeterminer.To(str, defaultVal);
        }

        public static sbyte StringToSByte(string str, params IConversionImpl<string, sbyte>[] impls)
        {
            return StringSByteDeterminer.To(str, impls);
        }

        public static sbyte EnumToSByte<TEnum>(TEnum @enum, sbyte defaultVal = default) where TEnum : struct
        {
            return EnumToSByte(typeof(TEnum), @enum, defaultVal);
        }

        public static sbyte EnumToSByte(Type enumType, object @enum, sbyte defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToSByte(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static sbyte? ObjectToNullableSByte(object obj)
        {
            if (obj is null)
                return null;
            if (obj is sbyte myself)
                return myself;
            if (obj is string str)
                return StringToNullableSByte(str);
            if (sbyte.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static sbyte? StringToNullableSByte(string str)
        {
            if (StringSByteDeterminer.Is(str))
                return StringSByteDeterminer.To(str);
            return null;
        }

        public static sbyte? EnumToNullableSByte<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableSByte(typeof(TEnum), @enum);
        }

        public static sbyte? EnumToNullableSByte(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToSByte(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static byte ObjectToByte(object obj, byte defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is byte myself)
                return myself;
            if (obj is string str)
                return StringToByte(str, defaultVal);
            str = obj.ToString();
            if (StringByteDeterminer.Is(str))
                return StringToByte(str, defaultVal);
            try
            {
                return Convert.ToByte(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static byte StringToByte(string str, byte defaultVal = default)
        {
            return StringByteDeterminer.To(str, defaultVal);
        }

        public static byte StringToByte(string str, params IConversionImpl<string, byte>[] impls)
        {
            return StringByteDeterminer.To(str, impls);
        }

        public static byte EnumToByte<TEnum>(TEnum @enum, byte defaultVal = default) where TEnum : struct
        {
            return EnumToByte(typeof(TEnum), @enum, defaultVal);
        }

        public static byte EnumToByte(Type enumType, object @enum, byte defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToByte(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static byte? ObjectToNullableByte(object obj)
        {
            if (obj is null)
                return null;
            if (obj is byte myself)
                return myself;
            if (obj is string str)
                return StringToNullableByte(str);
            if (byte.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static byte? StringToNullableByte(string str)
        {
            if (StringByteDeterminer.Is(str))
                return StringByteDeterminer.To(str);
            return null;
        }

        public static byte? EnumToNullableByte<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableByte(typeof(TEnum), @enum);
        }

        public static byte? EnumToNullableByte(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToByte(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static short ObjectToInt16(object obj, short defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is short myself)
                return myself;
            if (obj is string str)
                return StringToInt16(str, defaultVal);
            str = obj.ToString();
            if (StringShortDeterminer.Is(str))
                return StringToInt16(str, defaultVal);
            try
            {
                return Convert.ToInt16(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static short StringToInt16(string str, short defaultVal = default)
        {
            return StringShortDeterminer.To(str, defaultVal);
        }

        public static short StringToInt16(string str, params IConversionImpl<string, short>[] impls)
        {
            return StringShortDeterminer.To(str, impls);
        }

        public static short EnumToInt16<TEnum>(TEnum @enum, short defaultVal = default) where TEnum : struct
        {
            return EnumToInt16(typeof(TEnum), @enum, defaultVal);
        }

        public static short EnumToInt16(Type enumType, object @enum, short defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToInt16(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static short? ObjectToNullableInt16(object obj)
        {
            if (obj is null)
                return null;
            if (obj is short myself)
                return myself;
            if (obj is string str)
                return StringToNullableInt16(str);
            if (short.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static short? StringToNullableInt16(string str)
        {
            if (StringShortDeterminer.Is(str))
                return StringShortDeterminer.To(str);
            return null;
        }

        public static short? EnumToNullableInt16<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableInt16(typeof(TEnum), @enum);
        }

        public static short? EnumToNullableInt16(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToInt16(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static ushort ObjectToUInt16(object obj, ushort defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is ushort myself)
                return myself;
            if (obj is string str)
                return StringToUInt16(str, defaultVal);
            str = obj.ToString();
            if (StringUShortDeterminer.Is(str))
                return StringToUInt16(str, defaultVal);
            try
            {
                return Convert.ToUInt16(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static ushort StringToUInt16(string str, ushort defaultVal = default)
        {
            return StringUShortDeterminer.To(str, defaultVal);
        }

        public static ushort StringToUInt16(string str, params IConversionImpl<string, ushort>[] impls)
        {
            return StringUShortDeterminer.To(str, impls);
        }

        public static ushort EnumToUInt16<TEnum>(TEnum @enum, ushort defaultVal = default) where TEnum : struct
        {
            return EnumToUInt16(typeof(TEnum), @enum, defaultVal);
        }

        public static ushort EnumToUInt16(Type enumType, object @enum, ushort defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToUInt16(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static ushort? ObjectToNullableUInt16(object obj)
        {
            if (obj is null)
                return null;
            if (obj is ushort myself)
                return myself;
            if (obj is string str)
                return StringToNullableUInt16(str);
            if (ushort.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static ushort? StringToNullableUInt16(string str)
        {
            if (StringUShortDeterminer.Is(str))
                return StringUShortDeterminer.To(str);
            return null;
        }

        public static ushort? EnumToNullableUInt16<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableUInt16(typeof(TEnum), @enum);
        }

        public static ushort? EnumToNullableUInt16(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToUInt16(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static int ObjectToInt32(object obj, int defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is int myself)
                return myself;
            if (obj is string str)
                return StringToInt32(str, defaultVal);
            str = obj.ToString();
            if (StringIntDeterminer.Is(str))
                return StringToInt32(str, defaultVal);
            try
            {
                return Convert.ToInt32(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static int StringToInt32(string str, int defaultVal = default)
        {
            return StringIntDeterminer.To(str, defaultVal);
        }

        public static int StringToInt32(string str, params IConversionImpl<string, int>[] impls)
        {
            return StringIntDeterminer.To(str, impls);
        }

        public static int EnumToInt32<TEnum>(TEnum @enum, int defaultVal = default) where TEnum : struct
        {
            return EnumToInt32(typeof(TEnum), @enum, defaultVal);
        }

        public static int EnumToInt32(Type enumType, object @enum, int defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToInt32(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static int? ObjectToNullableInt32(object obj)
        {
            if (obj is null)
                return null;
            if (obj is int myself)
                return myself;
            if (obj is string str)
                return StringToNullableInt32(str);
            if (int.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static int? StringToNullableInt32(string str)
        {
            if (StringIntDeterminer.Is(str))
                return StringIntDeterminer.To(str);
            return null;
        }

        public static int? EnumToNullableInt32<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableInt32(typeof(TEnum), @enum);
        }

        public static int? EnumToNullableInt32(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToInt32(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static uint ObjectToUInt32(object obj, uint defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is uint myself)
                return myself;
            if (obj is string str)
                return StringToUInt32(str, defaultVal);
            str = obj.ToString();
            if (StringUIntDeterminer.Is(str))
                return StringToUInt32(str, defaultVal);
            try
            {
                return Convert.ToUInt32(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static uint StringToUInt32(string str, uint defaultVal = default)
        {
            return StringUIntDeterminer.To(str, defaultVal);
        }

        public static uint StringToUInt32(string str, params IConversionImpl<string, uint>[] impls)
        {
            return StringUIntDeterminer.To(str, impls);
        }

        public static uint EnumToUInt32<TEnum>(TEnum @enum, uint defaultVal = default) where TEnum : struct
        {
            return EnumToUInt32(typeof(TEnum), @enum, defaultVal);
        }

        public static uint EnumToUInt32(Type enumType, object @enum, uint defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToUInt32(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static uint? ObjectToNullableUInt32(object obj)
        {
            if (obj is null)
                return null;
            if (obj is uint myself)
                return myself;
            if (obj is string str)
                return StringToNullableUInt32(str);
            if (uint.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static uint? StringToNullableUInt32(string str)
        {
            if (StringUIntDeterminer.Is(str))
                return StringUIntDeterminer.To(str);
            return null;
        }

        public static uint? EnumToNullableUInt32<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableUInt32(typeof(TEnum), @enum);
        }

        public static uint? EnumToNullableUInt32(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToUInt32(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static long ObjectToInt64(object obj, long defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is long myself)
                return myself;
            if (obj is string str)
                return StringToInt64(str, defaultVal);
            str = obj.ToString();
            if (StringLongDeterminer.Is(str))
                return StringToInt64(str, defaultVal);
            try
            {
                return Convert.ToInt64(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static long StringToInt64(string str, long defaultVal = default)
        {
            return StringLongDeterminer.To(str, defaultVal);
        }

        public static long StringToInt64(string str, params IConversionImpl<string, long>[] impls)
        {
            return StringLongDeterminer.To(str, impls);
        }

        public static long EnumToInt64<TEnum>(TEnum @enum, long defaultVal = default) where TEnum : struct
        {
            return EnumToInt64(typeof(TEnum), @enum, defaultVal);
        }

        public static long EnumToInt64(Type enumType, object @enum, long defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToInt64(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static long? ObjectToNullableInt64(object obj)
        {
            if (obj is null)
                return null;
            if (obj is long myself)
                return myself;
            if (obj is string str)
                return StringToNullableInt64(str);
            if (long.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static long? StringToNullableInt64(string str)
        {
            if (StringLongDeterminer.Is(str))
                return StringLongDeterminer.To(str);
            return null;
        }

        public static long? EnumToNullableInt64<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableInt64(typeof(TEnum), @enum);
        }

        public static long? EnumToNullableInt64(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToInt64(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static ulong ObjectToUInt64(object obj, ulong defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is ulong myself)
                return myself;
            if (obj is string str)
                return StringToUInt64(str, defaultVal);
            str = obj.ToString();
            if (StringULongDeterminer.Is(str))
                return StringToUInt64(str, defaultVal);
            try
            {
                return Convert.ToUInt64(ObjectToDecimal(obj, defaultVal));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static ulong StringToUInt64(string str, ulong defaultVal = default)
        {
            return StringULongDeterminer.To(str, defaultVal);
        }

        public static ulong StringToUInt64(string str, params IConversionImpl<string, ulong>[] impls)
        {
            return StringULongDeterminer.To(str, impls);
        }

        public static ulong EnumToUInt64<TEnum>(TEnum @enum, ulong defaultVal = default) where TEnum : struct
        {
            return EnumToUInt64(typeof(TEnum), @enum, defaultVal);
        }

        public static ulong EnumToUInt64(Type enumType, object @enum, ulong defaultVal = default)
        {
            try
            {
                return EnumsNET.Enums.ToUInt64(enumType, @enum);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static ulong? ObjectToNullableUInt64(object obj)
        {
            if (obj is null)
                return null;
            if (obj is ulong myself)
                return myself;
            if (obj is string str)
                return StringToNullableUInt64(str);
            if (ulong.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static ulong? StringToNullableUInt64(string str)
        {
            if (StringULongDeterminer.Is(str))
                return StringULongDeterminer.To(str);
            return null;
        }

        public static ulong? EnumToNullableUInt64<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableUInt64(typeof(TEnum), @enum);
        }

        public static ulong? EnumToNullableUInt64(Type enumType, object @enum)
        {
            try
            {
                return EnumsNET.Enums.ToUInt64(enumType, @enum);
            }
            catch
            {
                return null;
            }
        }

        public static float ObjectToFloat(object obj, float defaultVal = 0F)
        {
            if (obj is null)
                return defaultVal;
            if (obj is float myself)
                return myself;
            if (obj is string str)
                return StringToFloat(str, defaultVal);
            return StringFloatDeterminer.To(obj.ToString(), defaultVal);
        }

        public static float StringToFloat(string str, float defaultVal = default)
        {
            return StringFloatDeterminer.To(str, defaultVal);
        }

        public static float StringToFloat(string str, params IConversionImpl<string, float>[] impls)
        {
            return StringFloatDeterminer.To(str, impls);
        }

        public static float? ObjectToNullableFloat(object obj)
        {
            if (obj is null)
                return null;
            if (obj is float myself)
                return myself;
            if (obj is string str)
                return StringToNullableFloat(str);
            return null;
        }

        public static float? StringToNullableFloat(string str)
        {
            if (StringFloatDeterminer.Is(str))
                return StringFloatDeterminer.To(str);
            return null;
        }

        public static double ObjectToDouble(object obj, double defaultVal = 0D)
        {
            if (obj is null)
                return defaultVal;
            if (obj is double myself)
                return myself;
            if (obj is string str)
                return StringToDouble(str, defaultVal);
            str = obj.ToString();
            if (StringDoubleDeterminer.Is(str))
                return StringToDouble(str, defaultVal);
            try
            {
                return Convert.ToDouble(ObjectToDecimal(obj));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static double StringToDouble(string str, double defaultVal = default)
        {
            return StringDoubleDeterminer.To(str, defaultVal);
        }

        public static double StringToDouble(string str, params IConversionImpl<string, double>[] impls)
        {
            return StringDoubleDeterminer.To(str, impls);
        }

        public static double? ObjectToNullableDouble(object obj)
        {
            if (obj is null)
                return null;
            if (obj is double myself)
                return myself;
            if (obj is string str)
                return StringToNullableDouble(str);
            if (double.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static double? StringToNullableDouble(string str)
        {
            if (StringDoubleDeterminer.Is(str))
                return StringDoubleDeterminer.To(str);
            return null;
        }

        public static double ObjectToRoundDouble(object obj, int digits, double defaultVal = 0D)
        {
            return Math.Round(ObjectToDouble(obj, defaultVal), digits);
        }

        public static double StringToRoundDouble(string str, int digits, double defaultVal = default)
        {
            return Math.Round(StringToDouble(str, defaultVal), digits);
        }

        public static double? ObjectToNullableRoundDouble(object obj, int digits)
        {
            var ret = ObjectToNullableDouble(obj);
            if (ret is null)
            {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }

        public static double? StringToNullableRoundDouble(string str, int digits)
        {
            var ret = StringToNullableDouble(str);
            if (ret is null)
            {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }

        public static decimal ObjectToDecimal(object obj, decimal defaultVal = 0M)
        {
            if (obj is null)
                return defaultVal;
            if (obj is decimal myself)
                return myself;
            if (obj is string str)
                return StringToDecimal(str, defaultVal);
            str = obj.ToString();
            if (StringDecimalDeterminer.Is(str))
                return StringToDecimal(str, defaultVal);
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static decimal StringToDecimal(string str, decimal defaultVal = default)
        {
            return StringDecimalDeterminer.To(str, defaultVal);
        }

        public static decimal StringToDecimal(string str, params IConversionImpl<string, decimal>[] impls)
        {
            return StringDecimalDeterminer.To(str, impls);
        }

        public static decimal? ObjectToNullableDecimal(object obj)
        {
            if (obj is null)
                return null;
            if (obj is decimal myself)
                return myself;
            if (obj is string str)
                return StringToNullableDecimal(str);
            if (decimal.TryParse(obj.ToString(), out var ret))
                return ret;
            return null;
        }

        public static decimal? StringToNullableDecimal(string str)
        {
            if (StringDecimalDeterminer.Is(str))
                return StringDecimalDeterminer.To(str);
            return null;
        }

        public static decimal ObjectToRoundDecimal(object obj, int digits, decimal defaultVal = 0M)
        {
            return Math.Round(ObjectToDecimal(obj, defaultVal), digits);
        }

        public static decimal StringToRoundDecimal(string str, int digits, decimal defaultVal = default)
        {
            return Math.Round(StringToDecimal(str, defaultVal), digits);
        }

        public static decimal? ObjectToNullableRoundDecimal(object obj, int digits)
        {
            var ret = ObjectToNullableDecimal(obj);
            if (ret is null)
            {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }

        public static decimal? StringToNullableRoundDecimal(string str, int digits)
        {
            var ret = StringToNullableDecimal(str);
            if (ret is null)
            {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }
    }
}