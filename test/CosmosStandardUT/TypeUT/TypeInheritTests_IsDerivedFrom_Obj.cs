using System;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeInherit.IsObjDerivedFrom")]
    public class TypeInheritObjDerivedFromTests
    {
        // entry1 --> abstract1 --> interface0
        //        --> interface2 --> interface1

        // entry2 --> base2 --> base1
        //        --> interface4[int,string] --> interface3[int]
        //                                   --> interface2 --> interface1

        // entry3 --> base4[long,long]-->base3[long]

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry1, abstract1) Test")]
        public void ObjectDerivedFromTypeWithEntryOneAndAbstractOneTest()
        {
            var model1 = new EntryClassOne();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(AbstractLevelOne)).ShouldBeTrue();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(AbstractLevelOne)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(abstract1, interface0) Test")]
        public void ObjectDerivedFromTypeWithAbstractOneAndInterfaceZeroTest()
        {
            var model1 = new EntryClassOne();
            var model2 = (AbstractLevelOne) model1;

            TypeReflections.IsObjectDerivedFrom(model2, typeof(AbstractLevelOne)).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(AbstractLevelOne), derivedOptions: TypeDerivedOptions.CanAbstract).ShouldBeTrue();
            
            TypeReflections.IsObjectDerivedFrom(model2, typeof(IInterfaceZero)).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(IInterfaceZero), derivedOptions: TypeDerivedOptions.CanAbstract).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(null, interface0) Test")]
        public void ObjectDerivedFromTypeWithNullAndInterfaceZeroTest()
        {
            var model1 = new EntryClassOne();
            var model2 = (AbstractLevelOne) model1;
            model2 = null;
            model1 = null;

            TypeReflections.IsObjectDerivedFrom(model1, typeof(AbstractLevelOne)).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(AbstractLevelOne)).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(AbstractLevelOne), derivedOptions: TypeDerivedOptions.CanAbstract).ShouldBeFalse();
            
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceZero)).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(IInterfaceZero)).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(IInterfaceZero), derivedOptions: TypeDerivedOptions.CanAbstract).ShouldBeFalse();

            TypeReflections.IsObjectDerivedFrom(model1, typeof(AbstractLevelOne), TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(AbstractLevelOne), TypeIsOptions.IgnoreNullable).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(AbstractLevelOne), TypeIsOptions.IgnoreNullable, TypeDerivedOptions.CanAbstract).ShouldBeTrue();
            
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceZero), TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(IInterfaceZero), TypeIsOptions.IgnoreNullable).ShouldBeFalse();
            TypeReflections.IsObjectDerivedFrom(model2, typeof(IInterfaceZero), TypeIsOptions.IgnoreNullable, TypeDerivedOptions.CanAbstract).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface4<int,string>) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceFourWithIntAndStringTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceFour<int, string>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface4<string,int>) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceFourWithStringAndIntTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceFour<string, int>)).ShouldBeFalse();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface4<>) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceFourDefinitionTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceFour<,>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface3<int>) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceThreeWithIntTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceThree<int>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface3<string>) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceThreeWithStringTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceThree<string>)).ShouldBeFalse();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface3<>) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceThreeDefinitionTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceThree<>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface2) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceTwoTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceTwo)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, interface1) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndInterfaceOneTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(IInterfaceOne)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, base1) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndBaseOneTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(BaseLevelOne)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry2, base2) Test")]
        public void ObjectDerivedFromTypeWithEntryTwoAndBaseTwoTest()
        {
            var model1 = new EntryClassTwo();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(BaseLevelTwo)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry3, base4<long,long>) Test")]
        public void ObjectDerivedFromTypeWithEntryThreeAndBaseFourWithLongAndLongTest()
        {
            var model1 = new EntryClassThree();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(BaseLevelFour<long, long>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "TypeReflections.IsObjDerivedFrom(entry3, base3<long>) Test")]
        public void ObjectDerivedFromTypeWithEntryThreeAndBaseThreeWithLongTest()
        {
            var model1 = new EntryClassThree();
            TypeReflections.IsObjectDerivedFrom(model1, typeof(BaseLevelThree<long>)).ShouldBeTrue();
        }
    }
}