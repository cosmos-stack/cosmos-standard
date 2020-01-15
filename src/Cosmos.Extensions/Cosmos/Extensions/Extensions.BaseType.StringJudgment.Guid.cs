using Cosmos.Conversions.Internals;
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
        public static bool IsGuid(this string str) => StringGuidHelper.Is(str) && GuidJudgment.IsValid(str);

        /// <summary>
        /// Is Guid
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsGuidExact(this string str, string format) => StringGuidExactHelper.Is(str, format);
    }
}