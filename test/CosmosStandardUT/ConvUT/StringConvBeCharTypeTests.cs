using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsChar")]
    public class StringConvBeCharTypeTests
    {
        public StringConvBeCharTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }
        
        [Fact(DisplayName = "To judge string is char type or not test")]
        public void JudgingStringIsCharTypeTest()
        {
            var type = typeof(char);
            var text0 = "b";
            var text1 = "B";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is char type or not and ignore case test")]
        public void JudgingStringIsCharTypeWithIgnoreCaseTest()
        {
            var type = typeof(char);
            var text0 = "b";
            var text1 = "B";
            
            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge string is char type or not by generic type test")]
        public void JudgingStringIsCharTypeByGenericTypeTest()
        {
            var text0 = "b";
            var text1 = "B";

            text0.Is<char>().ShouldBeTrue();
            text1.Is<char>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is char type or not by generic type and ignore case test")]
        public void JudgingStringIsCharTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "b";
            var text1 = "B";
            
            text0.Is<char>(Context).ShouldBeTrue();
            text1.Is<char>(Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge null or empty string is char type or not test")]
        public void JudgingNullOrEmptyStringIsCharTypeTest()
        {
            var type = typeof(char);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is char type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsCharTypeWithIgnoreCaseTest()
        {
            var type = typeof(char);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
        }
        
        [Fact(DisplayName = "To judge null or empty string is char type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsCharTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<char>().ShouldBeFalse();
            text1.Is<char>().ShouldBeFalse();
            text2.Is<char>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is char type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsCharTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is<char>(Context).ShouldBeFalse();
            text1.Is<char>(Context).ShouldBeFalse();
            text2.Is<char>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable char type or not test")]
        public void JudgingStringIsNullableCharTypeTest()
        {
            var type = typeof(char);
            var nullableType = typeof(char?);
            var text0 = "b";
            var text1 = "B";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable char type or not and ignore case test")]
        public void JudgingStringIsNullableCharTypeWithIgnoreCaseTest()
        {
            var type = typeof(char);
            var nullableType = typeof(char?);
            var text0 = "b";
            var text1 = "B";
            
            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            
            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeTrue();
            
            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            
            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge string is nullable char type or not by generic type test")]
        public void JudgingStringIsNullableCharTypeByGenericTypeTest()
        {
            var text0 = "b";
            var text1 = "B";

            text0.Is<char>().ShouldBeTrue();
            text1.Is<char>().ShouldBeTrue();

            text0.Is<char?>().ShouldBeTrue();
            text1.Is<char?>().ShouldBeTrue();

            text0.IsNullable<char>().ShouldBeTrue();
            text1.IsNullable<char>().ShouldBeTrue();

            text0.IsNullable<char?>().ShouldBeTrue();
            text1.IsNullable<char?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable char type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableCharTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "b";
            var text1 = "B";
            
            text0.Is<char>(Context).ShouldBeTrue();
            text1.Is<char>(Context).ShouldBeTrue();
            
            text0.Is<char?>(Context).ShouldBeTrue();
            text1.Is<char?>(Context).ShouldBeTrue();
            
            text0.IsNullable<char>(Context).ShouldBeTrue();
            text1.IsNullable<char>(Context).ShouldBeTrue();
            
            text0.IsNullable<char?>(Context).ShouldBeTrue();
            text1.IsNullable<char?>(Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge null or empty string is nullable char type or not test")]
        public void JudgingNullOrEmptyStringIsNullableCharTypeTest()
        {
            var type = typeof(char);
            var nullableType = typeof(char?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            
            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType).ShouldBeFalse();
            
            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            
            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable char type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableCharTypeWithIgnoreCaseTest()
        {
            var type = typeof(char);
            var nullableType = typeof(char?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            
            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();
            
            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();
            
            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();
        }
        
        [Fact(DisplayName = "To judge null or empty string is nullable char type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableCharTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<char?>().ShouldBeTrue();
            text1.Is<char?>().ShouldBeFalse();
            text2.Is<char?>().ShouldBeFalse();

            text0.IsNullable<char>().ShouldBeTrue();
            text1.IsNullable<char>().ShouldBeFalse();
            text2.IsNullable<char>().ShouldBeFalse();

            text0.IsNullable<char?>().ShouldBeTrue();
            text1.IsNullable<char?>().ShouldBeFalse();
            text2.IsNullable<char?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable char type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableCharTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is<char?>(Context).ShouldBeTrue();
            text1.Is<char?>(Context).ShouldBeFalse();
            text2.Is<char?>(Context).ShouldBeFalse();
            
            text0.IsNullable<char>(Context).ShouldBeTrue();
            text1.IsNullable<char>(Context).ShouldBeFalse();
            text2.IsNullable<char>(Context).ShouldBeFalse();
            
            text0.IsNullable<char?>(Context).ShouldBeTrue();
            text1.IsNullable<char?>(Context).ShouldBeFalse();
            text2.IsNullable<char?>(Context).ShouldBeFalse();
        }
    }
}