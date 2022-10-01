using System.Collections.Generic;
using Cosmos.Collections;

namespace CosmosStandardUT.CollUT;

[Trait("CollUT", "ListUT.Search")]
public class CollsSearchTests
{
    [Fact(DisplayName = "Search one item in another list test")]
    public void SearchOneItemInListTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = Colls.BinarySearch(list, 3);

        val.ShouldBe(2);
    }

    [Fact(DisplayName = "Search one item in another list with map test")]
    public void SearchOneItemInListWithMapTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = Colls.BinarySearch(list, v => v + 1, 3); // 2 + 1 = 3, so matched 2

        val.ShouldBe(1);
    }

    [Fact(DisplayName = "Search one item in another list with index and length test")]
    public void SearchOneItemInListWithStartAndLengthTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = Colls.BinarySearch(list, 2, 1, 3);
        var val2 = Colls.BinarySearch(list, 1, 1, 3);
        var val3 = Colls.BinarySearch(list, 1, 3, 3);
        var val4 = Colls.BinarySearch(list, 1, 1, 3);
        var val5 = Colls.BinarySearch(list, 5, 1, 3);

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Search one item in another list with index and length, and map test")]
    public void SearchOneItemInListWithMapAndStartAndLengthTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = Colls.BinarySearch(list, 2, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val2 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val3 = Colls.BinarySearch(list, 1, 3, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val4 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val5 = Colls.BinarySearch(list, 5, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Search one item in another list with comparer test")]
    public void SearchOneItemInListWithComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = Colls.BinarySearch(list, 3, Comparer<int>.Default);

        val.ShouldBe(2);
    }

    [Fact(DisplayName = "Search one item in another list with map and comparer test")]
    public void SearchOneItemInListWithMapAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = Colls.BinarySearch(list, v => v + 1, 3, Comparer<int>.Default);

        val.ShouldBe(1);
    }

    [Fact(DisplayName = "Search one item in another list with index and length, and comparer test")]
    public void SearchOneItemInListWithStartAndLengthAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = Colls.BinarySearch(list, 2, 1, 3, Comparer<int>.Default);
        var val2 = Colls.BinarySearch(list, 1, 1, 3, Comparer<int>.Default);
        var val3 = Colls.BinarySearch(list, 1, 3, 3, Comparer<int>.Default);
        var val4 = Colls.BinarySearch(list, 1, 1, 3, Comparer<int>.Default);
        var val5 = Colls.BinarySearch(list, 5, 1, 3, Comparer<int>.Default);

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Search one item in another list with index and length, and map, and comparer test")]
    public void SearchOneItemInListWithMapAndStartAndLengthTestAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = Colls.BinarySearch(list, 2, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val2 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val3 = Colls.BinarySearch(list, 1, 3, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val4 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val5 = Colls.BinarySearch(list, 5, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }
        
    [Fact(DisplayName = "Search one item in another readonly list test")]
    public void SearchOneItemInReadOnlyListTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val = Colls.BinarySearch(list, 3);

        val.ShouldBe(2);
    }

    [Fact(DisplayName = "Search one item in another readonly list with map test")]
    public void SearchOneItemInReadOnlyListWithMapTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val = Colls.BinarySearch(list, v => v + 1, 3); // 2 + 1 = 3, so matched 2

        val.ShouldBe(1);
    }

    [Fact(DisplayName = "Search one item in another readonly list with index and length test")]
    public void SearchOneItemInReadOnlyListWithStartAndLengthTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val1 = Colls.BinarySearch(list, 2, 1, 3);
        var val2 = Colls.BinarySearch(list, 1, 1, 3);
        var val3 = Colls.BinarySearch(list, 1, 3, 3);
        var val4 = Colls.BinarySearch(list, 1, 1, 3);
        var val5 = Colls.BinarySearch(list, 5, 1, 3);

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Search one item in another readonly list with index and length, and map test")]
    public void SearchOneItemInReadOnlyListWithMapAndStartAndLengthTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val1 = Colls.BinarySearch(list, 2, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val2 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val3 = Colls.BinarySearch(list, 1, 3, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val4 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val5 = Colls.BinarySearch(list, 5, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Search one item in another readonly list with comparer test")]
    public void SearchOneItemInReadOnlyListWithComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val = Colls.BinarySearch(list, 3, Comparer<int>.Default);

        val.ShouldBe(2);
    }

    [Fact(DisplayName = "Search one item in another readonly list with map and comparer test")]
    public void SearchOneItemInReadOnlyListWithMapAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val = Colls.BinarySearch(list, v => v + 1, 3, Comparer<int>.Default);

        val.ShouldBe(1);
    }

    [Fact(DisplayName = "Search one item in another readonly list with index and length, and comparer test")]
    public void SearchOneItemInReadOnlyListWithStartAndLengthAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val1 = Colls.BinarySearch(list, 2, 1, 3, Comparer<int>.Default);
        var val2 = Colls.BinarySearch(list, 1, 1, 3, Comparer<int>.Default);
        var val3 = Colls.BinarySearch(list, 1, 3, 3, Comparer<int>.Default);
        var val4 = Colls.BinarySearch(list, 1, 1, 3, Comparer<int>.Default);
        var val5 = Colls.BinarySearch(list, 5, 1, 3, Comparer<int>.Default);

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Search one item in another readonly list with index and length, and map, and comparer test")]
    public void SearchOneItemInReadOnlyListWithMapAndStartAndLengthTestAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7}.AsReadOnly();

        var val1 = Colls.BinarySearch(list, 2, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val2 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val3 = Colls.BinarySearch(list, 1, 3, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val4 = Colls.BinarySearch(list, 1, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val5 = Colls.BinarySearch(list, 5, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }
        
    [Fact(DisplayName = "Extensions Method for Search one item in another list test")]
    public void ExtensionMethodForSearchOneItemInListTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = list.BinarySearch( 3);

        val.ShouldBe(2);
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with map test")]
    public void ExtensionMethodForSearchOneItemInListWithMapTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = list.BinarySearch( v => v + 1, 3); // 2 + 1 = 3, so matched 2

        val.ShouldBe(1);
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with index and length test")]
    public void ExtensionMethodForSearchOneItemInListWithStartAndLengthTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = list.BinarySearch( 2, 1, 3);
        var val2 = list.BinarySearch( 1, 1, 3);
        var val3 = list.BinarySearch( 1, 3, 3);
        var val4 = list.BinarySearch( 1, 1, 3);
        var val5 = list.BinarySearch( 5, 1, 3);

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with index and length, and map test")]
    public void ExtensionMethodForSearchOneItemInListWithMapAndStartAndLengthTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = list.BinarySearch( 2, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val2 = list.BinarySearch( 1, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val3 = list.BinarySearch( 1, 3, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val4 = list.BinarySearch( 1, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3
        var val5 = list.BinarySearch( 5, 1, v => v + 1, 4); // 3 + 1 = 4, so matched 3

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with comparer test")]
    public void ExtensionMethodForSearchOneItemInListWithComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = list.BinarySearch( 3, Comparer<int>.Default);

        val.ShouldBe(2);
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with map and comparer test")]
    public void ExtensionMethodForSearchOneItemInListWithMapAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val = list.BinarySearch( v => v + 1, 3, Comparer<int>.Default);

        val.ShouldBe(1);
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with index and length, and comparer test")]
    public void ExtensionMethodForSearchOneItemInListWithStartAndLengthAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = list.BinarySearch( 2, 1, 3, Comparer<int>.Default);
        var val2 = list.BinarySearch( 1, 1, 3, Comparer<int>.Default);
        var val3 = list.BinarySearch( 1, 3, 3, Comparer<int>.Default);
        var val4 = list.BinarySearch( 1, 1, 3, Comparer<int>.Default);
        var val5 = list.BinarySearch( 5, 1, 3, Comparer<int>.Default);

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }

    [Fact(DisplayName = "Extensions Method for Search one item in another list with index and length, and map, and comparer test")]
    public void ExtensionMethodForSearchOneItemInListWithMapAndStartAndLengthTestAndComparerTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

        var val1 = list.BinarySearch(2, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val2 = list.BinarySearch( 1, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val3 = list.BinarySearch( 1, 3, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val4 = list.BinarySearch( 1, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3
        var val5 = list.BinarySearch( 5, 1, v => v + 1, 4, Comparer<int>.Default); // 3 + 1 = 4, so matched 3

        val1.ShouldBe(2);
        val2.ShouldBeNegative();
        val3.ShouldBe(2);
        val4.ShouldBeNegative();
        val5.ShouldBeNegative();
    }
}