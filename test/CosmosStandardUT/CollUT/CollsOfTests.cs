using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
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

        [Fact(DisplayName = "Use Colls.OfPage and returns a list with page information test")]
        public void CollOfPageAndReturnsListWithinPageTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var page = Colls.OfPage(list, 2, 3);

            page.PageSize.ShouldBe(3);
            page.CurrentPageNumber.ShouldBe(2);
            page.CurrentPageSize.ShouldBe(3);
            page.HasNext.ShouldBeTrue();
            page.HasPrevious.ShouldBeTrue();
            page.TotalMemberCount.ShouldBe(9);
            
            page[0].Value.ShouldBe(4);
            page[1].Value.ShouldBe(5);
            page[2].Value.ShouldBe(6);

            var list1 = page.ToOriginalItems().ToList();
            var list2 = page.ToList();
            
            list1.Count.ShouldBe(3);
            list1[0].ShouldBe(4);
            list1[1].ShouldBe(5);
            list1[2].ShouldBe(6);
            
            list2.Count.ShouldBe(3);
            list2[0].Value.ShouldBe(4);
            list2[1].Value.ShouldBe(5);
            list2[2].Value.ShouldBe(6);
        }

        [Fact(DisplayName = "Use Colls.OfPage for query and returns a list with page information test")]
        public void CollOfPageForQueryAndReturnsListWithinPageTest()
        {
            var query = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9}.AsQueryable();
            var page = Colls.OfPage(query, 2, 3);

            page.PageSize.ShouldBe(3);
            page.CurrentPageNumber.ShouldBe(2);
            page.CurrentPageSize.ShouldBe(3);
            page.HasNext.ShouldBeTrue();
            page.HasPrevious.ShouldBeTrue();
            page.TotalMemberCount.ShouldBe(9);
            
            page[0].Value.ShouldBe(4);
            page[1].Value.ShouldBe(5);
            page[2].Value.ShouldBe(6);

            var list1 = page.ToOriginalItems().ToList();
            var list2 = page.ToList();
            
            list1.Count.ShouldBe(3);
            list1[0].ShouldBe(4);
            list1[1].ShouldBe(5);
            list1[2].ShouldBe(6);
            
            list2.Count.ShouldBe(3);
            list2[0].Value.ShouldBe(4);
            list2[1].Value.ShouldBe(5);
            list2[2].Value.ShouldBe(6);
        }
    }
}