using Cosmos.IdUtils;
using Cosmos.Validation;

namespace CosmosStandardUT.IdUtilsUT
{
    [Trait("IdUtilUT", "Guid.Guard")]
    public class GuidGuardTests
    {
        [Fact(DisplayName = "Nullable guid should be invalid test")]
        public void NullableGuidShouldBeInvalidTest()
        {
            Guid? guid1 = Guid.Empty;
            Guid? guid2 = null;

            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid1, nameof(guid1)));
            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid2, nameof(guid2)));
        }
        
        [Fact(DisplayName = "Normal guid should be invalid test")]
        public void NormalGuidShouldBeInvalidTest()
        {
            Guid guid1 = Guid.Empty;
            Guid guid2 = default;

            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid1, nameof(guid1)));
            Assert.Throws<ValidationException>(() => GuidGuard.ShouldBeValid(guid2, nameof(guid2)));
        }
        
        [Fact(DisplayName = "Extension Method For Nullable guid should be invalid test")]
        public void ExtensionMethodForNullableGuidShouldBeInvalidTest()
        {
            Guid? guid1 = Guid.Empty;
            Guid? guid2 = null;

            Assert.Throws<ValidationException>(() => guid1.CheckNull( nameof(guid1)));
            Assert.Throws<ValidationException>(() => guid2.CheckNull( nameof(guid2)));
            
            Assert.Throws<ValidationException>(() => guid1.Require( nameof(guid1)));
            Assert.Throws<ValidationException>(() => guid2.Require( nameof(guid2)));
        }
        
        [Fact(DisplayName = "Extension Method For Normal guid should be invalid test")]
        public void ExtensionMethodForNormalGuidShouldBeInvalidTest()
        {
            Guid guid1 = Guid.Empty;
            Guid guid2 = default;

            Assert.Throws<ValidationException>(() => guid1.CheckNull( nameof(guid1)));
            Assert.Throws<ValidationException>(() => guid2.CheckNull( nameof(guid2)));
            
            Assert.Throws<ValidationException>(() => guid1.Require( nameof(guid1)));
            Assert.Throws<ValidationException>(() => guid2.Require( nameof(guid2)));
        }
    }
}