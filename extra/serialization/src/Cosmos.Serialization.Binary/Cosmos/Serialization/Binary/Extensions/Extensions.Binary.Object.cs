using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Binary {
    /// <summary>
    /// Binary extensions
    /// </summary>
    public static partial class BinaryExtensions {
        /// <summary>
        /// To bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this object obj) => BinaryHelper.Serialize(obj);

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stream Pack(this object obj) => BinaryHelper.Pack(obj);

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void PackTo(this object obj, Stream stream) => BinaryHelper.Pack(obj, stream);

        /// <summary>
        /// To bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<byte[]> ToBytesAsync(this object obj) => BinaryHelper.SerializeAsync(obj);

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<Stream> PackAsync(this object obj) => BinaryHelper.PackAsync(obj);

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static Task PackToAsync(this object obj, Stream stream) => BinaryHelper.PackAsync(obj, stream);
    }
}