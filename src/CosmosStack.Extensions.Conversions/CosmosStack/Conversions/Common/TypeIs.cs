using System;
using System.Globalization;
using System.Net;
using CosmosStack.Conversions.Determiners;
using CosmosStack.Text;
using CosmosStack.Reflection;

namespace CosmosStack.Conversions.Common
{
    internal static class TypeIs
    {
        #region Constants

        // ReSharper disable once InconsistentNaming
        private const NumberStyles INT_NUMBER_STYLE = NumberStyles.Integer;

        // ReSharper disable once InconsistentNaming
        private const NumberStyles DEM_NUMBER_STYLE = NumberStyles.Number;

        // ReSharper disable once InconsistentNaming
        private const NumberStyles FLT_NUMBER_STYLE = NumberStyles.AllowLeadingWhite
                                                      | NumberStyles.AllowTrailingWhite
                                                      | NumberStyles.AllowLeadingSign
                                                      | NumberStyles.AllowDecimalPoint
                                                      | NumberStyles.AllowThousands
                                                      | NumberStyles.AllowExponent;

        #endregion

        public static bool __enumIs(string s, Type type, Action<object> action, IgnoreCase ignoreCase) =>
            type.IsEnum && StringEnumDeterminer.Is(s, type, ignoreCase.X(), action);

        public static bool __charIs(string s, Type type, Action<object> action) =>
            type == TypeClass.CharClazz && StringCharDeterminer.Is(s, ValueConverter.ConvertAct<char>(action));

        public static bool __numericIs(string s, Type type, Action<object> action, NumberStyles? numberStyle, IFormatProvider provider) =>
            type == TypeClass.ByteClazz && StringByteDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<byte>(action))
         || type == TypeClass.SByteClazz && StringSByteDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<sbyte>(action))
         || type == TypeClass.Int16Clazz && StringShortDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<short>(action))
         || type == TypeClass.UInt16Clazz && StringUShortDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<ushort>(action))
         || type == TypeClass.Int32Clazz && StringIntDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<int>(action))
         || type == TypeClass.UInt32Clazz && StringUIntDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<uint>(action))
         || type == TypeClass.Int64Clazz && StringLongDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<long>(action))
         || type == TypeClass.UInt64Clazz && StringULongDeterminer.Is(s, numberStyle ?? INT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<ulong>(action))
         || type == TypeClass.FloatClazz && StringFloatDeterminer.Is(s, numberStyle ?? FLT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<float>(action))
         || type == TypeClass.DoubleClazz && StringDoubleDeterminer.Is(s, numberStyle ?? FLT_NUMBER_STYLE, provider, ValueConverter.ConvertAct<double>(action))
         || type == TypeClass.DecimalClazz && StringDecimalDeterminer.Is(s, numberStyle ?? DEM_NUMBER_STYLE, provider, ValueConverter.ConvertAct<decimal>(action));

        public static bool __booleanIs(string s, Type type, Action<object> action) =>
            type == TypeClass.BooleanClazz && StringBooleanDeterminer.Is(s, ValueConverter.ConvertAct<bool>(action));

        public static bool __dateTimeIs(string s, Type type, Action<object> action, string format, DateTimeStyles? dateTimeStyle, IFormatProvider provider) =>
            type == TypeClass.DateTimeClazz && (format is null
                ? StringDateTimeDeterminer.Is(s, dateTimeStyle ?? DateTimeStyles.None, provider, ValueConverter.ConvertAct<DateTime>(action))
                : StringDateTimeDeterminer.Exact.Is(s, format, dateTimeStyle ?? DateTimeStyles.None, provider, ValueConverter.ConvertAct<DateTime>(action)));

        public static bool __dateTimeOffsetIs(string s, Type type, Action<object> action, string format, DateTimeStyles? dateTimeStyle, IFormatProvider provider) =>
            type == TypeClass.DateTimeOffsetClazz && (format is null
                ? StringDateTimeOffsetDeterminer.Is(s, dateTimeStyle ?? DateTimeStyles.None, provider, ValueConverter.ConvertAct<DateTimeOffset>(action))
                : StringDateTimeOffsetDeterminer.Exact.Is(s, format, dateTimeStyle ?? DateTimeStyles.None, provider, ValueConverter.ConvertAct<DateTimeOffset>(action)));

        public static bool __timeSpanIs(string s, Type type, Action<object> action, string format, IFormatProvider provider) =>
            type == TypeClass.TimeSpanClazz && format is null
                ? StringTimeSpanDeterminer.Is(s, provider, ValueConverter.ConvertAct<TimeSpan>(action))
                : StringTimeSpanDeterminer.Exact.Is(s, format, provider, ValueConverter.ConvertAct<TimeSpan>(action));

        public static bool __guidIs(string s, Type type, Action<object> action, string format) =>
            type == TypeClass.GuidClazz && format is null
                ? StringGuidDeterminer.Is(s, ValueConverter.ConvertAct<Guid>(action))
                : StringGuidDeterminer.Exact.Is(s, format, ValueConverter.ConvertAct<Guid>(action));

        public static bool __versionIs(string s, Type type, Action<object> action) =>
            type == typeof(Version) && StringVersionDeterminer.Is(s, action);

        public static bool __ipAddressIs(string s, Type type, Action<object> action) =>
            type == typeof(IPAddress) && StringIpAddressDeterminer.Is(s, action);

        public static bool __encodingIs(string s, Action<object> action, bool typeIsAssignableFromEncoding) =>
            typeIsAssignableFromEncoding && StringEncodingDeterminer.Is(s, action);
    }
}