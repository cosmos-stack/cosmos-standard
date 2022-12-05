namespace Cosmos;

/// <summary>
/// An interface for UnionType <br />
/// 联合类型接口
/// </summary>
public interface IUnionType
{
    /// <summary>
    /// Gets value of this UnionType instance. <br />
    /// 获取联合类型实例的值
    /// </summary>
    object Value { get; }

    /// <summary>
    /// Gets index of this UnionType instance. <br />
    /// 获取联合类型中值所在的索引
    /// </summary>
    int Index { get; }
}

/// <summary>
/// An interface for UnionType`1 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
public interface IUnionType<out T0> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 1;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();
}

/// <summary>
/// An interface for UnionType`2 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
public interface IUnionType<out T0, out T1> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 2;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();
}

/// <summary>
/// An interface for UnionType`3 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public interface IUnionType<out T0, out T1, out T2> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 3;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();
}

/// <summary>
/// An interface for UnionType`4 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 4;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();
}

/// <summary>
/// An interface for UnionType`5 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 5;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();
}

/// <summary>
/// An interface for UnionType`6 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 6;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();
}

/// <summary>
/// An interface for UnionType`7 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 7;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();
}

/// <summary>
/// An interface for UnionType`8 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 8;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();
}

/// <summary>
/// An interface for UnionType`9 <br />
/// 联合类型接口
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 9;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();
}

/// <summary>
/// An interface for UnionType`10 <br />
/// 联合类型接口
/// </summary>
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
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 10;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();
}

/// <summary>
/// An interface for UnionType`11 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 11;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();
}

/// <summary>
/// An interface for UnionType`12 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 12;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();
}

/// <summary>
/// An interface for UnionType`13 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 13;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();
}

/// <summary>
/// An interface for UnionType`14 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 14;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Type 14 <br />
    /// 类型 14
    /// </summary>
    public Type TypeOfT13 => typeof(T13);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 14 <br />
    /// 标记是否为类型 14
    /// </summary>
    /// <returns></returns>
    bool IsT13();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();

    /// <summary>
    /// Convert the Union Type to type 14 <br />
    /// 转换为类型 14
    /// </summary>
    /// <returns></returns>
    T13 AsT13();
}

/// <summary>
/// An interface for UnionType`15 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 15;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Type 14 <br />
    /// 类型 14
    /// </summary>
    public Type TypeOfT13 => typeof(T13);

    /// <summary>
    /// Type 15 <br />
    /// 类型 15
    /// </summary>
    public Type TypeOfT14 => typeof(T14);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 14 <br />
    /// 标记是否为类型 14
    /// </summary>
    /// <returns></returns>
    bool IsT13();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 15 <br />
    /// 标记是否为类型 15
    /// </summary>
    /// <returns></returns>
    bool IsT14();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();

    /// <summary>
    /// Convert the Union Type to type 14 <br />
    /// 转换为类型 14
    /// </summary>
    /// <returns></returns>
    T13 AsT13();

    /// <summary>
    /// Convert the Union Type to type 15 <br />
    /// 转换为类型 15
    /// </summary>
    /// <returns></returns>
    T14 AsT14();
}

/// <summary>
/// An interface for UnionType`16 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="T15"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 16;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Type 14 <br />
    /// 类型 14
    /// </summary>
    public Type TypeOfT13 => typeof(T13);

    /// <summary>
    /// Type 15 <br />
    /// 类型 15
    /// </summary>
    public Type TypeOfT14 => typeof(T14);

    /// <summary>
    /// Type 16 <br />
    /// 类型 16
    /// </summary>
    public Type TypeOfT15 => typeof(T15);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 14 <br />
    /// 标记是否为类型 14
    /// </summary>
    /// <returns></returns>
    bool IsT13();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 15 <br />
    /// 标记是否为类型 15
    /// </summary>
    /// <returns></returns>
    bool IsT14();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 16 <br />
    /// 标记是否为类型 16
    /// </summary>
    /// <returns></returns>
    bool IsT15();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();

    /// <summary>
    /// Convert the Union Type to type 14 <br />
    /// 转换为类型 14
    /// </summary>
    /// <returns></returns>
    T13 AsT13();

    /// <summary>
    /// Convert the Union Type to type 15 <br />
    /// 转换为类型 15
    /// </summary>
    /// <returns></returns>
    T14 AsT14();

    /// <summary>
    /// Convert the Union Type to type 16 <br />
    /// 转换为类型 16
    /// </summary>
    /// <returns></returns>
    T15 AsT15();
}

/// <summary>
/// An interface for UnionType`17 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="T15"></typeparam>
/// <typeparam name="T16"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 17;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Type 14 <br />
    /// 类型 14
    /// </summary>
    public Type TypeOfT13 => typeof(T13);

    /// <summary>
    /// Type 15 <br />
    /// 类型 15
    /// </summary>
    public Type TypeOfT14 => typeof(T14);

    /// <summary>
    /// Type 16 <br />
    /// 类型 16
    /// </summary>
    public Type TypeOfT15 => typeof(T15);

    /// <summary>
    /// Type 17 <br />
    /// 类型 17
    /// </summary>
    public Type TypeOfT16 => typeof(T16);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 14 <br />
    /// 标记是否为类型 14
    /// </summary>
    /// <returns></returns>
    bool IsT13();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 15 <br />
    /// 标记是否为类型 15
    /// </summary>
    /// <returns></returns>
    bool IsT14();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 16 <br />
    /// 标记是否为类型 16
    /// </summary>
    /// <returns></returns>
    bool IsT15();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 17 <br />
    /// 标记是否为类型 17
    /// </summary>
    /// <returns></returns>
    bool IsT16();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();

    /// <summary>
    /// Convert the Union Type to type 14 <br />
    /// 转换为类型 14
    /// </summary>
    /// <returns></returns>
    T13 AsT13();

    /// <summary>
    /// Convert the Union Type to type 15 <br />
    /// 转换为类型 15
    /// </summary>
    /// <returns></returns>
    T14 AsT14();

    /// <summary>
    /// Convert the Union Type to type 16 <br />
    /// 转换为类型 16
    /// </summary>
    /// <returns></returns>
    T15 AsT15();

    /// <summary>
    /// Convert the Union Type to type 17 <br />
    /// 转换为类型 17
    /// </summary>
    /// <returns></returns>
    T16 AsT16();
}

/// <summary>
/// An interface for UnionType`18 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="T15"></typeparam>
/// <typeparam name="T16"></typeparam>
/// <typeparam name="T17"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 18;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Type 14 <br />
    /// 类型 14
    /// </summary>
    public Type TypeOfT13 => typeof(T13);

    /// <summary>
    /// Type 15 <br />
    /// 类型 15
    /// </summary>
    public Type TypeOfT14 => typeof(T14);

    /// <summary>
    /// Type 16 <br />
    /// 类型 16
    /// </summary>
    public Type TypeOfT15 => typeof(T15);

    /// <summary>
    /// Type 17 <br />
    /// 类型 17
    /// </summary>
    public Type TypeOfT16 => typeof(T16);

    /// <summary>
    /// Type 18 <br />
    /// 类型 18
    /// </summary>
    public Type TypeOfT17 => typeof(T17);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 14 <br />
    /// 标记是否为类型 14
    /// </summary>
    /// <returns></returns>
    bool IsT13();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 15 <br />
    /// 标记是否为类型 15
    /// </summary>
    /// <returns></returns>
    bool IsT14();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 16 <br />
    /// 标记是否为类型 16
    /// </summary>
    /// <returns></returns>
    bool IsT15();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 17 <br />
    /// 标记是否为类型 17
    /// </summary>
    /// <returns></returns>
    bool IsT16();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 18 <br />
    /// 标记是否为类型 18
    /// </summary>
    /// <returns></returns>
    bool IsT17();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();

    /// <summary>
    /// Convert the Union Type to type 14 <br />
    /// 转换为类型 14
    /// </summary>
    /// <returns></returns>
    T13 AsT13();

    /// <summary>
    /// Convert the Union Type to type 15 <br />
    /// 转换为类型 15
    /// </summary>
    /// <returns></returns>
    T14 AsT14();

    /// <summary>
    /// Convert the Union Type to type 16 <br />
    /// 转换为类型 16
    /// </summary>
    /// <returns></returns>
    T15 AsT15();

    /// <summary>
    /// Convert the Union Type to type 17 <br />
    /// 转换为类型 17
    /// </summary>
    /// <returns></returns>
    T16 AsT16();

    /// <summary>
    /// Convert the Union Type to type 18 <br />
    /// 转换为类型 18
    /// </summary>
    /// <returns></returns>
    T17 AsT17();
}

/// <summary>
/// An interface for UnionType`19 <br />
/// 联合类型接口
/// </summary>
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
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="T15"></typeparam>
/// <typeparam name="T16"></typeparam>
/// <typeparam name="T17"></typeparam>
/// <typeparam name="T18"></typeparam>
public interface IUnionType<out T0, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18> : IUnionType
{
    /// <summary>
    /// Count <br />
    /// 联合类型所包含的类型种类数
    /// </summary>
    /// <returns></returns>
    public int Count() => 19;

    /// <summary>
    /// Type 1 <br />
    /// 类型 1
    /// </summary>
    public Type TypeOfT0 => typeof(T0);

    /// <summary>
    /// Type 2 <br />
    /// 类型 2
    /// </summary>
    public Type TypeOfT1 => typeof(T1);

    /// <summary>
    /// Type 3 <br />
    /// 类型 3
    /// </summary>
    public Type TypeOfT2 => typeof(T2);

    /// <summary>
    /// Type 4 <br />
    /// 类型 4
    /// </summary>
    public Type TypeOfT3 => typeof(T3);

    /// <summary>
    /// Type 5 <br />
    /// 类型 5
    /// </summary>
    public Type TypeOfT4 => typeof(T4);

    /// <summary>
    /// Type 6 <br />
    /// 类型 6
    /// </summary>
    public Type TypeOfT5 => typeof(T5);

    /// <summary>
    /// Type 7 <br />
    /// 类型 7
    /// </summary>
    public Type TypeOfT6 => typeof(T6);

    /// <summary>
    /// Type 8 <br />
    /// 类型 8
    /// </summary>
    public Type TypeOfT7 => typeof(T7);

    /// <summary>
    /// Type 9 <br />
    /// 类型 9
    /// </summary>
    public Type TypeOfT8 => typeof(T8);

    /// <summary>
    /// Type 10 <br />
    /// 类型 10
    /// </summary>
    public Type TypeOfT9 => typeof(T9);

    /// <summary>
    /// Type 11 <br />
    /// 类型 11
    /// </summary>
    public Type TypeOfT10 => typeof(T10);

    /// <summary>
    /// Type 12 <br />
    /// 类型 12
    /// </summary>
    public Type TypeOfT11 => typeof(T11);

    /// <summary>
    /// Type 13 <br />
    /// 类型 13
    /// </summary>
    public Type TypeOfT12 => typeof(T12);

    /// <summary>
    /// Type 14 <br />
    /// 类型 14
    /// </summary>
    public Type TypeOfT13 => typeof(T13);

    /// <summary>
    /// Type 15 <br />
    /// 类型 15
    /// </summary>
    public Type TypeOfT14 => typeof(T14);

    /// <summary>
    /// Type 16 <br />
    /// 类型 16
    /// </summary>
    public Type TypeOfT15 => typeof(T15);

    /// <summary>
    /// Type 17 <br />
    /// 类型 17
    /// </summary>
    public Type TypeOfT16 => typeof(T16);

    /// <summary>
    /// Type 18 <br />
    /// 类型 18
    /// </summary>
    public Type TypeOfT17 => typeof(T17);

    /// <summary>
    /// Type 19 <br />
    /// 类型 19
    /// </summary>
    public Type TypeOfT18 => typeof(T18);

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 1 <br />
    /// 标记是否为类型 1
    /// </summary>
    /// <returns></returns>
    bool IsT0();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 2 <br />
    /// 标记是否为类型 2
    /// </summary>
    /// <returns></returns>
    bool IsT1();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 3 <br />
    /// 标记是否为类型 3
    /// </summary>
    /// <returns></returns>
    bool IsT2();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 4 <br />
    /// 标记是否为类型 4
    /// </summary>
    /// <returns></returns>
    bool IsT3();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 5 <br />
    /// 标记是否为类型 5
    /// </summary>
    /// <returns></returns>
    bool IsT4();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 6 <br />
    /// 标记是否为类型 6
    /// </summary>
    /// <returns></returns>
    bool IsT5();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 7 <br />
    /// 标记是否为类型 7
    /// </summary>
    /// <returns></returns>
    bool IsT6();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 8 <br />
    /// 标记是否为类型 8
    /// </summary>
    /// <returns></returns>
    bool IsT7();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 9 <br />
    /// 标记是否为类型 9
    /// </summary>
    /// <returns></returns>
    bool IsT8();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 10 <br />
    /// 标记是否为类型 10
    /// </summary>
    /// <returns></returns>
    bool IsT9();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 11 <br />
    /// 标记是否为类型 11
    /// </summary>
    /// <returns></returns>
    bool IsT10();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 12 <br />
    /// 标记是否为类型 12
    /// </summary>
    /// <returns></returns>
    bool IsT11();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 13 <br />
    /// 标记是否为类型 13
    /// </summary>
    /// <returns></returns>
    bool IsT12();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 14 <br />
    /// 标记是否为类型 14
    /// </summary>
    /// <returns></returns>
    bool IsT13();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 15 <br />
    /// 标记是否为类型 15
    /// </summary>
    /// <returns></returns>
    bool IsT14();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 16 <br />
    /// 标记是否为类型 16
    /// </summary>
    /// <returns></returns>
    bool IsT15();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 17 <br />
    /// 标记是否为类型 17
    /// </summary>
    /// <returns></returns>
    bool IsT16();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 18 <br />
    /// 标记是否为类型 18
    /// </summary>
    /// <returns></returns>
    bool IsT17();

    /// <summary>
    /// Mark whether the actual type of the Union Type is type 19 <br />
    /// 标记是否为类型 19
    /// </summary>
    /// <returns></returns>
    bool IsT18();

    /// <summary>
    /// Convert the Union Type to type 1 <br />
    /// 转换为类型 1
    /// </summary>
    /// <returns></returns>
    T0 AsT0();

    /// <summary>
    /// Convert the Union Type to type 2 <br />
    /// 转换为类型 2
    /// </summary>
    /// <returns></returns>
    T1 AsT1();

    /// <summary>
    /// Convert the Union Type to type 3 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T2 AsT2();

    /// <summary>
    /// Convert the Union Type to type 4 <br />
    /// 转换为类型 3
    /// </summary>
    /// <returns></returns>
    T3 AsT3();

    /// <summary>
    /// Convert the Union Type to type 5 <br />
    /// 转换为类型 5
    /// </summary>
    /// <returns></returns>
    T4 AsT4();

    /// <summary>
    /// Convert the Union Type to type 6 <br />
    /// 转换为类型 6
    /// </summary>
    /// <returns></returns>
    T5 AsT5();

    /// <summary>
    /// Convert the Union Type to type 7 <br />
    /// 转换为类型 7
    /// </summary>
    /// <returns></returns>
    T6 AsT6();

    /// <summary>
    /// Convert the Union Type to type 8 <br />
    /// 转换为类型 8
    /// </summary>
    /// <returns></returns>
    T7 AsT7();

    /// <summary>
    /// Convert the Union Type to type 9 <br />
    /// 转换为类型 9
    /// </summary>
    /// <returns></returns>
    T8 AsT8();

    /// <summary>
    /// Convert the Union Type to type 10 <br />
    /// 转换为类型 10
    /// </summary>
    /// <returns></returns>
    T9 AsT9();

    /// <summary>
    /// Convert the Union Type to type 11 <br />
    /// 转换为类型 11
    /// </summary>
    /// <returns></returns>
    T10 AsT10();

    /// <summary>
    /// Convert the Union Type to type 12 <br />
    /// 转换为类型 12
    /// </summary>
    /// <returns></returns>
    T11 AsT11();

    /// <summary>
    /// Convert the Union Type to type 13 <br />
    /// 转换为类型 13
    /// </summary>
    /// <returns></returns>
    T12 AsT12();

    /// <summary>
    /// Convert the Union Type to type 14 <br />
    /// 转换为类型 14
    /// </summary>
    /// <returns></returns>
    T13 AsT13();

    /// <summary>
    /// Convert the Union Type to type 15 <br />
    /// 转换为类型 15
    /// </summary>
    /// <returns></returns>
    T14 AsT14();

    /// <summary>
    /// Convert the Union Type to type 16 <br />
    /// 转换为类型 16
    /// </summary>
    /// <returns></returns>
    T15 AsT15();

    /// <summary>
    /// Convert the Union Type to type 17 <br />
    /// 转换为类型 17
    /// </summary>
    /// <returns></returns>
    T16 AsT16();

    /// <summary>
    /// Convert the Union Type to type 18 <br />
    /// 转换为类型 18
    /// </summary>
    /// <returns></returns>
    T17 AsT17();

    /// <summary>
    /// Convert the Union Type to type 19 <br />
    /// 转换为类型 19
    /// </summary>
    /// <returns></returns>
    T18 AsT18();
}