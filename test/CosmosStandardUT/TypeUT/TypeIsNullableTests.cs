using System;
using Cosmos.Reflection;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeIs.Nullable")]
    public class TypeIsNullableTests
    {
        [Fact(DisplayName = "Direct type should be nullable type test")]
        public void DirectTypeShouldBeNullTest()
        {
            Types.IsNullableType(typeof(int)).ShouldBeFalse();
            Types.IsNullableType(typeof(int?)).ShouldBeTrue();
            Types.IsNullableType(typeof(Nullable)).ShouldBeFalse();
            Types.IsNullableType(typeof(Nullable<int>)).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "Generic type should be nullable type test")]
        public void GenericTypeShouldBeNullTest()
        {
            Types.IsNullableType<int>().ShouldBeFalse();
            Types.IsNullableType<int?>().ShouldBeTrue();
            Types.IsNullableType<Nullable<int>>().ShouldBeTrue();
        }

        [Fact(DisplayName = "Object should be nullable type test")]
        public void ObjectShouldBeNullType()
        {
            int a = 0;
            int? b = 0;
            int? c = null;
            
            Types.IsNullableType(a).ShouldBeFalse();
            Types.IsNullableType(b).ShouldBeTrue();
            Types.IsNullableType(c).ShouldBeTrue();
            Types.IsNullableType(new object()).ShouldBeFalse();
        }
    }
}