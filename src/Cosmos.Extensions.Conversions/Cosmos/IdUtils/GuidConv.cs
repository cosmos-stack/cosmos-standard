using System;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.IdUtils
{
    /// <summary>
    /// Guid converter
    /// </summary>
    public static class GuidConv
    {
        /// <summary>
        /// Convert <see cref="object"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj, Guid defaultVal = default) => GuidConvX.ObjToGuid(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="Object"/> to nullable <see cref="Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj) => GuidConvX.ObjToNullableGuid(obj);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid ToGuid(string str, Guid defaultVal = default) => GuidConvX.StringToGuid(str, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="Guid"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(string str) => GuidConvX.StringToNullableGuid(str);
    }
}