namespace Cosmos.Numeric;

/// <summary>
/// Number Utilities <br />
/// 数值工具
/// </summary>
public static partial class Numbers
{
    /// <summary>
    /// Converts integer to named tuple (e.g. 'single', 'double' etc.). <br />
    /// 将数值转换为具名元组
    /// </summary>
    /// <param name="input">Integer</param>
    /// <returns>Named tuple</returns>
    public static string Tupleize(int input)
    {
        return input switch
        {
            1 => "single",
            2 => "double",
            3 => "triple",
            4 => "quadruple",
            5 => "quintuple",
            6 => "sextuple",
            7 => "septuple",
            8 => "octuple",
            9 => "nonuple",
            10 => "decuple",
            100 => "centuple",
            1000 => "milluple",
            _ => $"{input}-tuple"
        };
    }
}

/// <summary>
/// Extensions for number utilities <br />
/// 数值工具扩展
/// </summary>
public static partial class NumberExtensions
{
    /// <summary>
    /// Converts integer to named tuple (e.g. 'single', 'double' etc.). <br />
    /// 将数值转换为具名元组
    /// </summary>
    /// <param name="input">Integer</param>
    /// <returns>Named tuple</returns>
    public static string Tupleize(this int input) => Numbers.Tupleize(input);
}