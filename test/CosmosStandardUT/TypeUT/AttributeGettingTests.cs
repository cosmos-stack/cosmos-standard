using System;
using System.Linq;
using System.Reflection;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

// ReSharper disable PossibleMultipleEnumeration

namespace CosmosStandardUT.TypeUT;

[Trait("TypeUT", "AttributeGetting")]
public class AttributeGettingTests
{
    [Fact(DisplayName = "Direct type getting attribute test")]
    public void DirectTypeGettingAttributeTest()
    {
        var type = typeof(NormalWithAttrClass);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);

        TypeReflections.GetAttribute(type, one).ShouldNotBeNull();
        TypeReflections.GetAttribute(type, two).ShouldBeNull();
        TypeReflections.GetAttribute(type, three).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Generic type getting attribute test")]
    public void GenericTypeGettingAttributeTest()
    {
        var type = typeof(NormalWithAttrClass);

        TypeReflections.GetAttribute<ModelOneAttribute>(type).ShouldNotBeNull();
        TypeReflections.GetAttribute<ModelTwoAttribute>(type).ShouldBeNull();
        TypeReflections.GetAttribute<ModelThreeAttribute>(type).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Direct type getting attribute inherit test")]
    public void DirectTypeGettingAttributeInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);
        var four = typeof(ModelFourAttribute);

        TypeReflections.GetAttribute(type, one).ShouldBeNull();
        TypeReflections.GetAttribute(type, two).ShouldBeNull();
        TypeReflections.GetAttribute(type, three).ShouldBeNull();
        TypeReflections.GetAttribute(type, four).ShouldNotBeNull();

        Assert.Throws<AmbiguousMatchException>(() => TypeReflections.GetAttribute(type, one, ReflectionOptions.Inherit));
        TypeReflections.GetAttribute(type, one, ReflectionOptions.Inherit, ReflectionAmbiguousOptions.IgnoreAmbiguous).ShouldNotBeNull();
        TypeReflections.GetAttribute(type, two, ReflectionOptions.Inherit).ShouldBeNull();
        TypeReflections.GetAttribute(type, three, ReflectionOptions.Inherit).ShouldNotBeNull();
        TypeReflections.GetAttribute(type, four, ReflectionOptions.Inherit).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Generic type getting attribute inherit test")]
    public void GenericTypeGettingAttributeInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);

        TypeReflections.GetAttribute<ModelOneAttribute>(type).ShouldBeNull();
        TypeReflections.GetAttribute<ModelTwoAttribute>(type).ShouldBeNull();
        TypeReflections.GetAttribute<ModelThreeAttribute>(type).ShouldBeNull();
        TypeReflections.GetAttribute<ModelFourAttribute>(type).ShouldNotBeNull();

        Assert.Throws<AmbiguousMatchException>(() => TypeReflections.GetAttribute<ModelOneAttribute>(type, ReflectionOptions.Inherit));
        TypeReflections.GetAttribute<ModelOneAttribute>(type, ReflectionOptions.Inherit, ReflectionAmbiguousOptions.IgnoreAmbiguous).ShouldNotBeNull();
        TypeReflections.GetAttribute<ModelTwoAttribute>(type, ReflectionOptions.Inherit).ShouldBeNull();
        TypeReflections.GetAttribute<ModelThreeAttribute>(type, ReflectionOptions.Inherit).ShouldNotBeNull();
        TypeReflections.GetAttribute<ModelFourAttribute>(type, ReflectionOptions.Inherit).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Direct type getting attributes test")]
    public void DirectTypeGettingAttributesTest()
    {
        var type = typeof(NormalWithAttrClass);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);

        var val1 = TypeReflections.GetAttributes(type, one);
        var val2 = TypeReflections.GetAttributes(type, two);
        var val3 = TypeReflections.GetAttributes(type, three);

        val1.ShouldNotBeEmpty();
        val2.ShouldBeEmpty();
        val3.ShouldNotBeEmpty();

        val1.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);
    }

    [Fact(DisplayName = "Generic type getting attributes test")]
    public void GenericTypeGettingAttributesTest()
    {
        var type = typeof(NormalWithAttrClass);

        var val1 = TypeReflections.GetAttributes<ModelOneAttribute>(type);
        var val2 = TypeReflections.GetAttributes<ModelTwoAttribute>(type);
        var val3 = TypeReflections.GetAttributes<ModelThreeAttribute>(type);

        val1.ShouldNotBeEmpty();
        val2.ShouldBeEmpty();
        val3.ShouldNotBeEmpty();

        val1.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);
    }

    [Fact(DisplayName = "Direct type getting attributes inherit test")]
    public void DirectTypeGettingAttributesInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);
        var four = typeof(ModelFourAttribute);

        var val1 = TypeReflections.GetAttributes(type, one);
        var val2 = TypeReflections.GetAttributes(type, two);
        var val3 = TypeReflections.GetAttributes(type, three);
        var val4 = TypeReflections.GetAttributes(type, four);

        val1.ShouldBeEmpty();
        val2.ShouldBeEmpty();
        val3.ShouldBeEmpty();
        val4.ShouldNotBeEmpty();

        val4.Count().ShouldBe(1);

        val1 = TypeReflections.GetAttributes(type, one, ReflectionOptions.Inherit);
        val2 = TypeReflections.GetAttributes(type, two, ReflectionOptions.Inherit);
        val3 = TypeReflections.GetAttributes(type, three, ReflectionOptions.Inherit);
        val4 = TypeReflections.GetAttributes(type, four, ReflectionOptions.Inherit);

        val1.ShouldNotBeEmpty();
        val2.ShouldBeEmpty();
        val3.ShouldNotBeEmpty();
        val4.ShouldNotBeEmpty();

        val1.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);
        val4.Count().ShouldBe(1);
    }

    [Fact(DisplayName = "Generic type getting attributes inherit test")]
    public void GenericTypeGettingAttributesInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);

        var val1 = TypeReflections.GetAttributes<ModelOneAttribute>(type);
        var val2 = TypeReflections.GetAttributes<ModelTwoAttribute>(type);
        var val3 = TypeReflections.GetAttributes<ModelThreeAttribute>(type);
        var val4 = TypeReflections.GetAttributes<ModelFourAttribute>(type);

        val1.ShouldBeEmpty();
        val2.ShouldBeEmpty();
        val3.ShouldBeEmpty();
        val4.ShouldNotBeEmpty();

        val4.Count().ShouldBe(1);

        val1 = TypeReflections.GetAttributes<ModelOneAttribute>(type, ReflectionOptions.Inherit);
        val2 = TypeReflections.GetAttributes<ModelTwoAttribute>(type, ReflectionOptions.Inherit);
        val3 = TypeReflections.GetAttributes<ModelThreeAttribute>(type, ReflectionOptions.Inherit);
        val4 = TypeReflections.GetAttributes<ModelFourAttribute>(type, ReflectionOptions.Inherit);

        val1.ShouldNotBeEmpty();
        val2.ShouldBeEmpty();
        val3.ShouldNotBeEmpty();
        val4.ShouldNotBeEmpty();

        val1.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);
        val4.Count().ShouldBe(1);
    }

    [Fact(DisplayName = "Direct type getting attribute required test")]
    public void DirectTypeGettingRequiredAttributeTest()
    {
        var type = typeof(NormalWithAttrClass);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);

        TypeReflections.GetAttributeRequired(type, one).ShouldNotBeNull();
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired(type, two).ShouldBeNull());
        TypeReflections.GetAttributeRequired(type, three).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Generic type getting attribute required test")]
    public void GenericTypeGettingRequiredAttributeTest()
    {
        var type = typeof(NormalWithAttrClass);

        TypeReflections.GetAttributeRequired<ModelOneAttribute>(type).ShouldNotBeNull();
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired<ModelTwoAttribute>(type));
        TypeReflections.GetAttributeRequired<ModelThreeAttribute>(type).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Direct type getting attribute required inherit test")]
    public void DirectTypeGettingRequiredAttributeInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);
        var four = typeof(ModelFourAttribute);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired(type, one));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired(type, two).ShouldBeNull());
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired(type, three).ShouldBeNull());
        Assert.Throws<AmbiguousMatchException>(() => TypeReflections.GetAttributeRequired(type, one, ReflectionOptions.Inherit));
        TypeReflections.GetAttributeRequired(type, one, ReflectionOptions.Inherit, ReflectionAmbiguousOptions.IgnoreAmbiguous).ShouldNotBeNull();
        TypeReflections.GetAttributeRequired(type, three, ReflectionOptions.Inherit).ShouldNotBeNull();
        TypeReflections.GetAttributeRequired(type, four).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Generic type getting attribute required inherit test")]
    public void GenericTypeGettingRequiredAttributeInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired<ModelOneAttribute>(type));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired<ModelTwoAttribute>(type));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributeRequired<ModelThreeAttribute>(type));
        Assert.Throws<AmbiguousMatchException>(() => TypeReflections.GetAttributeRequired<ModelOneAttribute>(type, ReflectionOptions.Inherit).ShouldNotBeNull());
        TypeReflections.GetAttributeRequired<ModelOneAttribute>(type, ReflectionOptions.Inherit, ReflectionAmbiguousOptions.IgnoreAmbiguous).ShouldNotBeNull();
        TypeReflections.GetAttributeRequired<ModelThreeAttribute>(type, ReflectionOptions.Inherit).ShouldNotBeNull();
        TypeReflections.GetAttributeRequired<ModelFourAttribute>(type).ShouldNotBeNull();
    }

    [Fact(DisplayName = "Direct type getting attributes required test")]
    public void DirectTypeGettingRequiredAttributesTest()
    {
        var type = typeof(NormalWithAttrClass);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);

        var val1 = TypeReflections.GetAttributesRequired(type, one);
        var val3 = TypeReflections.GetAttributesRequired(type, three);

        val1.ShouldNotBeEmpty();
        val3.ShouldNotBeEmpty();

        val1.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired(type, two));
    }

    [Fact(DisplayName = "Generic type getting attributes required test")]
    public void GenericTypeGettingRequiredAttributesTest()
    {
        var type = typeof(NormalWithAttrClass);

        var val1 = TypeReflections.GetAttributesRequired<ModelOneAttribute>(type);
        var val3 = TypeReflections.GetAttributesRequired<ModelThreeAttribute>(type);

        val1.ShouldNotBeEmpty();
        val3.ShouldNotBeEmpty();

        val1.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired<ModelTwoAttribute>(type));
    }

    [Fact(DisplayName = "Direct type getting attributes required inherit test")]
    public void DirectTypeGettingRequiredAttributesInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);
        var one = typeof(ModelOneAttribute);
        var two = typeof(ModelTwoAttribute);
        var three = typeof(ModelThreeAttribute);
        var four = typeof(ModelFourAttribute);

        var val1 = TypeReflections.GetAttributesRequired(type, four);

        val1.ShouldNotBeEmpty();
        val1.Count().ShouldBe(1);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired(type, one));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired(type, two));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired(type, three));

        var val2 = TypeReflections.GetAttributesRequired(type, one, ReflectionOptions.Inherit);
        var val3 = TypeReflections.GetAttributesRequired(type, three, ReflectionOptions.Inherit);

        val2.ShouldNotBeEmpty();
        val3.ShouldNotBeEmpty();

        val2.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired(type, two, ReflectionOptions.Inherit));
    }

    [Fact(DisplayName = "Generic type getting attributes required inherit test")]
    public void GenericTypeGettingRequiredAttributesInheritTest()
    {
        var type = typeof(NormalWithAttrClassWrapper2);

        var val1 = TypeReflections.GetAttributesRequired<ModelFourAttribute>(type);

        val1.ShouldNotBeEmpty();
        val1.Count().ShouldBe(1);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired<ModelOneAttribute>(type));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired<ModelTwoAttribute>(type));
        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired<ModelThreeAttribute>(type));

        var val2 = TypeReflections.GetAttributesRequired<ModelOneAttribute>(type, ReflectionOptions.Inherit);
        var val3 = TypeReflections.GetAttributesRequired<ModelThreeAttribute>(type, ReflectionOptions.Inherit);

        val2.ShouldNotBeEmpty();
        val3.ShouldNotBeEmpty();

        val2.Count().ShouldBe(2);
        val3.Count().ShouldBe(1);

        Assert.Throws<ArgumentException>(() => TypeReflections.GetAttributesRequired<ModelTwoAttribute>(type, ReflectionOptions.Inherit));
    }

    [Fact(DisplayName = "Getting all attributes test")]
    public void AllAttributeGettingTest()
    {
        var val = TypeReflections.GetAttributes(typeof(NormalWithAttrClass));

        val.ShouldNotBeNull();
        val.ShouldNotBeEmpty();
        val.Count().ShouldBe(3);
    }

    [Fact(DisplayName = "Getting all attributes with inherit test")]
    public void AllAttributeGettingInheritTest()
    {
        var val1 = TypeReflections.GetAttributes(typeof(NormalWithAttrClassWrapper2));
        var val2 = TypeReflections.GetAttributes(typeof(NormalWithAttrClassWrapper2), ReflectionOptions.Inherit);

        val1.ShouldNotBeNull();
        val1.ShouldNotBeEmpty();
        val1.Count().ShouldBe(1);

        val2.ShouldNotBeNull();
        val2.ShouldNotBeEmpty();
        val2.Count().ShouldBe(4);
    }
}