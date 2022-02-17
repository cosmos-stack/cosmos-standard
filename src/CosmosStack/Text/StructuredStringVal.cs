using System.Collections;
using System.Text;

namespace Cosmos.Text;

/// <summary>
/// Structure String Value <br />
/// 结构化了的字符串值
/// </summary>
public readonly struct StructuredStringVal : IEnumerable<StructuredStringVal>
{
    private readonly List<StructuredStringVal> _children;

    public StructuredStringVal(string value)
    {
        Value = value;
        _children = new List<StructuredStringVal>();
    }

    /// <summary>
    /// Gets value <br />
    /// 获得值
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Get the next level of structured string value <br />
    /// 获得下一级结构化字符串值
    /// </summary>
    public IReadOnlyList<StructuredStringVal> Children => _children.AsReadOnly();

    #region Append Child

    /// <summary>
    /// Append string value <br />
    /// 附加字符串值
    /// </summary>
    /// <param name="value"></param>
    public void Append(string value)
    {
        _children.Add(new StructuredStringVal(value));
    }

    /// <summary>
    /// Append <see cref="StructuredStringVal"/> value <br />
    /// 附加结构化的字符串值
    /// </summary>
    /// <param name="value"></param>
    public void Append(StructuredStringVal value)
    {
        _children.Add(value);
    }

    #endregion

    #region Count & Length

    /// <summary>
    /// Count <br />
    /// 统计下一级结构化字符串值的数量
    /// </summary>
    public int Count => _children.Count;

    /// <summary>
    /// Length <br />
    /// 获得值的长度
    /// </summary>
    public int Length => Value.Length;

    #endregion

    #region Char

    /// <summary>
    /// Index <br />
    /// 索引
    /// </summary>
    /// <param name="index"></param>
    public char this[int index] => Value[index];

    /// <summary>
    /// Get char by index <br />
    /// 根据给定的索引获得字符
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public char GetChar(int index) => Value[index];

    /// <summary>
    /// To char array.
    /// 转换为字符数组
    /// </summary>
    /// <returns></returns>
    public char[] ToCarArray() => Value.ToCharArray();

    #endregion

    #region String

    public static implicit operator string(StructuredStringVal val)
    {
        return val.Value;
    }

    public static implicit operator StructuredStringVal(string value)
    {
        return new(value);
    }

    #endregion

    #region StringVal

    /// <summary>
    /// Get <see cref="StructuredStringVal"/> by index <br />
    /// 根据给定的索引获得结构化的字符串值
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public StructuredStringVal GetStringVal(int index) => _children[index];

    #endregion

    public IEnumerator<StructuredStringVal> GetEnumerator() => _children.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _children.GetEnumerator();

    #region ToString

    /// <summary>Returns the fully qualified type name of this instance.</summary>
    /// <returns>The fully qualified type name.</returns>
    /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/System.ValueType.ToString?view=netcore-5.0">`ValueType.ToString` on docs.microsoft.com</a></footer>
    public override string ToString() => Value;

    /// <summary>
    /// Returns the fully qualified type name of this instance.
    /// </summary>
    /// <param name="includeChildren"></param>
    /// <returns></returns>
    public string ToString(bool includeChildren) => ToString(includeChildren, 1);

    internal string ToString(bool includeChildren, int level)
    {
        var builder = new StringBuilder();

        builder.Append(Value);

        if (includeChildren)
        {
            builder.AppendLine();
            var nextLevel = level + 1;

            for (var i = 0; i < Count; i++)
            {
                builder.AppendLine($"{Strings.Repeat(" ", level * 4)}{_children[i].ToString(true, nextLevel)}");
            }
        }

        return builder.ToString();
    }

    #endregion
}