using System.Linq;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests.GuavaSplitter
{
    public class MapSplitterTests
    {
        public class StringToIntConverter : ITypeConverter<string, int>
        {
            public int To(string @from)
            {
                return int.TryParse(@from, out var ret) ? ret : default(int);
            }
        }

        private static class OriginalStrings
        {
            public static string NormalMapString { get; } = "a=1&b=2&c=3&d=4&e=5";
            public static string IncludeNullString { get; } = "a,,b,,,c,d,e";
            public static string IncludeWhiteSpaceString { get; } = "a, b ,c,d,e";
            public static string FixedLengthMapString { get; } = "a=1b=2c=3d=4e=5";
        }

        [Fact]
        public void StringToKvpTest()
        {
            var kvp = Splitter.On("&").WithKeyValueSeparator("=").Split(OriginalStrings.NormalMapString);

            // ReSharper disable once PossibleMultipleEnumeration
            kvp.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var dict = kvp.ToDictionary(k => k.Key, v => v.Value);
            dict.Count.ShouldBe(5);

            dict["a"].ShouldBe("1");
            dict["b"].ShouldBe("2");
            dict["c"].ShouldBe("3");
            dict["d"].ShouldBe("4");
            dict["e"].ShouldBe("5");
        }

        [Fact]
        public void StringToKvpWithLimitTest()
        {
            var kvp = Splitter.On("&").WithKeyValueSeparator("=").Limit(3).Split(OriginalStrings.NormalMapString);

            // ReSharper disable once PossibleMultipleEnumeration
            kvp.Count().ShouldBe(3);

            // ReSharper disable once PossibleMultipleEnumeration
            var dict = kvp.ToDictionary(k => k.Key, v => v.Value);
            dict.Count.ShouldBe(3);

            dict["a"].ShouldBe("1");
            dict["b"].ShouldBe("2");
            dict["c"].ShouldBe("3");
        }

        [Fact]
        public void StringToKvpWithConverterTest()
        {
            var converter = new StringToIntConverter();
            var kvp = Splitter.On("&").WithKeyValueSeparator("=").Split(OriginalStrings.NormalMapString, converter);

            // ReSharper disable once PossibleMultipleEnumeration
            kvp.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var dict = kvp.ToDictionary(k => k.Key, v => v.Value);
            dict.Count.ShouldBe(5);

            dict["a"].ShouldBe(1);
            dict["b"].ShouldBe(2);
            dict["c"].ShouldBe(3);
            dict["d"].ShouldBe(4);
            dict["e"].ShouldBe(5);
        }

        [Fact]
        public void StringToDictionaryTest()
        {
            var dict = Splitter.On("&").WithKeyValueSeparator("=").SplitToDictionary(OriginalStrings.NormalMapString);

            dict.Count.ShouldBe(5);

            dict["a"].ShouldBe("1");
            dict["b"].ShouldBe("2");
            dict["c"].ShouldBe("3");
            dict["d"].ShouldBe("4");
            dict["e"].ShouldBe("5");
        }

        [Fact]
        public void StringToDictionaryWithLimitTest()
        {
            var dict = Splitter.On("&").WithKeyValueSeparator("=").Limit(3).SplitToDictionary(OriginalStrings.NormalMapString);

            dict.Count.ShouldBe(3);

            dict["a"].ShouldBe("1");
            dict["b"].ShouldBe("2");
            dict["c"].ShouldBe("3");
        }

        [Fact]
        public void StringToDictionaryWithConverterTest()
        {
            var converter = new StringToIntConverter();
            var dict = Splitter.On("&").WithKeyValueSeparator("=").SplitToDictionary(OriginalStrings.NormalMapString, converter);
            dict.Count.ShouldBe(5);

            dict["a"].ShouldBe(1);
            dict["b"].ShouldBe(2);
            dict["c"].ShouldBe(3);
            dict["d"].ShouldBe(4);
            dict["e"].ShouldBe(5);
        }

        [Fact]
        public void StringToFixedLengthKvpTest()
        {
            var kvp = Splitter.FixedLength(3).WithKeyValueSeparator("=").Split(OriginalStrings.FixedLengthMapString);

            // ReSharper disable once PossibleMultipleEnumeration
            kvp.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var dict = kvp.ToDictionary(k => k.Key, v => v.Value);
            dict.Count.ShouldBe(5);

            dict["a"].ShouldBe("1");
            dict["b"].ShouldBe("2");
            dict["c"].ShouldBe("3");
            dict["d"].ShouldBe("4");
            dict["e"].ShouldBe("5");
        }

        [Fact]
        public void StringToFixedLengthDictionaryTest()
        {
            var dict = Splitter.FixedLength(3).WithKeyValueSeparator("=").SplitToDictionary(OriginalStrings.FixedLengthMapString);

            dict.Count.ShouldBe(5);

            dict["a"].ShouldBe("1");
            dict["b"].ShouldBe("2");
            dict["c"].ShouldBe("3");
            dict["d"].ShouldBe("4");
            dict["e"].ShouldBe("5");
        }
    }
}
