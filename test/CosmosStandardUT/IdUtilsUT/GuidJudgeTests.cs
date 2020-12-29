using System;
using Cosmos.IdUtils;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.IdUtilsUT
{
    [Trait("IdUtilUT","Guid.Judge")]
    public class GuidJudgeTests
    {
        [Fact(DisplayName = "Nullable Guid is empty or null test")]
        public void NullableGuidEmptyOrNullTest()
        {
            Guid? guid1 = Guid.Empty;
            Guid? guid2 = null;
            Guid? guid3 = default;
            
            GuidJudge.IsNullOrEmpty(guid1).ShouldBeTrue();
            GuidJudge.IsNullOrEmpty(guid2).ShouldBeTrue();
            GuidJudge.IsNullOrEmpty(guid3).ShouldBeTrue();
        }

        [Fact(DisplayName = "Normal Guid is empty or null test")]
        public void NormalGuidEmptyOrNullTest()
        {
            Guid guid1 = Guid.Empty;
            Guid guid2 = default;
            
            GuidJudge.IsNullOrEmpty(guid1).ShouldBeTrue();
            GuidJudge.IsNullOrEmpty(guid2).ShouldBeTrue();
        }

        [Fact(DisplayName = "Nullable Guid with value test")]
        public void NullableGuidWithValueTest()
        {
            Guid? guid = Guid.NewGuid();
            
            GuidJudge.IsNullOrEmpty(guid).ShouldBeFalse();
        }

        [Fact(DisplayName = "Normal Guid with value test")]
        public void NormalGuidWithValueTest()
        {
            Guid guid = Guid.NewGuid();
            
            GuidJudge.IsNullOrEmpty(guid).ShouldBeFalse();
        }
        
        [Fact(DisplayName = "Extension method for Nullable Guid is empty or null test")]
        public void ExtensionMethodForNullableGuidEmptyOrNullTest()
        {
            Guid? guid1 = Guid.Empty;
            Guid? guid2 = null;
            Guid? guid3 = default;
            
            guid1.IsNullOrEmpty().ShouldBeTrue();
            guid2.IsNullOrEmpty().ShouldBeTrue();
            guid3.IsNullOrEmpty().ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method for Normal Guid is empty or null test")]
        public void ExtensionMethodForNormalGuidEmptyOrNullTest()
        {
            Guid guid1 = Guid.Empty;
            Guid guid2 = default;
            
            guid1.IsNullOrEmpty().ShouldBeTrue();
            guid2.IsNullOrEmpty().ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method for Nullable Guid with value test")]
        public void ExtensionMethodForNullableGuidWithValueTest()
        {
            Guid? guid = Guid.NewGuid();
            
            guid.IsNullOrEmpty().ShouldBeFalse();
        }

        [Fact(DisplayName = "Extension method for Normal Guid with value test")]
        public void ExtensionMethodForNormalGuidWithValueTest()
        {
            Guid guid = Guid.NewGuid();
            
            guid.IsNullOrEmpty().ShouldBeFalse();
        }
    }
}