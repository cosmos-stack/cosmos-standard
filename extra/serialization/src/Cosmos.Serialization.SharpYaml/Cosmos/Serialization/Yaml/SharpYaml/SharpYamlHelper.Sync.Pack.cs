using System;
using System.IO;
using Cosmos.IO;

namespace Cosmos.Serialization.Yaml.SharpYaml {
    /// <summary>
    /// SharpYaml helper
    /// </summary>
    public static partial class SharpYamlHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            Pack(o, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream Pack(object o, Type type) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            Pack(o, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T o, Stream stream) {
            if (o == null || !stream.CanWrite)
                return;

            var bytes = SerializeToBytes(o);

            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        public static void Pack(object o, Type type, Stream stream) {
            if (o == null || !stream.CanWrite)
                return;

            var bytes = SerializeToBytes(o, type);

            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream) {
            return stream == null
                ? default
                : DeserializeFromBytes<T>(stream.StreamToBytes());
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type) {
            return stream == null
                ? null
                : DeserializeFromBytes(stream.StreamToBytes(), type);
        }
    }
}