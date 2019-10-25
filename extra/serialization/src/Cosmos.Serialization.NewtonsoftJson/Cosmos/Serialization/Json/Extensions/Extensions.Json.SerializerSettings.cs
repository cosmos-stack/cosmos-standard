using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To serializer
        /// </summary>
        /// <param name="jsonSerializerSettings"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static JsonSerializer ToSerializer(this JsonSerializerSettings jsonSerializerSettings)
        {
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            return JsonSerializer.Create(jsonSerializerSettings);
        }

        /// <summary>
        /// Serialize to memory stream async
        /// </summary>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        public static Task<MemoryStream> SerializeToMemoryStreamAsync<TRequest>(
            this JsonSerializerSettings jsonSerializerSettings, TRequest request, CancellationToken cancellationToken)
            => jsonSerializerSettings.ToSerializer().SerializeToMemoryStreamAsync(request, cancellationToken);

        /// <summary>
        /// Serialize to string
        /// </summary>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="request"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        public static string SerializeToString<TRequest>(this JsonSerializerSettings jsonSerializerSettings, TRequest request)
            => jsonSerializerSettings.ToSerializer().SerializeToString(request);

        /// <summary>
        /// Deserialize from string
        /// </summary>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="json"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        public static TResponse DeserializeFromString<TResponse>(this JsonSerializerSettings jsonSerializerSettings, string json) =>
            jsonSerializerSettings.ToSerializer().DeserializeFromString<TResponse>(json);
    }
}