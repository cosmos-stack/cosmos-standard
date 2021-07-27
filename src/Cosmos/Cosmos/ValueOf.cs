using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Cosmos
{
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

    public abstract class ValueOf<TVal, TMe> where TMe : ValueOf<TVal, TMe>, new()
    {
        private static readonly Func<TMe> Factory;

        static ValueOf()
        {
            Factory = ValueOfHelper.NewFactory<TVal, TMe>();
        }

        public TVal Value { get; protected set; }

        protected virtual void Validate() { }

        public static TMe From(TVal value)
        {
            var x = Factory();

            x.Value = value;

            x.Validate();

            return x;
        }

        public static TMe From(TVal value, Action<TVal> propertyValidator)
        {
            propertyValidator?.Invoke(value);

            return From(value);
        }

        protected virtual bool Equals(ValueOf<TVal, TMe> other)
        {
            return EqualityComparer<TVal>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals((ValueOf<TVal, TMe>)obj);
        }

        public override int GetHashCode() => EqualityComparer<TVal>.Default.GetHashCode(Value);

        public static bool operator ==(ValueOf<TVal, TMe> a, ValueOf<TVal, TMe> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueOf<TVal, TMe> a, ValueOf<TVal, TMe> b)
        {
            return !(a == b);
        }

        public static explicit operator TVal(ValueOf<TVal, TMe> @this)
        {
            return @this.Value;
        }

        public static explicit operator ValueOf<TVal, TMe>(TVal value)
        {
            return From(value);
        }

        public override string ToString() => Value.ToString();
    }
}