using System.Collections.Generic;
using Cosmos.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ListUT.Move")]
    public class CollsMoveTests
    {
        [Fact(DisplayName = "Move first test")]
        public void MoveItemToFirstTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
            var target = Colls.MoveToFirst(list, 8);
            
            target.Count.ShouldBe(8);
            target[0].ShouldBe(8);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
        }

        [Fact(DisplayName = "Move first with item witch not exists in colls test")]
        public void MoveItemToFirstWithNotExistsItemTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
            var target = Colls.MoveToFirst(list, 9);
            
            target.Count.ShouldBe(8);
            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
            target[6].ShouldBe(7);
            target[7].ShouldBe(8);
        }
    }
}