#if !NET451 && !NET452

/*
 * Author: LanX
 * 2020.01.03
 */

namespace Cosmos.Reflection
{
    /// <summary>
    /// Ctor matched result
    /// </summary>
    public readonly struct CtorMatchedResult
    {
        /// <summary>
        /// Ctor matched result
        /// </summary>
        /// <param name="values"></param>
        /// <param name="index"></param>
        public CtorMatchedResult(object[] values, int index)
        {
            Values = values;
            Index = index;
        }

        /// <summary>
        /// Values
        /// </summary>
        public readonly object[] Values;

        /// <summary>
        /// Index
        /// </summary>
        public readonly int Index;
    }
}

#endif