namespace System {
    /// <summary>
    /// Base Type Extensions
    /// </summary>
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// Block copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcOffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstOffset"></param>
        /// <param name="count"></param>
        public static void BlockCopy(this Array src, int srcOffset, Array dst, int dstOffset, int count) {
            Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count);
        }

        /// <summary>
        /// Gets length of byte.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int ByteLength(this Array array) {
            return Buffer.ByteLength(array);
        }

        /// <summary>
        /// Gets byte
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte GetByte(this Array array, int index) {
            return Buffer.GetByte(array, index);
        }

        /// <summary>
        /// Sets byte
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void SetByte(this Array array, int index, byte value) {
            Buffer.SetByte(array, index, value);
        }
    }
}