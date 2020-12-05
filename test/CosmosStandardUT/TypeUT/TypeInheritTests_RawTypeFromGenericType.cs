using System;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeInherit.GetRawTypeFromGenericType")]
    public class TypeInheritRawTypeFromGenericTypeTests
    {
        // entry1 --> abstract1 --> interface0
        //        --> interface2 --> interface1

        // entry2 --> base2 --> base1
        //        --> interface4[int,string] --> interface3[int]
        //                                   --> interface2 --> interface1

        // entry3 --> base4[long,long]-->base3[long]
        
        public Type Entry1 = typeof(EntryClassOne);
        public Type Entry2 = typeof(EntryClassTwo);
        public Type Entry3 = typeof(EntryClassThree);

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry1, abstract1) Test")]
        public void RawTypeFromGenericTypeWithEntryOneAndAbstractOneTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry1,typeof(AbstractLevelOne)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface4<int,string>) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceFourWithIntAndStringTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceFour<int, string>)).ShouldBe(typeof(IInterfaceFour<int, string>));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface4<string,int>) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceFourWithStringAndIntTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceFour<string, int>)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface4<>) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceFourDefinitionTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceFour<,>)).ShouldBe(typeof(IInterfaceFour<int, string>));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface3<int>) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceThreeWithIntTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceThree<int>)).ShouldBe(typeof(IInterfaceThree<int>));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface3<string>) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceThreeWithStringTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceThree<string>)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface3<>) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceThreeDefinitionTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceThree<>)).ShouldBe(typeof(IInterfaceThree<int>));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface2) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceTwoTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceTwo)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, interface1) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndInterfaceOneTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(IInterfaceOne)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, base1) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndBaseOneTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(BaseLevelOne)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry2, base2) Test")]
        public void RawTypeFromGenericTypeWithEntryTwoAndBaseTwoTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry2, typeof(BaseLevelTwo)).ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry3, base4<long,long>) Test")]
        public void RawTypeFromGenericTypeWithEntryThreeAndBaseFourWithLongAndLongTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry3, typeof(BaseLevelFour<long,long>)).ShouldBe(typeof(BaseLevelFour<long,long>));
        }
        
        [Fact(DisplayName = "TypeReflections.GetRawTypeFromGenericType(entry3, base3<long>) Test")]
        public void RawTypeFromGenericTypeWithEntryThreeAndBaseThreeWithLongTest()
        {
            TypeReflections.GetRawTypeFromGenericType(Entry3, typeof(BaseLevelThree<long>)).ShouldBe(typeof(BaseLevelThree<long>));
        }
    }
}