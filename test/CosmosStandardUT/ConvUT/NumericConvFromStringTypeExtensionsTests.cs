using Cosmos.Text;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "NumericConv.NumericFromStr")]
    public class NumericConvFromStringTypeExtensionsTests
    {
        [Fact(DisplayName = "Convert string value to byte test")]
        public void StringValConvertToByteTest()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToByte().ShouldBe((byte) 0);
            val1.CastToByte().ShouldBe((byte) 1);
            val2.CastToByte().ShouldBe(default);
            val3.CastToByte().ShouldBe((byte) 1);
            val4.CastToByte().ShouldBe((byte) 0);
            val5.CastToByte().ShouldBe((byte) 0);
            valA.CastToByte().ShouldBe(default);
            valB.CastToByte().ShouldBe(default);
            ValC.CastToByte().ShouldBe(default);
            ValD.CastToByte().ShouldBe(default);

            val0.CastToByte((byte) 2).ShouldBe((byte) 0);
            val1.CastToByte((byte) 2).ShouldBe((byte) 1);
            val2.CastToByte((byte) 2).ShouldBe((byte) 2);
            val3.CastToByte((byte) 2).ShouldBe((byte) 1);
            val4.CastToByte((byte) 2).ShouldBe((byte) 0);
            val5.CastToByte((byte) 2).ShouldBe((byte) 0);
            valA.CastToByte((byte) 2).ShouldBe((byte) 2);
            valB.CastToByte((byte) 2).ShouldBe((byte) 2);
            ValC.CastToByte((byte) 2).ShouldBe((byte) 0);
            ValD.CastToByte((byte) 2).ShouldBe((byte) 2);
        }

        [Fact(DisplayName = "Convert string value to sbyte test")]
        public void StringValConvertToSByteTest()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToSByte().ShouldBe((sbyte) 0);
            val1.CastToSByte().ShouldBe((sbyte) 1);
            val2.CastToSByte().ShouldBe((sbyte) -1);
            val3.CastToSByte().ShouldBe((sbyte) 1);
            val4.CastToSByte().ShouldBe((sbyte) 0);
            val5.CastToSByte().ShouldBe((sbyte) 0);
            valA.CastToSByte().ShouldBe(default);
            valB.CastToSByte().ShouldBe(default);
            ValC.CastToSByte().ShouldBe(default);
            ValD.CastToSByte().ShouldBe(default);

            val0.CastToSByte((sbyte) 2).ShouldBe((sbyte) 0);
            val1.CastToSByte((sbyte) 2).ShouldBe((sbyte) 1);
            val2.CastToSByte((sbyte) 2).ShouldBe((sbyte) -1);
            val3.CastToSByte((sbyte) 2).ShouldBe((sbyte) 1);
            val4.CastToSByte((sbyte) 2).ShouldBe((sbyte) 0);
            val5.CastToSByte((sbyte) 2).ShouldBe((sbyte) 0);
            valA.CastToSByte((sbyte) 2).ShouldBe((sbyte) 2);
            valB.CastToSByte((sbyte) 2).ShouldBe((sbyte) 2);
            ValC.CastToSByte((sbyte) 2).ShouldBe((sbyte) 0);
            ValD.CastToSByte((sbyte) 2).ShouldBe((sbyte) 2);
        }

        [Fact(DisplayName = "Convert string value to int16 test")]
        public void StringValConvertToInt16Test()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToInt16().ShouldBe((short) 0);
            val1.CastToInt16().ShouldBe((short) 1);
            val2.CastToInt16().ShouldBe((short) -1);
            val3.CastToInt16().ShouldBe((short) 1);
            val4.CastToInt16().ShouldBe((short) 0);
            val5.CastToInt16().ShouldBe((short) 0);
            valA.CastToInt16().ShouldBe(default);
            valB.CastToInt16().ShouldBe(default);
            ValC.CastToInt16().ShouldBe(default);
            ValD.CastToInt16().ShouldBe(default);

            val0.CastToInt16((short) 2).ShouldBe((short) 0);
            val1.CastToInt16((short) 2).ShouldBe((short) 1);
            val2.CastToInt16((short) 2).ShouldBe((short) -1);
            val3.CastToInt16((short) 2).ShouldBe((short) 1);
            val4.CastToInt16((short) 2).ShouldBe((short) 0);
            val5.CastToInt16((short) 2).ShouldBe((short) 0);
            valA.CastToInt16((short) 2).ShouldBe((short) 2);
            valB.CastToInt16((short) 2).ShouldBe((short) 2);
            ValC.CastToInt16((short) 2).ShouldBe((short) 0);
            ValD.CastToInt16((short) 2).ShouldBe((short) 2);

            val0.CastToShort().ShouldBe((short) 0);
            val1.CastToShort().ShouldBe((short) 1);
            val2.CastToShort().ShouldBe((short) -1);
            val3.CastToShort().ShouldBe((short) 1);
            val4.CastToShort().ShouldBe((short) 0);
            val5.CastToShort().ShouldBe((short) 0);
            valA.CastToShort().ShouldBe(default);
            valB.CastToShort().ShouldBe(default);
            ValC.CastToShort().ShouldBe(default);
            ValD.CastToShort().ShouldBe(default);

            val0.CastToShort((short) 2).ShouldBe((short) 0);
            val1.CastToShort((short) 2).ShouldBe((short) 1);
            val2.CastToShort((short) 2).ShouldBe((short) -1);
            val3.CastToShort((short) 2).ShouldBe((short) 1);
            val4.CastToShort((short) 2).ShouldBe((short) 0);
            val5.CastToShort((short) 2).ShouldBe((short) 0);
            valA.CastToShort((short) 2).ShouldBe((short) 2);
            valB.CastToShort((short) 2).ShouldBe((short) 2);
            ValC.CastToShort((short) 2).ShouldBe((short) 0);
            ValD.CastToShort((short) 2).ShouldBe((short) 2);
        }

        [Fact(DisplayName = "Convert string value to uint16 test")]
        public void StringValConvertToUInt16Test()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToUInt16().ShouldBe((ushort) 0);
            val1.CastToUInt16().ShouldBe((ushort) 1);
            val2.CastToUInt16().ShouldBe((ushort) 0);
            val3.CastToUInt16().ShouldBe((ushort) 1);
            val4.CastToUInt16().ShouldBe((ushort) 0);
            val5.CastToUInt16().ShouldBe((ushort) 0);
            valA.CastToUInt16().ShouldBe(default);
            valB.CastToUInt16().ShouldBe(default);
            ValC.CastToUInt16().ShouldBe(default);
            ValD.CastToUInt16().ShouldBe(default);

            val0.CastToUInt16((ushort) 2).ShouldBe((ushort) 0);
            val1.CastToUInt16((ushort) 2).ShouldBe((ushort) 1);
            val2.CastToUInt16((ushort) 2).ShouldBe((ushort) 2);
            val3.CastToUInt16((ushort) 2).ShouldBe((ushort) 1);
            val4.CastToUInt16((ushort) 2).ShouldBe((ushort) 0);
            val5.CastToUInt16((ushort) 2).ShouldBe((ushort) 0);
            valA.CastToUInt16((ushort) 2).ShouldBe((ushort) 2);
            valB.CastToUInt16((ushort) 2).ShouldBe((ushort) 2);
            ValC.CastToUInt16((ushort) 2).ShouldBe((ushort) 0);
            ValD.CastToUInt16((ushort) 2).ShouldBe((ushort) 2);

            val0.CastToUShort().ShouldBe((ushort) 0);
            val1.CastToUShort().ShouldBe((ushort) 1);
            val2.CastToUShort().ShouldBe((ushort) 0);
            val3.CastToUShort().ShouldBe((ushort) 1);
            val4.CastToUShort().ShouldBe((ushort) 0);
            val5.CastToUShort().ShouldBe((ushort) 0);
            valA.CastToUShort().ShouldBe(default);
            valB.CastToUShort().ShouldBe(default);
            ValC.CastToUShort().ShouldBe(default);
            ValD.CastToUShort().ShouldBe(default);

            val0.CastToUShort((ushort) 2).ShouldBe((ushort) 0);
            val1.CastToUShort((ushort) 2).ShouldBe((ushort) 1);
            val2.CastToUShort((ushort) 2).ShouldBe((ushort) 2);
            val3.CastToUShort((ushort) 2).ShouldBe((ushort) 1);
            val4.CastToUShort((ushort) 2).ShouldBe((ushort) 0);
            val5.CastToUShort((ushort) 2).ShouldBe((ushort) 0);
            valA.CastToUShort((ushort) 2).ShouldBe((ushort) 2);
            valB.CastToUShort((ushort) 2).ShouldBe((ushort) 2);
            ValC.CastToUShort((ushort) 2).ShouldBe((ushort) 0);
            ValD.CastToUShort((ushort) 2).ShouldBe((ushort) 2);
        }

        [Fact(DisplayName = "Convert string value to int32 test")]
        public void StringValConvertToInt32Test()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToInt32().ShouldBe((int) 0);
            val1.CastToInt32().ShouldBe((int) 1);
            val2.CastToInt32().ShouldBe((int) -1);
            val3.CastToInt32().ShouldBe((int) 1);
            val4.CastToInt32().ShouldBe((int) 0);
            val5.CastToInt32().ShouldBe((int) 0);
            valA.CastToInt32().ShouldBe(default);
            valB.CastToInt32().ShouldBe(default);
            ValC.CastToInt32().ShouldBe(default);
            ValD.CastToInt32().ShouldBe(default);

            val0.CastToInt32((int) 2).ShouldBe((int) 0);
            val1.CastToInt32((int) 2).ShouldBe((int) 1);
            val2.CastToInt32((int) 2).ShouldBe((int) -1);
            val3.CastToInt32((int) 2).ShouldBe((int) 1);
            val4.CastToInt32((int) 2).ShouldBe((int) 0);
            val5.CastToInt32((int) 2).ShouldBe((int) 0);
            valA.CastToInt32((int) 2).ShouldBe((int) 2);
            valB.CastToInt32((int) 2).ShouldBe((int) 2);
            ValC.CastToInt32((int) 2).ShouldBe((int) 0);
            ValD.CastToInt32((int) 2).ShouldBe((int) 2);

            val0.CastToInt().ShouldBe((int) 0);
            val1.CastToInt().ShouldBe((int) 1);
            val2.CastToInt().ShouldBe((int) -1);
            val3.CastToInt().ShouldBe((int) 1);
            val4.CastToInt().ShouldBe((int) 0);
            val5.CastToInt().ShouldBe((int) 0);
            valA.CastToInt().ShouldBe(default);
            valB.CastToInt().ShouldBe(default);
            ValC.CastToInt().ShouldBe(default);
            ValD.CastToInt().ShouldBe(default);

            val0.CastToInt((int) 2).ShouldBe((int) 0);
            val1.CastToInt((int) 2).ShouldBe((int) 1);
            val2.CastToInt((int) 2).ShouldBe((int) -1);
            val3.CastToInt((int) 2).ShouldBe((int) 1);
            val4.CastToInt((int) 2).ShouldBe((int) 0);
            val5.CastToInt((int) 2).ShouldBe((int) 0);
            valA.CastToInt((int) 2).ShouldBe((int) 2);
            valB.CastToInt((int) 2).ShouldBe((int) 2);
            ValC.CastToInt((int) 2).ShouldBe((int) 0);
            ValD.CastToInt((int) 2).ShouldBe((int) 2);
        }

        [Fact(DisplayName = "Convert string value to uint32 test")]
        public void StringValConvertToUInt32Test()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToUInt32().ShouldBe((uint) 0);
            val1.CastToUInt32().ShouldBe((uint) 1);
            val2.CastToUInt32().ShouldBe((uint) 0);
            val3.CastToUInt32().ShouldBe((uint) 1);
            val4.CastToUInt32().ShouldBe((uint) 0);
            val5.CastToUInt32().ShouldBe((uint) 0);
            valA.CastToUInt32().ShouldBe(default);
            valB.CastToUInt32().ShouldBe(default);
            ValC.CastToUInt32().ShouldBe(default);
            ValD.CastToUInt32().ShouldBe(default);

            val0.CastToUInt32((uint) 2).ShouldBe((uint) 0);
            val1.CastToUInt32((uint) 2).ShouldBe((uint) 1);
            val2.CastToUInt32((uint) 2).ShouldBe((uint) 2);
            val3.CastToUInt32((uint) 2).ShouldBe((uint) 1);
            val4.CastToUInt32((uint) 2).ShouldBe((uint) 0);
            val5.CastToUInt32((uint) 2).ShouldBe((uint) 0);
            valA.CastToUInt32((uint) 2).ShouldBe((uint) 2);
            valB.CastToUInt32((uint) 2).ShouldBe((uint) 2);
            ValC.CastToUInt32((uint) 2).ShouldBe((uint) 0);
            ValD.CastToUInt32((uint) 2).ShouldBe((uint) 2);

            val0.CastToUInt().ShouldBe((uint) 0);
            val1.CastToUInt().ShouldBe((uint) 1);
            val2.CastToUInt().ShouldBe((uint) 0);
            val3.CastToUInt().ShouldBe((uint) 1);
            val4.CastToUInt().ShouldBe((uint) 0);
            val5.CastToUInt().ShouldBe((uint) 0);
            valA.CastToUInt().ShouldBe(default);
            valB.CastToUInt().ShouldBe(default);
            ValC.CastToUInt().ShouldBe(default);
            ValD.CastToUInt().ShouldBe(default);

            val0.CastToUInt((uint) 2).ShouldBe((uint) 0);
            val1.CastToUInt((uint) 2).ShouldBe((uint) 1);
            val2.CastToUInt((uint) 2).ShouldBe((uint) 2);
            val3.CastToUInt((uint) 2).ShouldBe((uint) 1);
            val4.CastToUInt((uint) 2).ShouldBe((uint) 0);
            val5.CastToUInt((uint) 2).ShouldBe((uint) 0);
            valA.CastToUInt((uint) 2).ShouldBe((uint) 2);
            valB.CastToUInt((uint) 2).ShouldBe((uint) 2);
            ValC.CastToUInt((uint) 2).ShouldBe((uint) 0);
            ValD.CastToUInt((uint) 2).ShouldBe((uint) 2);
        }

        [Fact(DisplayName = "Convert string value to int64 test")]
        public void StringValConvertToInt64Test()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToInt64().ShouldBe((long) 0);
            val1.CastToInt64().ShouldBe((long) 1);
            val2.CastToInt64().ShouldBe((long) -1);
            val3.CastToInt64().ShouldBe((long) 1);
            val4.CastToInt64().ShouldBe((long) 0);
            val5.CastToInt64().ShouldBe((long) 0);
            valA.CastToInt64().ShouldBe(default);
            valB.CastToInt64().ShouldBe(default);
            ValC.CastToInt64().ShouldBe(default);
            ValD.CastToInt64().ShouldBe(default);

            val0.CastToInt64((long) 2).ShouldBe((long) 0);
            val1.CastToInt64((long) 2).ShouldBe((long) 1);
            val2.CastToInt64((long) 2).ShouldBe((long) -1);
            val3.CastToInt64((long) 2).ShouldBe((long) 1);
            val4.CastToInt64((long) 2).ShouldBe((long) 0);
            val5.CastToInt64((long) 2).ShouldBe((long) 0);
            valA.CastToInt64((long) 2).ShouldBe((long) 2);
            valB.CastToInt64((long) 2).ShouldBe((long) 2);
            ValC.CastToInt64((long) 2).ShouldBe((long) 0);
            ValD.CastToInt64((long) 2).ShouldBe((long) 2);

            val0.CastToLong().ShouldBe((long) 0);
            val1.CastToLong().ShouldBe((long) 1);
            val2.CastToLong().ShouldBe((long) -1);
            val3.CastToLong().ShouldBe((long) 1);
            val4.CastToLong().ShouldBe((long) 0);
            val5.CastToLong().ShouldBe((long) 0);
            valA.CastToLong().ShouldBe(default);
            valB.CastToLong().ShouldBe(default);
            ValC.CastToLong().ShouldBe(default);
            ValD.CastToLong().ShouldBe(default);

            val0.CastToLong((long) 2).ShouldBe((long) 0);
            val1.CastToLong((long) 2).ShouldBe((long) 1);
            val2.CastToLong((long) 2).ShouldBe((long) -1);
            val3.CastToLong((long) 2).ShouldBe((long) 1);
            val4.CastToLong((long) 2).ShouldBe((long) 0);
            val5.CastToLong((long) 2).ShouldBe((long) 0);
            valA.CastToLong((long) 2).ShouldBe((long) 2);
            valB.CastToLong((long) 2).ShouldBe((long) 2);
            ValC.CastToLong((long) 2).ShouldBe((long) 0);
            ValD.CastToLong((long) 2).ShouldBe((long) 2);
        }

        [Fact(DisplayName = "Convert string value to uint64 test")]
        public void StringValConvertToUInt64Test()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";

            string valA = "";
            string valB = null;
            string ValC = "0.1";
            string ValD = "A";

            val0.CastToUInt64().ShouldBe((ulong) 0);
            val1.CastToUInt64().ShouldBe((ulong) 1);
            val2.CastToUInt64().ShouldBe((ulong) 0);
            val3.CastToUInt64().ShouldBe((ulong) 1);
            val4.CastToUInt64().ShouldBe((ulong) 0);
            val5.CastToUInt64().ShouldBe((ulong) 0);
            valA.CastToUInt64().ShouldBe(default);
            valB.CastToUInt64().ShouldBe(default);
            ValC.CastToUInt64().ShouldBe(default);
            ValD.CastToUInt64().ShouldBe(default);

            val0.CastToUInt64((ulong) 2).ShouldBe((ulong) 0);
            val1.CastToUInt64((ulong) 2).ShouldBe((ulong) 1);
            val2.CastToUInt64((ulong) 2).ShouldBe((ulong) 2);
            val3.CastToUInt64((ulong) 2).ShouldBe((ulong) 1);
            val4.CastToUInt64((ulong) 2).ShouldBe((ulong) 0);
            val5.CastToUInt64((ulong) 2).ShouldBe((ulong) 0);
            valA.CastToUInt64((ulong) 2).ShouldBe((ulong) 2);
            valB.CastToUInt64((ulong) 2).ShouldBe((ulong) 2);
            ValC.CastToUInt64((ulong) 2).ShouldBe((ulong) 0);
            ValD.CastToUInt64((ulong) 2).ShouldBe((ulong) 2);

            val0.CastToULong().ShouldBe((ulong) 0);
            val1.CastToULong().ShouldBe((ulong) 1);
            val2.CastToULong().ShouldBe((ulong) 0);
            val3.CastToULong().ShouldBe((ulong) 1);
            val4.CastToULong().ShouldBe((ulong) 0);
            val5.CastToULong().ShouldBe((ulong) 0);
            valA.CastToULong().ShouldBe(default);
            valB.CastToULong().ShouldBe(default);
            ValC.CastToULong().ShouldBe(default);
            ValD.CastToULong().ShouldBe(default);

            val0.CastToULong((ulong) 2).ShouldBe((ulong) 0);
            val1.CastToULong((ulong) 2).ShouldBe((ulong) 1);
            val2.CastToULong((ulong) 2).ShouldBe((ulong) 2);
            val3.CastToULong((ulong) 2).ShouldBe((ulong) 1);
            val4.CastToULong((ulong) 2).ShouldBe((ulong) 0);
            val5.CastToULong((ulong) 2).ShouldBe((ulong) 0);
            valA.CastToULong((ulong) 2).ShouldBe((ulong) 2);
            valB.CastToULong((ulong) 2).ShouldBe((ulong) 2);
            ValC.CastToULong((ulong) 2).ShouldBe((ulong) 0);
            ValD.CastToULong((ulong) 2).ShouldBe((ulong) 2);
        }

        [Fact(DisplayName = "Convert string value to float test")]
        public void StringValConvertToFloatTest()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";
            string val6 = "1.111";
            string val7 = "+1.111";
            string val8 = "-1.111";
            string val9 = "0.0";

            string valA = "";
            string valB = null;
            string ValC = "A";

            val0.CastToFloat().ShouldBe((float) 0);
            val1.CastToFloat().ShouldBe((float) 1);
            val2.CastToFloat().ShouldBe((float) -1);
            val3.CastToFloat().ShouldBe((float) 1);
            val4.CastToFloat().ShouldBe((float) 0);
            val5.CastToFloat().ShouldBe((float) 0);
            val6.CastToFloat().ShouldBe((float) 1.111);
            val7.CastToFloat().ShouldBe((float) 1.111);
            val8.CastToFloat().ShouldBe((float) -1.111);
            val9.CastToFloat().ShouldBe((float) 0);
            valA.CastToFloat().ShouldBe(default);
            valB.CastToFloat().ShouldBe(default);
            ValC.CastToFloat().ShouldBe(default);

            val0.CastToFloat((float) 2.222).ShouldBe((float) 0);
            val1.CastToFloat((float) 2.222).ShouldBe((float) 1);
            val2.CastToFloat((float) 2.222).ShouldBe((float) -1);
            val3.CastToFloat((float) 2.222).ShouldBe((float) 1);
            val4.CastToFloat((float) 2.222).ShouldBe((float) 0);
            val5.CastToFloat((float) 2.222).ShouldBe((float) 0);
            val6.CastToFloat((float) 2.222).ShouldBe((float) 1.111);
            val7.CastToFloat((float) 2.222).ShouldBe((float) 1.111);
            val8.CastToFloat((float) 2.222).ShouldBe((float) -1.111);
            val9.CastToFloat((float) 2.222).ShouldBe((float) 0);
            valA.CastToFloat((float) 2.222).ShouldBe((float) 2.222);
            valB.CastToFloat((float) 2.222).ShouldBe((float) 2.222);
            ValC.CastToFloat((float) 2.222).ShouldBe((float) 2.222);
        }

        [Fact(DisplayName = "Convert string value to double test")]
        public void StringValConvertToDoubleTest()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";
            string val6 = "1.111";
            string val7 = "+1.111";
            string val8 = "-1.111";
            string val9 = "0.0";

            string valA = "";
            string valB = null;
            string ValC = "A";

            val0.CastToDouble().ShouldBe((double) 0);
            val1.CastToDouble().ShouldBe((double) 1);
            val2.CastToDouble().ShouldBe((double) -1);
            val3.CastToDouble().ShouldBe((double) 1);
            val4.CastToDouble().ShouldBe((double) 0);
            val5.CastToDouble().ShouldBe((double) 0);
            val6.CastToDouble().ShouldBe((double) 1.111);
            val7.CastToDouble().ShouldBe((double) 1.111);
            val8.CastToDouble().ShouldBe((double) -1.111);
            val9.CastToDouble().ShouldBe((double) 0);
            valA.CastToDouble().ShouldBe(default);
            valB.CastToDouble().ShouldBe(default);
            ValC.CastToDouble().ShouldBe(default);

            val0.CastToDouble((double) 2.222).ShouldBe((double) 0);
            val1.CastToDouble((double) 2.222).ShouldBe((double) 1);
            val2.CastToDouble((double) 2.222).ShouldBe((double) -1);
            val3.CastToDouble((double) 2.222).ShouldBe((double) 1);
            val4.CastToDouble((double) 2.222).ShouldBe((double) 0);
            val5.CastToDouble((double) 2.222).ShouldBe((double) 0);
            val6.CastToDouble((double) 2.222).ShouldBe((double) 1.111);
            val7.CastToDouble((double) 2.222).ShouldBe((double) 1.111);
            val8.CastToDouble((double) 2.222).ShouldBe((double) -1.111);
            val9.CastToDouble((double) 2.222).ShouldBe((double) 0);
            valA.CastToDouble((double) 2.222).ShouldBe((double) 2.222);
            valB.CastToDouble((double) 2.222).ShouldBe((double) 2.222);
            ValC.CastToDouble((double) 2.222).ShouldBe((double) 2.222);
        }

        [Fact(DisplayName = "Convert string value to decimal test")]
        public void StringValConvertToDecimalTest()
        {
            string val0 = "0";
            string val1 = "1";
            string val2 = "-1";
            string val3 = "+1";
            string val4 = "+0";
            string val5 = "-0";
            string val6 = "1.111";
            string val7 = "+1.111";
            string val8 = "-1.111";
            string val9 = "0.0";

            string valA = "";
            string valB = null;
            string ValC = "A";

            val0.CastToDecimal().ShouldBe((decimal) 0);
            val1.CastToDecimal().ShouldBe((decimal) 1);
            val2.CastToDecimal().ShouldBe((decimal) -1);
            val3.CastToDecimal().ShouldBe((decimal) 1);
            val4.CastToDecimal().ShouldBe((decimal) 0);
            val5.CastToDecimal().ShouldBe((decimal) 0);
            val6.CastToDecimal().ShouldBe((decimal) 1.111);
            val7.CastToDecimal().ShouldBe((decimal) 1.111);
            val8.CastToDecimal().ShouldBe((decimal) -1.111);
            val9.CastToDecimal().ShouldBe((decimal) 0);
            valA.CastToDecimal().ShouldBe(default);
            valB.CastToDecimal().ShouldBe(default);
            ValC.CastToDecimal().ShouldBe(default);

            val0.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 0);
            val1.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 1);
            val2.CastToDecimal((decimal) 2.222).ShouldBe((decimal) -1);
            val3.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 1);
            val4.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 0);
            val5.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 0);
            val6.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 1.111);
            val7.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 1.111);
            val8.CastToDecimal((decimal) 2.222).ShouldBe((decimal) -1.111);
            val9.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 0);
            valA.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 2.222);
            valB.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 2.222);
            ValC.CastToDecimal((decimal) 2.222).ShouldBe((decimal) 2.222);
        }
    }
}