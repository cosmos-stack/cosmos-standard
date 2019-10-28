using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ProtoBuf
{
    /// <summary>
    /// ProtoBuf extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To ProtoBuf
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToProtoBytes(this object obj)
        {
            return ProtobufHelper.Serialize(obj);
        }

        /// <summary>
        /// To ProtoBuf async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<byte[]> ToProtoBytesAsync(this object obj)
        {
            return ProtobufHelper.SerializeAsync(obj);
        }
    }
}