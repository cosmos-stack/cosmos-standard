using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ListUT.Contains")]
    public class CollsContainsTests
    {
        [Fact(DisplayName = "Enumerable instance contains item with given condition test")]
        public void ContainsWithGivenExpressionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = Colls.Contains(list, v => v > 9);
            var val1 = Colls.Contains(list, v => v > 10);
            var val2 = Colls.Contains(list, v => v > 11);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance contains item without condition at least test")]
        public void ContainsAtLeastWithoutExpressionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = Colls.ContainsAtLeast(list, 9);
            var val1 = Colls.ContainsAtLeast(list, 10);
            var val2 = Colls.ContainsAtLeast(list, 11);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance contains item with given condition at least test")]
        public void ContainsAtLeastWithGivenExpressionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = Colls.ContainsAtLeast(list, v => v > 9, 1);
            var val1 = Colls.ContainsAtLeast(list, v => v > 10, 0);
            var val2 = Colls.ContainsAtLeast(list, v => v > 11, 2);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance contains item as queryable at least test")]
        public void ContainsAtLeastAsQueryExpressionTest()
        {
            var query = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}.AsQueryable();

            var val0 = Colls.ContainsAtLeast(query, 9);
            var val1 = Colls.ContainsAtLeast(query, 10);
            var val2 = Colls.ContainsAtLeast(query, 11);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance contains item with given condition test")]
        public void ExtensionsMethodForContainsWithGivenExpressionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = list.Contains(v => v > 9);
            var val1 = list.Contains(v => v > 10);
            var val2 = list.Contains(v => v > 11);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance contains item without condition at least test")]
        public void ExtensionsMethodForContainsAtLeastWithoutExpressionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = list.ContainsAtLeast(9);
            var val1 = list.ContainsAtLeast(10);
            var val2 = list.ContainsAtLeast(11);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance contains item with given condition at least test")]
        public void ExtensionsMethodForContainsAtLeastWithGivenExpressionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = list.ContainsAtLeast(v => v > 9, 1);
            var val1 = list.ContainsAtLeast(v => v > 10, 0);
            var val2 = list.ContainsAtLeast(v => v > 11, 2);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance contains item as queryable at least test")]
        public void ExtensionsMethodForContainsAtLeastAsQueryExpressionTest()
        {
            var query = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}.AsQueryable();

            var val0 = query.ContainsAtLeast(9);
            var val1 = query.ContainsAtLeast(10);
            var val2 = query.ContainsAtLeast(11);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance be contains item with comparer test")]
        public void BeContainWithComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var comparer = EqualityComparer<int>.Default;

            var val0 = Colls.BeContainedIn(10, list, comparer);
            var val1 = Colls.BeContainedIn(11, list, comparer);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance be contains item without comparer test")]
        public void BeContainWithoutComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = Colls.BeContainedIn(10, list);
            var val1 = Colls.BeContainedIn(11, list);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance be contains item with condition and comparer test")]
        public void BeContainWithGivenExpressionAndWithComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var comparer = EqualityComparer<int>.Default;

            var val0 = Colls.BeContainedIn(9, list, v => v > 8, comparer);
            var val1 = Colls.BeContainedIn(10, list, v => v > 10, comparer);
            var val2 = Colls.BeContainedIn(11, list, v => v > 11, comparer);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Enumerable instance be contains item with condition and without comparer test")]
        public void BeContainWithGivenExpressionAndWithoutComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = Colls.BeContainedIn(9, list, v => v > 8);
            var val1 = Colls.BeContainedIn(10, list, v => v > 10);
            var val2 = Colls.BeContainedIn(11, list, v => v > 11);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance be contains item with comparer test")]
        public void ExtensionsMethodForBeContainWithComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var comparer = EqualityComparer<int>.Default;

            var val0 = 10.BeContainedIn(list, comparer);
            var val1 = 11.BeContainedIn(list, comparer);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance be contains item without comparer test")]
        public void ExtensionsMethodForBeContainWithoutComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = 10.BeContainedIn(list);
            var val1 = 11.BeContainedIn(list);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance be contains item with condition and comparer test")]
        public void ExtensionsMethodForBeContainWithGivenExpressionAndWithComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var comparer = EqualityComparer<int>.Default;

            var val0 = 9.BeContainedIn(list, v => v > 8, comparer);
            var val1 = 10.BeContainedIn(list, v => v > 10, comparer);
            var val2 = 11.BeContainedIn(list, v => v > 11, comparer);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance be contains item with condition and without comparer test")]
        public void ExtensionsMethodForBeContainWithGivenExpressionAndWithoutComparerTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var val0 = 9.BeContainedIn(list, v => v > 8);
            var val1 = 10.BeContainedIn(list, v => v > 10);
            var val2 = 11.BeContainedIn(list, v => v > 11);

            val0.ShouldBeTrue();
            val1.ShouldBeFalse();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance be contains item with params and without comparer test")]
        public void ExtensionsMethodForBeContainWithParamsItemsWithoutComparerTest()
        {
            var val0 = 9.BeContainedIn(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10);
            var val1 = 10.BeContainedIn(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10);
            var val2 = 11.BeContainedIn(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Extensions method for Enumerable instance be contains item with params and comparer test")]
        public void ExtensionsMethodForBeContainWithParamsItemsWithGivenComparerTest()
        {
            var comparer = EqualityComparer<int>.Default;

            var val0 = 9.BeContainedIn(comparer, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10);
            var val1 = 10.BeContainedIn(comparer, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10);
            var val2 = 11.BeContainedIn(comparer, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10);

            val0.ShouldBeTrue();
            val1.ShouldBeTrue();
            val2.ShouldBeFalse();
        }

        [Fact(DisplayName = "Unique count with default ValueCalculator test")]
        public void UniqueCountWithDefaultValueCalculatorTest()
        {
            var list = new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3};

            var val = list.Count;
            var val2 = Colls.UniqueCount(list);

            val.ShouldBe(9);
            val2.ShouldBe(3);
        }

        [Fact(DisplayName = "Unique count with custom ValueCalculator test")]
        public void UniqueCountWithCustomValueCalculatorTest()
        {
            var list = new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3};

            var val = list.Count;
            var val2 = Colls.UniqueCount(list, v => v * 0);

            val.ShouldBe(9);
            val2.ShouldBe(1);
        }

        [Fact(DisplayName = "Extension method for Unique count with default ValueCalculator test")]
        public void ExtensionMethodForUniqueCountWithDefaultValueCalculatorTest()
        {
            var list = new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3};

            var val = list.Count;
            var val2 = list.UniqueCount();

            val.ShouldBe(9);
            val2.ShouldBe(3);
        }

        [Fact(DisplayName = "Extension method for Unique count with custom ValueCalculator test")]
        public void ExtensionMethodForUniqueCountWithCustomValueCalculatorTest()
        {
            var list = new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3};

            var val = list.Count;
            var val2 = list.UniqueCount(v => v * 0);

            val.ShouldBe(9);
            val2.ShouldBe(1);
        }
    }
}