using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class CharExtensions {
        /// <summary>
        /// To create a range from one to another
        /// </summary>
        /// <param name="this"></param>
        /// <param name="toCharacter"></param>
        /// <returns></returns>
        public static IEnumerable<char> To(this char @this, char toCharacter) {
            var reverseRequired = @this > toCharacter;

            var first = reverseRequired ? toCharacter : @this;
            var last = reverseRequired ? @this : toCharacter;

            var result = Enumerable.Range(first, last - first + 1).Select(charCode => (char) charCode);

            if (reverseRequired) {
                result = result.Reverse();
            }

            return result;
        }
    }
}