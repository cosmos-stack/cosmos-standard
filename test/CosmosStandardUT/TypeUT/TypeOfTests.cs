using System;
using System.Linq;
using Cosmos.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT ", "TypeOfTests")]
    public class TypeOfTests
    {
        [Fact(DisplayName = "Single ValueType test")]
        public void SingleValueTypeTest()
        {
            Types.Of<int>().ShouldBe(typeof(int));
            Types.Of<int>(TypeOfOptions.Underlying).ShouldBe(typeof(int));
            Types.Of<int?>().ShouldBe(typeof(int?));
            Types.Of<int?>(TypeOfOptions.Underlying).ShouldBe(typeof(int));
        }

        [Fact(DisplayName = "Single EnumType test")]
        public void SingleEnumTypeTest()
        {
            Types.Of<Int16Enum>().ShouldBe(typeof(Int16Enum));
            Types.Of<Int16Enum>(TypeOfOptions.Underlying).ShouldBe(typeof(Int16Enum));
            Types.Of<Int16Enum?>().ShouldBe(typeof(Int16Enum?));
            Types.Of<Int16Enum?>(TypeOfOptions.Underlying).ShouldBe(typeof(Int16Enum));
        }

        [Fact(DisplayName = "Multi ValueType test")]
        public void MultiValueTypeTest()
        {
            int? a = 0;
            long? b = 1;
            string c = "2";
            DateTime d = DateTime.Now;
            Exception e = new ArgumentNullException();

            var types = Types.Of(new object[] {a, b, c, d, e}).ToList();

            types.Count.ShouldBe(5);
            types[0].ShouldBe(typeof(int?));
            types[1].ShouldBe(typeof(long?));
            types[2].ShouldBe(typeof(string));
            types[3].ShouldBe(typeof(DateTime));
            types[4].ShouldBe(typeof(ArgumentNullException));

            types = Types.Of(new object[] {a, b, c, d, e}, TypeOfOptions.Underlying).ToList();

            types.Count.ShouldBe(5);
            types[0].ShouldBe(typeof(int));
            types[1].ShouldBe(typeof(long));
            types[2].ShouldBe(typeof(string));
            types[3].ShouldBe(typeof(DateTime));
            types[4].ShouldBe(typeof(ArgumentNullException));
        }

        [Fact(DisplayName = "Multi ValueType with null test")]
        public void MultiValueTypeWithNullTest()
        {
            int? a = 0;
            long? b = 1;
            string c = "2";
            DateTime d = DateTime.Now;
            Exception e = new ArgumentNullException();
            object f = null;

            var types = Types.Of(new object[] {a, b, c, d, e, f}).ToList();

            types.Count.ShouldBe(6);
            types[0].ShouldBe(typeof(int));
            types[1].ShouldBe(typeof(long));
            types[2].ShouldBe(typeof(string));
            types[3].ShouldBe(typeof(DateTime));
            types[4].ShouldBe(typeof(ArgumentNullException));
            types[5].ShouldBeNull();

            types = Types.Of(new object[] {a, b, c, d, e, f}, TypeOfOptions.Underlying).ToList();

            types.Count.ShouldBe(6);
            types[0].ShouldBe(typeof(int));
            types[1].ShouldBe(typeof(long));
            types[2].ShouldBe(typeof(string));
            types[3].ShouldBe(typeof(DateTime));
            types[4].ShouldBe(typeof(ArgumentNullException));
            types[5].ShouldBeNull();
        }

        [Fact(DisplayName = "Multi ValueType with null test")]
        public void MultiValueTypeWithEnumAndNullTest()
        {
            int? a = 0;
            long? b = 1;
            string c = "2";
            DateTime d = DateTime.Now;
            Exception e = new ArgumentNullException();
            object f = null;
            Int16Enum g = Int16Enum.A;
            Int32Enum? h = null;
            Int64Enum? i = Int64Enum.C;

            var types = Types.Of(new object[] {a, b, c, d, e, f,g,h,i}).ToList();

            types.Count.ShouldBe(9);
            types[0].ShouldBe(typeof(int));
            types[1].ShouldBe(typeof(long));
            types[2].ShouldBe(typeof(string));
            types[3].ShouldBe(typeof(DateTime));
            types[4].ShouldBe(typeof(ArgumentNullException));
            types[5].ShouldBeNull();
            types[6].ShouldBe(typeof(Int16Enum));
            types[7].ShouldBeNull();
            types[8].ShouldBe(typeof(Int64Enum));

            types = Types.Of(new object[] {a, b, c, d, e, f,g,h,i}, TypeOfOptions.Underlying).ToList();

            types.Count.ShouldBe(9);
            types[0].ShouldBe(typeof(int));
            types[1].ShouldBe(typeof(long));
            types[2].ShouldBe(typeof(string));
            types[3].ShouldBe(typeof(DateTime));
            types[4].ShouldBe(typeof(ArgumentNullException));
            types[5].ShouldBeNull();
            types[6].ShouldBe(typeof(Int16Enum));
            types[7].ShouldBeNull();
            types[8].ShouldBe(typeof(Int64Enum));
        }
    }
}