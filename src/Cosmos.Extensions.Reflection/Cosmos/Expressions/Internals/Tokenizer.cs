using System.Text;

namespace Cosmos.Expressions.Internals;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

internal class Tokenizer
{
    public static IList<Token> Parse(string input)
    {
        var chars = $"{input}\0".Select(_ => new Char { Id = _.Id(), Value = _ }).ToList();
        var tokens = new List<Token>();
        var lastCharId = CharId.Empty;
        var currCharIndex = 0;
        var sb = new StringBuilder();
        for (var i = 0; i < chars.Count; i++)
        {
            var currChar = chars[i];
            switch (lastCharId)
            {
                case CharId.Unknow:
                    goto ThrowException;
                case CharId.Empty:
                    lastCharId = currChar.Id;
                    currCharIndex = i;
                    sb.Clear();
                    sb.Append(currChar.Value);
                    break;
                case CharId.Exclam:

                    #region !

                    if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.NotEqual,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Not,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.DoubleQuote:

                    #region "

                    if (currChar.Id == CharId.DoubleQuote)
                    {
                        var s = sb.ToString().Trim('"');
                        tokens.Add(new Token
                        {
                            Id = TokenId.String,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                            Value = s,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                        sb.Append(currChar.Value);

                    #endregion

                    break;
                case CharId.Sharp:
                    goto ThrowException;
                case CharId.Dollar:

                    #region $

                    if (currChar.Id == CharId.Underline || currChar.Id == CharId.Letter || currChar.Id == CharId.Digit)
                        sb.Append(currChar.Value);
                    else
                    {
                        var s = sb.ToString();
                        if (s.Length == 1)
                            tokens.Add(new Token
                            {
                                Id = TokenId.Parameter,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                                Value = s,
                            });
                        else
                            tokens.Add(new Token
                            {
                                Id = TokenId.Variable,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                                Value = s,
                            });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Modulo:

                    #region %

                    if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.ModuloAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Modulo,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.And:

                    #region &

                    if (currChar.Id == CharId.And)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.AndAlso,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.AndAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.And,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.SingleQuote:

                    #region '

                    if (currChar.Id == CharId.SingleQuote)
                    {
                        var s = sb.ToString().Trim('\'');
                        if (s.Length == 1)
                            tokens.Add(new Token
                            {
                                Id = TokenId.Char,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                                Value = char.Parse(s),
                            });
                        else
                            tokens.Add(new Token
                            {
                                Id = TokenId.String,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                                Value = s,
                            });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                        sb.Append(currChar.Value);

                    #endregion

                    break;
                case CharId.LeftParenthesis:

                    #region (

                    tokens.Add(new Token
                    {
                        Id = TokenId.LeftParenthesis,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.RightParenthesis:

                    #region )

                    tokens.Add(new Token
                    {
                        Id = TokenId.RightParenthesis,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Asterisk:

                    #region *

                    if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.MultiplyAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Multiply,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Plus:

                    #region +

                    if (currChar.Id == CharId.Plus)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.IncrementAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.AddAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Add,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Comma:

                    #region ,

                    tokens.Add(new Token
                    {
                        Id = TokenId.Comma,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Minus:

                    #region -

                    if (currChar.Id == CharId.Minus)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.DecrementAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.SubtractAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Minus,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Dot:

                    #region .

                    tokens.Add(new Token
                    {
                        Id = TokenId.Access,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Slash:

                    #region /

                    if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.DivideAssign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Divide,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Digit:

                    #region [0-9]

                    if (currChar.Id == CharId.Digit || currChar.Id == CharId.Letter ||
                        (currChar.Id == CharId.Dot && sb.ToString().IndexOf('.') < 0))
                        sb.Append(currChar.Value);
                    else
                    {
                        var s = sb.ToString();
                        if (s.EndsWith("M", StringComparison.OrdinalIgnoreCase))
                        {
#if NETFRAMEWORK
                            if (decimal.TryParse(s.Substring(0, s.Length - 1), out var @uint))
#else
                            if (decimal.TryParse(s[..^1], out var @uint))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Decimal,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @uint,
                                });
                            else
                                ThrowConvertException(s, nameof(Decimal), input, currCharIndex);
                        }
                        else if (s.EndsWith("D", StringComparison.OrdinalIgnoreCase))
                        {
#if NETFRAMEWORK
                            if (double.TryParse(s.Substring(0, s.Length - 1), out var @uint))
#else
                            if (double.TryParse(s[..^1], out var @uint))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Double,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @uint,
                                });
                            else
                                ThrowConvertException(s, nameof(Double), input, currCharIndex);
                        }
                        else if (s.EndsWith("F", StringComparison.OrdinalIgnoreCase))
                        {
#if NETFRAMEWORK
                            if (float.TryParse(s.Substring(0, s.Length - 1), out var @uint))
#else
                            if (float.TryParse(s[..^1], out var @uint))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Float,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @uint,
                                });
                            else
                                ThrowConvertException(s, nameof(Single), input, currCharIndex);
                        }
                        else if (s.EndsWith("UL", StringComparison.OrdinalIgnoreCase))
                        {
#if NETFRAMEWORK
                            if (ulong.TryParse(s.Substring(0, s.Length - 2), out var @uint))
#else
                            if (ulong.TryParse(s[..^2], out var @uint))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.ULong,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @uint,
                                });
                            else
                                ThrowConvertException(s, nameof(UInt64), input, currCharIndex);
                        }
                        else if (s.EndsWith("L", StringComparison.OrdinalIgnoreCase))
                        {
#if NETFRAMEWORK
                            if (long.TryParse(s.Substring(0, s.Length - 1), out var @uint))
#else
                            if (long.TryParse(s[..^1], out var @uint))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Long,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @uint,
                                });
                            else
                                ThrowConvertException(s, nameof(Int64), input, currCharIndex);
                        }
                        else if (s.EndsWith("U", StringComparison.OrdinalIgnoreCase))
                        {
#if NETFRAMEWORK
                            if (uint.TryParse(s.Substring(0, s.Length - 1), out var @uint))
#else
                            if (uint.TryParse(s[..^1], out var @uint))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.UInt,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @uint,
                                });
#if NETFRAMEWORK
                            else if (ulong.TryParse(s.Substring(0, s.Length - 1), out var @ulong))
#else
                            else if (ulong.TryParse(s[..^1], out var @ulong))
#endif
                                tokens.Add(new Token
                                {
                                    Id = TokenId.ULong,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @ulong,
                                });
                            else
                                ThrowConvertException(s, nameof(UInt64), input, currCharIndex);
                        }
                        else if (s.IndexOf('.') > 0)
                        {
                            if (double.TryParse(s, out var @double))
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Double,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @double,
                                });
                            else
                                ThrowConvertException(s, nameof(Double), input, currCharIndex);
                        }
                        else
                        {
                            if (int.TryParse(s, out var @int))
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Int,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @int,
                                });
                            else if (long.TryParse(s, out var @long))
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Long,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = @long,
                                });
                            else
                                ThrowConvertException(s, nameof(Int32), input, currCharIndex);
                        }

                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Colon:

                    #region :

                    tokens.Add(new Token
                    {
                        Id = TokenId.Option,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Semicolon:
                    goto ThrowException;
                case CharId.LessThan:

                    #region <

                    if (currChar.Id == CharId.Equal)
                    {
                        if (sb.Length == 2)
                            tokens.Add(new Token
                            {
                                Id = TokenId.LeftShiftAssign,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        else
                            tokens.Add(new Token
                            {
                                Id = TokenId.LessThanOrEqual,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else if (currChar.Id == CharId.LessThan)
                        sb.Append(currChar.Value);
                    else
                    {
                        if (sb.Length == 2)
                            tokens.Add(new Token
                            {
                                Id = TokenId.LeftShift,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        else
                            tokens.Add(new Token
                            {
                                Id = TokenId.LessThan,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Equal:

                    #region =

                    if (currChar.Id == CharId.Equal)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Equal,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Assign,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.GreaterThan:

                    #region >

                    if (currChar.Id == CharId.Equal)
                    {
                        if (sb.Length == 2)
                            tokens.Add(new Token
                            {
                                Id = TokenId.RightShiftAssign,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        else
                            tokens.Add(new Token
                            {
                                Id = TokenId.GreaterThanOrEqual,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else if (currChar.Id == CharId.GreaterThan)
                        sb.Append(currChar.Value);
                    else
                    {
                        if (sb.Length == 2)
                            tokens.Add(new Token
                            {
                                Id = TokenId.RightShift,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        else
                            tokens.Add(new Token
                            {
                                Id = TokenId.GreaterThan,
                                Index = currCharIndex,
                                Length = i - currCharIndex,
                            });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Question:

                    #region ?

                    if (currChar.Id == CharId.Dot)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.NullableAccess,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else if (currChar.Id == CharId.Question)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Coalesce,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Predicate,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.At:
                    break;
                case CharId.Letter:

                    #region [a-zA-Z_]

                    if (currChar.Id == CharId.Underline || currChar.Id == CharId.Letter || currChar.Id == CharId.Digit)
                        sb.Append(currChar.Value);
                    else
                    {
                        //new{} 或 new[]
                        if ((currChar.Id == CharId.LeftBrace || currChar.Id == CharId.LeftBracket) &&
                            sb.ToString().Equals("new", StringComparison.OrdinalIgnoreCase))
                        {
                            if (currChar.Id == CharId.LeftBrace) //new{}
                                tokens.Add(new Token
                                {
                                    Id = TokenId.NewObject,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                });
                            else if (currChar.Id == CharId.LeftBracket) //new{}
                                tokens.Add(new Token
                                {
                                    Id = TokenId.NewArray,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                });
                        }
                        //string|char|int|uint|long|ulong|double|float|decimal|bool|guid|datetime|datetimeoffset()
                        else if (currChar.Id == CharId.LeftParenthesis)
                        {
                            var s = sb.ToString().ToUpper();
                            switch (s)
                            {
                                case "STRING":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseString,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "CHAR":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseChar,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "INT":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseInt,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "UINT":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseUInt,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "LONG":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseLong,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "ULONG":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseULong,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "DOUBLE":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseDouble,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "FLOAT":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseFloat,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "DECIMAL":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseDecimal,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "BOOL":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseBool,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "GUID":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseGuid,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "DATETIME":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseDateTime,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                case "DATETIMEOFFSET":
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.ParseDateTimeOffset,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                    });
                                    break;
                                default:
                                    tokens.Add(new Token
                                    {
                                        Id = TokenId.MethodCall,
                                        Index = currCharIndex,
                                        Length = i - currCharIndex,
                                        Value = s,
                                    });
                                    break;
                            }
                        }
                        else
                        {
                            var s = sb.ToString();
                            if ("true".Equals(s) || "false".Equals(s))
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Bool,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = bool.Parse(s),
                                });
                            else if ("in".Equals(s))
                                tokens.Add(new Token
                                {
                                    Id = TokenId.In,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                });
                            else
                                tokens.Add(new Token
                                {
                                    Id = TokenId.Property,
                                    Index = currCharIndex,
                                    Length = i - currCharIndex,
                                    Value = s,
                                });
                        }

                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.LeftBracket:

                    #region [

                    if (currChar.Id == CharId.LeftBracket)
                        goto ThrowException;
                    tokens.Add(new Token
                    {
                        Id = TokenId.LeftBracket,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Backslash:
                    break;
                case CharId.RightBracket:

                    #region ]

                    tokens.Add(new Token
                    {
                        Id = TokenId.RightBracket,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Caret:

                    #region ^

                    tokens.Add(new Token
                    {
                        Id = TokenId.ExclusiveOr,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Underline:

                    #region _

                    if (currChar.Id == CharId.Underline || currChar.Id == CharId.Letter || currChar.Id == CharId.Digit)
                    {
                        sb.Append(currChar.Value);
                        lastCharId = CharId.Letter;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Property,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.Backquote:
                    goto ThrowException;
                case CharId.LeftBrace:

                    #region {

                    if (currChar.Id == CharId.LeftBrace)
                        goto ThrowException;
                    tokens.Add(new Token
                    {
                        Id = TokenId.LeftBrace,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Bar:

                    #region |

                    if (currChar.Id == CharId.Bar)
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.OrElse,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        lastCharId = CharId.Empty;
                        currCharIndex = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Id = TokenId.Or,
                            Index = currCharIndex,
                            Length = i - currCharIndex,
                        });
                        sb.Clear();
                        sb.Append(currChar.Value);
                        lastCharId = currChar.Id;
                        currCharIndex = i;
                    }

                    #endregion

                    break;
                case CharId.RightBrace:

                    #region }

                    tokens.Add(new Token
                    {
                        Id = TokenId.RightBrace,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                case CharId.Tilde:

                    #region ~

                    tokens.Add(new Token
                    {
                        Id = TokenId.BitComplement,
                        Index = currCharIndex,
                        Length = i - currCharIndex,
                    });
                    sb.Clear();
                    sb.Append(currChar.Value);
                    lastCharId = currChar.Id;
                    currCharIndex = i;

                    #endregion

                    break;
                default:
                    goto ThrowException;
            }

            continue;

            ThrowException:
            var segment_Before = currCharIndex + sb.Length - 7 >= 0
                ? input.Substring(currCharIndex + sb.Length - 7, 7)
#if NETFRAMEWORK
                : input.Substring(0, currCharIndex + sb.Length);
#else
                : input[..(currCharIndex + sb.Length)];
#endif
            throw new TokenParseException(
                $"Unrecognized '{currChar.Value}' at index position '{currCharIndex + sb.Length}':... {segment_Before} `{currChar.Value}`");
        }

        //if (tokens.Any(_ => _.Id == TokenId.Assign || _.Id == TokenId.DivideAssign || _.Id == TokenId.MultiplyAssign || _.Id == TokenId.ModuloAssign || _.Id == TokenId.AddAssign || _.Id == TokenId.SubtractAssign || _.Id == TokenId.LeftShiftAssign || _.Id == TokenId.RightShiftAssign || _.Id == TokenId.AndAssign || _.Id == TokenId.ExclusiveOrAssign || _.Id == TokenId.OrAssign))
        //{
        //    var token = tokens.First(_ => _.Id == TokenId.Assign || _.Id == TokenId.DivideAssign || _.Id == TokenId.MultiplyAssign || _.Id == TokenId.ModuloAssign || _.Id == TokenId.AddAssign || _.Id == TokenId.SubtractAssign || _.Id == TokenId.LeftShiftAssign || _.Id == TokenId.RightShiftAssign || _.Id == TokenId.AndAssign || _.Id == TokenId.ExclusiveOrAssign || _.Id == TokenId.OrAssign);
        //    throw new ExpressionParseException($"Assignment operator '{token.Id.Description() }' is not currently supported", input, token);
        //}

        Parse(tokens);

        return tokens;
    }

    static void Parse(IList<Token> tokens)
    {
        ParseConvert(tokens);
        ParseNew(tokens);
        ParseMethod(tokens);
    }

    static void ParseConvert(IList<Token> tokens)
    {
        static bool predicate(Token token)
            => false
            || token.Id == TokenId.ParseString
            || token.Id == TokenId.ParseChar
            || token.Id == TokenId.ParseInt
            || token.Id == TokenId.ParseUInt
            || token.Id == TokenId.ParseLong
            || token.Id == TokenId.ParseULong
            || token.Id == TokenId.ParseDouble
            || token.Id == TokenId.ParseFloat
            || token.Id == TokenId.ParseDecimal
            || token.Id == TokenId.ParseBool
            || token.Id == TokenId.ParseGuid
            || token.Id == TokenId.ParseDateTime
            || token.Id == TokenId.ParseDateTimeOffset;

        while (tokens.Any(predicate))
        {
            var token = tokens.First(predicate);
            var index_LeftParenthesis = tokens.IndexOf(token) + 1;
            var index_RightParenthesis = -1;
            var parentheses = 0;
            for (int i = index_LeftParenthesis + 1; i < tokens.Count; i++)
            {
                if (tokens[i].Id == TokenId.LeftParenthesis)
                    parentheses++;
                else if (tokens[i].Id == TokenId.RightParenthesis)
                {
                    if (parentheses > 0)
                        parentheses--;
                    else
                        index_RightParenthesis = i;
                }
            }

            var _tokens = tokens.Skip(index_LeftParenthesis + 1)
                                .Take(index_RightParenthesis - index_LeftParenthesis - 1).ToList();
            for (int i = index_LeftParenthesis; i <= index_RightParenthesis; i++)
            {
                tokens.RemoveAt(index_LeftParenthesis);
            }

            Parse(_tokens);
#if NETFRAMEWORK
            token.Id = (TokenId)Enum.Parse(typeof(TokenId), token.Id.ToString().Substring(5));
#else
            token.Id = (TokenId)Enum.Parse(typeof(TokenId), token.Id.ToString()[5..]);
#endif
            token.Value = _tokens;
        }
    }

    static void ParseNew(IList<Token> tokens)
    {
        while (tokens.Any(_ => _.Id == TokenId.NewArray || _.Id == TokenId.NewObject))
        {
            var token = tokens.First(_ => _.Id == TokenId.NewArray || _.Id == TokenId.NewObject);
            TokenId leftId = 0, rightId = 0;
            if (token.Id == TokenId.NewArray)
            {
                leftId = TokenId.LeftBracket;
                rightId = TokenId.RightBracket;
            }
            else if (token.Id == TokenId.NewObject)
            {
                leftId = TokenId.LeftBrace;
                rightId = TokenId.RightBrace;
            }

            var index_LeftBra = tokens.IndexOf(token) + 1;
            var index_RightBra = -1;
            var parentheses = 0;
            for (int i = index_LeftBra + 1; i < tokens.Count; i++)
            {
                if (tokens[i].Id == leftId)
                    parentheses++;
                else if (tokens[i].Id == rightId)
                {
                    if (parentheses > 0)
                        parentheses--;
                    else
                        index_RightBra = i;
                }
            }

            var _tokens = tokens.Skip(index_LeftBra + 1).Take(index_RightBra - index_LeftBra - 1).ToList();
            for (int i = index_LeftBra; i <= index_RightBra; i++)
            {
                tokens.RemoveAt(index_LeftBra);
            }

            Parse(_tokens);
#if NETFRAMEWORK
            token.Id = (TokenId)Enum.Parse(typeof(TokenId), token.Id.ToString().Substring(3));
#else
            token.Id = (TokenId)Enum.Parse(typeof(TokenId), token.Id.ToString()[3..]);
#endif
            token.Value = _tokens;
        }
    }

    static void ParseMethod(IList<Token> tokens)
    {
        while (tokens.Any(_ => _.Id == TokenId.MethodCall))
        {
            var token = tokens.First(_ => _.Id == TokenId.MethodCall);
            var index_LeftParenthesis = tokens.IndexOf(token) + 1;
            var index_RightParenthesis = -1;
            var parentheses = 0;
            for (int i = index_LeftParenthesis + 1; i < tokens.Count; i++)
            {
                if (tokens[i].Id == TokenId.LeftParenthesis)
                    parentheses++;
                else if (tokens[i].Id == TokenId.RightParenthesis)
                {
                    if (parentheses > 0)
                        parentheses--;
                    else
                        index_RightParenthesis = i;
                }
            }

            var _tokens = tokens.Where((_, i) => i > index_LeftParenthesis && i < index_RightParenthesis).ToList();
            for (int i = index_LeftParenthesis; i <= index_RightParenthesis; i++)
            {
                tokens.RemoveAt(index_LeftParenthesis);
            }

            Parse(_tokens);
            token.Id = TokenId.Method;
            token.Value = new KeyValuePair<string, IList<Token>>((string)token.Value, _tokens);
        }
    }

    static void ThrowConvertException(string @string, string typeName, string input, int index)
    {
#if NETFRAMEWORK
        var segment_Before = index - 7 >= 0 ? input.Substring(index - 7, 7) : input.Substring(0, index);
#else
        var segment_Before = index - 7 >= 0 ? input.Substring(index - 7, 7) : input[..index];
#endif
        throw new TokenParseException(
            $"Error thrown when converting '{@string}' to type '{typeName}', at index position '{index}':... {segment_Before} `{@string}`");
    }
}