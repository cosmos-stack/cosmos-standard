using System.Linq.Expressions;
using Cosmos.Expressions.Internals;

namespace Cosmos.Expressions;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

public class ExpressionParser
{
    private readonly ParameterExpression _parameterExpression;
    private readonly object _variablesObject;
    private readonly ConstantExpression _variablesExpression;

    /// <summary>
    /// Create a new instance of ExpressionParser
    /// </summary>
    /// <param name="parameterExpression"></param>
    /// <param name="variables"></param>
    public ExpressionParser(
        ParameterExpression parameterExpression,
        IDictionary<string, object> variables = default)
    {
        _parameterExpression = parameterExpression;
        _variablesObject = TypeFactory.CreateObject(variables ?? new Dictionary<string, object>());
        _variablesExpression = Expression.Constant(_variablesObject);
    }

    public string Input { get; private set; }

    public IDictionary<string, object> Variables => _variablesObject.GetType().GetProperties().ToDictionary(_ => _.Name, _ => _.GetValue(_variablesObject));

    /// <summary>
    /// 转换字符串表达式
    /// </summary>
    /// <param name="input">表达式字符串</param>
    /// <returns></returns>
    public Expression Parse(string input)
    {
        Input = input;
        return Parse(Tokenizer.Parse(input));
    }

    internal Expression Parse(IList<Token> tokens)
    {
        #region []

        while (tokens.Any(_ => _.Id == TokenId.LeftBracket))
        {
            var indexed_Tokens = tokens.Select((_, i) => new { _.Id, Index = i }).OrderBy(_ => _.Index);
            //“]”的位置
            var index_RightBracket = indexed_Tokens.First(_ => _.Id == TokenId.RightBracket).Index;
            //“[”的位置
            var index_LeftBracket = indexed_Tokens.Where(_ => _.Index < index_RightBracket)
                                                  .Last(_ => _.Id == TokenId.LeftBracket).Index;
            var tokens_Brackets = tokens.Where((_, i) => i > index_LeftBracket && i < index_RightBracket).ToList();
            for (int i = index_LeftBracket; i < index_RightBracket; i++)
            {
                tokens.RemoveAt(index_LeftBracket);
            }

            tokens[index_LeftBracket] = new Token
            {
                Id = TokenId.Expression,
                Value = Parse(tokens_Brackets),
            };
        }

        #endregion

        #region ()

        while (tokens.Any(_ => _.Id == TokenId.LeftParenthesis))
        {
            var indexed_Tokens = tokens.Select((_, i) => new { _.Id, Index = i }).OrderBy(_ => _.Index);
            //“)”的位置
            var index_RightParenthesis = indexed_Tokens.First(_ => _.Id == TokenId.RightParenthesis).Index;
            //“(”的位置
            var index_LeftParenthesis = indexed_Tokens.Where(_ => _.Index < index_RightParenthesis).Last(_ => _.Id == TokenId.LeftParenthesis).Index;
            var tokens_Parentheses = tokens.Where((_, index) => index > index_LeftParenthesis && index < index_RightParenthesis).ToList();

            for (var i = index_LeftParenthesis; i < index_RightParenthesis; i++)
            {
                tokens.RemoveAt(index_LeftParenthesis);
            }

            tokens[index_LeftParenthesis] = new Token
            {
                Id = TokenId.Expression,
                Value = Parse(tokens_Parentheses),
            };
        }

        #endregion

        #region ?., .

        //while (tokens.Any(_ => _.Id == TokenId.NullableAccess || _.Id == TokenId.Access))
        //{
        //    var token = tokens.First(_ => _.Id == TokenId.NullableAccess || _.Id == TokenId.Access);
        //    var token_Left = tokens[tokens.IndexOf(token) - 1];
        //    //tokens.RemoveAt(tokens.IndexOf(token) - 1);
        //    var token_Right = tokens[tokens.IndexOf(token) + 1];
        //    tokens.RemoveAt(tokens.IndexOf(token) + 1);
        //    if (token_Left.Id != TokenId.Parameter && token_Left.Id != TokenId.Variable && token_Left.Id != TokenId.PropertyAccess)
        //        throw new ExpressionParseException($"运算符“{token.Id.Description()}”左侧必须是变量或属性", Input, token_Left);
        //    if (token_Right.Id != TokenId.PropertyAccess)
        //        throw new ExpressionParseException($"运算符“{token.Id.Description()}”右侧必须是属性或字段", Input, token_Right);
        //    Expression valueLeft = Expression_TokenLeft(token, tokens);
        //    var valueRight = (string)token_Right.Value;
        //    //if (token_Left.Id == TokenId.Parameter)
        //    //{
        //    //    valueLeft = parameterExpression;
        //    //}
        //    //else if (token_Left.Id == TokenId.Variable)
        //    //{
        //    //    valueLeft = Expression.Constant(variables[(string)token_Left.Value]);
        //    //}
        //    //else if (token_Left.Id == TokenId.Property)
        //    //{
        //    //    valueLeft = Expression.Property(parameterExpression, (string)token_Left.Value);
        //    //}
        //    if (token.Id == TokenId.NullableAccess)
        //        token.Value = Expression.Condition(Expression.Equal(valueLeft, Expression.Constant(null)), Expression.Constant(null), Expression.Property(valueLeft, valueRight));
        //    //token.Value = valueLeft is null ? null : value(valueLeft, valueRight);
        //    if (token.Id == TokenId.Access)
        //        token.Value = Expression.Property(valueLeft, valueRight);
        //    token.Id = TokenId.Expression;
        //}

        #endregion

        #region ++, --

        while (tokens.Any(_ => _.Id is TokenId.IncrementAssign or TokenId.DecrementAssign))
        {
            var token = tokens.First(_ => _.Id is TokenId.IncrementAssign or TokenId.DecrementAssign);
            if (tokens.IndexOf(token) - 1 > -1 && tokens[tokens.IndexOf(token) - 1].Id == TokenId.Variable)
            {
                var variableExpression = Expression_TokenLeft(token, tokens);
                token.Value = token.Id switch
                {
                    TokenId.IncrementAssign => Expression.PostIncrementAssign(variableExpression),
                    TokenId.DecrementAssign => Expression.PostDecrementAssign(variableExpression),
                    _ => token.Value
                };

                token.Id = TokenId.Expression;
            }
            else if (tokens.IndexOf(token) + 1 < tokens.Count && tokens[tokens.IndexOf(token) + 1].Id == TokenId.Variable)
            {
                var variableExpression = Expression_TokenRight(token, tokens);
                token.Value = token.Id switch
                {
                    TokenId.IncrementAssign => Expression.PreIncrementAssign(variableExpression),
                    TokenId.DecrementAssign => Expression.PreDecrementAssign(variableExpression),
                    _ => token.Value
                };

                token.Id = TokenId.Expression;
            }
            else
            {
                throw new ExpressionParseException("自增或自减表达式必须是变量", Input, token);
            }
        }
        //while (tokens.Any(_ => _.Id == TokenId.IncrementAssign || _.Id == TokenId.DecrementAssign))
        //{
        //    var token = tokens.First(_ => _.Id == TokenId.IncrementAssign || _.Id == TokenId.DecrementAssign);
        //    if (tokens.IndexOf(token) - 1 > -1 && tokens[tokens.IndexOf(token) - 1].Id == TokenId.Variable)
        //    {
        //        var variableToken = tokens[tokens.IndexOf(token) - 1];
        //        tokens.RemoveAt(tokens.IndexOf(token) - 1);
        //        var variable = variables[(string)variableToken.Value];
        //        var value = variable;
        //        if (token.Id == TokenId.IncrementAssign)
        //            value = PostIncrement(ref variable);
        //        else if (token.Id == TokenId.DecrementAssign)
        //            value = PostDecrement(ref variable);
        //        variables[(string)variableToken.Value] = variable;

        //        token.Value = Expression.Constant(value);
        //        token.Id = TokenId.Expression;
        //    }
        //    else if (tokens.IndexOf(token) + 1 < tokens.Count && tokens[tokens.IndexOf(token) + 1].Id == TokenId.Variable)
        //    {
        //        var variableToken = tokens[tokens.IndexOf(token) - 1];
        //        var variable = variables[(string)variableToken.Value];
        //        tokens.RemoveAt(tokens.IndexOf(token) - 1);
        //        var value = variable;
        //        if (token.Id == TokenId.IncrementAssign)
        //            value = PreIncrement(ref variable);
        //        else if (token.Id == TokenId.DecrementAssign)
        //            value = PreDecrement(ref variable);
        //        variables[(string)variableToken.Value] = variable;

        //        token.Value = Expression.Constant(value);
        //        token.Id = TokenId.Expression;
        //    }
        //    else
        //        throw new ExpressionParseException("自增或自减表达式必须是变量", input, token);
        //}

        #endregion

        #region !

        while (tokens.Any(_ => _.Id == TokenId.Not))
        {
            var token = tokens.First(_ => _.Id == TokenId.Not);
            var expression_Right = Expression_TokenRight(token, tokens);
            token.Value = Expression.Not(Expression.Convert(expression_Right, typeof(bool)));
            token.Id = TokenId.Expression;
        }

        #endregion

        #region ~

        while (tokens.Any(_ => _.Id == TokenId.BitComplement))
        {
            var token = tokens.First(_ => _.Id == TokenId.BitComplement);
            var valueRight = Expression_TokenRight(token, tokens);
            if (valueRight.Type == typeof(ulong)
             || valueRight.Type == typeof(long)
             || valueRight.Type == typeof(uint)
             || valueRight.Type == typeof(int)
             || valueRight.Type == typeof(ushort)
             || valueRight.Type == typeof(short)
             || valueRight.Type == typeof(byte)
             || valueRight.Type == typeof(sbyte))
            {
                token.Value = Expression.Not(valueRight);
                token.Id = TokenId.Expression;
            }
            else
            {
                throw new ExpressionParseException($"运算符“{TokenId.BitComplement.Description()}”无法应用于“{valueRight.Type.Name}”类型的操作数", Input, token);
            }
        }

        #endregion

        #region /, *, %

        while (tokens.Any(_ => _.Id is TokenId.Divide or TokenId.Multiply or TokenId.Modulo))
        {
            var token = tokens.First(_ => _.Id is TokenId.Divide or TokenId.Multiply or TokenId.Modulo);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            switch (token.Id)
            {
                case TokenId.Divide:
                    MakeTypeConsistent(TokenId.Divide, ref valueLeft, ref valueRight);
                    token.Value = Expression.Divide(valueLeft, valueRight);
                    break;
                case TokenId.Multiply:
                    MakeTypeConsistent(TokenId.Multiply, ref valueLeft, ref valueRight);
                    token.Value = Expression.Multiply(valueLeft, valueRight);
                    break;
                case TokenId.Modulo:
                    MakeTypeConsistent(TokenId.Modulo, ref valueLeft, ref valueRight);
                    token.Value = Expression.Modulo(valueLeft, valueRight);
                    break;
            }

            token.Id = TokenId.Expression;
        }

        #endregion

        #region +, -

        while (tokens.Any(_ => _.Id is TokenId.Add or TokenId.Minus))
        {
            var token = tokens.First(_ => _.Id is TokenId.Add or TokenId.Minus);

            var valueLeft = (Expression)Expression.Constant(0);
            if (tokens.IndexOf(token) > 0)
                valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            MakeTypeConsistent(token.Id, ref valueLeft, ref valueRight);

            token.Value = token.Id switch
            {
                TokenId.Add when valueLeft.Type == typeof(string) || valueRight.Type == typeof(string) =>
                    Expression.Call(null, typeof(string).GetMethod("Concat", new[] { valueLeft.Type, valueRight.Type }), new[] { valueLeft, valueRight }),
                TokenId.Add => Expression.Add(valueLeft, valueRight),
                TokenId.Minus => Expression.Subtract(valueLeft, valueRight),
                _ => token.Value
            };

            token.Id = TokenId.Expression;
        }

        #endregion

        #region <<, >>

        while (tokens.Any(_ => _.Id is TokenId.LeftShift or TokenId.RightShift))
        {
            var token = tokens.First(_ => _.Id is TokenId.LeftShift or TokenId.RightShift);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            token.Value = token.Id switch
            {
                TokenId.LeftShift => Expression.LeftShift(valueLeft, valueRight),
                TokenId.RightShift => Expression.RightShift(valueLeft, valueRight),
                _ => token.Value
            };
            token.Id = TokenId.Expression;
        }

        #endregion

        #region >, >=, <, <=

        while (tokens.Any(_ => _.Id is TokenId.GreaterThan or TokenId.GreaterThanOrEqual or TokenId.LessThan or TokenId.LessThanOrEqual))
        {
            var token = tokens.First(_ => _.Id is TokenId.GreaterThan or TokenId.GreaterThanOrEqual or TokenId.LessThan or TokenId.LessThanOrEqual);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            MakeTypeConsistent(token.Id, ref valueLeft, ref valueRight);

            token.Value = token.Id switch
            {
                TokenId.GreaterThan => Expression.GreaterThan(valueLeft, valueRight),
                TokenId.GreaterThanOrEqual => Expression.GreaterThanOrEqual(valueLeft, valueRight),
                TokenId.LessThan => Expression.LessThan(valueLeft, valueRight),
                TokenId.LessThanOrEqual => Expression.LessThanOrEqual(valueLeft, valueRight),
                _ => token.Value
            };
            token.Id = TokenId.Expression;
        }

        #endregion

        #region ==, !=

        while (tokens.Any(_ => _.Id is TokenId.Equal or TokenId.NotEqual))
        {
            var token = tokens.First(_ => _.Id is TokenId.Equal or TokenId.NotEqual);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            MakeTypeConsistent(token.Id, ref valueLeft, ref valueRight);

            token.Value = token.Id switch
            {
                TokenId.Equal => Expression.Equal(valueLeft, valueRight),
                TokenId.NotEqual => Expression.NotEqual(valueLeft, valueRight),
                _ => token.Value
            };
            token.Id = TokenId.Expression;
        }

        #endregion

        #region &

        while (tokens.Any(_ => _.Id == TokenId.And))
        {
            var token = tokens.First(_ => _.Id == TokenId.And);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            token.Value = Expression.And(valueLeft, valueRight);
            token.Id = TokenId.Expression;
        }

        #endregion

        #region ^

        while (tokens.Any(_ => _.Id == TokenId.ExclusiveOr))
        {
            var token = tokens.First(_ => _.Id == TokenId.ExclusiveOr);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            token.Value = Expression.ExclusiveOr(valueLeft, valueRight);
            token.Id = TokenId.Expression;
        }

        #endregion

        #region |

        while (tokens.Any(_ => _.Id == TokenId.Or))
        {
            var token = tokens.First(_ => _.Id == TokenId.Or);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            token.Value = Expression.Or(valueLeft, valueRight);
            token.Id = TokenId.Expression;
        }

        #endregion

        #region &&

        while (tokens.Any(_ => _.Id == TokenId.AndAlso))
        {
            var token = tokens.First(_ => _.Id == TokenId.AndAlso);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            token.Value = Expression.AndAlso(Expression.Convert(valueLeft, typeof(bool)), Expression.Convert(valueRight, typeof(bool)));
            token.Id = TokenId.Expression;
        }

        #endregion

        #region ||

        while (tokens.Any(_ => _.Id == TokenId.OrElse))
        {
            var token = tokens.First(_ => _.Id == TokenId.OrElse);
            var valueLeft = Expression_TokenLeft(token, tokens);
            var valueRight = Expression_TokenRight(token, tokens);

            token.Value = Expression.OrElse(Expression.Convert(valueLeft, typeof(bool)), Expression.Convert(valueRight, typeof(bool)));
            token.Id = TokenId.Expression;
        }

        #endregion

        #region ?:

        while (tokens.Any(_ => _.Id == TokenId.Predicate))
        {
            var index_Predicate = -1;
            var index_Option = -1;
            var index_Predicates = new Stack<int>();
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                if (token.Id == TokenId.Predicate)
                    index_Predicates.Push(i);
                else if (token.Id == TokenId.Option)
                {
                    if (index_Predicates.Count == 1)
                    {
                        index_Predicate = index_Predicates.Pop();
                        index_Option = i;
                        break;
                    }
                    else
                    {
                        index_Predicates.Pop();
                    }
                }
            }

            var index_Test_Start = tokens
                                   .Select((_, i) => new { _.Id, Index = i })
                                   .OrderBy(_ => _.Index)
                                   .Where(_ => _.Index < index_Predicate)
                                   .LastOrDefault(_ => _.Id is TokenId.Assign
                                       or TokenId.DivideAssign
                                       or TokenId.MultiplyAssign
                                       or TokenId.ModuloAssign
                                       or TokenId.AddAssign
                                       or TokenId.SubtractAssign
                                       or TokenId.LeftShiftAssign
                                       or TokenId.RightShiftAssign
                                       or TokenId.AndAssign
                                       or TokenId.ExclusiveOrAssign
                                       or TokenId.OrAssign)
                                   ?.Index ?? -1;
            var tokens_Test = tokens.Where((_, i) => i > index_Test_Start && i < index_Predicate).ToList();
            var tokens_IfTrue = tokens.Where((_, i) => i > index_Predicate && i < index_Option).ToList();
            var tokens_IfFalse = tokens.Where((_, i) => i > index_Option).ToList();
            tokens = tokens.Where((_, i) => i <= index_Test_Start).ToList();
            tokens.Add(new Token
            {
                Id = TokenId.Expression,
                Value = Expression.Condition(Parse(tokens_Test), Parse(tokens_IfTrue), Parse(tokens_IfFalse)),
            });
        }

        #endregion

        #region ??

        while (tokens.Any(_ => _.Id == TokenId.Coalesce))
        {
            var token = tokens.First(_ => _.Id == TokenId.Coalesce);
            var tokenLeft = Expression_TokenLeft(token, tokens);
            var tokenRight = Expression_TokenRight(token, tokens);

            token.Value = Expression.Coalesce(tokenLeft, tokenRight);
            token.Id = TokenId.Expression;
        }

        #endregion

        #region =, /=, *=, %=, +=, -=, <<=, >>=, &=, ^=, |=

        while (tokens.Any(_ => _.Id is TokenId.Assign
                   or TokenId.DivideAssign
                   or TokenId.MultiplyAssign
                   or TokenId.ModuloAssign
                   or TokenId.AddAssign
                   or TokenId.SubtractAssign
                   or TokenId.LeftShiftAssign
                   or TokenId.RightShiftAssign
                   or TokenId.AndAssign
                   or TokenId.ExclusiveOrAssign
                   or TokenId.OrAssign))
        {
            var token = tokens.First(_ =>
                _.Id is TokenId.Assign
                    or TokenId.DivideAssign
                    or TokenId.MultiplyAssign
                    or TokenId.ModuloAssign
                    or TokenId.AddAssign
                    or TokenId.SubtractAssign
                    or TokenId.LeftShiftAssign
                    or TokenId.RightShiftAssign
                    or TokenId.AndAssign
                    or TokenId.ExclusiveOrAssign
                    or TokenId.OrAssign);
            var tokenAtLeft = tokens[tokens.IndexOf(token) - 1];
            if (tokenAtLeft.Id != TokenId.Variable)
            {
                throw new ExpressionParseException("赋值运算符左侧必须是变量", Input, token);
            }

            var token_Left = Expression_TokenLeft(token, tokens);
            var token_Right = Expression_TokenRight(token, tokens);

            MakeTypeConsistent(token.Id, ref token_Left, ref token_Right);

            token.Value = token.Id switch
            {
                TokenId.Assign => Expression.Assign(token_Left, token_Right),
                TokenId.DivideAssign => Expression.DivideAssign(token_Left, token_Right),
                TokenId.MultiplyAssign => Expression.MultiplyAssign(token_Left, token_Right),
                TokenId.ModuloAssign => Expression.ModuloAssign(token_Left, token_Right),
                TokenId.AddAssign => Expression.AddAssign(token_Left, token_Right),
                TokenId.SubtractAssign => Expression.SubtractAssign(token_Left, token_Right),
                TokenId.LeftShiftAssign => Expression.LeftShiftAssign(token_Left, token_Right),
                TokenId.RightShiftAssign => Expression.RightShiftAssign(token_Left, token_Right),
                TokenId.AndAssign => Expression.AndAssign(token_Left, token_Right),
                TokenId.ExclusiveOrAssign => Expression.ExclusiveOrAssign(token_Left, token_Right),
                TokenId.OrAssign => Expression.OrAssign(token_Left, token_Right),
                _ => token.Value
            };

            token.Id = TokenId.Expression;
        }

        #endregion

        if (tokens.Count == 1)
        {
            return GetExpression(tokens[0]);
        }
        else
        {
            var token = new Token();
            tokens.Insert(0, token);
            return Expression_TokenRight(token, tokens);
        }

        throw new ExpressionParseException("计算未完成");
    }

    Expression Expression_TokenLeft(Token token, IList<Token> tokens)
    {
        var token_Left = tokens.IndexOf(token) - 1 < 0
            ? throw new ExpressionParseException($"解析错误。", Input, token)
            : tokens[tokens.IndexOf(token) - 1];
        tokens.RemoveAt(tokens.IndexOf(token) - 1);

        var token_LeftLeft = tokens.IndexOf(token) - 1 < 0 ? null : tokens[tokens.IndexOf(token) - 1];
        if (token_LeftLeft is null)
            return GetExpression(token_Left);

        if (token_LeftLeft.Id == TokenId.In)
        {
            var expression_LeftLeftLeft = Expression_TokenLeft(token_LeftLeft, tokens);
            if (expression_LeftLeftLeft is null)
                throw new ExpressionParseException($"访问符“{token_LeftLeft.Id.Description()}”左侧找不到表达式。", Input, token_LeftLeft);

            tokens.Remove(token_LeftLeft);

            return Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), new[] { expression_LeftLeftLeft.Type }, GetExpression(token_Left), expression_LeftLeftLeft);
        }
        else if (token_LeftLeft.Id is TokenId.Access or TokenId.NullableAccess)
        {
            var expression_LeftLeftLeft = Expression_TokenLeft(token_LeftLeft, tokens);
            if (expression_LeftLeftLeft is null)
                throw new ExpressionParseException($"访问符“{token_LeftLeft.Id.Description()}”左侧找不到表达式。", Input, token_LeftLeft);

            tokens.Remove(token_LeftLeft);

            if (token_Left.Id == TokenId.Property)
            {
                return Expression.Property(expression_LeftLeftLeft, (string)token_Left.Value);
            }

            if (token_Left.Id == TokenId.Method)
            {
                var method = (KeyValuePair<string, IList<Token>>)token_Left.Value;
                var method_Name = method.Key;
                var method_Params = method.Value.Split(_ => _.Id == TokenId.Comma).Select(_ => Parse(_.ToList()))
                                          .ToArray();
                return Expression.Call(expression_LeftLeftLeft, method_Name, null, method_Params);
            }

            throw new ExpressionParseException($"访问符“{token_LeftLeft.Id.Description()}”右侧必须是属性或方法。", Input, token_LeftLeft);
        }

        return GetExpression(token_Left);
    }

    Expression Expression_TokenRight(Token token, IList<Token> tokens)
    {
        #region 取到右侧token

        var token_Right = tokens.IndexOf(token) + 1 < tokens.Count
            ? tokens[tokens.IndexOf(token) + 1]
            : throw new ExpressionParseException($"解析错误。", Input, token);
        tokens.RemoveAt(tokens.IndexOf(token) + 1);

        var minus = false;
        if (token_Right.Id is TokenId.Add or TokenId.Minus)
        {
            minus = token_Right.Id == TokenId.Minus;
            token_Right = tokens.IndexOf(token) + 1 < tokens.Count
                ? tokens[tokens.IndexOf(token) + 1]
                : throw new ExpressionParseException($"解析错误。", Input, token_Right);
            tokens.RemoveAt(tokens.IndexOf(token) + 1);
        }

        #endregion

        var expression = GetExpression(token_Right);

        Token? token_RightRight;
        bool token_RightRight_IsAccess;
        do
        {
            token_RightRight = tokens.IndexOf(token) + 1 < tokens.Count ? tokens[tokens.IndexOf(token) + 1] : null;
            if (token_RightRight is null)
                break;

            token_RightRight_IsAccess = token_RightRight.Id is TokenId.Access or TokenId.NullableAccess or TokenId.In;
            //如果右侧token的右侧是 in 或访问符，继续处理更右侧token
            if (token_RightRight_IsAccess)
            {
                if (token_RightRight.Id == TokenId.In)
                {
                    var expression_RightRightRight = Expression_TokenRight(token_RightRight, tokens);
                    if (expression_RightRightRight is null)
                        throw new ExpressionParseException($"访问符“{token_RightRight.Id.Description()}”右侧找不到表达式。", Input, token_RightRight);

                    tokens.Remove(token_RightRight);

                    expression = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), new[] { expression.Type }, expression_RightRightRight, expression);
                }
                else if (token_RightRight.Id is TokenId.Access or TokenId.NullableAccess)
                {
                    tokens.Remove(token_RightRight);

                    var token_RightRightRight = tokens.IndexOf(token) + 1 < tokens.Count
                        ? tokens[tokens.IndexOf(token) + 1]
                        : null;
                    if (token_RightRightRight is null)
                        throw new ExpressionParseException($"访问符“{token_RightRight.Id.Description()}”右侧必须是属性或方法。", Input, token_RightRight);

                    tokens.Remove(token_RightRightRight);

                    if (token_RightRightRight.Id == TokenId.Property)
                    {
                        expression = Expression.Property(expression, (string)token_RightRightRight.Value);
                    }
                    else if (token_RightRightRight.Id == TokenId.Method)
                    {
                        var method = (KeyValuePair<string, IList<Token>>)token_RightRightRight.Value;
                        var method_Name = method.Key;
                        var method_Params = method.Value
                                                  .Split(_ => _.Id == TokenId.Comma)
                                                  .Select(_ => Parse(_.ToList()))
                                                  .ToArray();
                        expression = Expression.Call(expression, method_Name, null, method_Params);
                    }
                    else
                    {
                        throw new ExpressionParseException($"访问符“{token_RightRight.Id.Description()}”右侧必须是属性或方法。", Input, token_RightRight);
                    }
                }
            }
        } while (token_RightRight_IsAccess);

        if (minus)
            expression = Expression.Negate(expression);
        return expression;
    }

    Expression GetExpression(Token token)
    {
        return token.Id switch
        {
            TokenId.Expression => (Expression)token.Value,
            TokenId.Parameter => _parameterExpression,
            TokenId.Property => Expression.Property(_parameterExpression, (string)token.Value),
            TokenId.Variable => Expression.Property(_variablesExpression, (string)token.Value),
            TokenId.String => token.Value is string
                ? (Expression)Expression.Constant(token.Value)
                : Expression.Call(Parse((IList<Token>)token.Value), "ToString", null),
            TokenId.Char => Expression_ParseOrConvert(token, typeof(char)),
            TokenId.Int => Expression_ParseOrConvert(token, typeof(int)),
            TokenId.UInt => Expression_ParseOrConvert(token, typeof(uint)),
            TokenId.Long => Expression_ParseOrConvert(token, typeof(long)),
            TokenId.ULong => Expression_ParseOrConvert(token, typeof(ulong)),
            TokenId.Double => Expression_ParseOrConvert(token, typeof(double)),
            TokenId.Float => Expression_ParseOrConvert(token, typeof(float)),
            TokenId.Decimal => Expression_ParseOrConvert(token, typeof(decimal)),
            TokenId.Bool => Expression_ParseOrConvert(token, typeof(bool)),
            TokenId.Guid => Expression_ParseOrConvert(token, typeof(Guid)),
            TokenId.DateTime => Expression_ParseOrConvert(token, typeof(DateTime), _ => _.GetParameters().Length == 1),
            TokenId.DateTimeOffset => Expression_ParseOrConvert(token, typeof(DateTimeOffset), _ => _.GetParameters().Length == 1),
            TokenId.Array => Expression_NewArrayInit(token),
            TokenId.Object => Expression_New(token),
            TokenId.Method => Expression_New(token),
            _ => throw new Exception($"Token(Id:{token.Id},Value:{token.Value}) can not get a value."),
        };
    }

    Expression Expression_ParseOrConvert(Token token, Type type, Func<MethodInfo, bool> methodSelector = null)
    {
        if (token.Value.GetType() == type)
            return Expression.Constant(token.Value);
        var expression = Parse((IList<Token>)token.Value);
        return expression.Type == typeof(string)
            ? (Expression)Expression.Call(
                methodSelector is null
                    ? type.GetTypeInfo().GetDeclaredMethod("Parse")
                    : type.GetTypeInfo().GetDeclaredMethods("Parse").First(methodSelector), expression)
            : Expression.Convert(expression, type);
    }

    Expression Expression_NewArrayInit(Token token)
    {
        var expressions = ((IList<Token>)token.Value).Split(_ => _.Id == TokenId.Comma).Select(_ => Parse(_.ToList())).ToArray();
        var types = expressions.Select(_ => _.Type).Distinct().ToArray();
        return types.Length == 1 
            ? Expression.NewArrayInit(types[0], expressions)
            : Expression.NewArrayInit(typeof(object), expressions.Select(_ => Expression.Convert(_, typeof(object))));
    }

    Expression Expression_New(Token token)
    {
        var properties = new Dictionary<string, Type>();
        var expressions = new List<Expression>();
        foreach (var item in ((IList<Token>)token.Value).Split(_ => _.Id == TokenId.Comma))
        {
            string name;
            Expression expression;
            if (item.Any(_ => _.Id == TokenId.Assign))
            {
                name = (string)item.First().Value;
                expression = Parse(item.Skip(2).ToList());
            }
            else if (item.Count() == 1)
            {
                name = (string)item.First().Value;
                expression = Parse(item.ToList());
            }
            else if (item.Any(_ => _.Id is TokenId.Access or TokenId.NullableAccess))
            {
                name = (string)item.Last().Value;
                expression = Parse(item.ToList());
            }
            else
            {
                throw new ExpressionParseException("出错了", Input, item.First());
            }

            properties.Add(name, expression.Type);
            expressions.Add(expression);
        }

        var type = TypeFactory.CreateType(properties);
        var propertyTypes = type.GetTypeInfo().GetProperties().Select(p => p.PropertyType).ToArray();
        var constructor = type.GetTypeInfo().GetConstructor(propertyTypes);
        return Expression.New(constructor, expressions);
    }

    static void MakeTypeConsistent(TokenId tokenId, ref Expression left, ref Expression right)
    {
        var type_Left = left.Type;
        var type_Right = right.Type;
        if (type_Left == type_Right)
            return;

        #region string

        if (tokenId == TokenId.Add)
        {
            if (type_Left == typeof(string))
            {
                right = Expression.Convert(right, typeof(object));
                return;
            }

            if (type_Right == typeof(string))
            {
                left = Expression.Convert(left, typeof(object));
                return;
            }
        }

        #endregion

        #region decimal

        if (type_Left == typeof(decimal))
        {
            if (type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region double

        if (type_Left == typeof(double))
        {
            if (type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region float

        if (type_Left == typeof(float))
        {
            if (type_Right == typeof(double))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region ulong

        if (type_Left == typeof(ulong))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region long

        if (type_Left == typeof(long))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region uint

        if (type_Left == typeof(uint))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region int

        if (type_Left == typeof(int))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region ushort

        if (type_Left == typeof(ushort))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region short

        if (type_Left == typeof(short))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region byte

        if (type_Left == typeof(byte))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(sbyte)
             || type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region sbyte

        if (type_Left == typeof(sbyte))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(char)
             || type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region char

        if (type_Left == typeof(sbyte))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }

            if (type_Right == typeof(bool))
            {
                right = Expression.Convert(right, type_Left);
                return;
            }
        }

        #endregion

        #region bool

        if (type_Left == typeof(bool))
        {
            if (type_Right == typeof(decimal)
             || type_Right == typeof(double)
             || type_Right == typeof(float)
             || type_Right == typeof(ulong)
             || type_Right == typeof(long)
             || type_Right == typeof(uint)
             || type_Right == typeof(int)
             || type_Right == typeof(ushort)
             || type_Right == typeof(short)
             || type_Right == typeof(byte)
             || type_Right == typeof(sbyte)
             || type_Right == typeof(char))
            {
                left = Expression.Convert(left, type_Right);
                return;
            }
        }

        #endregion

        throw new ExpressionParseException($"运算符“{tokenId.Description()}”无法应用于“{type_Left.Name}”和“{type_Right.Name}”类型的操作数");
    }

    public static LambdaExpression ParseLambda(Type parameterType, string expressionString, IDictionary<string, object>? variables = default)
    {
        var parameter = Expression.Parameter(parameterType);
        var parser = new ExpressionParser(parameter, variables);
        var expression = parser.Parse(expressionString);
        return Expression.Lambda(expression, parameter);
    }
}