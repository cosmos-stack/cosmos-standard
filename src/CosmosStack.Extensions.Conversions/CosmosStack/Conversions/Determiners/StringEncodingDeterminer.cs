using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CosmosStack.Conversions.Common;

namespace CosmosStack.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to encoding
    /// </summary>
    public static class StringEncodingDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            Action<Encoding> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            bool result;
            Encoding encoding;
            if (string.Equals("ANSI", text, StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                encoding = Encoding.Default;
            }
            else
            {
                var encodingInfo = Encoding.GetEncodings().FirstOrDefault(info => string.Compare(info.Name, text, StringComparison.CurrentCultureIgnoreCase) == 0);

                if (encodingInfo is null)
                {
                    encoding = Encoding.Default;
                    result = false;
                }
                else
                {
                    encoding = encodingInfo.GetEncoding();
                    result = true;
                }
            }

            if (result)
            {
                matchedCallback?.Invoke(encoding);
            }

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tries"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text, 
            IEnumerable<IConversionTry<string, Encoding>> tries,
            Action<Encoding> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, Is, tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Encoding To(
            string text, 
            Encoding defaultVal = null)
        {
            Encoding result = null;
            return Is(text, encoding => result = encoding)
                ? result
                : defaultVal.SafeValue(Encoding.Default);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Encoding To(
            string text, 
            IEnumerable<IConversionImpl<string, Encoding>> impls)
        {
            return ValueConverter.ToXxx(text, Is, impls);
        }

        private static Encoding SafeValue(this Encoding encoding, Encoding @default) =>
            encoding ?? @default ?? Encoding.UTF8;
    }
}