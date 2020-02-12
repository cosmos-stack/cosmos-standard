using Cosmos.Conversions.StringDeterminers;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
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