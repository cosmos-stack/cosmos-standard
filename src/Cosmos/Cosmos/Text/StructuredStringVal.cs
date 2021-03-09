using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Text
{
    /// <summary>
    /// Structure String Value
    /// </summary>
    public readonly struct StructuredStringVal : IEnumerable<StructuredStringVal>
    {
        private readonly List<StructuredStringVal> _children;

        public StructuredStringVal(string value)
        {
            Value = value;
            _children = new List<StructuredStringVal>();
        }

        public string Value { get; }

        public IReadOnlyList<StructuredStringVal> Children => _children.AsReadOnly();

        #region Append Child

        public void Append(string value)
        {
            _children.Add(new StructuredStringVal(value));
        }

        public void Append(StructuredStringVal value)
        {
            _children.Add(value);
        }

        #endregion

        #region Count & Length

        public int Count => _children.Count;

        public int Length => Value.Length;

        #endregion

        #region Char

        public char this[int index] => Value[index];

        public char GetChar(int index) => Value[index];

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

        public StructuredStringVal GetStringVal(int index) => _children[index];

        #endregion

        public IEnumerator<StructuredStringVal> GetEnumerator() => _children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _children.GetEnumerator();

        #region ToString

        public override string ToString() => Value;

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
}