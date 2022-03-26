using System;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeReflections.IsDescriptionDefined")]
    public class DescriptionDefinedTests
    {
        public Type EntryOne = typeof(NormalDescriptionClass);
        public Type EntryTwo = typeof(NormalDescriptionOrClass);
        public Type EntryThree = typeof(NormalDisplayNameOrClass);
        public Type Wrapper = typeof(NormalDescriptionWrapper);

        [Fact(DisplayName = "IsDescriptionDefined test")]
        public void DirectTypeIsDescriptionDefinedTest()
        {
            TypeReflections.IsDescriptionDefined(EntryOne).ShouldBeTrue();
#if NETFRAMEWORK
            TypeReflections.IsDescriptionDefined(EntryTwo).ShouldBeFalse();
#else
            TypeReflections.IsDescriptionDefined(EntryTwo).ShouldBeTrue();
#endif
            TypeReflections.IsDescriptionDefined(EntryThree).ShouldBeTrue();
            TypeReflections.IsDescriptionDefined(Wrapper).ShouldBeFalse();
            TypeReflections.IsDescriptionDefined(Wrapper, ReflectionOptions.Inherit).ShouldBeTrue();
        }
    }
}