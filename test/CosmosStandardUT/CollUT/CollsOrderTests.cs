using System.Collections.Generic;
using System.Linq;
using CosmosStack.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ListUT.Order")]
    public class CollsOrderTests
    {
        [Fact(DisplayName = "Order by random test")]
        public void CollOrderByRandomTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = Colls.OrderByRandom(list);

            target.Count().ShouldBe(10);
            Signature(list).ShouldNotBe(Signature(target));
        }

        [Fact(DisplayName = "Extension method for Order by random test")]
        public void ExtensionMethodForCollOrderByRandomTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = list.OrderByRandom();

            target.Count().ShouldBe(10);
            Signature(list).ShouldNotBe(Signature(target));
        }

        [Fact(DisplayName = "Order by shuffle test")]
        public void CollOrderByShuffleTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            Colls.OrderByShuffle(list);

            Signature(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}).ShouldNotBe(Signature(list));
        }

        [Fact(DisplayName = "Order by shuffle in 10 times test")]
        public void CollOrderByShuffleInTenTimesTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            Colls.OrderByShuffle(list, 10);

            Signature(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}).ShouldNotBe(Signature(list));
        }

        [Fact(DisplayName = "Order by shuffle and returns a new instance test")]
        public void CollOrderByShuffleAndReturnsNewInstanceTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = Colls.OrderByShuffleAndNewInstance(list);

            target.Count.ShouldBe(10);
            Signature(list).ShouldNotBe(Signature(target));
        }

        [Fact(DisplayName = "Order by shuffle and returns a new instance in 10 times test")]
        public void CollOrderByShuffleAndReturnsNewInstanceInTenTimesTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = Colls.OrderByShuffleAndNewInstance(list, 10);

            target.Count.ShouldBe(10);
            Signature(list).ShouldNotBe(Signature(target));
        }

        [Fact(DisplayName = "Extension method for Order by shuffle test")]
        public void ExtensionMethodForCollOrderByShuffleTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            list.OrderByShuffle();

            Signature(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}).ShouldNotBe(Signature(list));
        }

        [Fact(DisplayName = "Extension method for Order by shuffle in 10 times test")]
        public void ExtensionMethodForCollOrderByShuffleInTenTimesTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            list.OrderByShuffle(10);

            Signature(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}).ShouldNotBe(Signature(list));
        }

        [Fact(DisplayName = "Extension method for Order by shuffle and returns a new instance test")]
        public void ExtensionMethodForCollOrderByShuffleAndReturnsNewInstanceTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = list.OrderByShuffleAndNewInstance();

            target.Count.ShouldBe(10);
            Signature(list).ShouldNotBe(Signature(target));
        }

        [Fact(DisplayName = "Extension method for Order by shuffle and returns a new instance in 10 times test")]
        public void ExtensionMethodForCollOrderByShuffleAndReturnsNewInstanceInTenTimesTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = list.OrderByShuffleAndNewInstance(10);

            target.Count.ShouldBe(10);
            Signature(list).ShouldNotBe(Signature(target));
        }

        private static long Signature(IEnumerable<int> list)
        {
            var val = 0L;

            var indexedSequence = CollConv.ToIndexedSequence(list);

            foreach (var pair in indexedSequence)
            {
                val += (pair.Key + 1) * pair.Value;
            }

            return val;
        }
    }
}