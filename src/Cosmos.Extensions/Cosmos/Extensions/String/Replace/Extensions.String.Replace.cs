using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static string ReplaceIgnoringCase(this string original, string oldValue, string newValue)
        {
            return Replace(original, oldValue, newValue, StringComparison.OrdinalIgnoreCase);
        }

        public static string ReplaceOnlyWholePhrase(this string original, string oldValue, string newValue)
        {
            if (original.IsNullOrEmpty() || oldValue.IsNullOrEmpty())
                return original;

            var index = original.IndexWholePhrase(oldValue);
            var lastIndex = 0;

            var buffer = new StringBuilder(original.Length);

            while (index >= 0)
            {
                buffer.Append(original, startIndex: lastIndex, count: index - lastIndex);
                buffer.Append(newValue);

                lastIndex = index + oldValue.Length;

                index = original.IndexWholePhrase(oldValue, startIndex: index + 1);
            }
            buffer.Append(original, lastIndex, original.Length - lastIndex);

            return buffer.ToString();
        }

        public static string ReplaceFirstOccurrence(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            var index = original.IndexOfIgnoreCase(oldValue);

            if (index < 0)
                return original;

            if (index == 0)
                return newValue + original.Substring(oldValue.Length);

            return original.Substring(0, index) + newValue + original.Substring(index + oldValue.Length);
        }

        public static string ReplaceLastOccurrence(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            var index = original.LastIndexOfIgnoreCase(oldValue);

            if (index < 0)
                return original;

            if (index == 0)
                return newValue + original.Substring(oldValue.Length);

            return original.Substring(0, index) + newValue + original.Substring(index + oldValue.Length);
        }

        public static string ReplaceOnlyAtEndIgnoreCase(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            if (original.EndsWithIgnoreCase(oldValue))
                return original.Substring(0, original.Length - oldValue.Length) + newValue;

            return original;
        }


        public static string Replace(this string original, string oldValue, string newValue, StringComparison comparisionType)
        {
            if (original.IsNullOrEmpty())
                return original;

            string result = original;

            if (!string.IsNullOrEmpty(oldValue))
            {
                int index = -1, lastIndex = 0;

                var buffer = new StringBuilder(original.Length);

                while ((index = original.IndexOf(oldValue, index + 1, comparisionType)) >= 0)
                {
                    buffer.Append(original, lastIndex, index - lastIndex);
                    buffer.Append(newValue);

                    lastIndex = index + oldValue.Length;
                }
                buffer.Append(original, lastIndex, original.Length - lastIndex);

                result = buffer.ToString();
            }

            return result;
        }

        public static string ReplaceRecursive(this string original, string oldValue, string newValue)
        {
            const int MaxTries = 1000;

            string ante, res;

            res = original.Replace(oldValue, newValue);

            var i = 0;
            do
            {
                i++;
                ante = res;
                res = ante.Replace(oldValue, newValue);

            } while (ante != res || i > MaxTries);

            return res;
        }

        public static string ReplaceCharsWithSpace(this string me, params char[] toReplace)
        {
            var res = new StringBuilder(me);
            foreach (var replace in toReplace)
            {
                res.Replace(replace, ' ');
            }
            return res.ToString();
        }

        public static string ReplaceNumbersWith(this string me, char toReplace)
        {
            var res = new StringBuilder(me.Length);
            foreach (var caracter in me)
            {
                if (caracter.IsOn('1', '2', '3', '4', '5', '6', '7', '8', '9', '0'))
                    res.Append(toReplace);
                else
                    res.Append(caracter);
            }
            return res.ToString();
        }
    }
}
