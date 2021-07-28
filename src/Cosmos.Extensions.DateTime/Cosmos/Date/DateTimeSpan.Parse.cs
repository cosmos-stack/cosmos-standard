using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cosmos.Conversions.StringDeterminers;

namespace Cosmos.Date
{
    /// <summary>
    /// DateTime span
    /// </summary>
    public partial struct DateTimeSpan
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse(string s, out DateTimeSpan result) => 
            DateTimeSpanParse.TryParse(s, null, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse(string s, IFormatProvider provider, out DateTimeSpan result) =>
            DateTimeSpanParse.TryParse(s, provider, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParseExact(string input, string format, IFormatProvider provider, out DateTimeSpan result) => 
            DateTimeSpanParse.TryParseExact(input, format, provider, TimeSpanStyles.None, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, out DateTimeSpan result) => 
            DateTimeSpanParse.TryParseExactMultiple(input, formats, provider, TimeSpanStyles.None, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParseExact(string input, string format, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result) =>
            DateTimeSpanParse.TryParseExact(input, format, provider, styles, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result) =>
            DateTimeSpanParse.TryParseExactMultiple(input, formats, provider, styles, out result);

        private static Func<object, bool> StringConvBeHandler
        {
            get
            {
                return obj =>
                {
                    if (obj is string str)
                        return StringDateTimeSpanDeterminer.Is(str);
                    return false;
                };
            }
        }

        private static Func<object, object> StringConvToHandler
        {
            get
            {
                return obj =>
                {
                    if (obj is string str)
                        return StringDateTimeSpanDeterminer.To(str);
                    return default(DateInfo);
                };
            }
        }
    }

    internal static class DateTimeSpanParse
    {
        public static bool TryParse(string s, IFormatProvider provider, out DateTimeSpan result) =>
            TryCreateDateTimeSpan(TimeSpan.TryParse(s, provider, out var timeSpan), timeSpan, out result);

        public static bool TryParseExact(string s, string format, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result) => 
            TryCreateDateTimeSpan(TimeSpan.TryParseExact(s, format, provider, styles, out var timeSpan), timeSpan, out result);

        public static bool TryParseExactMultiple(string s, string[] formats, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result) =>
            TryCreateDateTimeSpan(TimeSpan.TryParseExact(s, formats, provider, styles, out var timeSpan), timeSpan, out result);

        private static bool TryCreateDateTimeSpan(bool condition, TimeSpan timeSpan, out DateTimeSpan result)
        {
            result = default;
            if (!condition) return false;
            result = new DateTimeSpan {TimeSpan = timeSpan};
            return true;
        }
    }
}