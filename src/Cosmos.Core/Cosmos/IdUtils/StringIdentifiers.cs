using System.Text;
using Cosmos.Text;

namespace Cosmos.IdUtils;

internal static class StringIdentifierHelper
{
    /// <summary>
    /// To capital case <br />
    /// 将所有单词转换为首字符大写的词
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToCapitalCase(string text)
    {
        var result = new List<string>();
        foreach (var word in text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
        {
            if (word.Length == 0 || word.ToCharArray().All(char.IsUpper))
                result.Add(word);
            else if (word.Length == 1)
                result.Add(word.ToUpper());
            else
                result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
        }

        return string.Join(" ", result)
                     .Replace(" Y ", " y ")
                     .Replace(" De ", " de ")
                     .Replace(" O ", " o ");
    }
}

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
        original = StringIdentifierHelper.ToCapitalCase(original);

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