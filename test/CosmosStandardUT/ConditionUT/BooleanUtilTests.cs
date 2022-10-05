namespace CosmosStandardUT.ConditionUT;

[Trait("ConditionUT", "BooleanUtil")]
public class BooleanUtilTests
{
    [Fact(DisplayName = "Boolean value if is true then do sth. test")]
    public void BooleanIfTrueThenDoSomethingTest()
    {
        int val0 = 0, val1 = 0, val2 = 0, val3 = 0, val4 = 0, val5 = 0, val6 = 0, val7 = 0;
        true.IfTrue(() => val0 = 1);
        true.IfTrue(x => val1 = x, 1);
        BooleanVal.Of(true, 1).IfTrue(x => val2 = x);
        BooleanVal<int>.Of(true, 1).IfTrue(x => val3 = x);

        false.IfTrue(() => val4 = 1);
        false.IfTrue(x => val5 = x, 1);
        BooleanVal.Of(false, 1).IfTrue(x => val6 = x);
        BooleanVal<int>.Of(false, 1).IfTrue(x => val7 = x);

        val0.ShouldBe(1);
        val1.ShouldBe(1);
        val2.ShouldBe(1);
        val3.ShouldBe(1);

        val4.ShouldBe(0);
        val5.ShouldBe(0);
        val6.ShouldBe(0);
        val7.ShouldBe(0);
    }

    [Fact(DisplayName = "Boolean value if is false then do sth. test")]
    public void BooleanIfFalseThenDoSomethingTest()
    {
        int val0 = 0, val1 = 0, val2 = 0, val3 = 0, val4 = 0, val5 = 0, val6 = 0, val7 = 0;
        false.IfFalse(() => val0 = 1);
        false.IfFalse(x => val1 = x, 1);
        BooleanVal.Of(false, 1).IfFalse(x => val2 = x);
        BooleanVal<int>.Of(false, 1).IfFalse(x => val3 = x);

        true.IfFalse(() => val4 = 1);
        true.IfFalse(x => val5 = x, 1);
        BooleanVal.Of(true, 1).IfFalse(x => val6 = x);
        BooleanVal<int>.Of(true, 1).IfFalse(x => val7 = x);

        val0.ShouldBe(1);
        val1.ShouldBe(1);
        val2.ShouldBe(1);
        val3.ShouldBe(1);

        val4.ShouldBe(0);
        val5.ShouldBe(0);
        val6.ShouldBe(0);
        val7.ShouldBe(0);
    }

    [Fact(DisplayName = "Boolean value if this then that test")]
    public void BooleanIfThisThenThatTest()
    {
        int val0 = 0, val1 = 0, val2 = 0, val3 = 0, val4 = 0, val5 = 0, val6 = 0, val7 = 0;
        int valA = 0, valB = 0, valC = 0, valD = 0;

        true.Ifttt(() => val0 = 1, () => val1 = 1);
        BooleanVal.Of(true, 1).Ifttt(x => val2 = x, x => val3 = x);
        BooleanVal.Of(true, 1).Ifttt(() => valA = 1, () => valB = 1);

        false.Ifttt(() => val4 = 1, () => val5 = 1);
        BooleanVal.Of(false, 1).Ifttt(x => val6 = x, x => val7 = x);
        BooleanVal.Of(false, 1).Ifttt(() => valC = 1, () => valD = 1);

        val0.ShouldBe(1);
        val1.ShouldBe(0);
        val2.ShouldBe(1);
        val3.ShouldBe(0);

        val4.ShouldBe(0);
        val5.ShouldBe(1);
        val6.ShouldBe(0);
        val7.ShouldBe(1);

        valA.ShouldBe(1);
        valB.ShouldBe(0);
        valC.ShouldBe(0);
        valD.ShouldBe(1);
    }

    [Fact(DisplayName = "Boolean value if this then that string test")]
    public void BooleanIfThisThenThatStringTest()
    {
        true.ToString("1", "2").ShouldBe("1");
        false.ToString("1", "2").ShouldBe("2");
    }

    [Fact(DisplayName = "Boolean value if this then throw exception test")]
    public void BooleanIfThisThenThrowTest()
    {
        var exception = new ArgumentException();

        Assert.Throws<ArgumentException>(() => true.IfTrueThenThrow(exception));
        Assert.Throws<ArgumentException>(() => BooleanVal.Of(true, 1).IfTrueThenThrow(exception));
        Assert.Throws<ArgumentException>(() => BooleanVal.Of(true, 1).IfTrueThenThrow(x => exception));

        Assert.Throws<ArgumentException>(() => false.IfFalseThenThrow(exception));
        Assert.Throws<ArgumentException>(() => BooleanVal.Of(false, 1).IfFalseThenThrow(exception));
        Assert.Throws<ArgumentException>(() => BooleanVal.Of(false, 1).IfFalseThenThrow(x => exception));
    }

#if !NET451 && !NET452
    [Fact(DisplayName = "Boolean value if this then throw exception by builder test")]
    public void BooleanIfThisThenThrowByBuilderTest()
    {
        Assert.Throws<ArgumentException>(() => true.IfTrueThenThrow<ArgumentException>());
        Assert.Throws<ArgumentException>(() => BooleanVal.Of(true, 1).IfTrueThenThrow<int, ArgumentException>());

        Assert.Throws<ArgumentException>(() => false.IfFalseThenThrow<ArgumentException>());
        Assert.Throws<ArgumentException>(() => BooleanVal.Of(false, 1).IfFalseThenThrow<int, ArgumentException>());
    }

#endif

    [Fact(DisplayName = "Boolean value if this then invoke, and return the bool value test")]
    public void BooleanIfThisThenInvokeTest()
    {
        int val0 = 0, val1 = 0, val2 = 0, val3 = 0;
        int val4 = 0, val5 = 0, val6 = 0, val7 = 0;

        true.IfTrueThenInvoke(() => false).ShouldBeFalse();
        true.IfTrueThenInvoke(() => true).ShouldBeTrue();
        false.IfTrueThenInvoke(() => false).ShouldBeFalse();
        false.IfTrueThenInvoke(() => true).ShouldBeFalse();

        true.IfTrueThenInvoke(x => x == 1, 1).ShouldBeTrue();
        true.IfTrueThenInvoke(x => x == 1, 2).ShouldBeFalse();
        false.IfTrueThenInvoke(x => x == 1, 1).ShouldBeFalse();
        false.IfTrueThenInvoke(x => x == 1, 2).ShouldBeFalse();

        true.IfTrueThenInvoke(() => val0 = 1).ShouldBeTrue();
        false.IfTrueThenInvoke(() => val1 = 1).ShouldBeFalse();

        val0.ShouldBe(1);
        val1.ShouldBe(0);

        true.IfTrueThenInvoke(x => val2 = x, 1).ShouldBeTrue();
        false.IfTrueThenInvoke(x => val3 = x, 1).ShouldBeFalse();

        val2.ShouldBe(1);
        val3.ShouldBe(0);

        BooleanVal.Of(true, 1).IfTrueThenInvoke(() => false).Value.ShouldBeFalse();
        BooleanVal.Of(true, 1).IfTrueThenInvoke(() => true).Value.ShouldBeTrue();
        BooleanVal.Of(false, 1).IfTrueThenInvoke(() => false).Value.ShouldBeFalse();
        BooleanVal.Of(false, 1).IfTrueThenInvoke(() => true).Value.ShouldBeFalse();

        BooleanVal.Of(true, 1).IfTrueThenInvoke(x => x == 2).Value.ShouldBeFalse();
        BooleanVal.Of(true, 1).IfTrueThenInvoke(x => x == 1).Value.ShouldBeTrue();
        BooleanVal.Of(false, 1).IfTrueThenInvoke(x => x == 2).Value.ShouldBeFalse();
        BooleanVal.Of(false, 1).IfTrueThenInvoke(x => x == 1).Value.ShouldBeFalse();

        true.IfFalseThenInvoke(() => false).ShouldBeTrue();
        true.IfFalseThenInvoke(() => true).ShouldBeTrue();
        false.IfFalseThenInvoke(() => false).ShouldBeFalse();
        false.IfFalseThenInvoke(() => true).ShouldBeTrue();

        true.IfFalseThenInvoke(x => x == 1, 1).ShouldBeTrue();
        true.IfFalseThenInvoke(x => x == 1, 2).ShouldBeTrue();
        false.IfFalseThenInvoke(x => x == 1, 1).ShouldBeTrue();
        false.IfFalseThenInvoke(x => x == 1, 2).ShouldBeFalse();

        true.IfFalseThenInvoke(() => val4 = 1).ShouldBeTrue();
        false.IfFalseThenInvoke(() => val5 = 1).ShouldBeFalse();

        val4.ShouldBe(0);
        val5.ShouldBe(1);

        true.IfFalseThenInvoke(x => val6 = x, 1).ShouldBeTrue();
        false.IfFalseThenInvoke(x => val7 = x, 1).ShouldBeFalse();

        val6.ShouldBe(0);
        val7.ShouldBe(1);

        BooleanVal.Of(true, 1).IfFalseThenInvoke(() => false).Value.ShouldBeTrue();
        BooleanVal.Of(true, 1).IfFalseThenInvoke(() => true).Value.ShouldBeTrue();
        BooleanVal.Of(false, 1).IfFalseThenInvoke(() => false).Value.ShouldBeFalse();
        BooleanVal.Of(false, 1).IfFalseThenInvoke(() => true).Value.ShouldBeTrue();

        BooleanVal.Of(true, 1).IfFalseThenInvoke(x => x == 2).Value.ShouldBeTrue();
        BooleanVal.Of(true, 1).IfFalseThenInvoke(x => x == 1).Value.ShouldBeTrue();
        BooleanVal.Of(false, 1).IfFalseThenInvoke(x => x == 2).Value.ShouldBeFalse();
        BooleanVal.Of(false, 1).IfFalseThenInvoke(x => x == 1).Value.ShouldBeTrue();
    }

    [Fact(DisplayName = "Covert value from bool to byte test")]
    public void BooleanToByteTest()
    {
        true.ToBinary().ShouldBe((byte) 1);
        false.ToBinary().ShouldBe((byte) 0);
    }

    [Fact(DisplayName = "Invoke sth. and return true or false test")]
    public void InvokeSomethingAndReturnBooleanValueTest()
    {
        int val0 = 0, val1 = 0;
        Action act0 = () => val0 = 1;
        Action act1 = () => val1 = 1;

        act0.InvokeThenTrue().ShouldBeTrue();
        act1.InvokeThenFalse().ShouldBeFalse();

        val0.ShouldBe(1);
        val1.ShouldBe(1);
    }
}