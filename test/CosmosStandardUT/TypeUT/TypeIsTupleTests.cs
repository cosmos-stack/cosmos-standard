using System;
using System.Reflection;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeIs.TupleType")]
    public class TypeIsTupleTests
    {
        [Fact(DisplayName = "Implicit value tuple test")]
        public void ImplicitValueTupleTypeTest()
        {
            Types.IsTupleType(typeof((int, int))).ShouldBeTrue();
            Types.IsTupleType(typeof((int, int, int))).ShouldBeTrue();

            Types.IsTupleType<string>().ShouldBeFalse();
        }

        [Fact(DisplayName = "Explicit value tuple test")]
        public void ExplicitValueTupleTypeTest()
        {
            Types.IsTupleType(typeof(ValueTuple)).ShouldBeTrue();
            Types.IsTupleType(typeof(ValueTuple<int>)).ShouldBeTrue();
            Types.IsTupleType(typeof(ValueTuple<int, int>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "Explicit tuple test")]
        public void ExplicitTupleTypeTest()
        {
            Types.IsTupleType(typeof(Tuple)).ShouldBeTrue();
            Types.IsTupleType(typeof(Tuple<int>)).ShouldBeTrue();
            Types.IsTupleType(typeof(Tuple<int, int>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "ParentClass should be Tuple test")]
        public void ParentShouldBeTupleTest()
        {
            Types.IsTupleType<ChildTupleType>().ShouldBeFalse();
            Types.IsTupleType<ChildTupleType>(TypeOfOptions.Underlying).ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method should be Tuple test")]
        public void ExtensionMethodTest()
        {
            typeof((int, int)).IsTupleType().ShouldBeTrue();
            typeof(Tuple).IsTupleType().ShouldBeTrue();
            typeof(Tuple<int, int>).IsTupleType().ShouldBeTrue();
            typeof(ValueTuple).IsTupleType().ShouldBeTrue();
            typeof(ValueTuple<int, int>).IsTupleType().ShouldBeTrue();
            typeof(ChildTupleType).IsTupleType().ShouldBeFalse();
            typeof(ChildTupleType).IsTupleType(TypeOfOptions.Underlying).ShouldBeTrue();
            typeof(object).IsTupleType().ShouldBeFalse();
        }

        [Fact(DisplayName = "Object should be Tuple test")]
        public void ObjectShouldBeTupleTest()
        {
            var tuple = Tuple.Create(1, 2, 3);
            var valueTuple = ValueTuple.Create(1, 2, 3);
            var childTuple = new ChildTupleType(1, 2);
            Types.IsTupleType(tuple).ShouldBeTrue();
            Types.IsTupleType(valueTuple).ShouldBeTrue();
            Types.IsTupleType(childTuple).ShouldBeFalse();
            Types.IsTupleType(childTuple, TypeOfOptions.Underlying).ShouldBeTrue();
            Types.IsTupleType(123).ShouldBeFalse();
            Types.IsTupleType((object) null).ShouldBeFalse();
            Types.IsTupleType(null).ShouldBeFalse();
        }

        [Fact(DisplayName = "Nullable Tuple test")]
        public void NullableTupleTest()
        {
            Types.IsTupleType(typeof((int, int))).ShouldBeTrue();
            Types.IsTupleType(typeof((int, int, int))).ShouldBeTrue();
            Types.IsTupleType(typeof((int, int)?)).ShouldBeFalse();
            Types.IsTupleType(typeof((int, int, int)?)).ShouldBeFalse();
            Types.IsTupleType(typeof((int, int)?), isOptions: TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsTupleType(typeof((int, int, int)?), isOptions: TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }
    }
}