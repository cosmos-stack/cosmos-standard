using System;
using System.IO;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Byte extensions
    /// </summary>
    public static class ByteExtensions
    {
        #region Min & Max

        /// <summary>
        /// Gets max one.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static byte Max(this byte val1, byte val2) => Math.Max(val1, val2);

        /// <summary>
        /// Gets min one.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static byte Min(this byte val1, byte val2) => Math.Min(val1, val2);

        #endregion

        #region Resize

        /// <summary>
        /// Resize
        /// </summary>
        /// <param name="this"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public static byte[] Resize(this byte[] @this, int newSize)
        {
            Array.Resize(ref @this, newSize);
            return @this;
        }

        #endregion

        #region To MemoryStream

        /// <summary>
        /// Convert byte[] to <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] @this)
        {
            return new MemoryStream(@this);
        }

        #endregion
    }
}