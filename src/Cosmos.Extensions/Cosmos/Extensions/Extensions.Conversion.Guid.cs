using System;
using Cosmos.Optionals;

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
            => Conversions.GuidConverter.ToGuid(str);

        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str, Guid defaultVal)
            => Conversions.GuidConverter.ToNullableGuid(str).SafeValue(defaultVal);

        /// <summary>
        /// To nullable GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? CastToNullableGuid(this string str)
            => Conversions.GuidConverter.ToNullableGuid(str);
    }
}