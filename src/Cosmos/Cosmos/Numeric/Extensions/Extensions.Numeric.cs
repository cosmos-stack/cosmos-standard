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
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(this double value) => double.IsNaN(value);

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(this float value) => float.IsNaN(value);

        /// <summary>
        /// Is default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefault(this double value)
        {
            return value.Equals(default);
        }

        /// <summary>
        /// Accurate way to convert float to decimal by converting to string first.  Avoids tolerance issues.<br />
        /// 通过先转换为字符串将浮点数转换为小数的准确方法。 避免公差问题。
        /// </summary>
        public static decimal ToDecimal(this float value)
        {
            return decimal.Parse(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Accurate way to convert float to double by rounding finite values to a decimal point tolerance level.<br />
        /// 通过将有限值四舍五入到小数点公差级别来将 float 转换为 double 的准确方法。
        /// </summary>
        public static double ToDouble(this float value, int precision)
        {
            if (precision < 0 || precision > 15)
                throw new ArgumentOutOfRangeException(nameof(precision), precision, "Must be between 0 and 15.");
            Contract.EndContractBlock();

            var result = value.ReturnZeroIfFinite();
            return result.IsZero() ? Math.Round(value, precision) : result;
        }

        /// <summary>
        /// Accurate way to convert float to double by converting to string first.  Avoids tolerance issues.<br />
        /// 通过首先转换为字符串将 float 转换为 double 的准确方法。 避免公差问题。
        /// </summary>
        public static double ToDouble(this float value)
        {
            var result = value.ReturnZeroIfFinite();
            return result.IsZero() ? double.Parse(value.ToString(CultureInfo.InvariantCulture)) : result;
        }

        /// <summary>
        /// Accurate way to convert possible float to double by converting to string first.  Avoids tolerance issues.<br />
        /// 通过首先转换为字符串来将可能的 float 转换为 double 的准确方法。 避免公差问题。
        /// </summary>
        public static double ToDouble(this float? value)
        {
            return value?.ToDouble() ?? double.NaN;
        }

        /// <summary>
        /// Accurate way to convert a possible float to double by rounding finite values to a decimal point tolerance level.<br />
        /// 通过将有限值四舍五入到小数点公差级别，将可能的浮点数转换为双精度值的准确方法。
        /// </summary>
        public static double ToDouble(this float? value, int precision)
        {
            if (precision < 0 || precision > 15)
                throw new ArgumentOutOfRangeException(nameof(precision), precision, "Must be between 0 and 15.");
            Contract.EndContractBlock();

            return value?.ToDouble(precision) ?? double.NaN;
        }

        /// <summary>
        /// Shortcut for returning true zero if a double tolerance floating point value is considered zero (within epsilon tolerance).<br />
        /// 如果将双公差浮点值视为零（在ε公差内），则返回真零的快捷方式。
        /// </summary>
        public static double FixZero(this double value)
        {
            return !value.Equals(0) && value.IsZero() ? 0 : value;
        }

        static double ReturnZeroIfFinite(this float value)
        {
            if (float.IsNegativeInfinity(value))
                return double.NegativeInfinity;
            if (float.IsPositiveInfinity(value))
                return double.PositiveInfinity;

            return float.IsNaN(value) ? double.NaN : 0D;
        }

        /// <summary>
        /// Returns the number of decimal places before last zero digit.<br />
        /// 返回最后零位之前的小数位数。
        /// </summary>
        public static int DecimalPlaces(this double source)
        {
            if (source.IsNaN())
                return 0;

            var valueString = source.ToString(CultureInfo.InvariantCulture); // To
            var index = valueString.IndexOf('.');
            return index == -1 ? 0 : valueString.Length - index - 1;
        }

        /// <summary>
        /// Ensures addition tolerance by trimming off unexpected imprecision.<br />
        /// 通过消除意外的不准确性来确保附加公差。
        /// </summary>
        public static double SumAccurate(this double source, double value)
        {
            var result = source + value;
            var vp = source.DecimalPlaces();
            if (vp > 15)
                return result;
            var ap = value.DecimalPlaces();
            if (ap > 15)
                return result;

            var digits = Math.Max(vp, ap);

            return Math.Round(result, digits);
        }

        /// <summary>
        /// Ensures addition tolerance by trimming off unexpected imprecision.<br />
        /// 通过消除意外的不准确性来确保附加公差。
        /// </summary>
        public static double ProductAccurate(this double source, double value)
        {
            var result = source * value;
            var vp = source.DecimalPlaces();
            if (vp > 15)
                return result;
            var ap = value.DecimalPlaces();
            if (ap > 15)
                return result;

            var digits = Math.Max(vp, ap);

            return Math.Round(result, digits);
        }

        /// <summary>
        /// Ensures addition tolerance by using integer math.<br />
        /// 通过使用整数数学来确保加法公差。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double SumUsingIntegers(this double source, double value)
        {
            var x = Math.Pow(10, Math.Max(source.DecimalPlaces(), value.DecimalPlaces()));

            var v = (long) (source * x);
            var a = (long) (value * x);
            var result = v + a;
            return result / x;
        }
    }
}