// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Truncate
        /// </summary>
        /// <param name="original"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string original, int maxLength)
        {
            if (original.IsNullOrEmpty() || maxLength == 0)
                return string.Empty;
            if (original.Length <= maxLength)
                return original;
            if (maxLength <= 3)
                return original.Substring(0, 2) + ".";
            return original.Substring(0, maxLength - 3) + "...";
        }
    }
}
