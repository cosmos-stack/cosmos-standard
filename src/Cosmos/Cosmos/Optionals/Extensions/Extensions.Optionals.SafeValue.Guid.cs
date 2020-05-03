using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals {
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static partial class OptionalsExtensions {
        /// <summary>
        /// Return a safe <see cref="Guid"/> value.<br />
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static Guid? SafeGuid(this object @object) => @object as Guid?;

        /// <summary>
        /// Return a safe <see cref="Guid"/> value.<br />
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid SafeGuid(this object @object, Guid defaultValue) => @object.SafeGuid().SafeValue(defaultValue);
    }
}