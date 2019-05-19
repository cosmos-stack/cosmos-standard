using System;
using System.Linq;
using System.Text.RegularExpressions;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests
{
    public class SplitterTest
    {
        [Fact]
        public void BasicTest()
        {
            var originalString = "a,b,c,d,e";

            var list1 = Splitter.On(",").Split(originalString);
            list1.Count().ShouldBe(5);

            var list2 = Splitter.On(",").SplitToList(originalString);
            list2.Count().ShouldBe(5);
            list2[0].ShouldBe("a");
            list2[1].ShouldBe("b");
            list2[2].ShouldBe("c");
            list2[3].ShouldBe("d");
            list2[4].ShouldBe("e");
        }

        [Fact]
        public void NullOrEmptyTest()
        {
            var originalString = "a,,b,,,c,d,e";

            var list1 = Splitter.On(",").Split(originalString);
            list1.Count().ShouldBe(8);

            var list2 = Splitter.On(",").OmitEmptyStrings().Split(originalString);
            list2.Count().ShouldBe(5);

            var list3 = Splitter.On(",").SplitToList(originalString);
            list3.Count().ShouldBe(8);
            list3[0].ShouldBe("a");
            list3[1].ShouldBe("");
            list3[2].ShouldBe("b");
            list3[3].ShouldBe("");
            list3[4].ShouldBe("");
            list3[5].ShouldBe("c");
            list3[6].ShouldBe("d");
            list3[7].ShouldBe("e");

            var list4 = Splitter.On(",").OmitEmptyStrings().SplitToList(originalString);
            list4.Count().ShouldBe(5);
            list4[0].ShouldBe("a");
            list4[1].ShouldBe("b");
            list4[2].ShouldBe("c");
            list4[3].ShouldBe("d");
            list4[4].ShouldBe("e");
        }

        [Fact]
        public void PatternTest()
        {
            var originalString = "a,b,c,d,e";
            var pattern = ",";

            var list1 = Splitter.OnPattern(pattern).SplitToList(originalString);
            list1.Count().ShouldBe(5);
            list1[0].ShouldBe("a");
            list1[1].ShouldBe("b");
            list1[2].ShouldBe("c");
            list1[3].ShouldBe("d");
            list1[4].ShouldBe("e");

            var list2 = Splitter.On(new Regex(pattern)).SplitToList(originalString);
            list2.Count().ShouldBe(5);
            list2[0].ShouldBe("a");
            list2[1].ShouldBe("b");
            list2[2].ShouldBe("c");
            list2[3].ShouldBe("d");
            list2[4].ShouldBe("e");
        }

        [Fact]
        public void KvpTest()
        {
            var originslString = "a=1&b=2&c=3&d=4&e=5";

            var dict1 = Splitter.On("&").WithKeyValueSeparator("=").Split(originslString);
            dict1.Count().ShouldBe(5);


            var dict2 = Splitter.On("&").WithKeyValueSeparator("=").SplitToDictionary(originslString);
            dict2.Count.ShouldBe(5);

            dict2["a"].ShouldBe("1");
            dict2["b"].ShouldBe("2");
            dict2["c"].ShouldBe("3");
            dict2["d"].ShouldBe("4");
            dict2["e"].ShouldBe("5");

        }

        [Fact]
        public void BasicLimitTest()
        {
            var originalString = "a,b,c,d,e";

            var list1 = Splitter.On(",").Limit(3).Split(originalString);
            list1.Count().ShouldBe(3);

            var list2 = Splitter.On(",").Limit(3).SplitToList(originalString);
            list2.Count().ShouldBe(3);
            list2[0].ShouldBe("a");
            list2[1].ShouldBe("b");
            list2[2].ShouldBe("c");
        }

        [Fact]
        public void KvpLimitTest()
        {
            var originslString = "a=1&b=2&c=3&d=4&e=5";

            var dict1 = Splitter.On("&").WithKeyValueSeparator("=").Limit(3).Split(originslString);
            dict1.Count().ShouldBe(3);


            var dict2 = Splitter.On("&").WithKeyValueSeparator("=").Limit(3).SplitToDictionary(originslString);
            dict2.Count.ShouldBe(3);

            dict2["a"].ShouldBe("1");
            dict2["b"].ShouldBe("2");
            dict2["c"].ShouldBe("3");
        }

        [Fact]
        public void TrimResultTest()
        {
            var originalString = "a, b ,c,d,e";

            var list1 = Splitter.On(",").Limit(3).TrimResults().Split(originalString);
            list1.Count().ShouldBe(3);

            var list2 = Splitter.On(",").Limit(3).TrimResults().SplitToList(originalString);
            list2.Count().ShouldBe(3);
            list2[0].ShouldBe("a");
            list2[1].ShouldBe("b");
            list2[2].ShouldBe("c");

            var list3 = Splitter.On(",").Limit(3).SplitToList(originalString);
            list3.Count().ShouldBe(3);
            list3[0].ShouldBe("a");
            list3[1].ShouldBe(" b ");
            list3[2].ShouldBe("c");

            var list4 = Splitter.On(",").Limit(3).TrimResults(s => s.TrimStart()).SplitToList(originalString);
            list4.Count().ShouldBe(3);
            list4[0].ShouldBe("a");
            list4[1].ShouldBe("b ");
            list4[2].ShouldBe("c");
        }

        [Fact]
        public void ConvertTest()
        {
            var originslString = "a=1&b=2&c=3&d=4&e=5";

            var dict1 = Splitter.On("&").WithKeyValueSeparator("=").Split(originslString);
            dict1.Count().ShouldBe(5);


            var converter = new StringToIntConverter();
            var dict2 = Splitter.On("&").WithKeyValueSeparator("=").SplitToDictionary(originslString, converter);
            dict2.Count.ShouldBe(5);

            dict2["a"].ShouldBe(1);
            dict2["b"].ShouldBe(2);
            dict2["c"].ShouldBe(3);
            dict2["d"].ShouldBe(4);
            dict2["e"].ShouldBe(5);
        }
    }

    public class StringToIntConverter : ITypeConverter<string, int>
    {
        public int To(string @from)
        {
            return int.TryParse(@from, out var ret) ? ret : default(int);
        }
    }
}
