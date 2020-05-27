using System;
using Cosmos.Conversions.Determiners;

namespace Cosmos.Conversions.Core
{
    internal static class DateTimeConv
    {
        public static DateTime ObjectToDateTime(object obj, DateTime defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is string str)
                return StringToDateTime(str, defaultVal);
            str = obj.ToString();
            if (StringDateTimeDeterminer.Is(str))
                return StringToDateTime(str, defaultVal);
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static DateTime StringToDateTime(string str, DateTime defaultVal = default)
        {
            return StringToNullableDateTime(str) ?? defaultVal;
        }

        public static DateTime? ObjectToNullableDateTime(object obj)
        {
            if (obj is null)
                return null;
            if (obj is string str)
                return StringToNullableDateTime(str);
            return StringToNullableDateTime(obj.ToString());
        }

        public static DateTime? StringToNullableDateTime(string str)
        {
            if (StringDateTimeDeterminer.Is(str))
                return StringDateTimeDeterminer.To(str);
            if (DateTime.TryParse(str, out var dateTime))
                return dateTime;
            return null;
        }

        public static DateTimeOffset ObjectToDateTimeOffset(object obj, DateTimeOffset defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is string str)
                return StringToDateTimeOffset(str, defaultVal);
            str = obj.ToString();
            if (StringDateTimeOffsetDeterminer.Is(str))
                return StringToDateTimeOffset(str, defaultVal);
            return DateTimeOffset.TryParse(str, out var dateTimeOffset) ? dateTimeOffset : defaultVal;
        }

        public static DateTimeOffset StringToDateTimeOffset(string str, DateTimeOffset defaultVal = default)
        {
            return StringToNullableDateTimeOffset(str) ?? defaultVal;
        }

        public static DateTimeOffset? ObjectToNullableDateTimeOffset(object obj)
        {
            if (obj is null)
                return null;
            if (obj is string str)
                return StringToNullableDateTimeOffset(str);
            return StringToNullableDateTimeOffset(obj.ToString());
        }

        public static DateTimeOffset? StringToNullableDateTimeOffset(string str)
        {
            if (StringDateTimeOffsetDeterminer.Is(str))
                return StringDateTimeOffsetDeterminer.To(str);
            if (DateTimeOffset.TryParse(str, out var dateTimeOffset))
                return dateTimeOffset;
            return null;
        }

        public static TimeSpan ObjectToTimeSpan(object obj, TimeSpan defaultVal = default)
        {
            if (obj is null)
                return defaultVal;
            if (obj is string str)
                return StringToTimeSpan(str, defaultVal);
            str = obj.ToString();
            if (StringTimeSpanDeterminer.Is(str))
                return StringToTimeSpan(str, defaultVal);
            return TimeSpan.TryParse(str, out var timeSpan) ? timeSpan : defaultVal;
        }

        public static TimeSpan StringToTimeSpan(string str, TimeSpan defaultVal = default)
        {
            return StringToNullableTimeSpan(str) ?? defaultVal;
        }

        public static TimeSpan? ObjectToNullableTimeSpan(object obj)
        {
            if (obj is null)
                return null;
            if (obj is string str)
                return StringToNullableTimeSpan(str);
            return StringToNullableTimeSpan(obj.ToString());
        }

        public static TimeSpan? StringToNullableTimeSpan(string str)
        {
            if (StringTimeSpanDeterminer.Is(str))
                return StringTimeSpanDeterminer.To(str);
            if (TimeSpan.TryParse(str, out var dateTimeOffset))
                return dateTimeOffset;
            return null;
        }
    }
}