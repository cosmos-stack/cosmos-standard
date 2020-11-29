using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("TypeUT", "TypeConv")]
    public class TypeConvTest
    {
        [Fact(DisplayName = "Convert Nullable Type to Non-Nullable Type")]
        public void NullableTypeToNonNullableTypeTest()
        {
            TypeConv.GetNonNullableType(typeof(object)).ShouldBe(typeof(object));
            TypeConv.GetNonNullableType(null).ShouldBeNull();

            TypeConv.GetNonNullableType(typeof(byte)).ShouldBe(typeof(byte));
            TypeConv.GetNonNullableType(typeof(byte?)).ShouldBe(typeof(byte));
            TypeConv.GetNonNullableType(typeof(sbyte)).ShouldBe(typeof(sbyte));
            TypeConv.GetNonNullableType(typeof(sbyte?)).ShouldBe(typeof(sbyte));
            TypeConv.GetNonNullableType(typeof(short)).ShouldBe(typeof(short));
            TypeConv.GetNonNullableType(typeof(short?)).ShouldBe(typeof(short));
            TypeConv.GetNonNullableType(typeof(ushort)).ShouldBe(typeof(ushort));
            TypeConv.GetNonNullableType(typeof(ushort?)).ShouldBe(typeof(ushort));
            TypeConv.GetNonNullableType(typeof(int)).ShouldBe(typeof(int));
            TypeConv.GetNonNullableType(typeof(int?)).ShouldBe(typeof(int));
            TypeConv.GetNonNullableType(typeof(uint)).ShouldBe(typeof(uint));
            TypeConv.GetNonNullableType(typeof(uint?)).ShouldBe(typeof(uint));
            TypeConv.GetNonNullableType(typeof(long)).ShouldBe(typeof(long));
            TypeConv.GetNonNullableType(typeof(long?)).ShouldBe(typeof(long));
            TypeConv.GetNonNullableType(typeof(ulong)).ShouldBe(typeof(ulong));
            TypeConv.GetNonNullableType(typeof(ulong?)).ShouldBe(typeof(ulong));

            TypeConv.GetNonNullableType(typeof(float)).ShouldBe(typeof(float));
            TypeConv.GetNonNullableType(typeof(float?)).ShouldBe(typeof(float));
            TypeConv.GetNonNullableType(typeof(double)).ShouldBe(typeof(double));
            TypeConv.GetNonNullableType(typeof(double?)).ShouldBe(typeof(double));
            TypeConv.GetNonNullableType(typeof(decimal)).ShouldBe(typeof(decimal));
            TypeConv.GetNonNullableType(typeof(decimal?)).ShouldBe(typeof(decimal));

            TypeConv.GetNonNullableType(typeof(string)).ShouldBe(typeof(string));
            TypeConv.GetNonNullableType(typeof(char)).ShouldBe(typeof(char));
            TypeConv.GetNonNullableType(typeof(char?)).ShouldBe(typeof(char));
            TypeConv.GetNonNullableType(typeof(bool)).ShouldBe(typeof(bool));
            TypeConv.GetNonNullableType(typeof(bool?)).ShouldBe(typeof(bool));

            TypeConv.GetNonNullableType(typeof(DateTime)).ShouldBe(typeof(DateTime));
            TypeConv.GetNonNullableType(typeof(DateTime?)).ShouldBe(typeof(DateTime));
            TypeConv.GetNonNullableType(typeof(DateTimeOffset)).ShouldBe(typeof(DateTimeOffset));
            TypeConv.GetNonNullableType(typeof(DateTimeOffset?)).ShouldBe(typeof(DateTimeOffset));
            TypeConv.GetNonNullableType(typeof(TimeSpan)).ShouldBe(typeof(TimeSpan));
            TypeConv.GetNonNullableType(typeof(TimeSpan?)).ShouldBe(typeof(TimeSpan));

            TypeConv.GetNonNullableType(typeof(Guid)).ShouldBe(typeof(Guid));
            TypeConv.GetNonNullableType(typeof(Guid?)).ShouldBe(typeof(Guid));
            TypeConv.GetNonNullableType(typeof(ValueTuple)).ShouldBe(typeof(ValueTuple));
            TypeConv.GetNonNullableType(typeof(ValueTuple?)).ShouldBe(typeof(ValueTuple));
            TypeConv.GetNonNullableType(typeof(ValueTuple<>)).ShouldBe(typeof(ValueTuple<>));

            TypeConv.GetNonNullableType(typeof(Task)).ShouldBe(typeof(Task));
            TypeConv.GetNonNullableType(typeof(Task<>)).ShouldBe(typeof(Task<>));
            TypeConv.GetNonNullableType(typeof(ValueTask)).ShouldBe(typeof(ValueTask));
            TypeConv.GetNonNullableType(typeof(ValueTask?)).ShouldBe(typeof(ValueTask));
            TypeConv.GetNonNullableType(typeof(ValueTask<>)).ShouldBe(typeof(ValueTask<>));
        }

        [Fact(DisplayName = "Convert Nullable Type Array to Non-Nullable Type Array")]
        public void NullableTypeArrayToNonNullableTypeArrayTest()
        {
            TypeConv.GetNonNullableType(typeof(byte)).ShouldBe(typeof(byte));
            TypeConv.GetNonNullableType(typeof(byte?[])).ShouldBe(typeof(byte[]));
            TypeConv.GetNonNullableType(typeof(List<byte>)).ShouldBe(typeof(List<byte>));
            TypeConv.GetNonNullableType(typeof(List<byte?>)).ShouldBe(typeof(List<byte>));
            TypeConv.GetNonNullableType(typeof(Dictionary<string, int>)).ShouldBe(typeof(Dictionary<string, int>));
            TypeConv.GetNonNullableType(typeof(Dictionary<string, int?>)).ShouldBe(typeof(Dictionary<string, int>));
        }

        [Fact(DisplayName = "Convert Nullable Enum Type to Non-Nullable Enum Type")]
        public void NullableEnumTypeToNonNullableEnumTypeTest()
        {
            TypeConv.GetNonNullableType(typeof(Int16Enum)).ShouldBe(typeof(Int16Enum));
            TypeConv.GetNonNullableType(typeof(Int16Enum?)).ShouldBe(typeof(Int16Enum));
            TypeConv.GetNonNullableType(typeof(Int16Enum[])).ShouldBe(typeof(Int16Enum[]));
            TypeConv.GetNonNullableType(typeof(Int16Enum?[])).ShouldBe(typeof(Int16Enum[]));
            TypeConv.GetNonNullableType(typeof(List<Int16Enum>)).ShouldBe(typeof(List<Int16Enum>));
            TypeConv.GetNonNullableType(typeof(List<Int16Enum?>)).ShouldBe(typeof(List<Int16Enum>));
            TypeConv.GetNonNullableType(typeof(Dictionary<string, Int16Enum>)).ShouldBe(typeof(Dictionary<string, Int16Enum>));
            TypeConv.GetNonNullableType(typeof(Dictionary<string, Int16Enum?>)).ShouldBe(typeof(Dictionary<string, Int16Enum>));
        }
        
        [Fact(DisplayName = "Convert Nullable Type Array to Non-Nullable Type Array with interface")]
        public void NullableTypeInterfaceToNonNullableTypeInterfaceTest()
        {
            TypeConv.GetNonNullableType(typeof(IList<byte>)).ShouldBe(typeof(IList<byte>));
            TypeConv.GetNonNullableType(typeof(IList<byte?>)).ShouldBe(typeof(IList<byte>));
            TypeConv.GetNonNullableType(typeof(IDictionary<string, int>)).ShouldBe(typeof(IDictionary<string, int>));
            TypeConv.GetNonNullableType(typeof(IDictionary<string, int?>)).ShouldBe(typeof(IDictionary<string, int>));
        }

        [Fact(DisplayName = "Convert Nullable Enum Type to Non-Nullable Enum Type with interface")]
        public void NullableEnumInterfaceToNonNullableEnumInterfaceTest()
        {
            TypeConv.GetNonNullableType(typeof(IList<Int16Enum>)).ShouldBe(typeof(IList<Int16Enum>));
            TypeConv.GetNonNullableType(typeof(IList<Int16Enum?>)).ShouldBe(typeof(IList<Int16Enum>));
            TypeConv.GetNonNullableType(typeof(IDictionary<string, Int16Enum>)).ShouldBe(typeof(IDictionary<string, Int16Enum>));
            TypeConv.GetNonNullableType(typeof(IDictionary<string, Int16Enum?>)).ShouldBe(typeof(IDictionary<string, Int16Enum>));
        }
    }
}