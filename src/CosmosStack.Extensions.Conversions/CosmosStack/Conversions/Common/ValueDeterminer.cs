using System;
using System.Collections.Generic;
using CosmosStack.Conversions.Common.Core;

// ReSharper disable InconsistentNaming

namespace CosmosStack.Conversions.Common
{
    internal static class ValueDeterminer
    {
        /// <summary>
        /// Is xxx
        /// </summary>
        /// <param name="from"></param>
        /// <param name="fromTry"></param>
        /// <param name="firstTry"></param>
        /// <param name="tries"></param>
        /// <param name="act"></param>
        /// <typeparam name="O"></typeparam>
        /// <typeparam name="X"></typeparam>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static bool IsXXX<O, X>(
            O from,
            Func<O, bool> fromTry,
            Func<O, Action<X>, bool> firstTry,
            IEnumerable<IConversionTry<O, X>> tries,
            Action<X> act = null)
        {
            if (fromTry(from))
                return false;
            if (firstTry(from, act))
                return true;
            if (tries is null)
                return false;
            foreach (var @try in tries)
            {
                if (!@try.Is(@from, out var to))
                    continue;

                act?.Invoke(to);
                return true;
            }

            return false;
        }

        public static bool IsXxxAgain<X>(string str)
        {
            return XConvHelper.I(() => Convert.ChangeType(str, typeof(X)));
        }
    }
}