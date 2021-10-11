using System;

namespace CosmosStack.Verba.Time
{
    /// <summary>
    /// TIme verba constant
    /// </summary>
    [Obsolete("将会被 CosmosStack.I18N 取代")]
    public static class TimeVerbaConstant
    {
        /// <summary>
        /// One minute <br />
        /// 一分钟
        /// </summary>
        public static readonly TimeSpan OneMinute = new(0, 1, 0);

        /// <summary>
        /// Tow minutes <br />
        /// 两分钟
        /// </summary>
        public static readonly TimeSpan TwoMinutes = new(0, 2, 0);

        /// <summary>
        /// One hour <br />
        /// 一小时
        /// </summary>
        public static readonly TimeSpan OneHour = new(1, 0, 0);

        /// <summary>
        /// Two hours <br />
        /// 两小时
        /// </summary>
        public static readonly TimeSpan TwoHours = new(2, 0, 0);

        /// <summary>
        /// One day <br />
        /// 一天
        /// </summary>
        public static readonly TimeSpan OneDay = new(1, 0, 0, 0);

        /// <summary>
        /// Two days <br />
        /// 两天
        /// </summary>
        public static readonly TimeSpan TwoDays = new(2, 0, 0, 0);

        /// <summary>
        /// One week <br />
        /// 一周
        /// </summary>
        public static readonly TimeSpan OneWeek = new(7, 0, 0, 0);

        /// <summary>
        /// Two weeks <br />
        /// 两周
        /// </summary>
        public static readonly TimeSpan TwoWeeks = new(14, 0, 0, 0);

        /// <summary>
        /// One month <br />
        /// 一月
        /// </summary>
        public static readonly TimeSpan OneMonth = new(31, 0, 0, 0);

        /// <summary>
        /// Two months <br />
        /// 两月
        /// </summary>
        public static readonly TimeSpan TwoMonths = new(62, 0, 0, 0);

        /// <summary>
        /// One year <br />
        /// 一年
        /// </summary>
        public static readonly TimeSpan OneYear = new(365, 0, 0, 0);

        /// <summary>
        /// Two years <br />
        /// 两年
        /// </summary>
        public static readonly TimeSpan TwoYears = new(730, 0, 0, 0);
    }
}