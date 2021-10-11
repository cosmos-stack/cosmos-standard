using System;

namespace CosmosStack.Date
{
    /// <summary>
    /// No repeat TimeStamp factory <br />
    /// 不重复时间戳工厂
    /// </summary>
    public class NoRepeatTimeStampFactory
    {
        // ReSharper disable once InconsistentNaming
        private DateTime lastValue = DateTime.MinValue;
        private readonly object _lockObj = new();

        /// <summary>
        /// Increment milliseconds. <br />
        /// 自增毫秒数
        /// </summary>
        public double IncrementMs { get; set; } = 4;

        /// <summary>
        /// Gets timestamp <br />
        /// 获得时间戳
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeStamp() => GetTimeStampCore(DateTime.Now);

        /// <summary>
        /// Gets timestamp <br />
        /// 获得时间戳
        /// </summary>
        /// <returns></returns>
        public DateTime GetUtcTimeStamp() => GetTimeStampCore(DateTime.UtcNow);

        /// <summary>
        /// Gets TimeStamp object <br />
        /// 获得时间戳对象
        /// </summary>
        /// <returns></returns>
        public TimeStamp GetTimeStampObject() => new(GetTimeStamp());

        /// <summary>
        /// Gets utc TimeStamp object <br />
        /// 获得时间戳对象
        /// </summary>
        /// <returns></returns>
        public TimeStamp GetUtcTimeStampObject() => new(GetUtcTimeStamp());

        /// <summary>
        /// Gets unix TimeStamp object <br />
        /// 获得 Unix 时间戳对象
        /// </summary>
        /// <returns></returns>
        public UnixTimeStamp GetUnixTimeStampObject() => new(GetTimeStamp());

        /// <summary>
        /// Gets utc unix TimeStamp object <br />
        /// 获得 UTC Unix 时间戳对象
        /// </summary>
        /// <returns></returns>
        public UnixTimeStamp GetUtcUnixTimeStampObject() => new(GetUtcTimeStamp());

        private DateTime GetTimeStampCore(DateTime refDt)
        {
            var now = refDt;
            lock (_lockObj)
            {
                if ((now - lastValue).TotalMilliseconds < IncrementMs)
                {
                    now = lastValue.AddMilliseconds(IncrementMs);
                }

                lastValue = now;
            }

            return now;
        }
    }
}