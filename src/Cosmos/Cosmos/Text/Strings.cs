using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable InconsistentNaming

namespace Cosmos.Text
{
    internal static class AuxiliaryStringHelper
    {
        public static IEnumerable<T> M<T>(T t, IEnumerable<T> ts)
        {
            yield return t;
            if (ts is not null)
                foreach (var t0 in ts)
                    yield return t0;
        }
    }

    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static partial class Strings
    {
        #region Count

        /// <summary>
        /// Returns the number of letters contained in the string.<br />
        /// 返回字符串中所包含字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForLetters(string text)
        {
            return string.IsNullOrEmpty(text) ? 0 : FilterForLetters(text).Count();
        }

        /// <summary>
        /// Returns the number of uppercase letters in the string.<br />
        /// 返回字符串中所包含大写字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForLettersUpperCase(string text)
        {
            return string.IsNullOrEmpty(text) ? 0 : FilterForLetters(text).Where(char.IsUpper).Count();
        }

        /// <summary>
        /// Returns the number of lowercase letters in the string.<br />
        /// 返回字符串中所包含小写字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForLettersLowerCase(string text)
        {
            return string.IsNullOrEmpty(text) ? 0 : FilterForLetters(text).Where(char.IsLower).Count();
        }

        /// <summary>
        /// Returns the number of digit contained in the string.<br />
        /// 返回字符串中所包含数字的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForDigit(string text)
        {
            return string.IsNullOrEmpty(text) ? 0 : FilterForNumbers(text).Count();
        }

        /// <summary>
        /// Count Occurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int CountOccurrences(string text, char toCheck)
        {
            return CountOccurrences(text, toCheck.ToString());
        }

        /// <summary>
        /// Count Occurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int CountOccurrences(string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return 0;

            int ret = 0, offset = 0;
            while ((offset = text.IndexOfIgnoreCase(offset, toCheck)) != -1)
            {
                offset += toCheck.Length;
                ret++;
            }

            return ret;
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
        public static bool Contains(string text, string value, params string[] values)
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
        public static bool Contains(string text, char character)
        {
            return text.Any(c => c == character);
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static bool Contains(string text, char character, params char[] characters)
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

        #region Empty

        /// <summary>
        /// Avoid null, so convert null to empty.<br />
        /// 将 null 转换为 Empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AvoidNull(string text) => text ?? string.Empty;

        /// <summary>
        /// Convert null to empty.<br />
        /// 将 null 转换为 Empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string NullToEmpty(string text) => AvoidNull(text);

        /// <summary>
        /// Convert empty to null.<br />
        /// 将 Empty 转换为 null
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EmptyToNull(string text) => string.IsNullOrEmpty(text) ? null : text;

        #endregion

        #region Filter

        /// <summary>
        /// Filter by char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<char> FilterByChar(string text, Func<char, bool> predicate)
        {
            return text.ToCharArray().Where(predicate);
        }

        /// <summary>
        /// Filter for only letters and numbers.<br />
        /// 只获取字母和数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<char> FilterForNumbersAndLetters(string text)
        {
            return FilterByChar(text, __check);

            bool __check(char @char)
            {
                return (@char >= 'a' && @char <= 'z') || (@char >= 'A' && @char <= 'Z') || (@char >= '0' && @char <= '9');
            }
        }

        /// <summary>
        /// Filter for only digit.<br />
        /// 只获取字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<char> FilterForNumbers(string text)
        {
            return FilterByChar(text, __check);

            bool __check(char @char)
            {
                return @char >= '0' && @char <= '9';
            }
        }

        /// <summary>
        /// Filter for only letters.<br />
        /// 只获取字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<char> FilterForLetters(string text)
        {
            return FilterByChar(text, __check);

            bool __check(char @char)
            {
                return (@char >= 'a' && @char <= 'z') || (@char >= 'A' && @char <= 'Z');
            }
        }

        #endregion

        #region Get

        /// <summary>
        /// Get only letters and numbers.<br />
        /// 只获取字母和数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetNumbersAndLetters(string text)
        {
            return Merge(FilterForNumbersAndLetters(text));
        }

        /// <summary>
        /// Get only digit.<br />
        /// 只获取字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetNumbers(string text)
        {
            return Merge(FilterForNumbers(text));
        }

        /// <summary>
        /// Get only letters.<br />
        /// 只获取字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetLetters(string text)
        {
            return Merge(FilterForLetters(text));
        }

        #endregion

        #region Has Numbers

        /// <summary>
        /// Returns whether it contains digit.<br />
        /// 返回是否包含数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool HasNumbers(string text)
        {
            return HasNumbersAtLeast(text, 1);
        }

        /// <summary>
        /// Contain at least the specified number of digit.<br />
        /// 至少包含指定数量的数字。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool HasNumbersAtLeast(string text, int minCount)
        {
            minCount = minCount <= 0 ? 1 : minCount;
            return FilterForNumbers(text).Count() >= minCount;
        }

        #endregion

        #region Has Letters

        /// <summary>
        /// Returns whether it contains letters.<br />
        /// 返回是否包含字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool HasLetters(string text)
        {
            return HasLettersAtLeast(text, 1);
        }

        /// <summary>
        /// Contain at least the specified number of letters.<br />
        /// 至少包含指定数量的字母。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool HasLettersAtLeast(string text, int minCount)
        {
            minCount = minCount <= 0 ? 1 : minCount;
            return FilterForLetters(text).Count() >= minCount;
        }

        #endregion

        #region Left and Right

        /// <summary>
        /// Cut off from right to left.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(string text, int length)
        {
            if (length < 0)
                throw new ArgumentException("Length > 0", nameof(length));

            if (length == 0 || text is null)
                return string.Empty;

            var strLength = text.Length;
            return length >= strLength ? text : text.Substring(strLength - length, length);
        }

        /// <summary>
        /// Cut off from left to right
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(string text, int length)
        {
            if (length < 0)
                throw new ArgumentException("Length > 0", nameof(length));

            if (length == 0 || text is null)
                return string.Empty;

            return length >= text.Length ? text : text.Substring(0, length);
        }

        #endregion

        #region Merge

        public static string Merge(IEnumerable<char> chars)
        {
            var builder = new StringBuilder();
            if (chars is not null)
                foreach (var val in chars)
                    builder.Append(val);
            return builder.ToString();
        }

        public static string Merge(string text, params string[] strings)
        {
            var builder = new StringBuilder();
            builder.Append(text);
            if (strings is not null)
                for (var i = 0; i < strings.Length; i++)
                    builder.Append(strings[i]);
            return builder.ToString();
        }

        public static string Merge(string text, string @string, params string[] strings)
        {
            var builder = new StringBuilder();
            builder.Append(text);
            foreach (var val in AuxiliaryStringHelper.M(@string, strings))
                builder.Append(val);
            return builder.ToString();
        }

        public static string Merge(string text, char @char, params char[] chars)
        {
            var builder = new StringBuilder();
            builder.Append(text);
            foreach (var val in AuxiliaryStringHelper.M(@char, chars))
                builder.Append(val);
            return builder.ToString();
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeText"></param>
        /// <returns></returns>
        public static string Remove(string text, string removeText)
        {
            return text.Replace(removeText, string.Empty);
        }

        /// <summary>
        /// Remove all specified characters. <br />
        /// 移除所有指定的字符。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public static string RemoveChars(string text, params char[] toRemove)
        {
            var builder = new StringBuilder(text);
            foreach (var remove in toRemove)
                builder.Replace(remove, char.MinValue);
            builder.Replace(char.MinValue.ToString(), string.Empty);
            return builder.ToString();
        }

        /// <summary>
        /// Remove all spaces. <br />
        /// 移除所有空格。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpace(string text)
        {
            return RemoveChars(text, ' ');
        }

        /// <summary>
        /// Remove duplicate space
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveDuplicateWhiteSpaces(string text)
        {
            return RemoveDuplicateChar(text, ' ');
        }

        /// <summary>
        /// Remove duplicate char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charRemove"></param>
        /// <returns></returns>
        public static string RemoveDuplicateChar(string text, char charRemove)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var builder = new StringBuilder();

            var index = 0;
            var offset = 0;
            var length = text.Length;

            while (true)
            {
                if (index >= length) break;

                var @char = text[index];

                if (@char != charRemove)
                {
                    builder.Append(@char);
                    index++;
                }
                else
                {
                    builder.Append(charRemove);
                    UpdateOffset();
                    index += offset;
                }
            }

            return builder.ToString();

            void UpdateOffset()
            {
                offset = 0;
                while (IsMatchedNextChar())
                    ++offset;
            }

            bool IsMatchedNextChar()
            {
                if (index + offset >= length) return false;
                return text[index + offset] == charRemove;
            }
        }

        /// <summary>
        /// Remove since the given index
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indexOfStartToRemove"></param>
        /// <returns></returns>
        public static string RemoveSince(string text, int indexOfStartToRemove)
        {
            return indexOfStartToRemove <= 0 ? text : text.Substring(0, indexOfStartToRemove);
        }

        /// <summary>
        /// Remove since the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeFromThis"></param>
        /// <returns></returns>
        public static string RemoveSince(string text, string removeFromThis)
        {
            if (string.IsNullOrEmpty(removeFromThis))
                return text;
            var index = text.IndexOf(removeFromThis, StringComparison.Ordinal);
            return RemoveSince(text, index);
        }

        /// <summary>
        /// Remove since the given text and ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeFromThis"></param>
        /// <returns></returns>
        public static string RemoveSinceIgnoreCase(string text, string removeFromThis)
        {
            if (string.IsNullOrEmpty(removeFromThis))
                return text;
            var index = text.IndexOf(removeFromThis, StringComparison.OrdinalIgnoreCase);
            return RemoveSince(text, index);
        }

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="text"></param>
        /// <param name="repeatTimes"></param>
        /// <returns></returns>
        public static string Repeat(string text, int repeatTimes)
        {
            if (repeatTimes < 0)
                return string.Empty;

            if (text.IsNullOrEmpty() || repeatTimes == 0)
                return string.Empty;

            if (text.Length == 1)
                return new string(text[0], repeatTimes);

            switch (repeatTimes)
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

            var res = new StringBuilder(text.Length * repeatTimes);
            for (var i = 0; i < repeatTimes; i++)
                res.Append(text);
            return res.ToString();
        }

        #endregion

        #region Replace

        /// <summary>
        /// Replace ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(string text, string oldValue, string newValue)
        {
            return Replace(text, oldValue, newValue, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Replace only whole phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceOnlyWholePhrase(string text, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (string.IsNullOrEmpty(oldValue))
                return text;

            var index = text.IndexOfWholePhrase(oldValue);
            var lastIndex = 0;

            var buffer = new StringBuilder(text.Length);

            while (index >= 0)
            {
                buffer.Append(text, startIndex: lastIndex, count: index - lastIndex);
                buffer.Append(newValue);

                lastIndex = index + oldValue.Length;

                index = text.IndexOfWholePhrase(oldValue, startIndex: index + 1);
            }

            buffer.Append(text, lastIndex, text.Length - lastIndex);

            return buffer.ToString();
        }

        /// <summary>
        /// Replace first occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceFirstOccurrence(string text, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (string.IsNullOrEmpty(oldValue))
                return text;

            var index = text.IndexOfIgnoreCase(oldValue);

            if (index < 0)
                return text;

            if (index == 0)
                return $"{newValue}{text.Substring(oldValue.Length)}";

            return $"{text.Substring(0, index)}{newValue}{text.Substring(index + oldValue.Length)}";
        }

        /// <summary>
        /// Replace last occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceLastOccurrence(string text, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (string.IsNullOrEmpty(oldValue))
                return text;

            var index = text.LastIndexOfIgnoreCase(oldValue);

            if (index < 0)
                return text;

            if (index == 0)
                return $"{newValue}{text.Substring(oldValue.Length)}";

            return $"{text.Substring(0, index)}{newValue}{text.Substring(index + oldValue.Length)}";
        }

        /// <summary>
        /// Replace only at end ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceOnlyAtEndIgnoreCase(string text, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (string.IsNullOrEmpty(oldValue))
                return text;

            if (text.EndsWithIgnoreCase(oldValue))
                return $"{text.Substring(0, text.Length - oldValue.Length)}{newValue}";

            return text;
        }

        /// <summary>
        /// Replace
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="comparisionType"></param>
        /// <returns></returns>
        public static string Replace(string text, string oldValue, string newValue, StringComparison comparisionType)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (string.IsNullOrEmpty(oldValue))
                return text;

            int index = -1, lastIndex = 0;

            var buffer = new StringBuilder(text.Length);

            while ((index = text.IndexOf(oldValue, index + 1, comparisionType)) >= 0)
            {
                buffer.Append(text, lastIndex, index - lastIndex);
                buffer.Append(newValue);

                lastIndex = index + oldValue.Length;
            }

            buffer.Append(text, lastIndex, text.Length - lastIndex);

            return buffer.ToString();
        }

        /// <summary>
        /// Replace recursive
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceRecursive(string text, string oldValue, string newValue)
        {
            const int maxTries = 1000;

            string temp, ret;

            ret = text.Replace(oldValue, newValue);

            var i = 0;
            do
            {
                i++;
                temp = ret;
                ret = temp.Replace(oldValue, newValue);
            } while (temp != ret || i > maxTries);

            return ret;
        }

        /// <summary>
        /// Replace chars with space
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toReplace"></param>
        /// <returns></returns>
        public static string ReplaceCharsWithWhiteSpace(string text, params char[] toReplace)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            if (toReplace is null || toReplace.Length == 0)
                return text;

            var holder = new char[text.Length];

            for (var i = 0; i < text.Length; i++)
            {
                var @char = text[i];
                var matched = false;
                for (var j = 0; j < toReplace.Length; j++)
                {
                    if (@char == toReplace[j])
                    {
                        holder[i] = ' ';
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    holder[i] = @char;
                }
            }

            return new string(holder);
        }

        /// <summary>
        /// Replace numbers with...
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toReplace"></param>
        /// <returns></returns>
        public static string ReplaceNumbersWith(string text, char toReplace)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var holder = new char[text.Length];

            for (var i = 0; i < text.Length; i++)
            {
                var @char = text[i];
                if (@char >= '0' && @char <= '9')
                    holder[i] = toReplace;
                else
                    holder[i] = @char;
            }

            return new string(holder);
        }

        #endregion

        #region Truncate

        /// <summary>
        /// Truncate
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <param name="placeholder"></param>
        /// <param name="shortPlaceholder"></param>
        /// <returns></returns>
        public static string Truncate(string text, int maxLength, string placeholder = "...", string shortPlaceholder = ".")
        {
            if (string.IsNullOrEmpty(text) || maxLength <= 0)
                return string.Empty;
            if (string.IsNullOrEmpty(placeholder))
                placeholder = "...";
            if (string.IsNullOrEmpty(shortPlaceholder))
                shortPlaceholder = ".";
            if (text.Length <= maxLength)
                return text;
            if (maxLength <= 3)
                return $"{Left(text, 2)}{shortPlaceholder}";
            return $"{Left(text, maxLength - 3)}{placeholder}";
        }

        #endregion

        #region Prefix / Suffix

        /// <summary>
        /// Returns the common prefix.<br />
        /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonPrefix(string left, string right)
        {
            return CommonPrefix(left, right, out _);
        }

        /// <summary>
        /// Returns the common prefix.<br />
        /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CommonPrefix(string left, string right, out int len)
        {
            len = 0;
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            for (var i = 0; i < rangeTimes; i++, len++)
                if (left[i] != right[i])
                    break;
            return left.Left(len);
        }

        /// <summary>
        /// Returns the common suffix.<br />
        /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonSuffix(string left, string right)
        {
            return CommonSuffix(left, right, out _);
        }

        /// <summary>
        /// Returns the common suffix.<br />
        /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CommonSuffix(string left, string right, out int len)
        {
            len = 0;
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            int leftPointer = left.Length - 1, rightPointer = right.Length - 1;
            for (var i = 0; i < rangeTimes; i++, len++, leftPointer--, rightPointer--)
                if (left[leftPointer] != right[rightPointer])
                    break;
            return right.Right(len);
        }

        #endregion
    }

    public static partial class StringsExtensions
    {
        #region Count

        /// <summary>
        /// Returns the number of letters contained in the string.<br />
        /// 返回字符串中所包含字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForLetters(this string text)
        {
            return Strings.CountForLetters(text);
        }

        /// <summary>
        /// Returns the number of uppercase letters in the string.<br />
        /// 返回字符串中所包含大写字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForLettersUpperCase(this string text)
        {
            return Strings.CountForLettersUpperCase(text);
        }

        /// <summary>
        /// Returns the number of lowercase letters in the string.<br />
        /// 返回字符串中所包含小写字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForLettersLowerCase(this string text)
        {
            return Strings.CountForLettersLowerCase(text);
        }

        /// <summary>
        /// Returns the number of digit contained in the string.<br />
        /// 返回字符串中所包含数字的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountForDigit(this string text)
        {
            return Strings.CountForDigit(text);
        }

        /// <summary>
        /// Count Occurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int CountOccurrences(this string text, char toCheck)
        {
            return Strings.CountOccurrences(text, toCheck);
        }

        /// <summary>
        /// Count Occurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int CountOccurrences(this string text, string toCheck)
        {
            return Strings.CountOccurrences(text, toCheck);
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
            return Strings.Contains(text, value, values);
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character)
        {
            return Strings.Contains(text, character);
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character, params char[] characters)
        {
            return Strings.Contains(text, character, characters);
        }

        #endregion

        #region Equals

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="targetText"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string text, string targetText) =>
            string.Equals(text, targetText, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Equals to any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="targetTexts"></param>
        /// <returns></returns>
        public static bool EqualsToAnyIgnoreCase(this string text, params string[] targetTexts) =>
            targetTexts != null &&
            targetTexts.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));

        #endregion

        #region Filter

        public static IEnumerable<char> Where(this string text, Func<char, bool> predicate)
        {
            return Strings.FilterByChar(text, predicate);
        }

        #endregion

        #region Has Numbers

        /// <summary>
        /// Returns whether it contains digit.<br />
        /// 返回是否包含数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool HasNumbers(this string text)
        {
            return Strings.HasNumbers(text);
        }

        /// <summary>
        /// Contain at least the specified number of digit.<br />
        /// 至少包含指定数量的数字。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool HasNumbersAtLeast(this string text, int minCount)
        {
            return Strings.HasNumbersAtLeast(text, minCount);
        }

        #endregion

        #region Has Letters

        /// <summary>
        /// Returns whether it contains letters.<br />
        /// 返回是否包含字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsLetters(this string text)
        {
            return Strings.HasLetters(text);
        }

        /// <summary>
        /// Contain at least the specified number of letters.<br />
        /// 至少包含指定数量的字母。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool ContainsLettersAtLeast(this string text, int minCount)
        {
            return Strings.HasLettersAtLeast(text, minCount);
        }

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
            return Strings.Right(text, length);
        }

        /// <summary>
        /// Cut off from left to right
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string text, int length)
        {
            return Strings.Left(text, length);
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeText"></param>
        /// <returns></returns>
        public static string Remove(this string text, string removeText)
        {
            return Strings.Remove(text, removeText);
        }

        /// <summary>
        /// Remove all specified characters. <br />
        /// 移除所有指定的字符。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public static string RemoveChars(this string text, params char[] toRemove)
        {
            return Strings.RemoveChars(text, toRemove);
        }

        /// <summary>
        /// Remove all spaces. <br />
        /// 移除所有空格。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpace(this string text)
        {
            return Strings.RemoveWhiteSpace(text);
        }

        /// <summary>
        /// Remove duplicate space
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveDuplicateWhiteSpaces(this string text)
        {
            return Strings.RemoveDuplicateWhiteSpaces(text);
        }

        /// <summary>
        /// Remove duplicate char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charRemove"></param>
        /// <returns></returns>
        public static string RemoveDuplicateChar(this string text, char charRemove)
        {
            return Strings.RemoveDuplicateChar(text, charRemove);
        }

        /// <summary>
        /// Remove since the given index
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indexOfStartToRemove"></param>
        /// <returns></returns>
        public static string RemoveSince(this string text, int indexOfStartToRemove)
        {
            return Strings.RemoveSince(text, indexOfStartToRemove);
        }

        /// <summary>
        /// Remove since the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeFromThis"></param>
        /// <returns></returns>
        public static string RemoveSince(this string text, string removeFromThis)
        {
            return Strings.RemoveSince(text, removeFromThis);
        }

        /// <summary>
        /// Remove since the given text and ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeFromThis"></param>
        /// <returns></returns>
        public static string RemoveSinceIgnoreCase(this string text, string removeFromThis)
        {
            return Strings.RemoveSinceIgnoreCase(text, removeFromThis);
        }

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="text"></param>
        /// <param name="repeatTimes"></param>
        /// <returns></returns>
        public static string Repeat(this string text, int repeatTimes)
        {
            return Strings.Repeat(text, repeatTimes);
        }

        #endregion

        #region Replace

        /// <summary>
        /// Replace ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string text, string oldValue, string newValue)
        {
            return Strings.ReplaceIgnoreCase(text, oldValue, newValue);
        }

        /// <summary>
        /// Replace only whole phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceOnlyWholePhrase(this string text, string oldValue, string newValue)
        {
            return Strings.ReplaceOnlyWholePhrase(text, oldValue, newValue);
        }

        /// <summary>
        /// Replace first occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceFirstOccurrence(this string text, string oldValue, string newValue)
        {
            return Strings.ReplaceFirstOccurrence(text, oldValue, newValue);
        }

        /// <summary>
        /// Replace last occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceLastOccurrence(this string text, string oldValue, string newValue)
        {
            return Strings.ReplaceLastOccurrence(text, oldValue, newValue);
        }

        /// <summary>
        /// Replace only at end ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceOnlyAtEndIgnoreCase(this string text, string oldValue, string newValue)
        {
            return Strings.ReplaceOnlyAtEndIgnoreCase(text, oldValue, newValue);
        }

        /// <summary>
        /// Replace
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="comparisionType"></param>
        /// <returns></returns>
        public static string Replace(this string text, string oldValue, string newValue, StringComparison comparisionType)
        {
            return Strings.Replace(text, oldValue, newValue, comparisionType);
        }

        /// <summary>
        /// Replace recursive
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceRecursive(this string text, string oldValue, string newValue)
        {
            return Strings.ReplaceRecursive(text, oldValue, newValue);
        }

        /// <summary>
        /// Replace chars with space
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toReplace"></param>
        /// <returns></returns>
        public static string ReplaceCharsWithWhiteSpace(this string text, params char[] toReplace)
        {
            return Strings.ReplaceCharsWithWhiteSpace(text, toReplace);
        }

        /// <summary>
        /// Replace numbers with...
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toReplace"></param>
        /// <returns></returns>
        public static string ReplaceNumbersWith(this string text, char toReplace)
        {
            return Strings.ReplaceNumbersWith(text, toReplace);
        }

        #endregion

        #region Truncate

        /// <summary>
        /// Truncate
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <param name="placeholder"></param>
        /// <param name="shortPlaceholder"></param>
        /// <returns></returns>
        public static string Truncate(this string text, int maxLength, string placeholder = "...", string shortPlaceholder = ".")
        {
            return Strings.Truncate(text, maxLength, placeholder, shortPlaceholder);
        }

        #endregion
        
         #region Prefix / Suffix

        /// <summary>
        /// Returns the common prefix.<br />
        /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonPrefix(this string left, string right)
        {
            return Strings.CommonPrefix(left, right);
        }

        /// <summary>
        /// Returns the common prefix.<br />
        /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CommonPrefix(this string left, string right, out int len)
        {
            return Strings.CommonPrefix(left, right, out len);
        }

        /// <summary>
        /// Returns the common suffix.<br />
        /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonSuffix(this string left, string right)
        {
            return Strings.CommonSuffix(left, right);
        }

        /// <summary>
        /// Returns the common suffix.<br />
        /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CommonSuffix(this string left, string right, out int len)
        {
            return Strings.CommonSuffix(left, right, out len);
        }

        #endregion
    }

    public static partial class StringsShortcutExtensions
    {
        #region Encoding

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            return value is null
                ? throw new ArgumentNullException(nameof(value))
                : (encoding ?? Encoding.UTF8).GetBytes(value);
        }

        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetString(this byte[] bytes, Encoding encoding = null)
        {
            return bytes is null
                ? throw new ArgumentNullException(nameof(bytes))
                : (encoding ?? Encoding.UTF8).GetString(bytes);
        }

        #endregion

        #region EndsWith

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string text, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
                return true;

            return values.Any(text.EndsWith);
        }

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string text, IEnumerable<string> values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || !values.Any())
                return true;

            return EndsWith(text, values.ToArray());
        }

        /// <summary>
        /// Ends with ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string text, string values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values.IsNullOrEmpty())
                return true;

            return text.EndsWith(values, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Ends with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string text, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
                return true;

            return EndsWithIgnoreCase(text, (IEnumerable<string>) values);
        }

        /// <summary>
        /// Ends with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string text, IEnumerable<string> values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || !values.Any())
                return true;

            return values.Any(check => text.EndsWith(check, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region Index

        /// <summary>
        /// Index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int IndexOfIgnoreCase(this string text, string toCheck)
        {
            return text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int IndexOfIgnoreCase(this string text, int startIndex, string toCheck)
        {
            return text.IndexOf(toCheck, startIndex, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Last index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int LastIndexOfIgnoreCase(this string text, string toCheck)
        {
            return text.LastIndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Last index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int LastIndexOfIgnoreCase(this string text, string toCheck, int startIndex, int count)
        {
            return text.LastIndexOf(toCheck, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Last index of any
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int LastIndexOfAny(this string text, params string[] toCheck)
        {
            if (toCheck is null || toCheck.Length == 0)
                throw new ArgumentNullException($"The parameter '{nameof(toCheck)}' cannot be null or empty.", nameof(toCheck));

            var res = -1;
            foreach (var checking in toCheck)
            {
                var index = text.LastIndexOf(checking, StringComparison.OrdinalIgnoreCase);
                if (index >= 0 && index > res)
                    res = index;
            }

            return res;
        }

        /// <summary>
        /// Index whole phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int IndexOfWholePhrase(this string text, string toCheck, int startIndex = 0)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentNullException($"The parameter '{nameof(toCheck)}' cannot be null or empty.", nameof(toCheck));

            //var length = toCheck.Length;
            while (startIndex <= text.Length)
            {
                var index = text.IndexOfIgnoreCase(startIndex, toCheck);
                if (index < 0)
                    return -1;

                var indexPreviousCar = index - 1;
                var indexNextCar = index + toCheck.Length;
                if (
                    (index == 0 || !char.IsLetter(text[indexPreviousCar]))
                  &&
                    (index + toCheck.Length == text.Length || !char.IsLetter(text[indexNextCar]))
                )
                    return index;

                startIndex = index + toCheck.Length;
            }

            return -1;
        }

        #endregion

        #region StartsWith

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string text, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
                return true;

            return values.Any(text.StartsWith);
        }

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string text, IEnumerable<string> values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || !values.Any())
                return true;

            return StartsWith(text, values.ToArray());
        }

        /// <summary>
        /// Starts with ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string text, string values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values.IsNullOrEmpty())
                return true;

            return text.StartsWith(values, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Starts with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string text, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
                return true;

            return StartsWithIgnoreCase(text, (IEnumerable<string>) values);
        }

        /// <summary>
        /// Starts with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string text, IEnumerable<string> values)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (values is null || !values.Any())
                return true;

            return values.Any(check => text.StartsWith(check, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region Substring

        /// <summary>
        /// SubString from...
        /// </summary>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string SubstringSince(this string text, string from)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            var index = text.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : text.Substring(index);
        }

        /// <summary>
        /// SubString to...
        /// </summary>
        /// <param name="text"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static string SubstringTo(this string text, string to)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            var index = text.IndexOfIgnoreCase(to);
            return index < 0 ? string.Empty : text.Substring(0, index);
        }

        #endregion

        #region Trim

        /// <summary>
        /// Remove all spaces. <br />
        /// 移除所有空格。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TrimInner(this string text)
        {
            return Strings.RemoveWhiteSpace(text);
        }

        /// <summary>
        /// Trim all
        /// </summary>
        /// <param name="texts"></param>
        public static void TrimAll(this IList<string> texts)
        {
            if (texts is null)
                return;

            for (var i = 0; i < texts.Count; i++)
                texts[i] = texts[i].Trim();
        }

        /// <summary>
        /// Trim phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimPhrase(this string text, string phrase)
        {
            return text.TrimPhraseStart(phrase).TrimPhraseEnd(phrase);
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