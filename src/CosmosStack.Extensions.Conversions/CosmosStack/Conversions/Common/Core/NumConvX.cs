using System;
using CosmosStack.Conversions.Determiners;

namespace CosmosStack.Conversions.Common.Core
{

    internal static class NumConvX
    {
        public static sbyte ObjectToSByte(object obj, sbyte defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                sbyte myself => myself,
                string str => StringToSByte(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringSByteDeterminer.IS, defaultVal, StringToSByte, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToSByte(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToSByte(enumType, @enum), defaultVal);
        }

        public static sbyte? ObjectToNullableSByte(object obj)
        {
            return obj switch
            {
                null => null,
                sbyte myself => myself,
                string str => StringToNullableSByte(str),
                _ => sbyte.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static sbyte? StringToNullableSByte(string str)
        {
            return StringSByteDeterminer.Is(str) ? StringSByteDeterminer.To(str) : null;
        }

        public static sbyte? EnumToNullableSByte<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableSByte(typeof(TEnum), @enum);
        }

        public static sbyte? EnumToNullableSByte(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToSByte(enumType, @enum), default(sbyte?));
        }

        public static byte ObjectToByte(object obj, byte defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                string str => StringToByte(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringByteDeterminer.IS, defaultVal, StringToByte, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToByte(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToByte(enumType, @enum), defaultVal);
        }

        public static byte? ObjectToNullableByte(object obj)
        {
            return obj switch
            {
                null => null,
                byte myself => myself,
                string str => StringToNullableByte(str),
                _ => byte.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static byte? StringToNullableByte(string str)
        {
            return StringByteDeterminer.Is(str) ? StringByteDeterminer.To(str) : null;
        }

        public static byte? EnumToNullableByte<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableByte(typeof(TEnum), @enum);
        }

        public static byte? EnumToNullableByte(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToByte(enumType, @enum), default(byte?));
        }

        public static short ObjectToInt16(object obj, short defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                short myself => myself,
                string str => StringToInt16(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringShortDeterminer.IS, defaultVal, StringToInt16, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToInt16(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToInt16(enumType, @enum), defaultVal);
        }

        public static short? ObjectToNullableInt16(object obj)
        {
            return obj switch
            {
                null => null,
                short myself => myself,
                string str => StringToNullableInt16(str),
                _ => short.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static short? StringToNullableInt16(string str)
        {
            return StringShortDeterminer.Is(str) ? StringShortDeterminer.To(str) : null;
        }

        public static short? EnumToNullableInt16<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableInt16(typeof(TEnum), @enum);
        }

        public static short? EnumToNullableInt16(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToInt16(enumType, @enum), default(short?));
        }

        public static ushort ObjectToUInt16(object obj, ushort defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                ushort myself => myself,
                string str => StringToUInt16(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringUShortDeterminer.IS, defaultVal, StringToUInt16, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToUInt16(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToUInt16(enumType, @enum), defaultVal);
        }

        public static ushort? ObjectToNullableUInt16(object obj)
        {
            return obj switch
            {
                null => null,
                ushort myself => myself,
                string str => StringToNullableUInt16(str),
                _ => ushort.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static ushort? StringToNullableUInt16(string str)
        {
            return StringUShortDeterminer.Is(str) ? StringUShortDeterminer.To(str) : null;
        }

        public static ushort? EnumToNullableUInt16<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableUInt16(typeof(TEnum), @enum);
        }

        public static ushort? EnumToNullableUInt16(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToUInt16(enumType, @enum), default(ushort?));
        }

        public static int ObjectToInt32(object obj, int defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                string str => StringToInt32(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringIntDeterminer.IS, defaultVal, StringToInt32, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToInt32(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToInt32(enumType, @enum), defaultVal);
        }

        public static int? ObjectToNullableInt32(object obj)
        {
            return obj switch
            {
                null => null,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                string str => StringToNullableInt32(str),
                _ => int.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static int? StringToNullableInt32(string str)
        {
            return StringIntDeterminer.Is(str) ? StringIntDeterminer.To(str) : null;
        }

        public static int? EnumToNullableInt32<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableInt32(typeof(TEnum), @enum);
        }

        public static int? EnumToNullableInt32(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToInt32(enumType, @enum), default(int?));
        }

        public static uint ObjectToUInt32(object obj, uint defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                ushort myself => myself,
                uint myself => myself,
                string str => StringToUInt32(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringUIntDeterminer.IS, defaultVal, StringToUInt32, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToUInt32(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToUInt32(enumType, @enum), defaultVal);
        }

        public static uint? ObjectToNullableUInt32(object obj)
        {
            return obj switch
            {
                null => null,
                byte myself => myself,
                ushort myself => myself,
                uint myself => myself,
                string str => StringToNullableUInt32(str),
                _ => uint.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static uint? StringToNullableUInt32(string str)
        {
            return StringUIntDeterminer.Is(str) ? StringUIntDeterminer.To(str) : null;
        }

        public static uint? EnumToNullableUInt32<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableUInt32(typeof(TEnum), @enum);
        }

        public static uint? EnumToNullableUInt32(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToUInt32(enumType, @enum), default(uint?));
        }

        public static long ObjectToInt64(object obj, long defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                string str => StringToInt64(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringLongDeterminer.IS, defaultVal, StringToInt64, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToInt64(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToInt64(enumType, @enum), defaultVal);
        }

        public static long? ObjectToNullableInt64(object obj)
        {
            return obj switch
            {
                null => null,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                string str => StringToNullableInt64(str),
                _ => long.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static long? StringToNullableInt64(string str)
        {
            return StringLongDeterminer.Is(str) ? StringLongDeterminer.To(str) : null;
        }

        public static long? EnumToNullableInt64<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableInt64(typeof(TEnum), @enum);
        }

        public static long? EnumToNullableInt64(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToInt64(enumType, @enum), default(long?));
        }

        public static ulong ObjectToUInt64(object obj, ulong defaultVal = default)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                ushort myself => myself,
                uint myself => myself,
                ulong myself => myself,
                string str => StringToUInt64(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringULongDeterminer.IS, defaultVal, StringToUInt64, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToUInt64(ObjectToDecimal(obj, defaultVal)), defaultVal)
            };
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
            return XConvHelper.T(() => EnumsNET.Enums.ToUInt64(enumType, @enum), defaultVal);
        }

        public static ulong? ObjectToNullableUInt64(object obj)
        {
            return obj switch
            {
                null => null,
                byte myself => myself,
                ushort myself => myself,
                uint myself => myself,
                ulong myself => myself,
                string str => StringToNullableUInt64(str),
                _ => ulong.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static ulong? StringToNullableUInt64(string str)
        {
            return StringULongDeterminer.Is(str) ? StringULongDeterminer.To(str) : null;
        }

        public static ulong? EnumToNullableUInt64<TEnum>(TEnum @enum) where TEnum : struct
        {
            return EnumToNullableUInt64(typeof(TEnum), @enum);
        }

        public static ulong? EnumToNullableUInt64(Type enumType, object @enum)
        {
            return XConvHelper.T(() => EnumsNET.Enums.ToUInt64(enumType, @enum), default(ulong?));
        }

        public static float ObjectToFloat(object obj, float defaultVal = 0F)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                ulong myself => myself,
                float myself => myself,
                double myself => StringToFloat(myself.ToString("N9")),
                decimal myself => StringToFloat(myself.ToString("N9")),
                string str => StringToFloat(str, defaultVal),
                _ => StringFloatDeterminer.To(obj.ToString(), defaultVal)
            };
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
            return obj switch
            {
                null => null,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                ulong myself => myself,
                float myself => myself,
                double myself => StringToNullableFloat(myself.ToString("N9")),
                decimal myself => StringToNullableFloat(myself.ToString("N9")),
                string str => StringToNullableFloat(str),
                _ => null
            };
        }

        public static float? StringToNullableFloat(string str)
        {
            return StringFloatDeterminer.Is(str)
                ? StringFloatDeterminer.To(str)
                : null;
        }

        public static double ObjectToDouble(object obj, double defaultVal = 0D)
        {
            return obj switch
            {
                null => defaultVal,
                double myself => myself,
                string str => StringToDouble(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringDoubleDeterminer.IS, defaultVal, StringToDouble, out var val)
                    ? val
                    : XConvHelper.T(() => Convert.ToDouble(ObjectToDecimal(obj)), defaultVal)
            };
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
            return obj switch
            {
                null => null,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                ulong myself => myself,
                float myself => myself,
                double myself => myself,
                string str => StringToNullableDouble(str),
                _ => double.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static double? StringToNullableDouble(string str)
        {
            return StringDoubleDeterminer.Is(str)
                ? StringDoubleDeterminer.To(str)
                : null;
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
            return ret switch
            {
                null => null,
                _ => Math.Round(ret.Value, digits)
            };
        }

        public static double? StringToNullableRoundDouble(string str, int digits)
        {
            var ret = StringToNullableDouble(str);
            return ret switch
            {
                null => null,
                _ => Math.Round(ret.Value, digits)
            };
        }

        public static decimal ObjectToDecimal(object obj, decimal defaultVal = 0M)
        {
            return obj switch
            {
                null => defaultVal,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                ulong myself => myself,
                float myself => (decimal) myself,
                double myself => (decimal) myself,
                decimal myself => myself,
                string str => StringToDecimal(str, defaultVal),
                _ => XConvHelper.D(obj.ToString(), StringDecimalDeterminer.IS, defaultVal, StringToDecimal, out var val) ? val : XConvHelper.T(() => Convert.ToDecimal(obj), defaultVal)
            };
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
            return obj switch
            {
                null => null,
                byte myself => myself,
                sbyte myself => myself,
                short myself => myself,
                ushort myself => myself,
                int myself => myself,
                uint myself => myself,
                long myself => myself,
                ulong myself => myself,
                float myself => (decimal) myself,
                double myself => (decimal) myself,
                decimal myself => myself,
                string str => StringToNullableDecimal(str),
                _ => decimal.TryParse(obj.ToString(), out var ret) ? ret : null
            };
        }

        public static decimal? StringToNullableDecimal(string str)
        {
            return StringDecimalDeterminer.Is(str) ? StringDecimalDeterminer.To(str) : null;
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
            return ret switch
            {
                null => null,
                _ => Math.Round(ret.Value, digits)
            };
        }

        public static decimal? StringToNullableRoundDecimal(string str, int digits)
        {
            var ret = StringToNullableDecimal(str);
            return ret switch
            {
                null => null,
                _ => Math.Round(ret.Value, digits)
            };
        }
    }
}