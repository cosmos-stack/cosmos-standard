using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Find first phrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrasesToCheck"></param>
        /// <returns></returns>
        public static string FindFirstPhrase(this string text, params string[] phrasesToCheck)
        {
            GuardParameter(phrasesToCheck, nameof(phrasesToCheck));
            return phrasesToCheck.FirstOrDefault(text.ContainsWholePhrase);
        }

        /// <summary>
        /// Find first occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static string FindFirstOccurrence(this string text, params string[] toCheck)
        {
            GuardParameter(toCheck, nameof(toCheck));
            return toCheck.FirstOrDefault(text.ContainsIgnoreCase);
        }

        /// <summary>
        /// Find and replace first occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newValue"></param>
        /// <param name="oldValues"></param>
        /// <returns></returns>
        public static string FindAndReplaceFirstOccurrence(this string text, string newValue, params string[] oldValues)
        {
            GuardParameter(oldValues, nameof(oldValues));

            foreach (var oldValue in oldValues)
            {
                if (text.ContainsIgnoreCase(oldValue))
                    return text.ReplaceIgnoringCase(oldValue, newValue);
            }

            return text;
        }

        /// <summary>
        /// Find and insert before first occurrence
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textInsert"></param>
        /// <param name="oldValues"></param>
        /// <returns></returns>
        public static string FindAndInsertBeforeFirstOccurrence(this string text, string textInsert, params string[] oldValues)
        {
            GuardParameter(oldValues, nameof(oldValues));

            foreach (var oldValue in oldValues)
            {
                if (text.ContainsIgnoreCase(oldValue))
                    return text.ReplaceIgnoringCase(oldValue, textInsert + oldValue);
            }

            return text;
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private static void GuardParameter<T>(T[] target, string nameOfT)
        {
            if (target is null || target.Length == 0)
                throw new ArgumentException($"Parameter '{nameOfT}' cannot be null or empty.", nameOfT);
        }
    }
}