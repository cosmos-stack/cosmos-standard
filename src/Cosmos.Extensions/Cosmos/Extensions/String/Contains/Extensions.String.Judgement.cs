using System;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="text"></param>
        public static bool ContainsChinese(string text) => StringJudgment.ContainsChineseCharacters(text);

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsNumber(string text) => StringJudgment.ContainsNumber(text);

        public static bool ContainsIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException($" The value of '{nameof(toCheck)}' cannot be null or empty.");
            return text.IndexOfIgnoreCase(toCheck) >= 0;
        }

        public static bool ContainsWholeWord(this string text, string toCheck)
        {
            if (text.IsNullOrEmpty())
                return false;

            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toChek' es vacio");

            var partes = text.SplitInWords();
            foreach (var parte in partes)
            {
                if (parte.EqualsIgnoreCase(toCheck))
                    return true;
            }
            return false;
        }

        public static bool ContainsAnyWholeWord(this string text, params string[] toCheck)
        {
            if (text.IsNullOrEmpty())
                return false;

            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");

            var partes = text.SplitInWords();
            foreach (var parte in partes)
            {
                foreach (var check in toCheck)
                {
                    if (parte.EqualsIgnoreCase(check))
                        return true;
                }
            }
            return false;
        }

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
                if ((index == 0
                     || !Char.IsLetter(text[indexPreviousCar]))
                    && (index + toCheck.Length == text.Length
                        || !Char.IsLetter(text[indexNextCar])))
                    return true;

                startIndex = index + toCheck.Length;
            }
            return false;
        }

        public static bool ContainsWholePhraseAny(this string text, params string[] toCheck)
        {
            foreach (var phrase in toCheck)
            {
                if (text.ContainsWholePhrase(phrase)) return true;
            }
            return false;
        }

        public static bool ContainsWholePhraseAll(this string text, params string[] toCheck)
        {
            foreach (var phrase in toCheck)
            {
                if (!text.ContainsWholePhrase(phrase)) return false;
            }
            return true;
        }

        public static bool ContainsAnyIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");

            foreach (var checking in toCheck)
            {
                if (text.IndexOfIgnoreCase(checking) >= 0) return true;
            }
            return false;
        }

        public static bool ContainsAllIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");

            foreach (var checking in toCheck)
            {
                if (text.IndexOfIgnoreCase(checking) < 0) return false;
            }
            return true;
        }

        public static bool ContainsOnlyThisChar(this string text, char toCheck)
        {
            if (text.Length == 0)
                return false;

            foreach (var t in text)
            {
                if (t != toCheck) return false;
            }
            return true;
        }
    }
}
