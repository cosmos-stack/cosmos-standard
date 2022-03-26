namespace Cosmos.Conversions.Common.Core;

internal static class SafeConvX
{
    public static IFormatProvider SafeNumber(this IFormatProvider formatProvider) => formatProvider ?? NumberFormatInfo.CurrentInfo;
    public static IFormatProvider SafeDateTime(this IFormatProvider formatProvider) => formatProvider ?? DateTimeFormatInfo.CurrentInfo;
}