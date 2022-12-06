namespace Cosmos.Numeric;

/// <summary>
/// Numerical speculative options <br />
/// 数值可推测性选项
/// </summary>
public enum NumericMayOptions
{
    Default = 0,
    IgnoreNullable = 1
}

/// <summary>
/// Number Utilities <br />
/// 数值工具
/// </summary>
public static partial class Numbers
{
    #region GetMembersBetween

    /// <summary>
    /// Get members between min value and max value (include min and max). <br />
    /// 获取最小值和最大值之间的成员（包括最小值和最大值）。
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int[] GetRangeBetween(int min, int max)
    {
        if (min == max)
        {
            return new[] { min };
        }

        if (min > max)
        {
            (min, max) = (max, min);
        }

        var count = max - min + 1;
        var results = new int[count];
        var pointer = min;
        var index = 0;

        while (pointer <= max && index < count)
        {
            results[index] = pointer;

            ++index;
            ++pointer;
        }

        return results;
    }

    /// <summary>
    /// Get members between min value and max value (include min and max). <br />
    /// 获取最小值和最大值之间的成员（包括最小值和最大值）。
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static long[] GetRangeBetween(long min, long max)
    {
        if (min == max)
        {
            return new[] { min };
        }

        if (min > max)
        {
            (min, max) = (max, min);
        }

        var count = max - min + 1;
        var results = new long[count];
        var pointer = min;
        var index = 0L;

        while (pointer <= max && index < count)
        {
            results[index] = pointer;

            ++index;
            ++pointer;
        }

        return results;
    }

    #endregion

    #region Fix Zero

    /// <summary>
    /// Shortcut for returning true zero if a double tolerance floating point value is considered zero (within epsilon tolerance).<br />
    /// 如果将双公差浮点值视为零（在ε公差内），则返回真零的快捷方式。
    /// </summary>
    public static double FixZero(double value)
    {
        return !value.Equals(0) && IsZeroValue(value) ? 0 : value;
    }

    private static double ReturnZeroIfFinite(float value)
    {
        if (float.IsNegativeInfinity(value))
            return double.NegativeInfinity;
        if (float.IsPositiveInfinity(value))
            return double.PositiveInfinity;

        return float.IsNaN(value) ? double.NaN : 0D;
    }

    #endregion

    #region GetDecimalPlaces

    /// <summary>
    /// Returns the number of decimal places before last zero digit.<br />
    /// 返回最后零位之前的小数位数。
    /// </summary>
    public static int GetDecimalPlaces(double source)
    {
        if (IsNaN(source))
            return 0;

        var valueString = source.ToString(CultureInfo.InvariantCulture); // To
        var index = valueString.IndexOf('.');
        return index == -1 ? 0 : valueString.Length - index - 1;
    }

    #endregion

    #region GetSumAccurate

    /// <summary>
    /// Ensures addition tolerance by trimming off unexpected imprecision.<br />
    /// 通过消除意外的不准确性来确保附加公差。
    /// </summary>
    public static double GetSumAccurate(double source, double value)
    {
        var result = source + value;
        var vp = GetDecimalPlaces(source);
        if (vp > 15)
            return result;
        var ap = GetDecimalPlaces(value);
        if (ap > 15)
            return result;

        var digits = Math.Max(vp, ap);

        return Math.Round(result, digits);
    }

    #endregion

    #region GetProductAccurate

    /// <summary>
    /// Ensures addition tolerance by trimming off unexpected imprecision.<br />
    /// 通过消除意外的不准确性来确保附加公差。
    /// </summary>
    public static double GetProductAccurate(double source, double value)
    {
        var result = source * value;
        var vp = GetDecimalPlaces(source);
        if (vp > 15)
            return result;
        var ap = GetDecimalPlaces(value);
        if (ap > 15)
            return result;

        var digits = Math.Max(vp, ap);

        return Math.Round(result, digits);
    }

    #endregion

    #region GetSumUsingIntegers

    /// <summary>
    /// Ensures addition tolerance by using integer math.<br />
    /// 通过使用整数数学来确保加法公差。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double GetSumUsingIntegers(double source, double value)
    {
        var x = Math.Pow(10, Math.Max(GetDecimalPlaces(source), GetDecimalPlaces(value)));

        var v = (long)(source * x);
        var a = (long)(value * x);
        var result = v + a;
        return result / x;
    }

    #endregion
}

/// <summary>
/// Extensions for number utilities <br />
/// 数值工具扩展
/// </summary>
public static partial class NumberExtensions
{
    /// <summary>
    /// Shortcut for returning true zero if a double tolerance floating point value is considered zero (within epsilon tolerance).<br />
    /// 如果将双公差浮点值视为零（在ε公差内），则返回真零的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double FixZero(this double x) => Numbers.FixZero(x);

    /// <summary>
    /// Returns the number of decimal places before last zero digit.<br />
    /// 返回最后零位之前的小数位数。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DecimalPlaces(this double x) => Numbers.GetDecimalPlaces(x);

    /// <summary>
    /// Ensures addition tolerance by trimming off unexpected imprecision.<br />
    /// 通过消除意外的不准确性来确保附加公差。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SumAccurate(this double x, double value) => Numbers.GetSumAccurate(x, value);

    /// <summary>
    /// Ensures addition tolerance by trimming off unexpected imprecision.<br />
    /// 通过消除意外的不准确性来确保附加公差。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ProductAccurate(this double x, double value) => Numbers.GetProductAccurate(x, value);

    /// <summary>
    /// Ensures addition tolerance by using integer math.<br />
    /// 通过使用整数数学来确保加法公差。
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SumUsingIntegers(this double x, double value) => Numbers.GetSumUsingIntegers(x, value);
}