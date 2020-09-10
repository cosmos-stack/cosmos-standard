using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Unix timestamp
    /// </summary>
    public class UnixTimeStamp : TimeStamp
    {
        /// <summary>
        /// Create a new instance of <see cref="UnixTimeStamp"/>
        /// </summary>
        public UnixTimeStamp() : this(DateTime.Now) { }

        /// <summary>
        /// Create a new instance of <see cref="UnixTimeStamp"/>
        /// </summary>
        /// <param name="timestamp"></param>
        public UnixTimeStamp(long timestamp) : this(FromUnixTimestampFunc(timestamp), timestamp) { }

        /// <summary>
        /// Create a new instance of <see cref="UnixTimeStamp"/>
        /// </summary>
        /// <param name="dt"></param>
        public UnixTimeStamp(DateTime dt) : this(dt, ToUnixTimestampFunc(dt)) { }

        private UnixTimeStamp(DateTime dt, long timestamp)
        {
            m_timestamp = timestamp;
            m_datetime = dt;
        }

        /// <summary>
        /// 根据 Unix 时间戳，获取对应时间
        /// </summary>
        /// <returns></returns>
        public override DateTime ToDateTime() => m_datetime;

        /// <summary>
        /// 获取 Unix 时间戳
        /// </summary>
        /// <returns></returns>
        public override long ToTimestamp() => m_timestamp;

        private static readonly Func<DateTime, long> ToUnixTimestampFunc = time =>
            (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

        private static readonly Func<long, DateTime> FromUnixTimestampFunc = timestamp =>
            (TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local))
           .Add(new TimeSpan(long.Parse(timestamp + "0000000")));

        /// <summary>
        /// Gets a func for unix now.
        /// </summary>
        public static Func<long> NowUnixTimeStamp = () => ToUnixTimestampFunc(DateTime.Now);

        /// <summary>
        /// Gets a func for unix utc_now.
        /// </summary>
        public static Func<long> UtcNowUnixTimeStamp = () => ToUnixTimestampFunc(DateTime.UtcNow);
    }
}