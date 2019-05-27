using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateInfoExtensions
    {
        public static DateInfo Clone(this DateInfo date)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));
            return new DateInfo(date.DateTimeRef);
        }
    }
}
