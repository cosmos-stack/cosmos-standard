using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Swifter;
using Swifter.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    using S = SwifterHelper;

    /// <summary>
    /// SwiftJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From Swifter
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSwifter<T>(this TextReader reader, JsonFormatterOptions? options = null) => S.Deserialize<T>(reader, options);

        /// <summary>
        /// From Swifter
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromSwifter(this TextReader reader, Type type, JsonFormatterOptions? options = null) => S.Deserialize(reader, type, options);

        /// <summary>
        /// From Swifter async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromSwifterAsync<T>(this TextReader reader, JsonFormatterOptions? options = null) => S.DeserializeAsync<T>(reader, options);

        /// <summary>
        /// From Swifter async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromSwifterAsync(this TextReader reader, Type type, JsonFormatterOptions? options = null) => S.DeserializeAsync(reader, type, options);
    }
}