using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateTimeExtensions
    {
        public static DateTime Clone(this DateTime dt)
        {
            return new DateTime(dt.Ticks, dt.Kind);
        }
    }
}
