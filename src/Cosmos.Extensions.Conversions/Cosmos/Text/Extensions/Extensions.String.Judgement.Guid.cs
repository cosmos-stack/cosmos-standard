using Cosmos.Conversions.Determiners;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StingJudgementExtensions
    {
        /// <summary>
        /// Is Guid
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsGuid(this string str) => StringGuidDeterminer.Is(str) && GuidJudgment.IsValid(str);

        /// <summary>
        /// Is Guid
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsGuidExact(this string str, string format) => StringGuidDeterminer.Exact.Is(str, format);
    }
}