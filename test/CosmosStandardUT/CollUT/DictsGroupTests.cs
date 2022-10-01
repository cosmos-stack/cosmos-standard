using System.Collections.Generic;
using Cosmos.Collections;

namespace CosmosStandardUT.CollUT;

[Trait("CollUT", "DictUT.Group")]
public class DictsGroupTests
{
    [Fact(DisplayName = "Group a list to a dictionary test")]
    public void GroupAsDictionaryTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
        var dict = Dicts.GroupByAsDictionary(list, v => v % 2);

        dict.Count.ShouldBe(2); // 0 or 1
        dict[0].Count.ShouldBe(4);
        dict[1].Count.ShouldBe(5);
            
        dict[0][0].ShouldBe(2);
        dict[0][1].ShouldBe(4);
        dict[0][2].ShouldBe(6);
        dict[0][3].ShouldBe(8);
            
        dict[1][0].ShouldBe(1);
        dict[1][1].ShouldBe(3);
        dict[1][2].ShouldBe(5);
        dict[1][3].ShouldBe(7);
        dict[1][4].ShouldBe(9);
    }

    [Fact(DisplayName = "Group a list to a dictionary with value func test")]
    public void GroupAsDictionaryWithValueFuncTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
        var dict = Dicts.GroupByAsDictionary(list, v => v % 2, v => v * 10);

        dict.Count.ShouldBe(2); // 0 or 1
        dict[0].Count.ShouldBe(4);
        dict[1].Count.ShouldBe(5);
            
        dict[0][0].ShouldBe(20);
        dict[0][1].ShouldBe(40);
        dict[0][2].ShouldBe(60);
        dict[0][3].ShouldBe(80);
            
        dict[1][0].ShouldBe(10);
        dict[1][1].ShouldBe(30);
        dict[1][2].ShouldBe(50);
        dict[1][3].ShouldBe(70);
        dict[1][4].ShouldBe(90);
    }
}