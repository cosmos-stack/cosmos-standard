using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using Jil;
using ProtoBuf;
using Cosmos.Http.HttpUtils;
using Newtonsoft.Json;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

// ReSharper disable once CheckNamespace
namespace Cosmos.Http
{
    /// <summary>
    /// Http Send Extensions
    /// </summary>
    public static class HttpSendExtensions
    {
        /// <summary>
        /// Send content
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static IRequestBuilder SendContent(this IRequestBuilder builder, HttpContent content)
        {
            builder.Message.Content = content;
            return builder;
        }

        /// <summary>
        /// Send from
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static IRequestBuilder SendForm(this IRequestBuilder builder, NameValueCollection form)
            => SendContent(builder, new FormUrlEncodedContent(form.AllKeys.ToDictionary(k => k, v => form[v])));

        /// <summary>
        /// Send html
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IRequestBuilder SendHtml(this IRequestBuilder builder, string html)
            => SendContent(builder, new StringContent(html, Encoding.UTF8, "text/html"));

        /// <summary>
        /// Send plain text
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IRequestBuilder SendPlaintext(this IRequestBuilder builder, string text)
            => SendContent(builder, new StringContent(text, Encoding.UTF8, "application/x-www-form-urlencoded"));

        #region JSON

        /// <summary>
        /// Send json by Jil
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IRequestBuilder SendJson(this IRequestBuilder builder, object obj)
            => SendJson(builder, obj, Options.Default);

        /// <summary>
        /// Send json by Jil
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IRequestBuilder SendJson(this IRequestBuilder builder, object obj, Options options)
            => builder.SendContent(new StringContent(JSON.Serialize(obj, options), Encoding.UTF8, "application/json"));

        /// <summary>
        /// Send json by Newtonsoft.Json
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IRequestBuilder SendJson(this IRequestBuilder builder, object obj, JsonSerializerSettings settings)
            => builder.SendContent(new StringContent(JsonConvert.SerializeObject(obj, settings), Encoding.UTF8, "application/json"));

        #endregion

        #region Protobuf

        /// <summary>
        /// Send ProtoBuf
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IRequestBuilder SendProtoBuf(this IRequestBuilder builder, object obj)
        {
            using (var output = new MemoryStream())
            {
                using (var gzs = new GZipStream(output, CompressionMode.Compress))
                {
                    Serializer.Serialize(gzs, obj);
                    gzs.Close();

                    var protoContent = new ByteArrayContent(output.ToArray());
                    protoContent.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    protoContent.Headers.Add("Content-Encoding", "gzip");
                    return builder.SendContent(protoContent);
                }
            }
        }

        #endregion

    }
}