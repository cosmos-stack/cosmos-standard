using System.ComponentModel;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

namespace Cosmos.Expressions.Internals;

internal enum TokenId
{
    /// <summary>
    /// $
    /// </summary>
    Parameter,

    /// <summary>
    /// Expression
    /// </summary>
    Expression,

    /// <summary>
    /// Parse to String
    /// </summary>
    ParseString,

    /// <summary>
    /// String
    /// </summary>
    String,

    /// <summary>
    /// Parse to Char
    /// </summary>
    ParseChar,

    /// <summary>
    /// Char
    /// </summary>
    Char,

    /// <summary>
    /// Parse to Int32
    /// </summary>
    ParseInt,

    /// <summary>
    /// Int32
    /// </summary>
    Int,

    /// <summary>
    /// Parse to UInt32
    /// </summary>
    ParseUInt,

    /// <summary>
    /// UInt32
    /// </summary>
    UInt,

    /// <summary>
    /// Parse to Int64
    /// </summary>
    ParseLong,

    /// <summary>
    /// Int64
    /// </summary>
    Long,

    /// <summary>
    /// Parse to UInt64
    /// </summary>
    ParseULong,

    /// <summary>
    /// UInt64
    /// </summary>
    ULong,

    /// <summary>
    /// Parse to Double
    /// </summary>
    ParseDouble,

    /// <summary>
    /// Double
    /// </summary>
    Double,

    /// <summary>
    /// Parse to Float
    /// </summary>
    ParseFloat,

    /// <summary>
    /// Float
    /// </summary>
    Float,

    /// <summary>
    /// Parse to Decimal
    /// </summary>
    ParseDecimal,

    /// <summary>
    /// Decimal
    /// </summary>
    Decimal,

    /// <summary>
    /// Parse to Boolean
    /// </summary>
    ParseBool,

    /// <summary>
    /// Boolean
    /// </summary>
    Bool,

    /// <summary>
    /// Parse to Guid,
    /// </summary>
    ParseGuid,

    /// <summary>
    /// Guid
    /// </summary>
    Guid,

    /// <summary>
    /// Parse to DateTime
    /// </summary>
    ParseDateTime,

    /// <summary>
    /// DateTime
    /// </summary>
    DateTime,

    /// <summary>
    /// Parse to DateTimeOffset
    /// </summary>
    ParseDateTimeOffset,

    /// <summary>
    /// DateTimeOffset
    /// </summary>
    DateTimeOffset,

    /// <summary>
    /// New a Array
    /// </summary>
    NewArray,

    /// <summary>
    /// Array
    /// </summary>
    Array,

    /// <summary>
    /// New a Object
    /// </summary>
    NewObject,

    /// <summary>
    /// Object
    /// </summary>
    Object,

    /// <summary>
    /// Contains
    /// </summary>
    In,

    /// <summary>
    /// Call a Method
    /// </summary>
    MethodCall,

    /// <summary>
    /// 方法
    /// </summary>
    Method,

    /// <summary>
    /// 属性
    /// </summary>
    Property,

    /// <summary>
    /// 变量
    /// </summary>
    Variable,

    /// <summary>
    /// {
    /// </summary>
    [Description("{")]
    LeftBrace,

    /// <summary>
    /// }
    /// </summary>
    [Description("}")]
    RightBrace,

    /// <summary>
    /// [
    /// </summary>
    [Description("[")]
    LeftBracket,

    /// <summary>
    /// ]
    /// </summary>
    [Description("]")]
    RightBracket,

    /// <summary>
    /// (
    /// </summary>
    [Description("(")]
    LeftParenthesis,

    /// <summary>
    /// )
    /// </summary>
    [Description(")")]
    RightParenthesis,

    /// <summary>
    /// ,
    /// </summary>
    [Description(",")]
    Comma,

    /// <summary>
    /// .
    /// </summary>
    [Description(".")]
    Access,

    /// <summary>
    /// ?.
    /// </summary>
    [Description("?.")]
    NullableAccess,

    /// <summary>
    /// ++
    /// </summary>
    [Description("++")]
    IncrementAssign,

    /// <summary>
    /// --
    /// </summary>
    [Description("--")]
    DecrementAssign,

    /// <summary>
    /// !
    /// </summary>
    [Description("!")]
    Not,

    /// <summary>
    /// ~
    /// </summary>
    [Description("~")]
    BitComplement,

    /// <summary>
    /// /
    /// </summary>
    [Description("/")]
    Divide,

    /// <summary>
    /// *
    /// </summary>
    [Description("*")]
    Multiply,

    /// <summary>
    /// %
    /// </summary>
    [Description("%")]
    Modulo,

    /// <summary>
    /// +
    /// </summary>
    [Description("+")]
    Add,

    /// <summary>
    /// -
    /// </summary>
    [Description("-")]
    Minus,

    /// <summary>
    /// &lt;&lt;
    /// </summary>
    [Description("<<")]
    LeftShift,

    /// <summary>
    /// &gt;&gt;
    /// </summary>
    [Description(">>")]
    RightShift,

    /// <summary>
    /// &lt;
    /// </summary>
    [Description("<")]
    LessThan,

    /// <summary>
    /// &lt;=
    /// </summary>
    [Description("<=")]
    LessThanOrEqual,

    /// <summary>
    /// &gt;
    /// </summary>
    [Description(">")]
    GreaterThan,

    /// <summary>
    /// &gt;=
    /// </summary>
    [Description(">=")]
    GreaterThanOrEqual,

    /// <summary>
    /// ==
    /// </summary>
    [Description("==")]
    Equal,

    /// <summary>
    /// !=
    /// </summary>
    [Description("!=")]
    NotEqual,

    /// <summary>
    /// &amp;-位与
    /// </summary>
    [Description("&")]
    And,

    /// <summary>
    /// ^-位异或
    /// </summary>
    [Description("^")]
    ExclusiveOr,

    /// <summary>
    /// |-位或
    /// </summary>
    [Description("|")]
    Or,

    /// <summary>
    /// &amp;&amp;-逻辑与
    /// </summary>
    [Description("&&")]
    AndAlso,

    /// <summary>
    /// ||-逻辑或
    /// </summary>
    [Description("||")]
    OrElse,

    /// <summary>
    /// ??
    /// </summary>
    [Description("??")]
    Coalesce,

    /// <summary>
    /// ?
    /// </summary>
    [Description("?")]
    Predicate,

    /// <summary>
    /// :
    /// </summary>
    [Description(":")]
    Option,

    /// <summary>
    /// =
    /// </summary>
    [Description("=")]
    Assign,

    /// <summary>
    /// /=
    /// </summary>
    [Description("/=")]
    DivideAssign,

    /// <summary>
    /// *=
    /// </summary>
    [Description("*=")]
    MultiplyAssign,

    /// <summary>
    /// %=
    /// </summary>
    [Description("%=")]
    ModuloAssign,

    /// <summary>
    /// +=
    /// </summary>
    [Description("+=")]
    AddAssign,

    /// <summary>
    /// -=
    /// </summary>
    [Description("-=")]
    SubtractAssign,

    /// <summary>
    /// &lt;&lt;=
    /// </summary>
    [Description("<<=")]
    LeftShiftAssign,

    /// <summary>
    /// &gt;&gt;=
    /// </summary>
    [Description(">>=")]
    RightShiftAssign,

    /// <summary>
    /// &amp;=
    /// </summary>
    [Description("&=")]
    AndAssign,

    /// <summary>
    /// ^=
    /// </summary>
    [Description("^=")]
    ExclusiveOrAssign,

    /// <summary>
    /// |=
    /// </summary>
    [Description("!=")]
    OrAssign,
}