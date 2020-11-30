using System;
using System.Reflection;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeIs")]
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
            typeof(Tuple<int,int>).IsTupleType().ShouldBeTrue();
            typeof(ValueTuple).IsTupleType().ShouldBeTrue();
            typeof(ValueTuple<int,int>).IsTupleType().ShouldBeTrue();
            typeof(ChildTupleType).IsTupleType().ShouldBeFalse();
            typeof(ChildTupleType).IsTupleType(TypeOfOptions.Underlying).ShouldBeTrue();
            typeof(object).IsTupleType().ShouldBeFalse();
        }
    }
}