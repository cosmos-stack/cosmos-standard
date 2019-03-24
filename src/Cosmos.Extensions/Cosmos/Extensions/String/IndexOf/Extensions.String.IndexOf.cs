using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
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

        public static int IndexOfIgnoreCase(this string text, string toCheck)
        {
            return text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static int LastIndexOfIgnoreCase(this string text, string toCheck)
        {
            return text.LastIndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static int LastIndexOfIgnoreCase(this string text, string toCheck, int startIndex, int count)
        {
            return text.LastIndexOf(toCheck, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        public static int IndexOfIgnoreCase(this string text, int startIndex, string toCheck)
        {
            return text.IndexOf(toCheck, startIndex, StringComparison.OrdinalIgnoreCase);
        }

        public static int LastIndexOfAny(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
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

    }
}
