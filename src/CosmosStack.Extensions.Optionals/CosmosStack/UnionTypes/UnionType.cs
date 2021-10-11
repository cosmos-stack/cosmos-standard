namespace CosmosStack.UnionTypes
{
    public static class UnionType
    {
        public static UnionType<T0> Of<T0>(T0 input) => UnionType<T0>.FromT0(input);

        public static UnionType<T0, T1> Of<T0, T1>(T0 input) => UnionType<T0, T1>.FromT0(input);

        public static UnionType<T0, T1> Of<T0, T1>(T1 input) => UnionType<T0, T1>.FromT1(input);

        public static UnionType<T0, T1, T2> Of<T0, T1, T2>(T0 input) => UnionType<T0, T1, T2>.FromT0(input);

        public static UnionType<T0, T1, T2> Of<T0, T1, T2>(T1 input) => UnionType<T0, T1, T2>.FromT1(input);

        public static UnionType<T0, T1, T2> Of<T0, T1, T2>(T2 input) => UnionType<T0, T1, T2>.FromT2(input);

        public static UnionType<T0, T1, T2, T3> Of<T0, T1, T2, T3>(T0 input) => UnionType<T0, T1, T2, T3>.FromT0(input);

        public static UnionType<T0, T1, T2, T3> Of<T0, T1, T2, T3>(T1 input) => UnionType<T0, T1, T2, T3>.FromT1(input);

        public static UnionType<T0, T1, T2, T3> Of<T0, T1, T2, T3>(T2 input) => UnionType<T0, T1, T2, T3>.FromT2(input);

        public static UnionType<T0, T1, T2, T3> Of<T0, T1, T2, T3>(T3 input) => UnionType<T0, T1, T2, T3>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4> Of<T0, T1, T2, T3, T4>(T0 input) => UnionType<T0, T1, T2, T3, T4>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4> Of<T0, T1, T2, T3, T4>(T1 input) => UnionType<T0, T1, T2, T3, T4>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4> Of<T0, T1, T2, T3, T4>(T2 input) => UnionType<T0, T1, T2, T3, T4>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4> Of<T0, T1, T2, T3, T4>(T3 input) => UnionType<T0, T1, T2, T3, T4>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4> Of<T0, T1, T2, T3, T4>(T4 input) => UnionType<T0, T1, T2, T3, T4>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5> Of<T0, T1, T2, T3, T4, T5>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5> Of<T0, T1, T2, T3, T4, T5>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5> Of<T0, T1, T2, T3, T4, T5>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5> Of<T0, T1, T2, T3, T4, T5>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5> Of<T0, T1, T2, T3, T4, T5>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5> Of<T0, T1, T2, T3, T4, T5>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6> Of<T0, T1, T2, T3, T4, T5, T6>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7> Of<T0, T1, T2, T3, T4, T5, T6, T7>(T7 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T8 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T9 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T10 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T11 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T3 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T5 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T6 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T7 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T8 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T9 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T10 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T11 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T12 input) => UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromT13(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T2 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T3 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T4 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T5 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T6 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T7 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T8 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T9 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T10 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T11 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T12 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T13 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT13(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T14 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromT14(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T2 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T3 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T4 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T5 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T6 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T7 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T8 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T9 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T10 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T11 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T12 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T13 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT13(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T14 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT14(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T15 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromT15(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T0 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T2 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T3 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T4 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T5 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T6 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T7 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T8 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T9 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T10 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T11 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T12 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T13 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT13(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T14 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT14(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T15 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT15(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T16 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromT16(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T0 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T2 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T3 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T4 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T5 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T6 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T7 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T8 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T9 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T10 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T11 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T12 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T13 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT13(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T14 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT14(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T15 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT15(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T16 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT16(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T17 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromT17(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T0 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT0(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T1 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT1(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T2 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT2(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T3 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT3(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T4 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT4(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T5 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT5(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T6 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT6(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T7 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT7(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T8 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT8(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T9 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT9(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T10 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT10(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T11 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT11(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T12 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT12(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T13 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT13(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T14 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT14(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T15 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT15(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T16 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT16(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T17 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT17(input);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Of<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T18 input) =>
            UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromT18(input);
    }
}