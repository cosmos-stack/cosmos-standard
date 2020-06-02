using System;
using System.Diagnostics.Contracts;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace Cosmos.Numeric
{
    /// <summary>
    /// Extensions for numeric
    /// </summary>
    public static partial class NumericExtensions
    {
        /// <summary>
        /// Shortcut for validating a if a floating point value is considered zero (within epsilon tolerance).
        /// </summary>
        public static bool IsZero(this float value)
        {
            return IsPreciseEqual(value, 0f);
        }

        /// <summary>
        /// Shortcut for validating a if a double tolerance floating point value is considered zero (within epsilon tolerance).
        /// </summary>
        public static bool IsZero(this double value)
        {
            return IsPreciseEqual(value, 0d);
        }

        /// <summary>
        /// Shortcut for validating a if a double tolerance floating point value is considered zero (within provided tolerance).
        /// </summary>
        public static bool IsNearZero(this double value, double precision = 0.001)
        {
            return IsNearEqual(value, 0d, precision);
        }

        /// <summary>
        /// Shortcut for validating a if a floating point value is close enough to another addValue using the given tolerance tolerance.
        /// </summary>
        public static bool IsNearEqual(this float a, float b, float tolerance)
        {
            return a.Equals(b) || float.IsNaN(a) && float.IsNaN(b) || Math.Abs(a - b) < tolerance;
        }

        /// <summary>
        /// Shortcut for validating a if a double precision floating point value is close enough to another addValue using the given tolerance tolerance.
        /// </summary>
        public static bool IsNearEqual(this double a, double b, double tolerance)
        {
            return a.Equals(b) || double.IsNaN(a) && double.IsNaN(b) || Math.Abs(a - b) < tolerance;
        }

        /// <summary>
        /// Shortcut for validating a if a decimal addValue is close enough to another addValue using the given tolerance tolerance.
        /// </summary>
        public static bool IsNearEqual(this decimal a, decimal b, decimal tolerance)
        {
            return a.Equals(b) || Math.Abs(a - b) < tolerance;
        }

        /// <summary>
        /// Shortcut for validating a if a decimal addValue is close enough to another addValue using the given tolerance tolerance.
        /// </summary>
        public static bool IsRelativeNearEqual(this double a, double b, uint minDecimalPlaces)
        {
            var tolerance = 1 / Math.Pow(10, minDecimalPlaces);
            if (a.IsNearEqual(b, tolerance)) return true;
            if (double.IsNaN(a) || double.IsNaN(b)) return false;
            var d = Math.Min(a.DecimalPlaces(), b.DecimalPlaces());
            var divisor = Math.Pow(10, minDecimalPlaces - d);
            a /= divisor;
            b /= divisor;
            return a.IsNearEqual(b, tolerance);
        }

        /// <summary>
        /// Validates if values are equal within epsilon tolerance.
        /// </summary>
        public static bool IsPreciseEqual(this double a, double b, bool stringValidate = false)
        {
            return IsNearEqual(a, b, double.Epsilon)
                || (stringValidate && !double.IsNaN(a) && !double.IsNaN(b) && a.ToString(CultureInfo.InvariantCulture) == b.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Validates if values are equal within epsilon tolerance.
        /// </summary>
        public static bool IsPreciseEqual(this float a, float b, bool stringValidate = false)
        {
            return IsNearEqual(a, b, float.Epsilon) ||
                   (stringValidate && !float.IsNaN(a) && !float.IsNaN(b) && a.ToString(CultureInfo.InvariantCulture) == b.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Validates if values are equal within epsilon tolerance.
        /// </summary>
        public static bool IsPreciseEqual(this double? a, double? b, bool stringValidate = false)
        {
            return !a.HasValue && !b.HasValue || a.HasValue && b.HasValue && a.Value.IsPreciseEqual(b.Value, stringValidate);
        }

        /// <summary>
        /// Validates if values are equal within epsilon tolerance.
        /// </summary>
        public static bool IsPreciseEqual(this float? a, float? b, bool stringValidate = false)
        {
            return !a.HasValue && !b.HasValue || a.HasValue && b.HasValue && a.Value.IsPreciseEqual(b.Value, stringValidate);
        }

        /// <summary>
        /// Shortcut for validating a if a potential floating pointvalue is close enough to another addValue using the given tolerance tolerance.
        /// </summary>
        public static bool IsNearEqual(this IComparable a, IComparable b, IComparable tolerance)
        {
            if (a == null)
                throw new NullReferenceException();
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            Contract.EndContractBlock();

            if (a.Equals(b))
                return true;

            return a switch
            {
                float f          => IsNearEqual(f, (float) b, (float) tolerance),
                double d         => IsNearEqual(d, (double) b, (double) tolerance),
                decimal @decimal => IsNearEqual(@decimal, (decimal) b, (decimal) tolerance),
                _                => throw new InvalidCastException(),
            };
        }
    }
}