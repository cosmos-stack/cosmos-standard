using System.Runtime.CompilerServices;

// ReSharper disable RedundantTypeArgumentsOfMethod

namespace CosmosStack.UnionTypes
{
    /// <summary>
    /// UnionType Convertor
    /// 联合类型转换器
    /// </summary>
    public static partial class UnionTypeConv
    {
        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0> ToUnionType<T0>(T0 input) => UnionType.Of<T0>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1> ToUnionType<T0, T1>(T0 input) => UnionType.Of<T0, T1>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1> ToUnionType<T0, T1>(T1 input) => UnionType.Of<T0, T1>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2> ToUnionType<T0, T1, T2>(T0 input) => UnionType.Of<T0, T1, T2>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2> ToUnionType<T0, T1, T2>(T1 input) => UnionType.Of<T0, T1, T2>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2> ToUnionType<T0, T1, T2>(T2 input) => UnionType.Of<T0, T1, T2>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(T0 input) => UnionType.Of<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(T1 input) => UnionType.Of<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(T2 input) => UnionType.Of<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(T3 input) => UnionType.Of<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(T0 input) => UnionType.Of<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(T1 input) => UnionType.Of<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(T2 input) => UnionType.Of<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(T3 input) => UnionType.Of<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(T4 input) => UnionType.Of<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(T0 input) => UnionType.Of<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(T1 input) => UnionType.Of<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(T2 input) => UnionType.Of<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(T3 input) => UnionType.Of<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(T4 input) => UnionType.Of<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(T5 input) => UnionType.Of<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T0 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T1 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T2 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T3 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T4 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T5 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(T6 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T0 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T1 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T2 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T3 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T4 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T5 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T6 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(T7 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T1 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T3 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 input) => UnionType.Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);
    }

    /// <summary>
    /// UnionType Convertor Extensions <br />
    /// 联合类型转换器扩展
    /// </summary>
    public static partial class UnionTypeConvExtensions
    {
        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0> ToUnionType<T0>(this T0 input) => UnionTypeConv.ToUnionType<T0>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1> ToUnionType<T0, T1>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1> ToUnionType<T0, T1>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2> ToUnionType<T0, T1, T2>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2> ToUnionType<T0, T1, T2>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2> ToUnionType<T0, T1, T2>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3> ToUnionType<T0, T1, T2, T3>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4> ToUnionType<T0, T1, T2, T3, T4>(this T4 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(this T4 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5> ToUnionType<T0, T1, T2, T3, T4, T5>(this T5 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T4 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T5 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6> ToUnionType<T0, T1, T2, T3, T4, T5, T6>(this T6 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T4 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T5 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T6 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(this T7 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T4 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T5 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T6 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T7 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T8 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T0 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T1 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T2 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T3 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T4 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T5 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T6 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T7 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T8 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);

        /// <summary>
        /// Convert Object to UnionType <br />
        /// 将对象转换为联合类型
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T9 input) => UnionTypeConv.ToUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(input);
    }
}