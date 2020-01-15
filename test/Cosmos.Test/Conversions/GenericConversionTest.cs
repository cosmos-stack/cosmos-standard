using System.Collections.Generic;
using System.Linq;
using Cosmos.Conversions;
using Xunit;
using Shouldly;

namespace Cosmos.Test.Conversions {
    public class GenericConversionTest {
        class One { }

        class Two : One { }

        [Fact]
        public void NullObjTest() {
            ObjectConversion.To<One>(null).ShouldBe(default);
        }

        [Fact]
        public void NullValueTypeTest() {
            ObjectConversion.To<int>(null).ShouldBe(default);
        }

        [Theory]
        [InlineData(1.0001D)]
        public void ValueTypeTest(double input) {
            ObjectConversion.To<int>(input).ShouldBe(1);
        }

        [Fact]
        public void ParentClazzTest() {
            One one = new Two();
            var one1 = ObjectConversion.To<One>(one);
            var two1 = ObjectConversion.To<Two>(one);

            one1.GetType().ShouldBeOfType<Two>();
            two1.GetType().ShouldBeOfType<Two>();
        }

        [Fact]
        public void BoxedValueTypeTest() {
            ObjectConversion.To<int>(100).ShouldBe(100);
        }

        [Fact]
        public void ObjectToListTest() {
            object list = new List<string> {"1", "2", "3"};
            var list2 = ObjectConversion.To<List<string>>(list);

            list2.ShouldNotBeNull();
            list2.ShouldNotBeEmpty();
            list2.Count.ShouldBe(3);
            list2[0].ShouldBe("1");
        }

        [Fact]
        public void ObjectValueListFailureTest() {
            object list = new List<string> {"1", "2", "3"};
            ObjectConversion.To<List<One>>(list).ShouldBeNull();
        }

        [Theory]
        [InlineData("1,2,3,4,5")]
        [InlineData("1,2,3,4,5,")]
        [InlineData("1.1,2.2,3.3,4.4,5.5")]
        [InlineData("1.1,2.2,3.3,4.4,5.5,")]
        public void IntegerListTest(string str) {
            var list = ObjectConversion.ToList<int>(str).ToList();

            list.ShouldNotBeNull();
            list.Count.ShouldBe(5);
            list.First().ShouldBe(1);
        }

        [Theory]
        [InlineData("1.1,2.2,3.3,4.4,5.5")]
        [InlineData("1.1,2.2,3.3,4.4,5.5,")]
        public void DoubleListTest(string str) {
            var list = ObjectConversion.ToList<double>(str).ToList();

            list.ShouldNotBeNull();
            list.Count.ShouldBe(5);
            list.First().ShouldBe(1.1);
        }

        [Theory]
        [InlineData("")]
        [InlineData(",,,,,")]
        public void EmptyListTest(string str) {
            var list0 = ObjectConversion.ToList<int>(str).ToList();
            var list1 = ObjectConversion.ToList<One>(str).ToList();

            list0.ShouldNotBeNull();
            list1.ShouldNotBeNull();

            list0.Count.ShouldBe(0);
            list1.Count.ShouldBe(0);

            list0.ShouldBeEmpty();
            list1.ShouldBeEmpty();
        }
    }
}