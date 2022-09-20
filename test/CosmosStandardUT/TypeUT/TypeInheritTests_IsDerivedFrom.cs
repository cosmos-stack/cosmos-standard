using System;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT;

[Trait("TypeUT", "TypeInherit.IsDerivedFrom")]
public class TypeInheritDerivedFromTests
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

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry1, abstract1) Test")]
    public void TypeDerivedFromTypeWithEntryOneAndAbstractOneTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry1, typeof(AbstractLevelOne)).ShouldBeTrue();
        TypeReflections.IsTypeDerivedFrom(Entry1, typeof(AbstractLevelOne), TypeDerivedOptions.CanAbstract).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(abstract1, interface0) Test")]
    public void TypeDerivedFromTypeWithAbstractOneAndInterfaceZeroTest()
    {
        TypeReflections.IsTypeDerivedFrom(typeof(AbstractLevelOne), typeof(IInterfaceZero)).ShouldBeFalse();
        TypeReflections.IsTypeDerivedFrom(typeof(AbstractLevelOne), typeof(IInterfaceZero), TypeDerivedOptions.CanAbstract).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface4<int,string>) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceFourWithIntAndStringTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceFour<int, string>)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface4<string,int>) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceFourWithStringAndIntTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceFour<string, int>)).ShouldBeFalse();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface4<>) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceFourDefinitionTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceFour<,>)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface3<int>) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceThreeWithIntTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceThree<int>)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface3<string>) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceThreeWithStringTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceThree<string>)).ShouldBeFalse();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface3<>) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceThreeDefinitionTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceThree<>)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface2) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceTwoTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceTwo)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, interface1) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndInterfaceOneTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(IInterfaceOne)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, base1) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndBaseOneTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(BaseLevelOne)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry2, base2) Test")]
    public void TypeDerivedFromTypeWithEntryTwoAndBaseTwoTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry2, typeof(BaseLevelTwo)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry3, base4<long,long>) Test")]
    public void TypeDerivedFromTypeWithEntryThreeAndBaseFourWithLongAndLongTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry3, typeof(BaseLevelFour<long, long>)).ShouldBeTrue();
    }

    [Fact(DisplayName = "TypeReflections.IsDerivedFrom(entry3, base3<long>) Test")]
    public void TypeDerivedFromTypeWithEntryThreeAndBaseThreeWithLongTest()
    {
        TypeReflections.IsTypeDerivedFrom(Entry3, typeof(BaseLevelThree<long>)).ShouldBeTrue();
    }
}