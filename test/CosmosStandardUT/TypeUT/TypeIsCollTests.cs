﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT","TypeIs.CollType")]
    public class TypeIsCollTests
    {
        [Fact(DisplayName = "Direct type for normal array test")]
        public void DirectTypeForNormalArrayTest()
        {
            Types.IsCollectionType(typeof(int[])).ShouldBeTrue();
            Types.IsCollectionType(typeof(int?[])).ShouldBeTrue();
            Types.IsCollectionType(typeof(string[])).ShouldBeTrue();
            Types.IsCollectionType(typeof(Array)).ShouldBeTrue();
            Types.IsCollectionType(typeof(ArrayList)).ShouldBeTrue();
            Types.IsCollectionType(typeof(List<int>)).ShouldBeTrue();
            Types.IsCollectionType(typeof(ArraySegment<int>)).ShouldBeTrue();
            Types.IsCollectionType(typeof(IEnumerable<string>)).ShouldBeTrue();
        }

        [Fact(DisplayName = "Generic type for normal array test")]
        public void GenericTypeForNormalArrayTest()
        {
            Types.IsCollectionType<int[]>().ShouldBeTrue();
            Types.IsCollectionType<int?[]>().ShouldBeTrue();
            Types.IsCollectionType<string[]>().ShouldBeTrue();
            Types.IsCollectionType<Array>().ShouldBeTrue();
            Types.IsCollectionType<ArrayList>().ShouldBeTrue();
            Types.IsCollectionType<List<int>>().ShouldBeTrue();
            Types.IsCollectionType<ArraySegment<int>>().ShouldBeTrue();
            Types.IsCollectionType<IEnumerable<string>>().ShouldBeTrue();
        }

        [Fact(DisplayName = "Object for normal array test")]
        public void ObjectForNormalArrayTest()
        {
            List<int> nullList = new List<int>();
            nullList = null;
            
            Types.IsCollectionType(new int[0]).ShouldBeTrue();
            Types.IsCollectionType(new int?[0]).ShouldBeTrue();
            Types.IsCollectionType(new ArrayList()).ShouldBeTrue();
            Types.IsCollectionType(new List<int>()).ShouldBeTrue();
            Types.IsCollectionType(new ArraySegment<int>()).ShouldBeTrue();
            Types.IsCollectionType("nice").ShouldBeTrue(); // String, IEnumerable<Char>
            Types.IsCollectionType(nullList).ShouldBeFalse();
            Types.IsCollectionType(nullList, TypeIsOptions.IgnoreNullable).ShouldBeTrue();
        }

        [Fact(DisplayName = "Reflection should be coll test")]
        public void ReflectionCollTest()
        {
            Func<MemberInfo, bool> filter = member => member.MemberType == MemberTypes.TypeInfo
                                                   || member.MemberType == MemberTypes.Field
                                                   || member.MemberType == MemberTypes.Property;
            var t = typeof(NormalValueTypeClass);
            var m0 = (MemberInfo) t;
            var allMembers = t.GetMembers().Where(filter).ToList();

            allMembers.ShouldNotBeNull();
            allMembers.ShouldNotBeEmpty();
            var m01 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumV1));
            var m02 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumV2));
            var m03 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumV3));
            var m04 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumV4));
            var m05 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumD1));
            var m06 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumD2));
            var m07 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumA1));
            var m08 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumA2));
            var m09 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumA3));
            var m10 = allMembers.Single(x => x.Name == nameof(NormalValueTypeClass.Int32EnumA4));

            m01.MemberType.ShouldBe(MemberTypes.Property);
            m02.MemberType.ShouldBe(MemberTypes.Field);
            m03.MemberType.ShouldBe(MemberTypes.Property);
            m04.MemberType.ShouldBe(MemberTypes.Field);
            m05.MemberType.ShouldBe(MemberTypes.Property);
            m06.MemberType.ShouldBe(MemberTypes.Field);
            m07.MemberType.ShouldBe(MemberTypes.Property);
            m08.MemberType.ShouldBe(MemberTypes.Field);
            m09.MemberType.ShouldBe(MemberTypes.Property);
            m10.MemberType.ShouldBe(MemberTypes.Field);
            
            TypeReflections.IsCollection(m0).ShouldBeFalse();
            TypeReflections.IsCollection(m01).ShouldBeTrue();
            TypeReflections.IsCollection(m02).ShouldBeTrue();
            TypeReflections.IsCollection(m03).ShouldBeTrue();
            TypeReflections.IsCollection(m04).ShouldBeTrue();
            TypeReflections.IsCollection(m05).ShouldBeTrue();
            TypeReflections.IsCollection(m06).ShouldBeTrue();
            TypeReflections.IsCollection(m07).ShouldBeTrue();
            TypeReflections.IsCollection(m08).ShouldBeTrue();
            TypeReflections.IsCollection(m09).ShouldBeTrue();
            TypeReflections.IsCollection(m10).ShouldBeTrue();
        }
    }
}