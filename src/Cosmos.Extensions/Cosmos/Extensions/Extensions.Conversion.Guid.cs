using System;
using Cosmos.Conversions.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {

        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str)
            => Conversions.GuidConversion.ToGuid(str);

        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str, Guid defaultVal)
            => Conversions.GuidConversion.ToNullableGuid(str).SafeValue(defaultVal);

        /// <summary>
        /// To nullable GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? CastToNullableGuid(this string str)
            => Conversions.GuidConversion.ToNullableGuid(str);
    }
}