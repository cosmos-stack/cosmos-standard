using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals
{
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static partial class OptionalsExtensions
    {
        /// <summary>
        /// Return a safe <see cref="DateTime"/> value.<br />
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static DateTime? SafeDateTime(this object @object)
        {
            if (@object is DateTime dateTime)
                return dateTime;
            return null;
        }

        /// <summary>
        /// Return a safe <see cref="DateTime"/> value.<br />
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime SafeDateTime(this object @object, DateTime defaultValue) =>
            @object.SafeDateTime().SafeValue(defaultValue);
    }
}