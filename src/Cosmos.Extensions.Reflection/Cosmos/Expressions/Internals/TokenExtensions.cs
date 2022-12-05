using System.ComponentModel;
using Cosmos.Text;

namespace Cosmos.Expressions.Internals;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

internal static class TokenExtensions
{
    public static CharId Id(this char @char)
    {
        if (@char.IsLetter())
            return CharId.Letter;
        if (@char.IsDigit())
            return CharId.Digit;
        switch (@char)
        {
            case ' ':
            case '\0':
            case '\r':
            case '\n':
                return CharId.Empty;
            case '!':
                return CharId.Exclam;
            case '"':
                return CharId.DoubleQuote;
            case '#':
                return CharId.Sharp;
            case '$':
                return CharId.Dollar;
            case '%':
                return CharId.Modulo;
            case '&':
                return CharId.And;
            case '\'':
                return CharId.SingleQuote;
            case '(':
                return CharId.LeftParenthesis;
            case ')':
                return CharId.RightParenthesis;
            case '*':
                return CharId.Asterisk;
            case '+':
                return CharId.Plus;
            case ',':
                return CharId.Comma;
            case '-':
                return CharId.Minus;
            case '.':
                return CharId.Dot;
            case '/':
                return CharId.Slash;
            case ':':
                return CharId.Colon;
            case ';':
                return CharId.Semicolon;
            case '<':
                return CharId.LessThan;
            case '=':
                return CharId.Equal;
            case '>':
                return CharId.GreaterThan;
            case '?':
                return CharId.Question;
            case '@':
                return CharId.At;
            case '[':
                return CharId.LeftBracket;
            case '\\':
                return CharId.Backslash;
            case ']':
                return CharId.RightBracket;
            case '^':
                return CharId.Caret;
            case '_':
                return CharId.Underline;
            case '`':
                return CharId.Backquote;
            case '{':
                return CharId.LeftBrace;
            case '|':
                return CharId.Bar;
            case '}':
                return CharId.RightBrace;
            case '~':
                return CharId.Tilde;
            default:
                return CharId.Unknow;
        }
    }

    public static string Description(this Enum @enum)
    {
        var type = @enum.GetType();
        var name = Enum.GetName(type, @enum);

        if(string.IsNullOrEmpty(name))
            throw new ArgumentOutOfRangeException(nameof(@enum), @enum,"The value of the Enum is not a valid value for the type.");

        return type.GetField(name)?.GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? name;
    }

    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Func<T, bool> separatorSelector)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (separatorSelector is null)
            throw new ArgumentNullException(nameof(separatorSelector),
                $"Parameter '{nameof(separatorSelector)}' cannot be null.");

        var output = new List<IEnumerable<T>>();
        var i = -1;
        var length = source.Count();
        for (var j = 0; j < length; j++)
        {
            if (separatorSelector(source.ElementAt(j)))
            {
                var item = source.Skip(i + 1).Take(j - i - 1);
                item.Any().IfTrueThenInvoke(() => output.Add(item));
                i = j;
            }
        }

        if (i < length - 1)
        {
            var item = source.Skip(i + 1).ToList();
            item.Any().IfTrueThenInvoke(() => output.Add(item));
        }

        return output;
    }
}