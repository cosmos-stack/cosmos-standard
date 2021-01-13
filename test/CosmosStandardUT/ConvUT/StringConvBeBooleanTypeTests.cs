using Cosmos.Conversions;
using Cosmos.Text;
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

        [Fact(DisplayName = "To judge string is bool type or not test")]
        public void JudgingStringIsBooleanTypeTest()
        {
            var type = typeof(bool);
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            text4.Is(type).ShouldBeTrue();
            text5.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is bool type or not and ignore case test")]
        public void JudgingStringIsBooleanTypeWithIgnoreCaseTest()
        {
            var type = typeof(bool);
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
            text4.Is(type, Context).ShouldBeTrue();
            text5.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is bool type or not by generic type test")]
        public void JudgingStringIsBooleanTypeByGenericTypeTest()
        {
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is<bool>().ShouldBeTrue();
            text1.Is<bool>().ShouldBeTrue();
            text2.Is<bool>().ShouldBeTrue();
            text3.Is<bool>().ShouldBeTrue();
            text4.Is<bool>().ShouldBeTrue();
            text5.Is<bool>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is bool type or not by generic type and ignore case test")]
        public void JudgingStringIsBooleanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is<bool>(Context).ShouldBeTrue();
            text1.Is<bool>(Context).ShouldBeTrue();
            text2.Is<bool>(Context).ShouldBeTrue();
            text3.Is<bool>(Context).ShouldBeTrue();
            text4.Is<bool>(Context).ShouldBeTrue();
            text5.Is<bool>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is bool type or not test")]
        public void JudgingNullOrEmptyStringIsBooleanTypeTest()
        {
            var type = typeof(bool);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is bool type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsBooleanTypeWithIgnoreCaseTest()
        {
            var type = typeof(bool);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is bool type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsBooleanTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<bool>().ShouldBeFalse();
            text1.Is<bool>().ShouldBeFalse();
            text2.Is<bool>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is bool type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsBooleanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<bool>(Context).ShouldBeFalse();
            text1.Is<bool>(Context).ShouldBeFalse();
            text2.Is<bool>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable bool type or not test")]
        public void JudgingStringIsNullableBooleanTypeTest()
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            text4.Is(type).ShouldBeTrue();
            text5.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();
            text3.Is(nullableType).ShouldBeTrue();
            text4.Is(nullableType).ShouldBeTrue();
            text5.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();
            text4.IsNullable(type).ShouldBeTrue();
            text5.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
            text3.IsNullable(nullableType).ShouldBeTrue();
            text4.IsNullable(nullableType).ShouldBeTrue();
            text5.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable bool type or not and ignore case test")]
        public void JudgingStringIsNullableBooleanTypeWithIgnoreCaseTest()
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
            text4.Is(type, Context).ShouldBeTrue();
            text5.Is(type, Context).ShouldBeTrue();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeTrue();
            text2.Is(nullableType, Context).ShouldBeTrue();
            text3.Is(nullableType, Context).ShouldBeTrue();
            text4.Is(nullableType, Context).ShouldBeTrue();
            text5.Is(nullableType, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();
            text3.IsNullable(type, Context).ShouldBeTrue();
            text4.IsNullable(type, Context).ShouldBeTrue();
            text5.IsNullable(type, Context).ShouldBeTrue();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
            text2.IsNullable(nullableType, Context).ShouldBeTrue();
            text3.IsNullable(nullableType, Context).ShouldBeTrue();
            text4.IsNullable(nullableType, Context).ShouldBeTrue();
            text5.IsNullable(nullableType, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable bool type or not by generic type test")]
        public void JudgingStringIsNullableBooleanTypeByGenericTypeTest()
        {
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is<bool>().ShouldBeTrue();
            text1.Is<bool>().ShouldBeTrue();
            text2.Is<bool>().ShouldBeTrue();
            text3.Is<bool>().ShouldBeTrue();
            text4.Is<bool>().ShouldBeTrue();
            text5.Is<bool>().ShouldBeTrue();

            text0.Is<bool?>().ShouldBeTrue();
            text1.Is<bool?>().ShouldBeTrue();
            text2.Is<bool?>().ShouldBeTrue();
            text3.Is<bool?>().ShouldBeTrue();
            text4.Is<bool?>().ShouldBeTrue();
            text5.Is<bool?>().ShouldBeTrue();

            text0.IsNullable<bool>().ShouldBeTrue();
            text1.IsNullable<bool>().ShouldBeTrue();
            text2.IsNullable<bool>().ShouldBeTrue();
            text3.IsNullable<bool>().ShouldBeTrue();
            text4.IsNullable<bool>().ShouldBeTrue();
            text5.IsNullable<bool>().ShouldBeTrue();

            text0.IsNullable<bool?>().ShouldBeTrue();
            text1.IsNullable<bool?>().ShouldBeTrue();
            text2.IsNullable<bool?>().ShouldBeTrue();
            text3.IsNullable<bool?>().ShouldBeTrue();
            text4.IsNullable<bool?>().ShouldBeTrue();
            text5.IsNullable<bool?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable bool type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableBooleanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "true";
            var text1 = "True";
            var text2 = "TRUE";
            var text3 = "false";
            var text4 = "False";
            var text5 = "FALSE";

            text0.Is<bool>(Context).ShouldBeTrue();
            text1.Is<bool>(Context).ShouldBeTrue();
            text2.Is<bool>(Context).ShouldBeTrue();
            text3.Is<bool>(Context).ShouldBeTrue();
            text4.Is<bool>(Context).ShouldBeTrue();
            text5.Is<bool>(Context).ShouldBeTrue();

            text0.Is<bool?>(Context).ShouldBeTrue();
            text1.Is<bool?>(Context).ShouldBeTrue();
            text2.Is<bool?>(Context).ShouldBeTrue();
            text3.Is<bool?>(Context).ShouldBeTrue();
            text4.Is<bool?>(Context).ShouldBeTrue();
            text5.Is<bool?>(Context).ShouldBeTrue();

            text0.IsNullable<bool>(Context).ShouldBeTrue();
            text1.IsNullable<bool>(Context).ShouldBeTrue();
            text2.IsNullable<bool>(Context).ShouldBeTrue();
            text3.IsNullable<bool>(Context).ShouldBeTrue();
            text4.IsNullable<bool>(Context).ShouldBeTrue();
            text5.IsNullable<bool>(Context).ShouldBeTrue();

            text0.IsNullable<bool?>(Context).ShouldBeTrue();
            text1.IsNullable<bool?>(Context).ShouldBeTrue();
            text2.IsNullable<bool?>(Context).ShouldBeTrue();
            text3.IsNullable<bool?>(Context).ShouldBeTrue();
            text4.IsNullable<bool?>(Context).ShouldBeTrue();
            text5.IsNullable<bool?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable bool type or not test")]
        public void JudgingNullOrEmptyStringIsNullableBooleanTypeTest()
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable bool type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableBooleanTypeWithIgnoreCaseTest()
        {
            var type = typeof(bool);
            var nullableType = typeof(bool?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable bool type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableBooleanTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<bool?>().ShouldBeTrue();
            text1.Is<bool?>().ShouldBeFalse();
            text2.Is<bool?>().ShouldBeFalse();

            text0.IsNullable<bool>().ShouldBeTrue();
            text1.IsNullable<bool>().ShouldBeFalse();
            text2.IsNullable<bool>().ShouldBeFalse();

            text0.IsNullable<bool?>().ShouldBeTrue();
            text1.IsNullable<bool?>().ShouldBeFalse();
            text2.IsNullable<bool?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable bool type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableBooleanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<bool?>(Context).ShouldBeTrue();
            text1.Is<bool?>(Context).ShouldBeFalse();
            text2.Is<bool?>(Context).ShouldBeFalse();

            text0.IsNullable<bool>(Context).ShouldBeTrue();
            text1.IsNullable<bool>(Context).ShouldBeFalse();
            text2.IsNullable<bool>(Context).ShouldBeFalse();

            text0.IsNullable<bool?>(Context).ShouldBeTrue();
            text1.IsNullable<bool?>(Context).ShouldBeFalse();
            text2.IsNullable<bool?>(Context).ShouldBeFalse();
        }
    }
}