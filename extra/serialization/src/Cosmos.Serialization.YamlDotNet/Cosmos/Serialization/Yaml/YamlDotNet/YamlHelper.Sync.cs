using System;

namespace Cosmos.Serialization.Yaml.YamlDotNet {
    /// <summary>
    /// Yaml Helper
    /// </summary>
    public static partial class YamlHelper {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o) {
            return YamlManager.DefaultSerializer.Serialize(o);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o) {
            return o is null
                ? new byte[0]
                : YamlManager.DefaultEncoding.GetBytes(Serialize(o));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string data) {
            return string.IsNullOrWhiteSpace(data)
                ? default
                : YamlManager.DefaultDeserializer.Deserialize<T>(data);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string data, Type type) {
            return string.IsNullOrWhiteSpace(data)
                ? null
                : YamlManager.DefaultDeserializer.Deserialize(data, type);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data) {
            return data is null || data.Length is 0
                ? default
                : Deserialize<T>(YamlManager.DefaultEncoding.GetString(data));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type) {
            return data is null || data.Length is 0
                ? null
                : Deserialize(YamlManager.DefaultEncoding.GetString(data), type);
        }
    }
}