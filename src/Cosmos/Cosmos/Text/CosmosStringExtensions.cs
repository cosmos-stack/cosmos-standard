using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Cosmos.Collections;
using Cosmos.Conversions;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> extensions.
    /// </summary>
    public static class CosmosStringExtensions
    {
        #region AvoidNull

        /// <summary>
        /// Avoid null
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string AvoidNull(this string original) => original ?? string.Empty;

        #endregion

        #region Bytes

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null) =>
            value is null
                ? throw new ArgumentNullException(nameof(value))
                : (encoding ?? Encoding.UTF8).GetBytes(value);

        /// <summary>
        /// Convert string to byte array by utf8
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf8Bytes(this string value) => value.ToBytes(Encoding.UTF8);

        /// <summary>
        /// Convert string to byte array by utf7
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf7Bytes(this string value) => value.ToBytes(Encoding.UTF7);

        /// <summary>
        /// Convert string to byte array by utf32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf32Bytes(this string value) => value.ToBytes(Encoding.UTF32);

        /// <summary>
        /// Convert string to byte array by ASCII
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static byte[] ToASCIIBytes(this string value) => value.ToBytes(Encoding.ASCII);

        /// <summary>
        /// Convert string to byte array by BigEndian Unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToBigEndianUnicodeBytes(this string value) => value.ToBytes(Encoding.BigEndianUnicode);

        /// <summary>
        /// Convert string to byte array by default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToDefaultBytes(this string value) => value.ToBytes(Encoding.Default);

        /// <summary>
        /// Convert string to byte array by unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUnicodeBytes(this string value) => value.ToBytes(Encoding.Unicode);

        #endregion

        #region Diff

        /// <summary>
        /// Diff chars' count
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int DiffCharsCount(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);

            var res = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] != toCheck[i])
                    res++;
            }

            return res;
        }

        /// <summary>
        /// Diff chars' count ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int DiffCharsCountIgnoreCase(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);

            var res = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (!text[i].EqualsIgnoreCase(toCheck[i]))
                    res++;
            }

            return res;
        }

        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private static void GuardParameterForDiffOnlyOneChar(string text, string check)
        {
            if (text.Length != check.Length)
                throw new ArgumentException("The parameter for 'DiffOnlyOneChar' must have the same length");
        }

        /// <summary>
        /// Diff only one char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool DiffOnlyOneChar(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);
            return text.DiffCharsCount(toCheck) == 1;
        }

        #endregion

        #region Digits

        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string OnlyDigits(this string text) =>
            text.OnlyDigits(null);

        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="text"></param>
        /// <param name="exceptions"></param>
        /// <returns></returns>
        public static string OnlyDigits(this string text, IEnumerable<char> exceptions)
        {
            var res = new StringBuilder();
            foreach (var car in text)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                if (char.IsDigit(car) || exceptions.Contains(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        /// <summary>
        /// Total digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalDigits(this string text) =>
            text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(char.IsDigit).Length;

        /// <summary>
        /// Contains only digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsOnlyDigits(this string text) =>
            text.All(char.IsDigit);

        /// <summary>
        /// Not Contains Digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool NotContainsDigits(this string text) =>
            text.All(car => !char.IsDigit(car));

        /// <summary>
        /// Contains digit
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsDigit(this string text) =>
            text.Any(char.IsDigit);

        /// <summary>
        /// Include digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IncludeDigits(this string text) =>
            text.IncludeDigits(0);

        /// <summary>
        /// Include digits
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool IncludeDigits(this string text, int minCount)
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsDigit(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }

        #endregion

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

        #region Fill

        /// <summary>
        /// Fill
        /// </summary>
        /// <param name="original"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string Fill(this string original, params object[] values)
        {
            var s = original.Replace("\\n", Environment.NewLine)
                .Replace("<br>", Environment.NewLine)
                .Replace("<BR>", Environment.NewLine);

            return string.Format(s, values);
        }

        #endregion

        #region Filter

        /// <summary>
        /// Filter chars
        /// </summary>
        /// <param name="text"></param>
        /// <param name="onlyThese"></param>
        /// <returns></returns>
        public static string FilterChars(this string text, Predicate<char> onlyThese)
        {
            var res = new StringBuilder(text.Length);

            foreach (var car in text)
            {
                if (onlyThese(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        #endregion

        #region From

        /// <summary>
        /// Convert from base64 <see cref="string"/> to <see cref="byte"/> array.
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static byte[] FromBase64StringToBytes(this string base64String) =>
            Base64Converter.FromBase64StringToBytes(base64String);

        /// <summary>
        /// Convert from base64 <see cref="string"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64String(this string base64String, Encoding encoding = null) =>
            Base64Converter.FromBase64String(base64String, encoding);

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

        #region Letters

        /// <summary>
        /// Total letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalLetters(this string text) =>
            text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(char.IsLetter).Length;

        /// <summary>
        /// Total lower letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalLowerLetters(this string text) =>
            text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsLower(x)).Length;

        /// <summary>
        /// Total upper letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalUpperLetters(this string text) =>
            text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsUpper(x)).Length;

        /// <summary>
        /// Include Letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IncludeLetters(this string text) =>
            text.IncludeLetters(0);

        /// <summary>
        /// Include Letters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool IncludeLetters(this string text, int minCount)
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsLetter(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Only letters numbers
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string OnlyLettersNumbers(this string text)
        {
            var res = new StringBuilder(text.Length);

            foreach (var car in text)
            {
                if (char.IsLetterOrDigit(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        #endregion

        #region Lines

        /// <summary>
        /// Enumerate lines
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        #region Similarity

        /// <summary>
        /// Evaluate Similarity
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="similarityMinimal"></param>
        /// <returns></returns>
        public static double EvaluateSimilarity(this string text, string toCheck, double similarityMinimal)
        {
            const int diffFound = 0;
            return EvaluateSimilarity(text, toCheck, similarityMinimal, diffFound);
        }

        private const int MAX_DIF_TOLERADAS = 2;

        /// <summary>
        /// Evaluate Similarity
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="similarityMinimal"></param>
        /// <param name="diffFound"></param>
        /// <returns></returns>
        public static double EvaluateSimilarity(this string text, string toCheck, double similarityMinimal, int diffFound)
        {
            //if you have too many differences and no longer comparing
            if (diffFound >= MAX_DIF_TOLERADAS)
                return 0.0;

            //ignore spaces
            text = text.RemoveChars(' ');
            toCheck = toCheck.RemoveChars(' ');

            //if they are equal 100%
            if (text.EqualsIgnoreCase(toCheck))
                return 1;

            //ignore remaining text
            var portionText = text;
            var portionToCheck = toCheck;
            if (text.Length != toCheck.Length)
            {
                if (text.Length > toCheck.Length)
                    portionText = text.Substring(0, toCheck.Length);
                else if (toCheck.Length > text.Length)
                    portionToCheck = toCheck.Substring(0, text.Length);
                if (portionText.EqualsIgnoreCase(portionToCheck))
                    return 0.75;
            }

            //evaluate the differences
            var totalDifferences = 0;
            var posDifference = -1;
            for (var i = 0; i < text.Length; i++)
            {
                if (i >= toCheck.Length
                    || text.ToCharArray()[i] != toCheck.ToCharArray()[i])
                    totalDifferences++;
                if (posDifference < 0 && totalDifferences == 1)
                    posDifference = i;
            }

            //but return percentage according to the amount of differences
            var res = Convert.ToDouble(text.Length - totalDifferences) / Convert.ToDouble(text.Length);

            if (totalDifferences <= MAX_DIF_TOLERADAS)
                return res;

            //suppose that only 1 difference was found
            var differences = diffFound + 1;
            //Consider if the dif is a missing character in text2
            var resConCarAwayInText2 = text.Substring(posDifference + 1).EvaluateSimilarity(toCheck.Substring(posDifference), similarityMinimal, differences);
            //Consider if the dif is a missing character in text1
            var resConCarAwayInText1 = text.Substring(posDifference).EvaluateSimilarity(toCheck.Substring(posDifference + 1), similarityMinimal, differences);
            //Consider if the dif is a changed character
            var resConCarCharacter = text.Substring(posDifference + 1).EvaluateSimilarity(toCheck.Substring(posDifference + 1), similarityMinimal, differences);
            //If any of the 3 is valid, calculate similarity as
            //  simParte1 + max(simParte2) - 0.1 / 2
            if (resConCarAwayInText2 > similarityMinimal || resConCarAwayInText1 > similarityMinimal || resConCarCharacter > similarityMinimal)
                return (1.0 + Math.Max(resConCarAwayInText2, Math.Max(resConCarAwayInText1, resConCarCharacter)) - 0.10) / 2.0;
            return res;
        }

        /// <summary>
        /// Evaluate Type Similarity
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static StringTypeSimilarity EvaluateTypeSimilarity(this string text, string toCheck)
        {
            //ignore spaces
            text = text.RemoveChars(' ');
            toCheck = toCheck.RemoveChars(' ');

            //if they are equal 100%
            if (text.EqualsIgnoreCase(toCheck))
                return StringTypeSimilarity.Same;

            //ignore remaining text
            var portionText = text;
            var portionToCheck = toCheck;
            if (text.Length != toCheck.Length)
            {
                if (text.Length > toCheck.Length)
                    portionText = text.Substring(0, toCheck.Length);
                else if (toCheck.Length > text.Length)
                    portionToCheck = toCheck.Substring(0, text.Length);
                if (portionText.EqualsIgnoreCase(portionToCheck))
                    return (text.Length > toCheck.Length ? StringTypeSimilarity.MayorLong : StringTypeSimilarity.MinorLong);
            }

            return StringTypeSimilarity.Any;
        }

        #endregion

        #region To

        /// <summary>
        /// To valid identifier
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToValidIdentifier(this string original)
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