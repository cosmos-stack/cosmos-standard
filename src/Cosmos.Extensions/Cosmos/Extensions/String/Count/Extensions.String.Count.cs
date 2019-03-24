using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static int CountLines(this string s)
        {
            int index = 0, lines = 0;

            while (true)
            {
                var newIndex = s.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
                if (newIndex < 0)
                {
                    if (s.Length > index)
                        lines++;

                    return lines;
                }

                index = newIndex + 2;
                lines++;
            }
        }

        public static int CountOccurrences(this string text, char toCheck)
        {
            return text.CountOccurrences(toCheck.ToString());
        }

        public static int CountOccurrences(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return 0;

            int res = 0, posIni = 0;
            while ((posIni = text.IndexOfIgnoreCase(posIni, toCheck)) != -1)
            {
                posIni += toCheck.Length;
                res++;
            }

            return res;
        }
    }
}
