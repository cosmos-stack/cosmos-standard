using System;
using System.IO;
using System.Xml.Serialization;

namespace Cosmos.Serialization.Xml {
    /// <summary>
    /// Xml Helper
    /// </summary>
    public static partial class XmlHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o) {
            return Pack(o, typeof(T));
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T o, Stream stream) {
            Pack(o, typeof(T), stream);
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stream Pack(object obj, Type type) {
            if (obj is null)
                return new MemoryStream();

            var ms = new MemoryStream();

            Pack(obj, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void Pack(object obj, Type type, Stream stream) {
            if (obj is null)
                return;

            var serializer = new XmlSerializer(type);

            serializer.Serialize(stream, obj);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream) {
            return (T) Unpack(stream, typeof(T));
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type) {
            if (stream is null || stream.Length == 0)
                return default;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            var xmlSerializer = new XmlSerializer(type);

            return xmlSerializer.Deserialize(stream);
        }
    }
}