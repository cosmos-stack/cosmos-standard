using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.StrFromNumeric")]
    public class StringConvFromNumericTypeTests
    {
        [Fact(DisplayName = "Convert byte and sbyte value to string test")]
        public void ByteAndSByteConvertToStringTest()
        {
            byte val0 = 0;
            byte val1 = 1;
            sbyte val2 = -1;
            sbyte val3 = 0;
            sbyte val4 = 1;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        }

        [Fact(DisplayName = "Convert int16 and uint16 value to string test")]
        public void Int16AndUInt16ConvertToStringTest()
        {
            Int16 val0 = 0;
            Int16 val1 = 1;
            Int16 val2 = -1;
            UInt16 val3 = 0;
            UInt16 val4 = 1;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        }

        [Fact(DisplayName = "Convert int32 and uint32 value to string test")]
        public void Int32AndUInt32ConvertToStringTest()
        {
            Int32 val0 = 0;
            Int32 val1 = 1;
            Int32 val2 = -1;
            UInt32 val3 = 0;
            UInt32 val4 = 1;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
        }

        [Fact(DisplayName = "Convert int64 and uint64 value to string test")]
        public void Int64AndUInt64ConvertToStringTest()
        {
            Int64 val0 = 0;
            Int64 val1 = 1;
            Int64 val2 = -1;
            UInt64 val3 = 0;
            UInt64 val4 = 1;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, (byte) 2).ShouldBe("0");
            StringConv.ToString(val1, (byte) 2).ShouldBe("1");
            StringConv.ToString(val2, (sbyte) 2).ShouldBe("-1");
            StringConv.ToString(val3, (sbyte) 2).ShouldBe("0");
            StringConv.ToString(val4, (sbyte) 2).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (byte) 2).ShouldBe("2");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (byte) 2).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("2");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("1");

            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valB).ShouldBeEmpty();

            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valB, "---").ShouldBe("---");

            StringConv.ToString(valA, (byte) 2).ShouldBe("2");
            StringConv.ToString(valB, (sbyte) 2).ShouldBe("2");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (byte) 2).ShouldBe("2");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, (sbyte) 2).ShouldBe("2");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, (Int16) 2).ShouldBe("0");
            StringConv.ToString(val1, (Int16) 2).ShouldBe("1");
            StringConv.ToString(val2, (Int16) 2).ShouldBe("-1");
            StringConv.ToString(val3, (UInt16) 2).ShouldBe("0");
            StringConv.ToString(val4, (UInt16) 2).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("2");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (UInt16) 2).ShouldBe("2");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (UInt16) 2).ShouldBe("1");

            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valB).ShouldBeEmpty();

            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valB, "---").ShouldBe("---");

            StringConv.ToString(valA, (Int16) 2).ShouldBe("2");
            StringConv.ToString(valB, (UInt16) 2).ShouldBe("2");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (Int16) 2).ShouldBe("2");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, (UInt16) 2).ShouldBe("2");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, (Int32) 2).ShouldBe("0");
            StringConv.ToString(val1, (Int32) 2).ShouldBe("1");
            StringConv.ToString(val2, (Int32) 2).ShouldBe("-1");
            StringConv.ToString(val3, (UInt32) 2).ShouldBe("0");
            StringConv.ToString(val4, (UInt32) 2).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("2");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (UInt32) 2).ShouldBe("2");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (UInt32) 2).ShouldBe("1");

            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valB).ShouldBeEmpty();

            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valB, "---").ShouldBe("---");

            StringConv.ToString(valA, (Int32) 2).ShouldBe("2");
            StringConv.ToString(valB, (UInt32) 2).ShouldBe("2");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (Int32) 2).ShouldBe("2");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, (UInt32) 2).ShouldBe("2");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("-1");
            StringConv.ToString(val3).ShouldBe("0");
            StringConv.ToString(val4).ShouldBe("1");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("-1");
            StringConv.ToString(val3, "---").ShouldBe("0");
            StringConv.ToString(val4, "---").ShouldBe("1");

            StringConv.ToString(val0, (Int64) 2).ShouldBe("0");
            StringConv.ToString(val1, (Int64) 2).ShouldBe("1");
            StringConv.ToString(val2, (Int64) 2).ShouldBe("-1");
            StringConv.ToString(val3, (UInt64) 2).ShouldBe("0");
            StringConv.ToString(val4, (UInt64) 2).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("2");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("-1");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (UInt64) 2).ShouldBe("2");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (UInt64) 2).ShouldBe("1");

            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valB).ShouldBeEmpty();

            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valB, "---").ShouldBe("---");

            StringConv.ToString(valA, (Int64) 2).ShouldBe("2");
            StringConv.ToString(valB, (UInt64) 2).ShouldBe("2");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (Int64) 2).ShouldBe("2");
            StringConv.ToString(valB, NumericConvOptions.ZeroAsEmpty, (UInt64) 2).ShouldBe("2");
        }
        
        [Fact(DisplayName = "Convert float value to string test")]
        public void FloatConvertToStringTest()
        {
            float val0 = 0;
            float val1 = 1;
            float val2 = 1.111F;
            float val3 = -1;
            float val4 = -1.111F;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("1.11");
            StringConv.ToString(val3).ShouldBe("-1");
            StringConv.ToString(val4).ShouldBe("-1.11");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("1.11");
            StringConv.ToString(val3, "---").ShouldBe("-1");
            StringConv.ToString(val4, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, (float) 2.222).ShouldBe("0");
            StringConv.ToString(val1, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, (float) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, (float) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3).ShouldBe("0");
            StringConv.ToString(val1, 3).ShouldBe("1");
            StringConv.ToString(val2, 3).ShouldBe("1.111");
            StringConv.ToString(val3, 3).ShouldBe("-1");
            StringConv.ToString(val4, 3).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, "---").ShouldBe("0");
            StringConv.ToString(val1, 3, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, (float) 2.222).ShouldBe("0");
            StringConv.ToString(val1, 3, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, (float) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, (float) 2.222).ShouldBe("-1.111");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.22");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.222");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1.111");
        }

        [Fact(DisplayName = "Convert double value to string test")]
        public void DoubleConvertToStringTest()
        {
            double val0 = 0;
            double val1 = 1;
            double val2 = 1.111;
            double val3 = -1;
            double val4 = -1.111;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("1.11");
            StringConv.ToString(val3).ShouldBe("-1");
            StringConv.ToString(val4).ShouldBe("-1.11");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("1.11");
            StringConv.ToString(val3, "---").ShouldBe("-1");
            StringConv.ToString(val4, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, (double) 2.222).ShouldBe("0");
            StringConv.ToString(val1, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, (double) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, (double) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3).ShouldBe("0");
            StringConv.ToString(val1, 3).ShouldBe("1");
            StringConv.ToString(val2, 3).ShouldBe("1.111");
            StringConv.ToString(val3, 3).ShouldBe("-1");
            StringConv.ToString(val4, 3).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, "---").ShouldBe("0");
            StringConv.ToString(val1, 3, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, (double) 2.222).ShouldBe("0");
            StringConv.ToString(val1, 3, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, (double) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, (double) 2.222).ShouldBe("-1.111");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.22");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0.00");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.222");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1.111");
        }

        [Fact(DisplayName = "Convert decimal value to string test")]
        public void DecimalConvertToStringTest()
        {
            decimal val0 = 0;
            decimal val1 = 1;
            decimal val2 = (decimal) 1.111;
            decimal val3 = -1;
            decimal val4 = (decimal) -1.111;

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("1.11");
            StringConv.ToString(val3).ShouldBe("-1");
            StringConv.ToString(val4).ShouldBe("-1.11");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("1.11");
            StringConv.ToString(val3, "---").ShouldBe("-1");
            StringConv.ToString(val4, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, (decimal) 2.222).ShouldBe("0");
            StringConv.ToString(val1, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, (decimal) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, (decimal) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3).ShouldBe("0");
            StringConv.ToString(val1, 3).ShouldBe("1");
            StringConv.ToString(val2, 3).ShouldBe("1.111");
            StringConv.ToString(val3, 3).ShouldBe("-1");
            StringConv.ToString(val4, 3).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, "---").ShouldBe("0");
            StringConv.ToString(val1, 3, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, (decimal) 2.222).ShouldBe("0");
            StringConv.ToString(val1, 3, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, (decimal) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, (decimal) 2.222).ShouldBe("-1.111");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.22");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("0");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.222");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1.111");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("1.11");
            StringConv.ToString(val3).ShouldBe("-1");
            StringConv.ToString(val4).ShouldBe("-1.11");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("1.11");
            StringConv.ToString(val3, "---").ShouldBe("-1");
            StringConv.ToString(val4, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, (float) 2.222).ShouldBe("0");
            StringConv.ToString(val1, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, (float) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, (float) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3).ShouldBe("0");
            StringConv.ToString(val1, 3).ShouldBe("1");
            StringConv.ToString(val2, 3).ShouldBe("1.111");
            StringConv.ToString(val3, 3).ShouldBe("-1");
            StringConv.ToString(val4, 3).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, "---").ShouldBe("0");
            StringConv.ToString(val1, 3, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, (float) 2.222).ShouldBe("0");
            StringConv.ToString(val1, 3, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, (float) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, (float) 2.222).ShouldBe("-1.111");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.22");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.222");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("-1.111");
            
            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valA, (float) 2.222).ShouldBe("2.22");
            
            StringConv.ToString(valA, 3).ShouldBeEmpty();
            StringConv.ToString(valA, 3, "---").ShouldBe("---");
            StringConv.ToString(valA, 3, (float) 2.222).ShouldBe("2.222");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.22");

            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty, (float) 2.222).ShouldBe("2.222");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("1.11");
            StringConv.ToString(val3).ShouldBe("-1");
            StringConv.ToString(val4).ShouldBe("-1.11");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("1.11");
            StringConv.ToString(val3, "---").ShouldBe("-1");
            StringConv.ToString(val4, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, (double) 2.222).ShouldBe("0");
            StringConv.ToString(val1, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, (double) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, (double) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3).ShouldBe("0");
            StringConv.ToString(val1, 3).ShouldBe("1");
            StringConv.ToString(val2, 3).ShouldBe("1.111");
            StringConv.ToString(val3, 3).ShouldBe("-1");
            StringConv.ToString(val4, 3).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, "---").ShouldBe("0");
            StringConv.ToString(val1, 3, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, (double) 2.222).ShouldBe("0");
            StringConv.ToString(val1, 3, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, (double) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, (double) 2.222).ShouldBe("-1.111");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.22");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.222");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("-1.111");
            
            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valA, (double) 2.222).ShouldBe("2.22");
            
            StringConv.ToString(valA, 3).ShouldBeEmpty();
            StringConv.ToString(valA, 3, "---").ShouldBe("---");
            StringConv.ToString(valA, 3, (double) 2.222).ShouldBe("2.222");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.22");

            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty, (double) 2.222).ShouldBe("2.222");
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

            StringConv.ToString(val0).ShouldBe("0");
            StringConv.ToString(val1).ShouldBe("1");
            StringConv.ToString(val2).ShouldBe("1.11");
            StringConv.ToString(val3).ShouldBe("-1");
            StringConv.ToString(val4).ShouldBe("-1.11");

            StringConv.ToString(val0, "---").ShouldBe("0");
            StringConv.ToString(val1, "---").ShouldBe("1");
            StringConv.ToString(val2, "---").ShouldBe("1.11");
            StringConv.ToString(val3, "---").ShouldBe("-1");
            StringConv.ToString(val4, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, (decimal) 2.222).ShouldBe("0");
            StringConv.ToString(val1, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, (decimal) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, (decimal) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3).ShouldBe("0");
            StringConv.ToString(val1, 3).ShouldBe("1");
            StringConv.ToString(val2, 3).ShouldBe("1.111");
            StringConv.ToString(val3, 3).ShouldBe("-1");
            StringConv.ToString(val4, 3).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, "---").ShouldBe("0");
            StringConv.ToString(val1, 3, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, (decimal) 2.222).ShouldBe("0");
            StringConv.ToString(val1, 3, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, (decimal) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, (decimal) 2.222).ShouldBe("-1.111");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.11");

            StringConv.ToString(val0, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.22");
            StringConv.ToString(val1, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1.11");
            StringConv.ToString(val3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1.11");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty).ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("-1.111");

            StringConv.ToString(val0, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.222");
            StringConv.ToString(val1, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1");
            StringConv.ToString(val2, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("1.111");
            StringConv.ToString(val3, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1");
            StringConv.ToString(val4, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("-1.111");
            
            StringConv.ToString(valA).ShouldBeEmpty();
            StringConv.ToString(valA, "---").ShouldBe("---");
            StringConv.ToString(valA, (decimal) 2.222).ShouldBe("2.22");
            
            StringConv.ToString(valA, 3).ShouldBeEmpty();
            StringConv.ToString(valA, 3, "---").ShouldBe("---");
            StringConv.ToString(valA, 3, (decimal) 2.222).ShouldBe("2.222");

            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valA, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.22");

            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty).ShouldBeEmpty();
            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty, "---").ShouldBe("---");
            StringConv.ToString(valA, 3, NumericConvOptions.ZeroAsEmpty, (decimal) 2.222).ShouldBe("2.222");
        }
    }
}