using System;
using System.Linq;
using System.Text;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> extensions.
    /// </summary>
    public static class StringExtensions
    {
        #region Equals

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string text, string toCheck) =>
            string.Equals(text, toCheck, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Equals to any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsToAnyIgnoreCase(this string text, params string[] toCheck) =>
            toCheck != null && toCheck.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));

        #endregion
        
        #region Index

        /// <summary>
        /// Index whole phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int IndexWholePhrase(this string text, string toCheck, int startIndex = 0)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentNullException($"The parameter '{nameof(toCheck)}' cannot be null or empty.", nameof(toCheck));

            //var startIndex = 0;
            while (startIndex <= text.Length)
            {
                var index = text.IndexOfIgnoreCase(startIndex, toCheck);
                if (index < 0)
                    return -1;

                var indexPreviousCar = index - 1;
                var indexNextCar = index + toCheck.Length;
                if ((index == 0 || !char.IsLetter(text[indexPreviousCar])) &&
                    (index + toCheck.Length == text.Length || !char.IsLetter(text[indexNextCar])))
                    return index;

                startIndex = index + toCheck.Length;
            }

            return -1;
        }

        /// <summary>
        /// Index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int IndexOfIgnoreCase(this string text, string toCheck) =>
            text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Last index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int LastIndexOfIgnoreCase(this string text, string toCheck) =>
            text.LastIndexOf(toCheck, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Last index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int LastIndexOfIgnoreCase(this string text, string toCheck, int startIndex, int count) =>
            text.LastIndexOf(toCheck, startIndex, count, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Index of ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int IndexOfIgnoreCase(this string text, int startIndex, string toCheck) =>
            text.IndexOf(toCheck, startIndex, StringComparison.OrdinalIgnoreCase);

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

        #endregion

        #region Remove

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeText"></param>
        /// <returns></returns>
        public static string Remove(this string text, string removeText) =>
            text.Replace(removeText, string.Empty);

        /// <summary>
        /// Remove from ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeFromThis"></param>
        /// <returns></returns>
        public static string RemoveFromIgnoreCase(this string text, string removeFromThis)
        {
            var index = text.IndexOfIgnoreCase(removeFromThis);
            return index < 0 ? text : text.Substring(0, index);
        }

        /// <summary>
        /// Remove duplicate space
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string RemoveDuplicateSpaces(this string me)
        {
            if (me.IsNullOrEmpty())
                return me;

            string ante = null;
            while (ante != me)
            {
                ante = me;
                me = me.Replace("  ", " ");
            }

            return me;
        }

        /// <summary>
        /// Remove duplicate char
        /// </summary>
        /// <param name="me"></param>
        /// <param name="charRemove"></param>
        /// <returns></returns>
        public static string RemoveDuplicateChar(this string me, char charRemove)
        {
            if (me.IsNullOrEmpty())
                return me;

            var strChar = charRemove.ToString();
            var charRep = strChar + strChar;

            string ante = null;
            while (ante != me)
            {
                ante = me;
                me = me.Replace(charRep, strChar);
            }

            return me;
        }

        /// <summary>
        /// Remove chars
        /// </summary>
        /// <param name="me"></param>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public static string RemoveChars(this string me, params char[] toRemove)
        {
            var res = new StringBuilder(me);
            foreach (var remove in toRemove)
            {
                res.Replace(remove, char.MinValue);
            }

            res.Replace(char.MinValue.ToString(), string.Empty);
            return res.ToString();
        }

        /// <summary>
        /// Remove accents ignore case and N
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveAccentsIgnoreCaseAndÑ(this string text) =>
            text.IsNullOrEmpty() ? text : text.RemoveAccentsIgnoreCase().Replace('Ñ', 'N').Replace('ñ', 'n');

        /// <summary>
        /// Remove accents ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveAccentsIgnoreCase(this string text)
        {
            if (text.IsNullOrEmpty())
                return text;

            return text.Replace('Á', 'A')
                       .Replace('É', 'E')
                       .Replace('Í', 'I')
                       .Replace('Ó', 'O')
                       .Replace('Ú', 'U')
                       .Replace('ü', 'u')
                       .Replace('Ü', 'U')
                       .Replace('á', 'a')
                       .Replace('é', 'e')
                       .Replace('í', 'i')
                       .Replace('ó', 'o')
                       .Replace('ú', 'u');
        }

        #endregion

        #region Replace

        /// <summary>
        /// Replace ignore case
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceIgnoringCase(this string original, string oldValue, string newValue) =>
            Replace(original, oldValue, newValue, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Replace only whole phrase
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Replace first occurrence
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Replace last occurrence
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Replace only at end ignore case
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceOnlyAtEndIgnoreCase(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            if (original.EndsWithIgnoreCase(oldValue))
                return original.Substring(0, original.Length - oldValue.Length) + newValue;

            return original;
        }

        /// <summary>
        /// Replace
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="comparisionType"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Replace recursive
        /// </summary>
        /// <param name="original"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceRecursive(this string original, string oldValue, string newValue)
        {
            const int maxTries = 1000;

            string ante, res;

            res = original.Replace(oldValue, newValue);

            var i = 0;
            do
            {
                i++;
                ante = res;
                res = ante.Replace(oldValue, newValue);
            } while (ante != res || i > maxTries);

            return res;
        }

        /// <summary>
        /// Replace chars with space
        /// </summary>
        /// <param name="me"></param>
        /// <param name="toReplace"></param>
        /// <returns></returns>
        public static string ReplaceCharsWithSpace(this string me, params char[] toReplace)
        {
            var res = new StringBuilder(me);
            foreach (var replace in toReplace)
            {
                res.Replace(replace, ' ');
            }

            return res.ToString();
        }

        /// <summary>
        /// Replace numbers with...
        /// </summary>
        /// <param name="me"></param>
        /// <param name="toReplace"></param>
        /// <returns></returns>
        public static string ReplaceNumbersWith(this string me, char toReplace)
        {
            var res = new StringBuilder(me.Length);
            foreach (var character in me)
            {
                if (character.IsOn('1', '2', '3', '4', '5', '6', '7', '8', '9', '0'))
                    res.Append(toReplace);
                else
                    res.Append(character);
            }

            return res.ToString();
        }

        #endregion

        #region Truncate

        /// <summary>
        /// Truncate
        /// </summary>
        /// <param name="original"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string original, int maxLength)
        {
            if (original.IsNullOrEmpty() || maxLength == 0)
                return string.Empty;
            if (original.Length <= maxLength)
                return original;
            if (maxLength <= 3)
                return original.Substring(0, 2) + ".";
            return original.Substring(0, maxLength - 3) + "...";
        }

        #endregion
    }
}