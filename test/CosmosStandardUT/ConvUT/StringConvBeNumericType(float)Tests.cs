using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT;

[Trait("ConvUT", "StringConv.JudgeIsNumeric(Float)")]
public class StringConvBeFloatTypeTests
{
    public StringConvBeFloatTypeTests()
    {
        Context = new CastingContext
        {
            IgnoreCase = IgnoreCase.TRUE
        };
    }

    private CastingContext Context { get; set; }

    [Fact(DisplayName = "To judge string is Float type or not test")]
    public void JudgingStringIsFloatTypeTest()
    {
        var type = typeof(float);
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is(type).ShouldBeTrue();
        text1.Is(type).ShouldBeTrue();
        text2.Is(type).ShouldBeTrue();
        text3.Is(type).ShouldBeTrue();
        text4.Is(type).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is Float type or not and ignore case test")]
    public void JudgingStringIsFloatTypeWithIgnoreCaseTest()
    {
        var type = typeof(float);
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is(type, Context).ShouldBeTrue();
        text1.Is(type, Context).ShouldBeTrue();
        text2.Is(type, Context).ShouldBeTrue();
        text3.Is(type, Context).ShouldBeTrue();
        text4.Is(type, Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is Float type or not by generic type test")]
    public void JudgingStringIsFloatTypeByGenericTypeTest()
    {
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is<float>().ShouldBeTrue();
        text1.Is<float>().ShouldBeTrue();
        text2.Is<float>().ShouldBeTrue();
        text3.Is<float>().ShouldBeTrue();
        text4.Is<float>().ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is Float type or not by generic type and ignore case test")]
    public void JudgingStringIsFloatTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is<float>(Context).ShouldBeTrue();
        text1.Is<float>(Context).ShouldBeTrue();
        text2.Is<float>(Context).ShouldBeTrue();
        text3.Is<float>(Context).ShouldBeTrue();
        text4.Is<float>(Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge null or empty string is Float type or not test")]
    public void JudgingNullOrEmptyStringIsFloatTypeTest()
    {
        var type = typeof(float);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is(type).ShouldBeFalse();
        text1.Is(type).ShouldBeFalse();
        text2.Is(type).ShouldBeFalse();
        text3.Is(type).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is Float type or not and ignore case test")]
    public void JudgingNullOrEmptyStringIsFloatTypeWithIgnoreCaseTest()
    {
        var type = typeof(float);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is(type, Context).ShouldBeFalse();
        text1.Is(type, Context).ShouldBeFalse();
        text2.Is(type, Context).ShouldBeFalse();
        text3.Is(type, Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is Float type or not by generic type test")]
    public void JudgingNullOrEmptyStringIsFloatTypeByGenericTypeTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is<float>().ShouldBeFalse();
        text1.Is<float>().ShouldBeFalse();
        text2.Is<float>().ShouldBeFalse();
        text3.Is<float>().ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is Float type or not by generic type and ignore case test")]
    public void JudgingNullOrEmptyStringIsFloatTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is<float>(Context).ShouldBeFalse();
        text1.Is<float>(Context).ShouldBeFalse();
        text2.Is<float>(Context).ShouldBeFalse();
        text3.Is<float>(Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge string is nullable Float type or not test")]
    public void JudgingStringIsNullableFloatTypeTest()
    {
        var type = typeof(float);
        var nullableType = typeof(float?);
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is(type).ShouldBeTrue();
        text1.Is(type).ShouldBeTrue();
        text2.Is(type).ShouldBeTrue();
        text3.Is(type).ShouldBeTrue();
        text4.Is(type).ShouldBeTrue();

        text0.Is(nullableType).ShouldBeTrue();
        text1.Is(nullableType).ShouldBeTrue();
        text2.Is(nullableType).ShouldBeTrue();
        text3.Is(nullableType).ShouldBeTrue();
        text4.Is(nullableType).ShouldBeTrue();

        text0.IsNullable(type).ShouldBeTrue();
        text1.IsNullable(type).ShouldBeTrue();
        text2.IsNullable(type).ShouldBeTrue();
        text3.IsNullable(type).ShouldBeTrue();
        text4.IsNullable(type).ShouldBeTrue();

        text0.IsNullable(nullableType).ShouldBeTrue();
        text1.IsNullable(nullableType).ShouldBeTrue();
        text2.IsNullable(nullableType).ShouldBeTrue();
        text3.IsNullable(nullableType).ShouldBeTrue();
        text4.IsNullable(nullableType).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is nullable Float type or not and ignore case test")]
    public void JudgingStringIsNullableFloatTypeWithIgnoreCaseTest()
    {
        var type = typeof(float);
        var nullableType = typeof(float?);
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is(type, Context).ShouldBeTrue();
        text1.Is(type, Context).ShouldBeTrue();
        text2.Is(type, Context).ShouldBeTrue();
        text3.Is(type, Context).ShouldBeTrue();
        text4.Is(type, Context).ShouldBeTrue();

        text0.Is(nullableType, Context).ShouldBeTrue();
        text1.Is(nullableType, Context).ShouldBeTrue();
        text2.Is(nullableType, Context).ShouldBeTrue();
        text3.Is(nullableType, Context).ShouldBeTrue();
        text4.Is(nullableType, Context).ShouldBeTrue();

        text0.IsNullable(type, Context).ShouldBeTrue();
        text1.IsNullable(type, Context).ShouldBeTrue();
        text2.IsNullable(type, Context).ShouldBeTrue();
        text3.IsNullable(type, Context).ShouldBeTrue();
        text4.IsNullable(type, Context).ShouldBeTrue();

        text0.IsNullable(nullableType, Context).ShouldBeTrue();
        text1.IsNullable(nullableType, Context).ShouldBeTrue();
        text2.IsNullable(nullableType, Context).ShouldBeTrue();
        text3.IsNullable(nullableType, Context).ShouldBeTrue();
        text4.IsNullable(nullableType, Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is nullable Float type or not by generic type test")]
    public void JudgingStringIsNullableFloatTypeByGenericTypeTest()
    {
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is<float>().ShouldBeTrue();
        text1.Is<float>().ShouldBeTrue();
        text2.Is<float>().ShouldBeTrue();
        text3.Is<float>().ShouldBeTrue();
        text4.Is<float>().ShouldBeTrue();

        text0.Is<float?>().ShouldBeTrue();
        text1.Is<float?>().ShouldBeTrue();
        text2.Is<float?>().ShouldBeTrue();
        text3.Is<float?>().ShouldBeTrue();
        text4.Is<float?>().ShouldBeTrue();

        text0.IsNullable<float>().ShouldBeTrue();
        text1.IsNullable<float>().ShouldBeTrue();
        text2.IsNullable<float>().ShouldBeTrue();
        text3.IsNullable<float>().ShouldBeTrue();
        text4.IsNullable<float>().ShouldBeTrue();

        text0.IsNullable<float?>().ShouldBeTrue();
        text1.IsNullable<float?>().ShouldBeTrue();
        text2.IsNullable<float?>().ShouldBeTrue();
        text3.IsNullable<float?>().ShouldBeTrue();
        text4.IsNullable<float?>().ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is nullable Float type or not by generic type and ignore case test")]
    public void JudgingStringIsNullableFloatTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        var text0 = "-1";
        var text1 = "0";
        var text2 = "1";
        var text3 = "-1.1";
        var text4 = "1.1";

        text0.Is<float>(Context).ShouldBeTrue();
        text1.Is<float>(Context).ShouldBeTrue();
        text2.Is<float>(Context).ShouldBeTrue();
        text3.Is<float>(Context).ShouldBeTrue();
        text4.Is<float>(Context).ShouldBeTrue();

        text0.Is<float?>(Context).ShouldBeTrue();
        text1.Is<float?>(Context).ShouldBeTrue();
        text2.Is<float?>(Context).ShouldBeTrue();
        text3.Is<float?>(Context).ShouldBeTrue();
        text4.Is<float?>(Context).ShouldBeTrue();

        text0.IsNullable<float>(Context).ShouldBeTrue();
        text1.IsNullable<float>(Context).ShouldBeTrue();
        text2.IsNullable<float>(Context).ShouldBeTrue();
        text3.IsNullable<float>(Context).ShouldBeTrue();
        text4.IsNullable<float>(Context).ShouldBeTrue();

        text0.IsNullable<float?>(Context).ShouldBeTrue();
        text1.IsNullable<float?>(Context).ShouldBeTrue();
        text2.IsNullable<float?>(Context).ShouldBeTrue();
        text3.IsNullable<float?>(Context).ShouldBeTrue();
        text4.IsNullable<float?>(Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable Float type or not test")]
    public void JudgingNullOrEmptyStringIsNullableFloatTypeTest()
    {
        var type = typeof(float);
        var nullableType = typeof(float?);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is(type).ShouldBeFalse();
        text1.Is(type).ShouldBeFalse();
        text2.Is(type).ShouldBeFalse();
        text3.Is(type).ShouldBeFalse();

        text0.Is(nullableType).ShouldBeTrue();
        text1.Is(nullableType).ShouldBeFalse();
        text2.Is(nullableType).ShouldBeFalse();
        text3.Is(nullableType).ShouldBeFalse();

        text0.IsNullable(type).ShouldBeTrue();
        text1.IsNullable(type).ShouldBeFalse();
        text2.IsNullable(type).ShouldBeFalse();
        text3.IsNullable(type).ShouldBeFalse();

        text0.IsNullable(nullableType).ShouldBeTrue();
        text1.IsNullable(nullableType).ShouldBeFalse();
        text2.IsNullable(nullableType).ShouldBeFalse();
        text3.IsNullable(nullableType).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable Float type or not and ignore case test")]
    public void JudgingNullOrEmptyStringIsNullableFloatTypeWithIgnoreCaseTest()
    {
        var type = typeof(float);
        var nullableType = typeof(float?);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is(type, Context).ShouldBeFalse();
        text1.Is(type, Context).ShouldBeFalse();
        text2.Is(type, Context).ShouldBeFalse();
        text3.Is(type, Context).ShouldBeFalse();

        text0.Is(nullableType, Context).ShouldBeTrue();
        text1.Is(nullableType, Context).ShouldBeFalse();
        text2.Is(nullableType, Context).ShouldBeFalse();
        text3.Is(nullableType, Context).ShouldBeFalse();

        text0.IsNullable(type, Context).ShouldBeTrue();
        text1.IsNullable(type, Context).ShouldBeFalse();
        text2.IsNullable(type, Context).ShouldBeFalse();
        text3.IsNullable(type, Context).ShouldBeFalse();

        text0.IsNullable(nullableType, Context).ShouldBeTrue();
        text1.IsNullable(nullableType, Context).ShouldBeFalse();
        text2.IsNullable(nullableType, Context).ShouldBeFalse();
        text3.IsNullable(nullableType, Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable Float type or not by generic type test")]
    public void JudgingNullOrEmptyStringIsNullableFloatTypeByGenericTypeTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is<float?>().ShouldBeTrue();
        text1.Is<float?>().ShouldBeFalse();
        text2.Is<float?>().ShouldBeFalse();
        text3.Is<float?>().ShouldBeFalse();

        text0.IsNullable<float>().ShouldBeTrue();
        text1.IsNullable<float>().ShouldBeFalse();
        text2.IsNullable<float>().ShouldBeFalse();
        text3.IsNullable<float>().ShouldBeFalse();

        text0.IsNullable<float?>().ShouldBeTrue();
        text1.IsNullable<float?>().ShouldBeFalse();
        text2.IsNullable<float?>().ShouldBeFalse();
        text3.IsNullable<float?>().ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable Float type or not by generic type and ignore case test")]
    public void JudgingNullOrEmptyStringIsNullableFloatTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";
        string text3 = "C";

        text0.Is<float?>(Context).ShouldBeTrue();
        text1.Is<float?>(Context).ShouldBeFalse();
        text2.Is<float?>(Context).ShouldBeFalse();
        text3.Is<float?>(Context).ShouldBeFalse();

        text0.IsNullable<float>(Context).ShouldBeTrue();
        text1.IsNullable<float>(Context).ShouldBeFalse();
        text2.IsNullable<float>(Context).ShouldBeFalse();
        text3.IsNullable<float>(Context).ShouldBeFalse();

        text0.IsNullable<float?>(Context).ShouldBeTrue();
        text1.IsNullable<float?>(Context).ShouldBeFalse();
        text2.IsNullable<float?>(Context).ShouldBeFalse();
        text3.IsNullable<float?>(Context).ShouldBeFalse();
    }
}