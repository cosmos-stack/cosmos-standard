using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        public static string Substring(this string text, string startText)
        {
            var index = text.IndexOf(startText, StringComparison.Ordinal);
            if (index == -1)
                throw new ArgumentException($"Not found: '{startText}'.");
            return text.Substring(index);
        }

        public static string SubstringFrom(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : me.Substring(index + @from.Length);
        }

        public static string SubstringTo(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : me.Substring(0, index);
        }

    }
}
