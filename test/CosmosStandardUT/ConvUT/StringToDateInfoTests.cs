using Cosmos.Date;
using Cosmos.Text;

namespace CosmosStandardUT.ConvUT;

[Trait("ConvUT", "StringConv.DateInfo")]
public class StringToDateInfoTests
{
    [Fact(DisplayName = "Casting null or empty string to DateInfo test")]
    public void CastingNullOrEmptyStringToDateInfoTest()
    {
        ((string) null).CastToDateInfo().ShouldBe(default);
        string.Empty.CastToDateInfo().ShouldBe(default);
        "".CastToDateInfo().ShouldBe(default);
    }

    [Fact(DisplayName = "Casting valid string with date to DateInfo test")]
    public void CastingValidStringToDateInfoTest()
    {
        var date = DateInfo.Today.ToString();
        var today = DateInfo.Today;
        date.CastToDateInfo().ShouldBe(today);
    }
        
    [Fact(DisplayName = "Casting invalid string to DateInfo test")]
    public void CastingInvalidStringToDateInfoTest()
    {
        "196-12-12".CastToDateInfo().ShouldBe(new DateInfo(196,12,12));
        "2000-13-12".CastToDateInfo().ShouldBe(default);
        "2000-1-32".CastToDateInfo().ShouldBe(default);
    }
        
    [Fact(DisplayName = "Casting null or empty to DateTimeSpan test")]
    public void CastingNullOrEmptyToDateTimeSpanTest()
    {
        ((string)null).CastToDateTimeSpan().ShouldBe(default);
        string.Empty.CastToDateTimeSpan().ShouldBe(default);
        "".CastToDateTimeSpan().ShouldBe(default);
    }
        
    [Fact(DisplayName = "Casting valid string to DateTimeSpan test")]
    public void CastingValidStringToDateTimeSpanTest()
    {
        var today = DateTime.Today;
        var now = DateTime.Now;
        DateTimeSpan span = now - today;
        var spanStr = span.ToString("G");
            
        spanStr.CastToDateTimeSpan().ShouldBe(span);
    }

    [Fact(DisplayName = "Casting null or empty to nullable DateTimeSpan test")]
    public void CastingNullOrEmptyToNullableDateTimeSpanTest()
    {
        ((string)null).CastToNullableDateTimeSpan().ShouldBeNull();
        string.Empty.CastToNullableDateTimeSpan().ShouldBeNull();
        "".CastToNullableDateTimeSpan().ShouldBeNull();
    }
        
    [Fact(DisplayName = "Casting valid string to nullable DateTimeSpan test")]
    public void CastingValidStringToNullableDateTimeSpanTest()
    {
        var today = DateTime.Today;
        var now = DateTime.Now;
        DateTimeSpan span = now - today;
        var spanStr = span.ToString("G");
            
        spanStr.CastToNullableDateTimeSpan().ShouldBe(span);
    }
}