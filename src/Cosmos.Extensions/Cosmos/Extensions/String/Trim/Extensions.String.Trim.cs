using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class StringExtensions {
        /// <summary>
        /// Trim all
        /// </summary>
        /// <param name="texts"></param>
        public static void TrimAll(this IList<string> texts) {
            for (var i = 0; i < texts.Count; i++) {
                texts[i] = texts[i].Trim();
            }
        }

        /// <summary>
        /// Trim phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimPhrase(this string text, string phrase) {
            var res = TrimPhraseStart(text, phrase);
            res = TrimPhraseEnd(res, phrase);
            return res;
        }

        /// <summary>
        /// Trim phrase start
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimPhraseStart(this string text, string phrase) {
            if (text.IsNullOrEmpty())
                return string.Empty;

            if (phrase.IsNullOrEmpty())
                return text;

            while (text.StartsWith(phrase)) {
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
        public static string TrimPhraseEnd(this string text, string phrase) {
            if (text.IsNullOrEmpty())
                return string.Empty;

            if (phrase.IsNullOrEmpty())
                return text;

            while (text.EndsWithIgnoreCase(phrase)) {
                text = text.Substring(0, text.Length - phrase.Length);
            }

            return text;
        }
    }
}