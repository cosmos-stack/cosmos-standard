using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cosmos.Http.HttpUtils.Internals;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils {
    internal class HttpBuilder : IRequestBuilder {
        public HttpSettings Settings { get; }

        public HttpRequestMessage Message { get; }

        public bool LogErrors { get; set; } = true;

        public IEnumerable<HttpStatusCode> IgnoreResponseStatuses { get; set; } = Enumerable.Empty<HttpStatusCode>();

        public TimeSpan Timeout { get; set; }

        public event EventHandler<HttpExceptionArgs> BeforeExceptionLog;


        private readonly string _callerName;
        private readonly string _callerFile;
        private readonly int _callerLine;

        public HttpBuilder(string uri, HttpSettings settings, string callerName, string callerFile, int callerLine) {
            Message = new HttpRequestMessage {RequestUri = new Uri(uri, UriKind.RelativeOrAbsolute)};
            Settings = settings;
            Timeout = (settings ?? FluentHttp.DefaultSettings).DefaultTimeout;

            _callerName = callerName;
            _callerFile = callerFile;
            _callerLine = callerLine;
        }

        public void OnBeforeExceptionLog(HttpExceptionArgs args) {
            BeforeExceptionLog?.Invoke(this, args);
        }

        internal void AddExceptionData(Exception ex) {
            if (ex == null) return;

            try {
                var servicePoint = ServicePointManager.FindServicePoint(Message.RequestUri);
                ex
                   .AddLoggedData("ServicePoint.ConnectionLimit", servicePoint.ConnectionLimit)
                   .AddLoggedData("ServicePoint.CurrentConnections", servicePoint.CurrentConnections)
                   .AddLoggedData("ServicePointManager.CurrentConnections", ServicePointManager.DefaultConnectionLimit);
            }
            catch {
                // ignored
            }

            ex
               .AddLoggedData("Caller.Name", _callerName)
               .AddLoggedData("Caller.File", _callerFile)
               .AddLoggedData("Caller_Line", _callerLine.ToString());
        }

        public IRequestBuilder<T> WithHandler<T>(Func<HttpResponseMessage, Task<T>> handler) => new HttpBuilder<T>(this, handler);
    }
}