using System;

namespace Cosmos
{
    /// <summary>
    /// Default value for type
    /// </summary>
    public static class TypeDefault
    {
        /// <summary>
        /// Gets default value for type TValue.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue Of<TValue>() => default;

        /// <summary>
        /// Gets default value for type TValue.
        /// </summary>
        /// <returns></returns>
        public static object Of(Type type) => default;

        /// <summary>
        /// Gets default value for int;
        /// </summary>
        public static int Int => default;

        /// <summary>
        /// Gets default value for long;
        /// </summary>
        public static long Long => default;

        /// <summary>
        /// Gets default value for float;
        /// </summary>
        public static float Float => default;

        /// <summary>
        /// Gets default value for double;
        /// </summary>
        public static double Double => default;

        /// <summary>
        /// Gets default value for decimal;
        /// </summary>
        public static decimal Decimal => default;

        /// <summary>
        /// Gets default value for char;
        /// </summary>
        public static char Char => default;

        /// <summary>
        /// Gets default value for string;
        /// </summary>
        public static string String => default;

        /// <summary>
        /// Gets empty value for string;
        /// </summary>
        public static string StringEmpty => string.Empty;

        /// <summary>
        /// Gets default value for DateTime;
        /// </summary>
        public static DateTime DateTime => default;

        /// <summary>
        /// Gets default value for TimeSpan;
        /// </summary>
        public static TimeSpan TimeSpan => default;
    }
}