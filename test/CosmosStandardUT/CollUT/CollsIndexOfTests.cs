using System.Collections.Generic;
using Cosmos.Collections;
using CosmosStack.Collections;
using Shouldly;
using Xunit;
using Colls = CosmosStack.Collections.Colls;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ListUT.IndexOf")]
    public class CollsIndexOfTests
    {
        [Fact(DisplayName = "Getting index of colls test")]
        public void GettingIndexOfCollTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var index = Colls.IndexOf(list, 3);

            index.ShouldBe(2);
        }

        [Fact(DisplayName = "Getting index of colls with default comparer test")]
        public void GettingIndexOfCollWithDefaultComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var index = Colls.IndexOf(list, 3, EqualityComparer<int>.Default);

            index.ShouldBe(2);
        }

        [Fact(DisplayName = "Getting index of colls with custom comparer test")]
        public void GettingIndexOfCollWithCustomComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var comparer = new Int32Comparer();

            var index = Colls.IndexOf(list, 3, comparer); //y=3

            index.ShouldBe(1); //x=2, so x+1 = y
        }

        [Fact(DisplayName = "Extensions method for Getting index of colls test")]
        public void ExtensionMethodForGettingIndexOfCollTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var index = list.IndexOf(3);

            index.ShouldBe(2);
        }

        [Fact(DisplayName = "Extensions method for Getting index of colls with default comparer test")]
        public void ExtensionMethodForGettingIndexOfCollWithDefaultComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var index = list.IndexOf(3, EqualityComparer<int>.Default);

            index.ShouldBe(2);
        }

        [Fact(DisplayName = "Extensions method for Getting index of colls with custom comparer test")]
        public void ExtensionMethodForGettingIndexOfCollWithCustomComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var comparer = new Int32Comparer();

            var index = list.IndexOf(3, comparer); //y=3

            index.ShouldBe(1); //x=2, so x+1 = y
        }

        internal class Int32Comparer : EqualityComparer<int>
        {
            public override bool Equals(int x, int y)
            {
                return x + 1 == y;
            }

            public override int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}