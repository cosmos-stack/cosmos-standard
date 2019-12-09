using System;
using System.Net;
using System.Net.Http;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http {
    /// <summary>
    /// HttpClient extensions
    /// </summary>
    public static partial class HttpClientExtensions {
        /// <summary>
        /// Set compression
        /// </summary>
        /// <param name="handler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetCompression(this HttpClientHandler handler) {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        }
    }
}