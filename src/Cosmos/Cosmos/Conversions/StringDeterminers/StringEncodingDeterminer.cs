using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Optionals;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to encoding
    /// </summary>
    public static class StringEncodingDeterminer {

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encodingAction"></param>
        /// <returns></returns>
        public static bool Is(string str, Action<Encoding> encodingAction = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            bool result;
            Encoding encoding;

            if (string.Equals("ANSI", str, StringComparison.OrdinalIgnoreCase)) {
                result = true;
                encoding = Encoding.Default;
            } else {
                var encodingInfo = Encoding.GetEncodings().FirstOrDefault(info => string.Compare(info.Name, str, StringComparison.CurrentCultureIgnoreCase) == 0);

                if (encodingInfo is null) {
                    encoding = Encoding.Default;
                    result = false;
                } else {
                    encoding = encodingInfo.GetEncoding();
                    result = true;
                }
            }

            if (result) {
                encodingAction?.Invoke(encoding);
            }

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="encodingAction"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, Encoding>> tries, Action<Encoding> encodingAction = null) =>
            _Helper.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, encodingAction);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Encoding To(string str, Encoding defaultVal = null) {
            Encoding result = null;
            return Is(str, encoding => result = encoding) ? result : defaultVal.SafeValue(Encoding.Default);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Encoding To(string str, IEnumerable<IConversionImpl<string, Encoding>> impls) =>
            _Helper.ToXXX(str, Is, impls);
    }
}