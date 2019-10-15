using System.Net.Http;

namespace Cosmos.Http
{
    /// <summary>
    /// Http message handler factory
    /// </summary>
    public static class HttpMessageHandlerFactory
    {
        /// <summary>
        /// Create default message handler
        /// </summary>
        /// <returns></returns>
        public static HttpMessageHandler CreateDefaultMessageHandler()
        {
            var handler = new HttpClientHandler();
            handler.SetCompression();
            return handler;
        }
    }
}