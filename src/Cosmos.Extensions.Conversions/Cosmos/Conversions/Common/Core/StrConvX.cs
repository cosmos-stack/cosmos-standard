using System;
using Cosmos.IdUtils;
using Cosmos.Optionals;
using Cosmos.Text;

// ReSharper disable InconsistentNaming

namespace Cosmos.Conversions.Common.Core
{
    internal static class StrConvX
    {
        private const int DEFAULT_DIGITS = 2;

        public static string ObjectSafeToString(object obj, string defaultVal = default)
        {
            return obj?.ToString() ?? defaultVal ?? string.Empty;
        }

        public static string ByteToString(byte number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string ByteToString(byte? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? ByteToString(result, options, defaultVal) : defaultVal;
        }

        public static string ByteToString(byte? number, NumericConvOptions options, byte defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => ByteToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => ByteToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => ByteToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string SByteToString(sbyte number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string SByteToString(sbyte? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? SByteToString(result, options, defaultVal) : defaultVal;
        }

        public static string SByteToString(sbyte? number, NumericConvOptions options, sbyte defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => SByteToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => SByteToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => SByteToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string Int16ToString(short number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string Int16ToString(short? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? Int16ToString(result, options, defaultVal) : defaultVal;
        }

        public static string Int16ToString(short? number, NumericConvOptions options, short defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => Int16ToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => Int16ToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => Int16ToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string UInt16ToString(ushort number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string UInt16ToString(ushort? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? UInt16ToString(result, options, defaultVal) : defaultVal;
        }

        public static string UInt16ToString(ushort? number, NumericConvOptions options, ushort defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => UInt16ToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => UInt16ToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => UInt16ToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string Int32ToString(int number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string Int32ToString(int? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? Int32ToString(result, options, defaultVal) : defaultVal;
        }

        public static string Int32ToString(int? number, NumericConvOptions options, int defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => Int32ToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => Int32ToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => Int32ToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string UInt32ToString(uint number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string UInt32ToString(uint? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? UInt32ToString(result, options, defaultVal) : defaultVal;
        }

        public static string UInt32ToString(uint? number, NumericConvOptions options, uint defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => UInt32ToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => UInt32ToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => UInt32ToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string Int64ToString(long number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string Int64ToString(long? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? Int64ToString(result, options, defaultVal) : defaultVal;
        }

        public static string Int64ToString(long? number, NumericConvOptions options, long defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => Int64ToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => Int64ToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => Int64ToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string UInt64ToString(ulong number, NumericConvOptions options, string defaultVal = "0")
        {
            return options switch
            {
                NumericConvOptions.Default => number.ToString(),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(),
                _ => number.ToString()
            };
        }

        public static string UInt64ToString(ulong? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? UInt64ToString(result, options, defaultVal) : defaultVal;
        }

        public static string UInt64ToString(ulong? number, NumericConvOptions options, ulong defaultVal)
        {
            return options switch
            {
                NumericConvOptions.Default => UInt64ToString(number.SafeValue(defaultVal), options, defaultVal.ToString()),
                NumericConvOptions.ZeroAsEmpty => UInt64ToString(number.SafeValue(), options, defaultVal.ToString()),
                _ => UInt64ToString(number.SafeValue(defaultVal), options, defaultVal.ToString())
            };
        }

        public static string FloatToString(float number, NumericConvOptions options, string defaultVal = "0.00")
        {
            return FloatToString(number, 2, options, defaultVal);
        }

        public static string FloatToString(float number, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            if (digits < 0) digits = DEFAULT_DIGITS;
            var format = $"0.{"#".Repeat(digits)}";
            return options switch
            {
                NumericConvOptions.Default => number.ToString(format),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(format),
                _ => number.ToString(format)
            };
        }

        public static string FloatToString(float? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? FloatToString(result, options, defaultVal) : defaultVal;
        }

        public static string FloatToString(float? number, NumericConvOptions options, float defaultVal)
        {
            var format = $"0.{"#".Repeat(DEFAULT_DIGITS)}";
            return options switch
            {
                NumericConvOptions.Default => FloatToString(number.SafeValue(defaultVal), DEFAULT_DIGITS, options, defaultVal.ToString(format)),
                NumericConvOptions.ZeroAsEmpty => FloatToString(number.SafeValue(), DEFAULT_DIGITS, options, defaultVal.ToString(format)),
                _ => FloatToString(number.SafeValue(defaultVal), DEFAULT_DIGITS, options, defaultVal.ToString(format))
            };
        }

        public static string FloatToString(float? number, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? FloatToString(result, digits,options, defaultVal) : defaultVal;
        }

        public static string FloatToString(float? number, int digits, NumericConvOptions options, float defaultVal)
        {
            if (digits < 0) digits = DEFAULT_DIGITS;
            var format = $"0.{"#".Repeat(digits)}";
            return options switch
            {
                NumericConvOptions.Default => FloatToString(number.SafeValue(defaultVal), digits, options, defaultVal.ToString(format)),
                NumericConvOptions.ZeroAsEmpty => FloatToString(number.SafeValue(), digits, options, defaultVal.ToString(format)),
                _ => FloatToString(number.SafeValue(defaultVal), digits, options, defaultVal.ToString(format))
            };
        }

        public static string DoubleToString(double number, NumericConvOptions options, string defaultVal = "0.00")
        {
            return DoubleToString(number, DEFAULT_DIGITS, options, defaultVal);
        }

        public static string DoubleToString(double number, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            if (digits < 0) digits = DEFAULT_DIGITS;
            var format = $"0.{"#".Repeat(digits)}";
            return options switch
            {
                NumericConvOptions.Default => number.ToString(format),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(format),
                _ => number.ToString(format)
            };
        }

        public static string DoubleToString(double? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? DoubleToString(result, options, defaultVal) : defaultVal;
        }

        public static string DoubleToString(double? number, NumericConvOptions options, double defaultVal)
        {
            var format = $"0.{"#".Repeat(DEFAULT_DIGITS)}";
            return options switch
            {
                NumericConvOptions.Default => DoubleToString(number.SafeValue(defaultVal), DEFAULT_DIGITS, options, defaultVal.ToString(format)),
                NumericConvOptions.ZeroAsEmpty => DoubleToString(number.SafeValue(), DEFAULT_DIGITS, options, defaultVal.ToString(format)),
                _ => DoubleToString(number.SafeValue(defaultVal), DEFAULT_DIGITS, options, defaultVal.ToString(format))
            };
        }

        public static string DoubleToString(double? number, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? DoubleToString(result, digits, options, defaultVal) : defaultVal;
        }

        public static string DoubleToString(double? number, int digits, NumericConvOptions options, double defaultVal)
        {
            if (digits < 0) digits = DEFAULT_DIGITS;
            var format = $"0.{"#".Repeat(digits)}";
            return options switch
            {
                NumericConvOptions.Default => DoubleToString(number.SafeValue(defaultVal), digits, options, defaultVal.ToString(format)),
                NumericConvOptions.ZeroAsEmpty => DoubleToString(number.SafeValue(), digits, options, defaultVal.ToString(format)),
                _ => DoubleToString(number.SafeValue(defaultVal), digits, options, defaultVal.ToString(format))
            };
        }

        public static string DecimalToString(decimal number, NumericConvOptions options, string defaultVal = "0.00")
        {
            return DecimalToString(number, DEFAULT_DIGITS, options, defaultVal);
        }

        public static string DecimalToString(decimal number, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            if (digits < 0) digits = DEFAULT_DIGITS;
            var format = $"0.{"#".Repeat(digits)}";
            return options switch
            {
                NumericConvOptions.Default => number.ToString(format),
                NumericConvOptions.ZeroAsEmpty => number is 0 ? defaultVal : number.ToString(format),
                _ => number.ToString(format)
            };
        }

        public static string DecimalToString(decimal? number, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? DecimalToString(result, options, defaultVal) : defaultVal;
        }

        public static string DecimalToString(decimal? number, NumericConvOptions options, decimal defaultVal)
        {
            var format = $"0.{"#".Repeat(DEFAULT_DIGITS)}";
            return options switch
            {
                NumericConvOptions.Default => DecimalToString(number.SafeValue(defaultVal), DEFAULT_DIGITS, options, defaultVal.ToString(format)),
                NumericConvOptions.ZeroAsEmpty => DecimalToString(number.SafeValue(), DEFAULT_DIGITS, options, defaultVal.ToString(format)),
                _ => DecimalToString(number.SafeValue(defaultVal), DEFAULT_DIGITS, options, defaultVal.ToString(format))
            };
        }

        public static string DecimalToString(decimal? number, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return number.TrySafeValue(out var result) ? DecimalToString(result,digits,  options, defaultVal) : defaultVal;
        }

        public static string DecimalToString(decimal? number, int digits, NumericConvOptions options, decimal defaultVal)
        {
            if (digits < 0) digits = DEFAULT_DIGITS;
            var format = $"0.{"#".Repeat(digits)}";
            return options switch
            {
                NumericConvOptions.Default => DecimalToString(number.SafeValue(defaultVal), digits, options, defaultVal.ToString(format)),
                NumericConvOptions.ZeroAsEmpty => DecimalToString(number.SafeValue(), digits, options, defaultVal.ToString(format)),
                _ => DecimalToString(number.SafeValue(defaultVal), digits, options, defaultVal.ToString(format))
            };
        }

        public static string GuidToString(Guid guid, CastingContext context, string defaultVal = "")
        {
            return XConvHelper.T(
                () => guid.ToString(context.GuidFormatStyles.X(), context.FormatProvider),
                defaultVal);
        }

        public static string GuidToString(Guid? guid, CastingContext context)
        {
            return XConvHelper.T(
                () => guid.SafeGuid()?.ToString(context.GuidFormatStyles.X(), context.FormatProvider) ?? string.Empty,
                string.Empty);
        }

        public static string GuidToString(Guid? guid, CastingContext context, Guid defaultVal)
        {
            return XConvHelper.T(
                () => guid.SafeGuid()?.ToString(context.GuidFormatStyles.X(), context.FormatProvider) ?? string.Empty,
                GuidToString(defaultVal, context, string.Empty));
        }
    }
}