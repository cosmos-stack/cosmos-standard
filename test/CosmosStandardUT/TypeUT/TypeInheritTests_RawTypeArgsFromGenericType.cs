using System;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeInherit.GetRawTypeArgsFromGenericType")]
    public class TypeInheritRawTypeArgsFromGenericTypeTests
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

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry1, abstract1) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryOneAndAbstractOneTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry1, typeof(AbstractLevelOne));

            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface4<int,string>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceFourWithIntAndStringTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceFour<int, string>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(2);
            val[0].ShouldBe(typeof(int));
            val[1].ShouldBe(typeof(string));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface4<string,int>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceFourWithStringAndIntTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceFour<string, int>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface4<>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceFourDefinitionTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceFour<,>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(2);
            val[0].ShouldBe(typeof(int));
            val[1].ShouldBe(typeof(string));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface3<int>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceThreeWithIntTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceThree<int>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(1);
            val[0].ShouldBe(typeof(int));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface3<string>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceThreeWithStringTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceThree<string>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface3<>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceThreeDefinitionTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceThree<>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(1);
            val[0].ShouldBe(typeof(int));
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface2) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceTwoTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceTwo));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, interface1) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndInterfaceOneTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(IInterfaceOne));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, base1) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndBaseOneTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(BaseLevelOne));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry2, base2) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryTwoAndBaseTwoTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry2, typeof(BaseLevelTwo));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry3, base4<long,long>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryThreeAndBaseFourWithLongAndLongTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry3, typeof(BaseLevelFour<long, long>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(2);
            val[0].ShouldBe(typeof(long));
            val[1].ShouldBe(typeof(long));
        }
        
        [Fact(DisplayName = "TypeReflections.GetRawTypeArgsFromGenericType(entry3, base3<long>) Test")]
        public void RawTypeArgsFromGenericTypeWithEntryThreeAndBaseThreeWithLongTest()
        {
            var val = TypeReflections.GetRawTypeArgsFromGenericType(Entry3, typeof(BaseLevelThree<long>));
            
            val.ShouldNotBeNull();
            val.Count.ShouldBe(1);
            val[0].ShouldBe(typeof(long));
        }
    }
}