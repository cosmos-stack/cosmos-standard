using System;
using System.Text;
using CosmosStack.Conversions;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    public class CommonCastingTest1
    {
        [Fact]
        public void ObjectToObject()
        {
            var str_1 = "1";
            var int_1 = 1;
            var obj_1 = (object) int_1;
            ((object) str_1).CastTo(typeof(int)).ShouldBe(obj_1);
        }

        [Fact]
        public void ObjectToObject_FailureWithDefault()
        {
            var str_1 = "1";
            var int_1 = 1;
            var obj_1 = (object) int_1;
            ((object) str_1).CastTo(typeof(Action), obj_1).ShouldBe(obj_1);
        }

        [Fact]
        public void ObjectToGenericObject()
        {
            var str_1 = "1";
            var int_1 = 1;
            var obj_1 = (object) int_1;
            ((object) str_1).CastTo<int>().ShouldBe(int_1);
            obj_1.CastTo<int>().ShouldBe(int_1);
        }

        [Fact]
        public void ObjectToGenericObject_FailureWithDefault()
        {
            var str_1 = "1";
            var int_1 = 1;
            var obj_1 = (object) int_1;
            ((object) str_1).CastTo(typeof(Action), obj_1).ShouldBe(obj_1);

            var defDtVal = DateTime.Now;

            ((object) str_1).CastTo<DateTime>(defDtVal).ShouldBe(defDtVal);
            obj_1.CastTo<DateTime>(defDtVal).ShouldBe(defDtVal);
        }

        [Fact]
        public void ObjectToAny()
        {
            string number = "1";
            string utf8 = "utf-8";

            number.CastTo<short>().ShouldBe((short) 1);
            number.CastTo<ushort>().ShouldBe((ushort) 1);
            number.CastTo<int>().ShouldBe(1);
            number.CastTo<uint>().ShouldBe((uint) 1);
            number.CastTo<long>().ShouldBe(1);
            number.CastTo<ulong>().ShouldBe((ulong) 1);
            number.CastTo<float>().ShouldBe(1F);
            number.CastTo<double>().ShouldBe(1D);
            number.CastTo<decimal>().ShouldBe(1M);

            utf8.CastTo<Encoding>(Encoding.ASCII).ShouldBe(Encoding.UTF8);
        }
    }
}