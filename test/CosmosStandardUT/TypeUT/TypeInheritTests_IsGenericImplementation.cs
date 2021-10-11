using System;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeInherit.IsGenericImplementation")]
    public class TypeInheritGenericImplementationTests
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

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry1, abstract1) Test")]
        public void GenericImplementationWithEntryOneAndAbstractOneTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry1,typeof(AbstractLevelOne), out outType, out outArguments).ShouldBeFalse();
            
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface4<int,string>) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceFourWithIntAndStringTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceFour<int, string>), out outType, out outArguments).ShouldBeTrue();
            outType.ShouldNotBeNull();
            outType.ShouldBe(typeof(IInterfaceFour<int, string>));
            outArguments.ShouldNotBeNull();
            outArguments.ShouldNotBeEmpty();
            outArguments.Length.ShouldBe(2);
            outArguments[0].ShouldBe(typeof(int));
            outArguments[1].ShouldBe(typeof(string));
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface4<string,int>) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceFourWithStringAndIntTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceFour<string, int>), out outType, out outArguments).ShouldBeFalse();
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface4<>) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceFourDefinitionTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceFour<,>), out outType, out outArguments).ShouldBeTrue();
            outType.ShouldNotBeNull();
            outType.ShouldBe(typeof(IInterfaceFour<int, string>));
            outArguments.ShouldNotBeNull();
            outArguments.ShouldNotBeEmpty();
            outArguments.Length.ShouldBe(2);
            outArguments[0].ShouldBe(typeof(int));
            outArguments[1].ShouldBe(typeof(string));
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface3<int>) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceThreeWithIntTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceThree<int>), out outType, out outArguments).ShouldBeTrue();
            outType.ShouldNotBeNull();
            outType.ShouldBe(typeof(IInterfaceThree<int>));
            outArguments.ShouldNotBeNull();
            outArguments.ShouldNotBeEmpty();
            outArguments.Length.ShouldBe(1);
            outArguments[0].ShouldBe(typeof(int));
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface3<string>) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceThreeWithStringTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceThree<string>), out outType, out outArguments).ShouldBeFalse();
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface3<>) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceThreeDefinitionTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceThree<>), out outType, out outArguments).ShouldBeTrue();
            outType.ShouldNotBeNull();
            outType.ShouldBe(typeof(IInterfaceThree<int>));
            outArguments.ShouldNotBeNull();
            outArguments.ShouldNotBeEmpty();
            outArguments.Length.ShouldBe(1);
            outArguments[0].ShouldBe(typeof(int));
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface2) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceTwoTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceTwo), out outType, out outArguments).ShouldBeFalse();
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, interface1) Test")]
        public void GenericImplementationWithEntryTwoAndInterfaceOneTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(IInterfaceOne), out outType, out outArguments).ShouldBeFalse();
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, base1) Test")]
        public void GenericImplementationWithEntryTwoAndBaseOneTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(BaseLevelOne), out outType, out outArguments).ShouldBeFalse();
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry2, base2) Test")]
        public void GenericImplementationWithEntryTwoAndBaseTwoTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry2, typeof(BaseLevelTwo), out outType, out outArguments).ShouldBeFalse();
            outType.ShouldBeNull();
            outArguments.ShouldBeNull();
        }

        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry3, base4<long,long>) Test")]
        public void GenericImplementationWithEntryThreeAndBaseFourWithLongAndLongTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry3, typeof(BaseLevelFour<long,long>), out outType, out outArguments).ShouldBeTrue();
            outType.ShouldNotBeNull();
            outType.ShouldBe(typeof(BaseLevelFour<long,long>));
            outArguments.ShouldNotBeNull();
            outArguments.ShouldNotBeEmpty();
            outArguments.Length.ShouldBe(2);
            outArguments[0].ShouldBe(typeof(long));
            outArguments[1].ShouldBe(typeof(long));
        }
        
        [Fact(DisplayName = "TypeReflections.IsGenericImplementation(entry3, base3<long>) Test")]
        public void GenericImplementationWithEntryThreeAndBaseThreeWithLongTest()
        {
            Type outType = null;
            Type[] outArguments = null;

            TypeReflections.IsImplementationOfGenericType(Entry3, typeof(BaseLevelThree<long>), out outType, out outArguments).ShouldBeTrue();
            outType.ShouldNotBeNull();
            outType.ShouldBe(typeof(BaseLevelThree<long>));
            outArguments.ShouldNotBeNull();
            outArguments.ShouldNotBeEmpty();
            outArguments.Length.ShouldBe(1);
            outArguments[0].ShouldBe(typeof(long));
        }
    }
}