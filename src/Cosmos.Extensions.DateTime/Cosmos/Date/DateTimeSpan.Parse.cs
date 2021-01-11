using System;
using System.Globalization;

namespace Cosmos.Date
{
    /// <summary>
    /// DateTime span
    /// </summary>
    public partial struct DateTimeSpan
    {
        public static bool TryParse(string s, out DateTimeSpan result)
        {
            return DateTimeSpanParse.TryParse(s, null, out result);
        }

        public static bool TryParse(string s, IFormatProvider provider, out DateTimeSpan result)
        {
            return DateTimeSpanParse.TryParse(s, provider, out result);
        }

        public static bool TryParseExact(string input, string format, IFormatProvider provider, out DateTimeSpan result)
        {
            return DateTimeSpanParse.TryParseExact(input, format, provider, TimeSpanStyles.None, out result);
        }

        public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, out DateTimeSpan result)
        {
            return DateTimeSpanParse.TryParseExactMultiple(input, formats, provider, TimeSpanStyles.None, out result);
        }

        public static bool TryParseExact(string input, string format, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        {
            return DateTimeSpanParse.TryParseExact(input, format, provider, styles, out result);
        }

        public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        {
            return DateTimeSpanParse.TryParseExactMultiple(input, formats, provider, styles, out result);
        }
    }

    internal static class DateTimeSpanParse
    {
        public static bool TryParse(string s, IFormatProvider provider, out DateTimeSpan result)
        {
            return TryCreateDateTimeSpan(TimeSpan.TryParse(s, provider, out var timeSpan), timeSpan, out result);
        }

        public static bool TryParseExact(string s, string format, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        {
            return TryCreateDateTimeSpan(TimeSpan.TryParseExact(s, format, provider, styles, out var timeSpan), timeSpan, out result);
        }

        public static bool TryParseExactMultiple(string s, string[] formats, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        {
            return TryCreateDateTimeSpan(TimeSpan.TryParseExact(s, formats, provider, styles, out var timeSpan), timeSpan, out result);
        }

        private static bool TryCreateDateTimeSpan(bool condition, TimeSpan timeSpan, out DateTimeSpan result)
        {
            result = default;
            if (!condition) return false;
            result = new DateTimeSpan {TimeSpan = timeSpan};
            return true;
        }
    }
}