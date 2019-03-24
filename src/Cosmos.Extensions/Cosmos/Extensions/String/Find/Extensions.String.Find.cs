using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        public static string FindFirstPhrase(this string text, params string[] phrasesToCheck)
        {
            GuardParameter(phrasesToCheck, nameof(phrasesToCheck));
            return phrasesToCheck.FirstOrDefault(text.ContainsWholePhrase);
        }

        public static string FindFirstOccurrence(this string text, params string[] toCheck)
        {
            GuardParameter(toCheck, nameof(toCheck));
            return toCheck.FirstOrDefault(text.ContainsIgnoreCase);
        }

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

        private static void GuardParameter<T>(T[] target, string nameOfT)
        {
            if (target == null || target.Length == 0)
                throw new ArgumentException($"Parameter '{nameOfT}' cannot be null or empty.", nameOfT);
        }
    }
}
