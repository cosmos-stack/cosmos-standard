// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Diff only one char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool DiffOnlyOneChar(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);
            return text.DiffCharsCount(toCheck) == 1;
        }
    }
}
