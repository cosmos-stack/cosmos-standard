using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Judgments;
using Cosmos.Text;

namespace System
{
    /// <summary>
    /// Cosmos <see cref="String"/> extensions.
    /// </summary>
    public static class CosmosStringExtensions
    {
        #region Case

        /// <summary>
        /// Is upper
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsUpper(this string text) =>
            text.All(ch => char.IsLetter(ch) && !char.IsLower(ch));

        /// <summary>
        /// Is lower
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsLower(this string text) =>
            text.All(ch => !char.IsLetter(ch) || !char.IsUpper(ch));

        /// <summary>
        /// To capital case
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToCapitalCase(this string original)
        {
            var words = original.Split(' ');
            var result = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == 0 || AllCapitals(word))
                    result.Add(word);
                else if (word.Length == 1)
                    result.Add(word.ToUpper());
                else
                    result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
            }

            return string.Join(" ", result).Replace(" Y ", " y ")
                .Replace(" De ", " de ")
                .Replace(" O ", " o ");
        }

        /// <summary>
        /// To all capitals
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static bool AllCapitals(string input) =>
            input.ToCharArray().All(char.IsUpper);

        /// <summary>
        /// To camel case
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string original)
        {
            if (original.Length <= 1)
                return original.ToLower();
            return char.ToLower(original[0]) + original.Substring(1);
        }

        #endregion

        #region Contains

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool Contains(this string text, string value, params string[] values)
        {
            return YieldReturnStrings().Any(text.Contains);

            IEnumerable<string> YieldReturnStrings()
            {
                yield return value;
                if (value is null)
                    yield break;
                foreach (var val in values)
                    yield return val;
            }
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character) =>
            text.Any(c => c == character);

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character, params char[] characters)
        {
            return YieldReturnCharacters().Any(text.Contains);

            IEnumerable<char> YieldReturnCharacters()
            {
                yield return character;
                if (characters is null)
                    yield break;
                foreach (var @char in characters)
                    yield return @char;
            }
        }

        #endregion

        #region Count

        /// <summary>
        /// Count lines
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CountLines(this string s)
        {
            int index = 0, lines = 0;

            while (true)
            {
                var newIndex = s.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
                if (newIndex < 0)
                {
                    if (s.Length > index)
                        lines++;

                    return lines;
                }

                index = newIndex + 2;
                lines++;
            }
        }

        /// <summary>
        /// Count Occurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int CountOccurrences(this string text, char toCheck) => text.CountOccurrences(toCheck.ToString());

        /// <summary>
        /// Count Occurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int CountOccurrences(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return 0;

            int res = 0, posIni = 0;
            while ((posIni = text.IndexOfIgnoreCase(posIni, toCheck)) != -1)
            {
                posIni += toCheck.Length;
                res++;
            }

            return res;
        }

        #endregion

        #region EndsWith

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string @string, params string[] values)
            => StringJudgment.EndWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string @string, ICollection<string> values)
            => StringJudgment.EndWithThese(@string, values);

        /// <summary>
        /// Ends with ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return true;
            return text.IsNullOrEmpty()
                ? toCheck.IsNullOrEmpty()
                : text.EndsWith(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Ends with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EndsWithAnyIgnoreCase(this string text, params string[] toCheck)
            => EndsWithAnyIgnoreCase(text, (IEnumerable<string>) toCheck);

        /// <summary>
        /// Ends with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EndsWithAnyIgnoreCase(this string text, IEnumerable<string> toCheck)
            => !text.IsNullOrEmpty() && toCheck.Any(check => text.EndsWith(check, StringComparison.OrdinalIgnoreCase));

        #endregion

        #region Is

        /// <summary>
        /// 检查字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// 检查字符串不是 null 或 System.String.Empty 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string str) => !str.IsNullOrEmpty();

        /// <summary>
        /// 检查字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// 检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string str) => !str.IsNullOrWhiteSpace();

        #endregion

        #region Left and Right

        /// <summary>
        /// Cut off from right to left.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string text, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length > 0", nameof(length));
            }

            if (length == 0 || text is null)
            {
                return "";
            }

            var strLength = text.Length;
            return length >= strLength ? text : text.Substring(strLength - length, length);
        }

        /// <summary>
        /// Cut off from left to right
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string text, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length > 0", nameof(length));
            }

            if (length == 0 || text is null)
            {
                return "";
            }

            return length >= text.Length ? text : text.Substring(0, length);
        }

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat
        /// </summary>
        /// <param name="text"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string Repeat(this string text, int times)
        {
            if (text.IsNullOrEmpty() || times == 0)
                return string.Empty;

            if (text.Length == 1)
                return new string(text[0], times);

            switch (times)
            {
                case 1:
                    return text;
                case 2:
                    return string.Concat(text, text);
                case 3:
                    return string.Concat(text, text, text);
                case 4:
                    return string.Concat(text, text, text, text);
            }

            var res = new StringBuilder(text.Length * times);
            for (var i = 0; i < times; i++)
            {
                res.Append(text);
            }

            return res.ToString();
        }

        #endregion

        #region StartsWith

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, params string[] values)
            => StringJudgment.StartWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, ICollection<string> values)
            => StringJudgment.StartWithThese(@string, values);

        /// <summary>
        /// Starts with ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return true;
            return text.IsNullOrEmpty()
                ? toCheck.IsNullOrEmpty()
                : text.StartsWith(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Starts with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool StartsWithAnyIgnoreCase(this string text, params string[] toCheck)
            => StartsWithAnyIgnoreCase(text, (IEnumerable<string>) toCheck);

        /// <summary>
        /// Starts with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool StartsWithAnyIgnoreCase(this string text, IEnumerable<string> toCheck)
            => !text.IsNullOrEmpty() && toCheck.Any(check => text.StartsWith(check, StringComparison.OrdinalIgnoreCase));

        #endregion

        #region Substring
        
        /// <summary>
        /// Extract around
        /// </summary>
        /// <param name="text"></param>
        /// <param name="index"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string ExtractAround(this string text, int index, int left, int right)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            if (index >= text.Length)
                throw new IndexOutOfRangeException("The parameter index is outside the limits of the string.");

            var startIndex = Math.Max(0, index - left);
            var length = Math.Min(text.Length - startIndex, index - startIndex + right);

            return text.Substring(startIndex, length);
        }

        /// <summary>
        /// SubString
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startText"></param>
        /// <returns></returns>
        public static string Substring(this string text, string startText)
        {
            var index = text.IndexOf(startText, StringComparison.Ordinal);
            if (index == -1)
                throw new ArgumentException($"Not found: '{startText}'.");
            return text.Substring(index);
        }

        /// <summary>
        /// SubString from...
        /// </summary>
        /// <param name="me"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string SubstringFrom(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : me.Substring(index + @from.Length);
        }

        /// <summary>
        /// SubString to...
        /// </summary>
        /// <param name="me"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string SubstringTo(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : me.Substring(0, index);
        }

        #endregion

        #region Trim

        /// <summary>
        /// Trim all
        /// </summary>
        /// <param name="texts"></param>
        public static void TrimAll(this IList<string> texts)
        {
            for (var i = 0; i < texts.Count; i++)
            {
                texts[i] = texts[i].Trim();
            }
        }

        /// <summary>
        /// Trim phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimPhrase(this string text, string phrase)
        {
            var res = TrimPhraseStart(text, phrase);
            res = TrimPhraseEnd(res, phrase);
            return res;
        }

        /// <summary>
        /// Trim phrase start
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimPhraseStart(this string text, string phrase)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            if (phrase.IsNullOrEmpty())
                return text;

            while (text.StartsWith(phrase))
            {
                text = text.Substring(phrase.Length);
            }

            return text;
        }

        /// <summary>
        /// Trim phrase end
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimPhraseEnd(this string text, string phrase)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            if (phrase.IsNullOrEmpty())
                return text;

            while (text.EndsWithIgnoreCase(phrase))
            {
                text = text.Substring(0, text.Length - phrase.Length);
            }

            return text;
        }

        #endregion
    }
}