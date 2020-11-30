using System;
using System.Linq;
using System.Reflection;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeIs.EnumType")]
    public class TypeIsEnumTests
    {
        [Fact(DisplayName = "Direct enum type test")]
        public void DirectEnumTypeTest()
        {
            Types.IsEnumType(typeof(int)).ShouldBeFalse();
            Types.IsEnumType(typeof(Int16Enum)).ShouldBeTrue();
            Types.IsEnumType(typeof(Int16Enum?)).ShouldBeFalse();
            Types.IsEnumType(typeof(Int16Enum?), TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }

        [Fact(DisplayName = "Generic enum type test")]
        public void GenericEnumTypeTest()
        {
            Types.IsEnumType<int>().ShouldBeFalse();
            Types.IsEnumType<Int16Enum>().ShouldBeTrue();
            Types.IsEnumType<Int16Enum?>().ShouldBeFalse();
            Types.IsEnumType<Int16Enum?>(TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }

        [Fact(DisplayName = "Object may be an enum type test")]
        public void ObjectMayBeEnumTypeTest()
        {
            Types.IsEnumType(Int16Enum.A).ShouldBeTrue();
            Types.IsEnumType((Int16Enum) 1).ShouldBeTrue();
            Types.IsEnumType((Int16Enum) 0).ShouldBeFalse();
            Types.IsEnumType(1).ShouldBeFalse();
            Types.IsEnumType(null).ShouldBeFalse();
        }

        [Fact(DisplayName = "Reflection should be enum test")]
        public void ReflectionEnumTest()
        {
            Func<MemberInfo, bool> filter = member => member.MemberType == MemberTypes.TypeInfo
                                                   || member.MemberType == MemberTypes.Field
                                                   || member.MemberType == MemberTypes.Property;
            var t = typeof(NormalValueTypeClass);
            var m0 = (MemberInfo) t;
            var allMembers = t.GetMembers().Where(filter).ToList();

            allMembers.ShouldNotBeNull();
            allMembers.ShouldNotBeEmpty();
            var m1 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int99V1));
            var m2 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int99V2));
            var m3 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int99V3));
            var m4 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int99V4));
            var m5 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Str));

            m1.MemberType.ShouldBe(MemberTypes.Property);
            m2.MemberType.ShouldBe(MemberTypes.Field);
            m3.MemberType.ShouldBe(MemberTypes.Property);
            m4.MemberType.ShouldBe(MemberTypes.Field);
            m5.MemberType.ShouldBe(MemberTypes.Property);

            TypeReflections.IsEnum(m0).ShouldBeFalse();
            TypeReflections.IsEnum(m1).ShouldBeTrue();
            TypeReflections.IsEnum(m2).ShouldBeTrue();
            TypeReflections.IsEnum(m3).ShouldBeFalse();
            TypeReflections.IsEnum(m4).ShouldBeFalse();
            TypeReflections.IsEnum(m3, TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            TypeReflections.IsEnum(m4, TypeIsOptions.IgnoreNullable).ShouldBeTrue();
            TypeReflections.IsEnum(m5).ShouldBeFalse();
        }
    }
}