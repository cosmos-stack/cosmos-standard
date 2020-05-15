using System;
using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions {
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions {
        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str) => GuidConv.StringToGuid(str);

        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str, Guid defaultVal) => GuidConv.StringToGuid(str, defaultVal);

        /// <summary>
        /// To nullable GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? CastToNullableGuid(this string str) => GuidConv.StringToNullableGuid(str);
    }
}