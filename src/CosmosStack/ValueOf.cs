using System.Linq.Expressions;
using System.Reflection;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Cosmos;

internal static class ValueOfHelper
{
    private static ConstructorInfo GetDefaultConstructor<TVal, TMe>() where TMe : ValueOf<TVal, TMe>, new()
        => typeof(TMe).GetTypeInfo().DeclaredConstructors.First();

    private static LambdaExpression CreateLambda<TValue, TThis>(ConstructorInfo ctor) where TThis : ValueOf<TValue, TThis>, new()
    {
        var argsExp = Array.Empty<Expression>();
        var newExp = Expression.New(ctor, argsExp);
        return Expression.Lambda(typeof(Func<TThis>), newExp);
    }

    public static Func<TThis> NewFactory<TValue, TThis>() where TThis : ValueOf<TValue, TThis>, new()
    {
        var ctor = GetDefaultConstructor<TValue, TThis>();
        var lambda = CreateLambda<TValue, TThis>(ctor);
        return (Func<TThis>)lambda.Compile();
    }
}

/// <summary>
/// A value shortcut for object <br />
/// 通过继承该抽象类，获得一种直接获得对象的值的捷径
/// </summary>
/// <typeparam name="TVal"></typeparam>
/// <typeparam name="TMe"></typeparam>
public abstract class ValueOf<TVal, TMe> where TMe : ValueOf<TVal, TMe>, new()
{
    private static readonly Func<TMe> Factory;

    static ValueOf()
    {
        Factory = ValueOfHelper.NewFactory<TVal, TMe>();
    }

    /// <summary>
    /// Get value <br />
    /// 获得值
    /// </summary>
    public TVal? Value { get; protected set; }

    /// <summary>
    /// Validate <br />
    /// 验证
    /// </summary>
    protected virtual void Validate() { }

    /// <summary>
    /// Create a new instance of <see cref="ValueOf{TVal,TMe}"/> <br />
    /// 快速构建一个新的 <see cref="ValueOf{TVal,TMe}"/> 实例
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TMe From(TVal? value)
    {
        var x = Factory();

        x.Value = value;

        x.Validate();

        return x;
    }

    /// <summary>
    /// Create a new instance of <see cref="ValueOf{TVal,TMe}"/> <br />
    /// 快速构建一个新的 <see cref="ValueOf{TVal,TMe}"/> 实例，并使用给定的验证器进行值验证
    /// </summary>
    /// <param name="value"></param>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static TMe From(TVal? value, Action<TVal?>? propertyValidator)
    {
        propertyValidator?.Invoke(value);

        return From(value);
    }

    /// <summary>
    /// Equals <br />
    /// 相等
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    protected virtual bool Equals(ValueOf<TVal, TMe>? other)
    {
        var val = other is null ? default : other.Value;
        return EqualityComparer<TVal>.Default.Equals(Value, val);
    }

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj.GetType() == GetType() && Equals((ValueOf<TVal, TMe>)obj);
    }

    /// <summary>Serves as the default hash function.</summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => Value is null ? 0 : EqualityComparer<TVal>.Default.GetHashCode(Value);

    public static bool operator ==(ValueOf<TVal, TMe>? a, ValueOf<TVal, TMe>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueOf<TVal, TMe>? a, ValueOf<TVal, TMe>? b)
    {
        return !(a == b);
    }

    public static explicit operator TVal?(ValueOf<TVal, TMe> @this)
    {
        return @this.Value;
    }

    public static explicit operator ValueOf<TVal, TMe>(TVal? value)
    {
        return From(value);
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Value?.ToString() ?? string.Empty;
}