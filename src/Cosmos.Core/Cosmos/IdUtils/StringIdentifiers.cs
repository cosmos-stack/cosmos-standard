using System.Text;
using Cosmos.Text;

namespace Cosmos.IdUtils;

/// <summary>
/// Identifier tool in string format <br />
/// 字符串格式的标识符工具
/// </summary>
public static class StringIdentifiers
{
    /// <summary>
    /// To valid identifier <br />
    /// 转换为合法的标识符
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public static string ToValidIdentifier(string original)
    {
        original = original.ToCapitalCase();

        if (original.Length == 0)
            return "_";

        var res = new StringBuilder(original.Length + 1);
        if (!char.IsLetter(original[0]) && original[0] != '_')
            res.Append('_');

        for (var i = 0; i < original.Length; i++)
        {
            var c = original[i];
            if (char.IsLetterOrDigit(c) || c == '_')
                res.Append(c);
            else
                res.Append('_');
        }

        return res.ToString().ReplaceRecursive("__", "_").Trim('_');
    }
}