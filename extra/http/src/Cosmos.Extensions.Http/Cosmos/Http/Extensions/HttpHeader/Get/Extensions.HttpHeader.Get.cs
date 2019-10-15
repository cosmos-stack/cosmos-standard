using System;
using System.Linq;
using System.Net.Http.Headers;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http
{
    /// <summary>
    /// Extensions of Http header
    /// </summary>
    public static partial class HttpHeaderExtensions
    {
        /// <summary>
        /// Try get value from http headers
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool TryGetValue(this HttpHeaders headers, string name, out string value)
        {
            if (headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            value = null;

            if (!headers.TryGetValues(name, out var values))
                return false;
            value = values.Single();

            return true;
        }
    }
}