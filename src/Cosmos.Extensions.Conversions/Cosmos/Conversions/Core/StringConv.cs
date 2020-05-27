using System;
using Cosmos.Optionals;
using Cosmos.Text;

namespace Cosmos.Conversions.Core
{
    internal static class StringConv
    {
        public static string ObjectSafeToString(object obj, string defaultVal = default)
        {
            return obj?.ToString() ?? defaultVal ?? string.Empty;
        }

        public static string Int16ToString(short number, string defaultVal = "0")
        {
            return number == 0
                ? defaultVal
                : number.ToString();
        }

        public static string Int16ToString(short? number, string defaultVal = "")
        {
            return Int16ToString(number.SafeValue(), defaultVal);
        }

        public static string UInt16ToString(ushort number, string defaultVal = "0")
        {
            return number == 0
                ? defaultVal
                : number.ToString();
        }

        public static string UInt16ToString(ushort? number, string defaultVal = "")
        {
            return UInt16ToString(number.SafeValue(), defaultVal);
        }

        public static string Int32ToString(int number, string defaultVal = "0")
        {
            return number == 0
                ? defaultVal
                : number.ToString();
        }

        public static string Int32ToString(int? number, string defaultVal = "")
        {
            return Int32ToString(number.SafeValue(), defaultVal);
        }

        public static string UInt32ToString(uint number, string defaultVal = "0")
        {
            return number == 0
                ? defaultVal
                : number.ToString();
        }

        public static string UInt32ToString(uint? number, string defaultVal = "")
        {
            return UInt32ToString(number.SafeValue(), defaultVal);
        }

        public static string Int64ToString(long number, string defaultVal = "0")
        {
            return number == 0
                ? defaultVal
                : number.ToString();
        }

        public static string Int64ToString(long? number, string defaultVal = "")
        {
            return Int64ToString(number.SafeValue(), defaultVal);
        }

        public static string UInt64ToString(ulong number, string defaultVal = "0")
        {
            return number == 0
                ? defaultVal
                : number.ToString();
        }

        public static string UInt64ToString(ulong? number, string defaultVal = "")
        {
            return UInt64ToString(number.SafeValue(), defaultVal);
        }

        public static string FloatToString(float number)
        {
            return FloatToString(number, 2);
        }

        public static string FloatToString(float number, int digits)
        {
            if (digits < 0) digits = 2;
            var format = $"0.{"#".Repeat(digits)}";
            return number.ToString(format);
        }

        public static string FloatToString(float? number)
        {
            return FloatToString(number, 2);
        }

        public static string FloatToString(float? number, int digits)
        {
            return FloatToString(number.SafeValue(), digits);
        }

        public static string DoubleToString(double number)
        {
            return DoubleToString(number, 2);
        }

        public static string DoubleToString(double number, int digits)
        {
            if (digits < 0) digits = 2;
            var format = $"0.{"#".Repeat(digits)}";
            return number.ToString(format);
        }

        public static string DoubleToString(double? number)
        {
            return DoubleToString(number, 2);
        }

        public static string DoubleToString(double? number, int digits)
        {
            return DoubleToString(number.SafeValue(), digits);
        }

        public static string DecimalToString(decimal number, string defaultVal = "")
        {
            return DecimalToString(number, 2, defaultVal);
        }

        public static string DecimalToString(decimal number, int digits, string defaultVal = "")
        {
            if (digits < 0) digits = 2;
            var format = $"0.{"#".Repeat(digits)}";
            return number == 0
                ? defaultVal
                : number.ToString(format);
        }

        public static string DecimalToString(decimal? number, string defaultVal = "")
        {
            return DecimalToString(number, 2, defaultVal);
        }

        public static string DecimalToString(decimal? number, int digits, string defaultVal = "")
        {
            return DecimalToString(number.SafeValue(), digits, defaultVal);
        }

        public static string GuidToString(Guid guid, CastingContext context, string defaultVal = "")
        {
            try
            {
                return guid.ToString(context.GuidFormatStyles.X(), context.FormatProvider);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static string GuidToString(Guid? guid, CastingContext context)
        {
            try
            {
                return guid.SafeGuid()?.ToString(context.GuidFormatStyles.X(), context.FormatProvider) ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}