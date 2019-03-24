// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static bool DiffOnlyOneChar(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);
            return text.DiffCharsCount(toCheck) == 1;
        }
    }
}
