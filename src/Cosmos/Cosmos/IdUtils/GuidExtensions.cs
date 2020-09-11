using System;

namespace Cosmos.IdUtils
{
    /// <summary>
    /// Guid extensions
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="guid"> 值 </param>
        public static bool IsNullOrEmpty(this Guid? guid) => guid is null || IsNullOrEmpty(guid.Value);

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="guid"> 值 </param>
        public static bool IsNullOrEmpty(this Guid guid) => guid == Guid.Empty;
    }
}