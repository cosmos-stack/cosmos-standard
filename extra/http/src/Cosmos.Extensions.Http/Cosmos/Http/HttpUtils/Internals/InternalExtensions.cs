using System;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils.Internals {
    internal static class InternalExtensions {
        public static HttpSettings GetSettings<T>(this IRequestBuilder<T> builder) => GetSettings(builder.Inner);

        public static HttpSettings GetSettings(this IRequestBuilder builder) => builder.Settings ?? FluentHttp.DefaultSettings;

        public static T AddLoggedData<T>(this T ex, string key, object value) where T : Exception {
            ex.Data[FluentHttp.DefaultSettings.ErrorDataPrefix + key] = value?.ToString() ?? "";
            return ex;
        }
    }
}