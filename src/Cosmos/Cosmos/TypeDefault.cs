using System;

namespace Cosmos
{
    public static class TypeDefault
    {
        public static TValue Of<TValue>() => default;

        public static int Int => default;

        public static long Long => default;

        public static float Float => default;

        public static double Double => default;

        public static decimal Decimal => default;

        public static char Char => default;

        public static string String => default;

        public static string StringEmpty => string.Empty;

        public static DateTime DateTime => default;

        public static TimeSpan TimeSpan => default;
    }
}