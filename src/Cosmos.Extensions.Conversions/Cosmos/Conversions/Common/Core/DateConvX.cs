using Cosmos.Conversions.Determiners;

namespace Cosmos.Conversions.Common.Core;

internal static class DtConvX
{
    public static DateTime ObjectToDateTime(object obj, DateTime defaultVal = default)
    {
        return obj switch
        {
            null => defaultVal,
            string str => StringToDateTime(str, defaultVal),
            DateTime d => d,
            _ => XConvHelper.D(obj.ToString(), StringDateTimeDeterminer.IS, defaultVal, StringToDateTime, out var val)
                ? val
                : XConvHelper.T(
                    () => Unsafe.As<object, DateTime>(ref obj),
                    () => Convert.ToDateTime(obj),
                    defaultVal)
        };
    }

    public static DateTime StringToDateTime(string str, DateTime defaultVal = default)
    {
        return StringToNullableDateTime(str) ?? defaultVal;
    }

    public static DateTime? ObjectToNullableDateTime(object obj)
    {
        return obj switch
        {
            null => null,
            string str => StringToNullableDateTime(str),
            DateTime d => d,
            _ => StringToNullableDateTime(obj.ToString())
        };
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
        return obj switch
        {
            null => defaultVal,
            string str => StringToDateTimeOffset(str, defaultVal),
            DateTimeOffset d => d,
            _ => XConvHelper.D(obj.ToString(), StringDateTimeOffsetDeterminer.IS, defaultVal, StringToDateTimeOffset, out var val)
                ? val
                : DateTimeOffset.TryParse(obj.ToString(), out var dateTimeOffset)
                    ? dateTimeOffset
                    : defaultVal
        };
    }

    public static DateTimeOffset StringToDateTimeOffset(string str, DateTimeOffset defaultVal = default)
    {
        return StringToNullableDateTimeOffset(str) ?? defaultVal;
    }

    public static DateTimeOffset? ObjectToNullableDateTimeOffset(object obj)
    {
        return obj switch
        {
            null => null,
            string str => StringToNullableDateTimeOffset(str),
            DateTimeOffset d => d,
            _ => StringToNullableDateTimeOffset(obj.ToString())
        };
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
        return obj switch
        {
            null => defaultVal,
            string str => StringToTimeSpan(str, defaultVal),
            TimeSpan t => t,
            _ => XConvHelper.D(obj.ToString(), StringTimeSpanDeterminer.IS, defaultVal, StringToTimeSpan, out var val)
                ? val
                : TimeSpan.TryParse(obj.ToString(), out var timeSpan)
                    ? timeSpan
                    : defaultVal
        };
    }

    public static TimeSpan StringToTimeSpan(string str, TimeSpan defaultVal = default)
    {
        return StringToNullableTimeSpan(str) ?? defaultVal;
    }

    public static TimeSpan? ObjectToNullableTimeSpan(object obj)
    {
        return obj switch
        {
            null => null,
            string str => StringToNullableTimeSpan(str),
            TimeSpan t => t,
            _ => StringToNullableTimeSpan(obj.ToString())
        };
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