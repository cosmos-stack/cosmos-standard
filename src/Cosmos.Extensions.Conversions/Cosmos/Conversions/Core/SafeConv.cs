using System;
using System.Globalization;

namespace Cosmos.Conversions.Core
{
    internal static class SafeConv
    {
        public static IFormatProvider SafeNumber(this IFormatProvider formatProvider) => formatProvider ?? NumberFormatInfo.CurrentInfo;
        public static IFormatProvider SafeDateTime(this IFormatProvider formatProvider) => formatProvider ?? DateTimeFormatInfo.CurrentInfo;
    }
}