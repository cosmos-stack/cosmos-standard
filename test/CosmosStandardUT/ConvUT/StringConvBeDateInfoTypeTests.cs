using Cosmos.Conversions;
using Cosmos.Date;
using Cosmos.Text;

namespace CosmosStandardUT.ConvUT;

[Trait("ConvUT", "StringConv.JudgeIsDateInfo")]
public class StringConvBeDateInfoTypeTests
{
    public StringConvBeDateInfoTypeTests()
    {
        Context = new CastingContext
        {
            IgnoreCase = IgnoreCase.TRUE
        };
    }

    private CastingContext Context { get; set; }
        
    [Fact(DisplayName = "To judge string is DateInfo type or not test")]
    public void JudgingStringIsDateInfoTypeTest()
    {
        var type = typeof(DateInfo);
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is(type).ShouldBeTrue();
        text1.Is(type).ShouldBeTrue();
        text2.Is(type).ShouldBeTrue();
        text3.Is(type).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is DateInfo type or not and ignore case test")]
    public void JudgingStringIsDateInfoTypeWithIgnoreCaseTest()
    {
        var type = typeof(DateInfo);
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is(type, Context).ShouldBeTrue();
        text1.Is(type, Context).ShouldBeTrue();
        text2.Is(type, Context).ShouldBeTrue();
        text3.Is(type, Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is DateInfo type or not by generic type test")]
    public void JudgingStringIsDateInfoTypeByGenericTypeTest()
    {
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is<DateInfo>().ShouldBeTrue();
        text1.Is<DateInfo>().ShouldBeTrue();
        text2.Is<DateInfo>().ShouldBeTrue();
        text3.Is<DateInfo>().ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is DateInfo type or not by generic type and ignore case test")]
    public void JudgingStringIsDateInfoTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is<DateInfo>(Context).ShouldBeTrue();
        text1.Is<DateInfo>(Context).ShouldBeTrue();
        text2.Is<DateInfo>(Context).ShouldBeTrue();
        text3.Is<DateInfo>(Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge null or empty string is DateInfo type or not test")]
    public void JudgingNullOrEmptyStringIsDateInfoTypeTest()
    {
        var type = typeof(DateInfo);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.Is(type).ShouldBeFalse();
        text1.Is(type).ShouldBeFalse();
        text2.Is(type).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is DateInfo type or not and ignore case test")]
    public void JudgingNullOrEmptyStringIsDateInfoTypeWithIgnoreCaseTest()
    {
        var type = typeof(DateInfo);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.Is(type, Context).ShouldBeFalse();
        text1.Is(type, Context).ShouldBeFalse();
        text2.Is(type, Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is DateInfo type or not by generic type test")]
    public void JudgingNullOrEmptyStringIsDateInfoTypeByGenericTypeTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.Is<DateInfo>().ShouldBeFalse();
        text1.Is<DateInfo>().ShouldBeFalse();
        text2.Is<DateInfo>().ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is DateInfo type or not by generic type and ignore case test")]
    public void JudgingNullOrEmptyStringIsDateInfoTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.Is<DateInfo>(Context).ShouldBeFalse();
        text1.Is<DateInfo>(Context).ShouldBeFalse();
        text2.Is<DateInfo>(Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge invalid string test")]
    public void JudgingInvalidStringTest()
    {
        var type = typeof(DateInfo);
        var text0 = "D";
        var text1 = "2000-13-01";
        var text2 = "2000-12-32";

        text0.Is(type).ShouldBeFalse();
        text0.Is(type, Context).ShouldBeFalse();

        text0.Is<DateInfo>().ShouldBeFalse();
        text0.Is<DateInfo>(Context).ShouldBeFalse();

        text1.Is(type).ShouldBeFalse();
        text1.Is(type, Context).ShouldBeFalse();

        text1.Is<DateInfo>().ShouldBeFalse();
        text1.Is<DateInfo>(Context).ShouldBeFalse();

        text2.Is(type).ShouldBeFalse();
        text2.Is(type, Context).ShouldBeFalse();

        text2.Is<DateInfo>().ShouldBeFalse();
        text2.Is<DateInfo>(Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge string is nullable DateInfo type or not test")]
    public void JudgingStringIsNullableDateInfoTypeTest()
    {
        var type = typeof(DateInfo);
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is(type).ShouldBeTrue();
        text1.Is(type).ShouldBeTrue();
        text2.Is(type).ShouldBeTrue();
        text3.Is(type).ShouldBeTrue();

        text0.IsNullable(type).ShouldBeTrue();
        text1.IsNullable(type).ShouldBeTrue();
        text2.IsNullable(type).ShouldBeTrue();
        text3.IsNullable(type).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is nullable DateInfo type or not and ignore case test")]
    public void JudgingStringIsNullableDateInfoTypeWithIgnoreCaseTest()
    {
        var type = typeof(DateInfo);
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is(type, Context).ShouldBeTrue();
        text1.Is(type, Context).ShouldBeTrue();
        text2.Is(type, Context).ShouldBeTrue();
        text3.Is(type, Context).ShouldBeTrue();

        text0.IsNullable(type, Context).ShouldBeTrue();
        text1.IsNullable(type, Context).ShouldBeTrue();
        text2.IsNullable(type, Context).ShouldBeTrue();
        text3.IsNullable(type, Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is nullable DateInfo type or not by generic type test")]
    public void JudgingStringIsNullableDateInfoTypeByGenericTypeTest()
    {
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is<DateInfo>().ShouldBeTrue();
        text1.Is<DateInfo>().ShouldBeTrue();
        text2.Is<DateInfo>().ShouldBeTrue();
        text3.Is<DateInfo>().ShouldBeTrue();

        text0.IsNullable<DateInfo>().ShouldBeTrue();
        text1.IsNullable<DateInfo>().ShouldBeTrue();
        text2.IsNullable<DateInfo>().ShouldBeTrue();
        text3.IsNullable<DateInfo>().ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge string is nullable DateInfo type or not by generic type and ignore case test")]
    public void JudgingStringIsNullableDateInfoTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        var text0 = DateInfo.Today.ToString("yyyy-MM-dd");
        var text1 = DateInfo.Today.ToString("yyyy-MM-dd HH:mm:ss");
        var text2 = DateInfo.Today.ToString("yyyy MM dd");
        var text3 = DateInfo.Today.ToString("yyyy MM dd HH:mm:ss");

        text0.Is<DateInfo>(Context).ShouldBeTrue();
        text1.Is<DateInfo>(Context).ShouldBeTrue();
        text2.Is<DateInfo>(Context).ShouldBeTrue();
        text3.Is<DateInfo>(Context).ShouldBeTrue();

        text0.IsNullable<DateInfo>(Context).ShouldBeTrue();
        text1.IsNullable<DateInfo>(Context).ShouldBeTrue();
        text2.IsNullable<DateInfo>(Context).ShouldBeTrue();
        text3.IsNullable<DateInfo>(Context).ShouldBeTrue();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable DateInfo type or not test")]
    public void JudgingNullOrEmptyStringIsNullableDateInfoTypeTest()
    {
        var type = typeof(DateInfo);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.Is(type).ShouldBeFalse();
        text1.Is(type).ShouldBeFalse();
        text2.Is(type).ShouldBeFalse();

        text0.IsNullable(type).ShouldBeTrue();
        text1.IsNullable(type).ShouldBeFalse();
        text2.IsNullable(type).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable DateInfo type or not and ignore case test")]
    public void JudgingNullOrEmptyStringIsNullableDateInfoTypeWithIgnoreCaseTest()
    {
        var type = typeof(DateInfo);
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.Is(type, Context).ShouldBeFalse();
        text1.Is(type, Context).ShouldBeFalse();
        text2.Is(type, Context).ShouldBeFalse();

        text0.IsNullable(type, Context).ShouldBeTrue();
        text1.IsNullable(type, Context).ShouldBeFalse();
        text2.IsNullable(type, Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable DateInfo type or not by generic type test")]
    public void JudgingNullOrEmptyStringIsNullableDateInfoTypeByGenericTypeTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.IsNullable<DateInfo>().ShouldBeTrue();
        text1.IsNullable<DateInfo>().ShouldBeFalse();
        text2.IsNullable<DateInfo>().ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge null or empty string is nullable DateInfo type or not by generic type and ignore case test")]
    public void JudgingNullOrEmptyStringIsNullableDateInfoTypeByGenericTypeAndWithIgnoreCaseTest()
    {
        string text0 = null;
        string text1 = string.Empty;
        string text2 = "";

        text0.IsNullable<DateInfo>(Context).ShouldBeTrue();
        text1.IsNullable<DateInfo>(Context).ShouldBeFalse();
        text2.IsNullable<DateInfo>(Context).ShouldBeFalse();
    }

    [Fact(DisplayName = "To judge invalid string to nullable DateInfo type test")]
    public void JudgingInvalidStringToNullableDateInfoTypeTest()
    {
        var type = typeof(DateInfo);
        var text0 = "D";
        var text1 = "2000-13-01";
        var text2 = "2000-12-32";

        text0.Is(type).ShouldBeFalse();
        text0.Is(type, Context).ShouldBeFalse();

        text0.Is<DateInfo>().ShouldBeFalse();
        text0.Is<DateInfo>(Context).ShouldBeFalse();

        text0.IsNullable(type).ShouldBeFalse();
        text0.IsNullable(type, Context).ShouldBeFalse();

        text0.IsNullable<DateInfo>().ShouldBeFalse();
        text0.IsNullable<DateInfo>(Context).ShouldBeFalse();

        text1.Is(type).ShouldBeFalse();
        text1.Is(type, Context).ShouldBeFalse();

        text1.Is<DateInfo>().ShouldBeFalse();
        text1.Is<DateInfo>(Context).ShouldBeFalse();

        text1.IsNullable(type).ShouldBeFalse();
        text1.IsNullable(type, Context).ShouldBeFalse();

        text1.IsNullable<DateInfo>().ShouldBeFalse();
        text1.IsNullable<DateInfo>(Context).ShouldBeFalse();
            
        text2.Is(type).ShouldBeFalse();
        text2.Is(type, Context).ShouldBeFalse();

        text2.Is<DateInfo>().ShouldBeFalse();
        text2.Is<DateInfo>(Context).ShouldBeFalse();

        text2.IsNullable(type).ShouldBeFalse();
        text2.IsNullable(type, Context).ShouldBeFalse();

        text2.IsNullable<DateInfo>().ShouldBeFalse();
        text2.IsNullable<DateInfo>(Context).ShouldBeFalse();
    }
}