using CosmosStack.Numeric;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("NumericUT", "NumericConv")]
    public class NumericConvTests
    {
        [Fact(DisplayName = "ConvX.ToInt16")]
        public void Int16ConvertTest()
        {
            object obj1 = 16;
            object obj2 = "16";
            object obj3 = null;
            object obj4 = "16.1";
            object obj5 = (short) 16;
            object obj6 = -16;
            object obj7 = "-16";
            object obj8 = "-16.1";
            object obj9 = (short) -16;
            string str1 = "16";
            string str2 = "";
            string str3 = null;
            string str4 = "16.1";
            string str5 = "-16";
            string str6 = "-16.1";

            NumericConv.ToInt16(obj1).ShouldBe((short) 16);
            NumericConv.ToInt16(obj2).ShouldBe((short) 16);
            NumericConv.ToInt16(obj3).ShouldBe((short) 0);
            NumericConv.ToInt16(obj4).ShouldBe((short) 16);
            NumericConv.ToInt16(obj5).ShouldBe((short) 16);
            NumericConv.ToInt16(obj6).ShouldBe((short) -16);
            NumericConv.ToInt16(obj7).ShouldBe((short) -16);
            NumericConv.ToInt16(obj8).ShouldBe((short) -16);
            NumericConv.ToInt16(str1).ShouldBe((short) 16);
            NumericConv.ToInt16(str2).ShouldBe((short) 0);
            NumericConv.ToInt16(str3).ShouldBe((short) 0);
            NumericConv.ToInt16(str4).ShouldBe((short) 16);
            NumericConv.ToInt16(str5).ShouldBe((short) -16);
            NumericConv.ToInt16(str6).ShouldBe((short) -16);

            NumericConv.ToNullableInt16(obj1).ShouldBe((short?) 16);
            NumericConv.ToNullableInt16(obj2).ShouldBe((short?) 16);
            NumericConv.ToNullableInt16(obj3).ShouldBe(null);
            NumericConv.ToNullableInt16(obj4).ShouldBe(null);
            NumericConv.ToNullableInt16(obj5).ShouldBe((short?) 16);
            NumericConv.ToNullableInt16(obj6).ShouldBe((short?) -16);
            NumericConv.ToNullableInt16(obj7).ShouldBe((short?) -16);
            NumericConv.ToNullableInt16(obj8).ShouldBe(null);
            NumericConv.ToNullableInt16(str1).ShouldBe((short?) 16);
            NumericConv.ToNullableInt16(str2).ShouldBe(null);
            NumericConv.ToNullableInt16(str3).ShouldBe(null);
            NumericConv.ToNullableInt16(str4).ShouldBe(null);
            NumericConv.ToNullableInt16(str5).ShouldBe((short?) -16);
            NumericConv.ToNullableInt16(str6).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToInt32")]
        public void Int32ConvertTest()
        {
            object obj1 = 32;
            object obj2 = "32";
            object obj3 = null;
            object obj4 = "32.1";
            object obj5 = 32;
            object obj6 = -32;
            object obj7 = "-32";
            object obj8 = "-32.1";
            object obj9 = -32;
            string str1 = "32";
            string str2 = "";
            string str3 = null;
            string str4 = "32.1";
            string str5 = "-32";
            string str6 = "-32.1";

            NumericConv.ToInt32(obj1).ShouldBe(32);
            NumericConv.ToInt32(obj2).ShouldBe(32);
            NumericConv.ToInt32(obj3).ShouldBe(0);
            NumericConv.ToInt32(obj4).ShouldBe(32);
            NumericConv.ToInt32(obj5).ShouldBe(32);
            NumericConv.ToInt32(obj6).ShouldBe(-32);
            NumericConv.ToInt32(obj7).ShouldBe(-32);
            NumericConv.ToInt32(obj8).ShouldBe(-32);
            NumericConv.ToInt32(str1).ShouldBe(32);
            NumericConv.ToInt32(str2).ShouldBe(0);
            NumericConv.ToInt32(str3).ShouldBe(0);
            NumericConv.ToInt32(str4).ShouldBe(32);
            NumericConv.ToInt32(str5).ShouldBe(-32);
            NumericConv.ToInt32(str6).ShouldBe(-32);

            NumericConv.ToNullableInt32(obj1).ShouldBe((int?) 32);
            NumericConv.ToNullableInt32(obj2).ShouldBe((int?) 32);
            NumericConv.ToNullableInt32(obj3).ShouldBe(null);
            NumericConv.ToNullableInt32(obj4).ShouldBe(null);
            NumericConv.ToNullableInt32(obj5).ShouldBe((int?) 32);
            NumericConv.ToNullableInt32(obj6).ShouldBe((int?) -32);
            NumericConv.ToNullableInt32(obj7).ShouldBe((int?) -32);
            NumericConv.ToNullableInt32(obj8).ShouldBe(null);
            NumericConv.ToNullableInt32(str1).ShouldBe((int?) 32);
            NumericConv.ToNullableInt32(str2).ShouldBe(null);
            NumericConv.ToNullableInt32(str3).ShouldBe(null);
            NumericConv.ToNullableInt32(str4).ShouldBe(null);
            NumericConv.ToNullableInt32(str5).ShouldBe((int?) -32);
            NumericConv.ToNullableInt32(str6).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToInt64")]
        public void Int64ConvertTest()
        {
            object obj1 = 64;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.1";
            object obj5 = 64L;
            object obj6 = -64;
            object obj7 = "-64";
            object obj8 = "-64.1";
            object obj9 = -64;
            string str1 = "64";
            string str2 = "";
            string str3 = null;
            string str4 = "64.1";
            string str5 = "-64";
            string str6 = "-64.1";
            string str7 = "64L";

            NumericConv.ToInt64(obj1).ShouldBe(64);
            NumericConv.ToInt64(obj2).ShouldBe(64);
            NumericConv.ToInt64(obj3).ShouldBe(0);
            NumericConv.ToInt64(obj4).ShouldBe(64);
            NumericConv.ToInt64(obj5).ShouldBe(64);
            NumericConv.ToInt64(obj6).ShouldBe(-64);
            NumericConv.ToInt64(obj7).ShouldBe(-64);
            NumericConv.ToInt64(obj8).ShouldBe(-64);
            NumericConv.ToInt64(str1).ShouldBe(64);
            NumericConv.ToInt64(str2).ShouldBe(0);
            NumericConv.ToInt64(str3).ShouldBe(0);
            NumericConv.ToInt64(str4).ShouldBe(64);
            NumericConv.ToInt64(str5).ShouldBe(-64);
            NumericConv.ToInt64(str6).ShouldBe(-64);
            NumericConv.ToInt64(str7).ShouldBe(0);

            NumericConv.ToNullableInt64(obj1).ShouldBe((long?) 64);
            NumericConv.ToNullableInt64(obj2).ShouldBe((long?) 64);
            NumericConv.ToNullableInt64(obj3).ShouldBe(null);
            NumericConv.ToNullableInt64(obj4).ShouldBe(null);
            NumericConv.ToNullableInt64(obj5).ShouldBe((long?) 64);
            NumericConv.ToNullableInt64(obj6).ShouldBe((long?) -64);
            NumericConv.ToNullableInt64(obj7).ShouldBe((long?) -64);
            NumericConv.ToNullableInt64(obj8).ShouldBe(null);
            NumericConv.ToNullableInt64(str1).ShouldBe((long?) 64);
            NumericConv.ToNullableInt64(str2).ShouldBe(null);
            NumericConv.ToNullableInt64(str3).ShouldBe(null);
            NumericConv.ToNullableInt64(str4).ShouldBe(null);
            NumericConv.ToNullableInt64(str5).ShouldBe((long?) -64);
            NumericConv.ToNullableInt64(str6).ShouldBe(null);
            NumericConv.ToNullableInt64(str7).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToUInt16")]
        public void UInt16ConvertTest()
        {
            object obj1 = 16;
            object obj2 = "16";
            object obj3 = null;
            object obj4 = "16.1";
            object obj5 = (ushort) 16;
            object obj6 = -16;
            object obj7 = "-16";
            object obj8 = "-16.1";
            object obj9 = (short) -16;
            string str1 = "16";
            string str2 = "";
            string str3 = null;
            string str4 = "16.1";
            string str5 = "-16";
            string str6 = "-16.1";

            NumericConv.ToUInt16(obj1).ShouldBe((ushort) 16);
            NumericConv.ToUInt16(obj2).ShouldBe((ushort) 16);
            NumericConv.ToUInt16(obj3).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(obj4).ShouldBe((ushort) 16);
            NumericConv.ToUInt16(obj5).ShouldBe((ushort) 16);
            NumericConv.ToUInt16(obj6).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(obj7).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(obj8).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(str1).ShouldBe((ushort) 16);
            NumericConv.ToUInt16(str2).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(str3).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(str4).ShouldBe((ushort) 16);
            NumericConv.ToUInt16(str5).ShouldBe((ushort) 0);
            NumericConv.ToUInt16(str6).ShouldBe((ushort) 0);

            NumericConv.ToNullableUInt16(obj1).ShouldBe((ushort?) 16);
            NumericConv.ToNullableUInt16(obj2).ShouldBe((ushort?) 16);
            NumericConv.ToNullableUInt16(obj3).ShouldBe(null);
            NumericConv.ToNullableUInt16(obj4).ShouldBe(null);
            NumericConv.ToNullableUInt16(obj5).ShouldBe((ushort?) 16);
            NumericConv.ToNullableUInt16(obj6).ShouldBe(null);
            NumericConv.ToNullableUInt16(obj7).ShouldBe(null);
            NumericConv.ToNullableUInt16(obj8).ShouldBe(null);
            NumericConv.ToNullableUInt16(str1).ShouldBe((ushort?) 16);
            NumericConv.ToNullableUInt16(str2).ShouldBe(null);
            NumericConv.ToNullableUInt16(str3).ShouldBe(null);
            NumericConv.ToNullableUInt16(str4).ShouldBe(null);
            NumericConv.ToNullableUInt16(str5).ShouldBe(null);
            NumericConv.ToNullableUInt16(str6).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToUInt32")]
        public void UInt32ConvertTest()
        {
            object obj1 = 32;
            object obj2 = "32";
            object obj3 = null;
            object obj4 = "32.1";
            object obj5 = (uint) 32;
            object obj6 = -32;
            object obj7 = "-32";
            object obj8 = "-32.1";
            object obj9 = -32;
            string str1 = "32";
            string str2 = "";
            string str3 = null;
            string str4 = "32.1";
            string str5 = "-32";
            string str6 = "-32.1";

            NumericConv.ToUInt32(obj1).ShouldBe((uint) 32);
            NumericConv.ToUInt32(obj2).ShouldBe((uint) 32);
            NumericConv.ToUInt32(obj3).ShouldBe((uint) 0);
            NumericConv.ToUInt32(obj4).ShouldBe((uint) 32);
            NumericConv.ToUInt32(obj5).ShouldBe((uint) 32);
            NumericConv.ToUInt32(obj6).ShouldBe((uint) 0);
            NumericConv.ToUInt32(obj7).ShouldBe((uint) 0);
            NumericConv.ToUInt32(obj8).ShouldBe((uint) 0);
            NumericConv.ToUInt32(str1).ShouldBe((uint) 32);
            NumericConv.ToUInt32(str2).ShouldBe((uint) 0);
            NumericConv.ToUInt32(str3).ShouldBe((uint) 0);
            NumericConv.ToUInt32(str4).ShouldBe((uint) 32);
            NumericConv.ToUInt32(str5).ShouldBe((uint) 0);
            NumericConv.ToUInt32(str6).ShouldBe((uint) 0);

            NumericConv.ToNullableUInt32(obj1).ShouldBe((uint?) 32);
            NumericConv.ToNullableUInt32(obj2).ShouldBe((uint?) 32);
            NumericConv.ToNullableUInt32(obj3).ShouldBe(null);
            NumericConv.ToNullableUInt32(obj4).ShouldBe(null);
            NumericConv.ToNullableUInt32(obj5).ShouldBe((uint?) 32);
            NumericConv.ToNullableUInt32(obj6).ShouldBe(null);
            NumericConv.ToNullableUInt32(obj7).ShouldBe(null);
            NumericConv.ToNullableUInt32(obj8).ShouldBe(null);
            NumericConv.ToNullableUInt32(str1).ShouldBe((uint?) 32);
            NumericConv.ToNullableUInt32(str2).ShouldBe(null);
            NumericConv.ToNullableUInt32(str3).ShouldBe(null);
            NumericConv.ToNullableUInt32(str4).ShouldBe(null);
            NumericConv.ToNullableUInt32(str5).ShouldBe(null);
            NumericConv.ToNullableUInt32(str6).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToUInt64")]
        public void UInt64ConvertTest()
        {
            object obj1 = 64;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.1";
            object obj5 = (ulong) 64L;
            object obj6 = -64;
            object obj7 = "-64";
            object obj8 = "-64.1";
            object obj9 = -64;
            string str1 = "64";
            string str2 = "";
            string str3 = null;
            string str4 = "64.1";
            string str5 = "-64";
            string str6 = "-64.1";
            string str7 = "64L";

            NumericConv.ToUInt64(obj1).ShouldBe((ulong) 64);
            NumericConv.ToUInt64(obj2).ShouldBe((ulong) 64);
            NumericConv.ToUInt64(obj3).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(obj4).ShouldBe((ulong) 64);
            NumericConv.ToUInt64(obj5).ShouldBe((ulong) 64);
            NumericConv.ToUInt64(obj6).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(obj7).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(obj8).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(str1).ShouldBe((ulong) 64);
            NumericConv.ToUInt64(str2).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(str3).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(str4).ShouldBe((ulong) 64);
            NumericConv.ToUInt64(str5).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(str6).ShouldBe((ulong) 0);
            NumericConv.ToUInt64(str7).ShouldBe((ulong) 0);

            NumericConv.ToNullableUInt64(obj1).ShouldBe((ulong?) 64uL);
            NumericConv.ToNullableUInt64(obj2).ShouldBe((ulong?) 64uL);
            NumericConv.ToNullableUInt64(obj3).ShouldBe(null);
            NumericConv.ToNullableUInt64(obj4).ShouldBe(null);
            NumericConv.ToNullableUInt64(obj5).ShouldBe((ulong?) 64uL);
            NumericConv.ToNullableUInt64(obj6).ShouldBe(null);
            NumericConv.ToNullableUInt64(obj7).ShouldBe(null);
            NumericConv.ToNullableUInt64(obj8).ShouldBe(null);
            NumericConv.ToNullableUInt64(str1).ShouldBe((ulong?) 64uL);
            NumericConv.ToNullableUInt64(str2).ShouldBe(null);
            NumericConv.ToNullableUInt64(str3).ShouldBe(null);
            NumericConv.ToNullableUInt64(str4).ShouldBe(null);
            NumericConv.ToNullableUInt64(str5).ShouldBe(null);
            NumericConv.ToNullableUInt64(str6).ShouldBe(null);
            NumericConv.ToNullableUInt64(str7).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToSingle")]
        public void SingleConvertTest()
        {
            object obj1 = 64;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.1";
            object obj5 = 64F;
            object obj6 = -64;
            object obj7 = "-64";
            object obj8 = "-64.1";
            object obj9 = -64;
            string str1 = "64";
            string str2 = "";
            string str3 = null;
            string str4 = "64.1";
            string str5 = "-64";
            string str6 = "-64.1";
            string str7 = "64F";

            NumericConv.ToFloat(obj1).ShouldBe(64);
            NumericConv.ToFloat(obj2).ShouldBe(64);
            NumericConv.ToFloat(obj3).ShouldBe(0);
            NumericConv.ToFloat(obj4).ShouldBe(64.1f);
            NumericConv.ToFloat(obj5).ShouldBe(64);
            NumericConv.ToFloat(obj6).ShouldBe(-64);
            NumericConv.ToFloat(obj7).ShouldBe(-64);
            NumericConv.ToFloat(obj8).ShouldBe(-64.1f);
            NumericConv.ToFloat(str1).ShouldBe(64);
            NumericConv.ToFloat(str2).ShouldBe(0);
            NumericConv.ToFloat(str3).ShouldBe(0);
            NumericConv.ToFloat(str4).ShouldBe(64.1f);
            NumericConv.ToFloat(str5).ShouldBe(-64);
            NumericConv.ToFloat(str6).ShouldBe(-64.1f);
            NumericConv.ToFloat(str7).ShouldBe(0);

            NumericConv.ToNullableFloat(obj1).ShouldBe((float?) 64);
            NumericConv.ToNullableFloat(obj2).ShouldBe((float?) 64);
            NumericConv.ToNullableFloat(obj3).ShouldBe(null);
            NumericConv.ToNullableFloat(obj4).ShouldBe(64.1f);
            NumericConv.ToNullableFloat(obj5).ShouldBe((float?) 64);
            NumericConv.ToNullableFloat(obj6).ShouldBe((float?) -64);
            NumericConv.ToNullableFloat(obj7).ShouldBe((float?) -64);
            NumericConv.ToNullableFloat(obj8).ShouldBe(-64.1f);
            NumericConv.ToNullableFloat(str1).ShouldBe((float?) 64);
            NumericConv.ToNullableFloat(str2).ShouldBe(null);
            NumericConv.ToNullableFloat(str3).ShouldBe(null);
            NumericConv.ToNullableFloat(str4).ShouldBe(64.1f);
            NumericConv.ToNullableFloat(str5).ShouldBe((float?) -64);
            NumericConv.ToNullableFloat(str6).ShouldBe(-64.1f);
            NumericConv.ToNullableFloat(str7).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToDouble")]
        public void DoubleConvertTest()
        {
            object obj1 = 64;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.1";
            object obj5 = 64D;
            object obj6 = -64;
            object obj7 = "-64";
            object obj8 = "-64.1";
            object obj9 = -64;
            string str1 = "64";
            string str2 = "";
            string str3 = null;
            string str4 = "64.1";
            string str5 = "-64";
            string str6 = "-64.1";
            string str7 = "64D";

            NumericConv.ToDouble(obj1).ShouldBe(64);
            NumericConv.ToDouble(obj2).ShouldBe(64);
            NumericConv.ToDouble(obj3).ShouldBe(0);
            NumericConv.ToDouble(obj4).ShouldBe(64.1D);
            NumericConv.ToDouble(obj5).ShouldBe(64);
            NumericConv.ToDouble(obj6).ShouldBe(-64);
            NumericConv.ToDouble(obj7).ShouldBe(-64);
            NumericConv.ToDouble(obj8).ShouldBe(-64.1D);
            NumericConv.ToDouble(str1).ShouldBe(64);
            NumericConv.ToDouble(str2).ShouldBe(0);
            NumericConv.ToDouble(str3).ShouldBe(0);
            NumericConv.ToDouble(str4).ShouldBe(64.1D);
            NumericConv.ToDouble(str5).ShouldBe(-64);
            NumericConv.ToDouble(str6).ShouldBe(-64.1D);
            NumericConv.ToDouble(str7).ShouldBe(0);

            NumericConv.ToNullableDouble(obj1).ShouldBe((double?) 64);
            NumericConv.ToNullableDouble(obj2).ShouldBe((double?) 64);
            NumericConv.ToNullableDouble(obj3).ShouldBe(null);
            NumericConv.ToNullableDouble(obj4).ShouldBe(64.1D);
            NumericConv.ToNullableDouble(obj5).ShouldBe((double?) 64);
            NumericConv.ToNullableDouble(obj6).ShouldBe((double?) -64);
            NumericConv.ToNullableDouble(obj7).ShouldBe((double?) -64);
            NumericConv.ToNullableDouble(obj8).ShouldBe(-64.1D);
            NumericConv.ToNullableDouble(str1).ShouldBe((double?) 64);
            NumericConv.ToNullableDouble(str2).ShouldBe(null);
            NumericConv.ToNullableDouble(str3).ShouldBe(null);
            NumericConv.ToNullableDouble(str4).ShouldBe(64.1D);
            NumericConv.ToNullableDouble(str5).ShouldBe((double?) -64);
            NumericConv.ToNullableDouble(str6).ShouldBe(-64.1D);
            NumericConv.ToNullableDouble(str7).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToRoundDouble")]
        public void RoundDoubleConvertTest()
        {
            object obj1 = 64.445566;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.445566";
            object obj5 = 64.445566D;
            object obj6 = -64.445566;
            object obj7 = "-64";
            object obj8 = "-64.445566";
            object obj9 = -64.445566F;
            string str1 = "64.445566";
            string str2 = "";
            string str3 = null;
            string str4 = "64.445566";
            string str5 = "-64";
            string str6 = "-64.445566";
            string str7 = "64.445566D";

            NumericConv.ToRoundDouble(obj1,5).ShouldBe(64.44557);
            NumericConv.ToRoundDouble(obj2,5).ShouldBe(64);
            NumericConv.ToRoundDouble(obj3,5).ShouldBe(0);
            NumericConv.ToRoundDouble(obj4,5).ShouldBe(64.44557);
            NumericConv.ToRoundDouble(obj5,5).ShouldBe(64.44557);
            NumericConv.ToRoundDouble(obj6,5).ShouldBe(-64.44557);
            NumericConv.ToRoundDouble(obj7,5).ShouldBe(-64);
            NumericConv.ToRoundDouble(obj8,5).ShouldBe(-64.44557);
            NumericConv.ToRoundDouble(obj9,5).ShouldBe(-64.44556);
            NumericConv.ToRoundDouble(str1,5).ShouldBe(64.44557);
            NumericConv.ToRoundDouble(str2,5).ShouldBe(0);
            NumericConv.ToRoundDouble(str3,5).ShouldBe(0);
            NumericConv.ToRoundDouble(str4,5).ShouldBe(64.44557);
            NumericConv.ToRoundDouble(str5,5).ShouldBe(-64);
            NumericConv.ToRoundDouble(str6,5).ShouldBe(-64.44557);
            NumericConv.ToRoundDouble(str7,5).ShouldBe(0);

            NumericConv.ToRoundDouble(obj1,2).ShouldBe(64.45);
            NumericConv.ToRoundDouble(obj2,2).ShouldBe(64);
            NumericConv.ToRoundDouble(obj3,2).ShouldBe(0);
            NumericConv.ToRoundDouble(obj4,2).ShouldBe(64.45);
            NumericConv.ToRoundDouble(obj5,2).ShouldBe(64.45);
            NumericConv.ToRoundDouble(obj6,2).ShouldBe(-64.45);
            NumericConv.ToRoundDouble(obj7,2).ShouldBe(-64);
            NumericConv.ToRoundDouble(obj8,2).ShouldBe(-64.45);
            NumericConv.ToRoundDouble(obj9,2).ShouldBe(-64.45);
            NumericConv.ToRoundDouble(str1,2).ShouldBe(64.45);
            NumericConv.ToRoundDouble(str2,2).ShouldBe(0);
            NumericConv.ToRoundDouble(str3,2).ShouldBe(0);
            NumericConv.ToRoundDouble(str4,2).ShouldBe(64.45);
            NumericConv.ToRoundDouble(str5,2).ShouldBe(-64);
            NumericConv.ToRoundDouble(str6,2).ShouldBe(-64.45);
            NumericConv.ToRoundDouble(str7,2).ShouldBe(0);

            NumericConv.ToRoundNullableDouble(obj1,5).ShouldBe((double?)64.44557);
            NumericConv.ToRoundNullableDouble(obj2,5).ShouldBe((double?)64);
            NumericConv.ToRoundNullableDouble(obj3,5).ShouldBe(null);
            NumericConv.ToRoundNullableDouble(obj4,5).ShouldBe((double?)64.44557);
            NumericConv.ToRoundNullableDouble(obj5,5).ShouldBe((double?)64.44557);
            NumericConv.ToRoundNullableDouble(obj6,5).ShouldBe((double?)-64.44557);
            NumericConv.ToRoundNullableDouble(obj7,5).ShouldBe((double?)-64);
            NumericConv.ToRoundNullableDouble(obj8,5).ShouldBe((double?)-64.44557);
            NumericConv.ToRoundNullableDouble(obj9,5).ShouldBe((double?)-64.44556);
            NumericConv.ToRoundNullableDouble(str1,5).ShouldBe((double?)64.44557);
            NumericConv.ToRoundNullableDouble(str2,5).ShouldBe(null);
            NumericConv.ToRoundNullableDouble(str3,5).ShouldBe(null);
            NumericConv.ToRoundNullableDouble(str4,5).ShouldBe((double?)64.44557);
            NumericConv.ToRoundNullableDouble(str5,5).ShouldBe((double?)-64);
            NumericConv.ToRoundNullableDouble(str6,5).ShouldBe((double?)-64.44557);
            NumericConv.ToRoundNullableDouble(str7,5).ShouldBe(null);

            NumericConv.ToRoundNullableDouble(obj1,2).ShouldBe((double?)64.45);
            NumericConv.ToRoundNullableDouble(obj2,2).ShouldBe((double?)64);
            NumericConv.ToRoundNullableDouble(obj3,2).ShouldBe(null);
            NumericConv.ToRoundNullableDouble(obj4,2).ShouldBe((double?)64.45);
            NumericConv.ToRoundNullableDouble(obj5,2).ShouldBe((double?)64.45);
            NumericConv.ToRoundNullableDouble(obj6,2).ShouldBe((double?)-64.45);
            NumericConv.ToRoundNullableDouble(obj7,2).ShouldBe((double?)-64);
            NumericConv.ToRoundNullableDouble(obj8,2).ShouldBe((double?)-64.45);
            NumericConv.ToRoundNullableDouble(obj9,2).ShouldBe((double?)-64.45);
            NumericConv.ToRoundNullableDouble(str1,2).ShouldBe((double?)64.45);
            NumericConv.ToRoundNullableDouble(str2,2).ShouldBe(null);
            NumericConv.ToRoundNullableDouble(str3,2).ShouldBe(null);
            NumericConv.ToRoundNullableDouble(str4,2).ShouldBe((double?)64.45);
            NumericConv.ToRoundNullableDouble(str5,2).ShouldBe((double?)-64);
            NumericConv.ToRoundNullableDouble(str6,2).ShouldBe((double?)-64.45);
            NumericConv.ToRoundNullableDouble(str7,2).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToDecimal")]
        public void DecimalConvertTest()
        {
            object obj1 = 64.445566;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.445566";
            object obj5 = (decimal)64.445566;
            object obj6 = (decimal)-64.445566;
            object obj7 = "-64";
            object obj8 = "-64.445566";
            object obj9 = -64.445566F;
            string str1 = "64.445566";
            string str2 = "";
            string str3 = null;
            string str4 = "64.445566";
            string str5 = "-64";
            string str6 = "-64.445566";
            string str7 = "64D";

            NumericConv.ToDecimal(obj1).ShouldBe((decimal)64.445566);
            NumericConv.ToDecimal(obj2).ShouldBe((decimal)64);
            NumericConv.ToDecimal(obj3).ShouldBe((decimal)0);
            NumericConv.ToDecimal(obj4).ShouldBe((decimal)64.445566);
            NumericConv.ToDecimal(obj5).ShouldBe((decimal)64.445566);
            NumericConv.ToDecimal(obj6).ShouldBe((decimal)-64.445566);
            NumericConv.ToDecimal(obj7).ShouldBe((decimal)-64);
            NumericConv.ToDecimal(obj8).ShouldBe((decimal)-64.445566);
            NumericConv.ToDecimal(str1).ShouldBe((decimal)64.445566);
            NumericConv.ToDecimal(str2).ShouldBe((decimal)0);
            NumericConv.ToDecimal(str3).ShouldBe((decimal)0);
            NumericConv.ToDecimal(str4).ShouldBe((decimal)64.445566);
            NumericConv.ToDecimal(str5).ShouldBe((decimal)-64);
            NumericConv.ToDecimal(str6).ShouldBe((decimal)-64.445566);
            NumericConv.ToDecimal(str7).ShouldBe((decimal)0);

            NumericConv.ToNullableDecimal(obj1).ShouldBe((decimal?) 64.445566);
            NumericConv.ToNullableDecimal(obj2).ShouldBe((decimal?) 64);
            NumericConv.ToNullableDecimal(obj3).ShouldBe(null);
            NumericConv.ToNullableDecimal(obj4).ShouldBe((decimal?) 64.445566);
            NumericConv.ToNullableDecimal(obj5).ShouldBe((decimal?) 64.445566);
            NumericConv.ToNullableDecimal(obj6).ShouldBe((decimal?) -64.445566);
            NumericConv.ToNullableDecimal(obj7).ShouldBe((decimal?) -64);
            NumericConv.ToNullableDecimal(obj8).ShouldBe((decimal?) -64.445566);
            NumericConv.ToNullableDecimal(str1).ShouldBe((decimal?) 64.445566);
            NumericConv.ToNullableDecimal(str2).ShouldBe(null);
            NumericConv.ToNullableDecimal(str3).ShouldBe(null);
            NumericConv.ToNullableDecimal(str4).ShouldBe((decimal?) 64.445566);
            NumericConv.ToNullableDecimal(str5).ShouldBe((decimal?) -64);
            NumericConv.ToNullableDecimal(str6).ShouldBe((decimal?) -64.445566);
            NumericConv.ToNullableDecimal(str7).ShouldBe(null);
        }

        [Fact(DisplayName = "ConvX.ToRoundDecimal")]
        public void RoundDecimalConvertTest()
        {
            object obj1 = 64.445566;
            object obj2 = "64";
            object obj3 = null;
            object obj4 = "64.445566";
            object obj5 = (decimal)64.445566;
            object obj6 = (decimal)-64.445566;
            object obj7 = "-64";
            object obj8 = "-64.445566";
            object obj9 = -64.445566F;
            string str1 = "64.445566";
            string str2 = "";
            string str3 = null;
            string str4 = "64.445566";
            string str5 = "-64";
            string str6 = "-64.445566";
            string str7 = "64D";

            NumericConv.ToRoundDecimal(obj1,5).ShouldBe((decimal)64.44557);
            NumericConv.ToRoundDecimal(obj2,5).ShouldBe((decimal)64);
            NumericConv.ToRoundDecimal(obj3,5).ShouldBe((decimal)0);
            NumericConv.ToRoundDecimal(obj4,5).ShouldBe((decimal)64.44557);
            NumericConv.ToRoundDecimal(obj5,5).ShouldBe((decimal)64.44557);
            NumericConv.ToRoundDecimal(obj6,5).ShouldBe((decimal)-64.44557);
            NumericConv.ToRoundDecimal(obj7,5).ShouldBe((decimal)-64);
            NumericConv.ToRoundDecimal(obj8,5).ShouldBe((decimal)-64.44557);
            NumericConv.ToRoundDecimal(obj9,5).ShouldBe((decimal)-64.44556);
            NumericConv.ToRoundDecimal(str1,5).ShouldBe((decimal)64.44557);
            NumericConv.ToRoundDecimal(str2,5).ShouldBe((decimal)0);
            NumericConv.ToRoundDecimal(str3,5).ShouldBe((decimal)0);
            NumericConv.ToRoundDecimal(str4,5).ShouldBe((decimal)64.44557);
            NumericConv.ToRoundDecimal(str5,5).ShouldBe((decimal)-64);
            NumericConv.ToRoundDecimal(str6,5).ShouldBe((decimal)-64.44557);
            NumericConv.ToRoundDecimal(str7,5).ShouldBe((decimal)0);

            NumericConv.ToRoundDecimal(obj1,2).ShouldBe((decimal)64.45);
            NumericConv.ToRoundDecimal(obj2,2).ShouldBe((decimal)64);
            NumericConv.ToRoundDecimal(obj3,2).ShouldBe((decimal)0);
            NumericConv.ToRoundDecimal(obj4,2).ShouldBe((decimal)64.45);
            NumericConv.ToRoundDecimal(obj5,2).ShouldBe((decimal)64.45);
            NumericConv.ToRoundDecimal(obj6,2).ShouldBe((decimal)-64.45);
            NumericConv.ToRoundDecimal(obj7,2).ShouldBe((decimal)-64);
            NumericConv.ToRoundDecimal(obj8,2).ShouldBe((decimal)-64.45);
            NumericConv.ToRoundDecimal(obj9,2).ShouldBe((decimal)-64.45);
            NumericConv.ToRoundDecimal(str1,2).ShouldBe((decimal)64.45);
            NumericConv.ToRoundDecimal(str2,2).ShouldBe((decimal)0);
            NumericConv.ToRoundDecimal(str3,2).ShouldBe((decimal)0);
            NumericConv.ToRoundDecimal(str4,2).ShouldBe((decimal)64.45);
            NumericConv.ToRoundDecimal(str5,2).ShouldBe((decimal)-64);
            NumericConv.ToRoundDecimal(str6,2).ShouldBe((decimal)-64.45);
            NumericConv.ToRoundDecimal(str7,2).ShouldBe((decimal)0);

            NumericConv.ToRoundNullableDecimal(obj1,5).ShouldBe((decimal?) 64.44557);
            NumericConv.ToRoundNullableDecimal(obj2,5).ShouldBe((decimal?) 64);
            NumericConv.ToRoundNullableDecimal(obj3,5).ShouldBe(null);
            NumericConv.ToRoundNullableDecimal(obj4,5).ShouldBe((decimal?) 64.44557);
            NumericConv.ToRoundNullableDecimal(obj5,5).ShouldBe((decimal?) 64.44557);
            NumericConv.ToRoundNullableDecimal(obj6,5).ShouldBe((decimal?) -64.44557);
            NumericConv.ToRoundNullableDecimal(obj7,5).ShouldBe((decimal?) -64);
            NumericConv.ToRoundNullableDecimal(obj8,5).ShouldBe((decimal?) -64.44557);
            NumericConv.ToRoundNullableDecimal(obj9,5).ShouldBe((decimal?) -64.44556);
            NumericConv.ToRoundNullableDecimal(str1,5).ShouldBe((decimal?) 64.44557);
            NumericConv.ToRoundNullableDecimal(str2,5).ShouldBe(null);
            NumericConv.ToRoundNullableDecimal(str3,5).ShouldBe(null);
            NumericConv.ToRoundNullableDecimal(str4,5).ShouldBe((decimal?) 64.44557);
            NumericConv.ToRoundNullableDecimal(str5,5).ShouldBe((decimal?) -64);
            NumericConv.ToRoundNullableDecimal(str6,5).ShouldBe((decimal?) -64.44557);
            NumericConv.ToRoundNullableDecimal(str7,5).ShouldBe(null);

            NumericConv.ToRoundNullableDecimal(obj1,2).ShouldBe((decimal?) 64.45);
            NumericConv.ToRoundNullableDecimal(obj2,2).ShouldBe((decimal?) 64);
            NumericConv.ToRoundNullableDecimal(obj3,2).ShouldBe(null);
            NumericConv.ToRoundNullableDecimal(obj4,2).ShouldBe((decimal?) 64.45);
            NumericConv.ToRoundNullableDecimal(obj5,2).ShouldBe((decimal?) 64.45);
            NumericConv.ToRoundNullableDecimal(obj6,2).ShouldBe((decimal?) -64.45);
            NumericConv.ToRoundNullableDecimal(obj7,2).ShouldBe((decimal?) -64);
            NumericConv.ToRoundNullableDecimal(obj8,2).ShouldBe((decimal?) -64.45);
            NumericConv.ToRoundNullableDecimal(str1,2).ShouldBe((decimal?) 64.45);
            NumericConv.ToRoundNullableDecimal(str2,2).ShouldBe(null);
            NumericConv.ToRoundNullableDecimal(str3,2).ShouldBe(null);
            NumericConv.ToRoundNullableDecimal(str4,2).ShouldBe((decimal?) 64.45);
            NumericConv.ToRoundNullableDecimal(str5,2).ShouldBe((decimal?) -64);
            NumericConv.ToRoundNullableDecimal(str6,2).ShouldBe((decimal?) -64.45);
            NumericConv.ToRoundNullableDecimal(str7,2).ShouldBe(null);
        }
    }
}