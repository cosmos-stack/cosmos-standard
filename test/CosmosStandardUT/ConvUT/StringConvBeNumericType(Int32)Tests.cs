using System;
using CosmosStack.Conversions;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(Int32)")]
    public class StringConvBeInt32TypeTests
    {
        public StringConvBeInt32TypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is Int32 type or not test")]
        public void JudgingStringIsInt32TypeTest()
        {
            var type = typeof(Int32);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Int32 type or not and ignore case test")]
        public void JudgingStringIsInt32TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Int32 type or not by generic type test")]
        public void JudgingStringIsInt32TypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int32>().ShouldBeTrue();
            text1.Is<Int32>().ShouldBeTrue();
            text2.Is<Int32>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Int32 type or not by generic type and ignore case test")]
        public void JudgingStringIsInt32TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int32>(Context).ShouldBeTrue();
            text1.Is<Int32>(Context).ShouldBeTrue();
            text2.Is<Int32>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Int32 type or not test")]
        public void JudgingNullOrEmptyStringIsInt32TypeTest()
        {
            var type = typeof(Int32);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Int32 type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsInt32TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
            text4.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Int32 type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsInt32TypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int32>().ShouldBeFalse();
            text1.Is<Int32>().ShouldBeFalse();
            text2.Is<Int32>().ShouldBeFalse();
            text3.Is<Int32>().ShouldBeFalse();
            text4.Is<Int32>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Int32 type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsInt32TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int32>(Context).ShouldBeFalse();
            text1.Is<Int32>(Context).ShouldBeFalse();
            text2.Is<Int32>(Context).ShouldBeFalse();
            text3.Is<Int32>(Context).ShouldBeFalse();
            text4.Is<Int32>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Int32 type or not test")]
        public void JudgingStringIsNullableInt32TypeTest()
        {
            var type = typeof(Int32);
            var nullableType = typeof(Int32?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Int32 type or not and ignore case test")]
        public void JudgingStringIsNullableInt32TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32);
            var nullableType = typeof(Int32?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeTrue();
            text2.Is(nullableType, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
            text2.IsNullable(nullableType, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Int32 type or not by generic type test")]
        public void JudgingStringIsNullableInt32TypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int32>().ShouldBeTrue();
            text1.Is<Int32>().ShouldBeTrue();
            text2.Is<Int32>().ShouldBeTrue();

            text0.Is<Int32?>().ShouldBeTrue();
            text1.Is<Int32?>().ShouldBeTrue();
            text2.Is<Int32?>().ShouldBeTrue();

            text0.IsNullable<Int32>().ShouldBeTrue();
            text1.IsNullable<Int32>().ShouldBeTrue();
            text2.IsNullable<Int32>().ShouldBeTrue();

            text0.IsNullable<Int32?>().ShouldBeTrue();
            text1.IsNullable<Int32?>().ShouldBeTrue();
            text2.IsNullable<Int32?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Int32 type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableInt32TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int32>(Context).ShouldBeTrue();
            text1.Is<Int32>(Context).ShouldBeTrue();
            text2.Is<Int32>(Context).ShouldBeTrue();

            text0.Is<Int32?>(Context).ShouldBeTrue();
            text1.Is<Int32?>(Context).ShouldBeTrue();
            text2.Is<Int32?>(Context).ShouldBeTrue();

            text0.IsNullable<Int32>(Context).ShouldBeTrue();
            text1.IsNullable<Int32>(Context).ShouldBeTrue();
            text2.IsNullable<Int32>(Context).ShouldBeTrue();

            text0.IsNullable<Int32?>(Context).ShouldBeTrue();
            text1.IsNullable<Int32?>(Context).ShouldBeTrue();
            text2.IsNullable<Int32?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Int32 type or not test")]
        public void JudgingNullOrEmptyStringIsNullableInt32TypeTest()
        {
            var type = typeof(Int32);
            var nullableType = typeof(Int32?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType).ShouldBeFalse();
            text3.Is(nullableType).ShouldBeFalse();
            text4.Is(nullableType).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();
            text4.IsNullable(type).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType).ShouldBeFalse();
            text3.IsNullable(nullableType).ShouldBeFalse();
            text4.IsNullable(nullableType).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Int32 type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableInt32TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int32);
            var nullableType = typeof(Int32?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
            text4.Is(type, Context).ShouldBeFalse();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();
            text3.Is(nullableType, Context).ShouldBeFalse();
            text4.Is(nullableType, Context).ShouldBeFalse();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();
            text3.IsNullable(type, Context).ShouldBeFalse();
            text4.IsNullable(type, Context).ShouldBeFalse();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();
            text3.IsNullable(nullableType, Context).ShouldBeFalse();
            text4.IsNullable(nullableType, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Int32 type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableInt32TypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int32?>().ShouldBeTrue();
            text1.Is<Int32?>().ShouldBeFalse();
            text2.Is<Int32?>().ShouldBeFalse();
            text3.Is<Int32?>().ShouldBeFalse();
            text4.Is<Int32?>().ShouldBeFalse();

            text0.IsNullable<Int32>().ShouldBeTrue();
            text1.IsNullable<Int32>().ShouldBeFalse();
            text2.IsNullable<Int32>().ShouldBeFalse();
            text3.IsNullable<Int32>().ShouldBeFalse();
            text4.IsNullable<Int32>().ShouldBeFalse();

            text0.IsNullable<Int32?>().ShouldBeTrue();
            text1.IsNullable<Int32?>().ShouldBeFalse();
            text2.IsNullable<Int32?>().ShouldBeFalse();
            text3.IsNullable<Int32?>().ShouldBeFalse();
            text4.IsNullable<Int32?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Int32 type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableInt32TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int32?>(Context).ShouldBeTrue();
            text1.Is<Int32?>(Context).ShouldBeFalse();
            text2.Is<Int32?>(Context).ShouldBeFalse();
            text3.Is<Int32?>(Context).ShouldBeFalse();
            text4.Is<Int32?>(Context).ShouldBeFalse();

            text0.IsNullable<Int32>(Context).ShouldBeTrue();
            text1.IsNullable<Int32>(Context).ShouldBeFalse();
            text2.IsNullable<Int32>(Context).ShouldBeFalse();
            text3.IsNullable<Int32>(Context).ShouldBeFalse();
            text4.IsNullable<Int32>(Context).ShouldBeFalse();

            text0.IsNullable<Int32?>(Context).ShouldBeTrue();
            text1.IsNullable<Int32?>(Context).ShouldBeFalse();
            text2.IsNullable<Int32?>(Context).ShouldBeFalse();
            text3.IsNullable<Int32?>(Context).ShouldBeFalse();
            text4.IsNullable<Int32?>(Context).ShouldBeFalse();
        }
    }
}