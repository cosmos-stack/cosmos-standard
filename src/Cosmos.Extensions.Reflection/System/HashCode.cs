#if NET || !NETSTANDARD2_1 && !NETCOREAPP3_0 && !NETCOREAPP3_1 && !NET5_0
using Cosmos.Reflection;

namespace System
{
    public class HashCode
    {
        public static int Combine<T1>(T1 value1)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1});

        public static int Combine<T1, T2>(T1 value1, T2 value2)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2});

        public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2, value3});

        public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2, value3, value4});

        public static int Combine<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2, value3, value4, value5});

        public static int Combine<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2, value3, value4, value5, value6});

        public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2, value3, value4, value5, value6, value7});

        public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(new object[] {value1, value2, value3, value4, value5, value6, value7, value8});
    }
}
#endif