using System;

namespace Cosmos.IdUtils {
    /// <summary>
    /// Default TraceIdMaker
    /// </summary>
    public class DefaultTraceIdMaker : ITraceIdMaker {
        /// <summary>
        /// Create Id
        /// </summary>
        /// <returns></returns>
        public string CreateId() {
            var now = DateTime.Now;
            return $"{now:yyyyMMddHHmmddffff}{RandomIdProvider.Create(7)}{now.Ticks}";
        }
    }
}