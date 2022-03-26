using System;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeInherit.IsBasedOn")]
    public class TypeInheritBasedOnTests
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

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry1, abstract1) Test")]
        public void TypeBasedOnTypeWithEntryOneAndAbstractOneTest()
        {
            TypeReflections.IsTypeBasedOn(Entry1, typeof(AbstractLevelOne)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface4<int,string>) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceFourWithIntAndStringTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceFour<int, string>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface4<string,int>) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceFourWithStringAndIntTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceFour<string, int>)).ShouldBeFalse();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface4<>) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceFourDefinitionTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceFour<,>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface3<int>) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceThreeWithIntTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceThree<int>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface3<string>) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceThreeWithStringTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceThree<string>)).ShouldBeFalse();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface3<>) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceThreeDefinitionTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceThree<>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface2) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceTwoTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceTwo)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, interface1) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndInterfaceOneTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(IInterfaceOne)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, base1) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndBaseOneTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(BaseLevelOne)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry2, base2) Test")]
        public void TypeBasedOnTypeWithEntryTwoAndBaseTwoTest()
        {
            TypeReflections.IsTypeBasedOn(Entry2, typeof(BaseLevelTwo)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry3, base4<long,long>) Test")]
        public void TypeBasedOnTypeWithEntryThreeAndBaseFourWithLongAndLongTest()
        {
            TypeReflections.IsTypeBasedOn(Entry3, typeof(BaseLevelFour<long, long>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsBasedOn(entry3, base3<long>) Test")]
        public void TypeBasedOnTypeWithEntryThreeAndBaseThreeWithLongTest()
        {
            TypeReflections.IsTypeBasedOn(Entry3, typeof(BaseLevelThree<long>)).ShouldBeTrue();
        }
    }
}