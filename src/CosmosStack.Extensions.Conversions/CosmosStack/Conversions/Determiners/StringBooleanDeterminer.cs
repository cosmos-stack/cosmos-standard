using System;
using System.Collections.Generic;
using CosmosStack.Conversions.Common;
using CosmosStack.Verba.Boolean;

namespace CosmosStack.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to boolean
    /// </summary>
    public static class StringBooleanDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text, 
            Action<bool> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            
            return bool.TryParse(text, out var boolean)
                       .Or(() => GlobalBooleanVerbaManager.MayBeDetermined(text))
                       .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<bool>, text)
                       .IfTrueThenInvoke(matchedCallback, boolean);
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
            IEnumerable<IConversionTry<string, bool>> tries,
            Action<bool> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, Is, tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static bool To(
            string text,
            bool defaultVal = default)
        {
            if (string.IsNullOrWhiteSpace(text))
                return defaultVal;
            return bool.TryParse(text, out var boolean)
                ? boolean
                : GlobalBooleanVerbaManager.TryDetermining(text, out boolean)
                    ? boolean
                    : ValueConverter.ToXxxAgain(text, defaultVal);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static bool To(
            string text, 
            IEnumerable<IConversionImpl<string, bool>> impls)
        {
            return ValueConverter.ToXxx(text, Is, impls);
        }
    }
}