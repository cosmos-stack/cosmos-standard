using CosmosStack.Numeric;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "NumericConv.NumericFromStr")]
    public class NumericConvFromStringTypeTests
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

            NumericConv.ToByte(val0).ShouldBe((byte) 0);
            NumericConv.ToByte(val1).ShouldBe((byte) 1);
            NumericConv.ToByte(val2).ShouldBe(default);
            NumericConv.ToByte(val3).ShouldBe((byte) 1);
            NumericConv.ToByte(val4).ShouldBe((byte) 0);
            NumericConv.ToByte(val5).ShouldBe((byte) 0);
            NumericConv.ToByte(valA).ShouldBe(default);
            NumericConv.ToByte(valB).ShouldBe(default);
            NumericConv.ToByte(ValC).ShouldBe(default);
            NumericConv.ToByte(ValD).ShouldBe(default);

            NumericConv.ToByte(val0, (byte) 2).ShouldBe((byte) 0);
            NumericConv.ToByte(val1, (byte) 2).ShouldBe((byte) 1);
            NumericConv.ToByte(val2, (byte) 2).ShouldBe((byte) 2);
            NumericConv.ToByte(val3, (byte) 2).ShouldBe((byte) 1);
            NumericConv.ToByte(val4, (byte) 2).ShouldBe((byte) 0);
            NumericConv.ToByte(val5, (byte) 2).ShouldBe((byte) 0);
            NumericConv.ToByte(valA, (byte) 2).ShouldBe((byte) 2);
            NumericConv.ToByte(valB, (byte) 2).ShouldBe((byte) 2);
            NumericConv.ToByte(ValC, (byte) 2).ShouldBe((byte) 0);
            NumericConv.ToByte(ValD, (byte) 2).ShouldBe((byte) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable byte test")]
        public void StringValConvertToNullableByteTest()
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

            NumericConv.ToNullableByte(val0).ShouldBe((byte) 0);
            NumericConv.ToNullableByte(val1).ShouldBe((byte) 1);
            NumericConv.ToNullableByte(val2).ShouldBeNull();
            NumericConv.ToNullableByte(val3).ShouldBe((byte) 1);
            NumericConv.ToNullableByte(val4).ShouldBe((byte) 0);
            NumericConv.ToNullableByte(val5).ShouldBe((byte) 0);
            NumericConv.ToNullableByte(valA).ShouldBeNull();
            NumericConv.ToNullableByte(valB).ShouldBeNull();
            NumericConv.ToNullableByte(ValC).ShouldBeNull();
            NumericConv.ToNullableByte(ValD).ShouldBeNull();
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

            NumericConv.ToSByte(val0).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(val1).ShouldBe((sbyte) 1);
            NumericConv.ToSByte(val2).ShouldBe((sbyte) -1);
            NumericConv.ToSByte(val3).ShouldBe((sbyte) 1);
            NumericConv.ToSByte(val4).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(val5).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(valA).ShouldBe(default);
            NumericConv.ToSByte(valB).ShouldBe(default);
            NumericConv.ToSByte(ValC).ShouldBe(default);
            NumericConv.ToSByte(ValD).ShouldBe(default);

            NumericConv.ToSByte(val0, (sbyte) 2).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(val1, (sbyte) 2).ShouldBe((sbyte) 1);
            NumericConv.ToSByte(val2, (sbyte) 2).ShouldBe((sbyte) -1);
            NumericConv.ToSByte(val3, (sbyte) 2).ShouldBe((sbyte) 1);
            NumericConv.ToSByte(val4, (sbyte) 2).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(val5, (sbyte) 2).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(valA, (sbyte) 2).ShouldBe((sbyte) 2);
            NumericConv.ToSByte(valB, (sbyte) 2).ShouldBe((sbyte) 2);
            NumericConv.ToSByte(ValC, (sbyte) 2).ShouldBe((sbyte) 0);
            NumericConv.ToSByte(ValD, (sbyte) 2).ShouldBe((sbyte) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable sbyte test")]
        public void StringValConvertToNullableSByteTest()
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

            NumericConv.ToNullableSByte(val0).ShouldBe((sbyte) 0);
            NumericConv.ToNullableSByte(val1).ShouldBe((sbyte) 1);
            NumericConv.ToNullableSByte(val2).ShouldBe((sbyte) -1);
            NumericConv.ToNullableSByte(val3).ShouldBe((sbyte) 1);
            NumericConv.ToNullableSByte(val4).ShouldBe((sbyte) 0);
            NumericConv.ToNullableSByte(val5).ShouldBe((sbyte) 0);
            NumericConv.ToNullableSByte(valA).ShouldBeNull();
            NumericConv.ToNullableSByte(valB).ShouldBeNull();
            NumericConv.ToNullableSByte(ValC).ShouldBeNull();
            NumericConv.ToNullableSByte(ValD).ShouldBeNull();
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

            NumericConv.ToInt16(val0).ShouldBe((short) 0);
            NumericConv.ToInt16(val1).ShouldBe((short) 1);
            NumericConv.ToInt16(val2).ShouldBe((short) -1);
            NumericConv.ToInt16(val3).ShouldBe((short) 1);
            NumericConv.ToInt16(val4).ShouldBe((short) 0);
            NumericConv.ToInt16(val5).ShouldBe((short) 0);
            NumericConv.ToInt16(valA).ShouldBe(default);
            NumericConv.ToInt16(valB).ShouldBe(default);
            NumericConv.ToInt16(ValC).ShouldBe(default);
            NumericConv.ToInt16(ValD).ShouldBe(default);

            NumericConv.ToInt16(val0, (short) 2).ShouldBe((short) 0);
            NumericConv.ToInt16(val1, (short) 2).ShouldBe((short) 1);
            NumericConv.ToInt16(val2, (short) 2).ShouldBe((short) -1);
            NumericConv.ToInt16(val3, (short) 2).ShouldBe((short) 1);
            NumericConv.ToInt16(val4, (short) 2).ShouldBe((short) 0);
            NumericConv.ToInt16(val5, (short) 2).ShouldBe((short) 0);
            NumericConv.ToInt16(valA, (short) 2).ShouldBe((short) 2);
            NumericConv.ToInt16(valB, (short) 2).ShouldBe((short) 2);
            NumericConv.ToInt16(ValC, (short) 2).ShouldBe((short) 0);
            NumericConv.ToInt16(ValD, (short) 2).ShouldBe((short) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable int16 test")]
        public void StringValConvertToNullableInt16Test()
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

            NumericConv.ToNullableInt16(val0).ShouldBe((short) 0);
            NumericConv.ToNullableInt16(val1).ShouldBe((short) 1);
            NumericConv.ToNullableInt16(val2).ShouldBe((short) -1);
            NumericConv.ToNullableInt16(val3).ShouldBe((short) 1);
            NumericConv.ToNullableInt16(val4).ShouldBe((short) 0);
            NumericConv.ToNullableInt16(val5).ShouldBe((short) 0);
            NumericConv.ToNullableInt16(valA).ShouldBeNull();
            NumericConv.ToNullableInt16(valB).ShouldBeNull();
            NumericConv.ToNullableInt16(ValC).ShouldBeNull();
            NumericConv.ToNullableInt16(ValD).ShouldBeNull();
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

            NumericConv.ToUInt16(val0).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(val1).ShouldBe((ushort) 1);
            NumericConv.ToUInt16(val2).ShouldBe(default);
            NumericConv.ToUInt16(val3).ShouldBe((ushort) 1);
            NumericConv.ToUInt16(val4).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(val5).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(valA).ShouldBe(default);
            NumericConv.ToUInt16(valB).ShouldBe(default);
            NumericConv.ToUInt16(ValC).ShouldBe(default);
            NumericConv.ToUInt16(ValD).ShouldBe(default);

            NumericConv.ToUInt16(val0, (ushort) 2).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(val1, (ushort) 2).ShouldBe((ushort) 1);
            NumericConv.ToUInt16(val2, (ushort) 2).ShouldBe((ushort) 2);
            NumericConv.ToUInt16(val3, (ushort) 2).ShouldBe((ushort) 1);
            NumericConv.ToUInt16(val4, (ushort) 2).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(val5, (ushort) 2).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(valA, (ushort) 2).ShouldBe((ushort) 2);
            NumericConv.ToUInt16(valB, (ushort) 2).ShouldBe((ushort) 2);
            NumericConv.ToUInt16(ValC, (ushort) 2).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(ValD, (ushort) 2).ShouldBe((ushort) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable uint16 test")]
        public void StringValConvertToNullableUInt16Test()
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

            NumericConv.ToNullableUInt16(val0).ShouldBe((ushort) 0);
            NumericConv.ToNullableUInt16(val1).ShouldBe((ushort) 1);
            NumericConv.ToNullableUInt16(val2).ShouldBeNull();
            NumericConv.ToNullableUInt16(val3).ShouldBe((ushort) 1);
            NumericConv.ToNullableUInt16(val4).ShouldBe((ushort) 0);
            NumericConv.ToNullableUInt16(val5).ShouldBe((ushort) 0);
            NumericConv.ToNullableUInt16(valA).ShouldBeNull();
            NumericConv.ToNullableUInt16(valB).ShouldBeNull();
            NumericConv.ToNullableUInt16(ValC).ShouldBeNull();
            NumericConv.ToNullableUInt16(ValD).ShouldBeNull();
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

            NumericConv.ToInt32(val0).ShouldBe((int) 0);
            NumericConv.ToInt32(val1).ShouldBe((int) 1);
            NumericConv.ToInt32(val2).ShouldBe((int) -1);
            NumericConv.ToInt32(val3).ShouldBe((int) 1);
            NumericConv.ToInt32(val4).ShouldBe((int) 0);
            NumericConv.ToInt32(val5).ShouldBe((int) 0);
            NumericConv.ToInt32(valA).ShouldBe(default);
            NumericConv.ToInt32(valB).ShouldBe(default);
            NumericConv.ToInt32(ValC).ShouldBe(default);
            NumericConv.ToInt32(ValD).ShouldBe(default);

            NumericConv.ToInt32(val0, (int) 2).ShouldBe((int) 0);
            NumericConv.ToInt32(val1, (int) 2).ShouldBe((int) 1);
            NumericConv.ToInt32(val2, (int) 2).ShouldBe((int) -1);
            NumericConv.ToInt32(val3, (int) 2).ShouldBe((int) 1);
            NumericConv.ToInt32(val4, (int) 2).ShouldBe((int) 0);
            NumericConv.ToInt32(val5, (int) 2).ShouldBe((int) 0);
            NumericConv.ToInt32(valA, (int) 2).ShouldBe((int) 2);
            NumericConv.ToInt32(valB, (int) 2).ShouldBe((int) 2);
            NumericConv.ToInt32(ValC, (int) 2).ShouldBe((int) 0);
            NumericConv.ToInt32(ValD, (int) 2).ShouldBe((int) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable int32 test")]
        public void StringValConvertToNullableInt32Test()
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

            NumericConv.ToNullableInt32(val0).ShouldBe((int) 0);
            NumericConv.ToNullableInt32(val1).ShouldBe((int) 1);
            NumericConv.ToNullableInt32(val2).ShouldBe((int) -1);
            NumericConv.ToNullableInt32(val3).ShouldBe((int) 1);
            NumericConv.ToNullableInt32(val4).ShouldBe((int) 0);
            NumericConv.ToNullableInt32(val5).ShouldBe((int) 0);
            NumericConv.ToNullableInt32(valA).ShouldBeNull();
            NumericConv.ToNullableInt32(valB).ShouldBeNull();
            NumericConv.ToNullableInt32(ValC).ShouldBeNull();
            NumericConv.ToNullableInt32(ValD).ShouldBeNull();
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

            NumericConv.ToUInt32(val0).ShouldBe((uint) 0);
            NumericConv.ToUInt32(val1).ShouldBe((uint) 1);
            NumericConv.ToUInt32(val2).ShouldBe(default);
            NumericConv.ToUInt32(val3).ShouldBe((uint) 1);
            NumericConv.ToUInt32(val4).ShouldBe((uint) 0);
            NumericConv.ToUInt32(val5).ShouldBe((uint) 0);
            NumericConv.ToUInt32(valA).ShouldBe(default);
            NumericConv.ToUInt32(valB).ShouldBe(default);
            NumericConv.ToUInt32(ValC).ShouldBe(default);
            NumericConv.ToUInt32(ValD).ShouldBe(default);

            NumericConv.ToUInt32(val0, (uint) 2).ShouldBe((uint) 0);
            NumericConv.ToUInt32(val1, (uint) 2).ShouldBe((uint) 1);
            NumericConv.ToUInt32(val2, (uint) 2).ShouldBe((uint) 2);
            NumericConv.ToUInt32(val3, (uint) 2).ShouldBe((uint) 1);
            NumericConv.ToUInt32(val4, (uint) 2).ShouldBe((uint) 0);
            NumericConv.ToUInt32(val5, (uint) 2).ShouldBe((uint) 0);
            NumericConv.ToUInt32(valA, (uint) 2).ShouldBe((uint) 2);
            NumericConv.ToUInt32(valB, (uint) 2).ShouldBe((uint) 2);
            NumericConv.ToUInt32(ValC, (uint) 2).ShouldBe((uint) 0);
            NumericConv.ToUInt32(ValD, (uint) 2).ShouldBe((uint) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable uint32 test")]
        public void StringValConvertToNullableUInt32Test()
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

            NumericConv.ToNullableUInt32(val0).ShouldBe((uint) 0);
            NumericConv.ToNullableUInt32(val1).ShouldBe((uint) 1);
            NumericConv.ToNullableUInt32(val2).ShouldBeNull();
            NumericConv.ToNullableUInt32(val3).ShouldBe((uint) 1);
            NumericConv.ToNullableUInt32(val4).ShouldBe((uint) 0);
            NumericConv.ToNullableUInt32(val5).ShouldBe((uint) 0);
            NumericConv.ToNullableUInt32(valA).ShouldBeNull();
            NumericConv.ToNullableUInt32(valB).ShouldBeNull();
            NumericConv.ToNullableUInt32(ValC).ShouldBeNull();
            NumericConv.ToNullableUInt32(ValD).ShouldBeNull();
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

            NumericConv.ToInt64(val0).ShouldBe((long) 0);
            NumericConv.ToInt64(val1).ShouldBe((long) 1);
            NumericConv.ToInt64(val2).ShouldBe((long) -1);
            NumericConv.ToInt64(val3).ShouldBe((long) 1);
            NumericConv.ToInt64(val4).ShouldBe((long) 0);
            NumericConv.ToInt64(val5).ShouldBe((long) 0);
            NumericConv.ToInt64(valA).ShouldBe(default);
            NumericConv.ToInt64(valB).ShouldBe(default);
            NumericConv.ToInt64(ValC).ShouldBe(default);
            NumericConv.ToInt64(ValD).ShouldBe(default);

            NumericConv.ToInt64(val0, (long) 2).ShouldBe((long) 0);
            NumericConv.ToInt64(val1, (long) 2).ShouldBe((long) 1);
            NumericConv.ToInt64(val2, (long) 2).ShouldBe((long) -1);
            NumericConv.ToInt64(val3, (long) 2).ShouldBe((long) 1);
            NumericConv.ToInt64(val4, (long) 2).ShouldBe((long) 0);
            NumericConv.ToInt64(val5, (long) 2).ShouldBe((long) 0);
            NumericConv.ToInt64(valA, (long) 2).ShouldBe((long) 2);
            NumericConv.ToInt64(valB, (long) 2).ShouldBe((long) 2);
            NumericConv.ToInt64(ValC, (long) 2).ShouldBe((long) 0);
            NumericConv.ToInt64(ValD, (long) 2).ShouldBe((long) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable int64 test")]
        public void StringValConvertToNullableInt64Test()
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

            NumericConv.ToNullableInt64(val0).ShouldBe((long) 0);
            NumericConv.ToNullableInt64(val1).ShouldBe((long) 1);
            NumericConv.ToNullableInt64(val2).ShouldBe((long) -1);
            NumericConv.ToNullableInt64(val3).ShouldBe((long) 1);
            NumericConv.ToNullableInt64(val4).ShouldBe((long) 0);
            NumericConv.ToNullableInt64(val5).ShouldBe((long) 0);
            NumericConv.ToNullableInt64(valA).ShouldBeNull();
            NumericConv.ToNullableInt64(valB).ShouldBeNull();
            NumericConv.ToNullableInt64(ValC).ShouldBeNull();
            NumericConv.ToNullableInt64(ValD).ShouldBeNull();
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

            NumericConv.ToUInt64(val0).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(val1).ShouldBe((ulong) 1);
            NumericConv.ToUInt64(val2).ShouldBe(default);
            NumericConv.ToUInt64(val3).ShouldBe((ulong) 1);
            NumericConv.ToUInt64(val4).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(val5).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(valA).ShouldBe(default);
            NumericConv.ToUInt64(valB).ShouldBe(default);
            NumericConv.ToUInt64(ValC).ShouldBe(default);
            NumericConv.ToUInt64(ValD).ShouldBe(default);

            NumericConv.ToUInt64(val0, (ulong) 2).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(val1, (ulong) 2).ShouldBe((ulong) 1);
            NumericConv.ToUInt64(val2, (ulong) 2).ShouldBe((ulong) 2);
            NumericConv.ToUInt64(val3, (ulong) 2).ShouldBe((ulong) 1);
            NumericConv.ToUInt64(val4, (ulong) 2).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(val5, (ulong) 2).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(valA, (ulong) 2).ShouldBe((ulong) 2);
            NumericConv.ToUInt64(valB, (ulong) 2).ShouldBe((ulong) 2);
            NumericConv.ToUInt64(ValC, (ulong) 2).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(ValD, (ulong) 2).ShouldBe((ulong) 2);
        }

        [Fact(DisplayName = "Convert string value to nullable uint64 test")]
        public void StringValConvertToNullableUInt64Test()
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

            NumericConv.ToNullableUInt64(val0).ShouldBe((ulong) 0);
            NumericConv.ToNullableUInt64(val1).ShouldBe((ulong) 1);
            NumericConv.ToNullableUInt64(val2).ShouldBeNull();
            NumericConv.ToNullableUInt64(val3).ShouldBe((ulong) 1);
            NumericConv.ToNullableUInt64(val4).ShouldBe((ulong) 0);
            NumericConv.ToNullableUInt64(val5).ShouldBe((ulong) 0);
            NumericConv.ToNullableUInt64(valA).ShouldBeNull();
            NumericConv.ToNullableUInt64(valB).ShouldBeNull();
            NumericConv.ToNullableUInt64(ValC).ShouldBeNull();
            NumericConv.ToNullableUInt64(ValD).ShouldBeNull();
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

            NumericConv.ToFloat(val0).ShouldBe((float) 0);
            NumericConv.ToFloat(val1).ShouldBe((float) 1);
            NumericConv.ToFloat(val2).ShouldBe((float) -1);
            NumericConv.ToFloat(val3).ShouldBe((float) 1);
            NumericConv.ToFloat(val4).ShouldBe((float) 0);
            NumericConv.ToFloat(val5).ShouldBe((float) 0);
            NumericConv.ToFloat(val6).ShouldBe((float) 1.111);
            NumericConv.ToFloat(val7).ShouldBe((float) 1.111);
            NumericConv.ToFloat(val8).ShouldBe((float) -1.111);
            NumericConv.ToFloat(val9).ShouldBe((float) 0);
            NumericConv.ToFloat(valA).ShouldBe(default);
            NumericConv.ToFloat(valB).ShouldBe(default);
            NumericConv.ToFloat(ValC).ShouldBe(default);

            NumericConv.ToFloat(val0, (float) 2.222).ShouldBe((float) 0);
            NumericConv.ToFloat(val1, (float) 2.222).ShouldBe((float) 1);
            NumericConv.ToFloat(val2, (float) 2.222).ShouldBe((float) -1);
            NumericConv.ToFloat(val3, (float) 2.222).ShouldBe((float) 1);
            NumericConv.ToFloat(val4, (float) 2.222).ShouldBe((float) 0);
            NumericConv.ToFloat(val5, (float) 2.222).ShouldBe((float) 0);
            NumericConv.ToFloat(val6, (float) 2.222).ShouldBe((float) 1.111);
            NumericConv.ToFloat(val7, (float) 2.222).ShouldBe((float) 1.111);
            NumericConv.ToFloat(val8, (float) 2.222).ShouldBe((float) -1.111);
            NumericConv.ToFloat(val9, (float) 2.222).ShouldBe((float) 0);
            NumericConv.ToFloat(valA, (float) 2.222).ShouldBe((float) 2.222);
            NumericConv.ToFloat(valB, (float) 2.222).ShouldBe((float) 2.222);
            NumericConv.ToFloat(ValC, (float) 2.222).ShouldBe((float) 2.222);
        }

        [Fact(DisplayName = "Convert string value to nullable float test")]
        public void StringValConvertToNullableFloatTest()
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

            NumericConv.ToNullableFloat(val0).ShouldBe((float) 0);
            NumericConv.ToNullableFloat(val1).ShouldBe((float) 1);
            NumericConv.ToNullableFloat(val2).ShouldBe((float) -1);
            NumericConv.ToNullableFloat(val3).ShouldBe((float) 1);
            NumericConv.ToNullableFloat(val4).ShouldBe((float) 0);
            NumericConv.ToNullableFloat(val5).ShouldBe((float) 0);
            NumericConv.ToNullableFloat(val6).ShouldBe((float) 1.111);
            NumericConv.ToNullableFloat(val7).ShouldBe((float) 1.111);
            NumericConv.ToNullableFloat(val8).ShouldBe((float) -1.111);
            NumericConv.ToNullableFloat(val9).ShouldBe((float) 0);
            NumericConv.ToNullableFloat(valA).ShouldBeNull();
            NumericConv.ToNullableFloat(valB).ShouldBeNull();
            NumericConv.ToNullableFloat(ValC).ShouldBeNull();
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

            NumericConv.ToDouble(val0).ShouldBe((double) 0);
            NumericConv.ToDouble(val1).ShouldBe((double) 1);
            NumericConv.ToDouble(val2).ShouldBe((double) -1);
            NumericConv.ToDouble(val3).ShouldBe((double) 1);
            NumericConv.ToDouble(val4).ShouldBe((double) 0);
            NumericConv.ToDouble(val5).ShouldBe((double) 0);
            NumericConv.ToDouble(val6).ShouldBe((double) 1.111);
            NumericConv.ToDouble(val7).ShouldBe((double) 1.111);
            NumericConv.ToDouble(val8).ShouldBe((double) -1.111);
            NumericConv.ToDouble(val9).ShouldBe((double) 0);
            NumericConv.ToDouble(valA).ShouldBe(default);
            NumericConv.ToDouble(valB).ShouldBe(default);
            NumericConv.ToDouble(ValC).ShouldBe(default);

            NumericConv.ToDouble(val0, (double) 2.222).ShouldBe((double) 0);
            NumericConv.ToDouble(val1, (double) 2.222).ShouldBe((double) 1);
            NumericConv.ToDouble(val2, (double) 2.222).ShouldBe((double) -1);
            NumericConv.ToDouble(val3, (double) 2.222).ShouldBe((double) 1);
            NumericConv.ToDouble(val4, (double) 2.222).ShouldBe((double) 0);
            NumericConv.ToDouble(val5, (double) 2.222).ShouldBe((double) 0);
            NumericConv.ToDouble(val6, (double) 2.222).ShouldBe((double) 1.111);
            NumericConv.ToDouble(val7, (double) 2.222).ShouldBe((double) 1.111);
            NumericConv.ToDouble(val8, (double) 2.222).ShouldBe((double) -1.111);
            NumericConv.ToDouble(val9, (double) 2.222).ShouldBe((double) 0);
            NumericConv.ToDouble(valA, (double) 2.222).ShouldBe((double) 2.222);
            NumericConv.ToDouble(valB, (double) 2.222).ShouldBe((double) 2.222);
            NumericConv.ToDouble(ValC, (double) 2.222).ShouldBe((double) 2.222);
        }

        [Fact(DisplayName = "Convert string value to nullable double test")]
        public void StringValConvertToNullableDoubleTest()
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

            NumericConv.ToNullableDouble(val0).ShouldBe((double) 0);
            NumericConv.ToNullableDouble(val1).ShouldBe((double) 1);
            NumericConv.ToNullableDouble(val2).ShouldBe((double) -1);
            NumericConv.ToNullableDouble(val3).ShouldBe((double) 1);
            NumericConv.ToNullableDouble(val4).ShouldBe((double) 0);
            NumericConv.ToNullableDouble(val5).ShouldBe((double) 0);
            NumericConv.ToNullableDouble(val6).ShouldBe((double) 1.111);
            NumericConv.ToNullableDouble(val7).ShouldBe((double) 1.111);
            NumericConv.ToNullableDouble(val8).ShouldBe((double) -1.111);
            NumericConv.ToNullableDouble(val9).ShouldBe((double) 0);
            NumericConv.ToNullableDouble(valA).ShouldBeNull();
            NumericConv.ToNullableDouble(valB).ShouldBeNull();
            NumericConv.ToNullableDouble(ValC).ShouldBeNull();
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

            NumericConv.ToDecimal(val0).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(val1).ShouldBe((decimal) 1);
            NumericConv.ToDecimal(val2).ShouldBe((decimal) -1);
            NumericConv.ToDecimal(val3).ShouldBe((decimal) 1);
            NumericConv.ToDecimal(val4).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(val5).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(val6).ShouldBe((decimal) 1.111);
            NumericConv.ToDecimal(val7).ShouldBe((decimal) 1.111);
            NumericConv.ToDecimal(val8).ShouldBe((decimal) -1.111);
            NumericConv.ToDecimal(val9).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(valA).ShouldBe(default);
            NumericConv.ToDecimal(valB).ShouldBe(default);
            NumericConv.ToDecimal(ValC).ShouldBe(default);

            NumericConv.ToDecimal(val0, (decimal) 2.222).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(val1, (decimal) 2.222).ShouldBe((decimal) 1);
            NumericConv.ToDecimal(val2, (decimal) 2.222).ShouldBe((decimal) -1);
            NumericConv.ToDecimal(val3, (decimal) 2.222).ShouldBe((decimal) 1);
            NumericConv.ToDecimal(val4, (decimal) 2.222).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(val5, (decimal) 2.222).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(val6, (decimal) 2.222).ShouldBe((decimal) 1.111);
            NumericConv.ToDecimal(val7, (decimal) 2.222).ShouldBe((decimal) 1.111);
            NumericConv.ToDecimal(val8, (decimal) 2.222).ShouldBe((decimal) -1.111);
            NumericConv.ToDecimal(val9, (decimal) 2.222).ShouldBe((decimal) 0);
            NumericConv.ToDecimal(valA, (decimal) 2.222).ShouldBe((decimal) 2.222);
            NumericConv.ToDecimal(valB, (decimal) 2.222).ShouldBe((decimal) 2.222);
            NumericConv.ToDecimal(ValC, (decimal) 2.222).ShouldBe((decimal) 2.222);
        }

        [Fact(DisplayName = "Convert string value to nullable decimal test")]
        public void StringValConvertToNullableDecimalTest()
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

            NumericConv.ToNullableDecimal(val0).ShouldBe((decimal) 0);
            NumericConv.ToNullableDecimal(val1).ShouldBe((decimal) 1);
            NumericConv.ToNullableDecimal(val2).ShouldBe((decimal) -1);
            NumericConv.ToNullableDecimal(val3).ShouldBe((decimal) 1);
            NumericConv.ToNullableDecimal(val4).ShouldBe((decimal) 0);
            NumericConv.ToNullableDecimal(val5).ShouldBe((decimal) 0);
            NumericConv.ToNullableDecimal(val6).ShouldBe((decimal) 1.111);
            NumericConv.ToNullableDecimal(val7).ShouldBe((decimal) 1.111);
            NumericConv.ToNullableDecimal(val8).ShouldBe((decimal) -1.111);
            NumericConv.ToNullableDecimal(val9).ShouldBe((decimal) 0);
            NumericConv.ToNullableDecimal(valA).ShouldBeNull();
            NumericConv.ToNullableDecimal(valB).ShouldBeNull();
            NumericConv.ToNullableDecimal(ValC).ShouldBeNull();
        }
    }
}