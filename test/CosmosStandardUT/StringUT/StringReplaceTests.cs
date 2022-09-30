using Cosmos.Text;

namespace CosmosStandardUT.StringUT;

[Trait("StringUT", "Strings.Replace")]
public class StringReplaceTests
{
    [Fact(DisplayName = "Replace text ignore case test")]
    public void ReplaceTextAndIgnoreCaseTest()
    {
        Strings.ReplaceIgnoreCase("AABBCC", "a", "_").ShouldBe("__BBCC");
        Strings.ReplaceIgnoreCase("AABBCC", "aa", "__").ShouldBe("__BBCC");
        Strings.ReplaceIgnoreCase("AABBCC", "Aa", "__").ShouldBe("__BBCC");
    }

    [Fact(DisplayName = "Replace text with StringComparison test")]
    public void ReplaceTextWithStringComparisonTest()
    {
        Strings.Replace("AABBCC", "a", "_", StringComparison.OrdinalIgnoreCase).ShouldBe("__BBCC");
        Strings.Replace("AABBCC", "aa", "__", StringComparison.OrdinalIgnoreCase).ShouldBe("__BBCC");
        Strings.Replace("AABBCC", "Aa", "__", StringComparison.OrdinalIgnoreCase).ShouldBe("__BBCC");
        Strings.Replace("AABBCC", "a", "_", StringComparison.Ordinal).ShouldBe("AABBCC");
        Strings.Replace("AABBCC", "aa", "__", StringComparison.Ordinal).ShouldBe("AABBCC");
        Strings.Replace("AABBCC", "Aa", "__", StringComparison.Ordinal).ShouldBe("AABBCC");
    }

    [Fact(DisplayName = "Replace text for only whole phrase test")]
    public void ReplaceTextForOnlyWholePhraseTest()
    {
        var text = "AA BB CC";
        Strings.ReplaceOnlyWholePhrase(text, "AA", "DD").ShouldBe("DD BB CC");
        Strings.ReplaceOnlyWholePhrase(text, "BB", "DD").ShouldBe("AA DD CC");
        Strings.ReplaceOnlyWholePhrase(text, "A", "DD").ShouldBe("AA BB CC");
        Strings.ReplaceOnlyWholePhrase(text, "B", "DD").ShouldBe("AA BB CC");

        text = "AABBCC";
        Strings.ReplaceOnlyWholePhrase(text, "AA", "DD").ShouldBe("AABBCC");
        Strings.ReplaceOnlyWholePhrase(text, "BB", "DD").ShouldBe("AABBCC");
        Strings.ReplaceOnlyWholePhrase(text, "A", "DD").ShouldBe("AABBCC");
        Strings.ReplaceOnlyWholePhrase(text, "B", "DD").ShouldBe("AABBCC");
    }

    [Fact(DisplayName = "Replace text when first occurrence test")]
    public void ReplaceTextWhenFirstOccurrenceTest()
    {
        Strings.ReplaceFirstOccurrence("AABBCCAABBCC", "AA", "00").ShouldBe("00BBCCAABBCC");
    }

    [Fact(DisplayName = "Replace text when last occurrence test")]
    public void ReplaceTextWhenLastOccurrenceTest()
    {
        Strings.ReplaceLastOccurrence("AABBCCAABBCC", "AA", "00").ShouldBe("AABBCC00BBCC");
    }

    [Fact(DisplayName = "Replace text only it at end and ignore case test")]
    public void ReplaceTextOnlyAtEndAndIgnoreCaseTest()
    {
        Strings.ReplaceOnlyAtEndIgnoreCase("AABBCCAABBCCAA", "AA", "00").ShouldBe("AABBCCAABBCC00");
        Strings.ReplaceOnlyAtEndIgnoreCase("AABBCCAABBCCAA", "CC", "00").ShouldBe("AABBCCAABBCCAA");
        Strings.ReplaceOnlyAtEndIgnoreCase("AABBCCAABBCCAA", "aa", "00").ShouldBe("AABBCCAABBCC00");
        Strings.ReplaceOnlyAtEndIgnoreCase("AABBCCAABBCCAA", "cc", "00").ShouldBe("AABBCCAABBCCAA");
        Strings.ReplaceOnlyAtEndIgnoreCase("AABBCCAABBCCAA", "Aa", "00").ShouldBe("AABBCCAABBCC00");
        Strings.ReplaceOnlyAtEndIgnoreCase("AABBCCAABBCCAA", "Cc", "00").ShouldBe("AABBCCAABBCCAA");
    }

    [Fact(DisplayName = "Replace text with recursive test")]
    public void ReplaceRecursiveTest()
    {
        Strings.ReplaceRecursive("ZZAAAAAABBCC", "AA", "A").ShouldBe("ZZABBCC");
    }

    [Fact(DisplayName = "Replace char(s) in a text with space test")]
    public void ReplaceCharsWithWhiteSpaceTest()
    {
        Strings.ReplaceCharsWithWhiteSpace("AABBCCDD", 'A', 'B').ShouldBe("    CCDD");
    }

    [Fact(DisplayName = "Replace numbers with the given char test")]
    public void ReplaceNumbersWithCharTest()
    {
        Strings.ReplaceNumbersWith("AABB1234567890CC", '*').ShouldBe("AABB**********CC");
    }

    [Fact(DisplayName = "Extension method for Replace text ignore case test")]
    public void ExtensionsMethodForReplaceTextAndIgnoreCaseTest()
    {
        "AABBCC".ReplaceIgnoreCase( "a", "_").ShouldBe("__BBCC");
        "AABBCC".ReplaceIgnoreCase( "aa", "__").ShouldBe("__BBCC");
        "AABBCC".ReplaceIgnoreCase( "Aa", "__").ShouldBe("__BBCC");
    }

    [Fact(DisplayName = "Extension method for Replace text with StringComparison test")]
    public void ExtensionsMethodForReplaceTextWithStringComparisonTest()
    {
        "AABBCC".Replace( "a", "_", StringComparison.OrdinalIgnoreCase).ShouldBe("__BBCC");
        "AABBCC".Replace( "aa", "__", StringComparison.OrdinalIgnoreCase).ShouldBe("__BBCC");
        "AABBCC".Replace( "Aa", "__", StringComparison.OrdinalIgnoreCase).ShouldBe("__BBCC");
        "AABBCC".Replace( "a", "_", StringComparison.Ordinal).ShouldBe("AABBCC");
        "AABBCC".Replace( "aa", "__", StringComparison.Ordinal).ShouldBe("AABBCC");
        "AABBCC".Replace( "Aa", "__", StringComparison.Ordinal).ShouldBe("AABBCC");
    }

    [Fact(DisplayName = "Extension method for Replace text for only whole phrase test")]
    public void ExtensionsMethodForReplaceTextForOnlyWholePhraseTest()
    {
        var text = "AA BB CC";
        text.ReplaceOnlyWholePhrase( "AA", "DD").ShouldBe("DD BB CC");
        text.ReplaceOnlyWholePhrase( "BB", "DD").ShouldBe("AA DD CC");
        text.ReplaceOnlyWholePhrase( "A", "DD").ShouldBe("AA BB CC");
        text.ReplaceOnlyWholePhrase( "B", "DD").ShouldBe("AA BB CC");

        text = "AABBCC";
        text.ReplaceOnlyWholePhrase( "AA", "DD").ShouldBe("AABBCC");
        text.ReplaceOnlyWholePhrase( "BB", "DD").ShouldBe("AABBCC");
        text.ReplaceOnlyWholePhrase( "A", "DD").ShouldBe("AABBCC");
        text.ReplaceOnlyWholePhrase( "B", "DD").ShouldBe("AABBCC");
    }

    [Fact(DisplayName = "Extension method for Replace text when first occurrence test")]
    public void ExtensionsMethodForReplaceTextWhenFirstOccurrenceTest()
    {
        "AABBCCAABBCC".ReplaceFirstOccurrence( "AA", "00").ShouldBe("00BBCCAABBCC");
    }

    [Fact(DisplayName = "Extension method for Replace text when last occurrence test")]
    public void ExtensionsMethodForReplaceTextWhenLastOccurrenceTest()
    {
        "AABBCCAABBCC".ReplaceLastOccurrence( "AA", "00").ShouldBe("AABBCC00BBCC");
    }

    [Fact(DisplayName = "Extension method for Replace text only it at end and ignore case test")]
    public void ExtensionsMethodForReplaceTextOnlyAtEndAndIgnoreCaseTest()
    {
        "AABBCCAABBCCAA".ReplaceOnlyAtEndIgnoreCase("AA", "00").ShouldBe("AABBCCAABBCC00");
        "AABBCCAABBCCAA".ReplaceOnlyAtEndIgnoreCase("CC", "00").ShouldBe("AABBCCAABBCCAA");
        "AABBCCAABBCCAA".ReplaceOnlyAtEndIgnoreCase("aa", "00").ShouldBe("AABBCCAABBCC00");
        "AABBCCAABBCCAA".ReplaceOnlyAtEndIgnoreCase("cc", "00").ShouldBe("AABBCCAABBCCAA");
        "AABBCCAABBCCAA".ReplaceOnlyAtEndIgnoreCase("Aa", "00").ShouldBe("AABBCCAABBCC00");
        "AABBCCAABBCCAA".ReplaceOnlyAtEndIgnoreCase("Cc", "00").ShouldBe("AABBCCAABBCCAA");
    }

    [Fact(DisplayName = "Extension method for Replace text with recursive test")]
    public void ExtensionsMethodForReplaceRecursiveTest()
    {
        "ZZAAAAAABBCC".ReplaceRecursive( "AA", "A").ShouldBe("ZZABBCC");
    }

    [Fact(DisplayName = "Extension method for Replace char(s) in a text with space test")]
    public void ExtensionsMethodForReplaceCharsWithWhiteSpaceTest()
    {
        "AABBCCDD".ReplaceCharsWithWhiteSpace( 'A', 'B').ShouldBe("    CCDD");
    }

    [Fact(DisplayName = "Extension method for Replace numbers with the given char test")]
    public void ExtensionsMethodForReplaceNumbersWithCharTest()
    {
        "AABB1234567890CC".ReplaceNumbersWith('*').ShouldBe("AABB**********CC");
    }
}