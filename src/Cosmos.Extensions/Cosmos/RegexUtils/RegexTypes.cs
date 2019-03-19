/*!
 * CSharpVerbalExpressions v0.1
 * https://github.com/VerbalExpressions/CSharpVerbalExpressions
 */
 
/*
 * Reference to:
 *      VerbalExpressions/CSharpVerbalExpressions
 *      Author: VerbalExpressions Team
 *      URL: https://github.com/VerbalExpressions/CSharpVerbalExpressions
 *      MIT
 *
 * Changed and updated by Alex Lewis
 */

namespace Cosmos.RegexUtils
{
    /// <summary>
    /// This class is used to fake an enum. You'll be able to use it as an enum.
    /// Note: type save enum, found on stackoverflow: http://stackoverflow.com/a/424414/603309
    /// </summary>
    public sealed class RegexTypes
    {
        private RegexTypes(int value, string name)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public int Value { get; }

        public static readonly RegexTypes Url = new RegexTypes(1, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[^-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+(:[0-9]+)?|(?:www.|[^-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w_]*)?\??(?:[-\+=&;%@.\w-_]*)#?‌​(?:[\w]*))?)");

        public static readonly RegexTypes Email = new RegexTypes(2, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}");
    }
}
