using System.Collections.Generic;

namespace Cosmos.Text
{
    public static class StringLinesExtensions
    {
        /// <summary>
        /// Line count
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int LineCount(this string text)
        {
            return StringLines.Count(text);
        }

        /// <summary>
        /// To lines
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<string> ToLines(this string text)
        {
            return StringLines.AsLines(text);
        }
    }
}