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
            ObjectConverter.To<One>(null).ShouldBe(default);
        }

        [Fact]
        public void NullValueTypeTest() {
            ObjectConverter.To<int>(null).ShouldBe(default);
        }

        [Theory]
        [InlineData(1.0001D)]
        public void ValueTypeTest(double input) {
            ObjectConverter.To<int>(input).ShouldBe(1);
        }

        [Fact]
        public void ParentClazzTest() {
            One one = new Two();
            var one1 = ObjectConverter.To<One>(one);
            var two1 = ObjectConverter.To<Two>(one);

            one1.GetType().ShouldBeOfType<Two>();
            two1.GetType().ShouldBeOfType<Two>();
        }

        [Fact]
        public void BoxedValueTypeTest() {
            ObjectConverter.To<int>(100).ShouldBe(100);
        }

        [Fact]
        public void ObjectToListTest() {
            object list = new List<string> {"1", "2", "3"};
            var list2 = ObjectConverter.To<List<string>>(list);

            list2.ShouldNotBeNull();
            list2.ShouldNotBeEmpty();
            list2.Count.ShouldBe(3);
            list2[0].ShouldBe("1");
        }

        [Fact]
        public void ObjectValueListFailureTest() {
            object list = new List<string> {"1", "2", "3"};
            ObjectConverter.To<List<One>>(list).ShouldBeNull();
        }

        [Theory]
        [InlineData("1,2,3,4,5")]
        [InlineData("1,2,3,4,5,")]
        [InlineData("1.1,2.2,3.3,4.4,5.5")]
        [InlineData("1.1,2.2,3.3,4.4,5.5,")]
        public void IntegerListTest(string str) {
            var list = ObjectConverter.ToList<int>(str).ToList();

            list.ShouldNotBeNull();
            list.Count.ShouldBe(5);
            list.First().ShouldBe(1);
        }

        [Theory]
        [InlineData("1.1,2.2,3.3,4.4,5.5")]
        [InlineData("1.1,2.2,3.3,4.4,5.5,")]
        public void DoubleListTest(string str) {
            var list = ObjectConverter.ToList<double>(str).ToList();

            list.ShouldNotBeNull();
            list.Count.ShouldBe(5);
            list.First().ShouldBe(1.1);
        }

        [Theory]
        [InlineData("")]
        [InlineData(",,,,,")]
        public void EmptyListTest(string str) {
            var list0 = ObjectConverter.ToList<int>(str).ToList();
            var list1 = ObjectConverter.ToList<One>(str).ToList();

            list0.ShouldNotBeNull();
            list1.ShouldNotBeNull();

            list0.Count.ShouldBe(0);
            list1.Count.ShouldBe(0);

            list0.ShouldBeEmpty();
            list1.ShouldBeEmpty();
        }
    }
}