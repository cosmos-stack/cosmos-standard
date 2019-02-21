namespace Cosmos.IdUtils
{
    public static class SnowflakeProvider
    {
        public static SnowflakeIdWorker Create(long workerId, long dataCenterId, long sequence = 0L)
        {
            return new SnowflakeIdWorker(workerId, dataCenterId, sequence);
        }

        public static TSnowflakeIdWorker Create<TSnowflakeIdWorker>(long workerId, long dataCenterId, long sequence = 0L)
            where TSnowflakeIdWorker : SnowflakeIdWorker
        {
            return Types.CreateInstance<TSnowflakeIdWorker>(workerId, dataCenterId, sequence);
        }
    }
}
