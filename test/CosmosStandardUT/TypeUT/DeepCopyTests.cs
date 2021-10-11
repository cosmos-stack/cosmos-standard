using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeVisit.DeepCopy")]
    public class DeepCopyTests
    {
        [Fact(DisplayName = "DeepCopier Test")]
        public void DeepCopierTest()
        {
            var original = new NormalWithAttrClass {Good = "Nice", Index = 99, Nice = "Good"};
            var target = TypeVisit.DeepCopy(original, DeepCopyOptions.DeepCopier);
            Assert.Same(original, original);
            Assert.Same(target, target);
            Assert.NotSame(original, target);
        }

        [Fact(DisplayName = "ExpressionCopier Test")]
        public void ExpressionCopierTest()
        {
            var original = new NormalWithAttrClass {Good = "Nice", Index = 99, Nice = "Good"};
            var target = TypeVisit.DeepCopy(original, DeepCopyOptions.ExpressionCopier);
            Assert.Same(original, original);
            Assert.Same(target, target);
            Assert.NotSame(original, target);
        }
    }
}