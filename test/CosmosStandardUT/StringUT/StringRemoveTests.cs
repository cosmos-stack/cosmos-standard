using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Remove")]
    public class StringRemoveTests
    {
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
            Strings.RemoveDuplicateChar("zz", 'z').ShouldBe("z");
            Strings.RemoveDuplicateChar("zz1", 'z').ShouldBe("z1");
            Strings.RemoveDuplicateChar("1zz", 'z').ShouldBe("1z");
            Strings.RemoveDuplicateChar("1zz1", 'z').ShouldBe("1z1");
            Strings.RemoveDuplicateChar("z11z", 'z').ShouldBe("z11z");
            Strings.RemoveDuplicateChar("zzz", 'z').ShouldBe("z");
            Strings.RemoveDuplicateChar("zz1zz", 'z').ShouldBe("z1z");
        }

        [Fact(DisplayName = "String remove since the given index test")]
        public void StringRemoveSinceTest()
        {
            Strings.RemoveSince("ABCDE", 3).ShouldBe("ABC");
        }

        [Fact(DisplayName = "String remove since the given text test")]
        public void StringRemoveSinceWithGivenTextTest()
        {
            Strings.RemoveSince("ABCDE", "D").ShouldBe("ABC");
        }

        [Fact(DisplayName = "String remove since the given text and ignore case test")]
        public void StringRemoveSinceWithGivenTextAndIgnoreCaseTest()
        {
            Strings.RemoveSinceIgnoreCase("ABCDE", "d").ShouldBe("ABC");
        }

        [Fact(DisplayName = "Extension method for String remove test")]
        public void ExtensionMethodForStringRemoveTest()
        {
            string text = " abcdefghijkl mnopqrstuvwxyz ";

            text.RemoveChars('a', 'b', 'z').ShouldBe(" cdefghijkl mnopqrstuvwxy ");
            text.RemoveChars(' ').ShouldBe("abcdefghijklmnopqrstuvwxyz");
            text.RemoveWhiteSpace().ShouldBe("abcdefghijklmnopqrstuvwxyz");
        }

        [Fact(DisplayName = "Extension method for String remove duplicate space test")]
        public void ExtensionMethodForStringRemoveDuplicateWhiteSpacesTest()
        {
            "  ".RemoveDuplicateWhiteSpaces().ShouldBe(" ");
            "  1".RemoveDuplicateWhiteSpaces().ShouldBe(" 1");
            "1  ".RemoveDuplicateWhiteSpaces().ShouldBe("1 ");
            "1  1".RemoveDuplicateWhiteSpaces().ShouldBe("1 1");
            " 11 ".RemoveDuplicateWhiteSpaces().ShouldBe(" 11 ");
            "    ".RemoveDuplicateWhiteSpaces().ShouldBe(" ");
            "  1  ".RemoveDuplicateWhiteSpaces().ShouldBe(" 1 ");
        }

        [Fact(DisplayName = "Extension method for String remove duplicate char test")]
        public void ExtensionMethodForStringRemoveDuplicateCharTest()
        {
            "zz".RemoveDuplicateChar('z').ShouldBe("z");
            "zz1".RemoveDuplicateChar('z').ShouldBe("z1");
            "1zz".RemoveDuplicateChar('z').ShouldBe("1z");
            "1zz1".RemoveDuplicateChar('z').ShouldBe("1z1");
            "z11z".RemoveDuplicateChar('z').ShouldBe("z11z");
            "zzz".RemoveDuplicateChar('z').ShouldBe("z");
            "zz1zz".RemoveDuplicateChar('z').ShouldBe("z1z");
        }

        [Fact(DisplayName = "Extension method for String remove since the given index test")]
        public void ExtensionMethodForStringRemoveSinceTest()
        {
            "ABCDE".RemoveSince(3).ShouldBe("ABC");
        }

        [Fact(DisplayName = "Extension method for String remove since the given text test")]
        public void ExtensionMethodForStringRemoveSinceWithGivenTextTest()
        {
            "ABCDE".RemoveSince("D").ShouldBe("ABC");
        }

        [Fact(DisplayName = "String remove since the given text and ignore case test")]
        public void ExtensionMethodForStringRemoveSinceWithGivenTextAndIgnoreCaseTest()
        {
            Strings.RemoveSinceIgnoreCase("ABCDE", "d").ShouldBe("ABC");
        }
    }
}