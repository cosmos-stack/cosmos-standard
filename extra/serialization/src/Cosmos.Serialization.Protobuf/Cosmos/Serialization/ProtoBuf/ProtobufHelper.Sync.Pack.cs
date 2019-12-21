using System;
using System.IO;

namespace Cosmos.Serialization.ProtoBuf {
    /// <summary>
    /// Google protobuf helper
    /// </summary>
    public static partial class ProtobufHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stream Pack(object obj) {
            var ms = new MemoryStream();

            if (obj != null)
                Pack(obj, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void Pack(object obj, Stream stream) {
            if (obj != null) {
                ProtoBufManager.Model.Serialize(stream, obj);
            }
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream) {
            if (stream is null || stream.Length == 0)
                return default;

            var type = typeof(T);
            return (T) Unpack(stream, type);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type) {
            if (stream is null || stream.Length == 0)
                return default;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return ProtoBufManager.Model.Deserialize(stream, null, type);
        }
    }
}