// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
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

        public static string SecondWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var parts = me.SplitInWords();
            return parts.Length >= 2 ? parts[1] : string.Empty;
        }

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
