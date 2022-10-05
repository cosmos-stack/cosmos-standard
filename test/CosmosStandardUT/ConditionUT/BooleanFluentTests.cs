using System.Collections.Generic;

namespace CosmosStandardUT.ConditionUT;

[Trait("ConditionUT", "BooleanFluent")]
public class BooleanFluentTests
{
    [Fact(DisplayName = "2-and test")]
    public void AndAndTest()
    {
        true.And(true).ShouldBeTrue();
        true.And(false).ShouldBeFalse();
        false.And(true).ShouldBeFalse();
        false.And(false).ShouldBeFalse();

        true.And(() => true).ShouldBeTrue();
        true.And(() => false).ShouldBeFalse();
        false.And(() => true).ShouldBeFalse();
        false.And(() => false).ShouldBeFalse();
    }

    [Fact(DisplayName = "2-and with context test")]
    public void AndAndWithContextTest()
    {
        var val0 = true.And(() => true, 1);
        var val1 = true.And(() => false, 1);
        var val2 = false.And(() => true, 1);
        var val3 = false.And(() => false, 1);

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeFalse();
        val2.Value.ShouldBeFalse();
        val3.Value.ShouldBeFalse();

        val0.Object.ShouldBe(1);
        val1.Object.ShouldBe(1);
        val2.Object.ShouldBe(1);
        val3.Object.ShouldBe(1);
    }

    [Fact(DisplayName = "2-and and return tuple test")]
    public void AndAndReturnTupleTest()
    {
        var val0 = true.And(() => (true, 1));
        var val1 = true.And(() => (false, 1));
        var val2 = false.And(() => (true, 1));
        var val3 = false.And(() => (false, 1));

        var val4 = BooleanVal.Of(true, 1).And(() => (true, 2));
        var val5 = BooleanVal.Of(true, 1).And(() => (false, 2));
        var val6 = BooleanVal.Of(false, 1).And(() => (true, 2));
        var val7 = BooleanVal.Of(false, 1).And(() => (false, 2));

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeFalse();
        val2.Value.ShouldBeFalse();
        val3.Value.ShouldBeFalse();
        val4.Value.ShouldBeTrue();
        val5.Value.ShouldBeFalse();
        val6.Value.ShouldBeFalse();
        val7.Value.ShouldBeFalse();

        val0.Object.ShouldBe(1);
        val1.Object.ShouldBe(1);
        val2.Object.ShouldBe(0);
        val3.Object.ShouldBe(0);
        val4.Object.ShouldBe(2);
        val5.Object.ShouldBe(2);
        val6.Object.ShouldBe(1);
        val7.Object.ShouldBe(1);
    }

    [Fact(DisplayName = "2-and and return BooleanVal test")]
    public void AndAndReturnBooleanValTest()
    {
        var val0 = true.And(() => true.ToBooleanVal(1));
        var val1 = true.And(() => false.ToBooleanVal(1));
        var val2 = false.And(() => true.ToBooleanVal(1));
        var val3 = false.And(() => false.ToBooleanVal(1));

        var val4 = true.And(x => true.ToBooleanVal(x), 2);
        var val5 = true.And(x => false.ToBooleanVal(x), 2);
        var val6 = false.And(x => true.ToBooleanVal(x), 2);
        var val7 = false.And(x => false.ToBooleanVal(x), 2);

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeFalse();
        val2.Value.ShouldBeFalse();
        val3.Value.ShouldBeFalse();
        val4.Value.ShouldBeTrue();
        val5.Value.ShouldBeFalse();
        val6.Value.ShouldBeFalse();
        val7.Value.ShouldBeFalse();

        val0.Object.ShouldBe(1);
        val1.Object.ShouldBe(1);
        val2.Object.ShouldBe(0);
        val3.Object.ShouldBe(0);
        val4.Object.ShouldBe(2);
        val5.Object.ShouldBe(2);
        val6.Object.ShouldBe(2);
        val7.Object.ShouldBe(2);
    }

    [Fact(DisplayName = "2-and with BooleanVal and return BooleanVal test")]
    public void AndAndWithValReturnBooleanValTest()
    {
        var val0 = BooleanVal.Of(true, 1).And(() => true.ToBooleanVal(2));
        var val1 = BooleanVal.Of(true, 1).And(() => false.ToBooleanVal(2));
        var val2 = BooleanVal.Of(false, 1).And(() => true.ToBooleanVal(2));
        var val3 = BooleanVal.Of(false, 1).And(() => false.ToBooleanVal(2));

        var val4 = BooleanVal.Of(true, 1).And(x => true.ToBooleanVal(x + 1));
        var val5 = BooleanVal.Of(true, 1).And(x => false.ToBooleanVal(x + 1));
        var val6 = BooleanVal.Of(false, 1).And(x => true.ToBooleanVal(x + 1));
        var val7 = BooleanVal.Of(false, 1).And(x => false.ToBooleanVal(x + 1));

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeFalse();
        val2.Value.ShouldBeFalse();
        val3.Value.ShouldBeFalse();
        val4.Value.ShouldBeTrue();
        val5.Value.ShouldBeFalse();
        val6.Value.ShouldBeFalse();
        val7.Value.ShouldBeFalse();

        val0.Object.ShouldBe(2);
        val1.Object.ShouldBe(2);
        val2.Object.ShouldBe(1);
        val3.Object.ShouldBe(1);
        val4.Object.ShouldBe(2);
        val5.Object.ShouldBe(2);
        val6.Object.ShouldBe(1);
        val7.Object.ShouldBe(1);
    }

    [Fact(DisplayName = "3-and test")]
    public void AndAndAndTest()
    {
        true.And(() => true).And(() => true).ShouldBeTrue();
        true.And(() => false).And(() => true).ShouldBeFalse();
        true.And(() => true).And(() => false).ShouldBeFalse();
        true.And(() => false).And(() => false).ShouldBeFalse();
        false.And(() => true).And(() => true).ShouldBeFalse();
        false.And(() => false).And(() => true).ShouldBeFalse();
        false.And(() => true).And(() => false).ShouldBeFalse();
        false.And(() => false).And(() => false).ShouldBeFalse();
    }

    [Fact(DisplayName = "1-and with condition coll test")]
    public void AndCollTest()
    {
        var coll0 = new List<Func<bool>>
        {
            () => true,
            () => true,
            () => true
        };
        var coll1 = new List<Func<bool>>
        {
            () => true,
            () => false,
            () => true
        };
        var coll2 = new List<Func<bool>>
        {
            () => false,
            () => false,
            () => false
        };

        true.And(coll0).ShouldBeTrue();
        true.And(coll1).ShouldBeFalse();
        true.And(coll2).ShouldBeFalse();
    }
        
    [Fact(DisplayName = "2-or test")]
    public void OrOrTest()
    {
        true.Or(true).ShouldBeTrue();
        true.Or(false).ShouldBeTrue();
        false.Or(true).ShouldBeTrue();
        false.Or(false).ShouldBeFalse();

        true.Or(() => true).ShouldBeTrue();
        true.Or(() => false).ShouldBeTrue();
        false.Or(() => true).ShouldBeTrue();
        false.Or(() => false).ShouldBeFalse();
    }

    [Fact(DisplayName = "2-or with context test")]
    public void OrOrWithContextTest()
    {
        var val0 = true.Or(() => true, 1);
        var val1 = true.Or(() => false, 1);
        var val2 = false.Or(() => true, 1);
        var val3 = false.Or(() => false, 1);

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeTrue();
        val2.Value.ShouldBeTrue();
        val3.Value.ShouldBeFalse();

        val0.Object.ShouldBe(1);
        val1.Object.ShouldBe(1);
        val2.Object.ShouldBe(1);
        val3.Object.ShouldBe(1);
    }

    [Fact(DisplayName = "2-or and return tuple test")]
    public void OrOrReturnTupleTest()
    {
        var val0 = true.Or(() => (true, 1));
        var val1 = true.Or(() => (false, 1));
        var val2 = false.Or(() => (true, 1));
        var val3 = false.Or(() => (false, 1));

        var val4 = BooleanVal.Of(true, 1).Or(() => (true, 2));
        var val5 = BooleanVal.Of(true, 1).Or(() => (false, 2));
        var val6 = BooleanVal.Of(false, 1).Or(() => (true, 2));
        var val7 = BooleanVal.Of(false, 1).Or(() => (false, 2));

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeTrue();
        val2.Value.ShouldBeTrue();
        val3.Value.ShouldBeFalse();
        val4.Value.ShouldBeTrue();
        val5.Value.ShouldBeTrue();
        val6.Value.ShouldBeTrue();
        val7.Value.ShouldBeFalse();

        val0.Object.ShouldBe(0);
        val1.Object.ShouldBe(0);
        val2.Object.ShouldBe(1);
        val3.Object.ShouldBe(1);
        val4.Object.ShouldBe(1);
        val5.Object.ShouldBe(1);
        val6.Object.ShouldBe(2);
        val7.Object.ShouldBe(2);
    }

    [Fact(DisplayName = "2-or and return BooleanVal test")]
    public void OrOrReturnBooleanValTest()
    {
        var val0 = true.Or(() => true.ToBooleanVal(1));
        var val1 = true.Or(() => false.ToBooleanVal(1));
        var val2 = false.Or(() => true.ToBooleanVal(1));
        var val3 = false.Or(() => false.ToBooleanVal(1));

        var val4 = true.Or(x => true.ToBooleanVal(x), 2);
        var val5 = true.Or(x => false.ToBooleanVal(x), 2);
        var val6 = false.Or(x => true.ToBooleanVal(x), 2);
        var val7 = false.Or(x => false.ToBooleanVal(x), 2);

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeTrue();
        val2.Value.ShouldBeTrue();
        val3.Value.ShouldBeFalse();
        val4.Value.ShouldBeTrue();
        val5.Value.ShouldBeTrue();
        val6.Value.ShouldBeTrue();
        val7.Value.ShouldBeFalse();

        val0.Object.ShouldBe(0);
        val1.Object.ShouldBe(0);
        val2.Object.ShouldBe(1);
        val3.Object.ShouldBe(1);
        val4.Object.ShouldBe(2);
        val5.Object.ShouldBe(2);
        val6.Object.ShouldBe(2);
        val7.Object.ShouldBe(2);
    }

    [Fact(DisplayName = "2-or with BooleanVal and return BooleanVal test")]
    public void OrOrWithValReturnBooleanValTest()
    {
        var val0 = BooleanVal.Of(true, 1).Or(() => true.ToBooleanVal(2));
        var val1 = BooleanVal.Of(true, 1).Or(() => false.ToBooleanVal(2));
        var val2 = BooleanVal.Of(false, 1).Or(() => true.ToBooleanVal(2));
        var val3 = BooleanVal.Of(false, 1).Or(() => false.ToBooleanVal(2));

        var val4 = BooleanVal.Of(true, 1).Or(x => true.ToBooleanVal(x + 1));
        var val5 = BooleanVal.Of(true, 1).Or(x => false.ToBooleanVal(x + 1));
        var val6 = BooleanVal.Of(false, 1).Or(x => true.ToBooleanVal(x + 1));
        var val7 = BooleanVal.Of(false, 1).Or(x => false.ToBooleanVal(x + 1));

        val0.Value.ShouldBeTrue();
        val1.Value.ShouldBeTrue();
        val2.Value.ShouldBeTrue();
        val3.Value.ShouldBeFalse();
        val4.Value.ShouldBeTrue();
        val5.Value.ShouldBeTrue();
        val6.Value.ShouldBeTrue();
        val7.Value.ShouldBeFalse();

        val0.Object.ShouldBe(1);
        val1.Object.ShouldBe(1);
        val2.Object.ShouldBe(2);
        val3.Object.ShouldBe(2);
        val4.Object.ShouldBe(1);
        val5.Object.ShouldBe(1);
        val6.Object.ShouldBe(2);
        val7.Object.ShouldBe(2);
    }

    [Fact(DisplayName = "3-or test")]
    public void OrOrOrTest()
    {
        true.Or(() => true).Or(() => true).ShouldBeTrue();
        true.Or(() => false).Or(() => true).ShouldBeTrue();
        true.Or(() => true).Or(() => false).ShouldBeTrue();
        true.Or(() => false).Or(() => false).ShouldBeTrue();
        false.Or(() => true).Or(() => true).ShouldBeTrue();
        false.Or(() => false).Or(() => true).ShouldBeTrue();
        false.Or(() => true).Or(() => false).ShouldBeTrue();
        false.Or(() => false).Or(() => false).ShouldBeFalse();
    }

    [Fact(DisplayName = "1-or with condition coll test")]
    public void OrCollTest()
    {
        var coll0 = new List<Func<bool>>
        {
            () => true,
            () => true,
            () => true
        };
        var coll1 = new List<Func<bool>>
        {
            () => true,
            () => false,
            () => true
        };
        var coll2 = new List<Func<bool>>
        {
            () => false,
            () => false,
            () => false
        };

        true.Or(coll0).ShouldBeTrue();
        true.Or(coll1).ShouldBeTrue();
        true.Or(coll2).ShouldBeTrue();

        false.Or(coll0).ShouldBeTrue();
        false.Or(coll1).ShouldBeTrue();
        false.Or(coll2).ShouldBeFalse();
    }

    [Fact(DisplayName = "and-or mixed test")]
    public void AndOrMixedTest()
    {
        true.And(true).And(true).Or(false).ShouldBeTrue();
        false.Or(false).Or(true).Or(false).ShouldBeTrue();
    }
}