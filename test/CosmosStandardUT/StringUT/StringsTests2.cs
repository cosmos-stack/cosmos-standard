using Cosmos.Text;

namespace CosmosStandardUT.StringUT;

public class Strings2Tests
{
    [Fact]
    public void StringTest()
    {
        string str = "str";
        var checker = Strings.NullToEmpty(str);
        checker.ShouldBe("str");
    }

    [Fact]
    public void NullStringTest()
    {
        string str = null;
        var checker = Strings.NullToEmpty(str);
        checker.ShouldBeEmpty();
        checker.ShouldBe(string.Empty);
    }

    [Fact]
    public void EmptyStringTest()
    {
        string str = string.Empty;
        var checker = Strings.NullToEmpty(str);
        checker.ShouldBeEmpty();
        checker.ShouldBe(string.Empty);
    }

    [Fact]
    public void WhiteSpaceStringTest()
    {
        string str = "";
        var checker = Strings.NullToEmpty(str);
        checker.ShouldBe("");
    }

    [Theory]
    [InlineData("aaac", "aa", "aa")]
    [InlineData("aabc", "aab", "aab")]
    [InlineData("", "aab", "")]
    [InlineData("aabc", "bbc", "")]
    public void CommonPrefixTest(string left, string right, string expected)
    {
        var actual = Strings.CommonPrefix(left, right);
        actual.ShouldBe(expected);
    }

    [Theory]
    [InlineData("aaac", "aac", "aac")]
    [InlineData("", "aac", "")]
    [InlineData("aabc", "bbc", "bc")]
    [InlineData("aaac", "aad", "")]
    public void CommonSuffixTest(string left, string right, string expected)
    {
        var actual = Strings.CommonSuffix(left, right);
        actual.ShouldBe(expected);
    }
}