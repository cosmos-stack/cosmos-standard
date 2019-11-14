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
        /// End of month
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate EndOfMonth(this LocalDate ld) => DateAdjusters.EndOfMonth(ld);
    }
}