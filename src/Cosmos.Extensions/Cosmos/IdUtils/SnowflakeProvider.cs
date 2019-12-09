namespace Cosmos.IdUtils {
    /// <summary>
    /// Snowflake Provider
    /// </summary>
    public static class SnowflakeProvider {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="dataCenterId"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static SnowflakeIdWorker Create(long workerId, long dataCenterId, long sequence = 0L) {
            return new SnowflakeIdWorker(workerId, dataCenterId, sequence);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TSnowflakeIdWorker"></typeparam>
        /// <param name="workerId"></param>
        /// <param name="dataCenterId"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static TSnowflakeIdWorker Create<TSnowflakeIdWorker>(long workerId, long dataCenterId, long sequence = 0L)
            where TSnowflakeIdWorker : SnowflakeIdWorker {
            return Types.CreateInstance<TSnowflakeIdWorker>(workerId, dataCenterId, sequence);
        }
    }
}