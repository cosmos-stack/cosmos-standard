using Cosmos.Conversions;
using Cosmos.Text;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsEnum")]
    public class StringConvBeEnumTypeTests
    {
        public StringConvBeEnumTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is enum type or not test")]
        public void JudgingStringIsEnumTypeTest()
        {
            var type = typeof(Int32Enum);
            var text0 = "b";
            var text1 = "B";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is enum type or not and ignore case test")]
        public void JudgingStringIsEnumTypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32Enum);
            var text0 = "b";
            var text1 = "B";
            
            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge string is enum type or not by generic type test")]
        public void JudgingStringIsEnumTypeByGenericTypeTest()
        {
            var text0 = "b";
            var text1 = "B";

            text0.Is<Int32Enum>().ShouldBeFalse();
            text1.Is<Int32Enum>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is enum type or not by generic type and ignore case test")]
        public void JudgingStringIsEnumTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "b";
            var text1 = "B";
            
            text0.Is<Int32Enum>(Context).ShouldBeTrue();
            text1.Is<Int32Enum>(Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge null or empty string is enum type or not test")]
        public void JudgingNullOrEmptyStringIsEnumTypeTest()
        {
            var type = typeof(Int32Enum);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is enum type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsEnumTypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32Enum);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
        }
        
        [Fact(DisplayName = "To judge null or empty string is enum type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsEnumTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<Int32Enum>().ShouldBeFalse();
            text1.Is<Int32Enum>().ShouldBeFalse();
            text2.Is<Int32Enum>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is enum type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsEnumTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is<Int32Enum>(Context).ShouldBeFalse();
            text1.Is<Int32Enum>(Context).ShouldBeFalse();
            text2.Is<Int32Enum>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string enum value test")]
        public void JudgingInvalidStringEnumValueTest()
        {
            var type = typeof(Int32Enum);
            var text = "D";

            text.Is(type).ShouldBeFalse();
            text.Is(type, Context).ShouldBeFalse();

            text.Is<Int32Enum>().ShouldBeFalse();
            text.Is<Int32Enum>(Context).ShouldBeFalse();
        }
        
        [Fact(DisplayName = "To judge string is nullable enum type or not test")]
        public void JudgingStringIsNullableEnumTypeTest()
        {
            var type = typeof(Int32Enum);
            var nullableType = typeof(Int32Enum?);
            var text0 = "b";
            var text1 = "B";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeFalse();
            text1.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeFalse();
            text1.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeFalse();
            text1.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable enum type or not and ignore case test")]
        public void JudgingStringIsNullableEnumTypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32Enum);
            var nullableType = typeof(Int32Enum?);
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
        
        [Fact(DisplayName = "To judge string is nullable enum type or not by generic type test")]
        public void JudgingStringIsNullableEnumTypeByGenericTypeTest()
        {
            var text0 = "b";
            var text1 = "B";

            text0.Is<Int32Enum>().ShouldBeFalse();
            text1.Is<Int32Enum>().ShouldBeTrue();

            text0.Is<Int32Enum?>().ShouldBeFalse();
            text1.Is<Int32Enum?>().ShouldBeTrue();

            text0.IsNullable<Int32Enum>().ShouldBeFalse();
            text1.IsNullable<Int32Enum>().ShouldBeTrue();

            text0.IsNullable<Int32Enum?>().ShouldBeFalse();
            text1.IsNullable<Int32Enum?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable enum type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableEnumTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "b";
            var text1 = "B";
            
            text0.Is<Int32Enum>(Context).ShouldBeTrue();
            text1.Is<Int32Enum>(Context).ShouldBeTrue();
            
            text0.Is<Int32Enum?>(Context).ShouldBeTrue();
            text1.Is<Int32Enum?>(Context).ShouldBeTrue();
            
            text0.IsNullable<Int32Enum>(Context).ShouldBeTrue();
            text1.IsNullable<Int32Enum>(Context).ShouldBeTrue();
            
            text0.IsNullable<Int32Enum?>(Context).ShouldBeTrue();
            text1.IsNullable<Int32Enum?>(Context).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "To judge null or empty string is nullable enum type or not test")]
        public void JudgingNullOrEmptyStringIsNullableEnumTypeTest()
        {
            var type = typeof(Int32Enum);
            var nullableType = typeof(Int32Enum?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable enum type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableEnumTypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32Enum);
            var nullableType = typeof(Int32Enum?);
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
        
        [Fact(DisplayName = "To judge null or empty string is nullable enum type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableEnumTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<Int32Enum?>().ShouldBeTrue();
            text1.Is<Int32Enum?>().ShouldBeFalse();
            text2.Is<Int32Enum?>().ShouldBeFalse();

            text0.IsNullable<Int32Enum>().ShouldBeTrue();
            text1.IsNullable<Int32Enum>().ShouldBeFalse();
            text2.IsNullable<Int32Enum>().ShouldBeFalse();

            text0.IsNullable<Int32Enum?>().ShouldBeTrue();
            text1.IsNullable<Int32Enum?>().ShouldBeFalse();
            text2.IsNullable<Int32Enum?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable enum type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableEnumTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            
            text0.Is<Int32Enum?>(Context).ShouldBeTrue();
            text1.Is<Int32Enum?>(Context).ShouldBeFalse();
            text2.Is<Int32Enum?>(Context).ShouldBeFalse();
            
            text0.IsNullable<Int32Enum>(Context).ShouldBeTrue();
            text1.IsNullable<Int32Enum>(Context).ShouldBeFalse();
            text2.IsNullable<Int32Enum>(Context).ShouldBeFalse();
            
            text0.IsNullable<Int32Enum?>(Context).ShouldBeTrue();
            text1.IsNullable<Int32Enum?>(Context).ShouldBeFalse();
            text2.IsNullable<Int32Enum?>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string enum value to nullable enum type test")]
        public void JudgingInvalidStringEnumValueToNullableEnumTypeTest()
        {
            var type = typeof(Int32Enum);
            var nullableType = typeof(Int32Enum?);
            var text = "D";

            text.Is(type).ShouldBeFalse();
            text.Is(type, Context).ShouldBeFalse();

            text.Is<Int32Enum>().ShouldBeFalse();
            text.Is<Int32Enum>(Context).ShouldBeFalse();

            text.Is(nullableType).ShouldBeFalse();
            text.Is(nullableType, Context).ShouldBeFalse();

            text.Is<Int32Enum?>().ShouldBeFalse();
            text.Is<Int32Enum?>(Context).ShouldBeFalse();

            text.IsNullable(type).ShouldBeFalse();
            text.IsNullable(type, Context).ShouldBeFalse();
            
            text.IsNullable(nullableType).ShouldBeFalse();
            text.IsNullable(nullableType, Context).ShouldBeFalse();

            text.IsNullable<Int32Enum>().ShouldBeFalse();
            text.IsNullable<Int32Enum>(Context).ShouldBeFalse();
            
            text.IsNullable<Int32Enum?>().ShouldBeFalse();
            text.IsNullable<Int32Enum?>(Context).ShouldBeFalse();
        }
    }
}