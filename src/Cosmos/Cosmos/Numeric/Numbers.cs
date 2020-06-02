namespace Cosmos.Numeric
{
    /// <summary>
    /// Number Utilities
    /// </summary>
    public static class Numbers
    {
        #region GetMembersBetween

        /// <summary>
        /// Get members between min value and max value (include min and max).
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int[] GetMembersBetween(int min, int max)
        {
            if (min == max)
            {
                return new[] {min};
            }

            if (min > max)
            {
                var t = min;
                min = max;
                max = t;
            }

            var count = max - min + 1;
            var results = new int[count];
            var pointer = min;
            var index = 0;

            while (pointer <= max && index < count)
            {
                results[index] = pointer;

                ++index;
                ++pointer;
            }

            return results;
        }

        /// <summary>
        /// Get members between min value and max value (include min and max).
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static long[] GetMembersBetween(long min, long max)
        {
            if (min == max)
            {
                return new[] {min};
            }

            if (min > max)
            {
                var t = min;
                min = max;
                max = t;
            }

            var count = max - min + 1;
            var results = new long[count];
            var pointer = min;
            var index = 0L;

            while (pointer <= max && index < count)
            {
                results[index] = pointer;

                ++index;
                ++pointer;
            }

            return results;
        }

        #endregion

        #region IsNaN

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(double value) => value.IsNaN();

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(float value) => value.IsNaN();

        #endregion
    }
}