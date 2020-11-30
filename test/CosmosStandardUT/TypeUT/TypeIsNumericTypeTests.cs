using System.Reflection;
using Cosmos.Reflection;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT","TypeIs.NumericType")]
    public class TypeIsNumericTypeTests
    {
        [Fact(DisplayName = "Direct type should be numeric")]
        public void DirectTypeShouldBeNumericTest()
        { 
            Types.IsNumericType(typeof(byte)).ShouldBeTrue();
            Types.IsNumericType(typeof(sbyte)).ShouldBeTrue();
            Types.IsNumericType(typeof(short)).ShouldBeTrue();
            Types.IsNumericType(typeof(ushort)).ShouldBeTrue();
            Types.IsNumericType(typeof(int)).ShouldBeTrue();
            Types.IsNumericType(typeof(uint)).ShouldBeTrue();
            Types.IsNumericType(typeof(long)).ShouldBeTrue();
            Types.IsNumericType(typeof(ulong)).ShouldBeTrue();
            Types.IsNumericType(typeof(float)).ShouldBeTrue();
            Types.IsNumericType(typeof(double)).ShouldBeTrue();
            Types.IsNumericType(typeof(decimal)).ShouldBeTrue();
        }

        [Fact(DisplayName = "Generic type should be numeric")]
        public void GenericTypeShouldBeNumericTest()
        {
            Types.IsNumericType<byte>().ShouldBeTrue();
            Types.IsNumericType<sbyte>().ShouldBeTrue();
            Types.IsNumericType<short>().ShouldBeTrue();
            Types.IsNumericType<ushort>().ShouldBeTrue();
            Types.IsNumericType<int>().ShouldBeTrue();
            Types.IsNumericType<uint>().ShouldBeTrue();
            Types.IsNumericType<long>().ShouldBeTrue();
            Types.IsNumericType<ulong>().ShouldBeTrue();
            Types.IsNumericType<float>().ShouldBeTrue();
            Types.IsNumericType<double>().ShouldBeTrue();
            Types.IsNumericType<decimal>().ShouldBeTrue();
        }

        [Fact(DisplayName = "Direct nullable type should be numeric")]
        public void DirectNullableTypeShouldBeNumericTest()
        {
            Types.IsNumericType(typeof(byte?)).ShouldBeFalse();
            Types.IsNumericType(typeof(sbyte?)).ShouldBeFalse();
            Types.IsNumericType(typeof(short?)).ShouldBeFalse();
            Types.IsNumericType(typeof(ushort?)).ShouldBeFalse();
            Types.IsNumericType(typeof(int?)).ShouldBeFalse();
            Types.IsNumericType(typeof(uint?)).ShouldBeFalse();
            Types.IsNumericType(typeof(long?)).ShouldBeFalse();
            Types.IsNumericType(typeof(ulong?)).ShouldBeFalse();
            Types.IsNumericType(typeof(float?)).ShouldBeFalse();
            Types.IsNumericType(typeof(double?)).ShouldBeFalse();
            Types.IsNumericType(typeof(decimal?)).ShouldBeFalse();
            
            Types.IsNumericType(typeof(byte?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(sbyte?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(short?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(ushort?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(int?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(uint?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(long?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(ulong?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(float?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(double?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(typeof(decimal?),TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "Generic nullable type should be numeric")]
        public void GenericNullableTypeShouldBeNumericTest()
        {
            Types.IsNumericType<byte?>().ShouldBeFalse();
            Types.IsNumericType<sbyte?>().ShouldBeFalse();
            Types.IsNumericType<short?>().ShouldBeFalse();
            Types.IsNumericType<ushort?>().ShouldBeFalse();
            Types.IsNumericType<int?>().ShouldBeFalse();
            Types.IsNumericType<uint?>().ShouldBeFalse();
            Types.IsNumericType<long?>().ShouldBeFalse();
            Types.IsNumericType<ulong?>().ShouldBeFalse();
            Types.IsNumericType<float?>().ShouldBeFalse();
            Types.IsNumericType<double?>().ShouldBeFalse();
            Types.IsNumericType<decimal?>().ShouldBeFalse();
            
            Types.IsNumericType<byte?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<sbyte?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<short?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<ushort?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<int?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<uint?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<long?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<ulong?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<float?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<double?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType<decimal?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method should be numeric test")]
        public void ExtensionMethodTest()
        {
            typeof(int).IsNumeric().ShouldBeTrue();
            typeof(int?).IsNumeric().ShouldBeFalse();
            typeof(int?).IsNumeric(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }

        [Fact(DisplayName = "Object should be numeric test")]
        public void ObjectShouldBeNumericTest()
        {
            int a = 1;
            int? b = 1;
            int? c = null;

            Types.IsNumericType(a).ShouldBeTrue();
            Types.IsNumericType(b).ShouldBeFalse();
            Types.IsNumericType(b, TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            Types.IsNumericType(c).ShouldBeFalse();
            Types.IsNumericType(c, TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }
    }
}