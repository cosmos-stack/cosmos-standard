using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static string Fill(this string original, params object[] values)
        {
            string texto =
                original.Replace("\\n", Environment.NewLine)
                    .Replace("<br>", Environment.NewLine)
                    .Replace("<BR>", Environment.NewLine);

            return string.Format(texto, values);
        }

        public static IEnumerable<string> EnumerateLines(this string s)
        {
            var index = 0;

            while (true)
            {
                var newIndex = s.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
                if (newIndex < 0)
                {
                    if (s.Length > index)
                        yield return s.Substring(index);

                    yield break;
                }

                var currentString = s.Substring(index, newIndex - index);
                index = newIndex + 2;

                yield return currentString;
            }
        }

        public static string ToValidIdentifier(this string original)
        {
            original = original.ToCapitalCase();

            if (original.Length == 0)
                return "_";

            StringBuilder res = new StringBuilder(original.Length + 1);
            if (!char.IsLetter(original[0]) && original[0] != '_')
                res.Append('_');

            for (int i = 0; i < original.Length; i++)
            {
                char c = original[i];
                if (char.IsLetterOrDigit(c) || c == '_')
                    res.Append(c);
                else
                    res.Append('_');
            }

            return res.ToString().ReplaceRecursive("__", "_").Trim('_');
        }

        public static string UseAsSeparatorFor<T>(this string separator, IEnumerable<T> list)
        {
            return list.JoinToString(separator);
        }

        public static string AvoidNull(this string original)
        {
            if (original == null)
                return string.Empty;

            return original;
        }

        public static string Repeat(this string text, int times)
        {
            if (text.IsNullOrEmpty() || times == 0)
                return string.Empty;

            if (text.Length == 1)
                return new string(text[0], times);

            if (times == 1)
                return text;
            else if (times == 2)
                return string.Concat(text, text);
            else if (times == 3)
                return string.Concat(text, text, text);
            else if (times == 4)
                return string.Concat(text, text, text, text);

            StringBuilder res = new StringBuilder(text.Length * times);
            for (int i = 0; i < times; i++)
            {
                res.Append(text);
            }
            return res.ToString();
        }

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

        public static string OnlyLettersNumbers(this string text)
        {
            var res = new StringBuilder(text.Length);

            foreach (char car in text)
            {
                if (char.IsLetterOrDigit(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        public static string FilterChars(this string text, Predicate<char> onlyThese)
        {
            var res = new StringBuilder(text.Length);

            foreach (char car in text)
            {
                if (onlyThese(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        public static string SafeGroupValue(this Match match, string name)
        {
            var group = match.Groups[name];

            if (group == null)
                return null;

            return match.Groups[name].Value;
        }
       
    }
}