namespace Cosmos.Numeric
{
    /// <summary>
    /// Number Utilities
    /// </summary>
    public static partial class Numbers
    {
        #region IsNaN

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(double value) => double.IsNaN(value);

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(float value) => float.IsNaN(value);

        #endregion

        #region IsDefault

        /// <summary>
        /// Is default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefaultValue(double value) => value.Equals(default);

        #endregion
    }

    /// <summary>
    /// Extensions for number utilities
    /// </summary>
    public static partial class NumberExtensions
    {
        /// <summary>
        /// Is default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefault(this double value) => Numbers.IsDefaultValue(value);
    }
}