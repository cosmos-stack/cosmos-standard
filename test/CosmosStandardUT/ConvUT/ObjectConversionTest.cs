using System;
using System.Globalization;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    public class ObjectConversionTest
    {
        class One { }

        class Two
        {
            public override string ToString()
            {
                return "i'm two!";
            }
        }

        [Fact]
        public void NullObjectTest()
        {
            var str = StringConv.ToString((object) null);

            str.ShouldBeEmpty();
        }

        [Fact]
        public void ValueTypeTest()
        {
            var str1 = StringConv.ToString(1);
            var str2 = StringConv.ToString(1.1D);

            str1.ShouldBe("1");
            str2.ShouldBe("1.1");
        }

        [Fact]
        public void DatetimeTest()
        {
            var dt = new DateTime(2017, 10, 1, 10, 10, 12, 933);
            var str = StringConv.ToString(dt);
            var expectedStr = dt.ToString(CultureInfo.CurrentCulture);

            str.ShouldBe(expectedStr);
        }

        [Fact]
        public void GuidTest()
        {
            var guid = new Guid();
            var str1 = guid.ToString();
            var str2 = StringConv.ToString(guid);

            str1.ShouldBe(str2);
        }

        [Fact]
        public void ObjectTest()
        {
            var one = new One();
            var two = new Two();
            var str1 = StringConv.ToString(one);
            var str2 = StringConv.ToString(two);

            str1.ShouldBe("CosmosStack.Test.Conversions.ObjectConversionTest+One");
            str2.ShouldBe("i'm two!");
        }
    }
}