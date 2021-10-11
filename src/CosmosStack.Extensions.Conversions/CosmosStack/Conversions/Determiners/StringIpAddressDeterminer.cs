using System;
using System.Collections.Generic;
using System.Net;
using CosmosStack.Conversions.Common;

namespace CosmosStack.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to IpAddress
    /// </summary>
    public static class StringIpAddressDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            Action<IPAddress> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return IPAddress.TryParse(text, out var address)
                            .IfTrueThenInvoke(matchedCallback, address);
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
            IEnumerable<IConversionTry<string, IPAddress>> tries,
            Action<IPAddress> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, Is, tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static IPAddress To(
            string text,
            IPAddress defaultVal = default)
        {
            if (string.IsNullOrWhiteSpace(text))
                return defaultVal;
            
            return IPAddress.TryParse(text, out var address) ? address : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static IPAddress To(
            string text,
            IEnumerable<IConversionImpl<string, IPAddress>> impls)
        {
            return ValueConverter.ToXxx(text, Is, impls);
        }
    }
}