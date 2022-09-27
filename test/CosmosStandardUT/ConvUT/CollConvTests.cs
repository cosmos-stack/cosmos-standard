using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;
using Cosmos.Reflection;

namespace CosmosStandardUT.ConvUT;

[Trait("ConvUT", "Coll")]
public class CollConvTests
{
    [Fact(DisplayName = "Enumerator to Enumerable instance test")]
    public void EnumeratorToEnumerableTest()
    {
        var source = new List<string> {"1", "2", "3", "4", "5"};
        using var enumerator = source.GetEnumerator();
        var target = CollConv.ToEnumerable(enumerator);

        var targetList = target.ToList();

        targetList.ShouldNotBeNull();
        targetList.Count.ShouldBe(5);
        targetList[0].ShouldBe("1");
        targetList[1].ShouldBe("2");
        targetList[2].ShouldBe("3");
        targetList[3].ShouldBe("4");
        targetList[4].ShouldBe("5");
    }

    [Fact(DisplayName = "Enumerator to Enumerable (after) instance test")]
    public void EnumeratorToEnumerableAfterTest()
    {
        var source = new List<string> {"1", "2", "3", "4", "5"};
        using var enumerator = source.GetEnumerator();
        var target = CollConv.ToEnumerableAfter(enumerator);

        var targetList = target.ToList();

        targetList.ShouldNotBeNull();
        targetList.Count.ShouldBe(6);
        targetList[0].ShouldBe(default);
        targetList[1].ShouldBe("1");
        targetList[2].ShouldBe("2");
        targetList[3].ShouldBe("3");
        targetList[4].ShouldBe("4");
        targetList[5].ShouldBe("5");
    }

    [Fact(DisplayName = "Enumerable to sequence instance test")]
    public void IndexedSequenceTest()
    {
        var source = new List<string> {"1", "2", "3", "4", "5"};
        var sequence = CollConv.ToIndexedSequence(source).ToList();

        sequence.ShouldNotBeNull();
        sequence.Count.ShouldBe(5);

        sequence[0].Key.ShouldBe(0);
        sequence[1].Key.ShouldBe(1);
        sequence[2].Key.ShouldBe(2);
        sequence[3].Key.ShouldBe(3);
        sequence[4].Key.ShouldBe(4);

        sequence[0].Value.ShouldBe("1");
        sequence[1].Value.ShouldBe("2");
        sequence[2].Value.ShouldBe("3");
        sequence[3].Value.ShouldBe("4");
        sequence[4].Value.ShouldBe("5");
    }

    [Fact(DisplayName = "Enumerable to string sorted array instance with given comparison test")]
    public void SortedStringArrayWithGivenComparisonTest()
    {
        Comparison<string> comparer = (i, j) => string.Compare(i, j, StringComparison.Ordinal);
        var list = new List<string> {"5", "4", "1", "3", "2"};
        var target = CollConv.ToSortedArray(list, comparer);

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe("1");
        target[1].ShouldBe("2");
        target[2].ShouldBe("3");
        target[3].ShouldBe("4");
        target[4].ShouldBe("5");
    }

    [Fact(DisplayName = "Enumerable to int32 sorted array instance with given comparison test")]
    public void SortedIntArrayGivenComparisonTest()
    {
        Comparison<int> comparer = (i, j) => i.CompareTo(j);
        var list = new List<int> {5, 4, 1, 3, 2};
        var target = CollConv.ToSortedArray(list, comparer);

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe(1);
        target[1].ShouldBe(2);
        target[2].ShouldBe(3);
        target[3].ShouldBe(4);
        target[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Enumerable to string sorted array instance with default comparison test")]
    public void SortedStringArrayWithDefaultComparisonTest()
    {
        var list = new List<string> {"5", "4", "1", "3", "2"};
        var target = CollConv.ToSortedArray(list);

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe("1");
        target[1].ShouldBe("2");
        target[2].ShouldBe("3");
        target[3].ShouldBe("4");
        target[4].ShouldBe("5");
    }

    [Fact(DisplayName = "Enumerable to int32 sorted array instance with default comparison test")]
    public void SortedIntArrayDefaultComparisonTest()
    {
        var list = new List<int> {5, 4, 1, 3, 2};
        var target = CollConv.ToSortedArray(list);

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe(1);
        target[1].ShouldBe(2);
        target[2].ShouldBe(3);
        target[3].ShouldBe(4);
        target[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Enumerable to nullable enumerable test")]
    public void ConvertToONullableListTest()
    {
        var originalArray = new int[5];
        originalArray[0] = 1;
        originalArray[1] = 2;
        originalArray[2] = 3;
        originalArray[4] = 5;
        var list = originalArray.ToList();
        var optionals = CollConv.AsOptionals(list).ToList();

        optionals.ShouldNotBeNull();
        optionals.Count.ShouldBe(5);

        optionals[0].HasValue.ShouldBeTrue();
        optionals[1].HasValue.ShouldBeTrue();
        optionals[2].HasValue.ShouldBeTrue();
        optionals[3].HasValue.ShouldBeTrue();
        optionals[4].HasValue.ShouldBeTrue();

        optionals[0]!.Value.ShouldBe(1);
        optionals[1]!.Value.ShouldBe(2);
        optionals[2]!.Value.ShouldBe(3);
        optionals[3]!.Value.ShouldBe(0);
        optionals[4]!.Value.ShouldBe(5);
    }

    [Fact(DisplayName = "Enumerable to enumerable proxy test")]
    public void ConvertToProxyListTest()
    {
        var source = new List<int> {1, 2, 3, 4, 5};
        var proxy = CollConv.AsEnumerableProxy(source);

        proxy.ShouldNotBeNull();
        int refVal = 0;
        foreach (var val in proxy)
        {
            val.ShouldBe(++refVal);
        }
    }

    [Fact(DisplayName = "Extension method for Enumerator to Enumerable instance test")]
    public void ExtensionMethodForEnumeratorToEnumerableTest()
    {
        var source = new List<string> {"1", "2", "3", "4", "5"};
        using var enumerator = source.GetEnumerator();
        var target = enumerator.ToEnumerable();

        var targetList = target.ToList();

        targetList.ShouldNotBeNull();
        targetList.Count.ShouldBe(5);
        targetList[0].ShouldBe("1");
        targetList[1].ShouldBe("2");
        targetList[2].ShouldBe("3");
        targetList[3].ShouldBe("4");
        targetList[4].ShouldBe("5");
    }

    [Fact(DisplayName = "Extension method for Enumerator to Enumerable (after) instance test")]
    public void ExtensionMethodForEnumeratorToEnumerableAfterTest()
    {
        var source = new List<string> {"1", "2", "3", "4", "5"};
        using var enumerator = source.GetEnumerator();
        var target = enumerator.ToEnumerableAfter();

        var targetList = target.ToList();

        targetList.ShouldNotBeNull();
        targetList.Count.ShouldBe(6);
        targetList[0].ShouldBe(default);
        targetList[1].ShouldBe("1");
        targetList[2].ShouldBe("2");
        targetList[3].ShouldBe("3");
        targetList[4].ShouldBe("4");
        targetList[5].ShouldBe("5");
    }

    [Fact(DisplayName = "Extension method for Enumerable to sequence instance test")]
    public void ExtensionMethodForIndexedSequenceTest()
    {
        var source = new List<string> {"1", "2", "3", "4", "5"};
        var sequence = source.ToIndexedSequence().ToList();

        sequence.ShouldNotBeNull();
        sequence.Count.ShouldBe(5);

        sequence[0].Key.ShouldBe(0);
        sequence[1].Key.ShouldBe(1);
        sequence[2].Key.ShouldBe(2);
        sequence[3].Key.ShouldBe(3);
        sequence[4].Key.ShouldBe(4);

        sequence[0].Value.ShouldBe("1");
        sequence[1].Value.ShouldBe("2");
        sequence[2].Value.ShouldBe("3");
        sequence[3].Value.ShouldBe("4");
        sequence[4].Value.ShouldBe("5");
    }

    [Fact(DisplayName = "Extension method for Enumerable to string sorted array instance with given comparison test")]
    public void ExtensionMethodForSortedStringArrayWithGivenComparisonTest()
    {
        Comparison<string> comparer = (i, j) => string.Compare(i, j, StringComparison.Ordinal);
        var list = new List<string> {"5", "4", "1", "3", "2"};
        var target = list.ToSortedArray(comparer);

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe("1");
        target[1].ShouldBe("2");
        target[2].ShouldBe("3");
        target[3].ShouldBe("4");
        target[4].ShouldBe("5");
    }

    [Fact(DisplayName = "Extension method for Enumerable to int32 sorted array instance with given comparison test")]
    public void ExtensionMethodForSortedIntArrayGivenComparisonTest()
    {
        Comparison<int> comparer = (i, j) => i.CompareTo(j);
        var list = new List<int> {5, 4, 1, 3, 2};
        var target = list.ToSortedArray(comparer);

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe(1);
        target[1].ShouldBe(2);
        target[2].ShouldBe(3);
        target[3].ShouldBe(4);
        target[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Extension method for Enumerable to string sorted array instance with default comparison test")]
    public void ExtensionMethodForSortedStringArrayWithDefaultComparisonTest()
    {
        var list = new List<string> {"5", "4", "1", "3", "2"};
        var target = list.ToSortedArray();

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe("1");
        target[1].ShouldBe("2");
        target[2].ShouldBe("3");
        target[3].ShouldBe("4");
        target[4].ShouldBe("5");
    }

    [Fact(DisplayName = "Extension method for Enumerable to int32 sorted array instance with default comparison test")]
    public void ExtensionMethodForSortedIntArrayDefaultComparisonTest()
    {
        var list = new List<int> {5, 4, 1, 3, 2};
        var target = list.ToSortedArray();

        target.ShouldNotBeNull();
        target.ShouldNotBeEmpty();
        target.Length.ShouldBe(5);

        target[0].ShouldBe(1);
        target[1].ShouldBe(2);
        target[2].ShouldBe(3);
        target[3].ShouldBe(4);
        target[4].ShouldBe(5);
    }

    [Fact(DisplayName = "ReadOnly Enumerable to normal Enumerable test")]
    public void ReadOnlyListToNormalListTest()
    {
        var readOnlyList = new List<int> {1, 2}.AsReadOnly();
        var list = ReadOnlyCollConv.AsList(readOnlyList);
        list.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Extension method for ReadOnly Enumerable to normal Enumerable test")]
    public void ExtensionMethodForReadOnlyListToNormalListTest()
    {
        var readOnlyList = new List<int> {1, 2}.AsReadOnly();
        var list = readOnlyList.AsList();
        list.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Extension method for normal Enumerable to ReadOnly Enumerable test")]
    public void ExtensionMethodForNormalEnumerableToReadOnlyOneTest()
    {
        IEnumerable<int> v = new List<int> {1, 2, 3, 4, 5};
        var coll = v.AsReadOnly();
        TypeReflections.IsInterfaceDefined<IReadOnlyList<int>>(coll.GetType()).ShouldBeTrue();
    }
}