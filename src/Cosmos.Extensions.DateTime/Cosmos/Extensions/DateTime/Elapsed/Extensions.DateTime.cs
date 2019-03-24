using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateTimeExtensions
    {
        public static TimeSpan ElapsedTime(this DateTime dt) => DateTime.Now - dt;

        public static int ElapsedMilliseconds(this DateTime dt) => (int)(DateTime.Now - dt).TotalMilliseconds;
    }
}
