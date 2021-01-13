using System;
using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsDa")]
    public class StringConvBeDateTimeOffsetTypeTests
    {
        public StringConvBeDateTimeOffsetTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is DateTimeOffset type or not test")]
        public void JudgingStringIsDateTimeOffsetTypeTest()
        {
            var type = typeof(DateTimeOffset);
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTimeOffset type or not and ignore case test")]
        public void JudgingStringIsDateTimeOffsetTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeOffset);
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTimeOffset type or not by generic type test")]
        public void JudgingStringIsDateTimeOffsetTypeByGenericTypeTest()
        {
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTimeOffset>().ShouldBeTrue();
            text1.Is<DateTimeOffset>().ShouldBeTrue();
            text2.Is<DateTimeOffset>().ShouldBeTrue();
            text3.Is<DateTimeOffset>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTimeOffset type or not by generic type and ignore case test")]
        public void JudgingStringIsDateTimeOffsetTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTimeOffset>(Context).ShouldBeTrue();
            text1.Is<DateTimeOffset>(Context).ShouldBeTrue();
            text2.Is<DateTimeOffset>(Context).ShouldBeTrue();
            text3.Is<DateTimeOffset>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeOffset type or not test")]
        public void JudgingNullOrEmptyStringIsDateTimeOffsetTypeTest()
        {
            var type = typeof(DateTimeOffset);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeOffset type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsDateTimeOffsetTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeOffset);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeOffset type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsDateTimeOffsetTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeOffset>().ShouldBeFalse();
            text1.Is<DateTimeOffset>().ShouldBeFalse();
            text2.Is<DateTimeOffset>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeOffset type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsDateTimeOffsetTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeOffset>(Context).ShouldBeFalse();
            text1.Is<DateTimeOffset>(Context).ShouldBeFalse();
            text2.Is<DateTimeOffset>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string test")]
        public void JudgingInvalidStringTest()
        {
            var type = typeof(DateTimeOffset);
            var text0 = "D";
            var text1 = "2000-13-01";
            var text2 = "2000-12-32";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, Context).ShouldBeFalse();

            text0.Is<DateTimeOffset>().ShouldBeFalse();
            text0.Is<DateTimeOffset>(Context).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();

            text1.Is<DateTimeOffset>().ShouldBeFalse();
            text1.Is<DateTimeOffset>(Context).ShouldBeFalse();

            text2.Is(type).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();

            text2.Is<DateTimeOffset>().ShouldBeFalse();
            text2.Is<DateTimeOffset>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable DateTimeOffset type or not test")]
        public void JudgingStringIsNullableDateTimeOffsetTypeTest()
        {
            var type = typeof(DateTimeOffset);
            var nullableType = typeof(DateTimeOffset?);
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();
            text3.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
            text3.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTimeOffset type or not and ignore case test")]
        public void JudgingStringIsNullableDateTimeOffsetTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeOffset);
            var nullableType = typeof(DateTimeOffset?);
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeTrue();
            text2.Is(nullableType, Context).ShouldBeTrue();
            text3.Is(nullableType, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();
            text3.IsNullable(type, Context).ShouldBeTrue();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
            text2.IsNullable(nullableType, Context).ShouldBeTrue();
            text3.IsNullable(nullableType, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTimeOffset type or not by generic type test")]
        public void JudgingStringIsNullableDateTimeOffsetTypeByGenericTypeTest()
        {
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTimeOffset>().ShouldBeTrue();
            text1.Is<DateTimeOffset>().ShouldBeTrue();
            text2.Is<DateTimeOffset>().ShouldBeTrue();
            text3.Is<DateTimeOffset>().ShouldBeTrue();

            text0.Is<DateTimeOffset?>().ShouldBeTrue();
            text1.Is<DateTimeOffset?>().ShouldBeTrue();
            text2.Is<DateTimeOffset?>().ShouldBeTrue();
            text3.Is<DateTimeOffset?>().ShouldBeTrue();

            text0.IsNullable<DateTimeOffset>().ShouldBeTrue();
            text1.IsNullable<DateTimeOffset>().ShouldBeTrue();
            text2.IsNullable<DateTimeOffset>().ShouldBeTrue();
            text3.IsNullable<DateTimeOffset>().ShouldBeTrue();

            text0.IsNullable<DateTimeOffset?>().ShouldBeTrue();
            text1.IsNullable<DateTimeOffset?>().ShouldBeTrue();
            text2.IsNullable<DateTimeOffset?>().ShouldBeTrue();
            text3.IsNullable<DateTimeOffset?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTimeOffset type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableDateTimeOffsetTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var text1 = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTimeOffset.UtcNow.ToString("yyyy MM dd");
            var text3 = DateTimeOffset.UtcNow.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTimeOffset>(Context).ShouldBeTrue();
            text1.Is<DateTimeOffset>(Context).ShouldBeTrue();
            text2.Is<DateTimeOffset>(Context).ShouldBeTrue();
            text3.Is<DateTimeOffset>(Context).ShouldBeTrue();

            text0.Is<DateTimeOffset?>(Context).ShouldBeTrue();
            text1.Is<DateTimeOffset?>(Context).ShouldBeTrue();
            text2.Is<DateTimeOffset?>(Context).ShouldBeTrue();
            text3.Is<DateTimeOffset?>(Context).ShouldBeTrue();

            text0.IsNullable<DateTimeOffset>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeOffset>(Context).ShouldBeTrue();
            text2.IsNullable<DateTimeOffset>(Context).ShouldBeTrue();
            text3.IsNullable<DateTimeOffset>(Context).ShouldBeTrue();

            text0.IsNullable<DateTimeOffset?>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeOffset?>(Context).ShouldBeTrue();
            text2.IsNullable<DateTimeOffset?>(Context).ShouldBeTrue();
            text3.IsNullable<DateTimeOffset?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeOffset type or not test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeOffsetTypeTest()
        {
            var type = typeof(DateTimeOffset);
            var nullableType = typeof(DateTimeOffset?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeOffset type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeOffsetTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeOffset);
            var nullableType = typeof(DateTimeOffset?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeOffset type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeOffsetTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeOffset?>().ShouldBeTrue();
            text1.Is<DateTimeOffset?>().ShouldBeFalse();
            text2.Is<DateTimeOffset?>().ShouldBeFalse();

            text0.IsNullable<DateTimeOffset>().ShouldBeTrue();
            text1.IsNullable<DateTimeOffset>().ShouldBeFalse();
            text2.IsNullable<DateTimeOffset>().ShouldBeFalse();

            text0.IsNullable<DateTimeOffset?>().ShouldBeTrue();
            text1.IsNullable<DateTimeOffset?>().ShouldBeFalse();
            text2.IsNullable<DateTimeOffset?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeOffset type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeOffsetTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeOffset?>(Context).ShouldBeTrue();
            text1.Is<DateTimeOffset?>(Context).ShouldBeFalse();
            text2.Is<DateTimeOffset?>(Context).ShouldBeFalse();

            text0.IsNullable<DateTimeOffset>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeOffset>(Context).ShouldBeFalse();
            text2.IsNullable<DateTimeOffset>(Context).ShouldBeFalse();

            text0.IsNullable<DateTimeOffset?>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeOffset?>(Context).ShouldBeFalse();
            text2.IsNullable<DateTimeOffset?>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string to nullable DateTimeOffset type test")]
        public void JudgingInvalidStringToNullableDateTimeOffsetTypeTest()
        {
            var type = typeof(DateTimeOffset);
            var nullableType = typeof(DateTimeOffset?);
            var text0 = "D";
            var text1 = "2000-13-01";
            var text2 = "2000-12-32";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, Context).ShouldBeFalse();

            text0.Is<DateTimeOffset>().ShouldBeFalse();
            text0.Is<DateTimeOffset>(Context).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeFalse();
            text0.Is(nullableType, Context).ShouldBeFalse();

            text0.Is<DateTimeOffset?>().ShouldBeFalse();
            text0.Is<DateTimeOffset?>(Context).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeFalse();
            text0.IsNullable(type, Context).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeFalse();
            text0.IsNullable(nullableType, Context).ShouldBeFalse();

            text0.IsNullable<DateTimeOffset>().ShouldBeFalse();
            text0.IsNullable<DateTimeOffset>(Context).ShouldBeFalse();

            text0.IsNullable<DateTimeOffset?>().ShouldBeFalse();
            text0.IsNullable<DateTimeOffset?>(Context).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();

            text1.Is<DateTimeOffset>().ShouldBeFalse();
            text1.Is<DateTimeOffset>(Context).ShouldBeFalse();

            text1.Is(nullableType).ShouldBeFalse();
            text1.Is(nullableType, Context).ShouldBeFalse();

            text1.Is<DateTimeOffset?>().ShouldBeFalse();
            text1.Is<DateTimeOffset?>(Context).ShouldBeFalse();

            text1.IsNullable(type).ShouldBeFalse();
            text1.IsNullable(type, Context).ShouldBeFalse();

            text1.IsNullable(nullableType).ShouldBeFalse();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();

            text1.IsNullable<DateTimeOffset>().ShouldBeFalse();
            text1.IsNullable<DateTimeOffset>(Context).ShouldBeFalse();

            text1.IsNullable<DateTimeOffset?>().ShouldBeFalse();
            text1.IsNullable<DateTimeOffset?>(Context).ShouldBeFalse();

            text2.Is(type).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();

            text2.Is<DateTimeOffset>().ShouldBeFalse();
            text2.Is<DateTimeOffset>(Context).ShouldBeFalse();

            text2.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();

            text2.Is<DateTimeOffset?>().ShouldBeFalse();
            text2.Is<DateTimeOffset?>(Context).ShouldBeFalse();

            text2.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();

            text2.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();

            text2.IsNullable<DateTimeOffset>().ShouldBeFalse();
            text2.IsNullable<DateTimeOffset>(Context).ShouldBeFalse();

            text2.IsNullable<DateTimeOffset?>().ShouldBeFalse();
            text2.IsNullable<DateTimeOffset?>(Context).ShouldBeFalse();
        }
    }
}