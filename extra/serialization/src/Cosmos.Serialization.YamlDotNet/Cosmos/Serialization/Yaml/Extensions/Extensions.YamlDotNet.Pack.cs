using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.YamlDotNet;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {
    /// <summary>
    /// YamlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Lit pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream YamlPack<T>(this T obj) => YamlHelper.Pack(obj);
        
        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void YamlPackTo<T>(this T t, Stream stream) {
            YamlHelper.Pack(t, stream);
        }

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void YamlPackTo(this object obj, Type type, Stream stream) {
            YamlHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void YamlPackBy<T>(this Stream stream, T t) => YamlHelper.Pack(t, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void YamlPackBy(this Stream stream, object obj, Type type) => YamlHelper.Pack(obj, type, stream);

        /// <summary>
        /// Yaml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> YamlPackAsync<T>(this T obj) => YamlHelper.PackAsync(obj);
        
        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task YamlPackToAsync<T>(this T t, Stream stream) => await YamlHelper.PackAsync(t, stream);

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task YamlPackToAsync(this object obj, Type type, Stream stream) => await YamlHelper.PackAsync(obj, type, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task YamlPackByAsync<T>(this Stream stream, T t) => await YamlHelper.PackAsync(t, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static async Task YamlPackByAsync(this Stream stream, object obj, Type type) => await YamlHelper.PackAsync(obj, type, stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T YamlUnpack<T>(this Stream stream) => YamlHelper.Unpack<T>(stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object YamlUnpack(this Stream stream, Type type) => YamlHelper.Unpack(stream, type);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> YamlUnpackAsync<T>(this Stream stream) => YamlHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> YamlUnpackAsync(this Stream stream, Type type) => YamlHelper.UnpackAsync(stream, type);
    }
}