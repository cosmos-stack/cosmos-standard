namespace System
{
    /// <summary>
    /// Base Type Extensions
    /// </summary>
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// Gets max one.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static byte Max(this byte val1, byte val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Gets min one.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static byte Min(this byte val1, byte val2)
        {
            return Math.Min(val1, val2);
        }
    }
}