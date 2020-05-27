using System;
using System.Reflection;
using Cosmos.Judgments;
using Cosmos.Reflection;
using Xunit;

namespace Cosmos.Test.Judgements
{
    public class TypeJudgementTest
    {
        [Fact]
        public void IsNumericTest()
        {
            Assert.True(TypeJudgment.IsNumericType(1.GetType()));
            Assert.True(TypeJudgment.IsNumericType(1D.GetType()));
            Assert.True(TypeJudgment.IsNumericType(1F.GetType()));
            Assert.True(TypeJudgment.IsNumericType(1M.GetType()));
            Assert.True(TypeJudgment.IsNumericType(1.001M.GetType()));
            Assert.True(TypeJudgment.IsNumericType(1L.GetType()));

            Assert.True(TypeJudgment.IsNumericType(1.GetType().GetTypeInfo()));
            Assert.True(TypeJudgment.IsNumericType(1D.GetType().GetTypeInfo()));
            Assert.True(TypeJudgment.IsNumericType(1F.GetType().GetTypeInfo()));
            Assert.True(TypeJudgment.IsNumericType(1M.GetType().GetTypeInfo()));
            Assert.True(TypeJudgment.IsNumericType(1.001M.GetType().GetTypeInfo()));
            Assert.True(TypeJudgment.IsNumericType(1L.GetType().GetTypeInfo()));
        }

        [Fact]
        public void IsNullableType()
        {
            Assert.True(TypeJudgment.IsNullableType(typeof(int?)));
            Assert.True(TypeJudgment.IsNullableType(typeof(Nullable<System.Int32>)));

            Assert.True(TypeJudgment.IsNullableType(typeof(int?).GetTypeInfo()));
        }
    }
}
