using System;
using System.Runtime.CompilerServices;
using CosmosStack.Conversions.Common.Core;

namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Guid Convertor <br />
    /// GUID 转换器
    /// </summary>
    public static class GuidConv
    {
        /// <summary>
        /// Convert <see cref="object"/> to <see cref="Guid"/> <br />
        /// 将对象转换为 GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid ToGuid(object obj, Guid defaultVal = default)
        {
            return GuidConvX.ObjToGuid(obj, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="Object"/> to nullable <see cref="Guid"/> <br />
        /// 将对象转换为可空 GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid? ToNullableGuid(object obj)
        {
            return GuidConvX.ObjToNullableGuid(obj);
        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Guid"/> <br />
        /// 将字符串转换为 GUID
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid ToGuid(string text, Guid defaultVal = default)
        {
            return GuidConvX.StringToGuid(text, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="Guid"/> <br />
        /// 将字符串转换为可空 GUID
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid? ToNullableGuid(string text)
        {
            return GuidConvX.StringToNullableGuid(text);
        }
    }
}