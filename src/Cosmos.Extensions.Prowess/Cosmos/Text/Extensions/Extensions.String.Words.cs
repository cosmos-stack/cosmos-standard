// ReSharper disable once CheckNamespace

namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Total words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalWords(this string text)
        {
            text = text.Trim();

            if (text.IsNullOrEmpty())
                return 0;

            var res = 0;

            var prevCharIsSeparator = true;
            foreach (var c in text)
            {
                if (char.IsSeparator(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c))
                {
                    if (!prevCharIsSeparator)
                        res++;
                    prevCharIsSeparator = true;
                }
                else
                    prevCharIsSeparator = false;
            }

            if (!prevCharIsSeparator)
                res++;

            return res;
        }

        /// <summary>
        /// Last word
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string LastWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            for (var i = me.Length - 1; i >= 0; i--)
            {
                if (char.IsSeparator(me, i))
                {
                    return i == me.Length - 1 ? string.Empty : me.Substring(i + 1);
                }
            }

            return me;
        }

        /// <summary>
        /// Second word
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string SecondWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var parts = me.SplitInWords();
            return parts.Length >= 2 ? parts[1] : string.Empty;
        }

        /// <summary>
        /// First word
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string FirstWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            for (var i = 0; i < me.Length; i++)
            {
                if (char.IsSeparator(me, i))
                {
                    return i == 0 ? string.Empty : me.Substring(0, i);
                }
            }

            return me;
        }
    }
}