using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Cosmos.Http.HttpUtils.Internals;
using Jil;
using ProtoBuf;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    /// <summary>
    /// Http Expect Extensions
    /// </summary>
    public static class HttpExpectExtensions
    {
        /// <summary>
        /// Expect Http Success
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IRequestBuilder<bool> ExpectHttpSuccess(this IRequestBuilder builder)
            => builder.WithHandler(responseMessage => Task.FromResult(responseMessage.IsSuccessStatusCode));

        /// <summary>
        /// Expect Byte Array
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IRequestBuilder<byte[]> ExpectByteArray(this IRequestBuilder builder)
            => builder.WithHandler(responseMessage => responseMessage.Content.ReadAsByteArrayAsync());

        /// <summary>
        /// Expect String
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IRequestBuilder<string> ExpectString(this IRequestBuilder builder)
            => builder.WithHandler(async responseMessage =>
            {
                using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
            });

        #region JSON

        /// <summary>
        /// Expect json
        /// </summary>
        /// <param name="builder"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRequestBuilder<T> ExpectJson<T>(this IRequestBuilder builder)
            => ExpectJson<T>(builder, Options.Default);

        /// <summary>
        /// Expect json
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRequestBuilder<T> ExpectJson<T>(this IRequestBuilder builder, Options options)
            => builder.WithHandler(JsonHandler<T>.WithOptions(builder, options));

        private static class JsonHandler<T>
        {
            internal static Func<HttpResponseMessage, Task<T>> WithOptions(IRequestBuilder builder, Options options)
            {
                return async responseMessage =>
                {
                    using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
                    {
                        using (var streamReader = new StreamReader(responseStream))
                        {
                            using (builder.GetSettings().ProfileGeneral?.Invoke("Descrialize: JOSN"))
                            {
                                if (responseStream.Length == 0)
                                {
                                    return default;
                                }

                                return JSON.Deserialize<T>(streamReader, options ?? Options.Default);
                            }
                        }
                    }
                };
            }
        }

        #endregion

        #region Protobuf

        /// <summary>
        /// Expect protobuf
        /// </summary>
        /// <param name="builder"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRequestBuilder<T> ExpectProtobuf<T>(this IRequestBuilder builder)
            => builder.WithHandler(async responseMessage =>
            {
                using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
                {
                    using (builder.GetSettings().ProfileGeneral?.Invoke("Deserialize: Protobuf"))
                    {
                        return Serializer.Deserialize<T>(responseStream);
                    }
                }
            });

        #endregion

    }
}