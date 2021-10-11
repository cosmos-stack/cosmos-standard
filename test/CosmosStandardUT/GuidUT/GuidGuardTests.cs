using System;
using CosmosStack.IdUtils;
using CosmosStack.Validation;
using Xunit;

namespace CosmosStandardUT.GuidUT
{
    [Trait("GuidUT","GuidGuard")]
    public class GuidGuardTests
    {
        [Fact(DisplayName =  "Valid GUID test")]
        public void ValidGuidTest()
        {
            var guid1 = Guid.Empty;
            var guid2 = Guid.NewGuid();
            Guid? guid3 = guid1;
            Guid? guid4 = null;
            Guid? guid5 = guid2;

            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid1, "guid1"));
            GuidGuard.ShouldBeValid(guid2, "guid2");
            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid3, "guid3"));
            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid4, "guid4"));
            GuidGuard.ShouldBeValid(guid5, "guid5");
        }
    }
}