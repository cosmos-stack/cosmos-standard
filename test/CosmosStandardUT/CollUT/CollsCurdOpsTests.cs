using System.Collections.Generic;
using System.Linq;
using CosmosStack.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ListUT.Ops")]
    public class CollsCurdOpsTests
    {
        [Fact(DisplayName = "Add one list into another and returns it.")]
        public void AddOneListIntoAnotherTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var other = new List<int> {6, 7, 8, 9, 10};

            var target = Colls.AddRange(list, other).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(10);
            other.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
            target[6].ShouldBe(7);
            target[7].ShouldBe(8);
            target[8].ShouldBe(9);
            target[9].ShouldBe(10);
        }

        [Fact(DisplayName = "Add one list into another with limit and returns it.")]
        public void AddOneListIntoAnotherWithLimitTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var other = new List<int> {6, 7, 8, 9, 10};

            var target = Colls.AddRange(list, other, 2).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(7);
            other.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
            target[6].ShouldBe(7);
        }

        [Fact(DisplayName = "Add one list into another with direct true flag and returns it.")]
        public void AddOneListIntoAnotherWithDirectTrueFlagTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = Colls.AddIf(list, 6, true).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(6);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
        }

        [Fact(DisplayName = "Add one list into another with direct false flag and returns it.")]
        public void AddOneListIntoAnotherWithDirectFalseFlagTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = Colls.AddIf(list, 6, false).ToList();

            list.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
        }

        [Fact(DisplayName = "Add one list into another with true func condition and returns it.")]
        public void AddOneListIntoAnotherWithDirectTrueConditionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = Colls.AddIf(list, 6, () => true).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(6);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
        }

        [Fact(DisplayName = "Add one list into another with false func condition and returns it.")]
        public void AddOneListIntoAnotherWithDirectFalseConditionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = Colls.AddIf(list, 6, () => false).ToList();

            list.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
        }

        [Fact(DisplayName = "Add one list into another with true func condition and val and returns it.")]
        public void AddOneListIntoAnotherWithDirectTrueConditionAndValTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = Colls.AddIf(list, 6, v => v > 5).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(6);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
        }

        [Fact(DisplayName = "Add one list into another with false func condition and val and returns it.")]
        public void AddOneListIntoAnotherWithDirectFalseConditionAndValTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = Colls.AddIf(list, 6, v => v > 6).ToList();

            list.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with limit and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithLimitTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var other = new List<int> {6, 7, 8, 9, 10};

            var target = list.AddRange(other, 2).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(7);
            other.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
            target[6].ShouldBe(7);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with direct true flag and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithDirectTrueFlagTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = list.AddIf(6, true).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(6);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with direct false flag and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithDirectFalseFlagTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = list.AddIf(6, false).ToList();

            list.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with true func condition and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithDirectTrueConditionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = list.AddIf(6, () => true).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(6);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with false func condition and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithDirectFalseConditionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = list.AddIf(6, () => false).ToList();

            list.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with true func condition and val and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithDirectTrueConditionAndValTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = list.AddIf(6, v => v > 5).ToList();

            list.Count.ShouldBe(5);
            target.Count.ShouldBe(6);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
            target[5].ShouldBe(6);
        }

        [Fact(DisplayName = "Extensions method for Add one list into another with false func condition and val and returns it.")]
        public void ExtensionsMethodForAddOneListIntoAnotherWithDirectFalseConditionAndValTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5};

            var target = list.AddIf(6, v => v > 6).ToList();

            list.Count.ShouldBe(5);

            target[0].ShouldBe(1);
            target[1].ShouldBe(2);
            target[2].ShouldBe(3);
            target[3].ShouldBe(4);
            target[4].ShouldBe(5);
        }

        [Fact(DisplayName = "Extensions method for Add one item into another with exists func condition and returns it.")]
        public void ExtensionsMethodForAddOneItemInfoAnotherWithFunctionThatExistsTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var val1 = list.AddIfNotExist(0, _ => false).ToList();
            var val2 = list.AddIfNotExist(0, _ => true).ToList();
            var val3 = list.AddIfNotExist(0).ToList();
            var val4 = list.AddIfNotExist(9).ToList();

            list.Count.ShouldBe(9);
            val1.Count.ShouldBe(9); // 1 2 3 4 5 6 7 8 9
            val2.Count.ShouldBe(10); // 1 2 3 4 5 6 7 8 9 0
            val3.Count.ShouldBe(10); // 1 2 3 4 5 6 7 8 9 0
            val4.Count.ShouldBe(9); // 1 2 3 4 5 6 7 8 9
            list.Count.ShouldBe(9);
        }

        [Fact(DisplayName = "Extensions method for Add one item into another if not null and returns it.")]
        public void ExtensionsMethodForAddOneItemInfoAnotherIfNotNullTest()
        {
            var list0 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var list1 = new List<int?> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var list2 = new List<string> {"1", "2"};

            var val0 = list0.AddIfNotNull(0).ToList();
            var val1 = list1.AddIfNotNull(0).ToList();
            var val2 = list1.AddIfNotNull(null).ToList();
            var val3 = list2.AddIfNotNull("").ToList();
            var val4 = list2.AddIfNotNull(null).ToList();

            list0.Count.ShouldBe(9);
            list1.Count.ShouldBe(9);
            list2.Count.ShouldBe(2);

            val0.Count.ShouldBe(10);
            val1.Count.ShouldBe(10);
            val2.Count.ShouldBe(9);
            val3.Count.ShouldBe(3);
            val4.Count.ShouldBe(2);

            list0.Count.ShouldBe(9);
            list1.Count.ShouldBe(9);
            list2.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Getting or adding item from value type coll test")]
        public void GettingOrAddingFromValueTypeCollTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};

            var val1 = Colls.GetOrAdd(list, v => v > 7, () => 9);
            val1.ShouldBe(8);
            list.Count.ShouldBe(8);

            var val2 = Colls.GetOrAdd(list, v => v > 8, () => 9);
            val2.ShouldBe(0);
            list.Count.ShouldBe(8);
        }

        [Fact(DisplayName = "Getting or adding item from nullable value type coll test")]
        public void GettingOrAddingFromNullableValueTypeCollTest()
        {
            var list = new List<int?> {1, 2, 3, 4, 5, 6, 7, 8};

            var val1 = Colls.GetOrAdd(list, v => v > 7, () => 9);
            val1.ShouldBe(8);
            list.Count.ShouldBe(8);

            var val2 = Colls.GetOrAdd(list, v => v > 8, () => 9);
            val2.ShouldBe(9);
            list.Count.ShouldBe(9);
        }

        [Fact(DisplayName = "Getting or adding item from string coll test")]
        public void GettingOrAddingFromStringCollTest()
        {
            var list = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8"};

            var val1 = Colls.GetOrAdd(list, v => v == "8", () => "8");
            val1.ShouldBe("8");
            list.Count.ShouldBe(8);

            var val2 = Colls.GetOrAdd(list, v => v == "9", () => "9");
            val2.ShouldBe("9");
            list.Count.ShouldBe(9);
        }

        [Fact(DisplayName = "Extensions method for Getting or adding item from value type coll test")]
        public void ExtensionsMethodForGettingOrAddingFromValueTypeCollTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};

            var val1 = list.GetOrAdd(v => v > 7, () => 9);
            val1.ShouldBe(8);
            list.Count.ShouldBe(8);

            var val2 = list.GetOrAdd(v => v > 8, () => 9);
            val2.ShouldBe(0);
            list.Count.ShouldBe(8);
        }

        [Fact(DisplayName = "Extensions method for Getting or adding item from nullable value type coll test")]
        public void ExtensionsMethodForGettingOrAddingFromNullableValueTypeCollTest()
        {
            var list = new List<int?> {1, 2, 3, 4, 5, 6, 7, 8};

            var val1 = list.GetOrAdd(v => v > 7, () => 9);
            val1.ShouldBe(8);
            list.Count.ShouldBe(8);

            var val2 = list.GetOrAdd(v => v > 8, () => 9);
            val2.ShouldBe(9);
            list.Count.ShouldBe(9);
        }

        [Fact(DisplayName = "Extensions method for Getting or adding item from string coll test")]
        public void ExtensionsMethodForGettingOrAddingFromStringCollTest()
        {
            var list = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8"};

            var val1 = Colls.GetOrAdd(list, v => v == "8", () => "8");
            val1.ShouldBe("8");
            list.Count.ShouldBe(8);

            var val2 = Colls.GetOrAdd(list, v => v == "9", () => "9");
            val2.ShouldBe("9");
            list.Count.ShouldBe(9);
        }

        [Fact(DisplayName = "Remove range of elements from List safety test")]
        public void RemoveRangeFromListSafety()
        {
            var nice = new List<string> {"1", "2", "3"};

            Colls.RemoveRangeSafety(nice, 4, 4);
            nice.ShouldNotBeNull();
            nice.ShouldNotBeEmpty();
            nice.Count.ShouldBe(3);

            Colls.RemoveRangeSafety(nice, 0, 0);
            nice.ShouldNotBeNull();
            nice.ShouldNotBeEmpty();
            nice.Count.ShouldBe(3);

            Colls.RemoveRangeSafety(nice, 4, 0);
            nice.ShouldNotBeNull();
            nice.ShouldNotBeEmpty();
            nice.Count.ShouldBe(3);

            Colls.RemoveRangeSafety(nice, 0, 4);
            nice.ShouldNotBeNull();
            nice.ShouldBeEmpty();
        }

        [Fact(DisplayName = "Remove duplicates elements from int32 List test")]
        public void RemoveDuplicatesFromInt32ListTest()
        {
            var list = new List<int> {1, 2, 3, 3, 3, 4, 5, 6, 7, 7, 8, 9, 9, 9, 0, 0};

            list.Count.ShouldBe(16);
            var target = Colls.RemoveDuplicates(list);

            list.Count.ShouldBe(10);
            target.Count().ShouldBe(10);
        }

        [Fact(DisplayName = "Remove duplicates elements from int32 List with check test")]
        public void RemoveDuplicatesFromInt32ListWithCheckTest()
        {
            var list = new List<int> {1, 2, 3, 3, 3, 4, 5, 6, 7, 7, 8, 9, 9, 9, 0, 0};

            list.Count.ShouldBe(16);
            var target = Colls.RemoveDuplicates(list, v => v * 0);

            list.Count.ShouldBe(1);
            target.Count().ShouldBe(1);
        }

        [Fact(DisplayName = "Remove duplicates elements from string List test")]
        public void RemoveDuplicatesFromStringListTest()
        {
            var list = new List<string> {"A", "a", "a", "b", "c", "C"};

            list.Count.ShouldBe(6);
            var target = Colls.RemoveDuplicates(list);

            list.Count.ShouldBe(5); // A a b c C
            target.Count().ShouldBe(5); // A a b c C
        }

        [Fact(DisplayName = "Remove duplicates elements from string List IgnoreCase test")]
        public void RemoveDuplicatesIgnoreCaseFromStringListTest()
        {
            var list = new List<string> {"A", "a", "a", "b", "c", "C"};

            list.Count.ShouldBe(6);
            var target = Colls.RemoveDuplicatesIgnoreCase(list);

            list.Count.ShouldBe(3);
            target.Count().ShouldBe(3);
        }

        [Fact(DisplayName = "Remove with condition test")]
        public void RemoveWithConditionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = Colls.RemoveIf(list, c => c > 1);

            list.Count.ShouldBe(2);
            target.Count().ShouldBe(2);
        }

        [Fact(DisplayName = "Extensions method for Remove duplicates elements from int32 List test")]
        public void ExtensionsMethodForRemoveDuplicatesFromInt32ListTest()
        {
            var list = new List<int> {1, 2, 3, 3, 3, 4, 5, 6, 7, 7, 8, 9, 9, 9, 0, 0};

            list.Count.ShouldBe(16);
            var target = list.RemoveDuplicates();

            list.Count.ShouldBe(10);
            target.Count().ShouldBe(10);
        }

        [Fact(DisplayName = "Extensions method for Remove duplicates elements from int32 List with check test")]
        public void ExtensionsMethodForRemoveDuplicatesFromInt32ListWithCheckTest()
        {
            var list = new List<int> {1, 2, 3, 3, 3, 4, 5, 6, 7, 7, 8, 9, 9, 9, 0, 0};

            list.Count.ShouldBe(16);
            var target = list.RemoveDuplicates(v => v * 0);

            list.Count.ShouldBe(1);
            target.Count().ShouldBe(1);
        }

        [Fact(DisplayName = "Extensions method for Remove duplicates elements from string List test")]
        public void ExtensionsMethodForRemoveDuplicatesFromStringListTest()
        {
            var list = new List<string> {"A", "a", "a", "b", "c", "C"};

            list.Count.ShouldBe(6);
            var target = list.RemoveDuplicates();

            list.Count.ShouldBe(5); // A a b c C
            target.Count().ShouldBe(5); // A a b c C
        }

        [Fact(DisplayName = "Extensions method for Remove duplicates elements from string List IgnoreCase test")]
        public void ExtensionsMethodForRemoveDuplicatesIgnoreCaseFromStringListTest()
        {
            var list = new List<string> {"A", "a", "a", "b", "c", "C"};

            list.Count.ShouldBe(6);
            var target = list.RemoveDuplicatesIgnoreCase();

            list.Count.ShouldBe(3);
            target.Count().ShouldBe(3);
        }

        [Fact(DisplayName = "Extensions method for Remove with condition test")]
        public void ExtensionsMethodForRemoveWithConditionTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            var target = list.RemoveIf(c => c > 1);

            list.Count.ShouldBe(2);
            target.Count().ShouldBe(2);
        }

        [Fact(DisplayName = "Merge one item and another enumerator of colls test")]
        public void MergeOneItemAndAnotherEnumeratorTest()
        {
            var zero = 0;
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

            using var enumerator = list.GetEnumerator();
            var target = Colls.Merge(zero, enumerator).ToList();

            list.Count.ShouldBe(7);
            target.Count.ShouldBe(8);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
        }

        [Fact(DisplayName = "Merge two enumerators of colls test")]
        public void MergeTwoEnumeratorsTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};

            using var leftEnumerator = left.GetEnumerator();
            using var rightEnumerator = right.GetEnumerator();

            var target = Colls.Merge(leftEnumerator, rightEnumerator).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }

        [Fact(DisplayName = "Merge one enumerator of colls and another item test")]
        public void MergeOneEnumeratorAndAnotherItemTest()
        {
            var eight = 8;
            var list = new List<int> {0,1, 2, 3, 4, 5, 6, 7};

            using var enumerator = list.GetEnumerator();
            var target = Colls.Merge(enumerator, eight).ToList();

            list.Count.ShouldBe(8);
            target.Count.ShouldBe(9);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
        }

        [Fact(DisplayName = "Merge two list without limited test")]
        public void MergeTwoListWithoutLimitedTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = Colls.Merge(left, right).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }
        
        [Fact(DisplayName = "Merge two list with limited that > 0 test")]
        public void MergeTwoListWithLimitedThatGreaterThanZeroTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = Colls.Merge(left, right,2).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(8);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
        }
        
        [Fact(DisplayName = "Merge two list with limited that = 0 test")]
        public void MergeTwoListWithLimitedThatEqualsToZeroTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = Colls.Merge(left, right,0).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }
        
        [Fact(DisplayName = "Merge two list with limited that < 0 test")]
        public void MergeTwoListWithLimitedThatLessThanZeroTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = Colls.Merge(left, right,-2).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }
        
        [Fact(DisplayName = "Merge two list with limited that > len test")]
        public void MergeTwoListWithLimitedThatGreaterThanLengthTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = Colls.Merge(left, right,20).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }

        [Fact(DisplayName = "Extensions method for Merge two list without limited test")]
        public void ExtensionsMethodForMergeTwoListWithoutLimitedTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = left.Merge( right).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }
        
        [Fact(DisplayName = "Extensions method for Merge two list with limited that > 0 test")]
        public void ExtensionsMethodForMergeTwoListWithLimitedThatGreaterThanZeroTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = left.Merge( right,2).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(8);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
        }
        
        [Fact(DisplayName = "Extensions method for Merge two list with limited that = 0 test")]
        public void ExtensionsMethodForMergeTwoListWithLimitedThatEqualsToZeroTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = left.Merge( right,0).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }
        
        [Fact(DisplayName = "Extensions method for Merge two list with limited that < 0 test")]
        public void ExtensionsMethodForMergeTwoListWithLimitedThatLessThanZeroTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = left.Merge( right,-2).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }
        
        [Fact(DisplayName = "Extensions method for Merge two list with limited that > len test")]
        public void ExtensionsMethodForMergeTwoListWithLimitedThatGreaterThanLengthTest()
        {
            var left = new List<int> {0, 1, 2, 3, 4, 5};
            var right = new List<int> {6, 7, 8, 9};
            var target = left.Merge( right,20).ToList();

            left.Count.ShouldBe(6);
            right.Count.ShouldBe(4);
            target.Count.ShouldBe(10);

            target[0].ShouldBe(0);
            target[1].ShouldBe(1);
            target[2].ShouldBe(2);
            target[3].ShouldBe(3);
            target[4].ShouldBe(4);
            target[5].ShouldBe(5);
            target[6].ShouldBe(6);
            target[7].ShouldBe(7);
            target[8].ShouldBe(8);
            target[9].ShouldBe(9);
        }

        [Fact(DisplayName = "Append one item into a readonly list test")]
        public void ReadOnlyAppendOneItemIntoCollTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}.AsReadOnly();

            var v = ReadOnlyColls.Append(list, 11);
            
            v.ShouldNotBeNull();
            v.Count.ShouldBe(11);
        }
        
        [Fact(DisplayName = "Extensions method for Append one item into a readonly list test")]
        public void ExtensionsMethodForReadOnlyAppendOneItemIntoCollTest()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}.AsReadOnly();

            var v = list.Append( 11);
            
            v.ShouldNotBeNull();
            v.Count.ShouldBe(11);
        }
    }
}