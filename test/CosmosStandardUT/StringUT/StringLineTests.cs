﻿using System.Linq;
using Cosmos.Text;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Lines")]
    public class StringLineTests
    {
        private string TestSampleOne = @"The Apache License 2.0
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an ""AS IS"" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
"; // 6 lines

        [Fact(DisplayName = "Count a text and returns the number of line test")]
        public void LineCountTest()
        {
            Strings.CountByLines(TestSampleOne).ShouldBe(6);
        }

        [Fact(DisplayName = "Split a text and returns the all lines test")]
        public void LineItemsTest()
        {
            var texts = Strings.SplitByLines(TestSampleOne).ToList();

            texts[0].ShouldBe("The Apache License 2.0");
            texts[1].Trim().ShouldBe("Unless required by applicable law or agreed to in writing, software");
        }

        [Fact(DisplayName = "Extensions method for Count a text and returns the number of line test")]
        public void ExtensionMethodForLineCountTest()
        {
            TestSampleOne.CountByLines().ShouldBe(6);
        }

        [Fact(DisplayName = "Extensions method for Split a text and returns the all lines test")]
        public void ExtensionMethodForLineItemsTest()
        {
            var texts = TestSampleOne.SplitByLines().ToList();

            texts[0].ShouldBe("The Apache License 2.0");
            texts[1].Trim().ShouldBe("Unless required by applicable law or agreed to in writing, software");
        }

        [Fact(DisplayName = "Truncate a text and returns the all lines test")]
        public void TruncateByLinesTest()
        {
            var val = Strings.TruncateByLines(TestSampleOne, 3);
            var lines = Strings.SplitByLines(val).ToList();

            lines.Count.ShouldBe(3);
            lines[0].ShouldBe("The Apache License 2.0");
            lines[1].Trim().ShouldBe("Unless required by applicable law or agreed to in writing, software");
            lines[2].ShouldBe("...");
        }

        [Fact(DisplayName = "Extensions method for Truncate a text and returns the all lines test")]
        public void ExtensionMethodForTruncateByLinesTest()
        {
            var val = TestSampleOne.TruncateByLines(3);
            var lines = Strings.SplitByLines(val).ToList();

            lines.Count.ShouldBe(3);
            lines[0].ShouldBe("The Apache License 2.0");
            lines[1].Trim().ShouldBe("Unless required by applicable law or agreed to in writing, software");
            lines[2].ShouldBe("...");
        }
    }
}