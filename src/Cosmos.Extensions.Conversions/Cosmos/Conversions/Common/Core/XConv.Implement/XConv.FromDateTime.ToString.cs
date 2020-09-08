using System;
using Cosmos.Date;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        private static bool FromDateTimeToString(DateTime dateTime, string givenFormat, CastingContext context, out object result)
        {
            var format = givenFormat;
            if (string.IsNullOrWhiteSpace(format))
                format = context.Format;
            if (string.IsNullOrWhiteSpace(format))
                format = "yyyy-MM-dd HH:mm:ss";

            result = context.DateTimeFormatStyles switch
            {
                DateTimeFormatStyles.Normal    => dateTime.ToString(format, context.FormatProvider),
                DateTimeFormatStyles.Date      => dateTime.ToDateString(),
                DateTimeFormatStyles.Time      => dateTime.ToTimeString(),
                DateTimeFormatStyles.DateTime  => dateTime.ToDateTimeString(),
                DateTimeFormatStyles.LongDate  => dateTime.ToLongDateString(),
                DateTimeFormatStyles.LongTime  => dateTime.ToLongTimeString(),
                DateTimeFormatStyles.ShortDate => dateTime.ToShortDateString(),
                DateTimeFormatStyles.ShortTime => dateTime.ToShortTimeString(),
                DateTimeFormatStyles.Local     => dateTime.ToLocalTime().ToString(format, context.FormatProvider),
                DateTimeFormatStyles.Universal => dateTime.ToUniversalTime().ToString(format, context.FormatProvider),
                _                              => dateTime.ToString(format, context.FormatProvider)
            };

            return true;
        }

        private static bool FromDateTimeToNullableString(DateTime dateTime, CastingContext context, out object result)
        {
            var format = context.Format;
            if (string.IsNullOrWhiteSpace(format))
                format = "yyyy-MM-dd HH:mm:ss";

            result = context.DateTimeFormatStyles switch
            {
                DateTimeFormatStyles.Normal    => dateTime.ToString(format, context.FormatProvider),
                DateTimeFormatStyles.Date      => dateTime.ToDateString(),
                DateTimeFormatStyles.Time      => dateTime.ToTimeString(),
                DateTimeFormatStyles.DateTime  => dateTime.ToDateTimeString(),
                DateTimeFormatStyles.LongDate  => dateTime.ToLongDateString(),
                DateTimeFormatStyles.LongTime  => dateTime.ToLongTimeString(),
                DateTimeFormatStyles.ShortDate => dateTime.ToShortDateString(),
                DateTimeFormatStyles.ShortTime => dateTime.ToShortTimeString(),
                DateTimeFormatStyles.Local     => dateTime.ToLocalTime().ToString(format, context.FormatProvider),
                DateTimeFormatStyles.Universal => dateTime.ToUniversalTime().ToString(format, context.FormatProvider),
                _                              => dateTime.ToString(format, context.FormatProvider)
            };

            return true;
        }
    }
}