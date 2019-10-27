using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Xml
{
    /// <summary>
    /// Xml extensions
    /// </summary>
    public static partial class XmlExtensions
    {
        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream XmlPack<T>(this T obj)
        {
            return XmlHelper.Pack(obj);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream XmlPack(this object obj, Type type)
        {
            return XmlHelper.Pack(obj, type);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void XmlPackTo<T>(this T obj, Stream stream)
        {
            XmlHelper.Pack(obj, stream);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void XmlPackTo<T>(this T obj, Type type, Stream stream)
        {
            XmlHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Xml pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void XmlPackBy<T>(this Stream stream, T obj)
        {
            XmlHelper.Pack(obj, stream);
        }

        /// <summary>
        /// Xml pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void XmlPackBy(this Stream stream, object obj, Type type)
        {
            XmlHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> XmlPackAsync<T>(this T obj)
        {
            return XmlHelper.PackAsync(obj);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<Stream> XmlPackAsync(this object obj, Type type)
        {
            return XmlHelper.PackAsync(obj, type);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static Task XmlPackToAsync<T>(this T obj, Stream stream)
        {
            return XmlHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// Xml pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static Task XmlPackToAsync(this object obj, Type type, Stream stream)
        {
            return XmlHelper.PackAsync(obj, type, stream);
        }

        /// <summary>
        /// Xml pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static Task XmlPackByAsync<T>(this Stream stream, T obj)
        {
            return XmlHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// Xml pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static Task XmlPackByAsync(this Stream stream, object obj, Type type)
        {
            return XmlHelper.PackAsync(obj, type, stream);
        }

        /// <summary>
        /// Xml unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T XmlUnpack<T>(this Stream stream)
        {
            return XmlHelper.Unpack<T>(stream);
        }

        /// <summary>
        /// Xml unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object XmlUnpack(this Stream stream, Type type)
        {
            return XmlHelper.Unpack(stream, type);
        }

        /// <summary>
        /// Xml unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> XmlUnpackAsync<T>(this Stream stream)
        {
            return await XmlHelper.UnpackAsync<T>(stream);
        }

        /// <summary>
        /// Xml unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> XmlUnpackAsync(this Stream stream, Type type)
        {
            return await XmlHelper.UnpackAsync(stream, type);
        }
    }
}