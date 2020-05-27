using System;

namespace Cosmos.Date
{
    /// <summary>
    /// No repeat TimeStamp factory
    /// </summary>
    public class NoRepeatTimeStampFactory
    {
        // ReSharper disable once InconsistentNaming
        private DateTime lastValue = DateTime.MinValue;
        private readonly object _lockObj = new object();

        /// <summary>
        /// Increment milliseconds.
        /// </summary>
        public double IncrementMs { get; set; } = 4;

        /// <summary>
        /// Gets timestamp
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeStamp() => GetTimeStampCore(DateTime.Now);

        /// <summary>
        /// Gets timestamp
        /// </summary>
        /// <returns></returns>
        public DateTime GetUtcTimeStamp() => GetTimeStampCore(DateTime.UtcNow);

        /// <summary>
        /// Gets TimeStamp object
        /// </summary>
        /// <returns></returns>
        public TimeStamp GetTimeStampObject() => new TimeStamp(GetTimeStamp());

        /// <summary>
        /// Gets utc TimeStamp object
        /// </summary>
        /// <returns></returns>
        public TimeStamp GetUtcTimeStampObject() => new TimeStamp(GetUtcTimeStamp());

        /// <summary>
        /// Gets unix TimeStamp object
        /// </summary>
        /// <returns></returns>
        public UnixTimeStamp GetUnixTimeStampObject() => new UnixTimeStamp(GetTimeStamp());

        /// <summary>
        /// Gets utc unix TimeStamp object
        /// </summary>
        /// <returns></returns>
        public UnixTimeStamp GetUtcUnixTimeStampObject() => new UnixTimeStamp(GetUtcTimeStamp());

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