using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// 根据给定的 splitCode 对字符串进行切割
        /// </summary>
        /// <param name="string"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string[] Split(this string @string, string separator) => Regex.Split(@string, separator);

        private static readonly Regex mSplitWords = new Regex(@"\W+");

        public static string[] SplitInWords(this string s)
        {

            //
            // Split on all non-word characters.
            // ... Returns an array of all the words.
            //
            return mSplitWords.Split(s);
            // @      special verbatim string syntax
            // \W+    one or more non-word characters together
        }

        public static List<string> SplitInWordsLongerThan(this string s, int wordlength)
        {
            var res = new List<string>();
            var splitwords = mSplitWords.Split(s);

            foreach (var word in splitwords)
            {
                if (word.Length > wordlength)
                {
                    res.Add(word);
                }
            }

            return res;
        }

        public static string[] SplitInLines(this string s)
        {
            return s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static T[] SplitInLinesTyped<T>(this string s) where T : IComparable
        {
            return SplitTyped<T>(s, Environment.NewLine);
        }

        public static string[] SplitInLinesRemoveEmptys(this string s)
        {
            return s.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static Tuple<string, string> SplitByIndex(this string text, int index)
        {
            if (text.IsNullOrEmpty())
                return new Tuple<string, string>("", "");

            if (index >= text.Length)
                return new Tuple<string, string>(text, "");

            if (index <= 0)
                return new Tuple<string, string>("", text);

            return new Tuple<string, string>(text.Substring(0, index - 1), text.Substring(index - 1));
        }

        public static Tuple<string, string> SplitWordsByIndex(this string text, int index)
        {
            var splitByIndex = text.SplitByIndex(index);
            var res = new Tuple<string, string>(splitByIndex.Item1, splitByIndex.Item2);

            var wordsInItem1 = res.Item1.SplitInWords();
            res = new Tuple<string, string>(wordsInItem1.Take(wordsInItem1.Length - 1).JoinToString(" ").Trim(), wordsInItem1.Last() + splitByIndex.Item2);

            return res;
        }

        public static T[] SplitTyped<T>(this string me, char delimiter) where T : IComparable
        {
            if (me.IsNullOrWhiteSpace())
                return new T[] { };

            me = me.Trim();

            var parts = me.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var res = new T[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                res[i] = (T)Convert.ChangeType(parts[i], typeof(T));
            }
            return res;
        }

        public static T[] SplitTyped<T>(this string me, string delimiter) where T : IComparable
        {
            if (me.IsNullOrWhiteSpace())
                return new T[] { };

            me = me.Trim();

            var parts = me.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var res = new T[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                res[i] = (T)Convert.ChangeType(parts[i], typeof(T));
            }
            return res;
        }
    }
}
