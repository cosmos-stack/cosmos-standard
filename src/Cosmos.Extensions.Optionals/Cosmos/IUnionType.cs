using System;

namespace Cosmos
{
    /// <summary>
    /// An interface for UnionType
    /// </summary>
    public interface IUnionType
    {
        /// <summary>
        /// Gets value of this UnionType instance.
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Gets index of this UnionType instance.
        /// </summary>
        int Index { get; }
    }

    public interface IUnionType<out T0> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 1;
#endif

        Type TypeOfT0 { get; }

        bool IsT0();

        T0 AsT0();
    }

    public interface IUnionType<out T0, out T1> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 2;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        bool IsT0();

        bool IsT1();

        T0 AsT0();

        T1 AsT1();
    }

    public interface IUnionType<out T0, out T1, out T2> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 3;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 4;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 5;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 6;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 7;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 8;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 9;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 10;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 11;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 12;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 13;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 14;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        Type TypeOfT13 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        bool IsT13();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();

        T13 AsT13();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 15;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        Type TypeOfT13 { get; }

        Type TypeOfT14 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        bool IsT13();

        bool IsT14();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();

        T13 AsT13();

        T14 AsT14();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 16;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        Type TypeOfT13 { get; }

        Type TypeOfT14 { get; }

        Type TypeOfT15 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        bool IsT13();

        bool IsT14();

        bool IsT15();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();

        T13 AsT13();

        T14 AsT14();

        T15 AsT15();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 17;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        Type TypeOfT13 { get; }

        Type TypeOfT14 { get; }

        Type TypeOfT15 { get; }

        Type TypeOfT16 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        bool IsT13();

        bool IsT14();

        bool IsT15();

        bool IsT16();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();

        T13 AsT13();

        T14 AsT14();

        T15 AsT15();

        T16 AsT16();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 18;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        Type TypeOfT13 { get; }

        Type TypeOfT14 { get; }

        Type TypeOfT15 { get; }

        Type TypeOfT16 { get; }

        Type TypeOfT17 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        bool IsT13();

        bool IsT14();

        bool IsT15();

        bool IsT16();

        bool IsT17();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();

        T13 AsT13();

        T14 AsT14();

        T15 AsT15();

        T16 AsT16();

        T17 AsT17();
    }

    public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18> : IUnionType
    {
#if NETFRAMEWORK
        int Count();
#else
        public int Count() => 19;
#endif

        Type TypeOfT0 { get; }

        Type TypeOfT1 { get; }

        Type TypeOfT2 { get; }

        Type TypeOfT3 { get; }

        Type TypeOfT4 { get; }

        Type TypeOfT5 { get; }

        Type TypeOfT6 { get; }

        Type TypeOfT7 { get; }

        Type TypeOfT8 { get; }

        Type TypeOfT9 { get; }

        Type TypeOfT10 { get; }

        Type TypeOfT11 { get; }

        Type TypeOfT12 { get; }

        Type TypeOfT13 { get; }

        Type TypeOfT14 { get; }

        Type TypeOfT15 { get; }

        Type TypeOfT16 { get; }

        Type TypeOfT17 { get; }

        Type TypeOfT18 { get; }

        bool IsT0();

        bool IsT1();

        bool IsT2();

        bool IsT3();

        bool IsT4();

        bool IsT5();

        bool IsT6();

        bool IsT7();

        bool IsT8();

        bool IsT9();

        bool IsT10();

        bool IsT11();

        bool IsT12();

        bool IsT13();

        bool IsT14();

        bool IsT15();

        bool IsT16();

        bool IsT17();

        bool IsT18();

        T0 AsT0();

        T1 AsT1();

        T2 AsT2();

        T3 AsT3();

        T4 AsT4();

        T5 AsT5();

        T6 AsT6();

        T7 AsT7();

        T8 AsT8();

        T9 AsT9();

        T10 AsT10();

        T11 AsT11();

        T12 AsT12();

        T13 AsT13();

        T14 AsT14();

        T15 AsT15();

        T16 AsT16();

        T17 AsT17();

        T18 AsT18();
    }
}