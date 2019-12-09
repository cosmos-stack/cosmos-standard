using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ProtoBuf {
    /// <summary>
    /// ProtoBuf extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To ProtoBuf stream
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stream ToProtoStream(this object obj) => ProtobufHelper.Pack(obj);

        /// <summary>
        /// To ProtoBuf stream async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<Stream> ToStreamAsync(this object obj) => await ProtobufHelper.PackAsync(obj);
    }
}