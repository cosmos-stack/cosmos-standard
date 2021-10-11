using System.Runtime.CompilerServices;

namespace CosmosStack.Numeric
{
    /// <summary>
    /// Number Utilities <br />
    /// 数值工具
    /// </summary>
    public static partial class Numbers
    {
        #region IsNaN

        /// <summary>
        /// Is NaN <br />
        /// 标记是否为非数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(double value) => double.IsNaN(value);

        /// <summary>
        /// Is NaN <br />
        /// 标记是否为非数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(float value) => float.IsNaN(value);

        #endregion

        #region IsDefault

        /// <summary>
        /// Is default <br />
        /// 标记是否为默认值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefaultValue(double value) => value.Equals(default);

        #endregion
    }

    /// <summary>
    /// Extensions for number utilities <br />
    /// 数值工具扩展
    /// </summary>
    public static partial class NumberExtensions
    {
        /// <summary>
        /// Is default <br />
        /// 标记是否为默认值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefault(this double value) => Numbers.IsDefaultValue(value);
    }
}