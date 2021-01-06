using System.Collections.Generic;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Basic")]
    public class StringsTests
    {
        [Fact(DisplayName = "Merge all chars test")]
        public void MergeForAllCharsTest()
        {
            var chars = new List<char> {'a', 'b', 'c'};
            Strings.Merge(chars).ShouldBe("abc");
        }

        [Fact(DisplayName = "Merge all strings test")]
        public void MergeForStringsTest()
        {
            var strings = new List<string> {"00", "11", "22"};
            Strings.Merge("AA", strings.ToArray()).ShouldBe("AA001122");
        }

        [Fact(DisplayName = "Merge one string and a set of string test")]
        public void MergeForStringAndStringsTest()
        {
            Strings.Merge("AA", "00", "11", "22").ShouldBe("AA001122");
        }

        [Fact(DisplayName = "Merge one string and a set of chars test")]
        public void MergeForStringAndCharsTest()
        {
            Strings.Merge("AA", '0', '0', '1', '1', '2', '2').ShouldBe("AA001122");
        }

        [Fact(DisplayName = "Equals between two string and ignore case test")]
        public void EqualsBetweenTwoStringsIgnoreCaseTest()
        {
            "AAA".EqualsIgnoreCase("aaa").ShouldBeTrue();
            "aaa".EqualsIgnoreCase("AAA").ShouldBeTrue();
            "AaA".EqualsIgnoreCase("aAa").ShouldBeTrue();
            "".EqualsIgnoreCase("").ShouldBeTrue();
        }

        [Fact(DisplayName = "Equals to any one and ignore case test")]
        public void EqualsToAnyOneAndIgnoreCaseTest()
        {
            "AAA".EqualsToAnyIgnoreCase("a", "aa", "aaa").ShouldBeTrue();
            "aaa".EqualsToAnyIgnoreCase("b", "a", "bb", "AA", "AAA").ShouldBeTrue();
            "ZZZ".EqualsToAnyIgnoreCase().ShouldBeFalse();
            "ZZZ".EqualsToAnyIgnoreCase(null).ShouldBeFalse();
        }

        [Fact(DisplayName = "Text has any letters or not test")]
        public void TextHasLettersOrNotTest()
        {
            Strings.HasLetters("").ShouldBeFalse();
            Strings.HasLetters("1234567890").ShouldBeFalse();
            Strings.HasLetters("1234567890a").ShouldBeTrue();
        }

        [Fact(DisplayName = "Text has any letters at least or not test")]
        public void TextHasLettersAtLeastOrNotTest()
        {
            Strings.HasLettersAtLeast("1234567890", 0).ShouldBeFalse();
            Strings.HasLettersAtLeast("1234567890", -1).ShouldBeFalse();
            Strings.HasLettersAtLeast("1234567890a", 0).ShouldBeTrue();
            Strings.HasLettersAtLeast("1234567890a", 1).ShouldBeTrue();
            Strings.HasLettersAtLeast("1234567890a", 2).ShouldBeFalse();
        }

        [Fact(DisplayName = "Extension method for Text has any letters or not test")]
        public void ExtensionMethodForTextHasLettersOrNotTest()
        {
            "".ContainsLetters().ShouldBeFalse();
            "1234567890".ContainsLetters().ShouldBeFalse();
            "1234567890a".ContainsLetters().ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method for Text has any letters at least or not test")]
        public void ExtensionMethodForTextHasLettersAtLeastOrNotTest()
        {
            "1234567890".ContainsLettersAtLeast(0).ShouldBeFalse();
            "1234567890".ContainsLettersAtLeast(-1).ShouldBeFalse();
            "1234567890a".ContainsLettersAtLeast(0).ShouldBeTrue();
            "1234567890a".ContainsLettersAtLeast(1).ShouldBeTrue();
            "1234567890a".ContainsLettersAtLeast(2).ShouldBeFalse();
        }

        [Fact(DisplayName = "Count all letters in a string test")]
        public void CountForLettersTest()
        {
            Strings.CountForLetters("abcd1234").ShouldBe(4);
            Strings.CountForLetters("").ShouldBe(0);
            Strings.CountForLetters("1234").ShouldBe(0);
            Strings.CountForLetters(null).ShouldBe(0);
        }

        [Fact(DisplayName = "Count all upper case letters in a string test")]
        public void CountForLettersWithUpperCaseTest()
        {
            Strings.CountForLettersUpperCase("abcdABCD1234").ShouldBe(4);
            Strings.CountForLettersUpperCase("").ShouldBe(0);
            Strings.CountForLettersUpperCase("1234").ShouldBe(0);
            Strings.CountForLettersUpperCase(null).ShouldBe(0);
        }

        [Fact(DisplayName = "Count all lower case letters in a string test")]
        public void CountForLettersWithLowerCaseTest()
        {
            Strings.CountForLettersLowerCase("abcdABCD1234").ShouldBe(4);
            Strings.CountForLettersLowerCase("").ShouldBe(0);
            Strings.CountForLettersLowerCase("1234").ShouldBe(0);
            Strings.CountForLettersLowerCase(null).ShouldBe(0);
        }

        [Fact(DisplayName = "Count all digit in a string test")]
        public void CountForDigitTest()
        {
            Strings.CountForDigit("abcd1234").ShouldBe(4);
            Strings.CountForDigit("").ShouldBe(0);
            Strings.CountForDigit("abcd").ShouldBe(0);
            Strings.CountForDigit(null).ShouldBe(0);
        }

        [Fact(DisplayName = "Extension method for Count all letters in a string test")]
        public void ExtensionMethodForCountForLettersTest()
        {
            "abcd1234".CountForLetters().ShouldBe(4);
            "".CountForLetters().ShouldBe(0);
            "1234".CountForLetters().ShouldBe(0);
            ((string) null).CountForLetters().ShouldBe(0);
        }

        [Fact(DisplayName = "Extension method for Count all upper case letters in a string test")]
        public void ExtensionMethodForCountForLettersWithUpperCaseTest()
        {
            "abcdABCD1234".CountForLettersUpperCase().ShouldBe(4);
            "".CountForLettersUpperCase().ShouldBe(0);
            "1234".CountForLettersUpperCase().ShouldBe(0);
            ((string) null).CountForLettersUpperCase().ShouldBe(0);
        }

        [Fact(DisplayName = "Extension method for Count all lower case letters in a string test")]
        public void ExtensionMethodForCountForLettersWithLowerCaseTest()
        {
            "abcdABCD1234".CountForLettersLowerCase().ShouldBe(4);
            "".CountForLettersLowerCase().ShouldBe(0);
            "1234".CountForLettersLowerCase().ShouldBe(0);
            ((string) null).CountForLettersLowerCase().ShouldBe(0);
        }

        [Fact(DisplayName = "Extension method for Count all digit in a string test")]
        public void ExtensionMethodForCountForDigitTest()
        {
            "abcd1234".CountForDigit().ShouldBe(4);
            "".CountForDigit().ShouldBe(0);
            "abcd".CountForDigit().ShouldBe(0);
            ((string) null).CountForDigit().ShouldBe(0);
        }

        [Fact(DisplayName = "Text has any digit or not test")]
        public void TextHasDigitOrNotTest()
        {
            Strings.HasNumbers("").ShouldBeFalse();
            Strings.HasNumbers("abcdefg").ShouldBeFalse();
            Strings.HasNumbers("abcdefg0").ShouldBeTrue();
        }

        [Fact(DisplayName = "Text has any digit at least or not test")]
        public void TextHasDigitAtLeastOrNotTest()
        {
            Strings.HasNumbersAtLeast("abcdefg", 0).ShouldBeFalse();
            Strings.HasNumbersAtLeast("abcdefg", -1).ShouldBeFalse();
            Strings.HasNumbersAtLeast("abcdefg0", 0).ShouldBeTrue();
            Strings.HasNumbersAtLeast("abcdefg0", 1).ShouldBeTrue();
            Strings.HasNumbersAtLeast("abcdefg0", 2).ShouldBeFalse();
        }

        [Fact(DisplayName = "Extension method for Text has any digit or not test")]
        public void ExtensionMethodForTextHasDigitOrNotTest()
        {
            "".HasNumbers().ShouldBeFalse();
            "abcdefg".HasNumbers().ShouldBeFalse();
            "abcdefg0".HasNumbers().ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method for Text has any digit at least or not test")]
        public void ExtensionMethodForTextHasDigitAtLeastOrNotTest()
        {
            "abcdefg".HasNumbersAtLeast(0).ShouldBeFalse();
            "abcdefg".HasNumbersAtLeast(-1).ShouldBeFalse();
            "abcdefg0".HasNumbersAtLeast(0).ShouldBeTrue();
            "abcdefg0".HasNumbersAtLeast(1).ShouldBeTrue();
            "abcdefg0".HasNumbersAtLeast(2).ShouldBeFalse();
        }

        [Fact(DisplayName = "String repeat test")]
        public void StringRepeatTest()
        {
            Strings.Repeat("ABC", -1).ShouldBeEmpty();
            Strings.Repeat("ABC", 0).ShouldBeEmpty();
            Strings.Repeat("ABC", 1).ShouldBe("ABC");
            Strings.Repeat("ABC", 2).ShouldBe("ABCABC");

            "ABC".Repeat(-1).ShouldBeEmpty();
            "ABC".Repeat(0).ShouldBeEmpty();
            "ABC".Repeat(1).ShouldBe("ABC");
            "ABC".Repeat(2).ShouldBe("ABCABC");
        }

        [Fact(DisplayName = "String remove test")]
        public void StringRemoveTest()
        {
            string text = " abcdefghijkl mnopqrstuvwxyz ";

            Strings.RemoveChars(text, 'a', 'b', 'z').ShouldBe(" cdefghijkl mnopqrstuvwxy ");
            Strings.RemoveChars(text, ' ').ShouldBe("abcdefghijklmnopqrstuvwxyz");
            Strings.RemoveWhiteSpace(text).ShouldBe("abcdefghijklmnopqrstuvwxyz");
        }

        [Fact(DisplayName = "String remove duplicate space test")]
        public void StringRemoveDuplicateWhiteSpacesTest()
        {
            Strings.RemoveDuplicateWhiteSpaces("  ").ShouldBe(" ");
            Strings.RemoveDuplicateWhiteSpaces("  1").ShouldBe(" 1");
            Strings.RemoveDuplicateWhiteSpaces("1  ").ShouldBe("1 ");
            Strings.RemoveDuplicateWhiteSpaces("1  1").ShouldBe("1 1");
            Strings.RemoveDuplicateWhiteSpaces(" 11 ").ShouldBe(" 11 ");
            Strings.RemoveDuplicateWhiteSpaces("    ").ShouldBe(" ");
            Strings.RemoveDuplicateWhiteSpaces("  1  ").ShouldBe(" 1 ");
        }

        [Fact(DisplayName = "String remove duplicate char test")]
        public void StringRemoveDuplicateCharTest()
        {
            Strings.RemoveDuplicateChar("zz",'z').ShouldBe("z");
            Strings.RemoveDuplicateChar("zz1",'z').ShouldBe("z1");
            Strings.RemoveDuplicateChar("1zz",'z').ShouldBe("1z");
            Strings.RemoveDuplicateChar("1zz1",'z').ShouldBe("1z1");
            Strings.RemoveDuplicateChar("z11z",'z').ShouldBe("z11z");
            Strings.RemoveDuplicateChar("zzz",'z').ShouldBe("z");
            Strings.RemoveDuplicateChar("zz1zz",'z').ShouldBe("z1z");
        }

        [Fact(DisplayName = "String remove since the given index test")]
        public void StringRemoveSinceTest()
        {
            Strings.RemoveSince("ABCDE",3).ShouldBe("ABC");
        }

        [Fact(DisplayName = "String remove since the given text test")]
        public void StringRemoveSinceWithGivenTextTest()
        {
            Strings.RemoveSince("ABCDE","D").ShouldBe("ABC");
        }

        [Fact(DisplayName = "String remove since the given text and ignore case test")]
        public void StringRemoveSinceWithGivenTextAndIgnoreCaseTest()
        {
            Strings.RemoveSinceIgnoreCase("ABCDE","d").ShouldBe("ABC");
        }

        [Fact(DisplayName = "Extension method for String remove test")]
        public void ExtensionMethodForStringRemoveTest()
        {
            string text = " abcdefghijkl mnopqrstuvwxyz ";

            text.RemoveChars('a', 'b', 'z').ShouldBe(" cdefghijkl mnopqrstuvwxy ");
            text.RemoveChars(' ').ShouldBe("abcdefghijklmnopqrstuvwxyz");
            text.RemoveWhiteSpace().ShouldBe("abcdefghijklmnopqrstuvwxyz");
        }

        [Fact(DisplayName = "All char in given text should be Upper or Lower Case test")]
        public void UpperOrLowerCaseTest()
        {
            Strings.IsUpper("").ShouldBeTrue();
            Strings.IsUpper("a").ShouldBeFalse();
            Strings.IsUpper("A").ShouldBeTrue();
            Strings.IsUpper("aa").ShouldBeFalse();
            Strings.IsUpper("AA").ShouldBeTrue();
            Strings.IsUpper("aA").ShouldBeFalse();
            Strings.IsUpper("Aa").ShouldBeFalse();
            Strings.IsUpper("a123").ShouldBeFalse();
            Strings.IsUpper("A123").ShouldBeTrue();
            Strings.IsUpper("aa123").ShouldBeFalse();
            Strings.IsUpper("AA123").ShouldBeTrue();
            Strings.IsUpper("aA123").ShouldBeFalse();
            Strings.IsUpper("Aa123").ShouldBeFalse();
            Strings.IsUpper("a°").ShouldBeFalse();
            Strings.IsUpper("A°").ShouldBeTrue();
            Strings.IsUpper("aa°").ShouldBeFalse();
            Strings.IsUpper("AA°").ShouldBeTrue();
            Strings.IsUpper("aA°").ShouldBeFalse();
            Strings.IsUpper("Aa°").ShouldBeFalse();
            Strings.IsUpper("a ").ShouldBeFalse();
            Strings.IsUpper("A ").ShouldBeTrue();
            Strings.IsUpper("a a").ShouldBeFalse();
            Strings.IsUpper("A A").ShouldBeTrue();
            Strings.IsUpper("a A").ShouldBeFalse();
            Strings.IsUpper("A a").ShouldBeFalse();
            
            Strings.IsLower("").ShouldBeTrue();
            Strings.IsLower("a").ShouldBeTrue();
            Strings.IsLower("A").ShouldBeFalse();
            Strings.IsLower("aa").ShouldBeTrue();
            Strings.IsLower("AA").ShouldBeFalse();
            Strings.IsLower("aA").ShouldBeFalse();
            Strings.IsLower("Aa").ShouldBeFalse();
            Strings.IsLower("a123").ShouldBeTrue();
            Strings.IsLower("A123").ShouldBeFalse();
            Strings.IsLower("aa123").ShouldBeTrue();
            Strings.IsLower("AA123").ShouldBeFalse();
            Strings.IsLower("aA123").ShouldBeFalse();
            Strings.IsLower("Aa123").ShouldBeFalse();
            Strings.IsLower("a°").ShouldBeTrue();
            Strings.IsLower("A°").ShouldBeFalse();
            Strings.IsLower("aa°").ShouldBeTrue();
            Strings.IsLower("AA°").ShouldBeFalse();
            Strings.IsLower("aA°").ShouldBeFalse();
            Strings.IsLower("Aa°").ShouldBeFalse();
            Strings.IsLower("a ").ShouldBeTrue();
            Strings.IsLower("A ").ShouldBeFalse();
            Strings.IsLower("a a").ShouldBeTrue();
            Strings.IsLower("A A").ShouldBeFalse();
            Strings.IsLower("a A").ShouldBeFalse();
            Strings.IsLower("A a").ShouldBeFalse();
        }

        [Fact(DisplayName = "Truncate test")]
        public void TruncateTest()
        {
            Strings.Truncate("Nietooo",8).ShouldBe("Nietooo");
            Strings.Truncate("Nietooo",7).ShouldBe("Nietooo");
            Strings.Truncate("Nietooo",6).ShouldBe("Nie...");
            Strings.Truncate("Nietooo",5).ShouldBe("Ni...");
            Strings.Truncate("Nietooo",4).ShouldBe("N...");
            Strings.Truncate("Nietooo",3).ShouldBe("Ni.");
            
        }

        [Fact(DisplayName = "String left or right test")]
        public void LeftAndRightTest()
        {
            Strings.Left("ABCDEFG", 0).ShouldBeEmpty();
            Strings.Left("ABCDEFG", 1).ShouldBe("A");
            Strings.Left("ABCDEFG", 2).ShouldBe("AB");
            Strings.Left("ABCDEFG", 3).ShouldBe("ABC");
            Strings.Left("ABCDEFG", 4).ShouldBe("ABCD");
            Strings.Left("ABCDEFG", 5).ShouldBe("ABCDE");
            Strings.Left("ABCDEFG", 6).ShouldBe("ABCDEF");
            Strings.Left("ABCDEFG", 7).ShouldBe("ABCDEFG");
            Strings.Left("ABCDEFG", 8).ShouldBe("ABCDEFG");

            Strings.Right("ABCDEFG", 0).ShouldBeEmpty();
            Strings.Right("ABCDEFG", 1).ShouldBe("G");
            Strings.Right("ABCDEFG", 2).ShouldBe("FG");
            Strings.Right("ABCDEFG", 3).ShouldBe("EFG");
            Strings.Right("ABCDEFG", 4).ShouldBe("DEFG");
            Strings.Right("ABCDEFG", 5).ShouldBe("CDEFG");
            Strings.Right("ABCDEFG", 6).ShouldBe("BCDEFG");
            Strings.Right("ABCDEFG", 7).ShouldBe("ABCDEFG");
            Strings.Right("ABCDEFG", 8).ShouldBe("ABCDEFG");
        }
    }
}