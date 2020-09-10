namespace System
{
    /// <summary>
    /// Cosmos <see cref="DayOfWeek"/> extensions.
    /// </summary>
    public static class SystemDayOfWeekExtensions
    {
        /// <summary>
        /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
        /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static int ToInt(this DayOfWeek week)
        {
            return week switch
            {
                DayOfWeek.Sunday => 1,
                DayOfWeek.Monday => 2,
                DayOfWeek.Tuesday => 3,
                DayOfWeek.Wednesday => 4,
                DayOfWeek.Thursday => 5,
                DayOfWeek.Friday => 6,
                DayOfWeek.Saturday => 7,
                _ => 0
            };
        }
    }
}
