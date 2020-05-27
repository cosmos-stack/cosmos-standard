using System.Collections.Generic;
using Cosmos.Judgments;
using Cosmos.Text;
using Xunit;

namespace Cosmos.Test.Judgements
{
    public class StringJudgementTest
    {
        [Fact]
        public void StartWithTheseTest_SingleString()
        {
            Assert.False(StringJudgment.StartWithThese("0", "1"));
            Assert.False(StringJudgment.StartWithThese("123", ""));
            Assert.False(StringJudgment.StartWithThese("1234", "234"));
            Assert.False(StringJudgment.StartWithThese("23", "234"));
            Assert.False(StringJudgment.StartWithThese("123", null));
            Assert.False(StringJudgment.StartWithThese("", null));
            Assert.False(StringJudgment.StartWithThese(null, ""));
            Assert.False(StringJudgment.StartWithThese(null, null));
            Assert.False(StringJudgment.StartWithThese("", ""));

            Assert.True(StringJudgment.StartWithThese("1234", "1"));
            Assert.True(StringJudgment.StartWithThese("1234", "1234"));
            Assert.True(StringJudgment.StartWithThese("12345678", "1234"));
        }

        [Fact]
        public void StartWithTheseTest_MutliStrings()
        {
            Assert.False(StringJudgment.StartWithThese("0", "1", "2"));
            Assert.False(StringJudgment.StartWithThese("123", "", ""));
            Assert.False(StringJudgment.StartWithThese("1234", "234", "23"));
            Assert.False(StringJudgment.StartWithThese("23", "234", "3"));
            Assert.False(StringJudgment.StartWithThese("123", null, null));
            Assert.False(StringJudgment.StartWithThese("", "", ""));
            Assert.False(StringJudgment.StartWithThese("", null, null));
            Assert.False(StringJudgment.StartWithThese(null, "", ""));
            Assert.False(StringJudgment.StartWithThese(null, null, null));
            Assert.False(StringJudgment.StartWithThese(null, "", null));
            Assert.False(StringJudgment.StartWithThese("", "", null));

            Assert.True(StringJudgment.StartWithThese("1234", "1", "12", "123", "234", "34", "4"));
            Assert.True(StringJudgment.StartWithThese("1234", "1234", "123", "12", "1"));
        }

        [Fact]
        public void StartWithTheseTest_CollectionString()
        {
            Assert.False(StringJudgment.StartWithThese("0", new List<string> { "1", "2" }));
            Assert.False(StringJudgment.StartWithThese("123", new List<string> { "", "" }));
            Assert.False(StringJudgment.StartWithThese("1234", new List<string> { "234", "23" }));
            Assert.False(StringJudgment.StartWithThese("23", new List<string> { "234", "3" }));
            Assert.False(StringJudgment.StartWithThese("123", new List<string> { null, null }));
            Assert.False(StringJudgment.StartWithThese("", new List<string> { "", "" }));
            Assert.False(StringJudgment.StartWithThese("", new List<string> { null, null }));
            Assert.False(StringJudgment.StartWithThese(null, new List<string> { "", "" }));
            Assert.False(StringJudgment.StartWithThese(null, new List<string> { null, null }));
            Assert.False(StringJudgment.StartWithThese(null, new List<string> { "", null }));
            Assert.False(StringJudgment.StartWithThese("", new List<string> { "", null }));

            Assert.True(StringJudgment.StartWithThese("1234", new List<string> { "1", "12", "123", "234", "34", "4" }));
            Assert.True(StringJudgment.StartWithThese("1234", new List<string> { "1234", "123", "12", "1" }));

            List<string> nullList = new List<string>();
            nullList = null;
            Assert.False(StringJudgment.StartWithThese("", nullList));
        }

        [Fact]
        public void EndWithTheseTest_SingleString()
        {
            Assert.False(StringJudgment.EndWithThese("0", "1"));
            Assert.False(StringJudgment.EndWithThese("123", ""));
            Assert.False(StringJudgment.EndWithThese("1234", "123"));
            Assert.False(StringJudgment.EndWithThese("23", "234"));
            Assert.False(StringJudgment.EndWithThese("123", null));
            Assert.False(StringJudgment.EndWithThese("", null));
            Assert.False(StringJudgment.EndWithThese(null, ""));
            Assert.False(StringJudgment.EndWithThese(null, null));
            Assert.False(StringJudgment.EndWithThese("", ""));

            Assert.True(StringJudgment.EndWithThese("1234", "4"));
            Assert.True(StringJudgment.EndWithThese("1234", "1234"));
            Assert.True(StringJudgment.EndWithThese("12345678", "5678"));
        }

        [Fact]
        public void EndWithTheseTest_MutliStrings()
        {
            Assert.False(StringJudgment.EndWithThese("0", "1", "2"));
            Assert.False(StringJudgment.EndWithThese("123", "", ""));
            Assert.False(StringJudgment.EndWithThese("1234", "123", "23"));
            Assert.False(StringJudgment.EndWithThese("23", "234", "2"));
            Assert.False(StringJudgment.EndWithThese("123", null, null));
            Assert.False(StringJudgment.EndWithThese("", "", ""));
            Assert.False(StringJudgment.EndWithThese("", null, null));
            Assert.False(StringJudgment.EndWithThese(null, "", ""));
            Assert.False(StringJudgment.EndWithThese(null, null, null));
            Assert.False(StringJudgment.EndWithThese(null, "", null));
            Assert.False(StringJudgment.EndWithThese("", "", null));

            Assert.True(StringJudgment.EndWithThese("1234", "1", "12", "123", "234", "34", "4"));
            Assert.True(StringJudgment.EndWithThese("1234", "1234", "234", "12", "1"));
        }

        [Fact]
        public void EndWithTheseTest_CollectionString()
        {
            Assert.False(StringJudgment.EndWithThese("0", new List<string> { "1", "2" }));
            Assert.False(StringJudgment.EndWithThese("123", new List<string> { "", "" }));
            Assert.False(StringJudgment.EndWithThese("1234", new List<string> { "123", "23" }));
            Assert.False(StringJudgment.EndWithThese("23", new List<string> { "234", "2" }));
            Assert.False(StringJudgment.EndWithThese("123", new List<string> { null, null }));
            Assert.False(StringJudgment.EndWithThese("", new List<string> { "", "" }));
            Assert.False(StringJudgment.EndWithThese("", new List<string> { null, null }));
            Assert.False(StringJudgment.EndWithThese(null, new List<string> { "", "" }));
            Assert.False(StringJudgment.EndWithThese(null, new List<string> { null, null }));
            Assert.False(StringJudgment.EndWithThese(null, new List<string> { "", null }));
            Assert.False(StringJudgment.EndWithThese("", new List<string> { "", null }));

            Assert.True(StringJudgment.EndWithThese("1234", new List<string> { "1", "12", "123", "234", "34", "4" }));
            Assert.True(StringJudgment.EndWithThese("1234", new List<string> { "1234", "234", "12", "1" }));

            List<string> nullList = new List<string>();
            nullList = null;
            Assert.False(StringJudgment.EndWithThese("", nullList));
        }

        [Theory]
        [InlineData("http://www.baidu.com")]
        [InlineData("http://www.baidu.com/")]
        [InlineData("http://www.baidu.com/123")]
        [InlineData("http://www.baidu.com/123.html")]
        [InlineData("https://www.baidu.com")]
        [InlineData("https://www.baidu.com/")]
        [InlineData("https://www.baidu.com/123")]
        [InlineData("https://www.baidu.com/123.html")]
        [InlineData("https://baidu.com")]
        [InlineData("https://baidu.com/")]
        [InlineData("https://baidu.com/123")]
        [InlineData("https://baidu.com/123.html")]
        public void IsWebUrlTest_True(string url)
        {
            Assert.True(StringJudgment.IsWebUrl(url));
        }


        [Theory]
        [InlineData("//www.baidu.com")]
        [InlineData("//www.baidu.com/")]
        [InlineData("//www.baidu.com/123")]
        [InlineData("//www.baidu.com/123.html")]
        [InlineData("www.baidu.com")]
        [InlineData("www.baidu.com/")]
        [InlineData("www.baidu.com/123")]
        [InlineData("www.baidu.com/123.html")]
        [InlineData("//baidu.com")]
        [InlineData("//baidu.com/")]
        [InlineData("//baidu.com/123")]
        [InlineData("//baidu.com/123.html")]
        [InlineData("baidu.com")]
        [InlineData("baidu.com/")]
        [InlineData("baidu.com/123")]
        [InlineData("baidu.com/123.html")]
        [InlineData("baidu.com/123.html.")]
        [InlineData("baidu")]
        [InlineData("baidu/123")]
        [InlineData("baidu/123.html")]
        [InlineData("")]
        [InlineData(null)]
        public void IsWebUrlTest_False(string url)
        {
            Assert.False(StringJudgment.IsWebUrl(url));
        }

        [Theory]
        [InlineData("alex@github.com")]
        [InlineData("alex@github.com.cn")]
        [InlineData("alex.lewis@github.com")]
        public void IsEmailTest_True(string mail)
        {
            Assert.True(StringJudgment.IsEmail(mail));
        }

        [Theory]
        [InlineData("@mail.com")]
        [InlineData("alex@github")]
        [InlineData("alex@github.")]
        [InlineData("")]
        [InlineData(null)]
        public void IsEmailTest_False(string mail)
        {
            Assert.False(StringJudgment.IsEmail(mail));
        }

        [Theory]
        [InlineData("中国")]
        [InlineData("ilove中国")]
        public void ContainsChineseCharactersTest_True(string str)
        {
            Assert.True(StringJudgment.ContainsChineseCharacters(str));
        }

        [Theory]
        [InlineData("iloveChina")]
        [InlineData("iloveちゅうごく")]
        [InlineData("")]
        [InlineData(null)]
        public void ContainsChineseCharactersTest_False(string str)
        {
            Assert.False(StringJudgment.ContainsChineseCharacters(str));
        }

        [Theory]
        [InlineData("10086")]
        [InlineData("ilove10086")]
        [InlineData("ilove100and86")]
        public void ContainsNumberTest_True(string str)
        {
            Assert.True(StringJudgment.ContainsNumber(str));
        }

        [Theory]
        [InlineData("１００８６")]
        [InlineData("ilove１００８６")]
        [InlineData("ilove１００and８６")]
        [InlineData("iloveyilinglingbaliu")]
        [InlineData("")]
        [InlineData(null)]
        public void ContainsNumberTest_False(string str)
        {
            Assert.False(StringJudgment.ContainsChineseCharacters(str));
        }
    }
}
