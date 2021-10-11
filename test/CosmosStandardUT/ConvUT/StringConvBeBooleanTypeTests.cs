using CosmosStack.Conversions;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsBoolean")]
    public class StringConvBeBooleanTypeTests
    {
        public StringConvBeBooleanTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Theory(DisplayName = "To judge string is bool type or not test")]
        [InlineData("true")] // inline determiner
        [InlineData("True")]
        [InlineData("TRUE")]
        [InlineData("false")]
        [InlineData("False")]
        [InlineData("FALSE")]
        [InlineData("yes")]   // boolean verba manager
        [InlineData("Yes")]
        [InlineData("no")]
        [InlineData("No")]
        [InlineData("1")]
        [InlineData("0")]
        public void JudgingStringIsBooleanTypeTest(string text)
        {
            var type = typeof(bool);
            
            text.Is(type).ShouldBeTrue();
            text.Is(type, Context).ShouldBeTrue();
            
            text.Is<bool>().ShouldBeTrue();
            text.Is<bool>(Context).ShouldBeTrue();
        }
        
        [Theory(DisplayName = "To judge string is nullable bool type or not test")]
        [InlineData("true")] // inline determiner
        [InlineData("True")]
        [InlineData("TRUE")]
        [InlineData("false")]
        [InlineData("False")]
        [InlineData("FALSE")]
        [InlineData("yes")]   // boolean verba manager
        [InlineData("Yes")]
        [InlineData("no")]
        [InlineData("No")]
        [InlineData("1")]
        [InlineData("0")]
        public void JudgingStringIsNullableBooleanTypeTest(string text)
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);
            
            text.Is(type).ShouldBeTrue();
            text.Is(nullableType).ShouldBeTrue();
            text.IsNullable(type).ShouldBeTrue();
            text.IsNullable(nullableType).ShouldBeTrue();
            
            text.Is(type, Context).ShouldBeTrue();
            text.Is(nullableType, Context).ShouldBeTrue();
            text.IsNullable(type, Context).ShouldBeTrue();
            text.IsNullable(nullableType, Context).ShouldBeTrue();
            
            text.Is<bool>().ShouldBeTrue();
            text.Is<bool?>().ShouldBeTrue();
            text.IsNullable<bool>().ShouldBeTrue();
            text.IsNullable<bool?>().ShouldBeTrue();
            
            text.Is<bool>(Context).ShouldBeTrue();
            text.Is<bool?>(Context).ShouldBeTrue();
            text.IsNullable<bool>(Context).ShouldBeTrue();
            text.IsNullable<bool?>(Context).ShouldBeTrue();
        }
        
        [Theory(DisplayName = "To judge null or empty string is bool type or not test")]
        [InlineData(null)] // inline determiner
        [InlineData("null")]
        [InlineData("")]
        public void JudgingNullOrEmptyStringIsBooleanTypeTest(string text)
        {
            var type = typeof(bool);

            text.Is(type).ShouldBeFalse();
            text.Is(type, Context).ShouldBeFalse();
            
            text.Is<bool>().ShouldBeFalse();
            text.Is<bool>(Context).ShouldBeFalse();
        }

        [Theory(DisplayName = "To judge null is bool type or not test")]
        [InlineData(null)] // inline determiner
        public void JudgingNullStringIsNullableBooleanTypeTest(string text)
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);

            text.Is(type).ShouldBeFalse();
            text.Is(nullableType).ShouldBeTrue();
            text.IsNullable(type).ShouldBeTrue();
            text.IsNullable(nullableType).ShouldBeTrue();

            text.Is(type, Context).ShouldBeFalse();
            text.Is(nullableType, Context).ShouldBeTrue();
            text.IsNullable(type, Context).ShouldBeTrue();
            text.IsNullable(nullableType, Context).ShouldBeTrue();

            text.Is<bool?>().ShouldBeTrue();
            text.IsNullable<bool>().ShouldBeTrue();
            text.IsNullable<bool?>().ShouldBeTrue();

            text.Is<bool?>(Context).ShouldBeTrue();
            text.IsNullable<bool>(Context).ShouldBeTrue();
            text.IsNullable<bool?>(Context).ShouldBeTrue();
        }
        
        [Theory(DisplayName = "To judge empty or invalid string is nullable bool type or not test")]
        [InlineData("")] // inline determiner
        [InlineData("null")]
        public void JudgingEmptyOrInvalidStringIsNullableBooleanTypeTest(string text)
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);
            
            text.Is(type).ShouldBeFalse();
            text.Is(nullableType).ShouldBeFalse();
            text.IsNullable(type).ShouldBeFalse();
            text.IsNullable(nullableType).ShouldBeFalse();
            
            text.Is(type, Context).ShouldBeFalse();
            text.Is(nullableType, Context).ShouldBeFalse();
            text.IsNullable(type, Context).ShouldBeFalse();
            text.IsNullable(nullableType, Context).ShouldBeFalse();

            text.Is<bool?>().ShouldBeFalse();
            text.IsNullable<bool>().ShouldBeFalse();
            text.IsNullable<bool?>().ShouldBeFalse();

            text.Is<bool?>(Context).ShouldBeFalse();
            text.IsNullable<bool>(Context).ShouldBeFalse();
            text.IsNullable<bool?>(Context).ShouldBeFalse();
        }
    }
}