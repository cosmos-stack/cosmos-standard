using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Collections;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.StringBuilder")]
    public class StringBuilderTests
    {
        [Fact(DisplayName = "Reverse string builder self test")]
        public void ReverseSelfTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            Strings.Reverse(builder);

            builder.ToString().ShouldBe("CBA");
        }

        [Fact(DisplayName = "Reverse string builder and return a new instance test")]
        public void ReverseAndReturnNewInstanceTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            var sb = Strings.ReverseAndReturnNewInstance(builder);

            sb.GetHashCode().ShouldNotBe(builder.GetHashCode());
            sb.ToString().ShouldBe("CBA");
        }

        [Fact(DisplayName = "Reverse string builder and to string test")]
        public void ReverseAndToStringTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            var val = Strings.ReverseAndToString(builder);

            builder.ToString().ShouldBe("ABC");
            val.ShouldBe("CBA");
        }

        [Fact(DisplayName = "Extensions method for Reverse string builder self test")]
        public void ExtensionMethodForReverseSelfTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            builder.Reverse();

            builder.ToString().ShouldBe("CBA");
        }

        [Fact(DisplayName = "Extensions method for Reverse string builder and return a new instance test")]
        public void ExtensionMethodForReverseAndReturnNewInstanceTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            var sb = builder.ReverseAndReturnNewInstance();

            sb.GetHashCode().ShouldNotBe(builder.GetHashCode());
            sb.ToString().ShouldBe("CBA");
        }

        [Fact(DisplayName = "Extensions method for Reverse string builder and to string test")]
        public void ExtensionMethodForReverseAndToStringTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            var val = builder.ReverseAndToString();

            builder.ToString().ShouldBe("ABC");
            val.ShouldBe("CBA");
        }

        [Fact(DisplayName = "Append all string into builder with separator test")]
        public void AppendAllWithStringAndSeparatorTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            builder.AppendAll(new List<string> {"E", "F", "G"}, "|");

            builder.ToString().ShouldBe("ABC|E|F|G");
        }

        [Fact(DisplayName = "Append all string into builder without separator test")]
        public void AppendAllWithStringAndWithoutSeparatorTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            builder.AppendAll(new List<string> {"E", "F", "G"});

            builder.ToString().ShouldBe("ABCEFG");
        }

        [Fact(DisplayName = "Append all string into builder with in char separator test")]
        public void AppendAllWithStringAndInCharSeparatorTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            builder.AppendAll(new List<string> {"E", "F", "G"}, '|');

            builder.ToString().ShouldBe("ABC|E|F|G");
        }

        [Fact(DisplayName = "Append all string into builder with separator (2) test")]
        public void AppendAllWithSeparatorTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            builder.AppendWithSeparator("|", "E", "F", "G");

            builder.ToString().ShouldBe("ABC|EFG");
        }

        [Fact(DisplayName = "Append all string into builder with in char separator (2) test")]
        public void AppendAllWithInCharSeparatorTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            builder.AppendWithSeparator('|', "E", "F", "G");

            builder.ToString().ShouldBe("ABC|EFG");
        }

        [Fact(DisplayName = "Append all string into builder with separator (3) from dict test")]
        public void AppendAllWithSeparatorFromDictTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("E", "FFF");

            builder.AppendWithSeparator(d, "E", "|", "---");

            builder.ToString().ShouldBe("ABC|E---FFF");
        }

        [Fact(DisplayName = "Builder to char array test")]
        public void ArrayCharTest()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("A");
            builder.Append("B");
            builder.Append("C");

            var list = builder.ToCharArray().ToList();
            
            list.ShouldNotBeNull();
            list.Count.ShouldBe(3);
            list[0].ShouldBe('A');
            list[1].ShouldBe('B');
            list[2].ShouldBe('C');
        }
    }
}