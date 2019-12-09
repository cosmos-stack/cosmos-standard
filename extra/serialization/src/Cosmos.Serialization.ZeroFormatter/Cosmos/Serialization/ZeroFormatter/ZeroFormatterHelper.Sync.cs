using System;
using ZeroFormatter;

namespace Cosmos.Serialization.ZeroFormatter {
    /// <summary>
    /// ZeroFormatter helper
    /// </summary>
    public static partial class ZeroFormatterHelper {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] Serialize<T>(T o) {
            return o is null
                ? new byte[0]
                : ZeroFormatterSerializer.Serialize(o);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj, Type type) {
            return obj is null
                ? new byte[0]
                : ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes) {
            return bytes is null || bytes.Length == 0
                ? default
                : ZeroFormatterSerializer.Deserialize<T>(bytes);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] bytes, Type type) {
            return bytes is null || bytes.Length == 0
                ? null
                : ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);
        }
    }
}