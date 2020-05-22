using System;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Guid converter
    /// </summary>
    public static class GuidConverter
    {
        /// <summary>
        /// Convert <see cref="object"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj, Guid defaultVal = default) => GuidConv.ObjToGuid(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="Object"/> to nullable <see cref="Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj) => GuidConv.ObjToNullableGuid(obj);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid ToGuid(string str, Guid defaultVal = default) => GuidConv.StringToGuid(str, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="Guid"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(string str) => GuidConv.StringToNullableGuid(str);
    }
}