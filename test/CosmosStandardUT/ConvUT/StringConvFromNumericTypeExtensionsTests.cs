using Cosmos.Text;

namespace CosmosStandardUT.ConvUT;

[Trait("ConvUT", "StringConv.StrFromNumeric")]
public class StringConvFromNumericTypeExtensionsTests
{
    [Fact(DisplayName = "Convert byte and sbyte value to string test")]
    public void ByteAndSByteConvertToStringTest()
    {
        byte val0 = 0;
        byte val1 = 1;
        sbyte val2 = -1;
        sbyte val3 = 0;
        sbyte val4 = 1;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
    }

    [Fact(DisplayName = "Convert int16 and uint16 value to string test")]
    public void Int16AndUInt16ConvertToStringTest()
    {
        Int16 val0 = 0;
        Int16 val1 = 1;
        Int16 val2 = -1;
        UInt16 val3 = 0;
        UInt16 val4 = 1;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
    }

    [Fact(DisplayName = "Convert int32 and uint32 value to string test")]
    public void Int32AndUInt32ConvertToStringTest()
    {
        Int32 val0 = 0;
        Int32 val1 = 1;
        Int32 val2 = -1;
        UInt32 val3 = 0;
        UInt32 val4 = 1;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
    }

    [Fact(DisplayName = "Convert int64 and uint64 value to string test")]
    public void Int64AndUInt64ConvertToStringTest()
    {
        Int64 val0 = 0;
        Int64 val1 = 1;
        Int64 val2 = -1;
        UInt64 val3 = 0;
        UInt64 val4 = 1;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
    }

    [Fact(DisplayName = "Convert nullable byte and sbyte value to string test")]
    public void NullableByteAndSByteConvertToStringTest()
    {
        byte? val0 = 0;
        byte? val1 = 1;
        sbyte? val2 = -1;
        sbyte? val3 = 0;
        sbyte? val4 = 1;

        byte? valA = null;
        sbyte? valB = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString((byte) 2).ShouldBe("0");
        val1.CastToString((byte) 2).ShouldBe("1");
        val2.CastToString((sbyte) 2).ShouldBe("-1");
        val3.CastToString((sbyte) 2).ShouldBe("0");
        val4.CastToString((sbyte) 2).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (byte) 2).ShouldBe("2");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (byte) 2).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("2");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("1");

        valA.CastToString().ShouldBeEmpty();
        valB.CastToString().ShouldBeEmpty();

        valA.CastToString("---").ShouldBe("---");
        valB.CastToString("---").ShouldBe("---");

        valA.CastToString((byte) 2).ShouldBe("2");
        valB.CastToString((sbyte) 2).ShouldBe("2");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valB.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (byte) 2).ShouldBe("2");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("2");
    }

    [Fact(DisplayName = "Convert nullable int16 and uint16 value to string test")]
    public void NullableInt16AndUInt16ConvertToStringTest()
    {
        Int16? val0 = 0;
        Int16? val1 = 1;
        Int16? val2 = -1;
        UInt16? val3 = 0;
        UInt16? val4 = 1;

        Int16? valA = null;
        UInt16? valB = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString((Int16) 2).ShouldBe("0");
        val1.CastToString((Int16) 2).ShouldBe("1");
        val2.CastToString((Int16) 2).ShouldBe("-1");
        val3.CastToString((UInt16) 2).ShouldBe("0");
        val4.CastToString((UInt16) 2).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("2");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt16) 2).ShouldBe("2");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt16) 2).ShouldBe("1");

        valA.CastToString().ShouldBeEmpty();
        valB.CastToString().ShouldBeEmpty();

        valA.CastToString("---").ShouldBe("---");
        valB.CastToString("---").ShouldBe("---");

        valA.CastToString((Int16) 2).ShouldBe("2");
        valB.CastToString((UInt16) 2).ShouldBe("2");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valB.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("2");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt16) 2).ShouldBe("2");
    }

    [Fact(DisplayName = "Convert nullable int32 and uint32 value to string test")]
    public void NullableInt32AndUInt32ConvertToStringTest()
    {
        Int32? val0 = 0;
        Int32? val1 = 1;
        Int32? val2 = -1;
        UInt32? val3 = 0;
        UInt32? val4 = 1;

        Int32? valA = null;
        UInt32? valB = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString((Int32) 2).ShouldBe("0");
        val1.CastToString((Int32) 2).ShouldBe("1");
        val2.CastToString((Int32) 2).ShouldBe("-1");
        val3.CastToString((UInt32) 2).ShouldBe("0");
        val4.CastToString((UInt32) 2).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("2");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt32) 2).ShouldBe("2");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt32) 2).ShouldBe("1");

        valA.CastToString().ShouldBeEmpty();
        valB.CastToString().ShouldBeEmpty();

        valA.CastToString("---").ShouldBe("---");
        valB.CastToString("---").ShouldBe("---");

        valA.CastToString((Int32) 2).ShouldBe("2");
        valB.CastToString((UInt32) 2).ShouldBe("2");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valB.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("2");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt32) 2).ShouldBe("2");
    }

    [Fact(DisplayName = "Convert nullable int64 and uint64 value to string test")]
    public void NullableInt64AndUInt64ConvertToStringTest()
    {
        Int64? val0 = 0;
        Int64? val1 = 1;
        Int64? val2 = -1;
        UInt64? val3 = 0;
        UInt64? val4 = 1;

        Int64? valA = null;
        UInt64? valB = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("-1");
        val3.CastToString().ShouldBe("0");
        val4.CastToString().ShouldBe("1");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("-1");
        val3.CastToString("---").ShouldBe("0");
        val4.CastToString("---").ShouldBe("1");

        val0.CastToString((Int64) 2).ShouldBe("0");
        val1.CastToString((Int64) 2).ShouldBe("1");
        val2.CastToString((Int64) 2).ShouldBe("-1");
        val3.CastToString((UInt64) 2).ShouldBe("0");
        val4.CastToString((UInt64) 2).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("2");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("-1");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt64) 2).ShouldBe("2");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt64) 2).ShouldBe("1");

        valA.CastToString().ShouldBeEmpty();
        valB.CastToString().ShouldBeEmpty();

        valA.CastToString("---").ShouldBe("---");
        valB.CastToString("---").ShouldBe("---");

        valA.CastToString((Int64) 2).ShouldBe("2");
        valB.CastToString((UInt64) 2).ShouldBe("2");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valB.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("2");
        valB.CastToString(NumericConvOptions.ZeroAsEmpty, (UInt64) 2).ShouldBe("2");
    }

    [Fact(DisplayName = "Convert float value to string test")]
    public void FloatConvertToStringTest()
    {
        float val0 = 0;
        float val1 = 1;
        float val2 = 1.111F;
        float val3 = -1;
        float val4 = -1.111F;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("1.11");
        val3.CastToString().ShouldBe("-1");
        val4.CastToString().ShouldBe("-1.11");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("1.11");
        val3.CastToString("---").ShouldBe("-1");
        val4.CastToString("---").ShouldBe("-1.11");

        val0.CastToString(3).ShouldBe("0");
        val1.CastToString(3).ShouldBe("1");
        val2.CastToString(3).ShouldBe("1.111");
        val3.CastToString(3).ShouldBe("-1");
        val4.CastToString(3).ShouldBe("-1.111");

        val0.CastToString(3, "---").ShouldBe("0");
        val1.CastToString(3, "---").ShouldBe("1");
        val2.CastToString(3, "---").ShouldBe("1.111");
        val3.CastToString(3, "---").ShouldBe("-1");
        val4.CastToString(3, "---").ShouldBe("-1.111");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");
    }

    [Fact(DisplayName = "Convert double value to string test")]
    public void DoubleConvertToStringTest()
    {
        double val0 = 0;
        double val1 = 1;
        double val2 = 1.111;
        double val3 = -1;
        double val4 = -1.111;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("1.11");
        val3.CastToString().ShouldBe("-1");
        val4.CastToString().ShouldBe("-1.11");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("1.11");
        val3.CastToString("---").ShouldBe("-1");
        val4.CastToString("---").ShouldBe("-1.11");

        val0.CastToString(3).ShouldBe("0");
        val1.CastToString(3).ShouldBe("1");
        val2.CastToString(3).ShouldBe("1.111");
        val3.CastToString(3).ShouldBe("-1");
        val4.CastToString(3).ShouldBe("-1.111");

        val0.CastToString(3, "---").ShouldBe("0");
        val1.CastToString(3, "---").ShouldBe("1");
        val2.CastToString(3, "---").ShouldBe("1.111");
        val3.CastToString(3, "---").ShouldBe("-1");
        val4.CastToString(3, "---").ShouldBe("-1.111");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");
    }

    [Fact(DisplayName = "Convert decimal value to string test")]
    public void DecimalConvertToStringTest()
    {
        decimal val0 = 0;
        decimal val1 = 1;
        decimal val2 = (decimal) 1.111;
        decimal val3 = -1;
        decimal val4 = (decimal) -1.111;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("1.11");
        val3.CastToString().ShouldBe("-1");
        val4.CastToString().ShouldBe("-1.11");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("1.11");
        val3.CastToString("---").ShouldBe("-1");
        val4.CastToString("---").ShouldBe("-1.11");

        val0.CastToString(3).ShouldBe("0");
        val1.CastToString(3).ShouldBe("1");
        val2.CastToString(3).ShouldBe("1.111");
        val3.CastToString(3).ShouldBe("-1");
        val4.CastToString(3).ShouldBe("-1.111");

        val0.CastToString(3, "---").ShouldBe("0");
        val1.CastToString(3, "---").ShouldBe("1");
        val2.CastToString(3, "---").ShouldBe("1.111");
        val3.CastToString(3, "---").ShouldBe("-1");
        val4.CastToString(3, "---").ShouldBe("-1.111");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");
    }

    [Fact(DisplayName = "Convert nullable float value to string test")]
    public void NullableFloatConvertToStringTest()
    {
        float? val0 = 0;
        float? val1 = 1;
        float? val2 = 1.111F;
        float? val3 = -1;
        float? val4 = -1.111F;

        float? valA = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("1.11");
        val3.CastToString().ShouldBe("-1");
        val4.CastToString().ShouldBe("-1.11");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("1.11");
        val3.CastToString("---").ShouldBe("-1");
        val4.CastToString("---").ShouldBe("-1.11");

        val0.CastToString((float) 2.222).ShouldBe("0");
        val1.CastToString((float) 2.222).ShouldBe("1");
        val2.CastToString((float) 2.222).ShouldBe("1.11");
        val3.CastToString((float) 2.222).ShouldBe("-1");
        val4.CastToString((float) 2.222).ShouldBe("-1.11");

        val0.CastToString(3).ShouldBe("0");
        val1.CastToString(3).ShouldBe("1");
        val2.CastToString(3).ShouldBe("1.111");
        val3.CastToString(3).ShouldBe("-1");
        val4.CastToString(3).ShouldBe("-1.111");

        val0.CastToString(3, "---").ShouldBe("0");
        val1.CastToString(3, "---").ShouldBe("1");
        val2.CastToString(3, "---").ShouldBe("1.111");
        val3.CastToString(3, "---").ShouldBe("-1");
        val4.CastToString(3, "---").ShouldBe("-1.111");

        val0.CastToString(3, (float) 2.222).ShouldBe("0");
        val1.CastToString(3, (float) 2.222).ShouldBe("1");
        val2.CastToString(3, (float) 2.222).ShouldBe("1.111");
        val3.CastToString(3, (float) 2.222).ShouldBe("-1");
        val4.CastToString(3, (float) 2.222).ShouldBe("-1.111");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.22");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1.11");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.222");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1.111");

        valA.CastToString().ShouldBeEmpty();
        valA.CastToString("---").ShouldBe("---");
        valA.CastToString((float) 2.222).ShouldBe("2.22");

        valA.CastToString(3).ShouldBeEmpty();
        valA.CastToString(3, "---").ShouldBe("---");
        valA.CastToString(3, (float) 2.222).ShouldBe("2.222");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.22");

        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.222");
    }

    [Fact(DisplayName = "Convert nullable double value to string test")]
    public void NullableDoubleConvertToStringTest()
    {
        double? val0 = 0;
        double? val1 = 1;
        double? val2 = 1.111;
        double? val3 = -1;
        double? val4 = -1.111;

        double? valA = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("1.11");
        val3.CastToString().ShouldBe("-1");
        val4.CastToString().ShouldBe("-1.11");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("1.11");
        val3.CastToString("---").ShouldBe("-1");
        val4.CastToString("---").ShouldBe("-1.11");

        val0.CastToString((double) 2.222).ShouldBe("0");
        val1.CastToString((double) 2.222).ShouldBe("1");
        val2.CastToString((double) 2.222).ShouldBe("1.11");
        val3.CastToString((double) 2.222).ShouldBe("-1");
        val4.CastToString((double) 2.222).ShouldBe("-1.11");

        val0.CastToString(3).ShouldBe("0");
        val1.CastToString(3).ShouldBe("1");
        val2.CastToString(3).ShouldBe("1.111");
        val3.CastToString(3).ShouldBe("-1");
        val4.CastToString(3).ShouldBe("-1.111");

        val0.CastToString(3, "---").ShouldBe("0");
        val1.CastToString(3, "---").ShouldBe("1");
        val2.CastToString(3, "---").ShouldBe("1.111");
        val3.CastToString(3, "---").ShouldBe("-1");
        val4.CastToString(3, "---").ShouldBe("-1.111");

        val0.CastToString(3, (double) 2.222).ShouldBe("0");
        val1.CastToString(3, (double) 2.222).ShouldBe("1");
        val2.CastToString(3, (double) 2.222).ShouldBe("1.111");
        val3.CastToString(3, (double) 2.222).ShouldBe("-1");
        val4.CastToString(3, (double) 2.222).ShouldBe("-1.111");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.22");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1.11");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.222");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1.111");

        valA.CastToString().ShouldBeEmpty();
        valA.CastToString("---").ShouldBe("---");
        valA.CastToString((double) 2.222).ShouldBe("2.22");

        valA.CastToString(3).ShouldBeEmpty();
        valA.CastToString(3, "---").ShouldBe("---");
        valA.CastToString(3, (double) 2.222).ShouldBe("2.222");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.22");

        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.222");
    }

    [Fact(DisplayName = "Convert nullable decimal value to string test")]
    public void NullableDecimalConvertToStringTest()
    {
        decimal? val0 = 0;
        decimal? val1 = 1;
        decimal? val2 = (decimal) 1.111;
        decimal? val3 = -1;
        decimal? val4 = (decimal) -1.111;

        decimal? valA = null;

        val0.CastToString().ShouldBe("0");
        val1.CastToString().ShouldBe("1");
        val2.CastToString().ShouldBe("1.11");
        val3.CastToString().ShouldBe("-1");
        val4.CastToString().ShouldBe("-1.11");

        val0.CastToString("---").ShouldBe("0");
        val1.CastToString("---").ShouldBe("1");
        val2.CastToString("---").ShouldBe("1.11");
        val3.CastToString("---").ShouldBe("-1");
        val4.CastToString("---").ShouldBe("-1.11");

        val0.CastToString((decimal) 2.222).ShouldBe("0");
        val1.CastToString((decimal) 2.222).ShouldBe("1");
        val2.CastToString((decimal) 2.222).ShouldBe("1.11");
        val3.CastToString((decimal) 2.222).ShouldBe("-1");
        val4.CastToString((decimal) 2.222).ShouldBe("-1.11");

        val0.CastToString(3).ShouldBe("0");
        val1.CastToString(3).ShouldBe("1");
        val2.CastToString(3).ShouldBe("1.111");
        val3.CastToString(3).ShouldBe("-1");
        val4.CastToString(3).ShouldBe("-1.111");

        val0.CastToString(3, "---").ShouldBe("0");
        val1.CastToString(3, "---").ShouldBe("1");
        val2.CastToString(3, "---").ShouldBe("1.111");
        val3.CastToString(3, "---").ShouldBe("-1");
        val4.CastToString(3, "---").ShouldBe("-1.111");

        val0.CastToString(3, (decimal) 2.222).ShouldBe("0");
        val1.CastToString(3, (decimal) 2.222).ShouldBe("1");
        val2.CastToString(3, (decimal) 2.222).ShouldBe("1.111");
        val3.CastToString(3, (decimal) 2.222).ShouldBe("-1");
        val4.CastToString(3, (decimal) 2.222).ShouldBe("-1.111");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

        val0.CastToString(NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.22");
        val1.CastToString(NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1");
        val2.CastToString(NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1.11");
        val3.CastToString(NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1");
        val4.CastToString(NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1.11");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

        val0.CastToString(3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.222");
        val1.CastToString(3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1");
        val2.CastToString(3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1.111");
        val3.CastToString(3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1");
        val4.CastToString(3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1.111");

        valA.CastToString().ShouldBeEmpty();
        valA.CastToString("---").ShouldBe("---");
        valA.CastToString((decimal) 2.222).ShouldBe("2.22");

        valA.CastToString(3).ShouldBeEmpty();
        valA.CastToString(3, "---").ShouldBe("---");
        valA.CastToString(3, (decimal) 2.222).ShouldBe("2.222");

        valA.CastToString(NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valA.CastToString(NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valA.CastToString(NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.22");

        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
        valA.CastToString(3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.222");
    }
}