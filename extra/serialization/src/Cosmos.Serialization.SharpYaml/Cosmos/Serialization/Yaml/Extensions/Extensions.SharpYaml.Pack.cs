using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.SharpYaml;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {

    /// <summary>
    /// SharpYaml extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Yaml pack
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream SharpYamlPack<T>(this T obj) => SharpYamlHelper.Pack(obj);
        
        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void SharpYamlPackTo<T>(this T t, Stream stream) {
            SharpYamlHelper.Pack(t, stream);
        }

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void SharpYamlPackTo(this object obj, Type type, Stream stream) {
            SharpYamlHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void SharpYamlPackBy<T>(this Stream stream, T t) => SharpYamlHelper.Pack(t, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void SharpYamlPackBy(this Stream stream, object obj, Type type) => SharpYamlHelper.Pack(obj, type, stream);

        /// <summary>
        /// Yaml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> SharpYamlPackAsync<T>(this T obj) => SharpYamlHelper.PackAsync(obj);
        
        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task SharpYamlPackToAsync<T>(this T t, Stream stream) => await SharpYamlHelper.PackAsync(t, stream);

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task SharpYamlPackToAsync(this object obj, Type type, Stream stream) => await SharpYamlHelper.PackAsync(obj, type, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task SharpYamlPackByAsync<T>(this Stream stream, T t) => await SharpYamlHelper.PackAsync(t, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static async Task SharpYamlPackByAsync(this Stream stream, object obj, Type type) => await SharpYamlHelper.PackAsync(obj, type, stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SharpYamlUnpack<T>(this Stream stream) => SharpYamlHelper.Unpack<T>(stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object SharpYamlUnpack(this Stream stream, Type type) => SharpYamlHelper.Unpack(stream, type);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> SharpYamlUnpackAsync<T>(this Stream stream) => SharpYamlHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> SharpYamlUnpackAsync(this Stream stream, Type type) => SharpYamlHelper.UnpackAsync(stream, type);
    }
}