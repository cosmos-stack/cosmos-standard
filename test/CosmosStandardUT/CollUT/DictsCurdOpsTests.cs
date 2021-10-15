using System.Collections.Generic;
using CosmosStack.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "DictUT.Ops")]
    public class DictsCurdOpsTests
    {
        [Fact(DisplayName = "Add value or override it in dictionary test")]
        public void AddValueOrOverrideTest()
        {
            var dictionary = new Dictionary<int, int> {{1, 2}};

            Dicts.AddValueOrOverride(dictionary, 1, 100);
            Dicts.AddValueOrOverride(dictionary, 2, 200);

            dictionary.Count.ShouldBe(2);
            dictionary[1].ShouldBe(100);
            dictionary[2].ShouldBe(200);

            dictionary.AddValueOrOverride(1, 300);
            dictionary.AddValueOrOverride(3, 400);

            dictionary.Count.ShouldBe(3);
            dictionary[1].ShouldBe(300);
            dictionary[2].ShouldBe(200);
            dictionary[3].ShouldBe(400);
        }

        [Fact(DisplayName = "Add value or update it in dictionary test")]
        public void AddValueOrUpdateTest()
        {
            var dictionary = new Dictionary<int, int> {{1, 2}};

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(2);

            Dicts.AddValueOrUpdate(dictionary, 1, k => 200, (k, v) => v * 111);

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(222);

            Dicts.AddValueOrUpdate(dictionary, 2, k => 200, (k, v) => v * 111);

            dictionary.Count.ShouldBe(2);
            dictionary[1].ShouldBe(222);
            dictionary[2].ShouldBe(200);

            dictionary.AddValueOrUpdate(2, k => 200, (k, v) => v * 111);
            dictionary.AddValueOrUpdate(3, k => 300, (k, v) => v * 111);

            dictionary.Count.ShouldBe(3);
            dictionary[1].ShouldBe(222);
            dictionary[2].ShouldBe(22200);
            dictionary[3].ShouldBe(300);
        }

        [Fact(DisplayName = "Add value or do sth in dictionary test")]
        public void AddValueOrDoTest()
        {
            var dictionary = new Dictionary<int, int> {{1, 2}};

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(2);

            string show = "";

            Dicts.AddValueOrDo(dictionary, 1, k => 200, (k, v) => { show = $"{k}-{v}"; });

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(2);
            show.ShouldBe("1-2");

            show = "";

            Dicts.AddValueOrDo(dictionary, 2, k => 200, (k, v) => { show = $"{k}-{v}"; });

            dictionary.Count.ShouldBe(2);
            dictionary[1].ShouldBe(2);
            dictionary[2].ShouldBe(200);
            show.ShouldBe("");

            show = "";
            
            dictionary.AddValueOrDo(2, k => 200, (k, v) => { show = $"{k}-{v}"; });
            
            dictionary.Count.ShouldBe(2);
            dictionary[1].ShouldBe(2);
            dictionary[2].ShouldBe(200);
            show.ShouldBe("2-200");

            show = "";
            
            dictionary.AddValueOrDo(3, k => 300, (k, v) => { show = $"{k}-{v}"; });
            
            dictionary.Count.ShouldBe(3);
            dictionary[1].ShouldBe(2);
            dictionary[2].ShouldBe(200);
            dictionary[3].ShouldBe(300);
            show.ShouldBe("");
        }

        [Fact(DisplayName = "Merge two dictionary into the first one test")]
        public void MergeTest()
        {
            var dictionary1 = new Dictionary<int, int> {{1, 2}};
            var dictionary2 = new Dictionary<int, int> {{3, 4}};
            var dictionary3= new Dictionary<int, int> {{5, 6}};
            var kvp = new KeyValuePair<int, int>(7, 8);
            
            dictionary1.Count.ShouldBe(1);
            dictionary2.Count.ShouldBe(1);
            dictionary3.Count.ShouldBe(1);
            
            Dicts.Add(dictionary1,dictionary2);
            
            dictionary1.Count.ShouldBe(2);
            dictionary2.Count.ShouldBe(1);
            dictionary3.Count.ShouldBe(1);
            
            dictionary1.Add(dictionary3);
            
            dictionary1.Count.ShouldBe(3);
            dictionary2.Count.ShouldBe(1);
            dictionary3.Count.ShouldBe(1);
            
            dictionary1.Add(kvp);
            
            dictionary1.Count.ShouldBe(4);
            dictionary2.Count.ShouldBe(1);
            dictionary3.Count.ShouldBe(1);
        }
    }
}