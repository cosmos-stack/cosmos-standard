using System.Diagnostics;

namespace Cosmos
{
    public class TimeWatcher
    {
        static TimeWatcher()
        {
            WatchObj = new Stopwatch();
            WatchObj.Start();
        }

        protected static readonly Stopwatch WatchObj;

        public static double GetTotalMilliseconds() => WatchObj.Elapsed.TotalMilliseconds;

        public static long GetElapsedMilliseconds() => WatchObj.ElapsedMilliseconds;

        public static double GetTotalSeconds() => WatchObj.Elapsed.TotalSeconds;

        public static double GetTotalMinutes() => WatchObj.Elapsed.TotalMinutes;

        public static double GetTotalHours() => WatchObj.Elapsed.TotalHours;

        public static double GetTotalDays() => WatchObj.Elapsed.TotalDays;

        public static TimeWatcher Get() => new TimeWatcher();
    }
}