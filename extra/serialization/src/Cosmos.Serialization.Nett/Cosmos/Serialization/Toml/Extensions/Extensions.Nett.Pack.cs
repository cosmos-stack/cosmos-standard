using System;
using System.IO;
using System.Threading.Tasks;
using NettHelper = Cosmos.Serialization.Toml.Nett.NettHelper;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Toml {
    /// <summary>
    /// TomlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Lit pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream TomlPack<T>(this T obj) => NettHelper.Pack(obj);
        
        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void TomlPackTo<T>(this T t, Stream stream) {
            NettHelper.Pack(t, stream);
        }

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void TomlPackTo(this object obj, Type type, Stream stream) {
            NettHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void TomlPackBy<T>(this Stream stream, T t) => NettHelper.Pack(t, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void TomlPackBy(this Stream stream, object obj, Type type) => NettHelper.Pack(obj, type, stream);

        /// <summary>
        /// Toml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> TomlPackAsync<T>(this T obj) => NettHelper.PackAsync(obj);
        
        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task TomlPackToAsync<T>(this T t, Stream stream) => await NettHelper.PackAsync(t, stream);

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task TomlPackToAsync(this object obj, Type type, Stream stream) => await NettHelper.PackAsync(obj, type, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task TomlPackByAsync<T>(this Stream stream, T t) => await NettHelper.PackAsync(t, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static async Task TomlPackByAsync(this Stream stream, object obj, Type type) => await NettHelper.PackAsync(obj, type, stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T TomlUnpack<T>(this Stream stream) => NettHelper.Unpack<T>(stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object TomlUnpack(this Stream stream, Type type) => NettHelper.Unpack(stream, type);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> TomlUnpackAsync<T>(this Stream stream) => NettHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> TomlUnpackAsync(this Stream stream, Type type) => NettHelper.UnpackAsync(stream, type);
    }
}