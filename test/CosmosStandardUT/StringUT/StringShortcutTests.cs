using System.Collections.Generic;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Shortcut")]
    public class StringShortcutTests
    {
        [Fact(DisplayName = "TrimInner test")]
        public void TrimInnerTest()
        {
            " abcdefghijkl mnopqrstuvwxyz ".TrimInner().ShouldBe("abcdefghijklmnopqrstuvwxyz");
        }

        [Fact(DisplayName = "TrimAll test")]
        public void TrimAllTest()
        {
            var list = new List<string>();
            list.Add("  A");
            list.Add("A  ");
            list.Add("  A  ");
            list.Add("A");
            
            list.TrimAll();
            
            list.Count.ShouldBe(4);
            list[0].ShouldBe("A");
            list[1].ShouldBe("A");
            list[2].ShouldBe("A");
            list[3].ShouldBe("A");
        }

        [Fact(DisplayName = "TrimPhrase test")]
        public void TrimPhraseTest()
        {
            "ABCDEFGAB".TrimPhraseStart("AB").ShouldBe("CDEFGAB");
            "ABCDEFGAB".TrimPhraseEnd("AB").ShouldBe("ABCDEFG");
            "ABCDEFGAB".TrimPhrase("AB").ShouldBe("CDEFG");
        }

        [Fact(DisplayName = "EndsWith Test")]
        public void EndsWithTest()
        {
            var text = "ABCDE";

            text.EndsWith().ShouldBeTrue();
            text.EndsWith("").ShouldBeTrue();
            text.EndsWith((List<string>) null).ShouldBeTrue();
            text.EndsWith((string[]) null).ShouldBeTrue();
            text.EndsWith(new string[0]).ShouldBeTrue();
            text.EndsWith(new List<string>()).ShouldBeTrue();
            text.EndsWith("", "", "").ShouldBeTrue();
            text.EndsWith("D").ShouldBeFalse();
            text.EndsWith("C", "D").ShouldBeFalse();

            text.EndsWith("E").ShouldBeTrue();
            text.EndsWith("C", "E").ShouldBeTrue();
            text.EndsWith("C", "E", "D").ShouldBeTrue();

            text.EndsWith("DE").ShouldBeTrue();
            text.EndsWith("C", "DE").ShouldBeTrue();
            text.EndsWith("C", "DE", "D").ShouldBeTrue();

            text.EndsWith(new List<string> {"E"}).ShouldBeTrue();
            text.EndsWith(new List<string> {"C", "E"}).ShouldBeTrue();
            text.EndsWith(new List<string> {"C", "E", "D"}).ShouldBeTrue();

            text.EndsWith(new List<string> {"DE"}).ShouldBeTrue();
            text.EndsWith(new List<string> {"C", "DE"}).ShouldBeTrue();
            text.EndsWith(new List<string> {"C", "DE", "D"}).ShouldBeTrue();
        }

        [Fact(DisplayName = "EndsWith and ignore case Test")]
        public void EndsWithAndIgnoreCaseTest()
        {
            var text = "ABCDE";

            text.EndsWithIgnoreCase("").ShouldBeTrue();
            text.EndsWithIgnoreCase("d").ShouldBeFalse();
            text.EndsWithIgnoreCase("D").ShouldBeFalse();
            text.EndsWithIgnoreCase("e").ShouldBeTrue();
            text.EndsWithIgnoreCase("E").ShouldBeTrue();
            text.EndsWithIgnoreCase("dE").ShouldBeTrue();
            text.EndsWithIgnoreCase("de").ShouldBeTrue();
            text.EndsWithIgnoreCase("DE").ShouldBeTrue();
            text.EndsWithIgnoreCase("De").ShouldBeTrue();

            text.EndsWithIgnoreCase("").ShouldBeTrue();
            text.EndsWithIgnoreCase((List<string>) null).ShouldBeTrue();
            text.EndsWithIgnoreCase((string[]) null).ShouldBeTrue();
            text.EndsWithIgnoreCase(new string[0]).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string>()).ShouldBeTrue();
            text.EndsWithIgnoreCase("", "", "").ShouldBeTrue();
            text.EndsWithIgnoreCase("D").ShouldBeFalse();
            text.EndsWithIgnoreCase("C", "D").ShouldBeFalse();
            text.EndsWithIgnoreCase("d").ShouldBeFalse();
            text.EndsWithIgnoreCase("c", "d").ShouldBeFalse();

            text.EndsWithIgnoreCase("E").ShouldBeTrue();
            text.EndsWithIgnoreCase("C", "E").ShouldBeTrue();
            text.EndsWithIgnoreCase("C", "E", "D").ShouldBeTrue();
            text.EndsWithIgnoreCase("e").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "e").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "e", "d").ShouldBeTrue();

            text.EndsWithIgnoreCase("DE").ShouldBeTrue();
            text.EndsWithIgnoreCase("C", "DE").ShouldBeTrue();
            text.EndsWithIgnoreCase("C", "DE", "D").ShouldBeTrue();
            text.EndsWithIgnoreCase("De").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "De").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "De", "d").ShouldBeTrue();
            text.EndsWithIgnoreCase("dE").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "dE").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "dE", "d").ShouldBeTrue();
            text.EndsWithIgnoreCase("de").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "de").ShouldBeTrue();
            text.EndsWithIgnoreCase("c", "de", "d").ShouldBeTrue();

            text.EndsWithIgnoreCase(new List<string> {"E"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"C", "E"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"C", "E", "D"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"e"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "e"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "e", "d"}).ShouldBeTrue();

            text.EndsWithIgnoreCase(new List<string> {"DE"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"C", "DE"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"C", "DE", "D"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"De"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "De"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "De", "d"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"dE"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "dE"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "dE", "d"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"de"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "de"}).ShouldBeTrue();
            text.EndsWithIgnoreCase(new List<string> {"c", "de", "d"}).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "StartsWith Test")]
        public void StartsWithTest()
        {
            var text = "ABCDE";

            text.StartsWith().ShouldBeTrue();
            text.StartsWith("").ShouldBeTrue();
            text.StartsWith((List<string>) null).ShouldBeTrue();
            text.StartsWith((string[]) null).ShouldBeTrue();
            text.StartsWith(new string[0]).ShouldBeTrue();
            text.StartsWith(new List<string>()).ShouldBeTrue();
            text.StartsWith("", "", "").ShouldBeTrue();
            text.StartsWith("B").ShouldBeFalse();
            text.StartsWith("C", "B").ShouldBeFalse();

            text.StartsWith("A").ShouldBeTrue();
            text.StartsWith("C", "A").ShouldBeTrue();
            text.StartsWith("C", "A", "B").ShouldBeTrue();

            text.StartsWith("AB").ShouldBeTrue();
            text.StartsWith("C", "AB").ShouldBeTrue();
            text.StartsWith("C", "AB", "D").ShouldBeTrue();

            text.StartsWith(new List<string> {"A"}).ShouldBeTrue();
            text.StartsWith(new List<string> {"C", "A"}).ShouldBeTrue();
            text.StartsWith(new List<string> {"C", "A", "B"}).ShouldBeTrue();

            text.StartsWith(new List<string> {"AB"}).ShouldBeTrue();
            text.StartsWith(new List<string> {"C", "AB"}).ShouldBeTrue();
            text.StartsWith(new List<string> {"C", "AB", "D"}).ShouldBeTrue();
        }
        
        [Fact(DisplayName = "StartsWith and ignore case Test")]
        public void StartsWithAndIgnoreCaseTest()
        {
            var text = "ABCDE";

            text.StartsWithIgnoreCase("").ShouldBeTrue();
            text.StartsWithIgnoreCase("b").ShouldBeFalse();
            text.StartsWithIgnoreCase("B").ShouldBeFalse();
            text.StartsWithIgnoreCase("a").ShouldBeTrue();
            text.StartsWithIgnoreCase("A").ShouldBeTrue();
            text.StartsWithIgnoreCase("aB").ShouldBeTrue();
            text.StartsWithIgnoreCase("ab").ShouldBeTrue();
            text.StartsWithIgnoreCase("AB").ShouldBeTrue();
            text.StartsWithIgnoreCase("Ab").ShouldBeTrue();

            text.StartsWithIgnoreCase("").ShouldBeTrue();
            text.StartsWithIgnoreCase((List<string>) null).ShouldBeTrue();
            text.StartsWithIgnoreCase((string[]) null).ShouldBeTrue();
            text.StartsWithIgnoreCase(new string[0]).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string>()).ShouldBeTrue();
            text.StartsWithIgnoreCase("", "", "").ShouldBeTrue();
            text.StartsWithIgnoreCase("B").ShouldBeFalse();
            text.StartsWithIgnoreCase("C", "B").ShouldBeFalse();
            text.StartsWithIgnoreCase("b").ShouldBeFalse();
            text.StartsWithIgnoreCase("c", "b").ShouldBeFalse();

            text.StartsWithIgnoreCase("A").ShouldBeTrue();
            text.StartsWithIgnoreCase("C", "A").ShouldBeTrue();
            text.StartsWithIgnoreCase("C", "A", "B").ShouldBeTrue();
            text.StartsWithIgnoreCase("a").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "a").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "a", "b").ShouldBeTrue();

            text.StartsWithIgnoreCase("AB").ShouldBeTrue();
            text.StartsWithIgnoreCase("C", "AB").ShouldBeTrue();
            text.StartsWithIgnoreCase("C", "AB", "B").ShouldBeTrue();
            text.StartsWithIgnoreCase("Ab").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "Ab").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "Ab", "b").ShouldBeTrue();
            text.StartsWithIgnoreCase("aB").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "aB").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "aB", "b").ShouldBeTrue();
            text.StartsWithIgnoreCase("ab").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "ab").ShouldBeTrue();
            text.StartsWithIgnoreCase("c", "ab", "b").ShouldBeTrue();

            text.StartsWithIgnoreCase(new List<string> {"A"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"C", "A"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"C", "A", "B"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"a"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "a"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "a", "b"}).ShouldBeTrue();

            text.StartsWithIgnoreCase(new List<string> {"AB"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"C", "AB"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"C", "AB", "B"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"Ab"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "Ab"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "Ab", "b"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"aB"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "aB"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "aB", "b"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"ab"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "ab"}).ShouldBeTrue();
            text.StartsWithIgnoreCase(new List<string> {"c", "ab", "b"}).ShouldBeTrue();
        }

        [Fact(DisplayName = "Empty, Null and WhiteSpace Test")]
        public void EmptyAndNullAndWhiteSpaceTest()
        {
            ((string)null).IsNullOrWhiteSpace().ShouldBeTrue();
            ((string)null).IsNullOrEmpty().ShouldBeTrue();
            "".IsNullOrWhiteSpace().ShouldBeTrue();
            "".IsNullOrEmpty().ShouldBeTrue();
            " ".IsNullOrWhiteSpace().ShouldBeTrue();
            " ".IsNullOrEmpty().ShouldBeFalse();
            "A".IsNullOrWhiteSpace().ShouldBeFalse();
            "A".IsNullOrEmpty().ShouldBeFalse();
             
            ((string)null).IsNotNullNorWhiteSpace().ShouldBeFalse();
            ((string)null).IsNotNullNorEmpty().ShouldBeFalse();
            "".IsNotNullNorWhiteSpace().ShouldBeFalse();
            "".IsNotNullNorEmpty().ShouldBeFalse();
            " ".IsNotNullNorWhiteSpace().ShouldBeFalse();
            " ".IsNotNullNorEmpty().ShouldBeTrue();
            "A".IsNotNullNorWhiteSpace().ShouldBeTrue();
            "A".IsNotNullNorEmpty().ShouldBeTrue();
        }

        [Fact(DisplayName = "IndexWholePhrase test")]
        public void IndexOfWholePhraseTest()
        {
            "AA BB CC DD DD EE DD".IndexOfWholePhrase("DD").ShouldBe(9);
            "AA BB CC DD DD EE DD".IndexOfWholePhrase("DD",6).ShouldBe(9);
            "AA BB CC DD DD EE DD".IndexOfWholePhrase("DD",7).ShouldBe(9);
            "AA BB CC DD DD EE DD".IndexOfWholePhrase("DD",8).ShouldBe(9);
            "AA BB CC DD DD EE DD".IndexOfWholePhrase("DD",10).ShouldBe(12);
        }

        [Fact(DisplayName = "LastIndexOfAny test")]
        public void LastIndexOfAnyTest()
        {
            var text = "AABBCCDDEEFFGG";
            
            text.LastIndexOfAny("WW","XX","YY","ZZ","GG").ShouldBe(12);
        }

        [Fact(DisplayName = "Getting last index of text for the given text ignore case text")]
        public void LastIndexOfWithIgnoreCaseTest()
        {
            var text = "AABBCCDDEEFFGG";
            
            text.LastIndexOfIgnoreCase("GG").ShouldBe(12);
            text.LastIndexOfIgnoreCase("gg").ShouldBe(12);
            text.LastIndexOfIgnoreCase("gG").ShouldBe(12);
        }
        
        [Fact(DisplayName = "Getting last index of text for the given text ignore case and start text")]
        public void LastIndexOfWithIgnoreCaseAndStartTest()
        {
            var text = "AABBCCDDEEFFGG";
            
            text.LastIndexOfIgnoreCase("GG",10,2).ShouldBe(-1);
            text.LastIndexOfIgnoreCase("gg",10,2).ShouldBe(-1);
            text.LastIndexOfIgnoreCase("gG",10,2).ShouldBe(-1);
            text.LastIndexOfIgnoreCase("CC",6,4).ShouldBe(4);
            text.LastIndexOfIgnoreCase("cc",6,4).ShouldBe(4);
            text.LastIndexOfIgnoreCase("Cc",6,4).ShouldBe(4);
        }

        [Fact(DisplayName = "String encoding test")]
        public void EncodingTest()
        {
            var text = "AlexLEWIS";
            var val = text.ToBytes().GetString();
            val.ShouldBe(text);
        }
    }
}