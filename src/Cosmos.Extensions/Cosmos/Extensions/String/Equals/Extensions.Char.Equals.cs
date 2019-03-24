using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string text, string toCheck)
        {
            return string.Equals(text, toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EqualsToAnyIgnoreCase(this string text, params string[] toCheck)
        {
            return toCheck != null && toCheck.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));
        }
    }
}
