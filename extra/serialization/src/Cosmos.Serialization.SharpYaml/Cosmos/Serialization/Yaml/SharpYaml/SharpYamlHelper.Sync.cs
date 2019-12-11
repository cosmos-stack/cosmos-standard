using System;

namespace Cosmos.Serialization.Yaml.SharpYaml {
    /// <summary>
    /// SharpYaml helper
    /// </summary>
    public static partial class SharpYamlHelper {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o) {
            return SharpYamlManager.DefaultSerializer.Serialize(o);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="expectedType"></param>
        /// <returns></returns>
        public static string Serialize(object o, Type expectedType) {
            return SharpYamlManager.DefaultSerializer.Serialize(o, expectedType);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o) {
            return o is null
                ? new byte[0]
                : SharpYamlManager.DefaultEncoding.GetBytes(Serialize(o));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="expectedType"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o, Type expectedType) {
            return o is null
                ? new byte[0]
                : SharpYamlManager.DefaultEncoding.GetBytes(Serialize(o, expectedType));
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
                : SharpYamlManager.DefaultSerializer.Deserialize<T>(data);
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
                : SharpYamlManager.DefaultSerializer.Deserialize(data, type);
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
                : Deserialize<T>(SharpYamlManager.DefaultEncoding.GetString(data));
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
                : Deserialize(SharpYamlManager.DefaultEncoding.GetString(data), type);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="targetObj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeInto<T>(string data, T targetObj) {
            return string.IsNullOrWhiteSpace(data)
                ? targetObj
                : SharpYamlManager.DefaultSerializer.DeserializeInto(data, targetObj);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        public static object DeserializeInto(string data, Type type, object targetObj) {
            return string.IsNullOrWhiteSpace(data)
                ? targetObj
                : SharpYamlManager.DefaultSerializer.Deserialize(data, type, targetObj);
        }
    }
}