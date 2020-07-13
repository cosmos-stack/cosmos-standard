using System;
using System.Linq;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="text"></param>
        public static bool ContainsChinese(string text) =>
            StringJudgment.ContainsChineseCharacters(text);

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsNumber(string text) =>
            StringJudgment.ContainsNumber(text);

        /// <summary>
        /// Contains ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException($" The value of '{nameof(toCheck)}' cannot be null or empty.");
            return text.IndexOfIgnoreCase(toCheck) >= 0;
        }

        /// <summary>
        /// Contains whole word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsWholeWord(this string text, string toCheck)
        {
            if (text.IsNullOrEmpty())
                return false;
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toChek' es vacio");
            return text.SplitInWords().Any(p => p.EqualsIgnoreCase(toCheck));
        }

        /// <summary>
        /// Contains ant whole word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsAnyWholeWord(this string text, params string[] toCheck)
        {
            if (text.IsNullOrEmpty())
                return false;
            if (toCheck is null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");
            return text.SplitInWords().Any(p => toCheck.Any(p.EqualsIgnoreCase));
        }

        /// <summary>
        /// Contains whole phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsWholePhrase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toChek' es vacio");

            var startIndex = 0;
            while (startIndex <= text.Length)
            {
                var index = text.IndexOfIgnoreCase(startIndex, toCheck);
                if (index < 0)
                    return false;

                var indexPreviousCar = index - 1;
                var indexNextCar = index + toCheck.Length;
                if ((index == 0 || !char.IsLetter(text[indexPreviousCar])) &&
                    (index + toCheck.Length == text.Length || !char.IsLetter(text[indexNextCar])))
                    return true;

                startIndex = index + toCheck.Length;
            }

            return false;
        }

        /// <summary>
        /// Contains whole phrase any
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsWholePhraseAny(this string text, params string[] toCheck) =>
            toCheck.Any(text.ContainsWholePhrase);

        /// <summary>
        /// Contains whole phrase all
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsWholePhraseAll(this string text, params string[] toCheck) =>
            toCheck.All(text.ContainsWholePhrase);

        /// <summary>
        /// Contains any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsAnyIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck is null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");
            return toCheck.Any(checking => text.IndexOfIgnoreCase(checking) >= 0);
        }

        /// <summary>
        /// Contains all ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsAllIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");
            return toCheck.All(checking => text.IndexOfIgnoreCase(checking) >= 0);
        }

        /// <summary>
        /// Contains onle this char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool ContainsOnlyThisChar(this string text, char toCheck) =>
            text.Length != 0 && text.All(t => t == toCheck);
    }
}