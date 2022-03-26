using System.Diagnostics.Contracts;

namespace Cosmos.Numeric;

/// <summary>
/// Number Utilities <br />
/// 数值工具
/// </summary>
public static partial class Numbers
{
    /// <summary>
    /// Accurate way to convert float to decimal by converting to string first.  Avoids tolerance issues.<br />
    /// 通过先转换为字符串将浮点数转换为小数的准确方法。 避免公差问题。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal ToDecimal(float value)
    {
        return decimal.Parse(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Accurate way to convert float to double by rounding finite values to a decimal point tolerance level.<br />
    /// 通过将有限值四舍五入到小数点公差级别来将 float 转换为 double 的准确方法。
    /// </summary>
    public static double ToDouble(float value, int precision)
    {
        if (precision < 0 || precision > 15)
            throw new ArgumentOutOfRangeException(nameof(precision), precision, "Must be between 0 and 15.");
        Contract.EndContractBlock();

        var result = ReturnZeroIfFinite(value);
        return IsZeroValue(result) ? Math.Round(value, precision) : result;
    }

    /// <summary>
    /// Accurate way to convert float to double by converting to string first.  Avoids tolerance issues.<br />
    /// 通过首先转换为字符串将 float 转换为 double 的准确方法。 避免公差问题。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDouble(float value)
    {
        var result = ReturnZeroIfFinite(value);
        return IsZeroValue(result) ? double.Parse(value.ToString(CultureInfo.InvariantCulture)) : result;
    }

    /// <summary>
    /// Accurate way to convert possible float to double by converting to string first.  Avoids tolerance issues.<br />
    /// 通过首先转换为字符串来将可能的 float 转换为 double 的准确方法。 避免公差问题。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDouble(float? value)
    {
        return value.HasValue ? ToDouble(value.Value) : double.NaN;
    }

    /// <summary>
    /// Accurate way to convert a possible float to double by rounding finite values to a decimal point tolerance level.<br />
    /// 通过将有限值四舍五入到小数点公差级别，将可能的浮点数转换为双精度值的准确方法。
    /// </summary>
    public static double ToDouble(float? value, int precision)
    {
        if (precision < 0 || precision > 15)
            throw new ArgumentOutOfRangeException(nameof(precision), precision, "Must be between 0 and 15.");
        Contract.EndContractBlock();

        return value.HasValue ? ToDouble(value.Value, precision) : double.NaN;
    }
}

/// <summary>
/// Extensions for number utilities <br />
/// 数值工具扩展
/// </summary>
public static partial class NumberExtensions
{
    /// <summary>
    /// Accurate way to convert float to decimal by converting to string first.  Avoids tolerance issues.<br />
    /// 通过先转换为字符串将浮点数转换为小数的准确方法。 避免公差问题。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal ToDecimal(this float value) => Numbers.ToDecimal(value);

    /// <summary>
    /// Accurate way to convert float to double by rounding finite values to a decimal point tolerance level.<br />
    /// 通过将有限值四舍五入到小数点公差级别来将 float 转换为 double 的准确方法。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDouble(this float value, int precision) => Numbers.ToDouble(value, precision);

    /// <summary>
    /// Accurate way to convert float to double by converting to string first.  Avoids tolerance issues.<br />
    /// 通过首先转换为字符串将 float 转换为 double 的准确方法。 避免公差问题。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDouble(this float value) => Numbers.ToDouble(value);

    /// <summary>
    /// Accurate way to convert possible float to double by converting to string first.  Avoids tolerance issues.<br />
    /// 通过首先转换为字符串来将可能的 float 转换为 double 的准确方法。 避免公差问题。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDouble(this float? value) => Numbers.ToDouble(value);

    /// <summary>
    /// Accurate way to convert a possible float to double by rounding finite values to a decimal point tolerance level.<br />
    /// 通过将有限值四舍五入到小数点公差级别，将可能的浮点数转换为双精度值的准确方法。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDouble(this float? value, int precision) => Numbers.ToDouble(value, precision);
}