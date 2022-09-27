using Cosmos.Conversions;

namespace CosmosStandardUT.ConvUT;

[Trait("ConvUT", "Scale")]
public class ScaleConvTests
{
    [Fact(DisplayName = "X-2-X test")]
    public void SystemToSystemTest()
    {
        ScaleConv.X2X("101110", 2, 10).ShouldBe("46");
        ScaleConv.X2X("101110", 2, 16).ShouldBe("2E");
        ScaleConv.X2X("128", 10, 16).ShouldBe("80");
        ScaleConv.X2X("2E", 16, 10).ShouldBe("46");
    }

    [Fact(DisplayName = "XN-2-XN test")]
    public void SystemSameToSystemSameTest()
    {
        ScaleConv.X2X("101110", 2, 2).ShouldBe("101110");
        ScaleConv.X2X("101110", 3, 3).ShouldBe("101110");
        ScaleConv.X2X("101110", 4, 4).ShouldBe("101110");
        ScaleConv.X2X("101110", 5, 5).ShouldBe("101110");
        ScaleConv.X2X("101110", 6, 6).ShouldBe("101110");
        ScaleConv.X2X("101110", 7, 7).ShouldBe("101110");
        ScaleConv.X2X("101110", 8, 8).ShouldBe("101110");
        ScaleConv.X2X("101110", 9, 9).ShouldBe("101110");
        ScaleConv.X2X("101110", 10, 10).ShouldBe("101110");
        ScaleConv.X2X("101110", 11, 11).ShouldBe("101110");
        ScaleConv.X2X("101110", 12, 12).ShouldBe("101110");
        ScaleConv.X2X("101110", 13, 13).ShouldBe("101110");
        ScaleConv.X2X("101110", 14, 14).ShouldBe("101110");
        ScaleConv.X2X("101110", 15, 15).ShouldBe("101110");
        ScaleConv.X2X("101110", 16, 16).ShouldBe("101110");
        ScaleConv.X2X("101110", 17, 17).ShouldBe("101110");
        ScaleConv.X2X("101110", 18, 18).ShouldBe("101110");
        ScaleConv.X2X("101110", 19, 19).ShouldBe("101110");
        ScaleConv.X2X("101110", 20, 20).ShouldBe("101110");
        ScaleConv.X2X("101110", 21, 21).ShouldBe("101110");
        ScaleConv.X2X("101110", 22, 22).ShouldBe("101110");
        ScaleConv.X2X("101110", 23, 23).ShouldBe("101110");
        ScaleConv.X2X("101110", 24, 24).ShouldBe("101110");
        ScaleConv.X2X("101110", 25, 25).ShouldBe("101110");
        ScaleConv.X2X("101110", 26, 26).ShouldBe("101110");
        ScaleConv.X2X("101110", 27, 27).ShouldBe("101110");
        ScaleConv.X2X("101110", 28, 28).ShouldBe("101110");
        ScaleConv.X2X("101110", 29, 29).ShouldBe("101110");
        ScaleConv.X2X("101110", 30, 30).ShouldBe("101110");
        ScaleConv.X2X("101110", 31, 31).ShouldBe("101110");
        ScaleConv.X2X("101110", 32, 32).ShouldBe("101110");
        ScaleConv.X2X("101110", 33, 33).ShouldBe("101110");
        ScaleConv.X2X("101110", 34, 34).ShouldBe("101110");
        ScaleConv.X2X("101110", 35, 35).ShouldBe("101110");
        ScaleConv.X2X("101110", 36, 36).ShouldBe("101110");
    }

    [Fact(DisplayName = "X02-2-X10 test")]
    public void System02ToSystem10Test()
    {
        ScaleConv.BinToDec("101110").ShouldBe(46);
    }

    [Fact(DisplayName = "X02-2-X16 test")]
    public void System02ToSystem16Test()
    {
        ScaleConv.BinToHex("101110").ShouldBe("2E");
    }

    [Fact(DisplayName = "X10-2-X02 test")]
    public void System10ToSystem02Test()
    {
        ScaleConv.DecToBin("46").ShouldBe("101110");
        ScaleConv.DecToBin(46).ShouldBe("101110");
    }

    [Fact(DisplayName = "X10-2-X16 test")]
    public void System10ToSystem16Test()
    {
        ScaleConv.DecToHex("46").ShouldBe("2E");
        ScaleConv.DecToHex("46", 4).ShouldBe("002E");
        ScaleConv.DecToHex(46).ShouldBe("2E");
        ScaleConv.DecToHex(65, 66).ShouldBe("4142");
        ScaleConv.DecToHex(66, 65).ShouldBe("4241");
    }

    [Fact(DisplayName = "X16-2-X10 test")]
    public void System16ToSystem10Test()
    {
        ScaleConv.HexToDec("2E").ShouldBe("46");
    }

    [Fact(DisplayName = "X16-2-X02 test")]
    public void System16ToSystem02Test()
    {
        ScaleConv.HexToBin("2E").ShouldBe("101110");
    }

    [Fact(DisplayName = "Letters-2-X16 test")]
    public void LettersAndSystem16Test()
    {
        ScaleConv.LettersToHex("ABC").ShouldBe("41 42 43");
        ScaleConv.HexToLetters("41 42 43").ShouldBe("ABC");
    }

    [Fact(DisplayName = "LongHex-2-X10Bytes test")]
    public void LongHexAndDecBytesTest()
    {
        var byteArray = ScaleConv.LongHexToDecBytes("41 42 43");

        byteArray.Length.ShouldBe(3);
        byteArray[0].ShouldBe((byte) 65);
        byteArray[1].ShouldBe((byte) 66);
        byteArray[2].ShouldBe((byte) 67);

        var longHex = ScaleConv.DecBytesToLongHex(byteArray);

        longHex.ShouldNotBeEmpty();
        longHex.ShouldBe("41 42 43");
    }

    [Fact]
    public void HexReverseTest()
    {
        Hex.Reverse("E81AD0E").ShouldBe("0EAD810E");
        Hex.Reverse("6E81AD0E").ShouldBe("0EAD816E");
    }

    [Fact]
    public void BinReverseTest()
    {
        Bin.Reverse("1101110100000011010110100001110").ShouldBe("00001110101011011000000101101110");
        Bin.Reverse("01101110100000011010110100001110").ShouldBe("00001110101011011000000101101110");
    }
}