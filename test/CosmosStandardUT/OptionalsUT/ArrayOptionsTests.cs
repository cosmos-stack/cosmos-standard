using System.Collections.Generic;
using Cosmos.Optionals;

namespace CosmosStandardUT.OptionalsUT
{
    [Trait("CollUT", "ArrayUT.To")]
    public class ArrayOptionsTests
    {
        [Fact(DisplayName = "Arrays.ToArraySafety test")]
        public void ConvertToArraySafety()
        {
            var expectVal = new[] {"1", "2"};
            List<string> niceString = new List<string> {"1", "2"};
            IEnumerable<string> niceEnumerable = niceString;
            IReadOnlyList<string> niceReadOnly = niceString.AsReadOnly();
            string[] niceOneDimArray = {"1", "2"};
            Array niceArray = new[] {"1", "2"};
            
            var niceNull1 = ((IEnumerable<string>) null).ToArraySafety();
            var niceNull2 = ((Array) null).ToArraySafety<string>();
            var niceStringCopy = niceString.ToArraySafety();
            var niceEnumerableCopy = niceEnumerable.ToArraySafety();
            var niceReadOnlyCopy = niceReadOnly.ToArraySafety();
            var niceOneDimArrayCopy = niceOneDimArray.ToArraySafety();
            var niceArrayCopy = niceArray.ToArraySafety<string>();

            niceNull1.ShouldNotBeNull();
            niceNull1.ShouldBeEmpty();
            niceNull2.ShouldNotBeNull();
            niceNull2.ShouldBeEmpty();
            niceStringCopy.ShouldNotBeNull();
            Assert.Equal(expectVal, niceStringCopy);
            niceEnumerableCopy.ShouldNotBeNull();
            Assert.Equal(expectVal, niceEnumerableCopy);
            niceReadOnlyCopy.ShouldNotBeNull();
            Assert.Equal(expectVal, niceReadOnlyCopy);
            niceOneDimArrayCopy.ShouldNotBeNull();
            Assert.Equal(expectVal, niceOneDimArrayCopy);
            niceArrayCopy.ShouldNotBeNull();
            Assert.Equal(expectVal, niceArrayCopy);
        }
    }
}