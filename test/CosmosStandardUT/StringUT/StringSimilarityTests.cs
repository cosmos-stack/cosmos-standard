using Cosmos.Text;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Similarity")]
    public class StringSimilarityTests
    {
        [Fact(DisplayName = "Two string should be equal and same.")]
        public void SameTest()
        {
            var a = "全世界无产阶级联合起来";
            var b = "全世界无产阶级联合起来";

            var val = Strings.EvaluateSimilarity(a, b, 0.1);
            var typ = Strings.EvaluateSimilarity(a, b);

            val.ShouldBeLessThan(1.00000001);
            val.ShouldBeGreaterThan(0.9999999999);
            typ.ShouldBe(StringSimilarityTypes.Same);
        }

        [Fact(DisplayName = "Two string should be not equal or same.")]
        public void AnyTest()
        {
            var a = "全世界无产阶级联合起来";
            var b = "巴拉巴拉小魔仙";

            var val = Strings.EvaluateSimilarity(a, b, 0.1);
            var typ = Strings.EvaluateSimilarity(a, b);

            val.ShouldBeLessThan(0.00001);
            val.ShouldBe(0);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Two string should be 60% similarity.")]
        public void Any60Test()
        {
            var a = "全世界无产阶级联合起来";
            var b = "全世界无产阶级跳起舞来";

            var val = Strings.EvaluateSimilarity(a, b, 0.1);
            var typ = Strings.EvaluateSimilarity(a, b);

            val.ShouldBeLessThan(1);
            val.ShouldBeGreaterThan(0.60);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Two string should be 75% similarity.")]
        public void Any75Test()
        {
            var a = "知错能改";
            var b = "知错不改";

            var val = Strings.EvaluateSimilarity(a, b, 0.1);
            var typ = Strings.EvaluateSimilarity(a, b);

            val.ShouldBeLessThan(0.750000001);
            val.ShouldBeGreaterThan(0.749999999);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Two string should be 50% similarity.")]
        public void Any50Test()
        {
            var a = "乾坤无敌";
            var b = "宇宙无敌";

            var val = Strings.EvaluateSimilarity(a, b, 0.1);
            var typ = Strings.EvaluateSimilarity(a, b);

            val.ShouldBeLessThan(0.50000001);
            val.ShouldBeGreaterThan(0.49999999);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Extensions method for Two string should be equal and same.")]
        public void ExtensionMethodForSameTest()
        {
            var a = "全世界无产阶级联合起来";
            var b = "全世界无产阶级联合起来";

            var val = a.EvaluateSimilarity(b, 0.1);
            var typ = a.EvaluateSimilarity(b);

            val.ShouldBeLessThan(1.00000001);
            val.ShouldBeGreaterThan(0.9999999999);
            typ.ShouldBe(StringSimilarityTypes.Same);
        }

        [Fact(DisplayName = "Extensions method for Two string should be not equal or same.")]
        public void ExtensionMethodForAnyTest()
        {
            var a = "全世界无产阶级联合起来";
            var b = "巴拉巴拉小魔仙";

            var val = a.EvaluateSimilarity(b, 0.1);
            var typ = a.EvaluateSimilarity(b);

            val.ShouldBeLessThan(0.00001);
            val.ShouldBe(0);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Extensions method for Two string should be 60% similarity.")]
        public void ExtensionMethodForAny60Test()
        {
            var a = "全世界无产阶级联合起来";
            var b = "全世界无产阶级跳起舞来";

            var val = a.EvaluateSimilarity(b, 0.1);
            var typ = a.EvaluateSimilarity(b);

            val.ShouldBeLessThan(1);
            val.ShouldBeGreaterThan(0.60);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Extensions method for Two string should be 75% similarity.")]
        public void ExtensionMethodForAny75Test()
        {
            var a = "知错能改";
            var b = "知错不改";

            var val = a.EvaluateSimilarity(b, 0.1);
            var typ = a.EvaluateSimilarity(b);

            val.ShouldBeLessThan(0.750000001);
            val.ShouldBeGreaterThan(0.749999999);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }

        [Fact(DisplayName = "Extensions method for Two string should be 50% similarity.")]
        public void ExtensionMethodForAny50Test()
        {
            var a = "乾坤无敌";
            var b = "宇宙无敌";

            var val = a.EvaluateSimilarity(b, 0.1);
            var typ = a.EvaluateSimilarity(b);

            val.ShouldBeLessThan(0.50000001);
            val.ShouldBeGreaterThan(0.49999999);
            typ.ShouldBe(StringSimilarityTypes.Any);
        }
    }
}