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
        public static Guid ToGuid(object obj, Guid defaultVal = default)
        {
            return GuidConvX.ObjToGuid(obj, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="Object"/> to nullable <see cref="Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj)
        {
            return GuidConvX.ObjToNullableGuid(obj);
        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid ToGuid(string text, Guid defaultVal = default)
        {
            return GuidConvX.StringToGuid(text, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="Guid"/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(string text)
        {
            return GuidConvX.StringToNullableGuid(text);
        }
    }
}