using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// SubString
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startText"></param>
        /// <returns></returns>
        public static string Substring(this string text, string startText)
        {
            var index = text.IndexOf(startText, StringComparison.Ordinal);
            if (index == -1)
                throw new ArgumentException($"Not found: '{startText}'.");
            return text.Substring(index);
        }

        /// <summary>
        /// SubString from...
        /// </summary>
        /// <param name="me"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string SubstringFrom(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : me.Substring(index + @from.Length);
        }

        /// <summary>
        /// SubString to...
        /// </summary>
        /// <param name="me"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string SubstringTo(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return string.Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? string.Empty : me.Substring(0, index);
        }
    }
}