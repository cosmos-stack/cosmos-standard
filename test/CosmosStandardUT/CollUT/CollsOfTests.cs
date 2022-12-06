using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;

namespace CosmosStandardUT.CollUT;

[Trait("CollUT", "ListUT.Of")]
public class CollsOfTests
{
    [Fact(DisplayName = "Use Colls.Of and returns an empty list test")]
    public void CollOfListAndReturnsAnEmptyListTest()
    {
        var list = Colls.OfList<int>();

        list.ShouldNotBeNull();
        list.ShouldBeEmpty();
    }

    [Fact(DisplayName = "Use Colls.Of and returns a list with given params test")]
    public void CollOfListAndReturnsListWithGivenParamsTest()
    {
        var list = Colls.OfList(1, 2, 3, 4, 5);

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Use Colls.Of and returns a list with given list test")]
    public void CollOfListAndReturnsListWithGivenListTest()
    {
        var list = Colls.OfList<int>(new List<int> {1, 2, 3, 4, 5});

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Use Colls.Of and returns a list with given list sequence test")]
    public void CollOfListAndReturnsListWithGivenListSequenceTest()
    {
        var list0 = new List<int> {1, 2};
        var list1 = new List<int> {3, 4};
        var list2 = new List<int> {5};

        var listSrc = new List<List<int>> {list0, list1, list2}.ToArray();

        var list = Colls.OfList<int>(listSrc);

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Use Colls.Of and returns a list with given list params test")]
    public void CollOfListAndReturnsListWithGivenListParamsTest()
    {
        var list0 = new List<int> {1, 2};
        var list1 = new List<int> {3, 4};
        var list2 = new List<int> {5};

        var list = Colls.OfList<int>(list0, list1, list2);

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }

    [Fact(DisplayName = "Use ReadOnlyColls.Of and returns a readonly list with given params test")]
    public void ReadOnlyCollsOfListWithGivenParamsTest()
    {
        var list = ReadOnlyColls.OfList(1, 2, 3, 4, 5);

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }
        
    [Fact(DisplayName = "Use ReadOnlyColls.Of and returns a readonly list with given list sequence test")]
    public void ReadOnlyCollOfListAndReturnsListWithGivenListSequenceTest()
    {
        var list0 = new List<int> {1, 2};
        var list1 = new List<int> {3, 4};
        var list2 = new List<int> {5};

        var listSrc = new List<List<int>> {list0, list1, list2}.ToArray();

        var list = ReadOnlyColls.OfList<int>(listSrc);

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }
        
    [Fact(DisplayName = "Use ReadOnlyColls.Of and returns a readonly list with given list params test")]
    public void ReadOnlyCollOfListAndReturnsListWithGivenListParamsTest()
    {
        var list0 = new List<int> {1, 2};
        var list1 = new List<int> {3, 4};
        var list2 = new List<int> {5};

        var list = ReadOnlyColls.OfList<int>(list0, list1, list2);

        list.ShouldNotBeNull();
        list.ShouldNotBeEmpty();
        list.Count.ShouldBe(5);
        list[0].ShouldBe(1);
        list[1].ShouldBe(2);
        list[2].ShouldBe(3);
        list[3].ShouldBe(4);
        list[4].ShouldBe(5);
    }
}