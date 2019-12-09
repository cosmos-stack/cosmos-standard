using System;

namespace Cosmos {
    /// <summary>
    /// Timestamp
    /// </summary>
    public class TimeStamp {
        /// <summary>
        /// Timestamp
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected long m_timestamp;

        /// <summary>
        /// Datetime
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected DateTime m_datetime;

        /// <summary>
        /// Create a new instance of <see cref="TimeStamp"/>
        /// </summary>
        public TimeStamp() : this(DateTime.Now) { }

        /// <summary>
        /// Create a new instance of <see cref="TimeStamp"/>
        /// </summary>
        /// <param name="timestamp"></param>
        public TimeStamp(long timestamp) : this(FromTimestampFunc(timestamp), timestamp) { }

        /// <summary>
        /// Create a new instance of <see cref="TimeStamp"/>
        /// </summary>
        /// <param name="dt"></param>
        public TimeStamp(DateTime dt) : this(dt, ToTimestampFunc(dt)) { }

        private TimeStamp(DateTime dt, long timestamp) {
            m_timestamp = timestamp;
            m_datetime = dt;
        }

        /// <summary>
        /// Get the corresponding time based on the timestamp.
        /// </summary>
        /// <returns></returns>
        public virtual DateTime ToDateTime() => m_datetime;

        /// <summary>
        /// Get timestamp
        /// </summary>
        /// <returns></returns>
        public virtual long ToTimestamp() => m_timestamp;

        private static readonly Func<DateTime, long> ToTimestampFunc = time => time.Ticks;

        private static readonly Func<long, DateTime> FromTimestampFunc = timestamp => new DateTime(timestamp);

        /// <summary>
        /// Gets a Func for now
        /// </summary>
        public static Func<long> NowTimeStamp = () => ToTimestampFunc(DateTime.Now);

        /// <summary>
        /// Gets a Func for utc_now
        /// </summary>
        public static Func<long> UtcNowTimeStamp = () => ToTimestampFunc(DateTime.UtcNow);
    }
}