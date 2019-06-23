using System;
using Cosmos.Disposables;

/*
 * Reference To:
 *      https://github.com/stulzq/snowflake-net/
 *      Author:
 *          dunitian,   https://github.com/dunitian
 *          stulzq,     https://github.com/stulzq
 *      MIT
 */

namespace Cosmos.IdUtils
{
    /// <summary>
    /// Snowflake Id worker
    /// </summary>
    public class SnowflakeIdWorker
    {
        #region Constants

        /// <summary>
        /// 基准时间
        /// </summary>
        // ReSharper disable once IdentifierTypo
        public const long TWEPOCH = 1288834974657L;

        /// <summary>
        /// 机器标识位数
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once InconsistentNaming
        const int WORKER_ID_BITS = 5;

        /// <summary>
        /// 数据标志位数
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once InconsistentNaming
        const int DATA_CENTER_ID_BITS = 5;

        /// <summary>
        /// 序列号识位数
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once InconsistentNaming
        const int SEQUENCE_BITS = 12;

        /// <summary>
        /// 机器ID最大值
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once InconsistentNaming
        const long MAX_WORKER_ID = -1L ^ (-1L << WORKER_ID_BITS);

        /// <summary>
        /// 数据标志ID最大值
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once InconsistentNaming
        const long MAX_DATA_CENTER_ID = -1L ^ (-1L << DATA_CENTER_ID_BITS);

        /// <summary>
        /// 序列号ID最大值
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private const long SEQUENCE_MASK = -1L ^ (-1L << SEQUENCE_BITS);

        /// <summary>
        /// 机器ID偏左移12位
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private const int WORKER_ID_SHIFT = SEQUENCE_BITS;

        /// <summary>
        /// 数据ID偏左移17位
        /// </summary>
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private const int DATA_CENTER_ID_SHIFT = SEQUENCE_BITS + WORKER_ID_BITS;

        /// <summary>
        /// 时间毫秒左移22位
        /// </summary>
        // ReSharper disable once IdentifierTypo
        public const int TIMESTAMP_LEFT_SHIFT = SEQUENCE_BITS + WORKER_ID_BITS + DATA_CENTER_ID_BITS;

        #endregion

        // ReSharper disable once RedundantDefaultMemberInitializer
        private long _sequence = 0L;
        private long _lastTimestamp = -1L;

        /// <summary>
        /// Worker Id
        /// </summary>
        public long WorkerId { get; protected set; }

        /// <summary>
        /// Data center Id
        /// </summary>
        public long DataCenterId { get; protected set; }

        /// <summary>
        /// Sequence
        /// </summary>
        public long Sequence {
            get => _sequence;
            internal set => _sequence = value;
        }

        /// <summary>
        /// Create a new <see cref="SnowflakeIdWorker"/> instance.
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="dataCenterId"></param>
        /// <param name="sequence"></param>
        public SnowflakeIdWorker(long workerId, long dataCenterId, long sequence = 0L)
        {
            // 如果超出范围就抛出异常
            if (workerId > MAX_WORKER_ID || workerId < 0)
                throw new ArgumentException($"worker Id 必须大于0，且不能大于MaxWorkerId： {MAX_WORKER_ID}");
            if (dataCenterId > MAX_DATA_CENTER_ID || dataCenterId < 0)
                throw new ArgumentException($"region Id 必须大于0，且不能大于MaxWorkerId： {MAX_DATA_CENTER_ID}");

            //先检验再赋值
            WorkerId = workerId;
            DataCenterId = dataCenterId;
            _sequence = sequence;
        }

        readonly object _lock = new object();

        /// <summary>
        /// Next Id
        /// </summary>
        /// <returns></returns>
        public virtual long NextId()
        {
            lock (_lock)
            {
                var timestamp = TimeGen();
                if (timestamp < _lastTimestamp)
                {
                    throw new Exception($"时间戳必须大于上一次生成ID的时间戳.  拒绝为{_lastTimestamp - timestamp}毫秒生成id");
                }

                //如果上次生成时间和当前时间相同,在同一毫秒内
                if (_lastTimestamp == timestamp)
                {
                    //sequence自增，和sequenceMask相与一下，去掉高位
                    _sequence = (_sequence + 1) & SEQUENCE_MASK;
                    //判断是否溢出,也就是每毫秒内超过1024，当为1024时，与sequenceMask相与，sequence就等于0
                    if (_sequence == 0)
                    {
                        //等待到下一毫秒
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    //如果和上次生成时间不同,重置sequence，就是下一毫秒开始，sequence计数重新从0开始累加,
                    //为了保证尾数随机性更大一些,最后一位可以设置一个随机数
                    _sequence = 0;//new Random().Next(10);
                }

                _lastTimestamp = timestamp;
                return ((timestamp - TWEPOCH) << TIMESTAMP_LEFT_SHIFT) | (DataCenterId << DATA_CENTER_ID_SHIFT) | (WorkerId << WORKER_ID_SHIFT) | _sequence;
            }
        }

        /// <summary>
        /// 防止产生的时间比之前的时间还要小（由于NTP回拨等问题）,保持增量的趋势.
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        protected virtual long TilNextMillis(long lastTimestamp)
        {
            var timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }
            return timestamp;
        }

        /// <summary>
        /// 获取当前的时间戳
        /// </summary>
        /// <returns></returns>
        protected virtual long TimeGen()
        {
            return TimeExtensions.CurrentTimeMillis();
        }

        private static class TimeExtensions
        {
            private static Func<long> _currentTimeFunc = InternalCurrentTimeMillis;

            public static long CurrentTimeMillis()
            {
                return _currentTimeFunc();
            }

            // ReSharper disable once UnusedMember.Global
            // ReSharper disable once UnusedMember.Local
            public static IDisposable StubCurrentTime(Func<long> func)
            {
                _currentTimeFunc = func;

                return new DisposableAction(() =>
                {
                    _currentTimeFunc = InternalCurrentTimeMillis;
                });
            }

            // ReSharper disable once UnusedMember.Global
            // ReSharper disable once UnusedMember.Local
            public static IDisposable StubCurrentTime(long millis)
            {
                _currentTimeFunc = () => millis;

                return new DisposableAction(() =>
                {
                    _currentTimeFunc = InternalCurrentTimeMillis;
                });
            }

            private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            private static long InternalCurrentTimeMillis() => (long)(DateTime.UtcNow - Jan1St1970).TotalMilliseconds;
        }
    }
}
