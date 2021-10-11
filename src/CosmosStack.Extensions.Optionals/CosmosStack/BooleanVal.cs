using System.Runtime.CompilerServices;

namespace CosmosStack
{
    /// <summary>
    /// Extend-Boolean Utilities <br />
    /// 扩展布尔值工具
    /// </summary>
    public static class BooleanVal
    {
        /// <summary>
        /// Of <br />
        /// 创建一个布尔封装值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal<T> Of<T>(bool value, T obj) => BooleanVal<T>.Of(value, obj);

        /// <summary>
        /// Maybe true <br />
        /// 可能为 True
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 MayTrue() => BooleanVal3.True.Instance;

        /// <summary>
        /// Maybe false <br />
        /// 可能为 False
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 MayFalse() => BooleanVal3.False.Instance;

        /// <summary>
        /// Maybe null <br />
        /// 可能为 Null
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 MayNull() => BooleanVal3.Null.Instance;
    }
}