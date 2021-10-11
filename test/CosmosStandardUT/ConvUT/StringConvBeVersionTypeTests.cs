using System;
using CosmosStack.Conversions;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsVersion")]
    public class StringConvBeVersionTypeTests
    {
        public StringConvBeVersionTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is Version type or not test")]
        public void JudgingStringIsVersionTypeTest()
        {
            var type = typeof(Version);
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Version type or not and ignore case test")]
        public void JudgingStringIsVersionTypeWithIgnoreCaseTest()
        {
            var type = typeof(Version);
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Version type or not by generic type test")]
        public void JudgingStringIsVersionTypeByGenericTypeTest()
        {
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is<Version>().ShouldBeTrue();
            text1.Is<Version>().ShouldBeTrue();
            text2.Is<Version>().ShouldBeTrue();
            text3.Is<Version>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Version type or not by generic type and ignore case test")]
        public void JudgingStringIsVersionTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is<Version>(Context).ShouldBeTrue();
            text1.Is<Version>(Context).ShouldBeTrue();
            text2.Is<Version>(Context).ShouldBeTrue();
            text3.Is<Version>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Version type or not test")]
        public void JudgingNullOrEmptyStringIsVersionTypeTest()
        {
            var type = typeof(Version);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Version type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsVersionTypeWithIgnoreCaseTest()
        {
            var type = typeof(Version);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Version type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsVersionTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is<Version>().ShouldBeFalse();
            text1.Is<Version>().ShouldBeFalse();
            text2.Is<Version>().ShouldBeFalse();
            text3.Is<Version>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Version type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsVersionTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is<Version>(Context).ShouldBeFalse();
            text1.Is<Version>(Context).ShouldBeFalse();
            text2.Is<Version>(Context).ShouldBeFalse();
            text3.Is<Version>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Version type or not test")]
        public void JudgingStringIsNullableVersionTypeTest()
        {
            var type = typeof(Version);
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Version type or not and ignore case test")]
        public void JudgingStringIsNullableVersionTypeWithIgnoreCaseTest()
        {
            var type = typeof(Version);
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();
            text3.IsNullable(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Version type or not by generic type test")]
        public void JudgingStringIsNullableVersionTypeByGenericTypeTest()
        {
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is<Version>().ShouldBeTrue();
            text1.Is<Version>().ShouldBeTrue();
            text2.Is<Version>().ShouldBeTrue();
            text3.Is<Version>().ShouldBeTrue();

            text0.IsNullable<Version>().ShouldBeTrue();
            text1.IsNullable<Version>().ShouldBeTrue();
            text2.IsNullable<Version>().ShouldBeTrue();
            text3.IsNullable<Version>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Version type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableVersionTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = new Version(1, 1).ToString();
            var text1 = new Version(1, 1, 1).ToString();
            var text2 = new Version(1, 1, 1, 1).ToString();
            var text3 = new Version("1.1.1.1").ToString();

            text0.Is<Version>(Context).ShouldBeTrue();
            text1.Is<Version>(Context).ShouldBeTrue();
            text2.Is<Version>(Context).ShouldBeTrue();
            text3.Is<Version>(Context).ShouldBeTrue();

            text0.IsNullable<Version>(Context).ShouldBeTrue();
            text1.IsNullable<Version>(Context).ShouldBeTrue();
            text2.IsNullable<Version>(Context).ShouldBeTrue();
            text3.IsNullable<Version>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Version type or not test")]
        public void JudgingNullOrEmptyStringIsNullableVersionTypeTest()
        {
            var type = typeof(Version);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Version type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableVersionTypeWithIgnoreCaseTest()
        {
            var type = typeof(Version);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();
            text3.IsNullable(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Version type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableVersionTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.IsNullable<Version>().ShouldBeTrue();
            text1.IsNullable<Version>().ShouldBeFalse();
            text2.IsNullable<Version>().ShouldBeFalse();
            text3.IsNullable<Version>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Version type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableVersionTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.IsNullable<Version>(Context).ShouldBeTrue();
            text1.IsNullable<Version>(Context).ShouldBeFalse();
            text2.IsNullable<Version>(Context).ShouldBeFalse();
            text3.IsNullable<Version>(Context).ShouldBeFalse();
        }
    }
}