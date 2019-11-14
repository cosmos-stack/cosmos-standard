using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// LocalDate extensions
    /// </summary>
    public static partial class LocalDateExtensions
    {
        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate BeginningOfMonth(this LocalDate ld) => DateAdjusters.StartOfMonth(ld);
    }
}