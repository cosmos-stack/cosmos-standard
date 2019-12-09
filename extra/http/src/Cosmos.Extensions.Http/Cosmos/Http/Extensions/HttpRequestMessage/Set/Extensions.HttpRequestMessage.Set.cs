using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http {
    /// <summary>
    /// HttpResponseMessage extensions
    /// </summary>
    public static partial class HttpResponseMessageExtensions {
        /// <summary>
        /// Set basic http authentication
        /// </summary>
        /// <param name="message"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetBasicHttpAuthentication(this HttpRequestMessage message, string username, string password) {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            const string scheme = "Basic";
            const string parameterTemplate = "{0}:{1}";

            var parameter = string.Format(CultureInfo.InvariantCulture, parameterTemplate, username, password);
            parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes(parameter));
            message.Headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
        }
    }
}