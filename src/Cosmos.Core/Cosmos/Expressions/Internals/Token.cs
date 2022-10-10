namespace Cosmos.Expressions.Internals;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

internal class Token
{
    /// <summary>
    ///
    /// </summary>
    public TokenId Id { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    ///
    /// </summary>
    public object Value { get; set; } = new();
}