using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
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
    public static class HttpSendExtensions
    {
        public static IRequestBuilder SendContent(this IRequestBuilder builder, HttpContent content)
        {
            builder.Message.Content = content;
            return builder;
        }

        public static IRequestBuilder SendForm(this IRequestBuilder builder, NameValueCollection form)
            => SendContent(builder, new FormUrlEncodedContent(form.AllKeys.ToDictionary(k => k, v => form[v])));

        public static IRequestBuilder SendHtml(this IRequestBuilder builder, string html)
            => SendContent(builder, new StringContent(html, Encoding.UTF8, "text/html"));

        public static IRequestBuilder SendPlaintext(this IRequestBuilder builder, string text)
            => SendContent(builder, new StringContent(text, Encoding.UTF8, "application/x-www-form-urlencoded"));

        #region JSON

        public static IRequestBuilder SendJson(this IRequestBuilder builder, object obj)
            => SendJson(builder, obj, Options.Default);

        public static IRequestBuilder SendJson(this IRequestBuilder builder, object obj, Options options)
            => builder.SendContent(new StringContent(JSON.Serialize(obj, options), Encoding.UTF8, "application/json"));

        #endregion

        #region Protobuf

        public static IRequestBuilder SendProtobuf(this IRequestBuilder builder, object obj)
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
