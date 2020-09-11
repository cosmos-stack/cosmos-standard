using System;
using System.Collections.Generic;

namespace Cosmos.Text
{
    public static class StringLines
    {
        /// <summary>
        /// Count lines
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int Count(string s)
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

        /// <summary>
        /// Enumerate lines
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<string> AsLines(string text)
        {
            var index = 0;

            while (true)
            {
                var newIndex = text.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
                if (newIndex < 0)
                {
                    if (text.Length > index)
                        yield return text.Substring(index);

                    yield break;
                }

                var currentString = text.Substring(index, newIndex - index);
                index = newIndex + 2;

                yield return currentString;
            }
        }
    }
}