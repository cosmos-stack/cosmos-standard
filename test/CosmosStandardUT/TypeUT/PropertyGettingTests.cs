using System;
using System.Linq;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeVisit.PropertyGetting")]
    public class PropertyGettingTests
    {
        [Fact(DisplayName = "All get/set property test")]
        public void AllGetSetPropertyTest()
        {
            var type = typeof(NormalPropertyClass);
            var members = type.GetMembers();
            var property1 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicGetSet));
            var property2 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicGet));
            var property3 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicSet));

            var x1 = TypeVisit.GetProperties(type, PropertyAccessOptions.Both).ToList();
            var x2 = TypeVisit.GetProperties(type, PropertyAccessOptions.Getters).ToList();
            var x3 = TypeVisit.GetProperties(type, PropertyAccessOptions.Setters).ToList();

            x1.ShouldNotBeEmpty();
            x2.ShouldNotBeEmpty();
            x3.ShouldNotBeEmpty();

            x1.Count().ShouldBe(1);
            x2.Count().ShouldBe(2);
            x3.Count().ShouldBe(2);

            x1[0].ShouldBe(property1);

            x2[0].ShouldBe(property1);
            x2[1].ShouldBe(property2);

            x3[0].ShouldBe(property1);
            x3[1].ShouldBe(property3);
        }

        [Fact(DisplayName = "Expression single get/set property test")]
        public void ExtensionsSinglePropertyTest()
        {
            var type = typeof(NormalPropertyClass);
            var members = type.GetMembers();
            var property1 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicGetSet));
            var property2 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicGet));
            var property3 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicSet));

            var x4 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicGetSet);
            var x5 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicGetSet, PropertyAccessOptions.Getters);
            var x6 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicGetSet, PropertyAccessOptions.Setters);

            x4.ShouldNotBeNull();
            x5.ShouldNotBeNull();
            x6.ShouldNotBeNull();

            x4.ShouldBe(property1);
            x5.ShouldBe(property1);
            x6.ShouldBe(property1);

            var x7 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicGet);
            var x8 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicGet, PropertyAccessOptions.Getters);
            Assert.Throws<ArgumentException>(() => TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicGet, PropertyAccessOptions.Setters));

            x7.ShouldNotBeNull();
            x8.ShouldNotBeNull();

            x7.ShouldBe(property2);
            x8.ShouldBe(property2);

            var x9 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicSet);
            var x10 = TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicSet, PropertyAccessOptions.Setters);
            Assert.Throws<ArgumentException>(() => TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicSet, PropertyAccessOptions.Getters));

            x9.ShouldNotBeNull();
            x10.ShouldNotBeNull();

            x9.ShouldBe(property3);
            x10.ShouldBe(property3);
        }

        [Fact(DisplayName = "Expression field then throw exception test")]
        public void FieldErrTest()
        {
            Assert.Throws<ArgumentException>(() => TypeVisit.GetProperty<NormalPropertyClass, string>(t => t.PublicField));
        }

        [Fact(DisplayName = "Extension method test")]
        public void ExtensionMethodTest()
        {
            var model = new NormalPropertyClass();

            var type = typeof(NormalPropertyClass);
            var members = type.GetMembers();
            var property1 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicGetSet));
            var property2 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicGet));
            var property3 = members.Single(m => m.Name == nameof(NormalPropertyClass.PublicSet));

            var x1 = model.GetProperties().ToList(); //both
            var x2 = model.GetProperties(PropertyAccessOptions.Getters).ToList();
            var x3 = model.GetProperties(PropertyAccessOptions.Setters).ToList();

            x1.ShouldNotBeEmpty();
            x2.ShouldNotBeEmpty();
            x3.ShouldNotBeEmpty();

            x1.Count().ShouldBe(1);
            x2.Count().ShouldBe(2);
            x3.Count().ShouldBe(2);

            x1[0].ShouldBe(property1);

            x2[0].ShouldBe(property1);
            x2[1].ShouldBe(property2);

            x3[0].ShouldBe(property1);
            x3[1].ShouldBe(property3);

            var x4 = model.GetProperty(x => x.PublicGetSet);
            var x5 = model.GetProperty(x => x.PublicGetSet, PropertyAccessOptions.Getters);
            var x6 = model.GetProperty(x => x.PublicGetSet, PropertyAccessOptions.Setters);

            x4.ShouldNotBeNull();
            x5.ShouldNotBeNull();
            x6.ShouldNotBeNull();

            x4.ShouldBe(property1);
            x5.ShouldBe(property1);
            x6.ShouldBe(property1);

            var x7 = model.GetProperty(t => t.PublicGet);
            var x8 = model.GetProperty(t => t.PublicGet, PropertyAccessOptions.Getters);
            Assert.Throws<ArgumentException>(() => model.GetProperty(t => t.PublicGet, PropertyAccessOptions.Setters));

            x7.ShouldNotBeNull();
            x8.ShouldNotBeNull();

            x7.ShouldBe(property2);
            x8.ShouldBe(property2);

            var x9 = model.GetProperty(t => t.PublicSet);
            var x10 = model.GetProperty(t => t.PublicSet, PropertyAccessOptions.Setters);
            Assert.Throws<ArgumentException>(() => model.GetProperty(t => t.PublicSet, PropertyAccessOptions.Getters));

            x9.ShouldNotBeNull();
            x10.ShouldNotBeNull();

            x9.ShouldBe(property3);
            x10.ShouldBe(property3);
        }
    }
}