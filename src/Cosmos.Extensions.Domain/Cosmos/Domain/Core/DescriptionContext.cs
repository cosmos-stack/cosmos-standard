using System.Text;

namespace Cosmos.Domain.Core
{
    /// <summary>
    /// Description context
    /// </summary>
    public sealed class DescriptionContext
    {
        private StringBuilder _stringBuilder;

        /// <summary>
        /// Create a new instance of <see cref="DescriptionContext"/>.
        /// </summary>
        public DescriptionContext()
        {
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// Add desctiption
        /// </summary>
        /// <param name="description"></param>
        public void Add(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return;
            _stringBuilder.Append(description);
        }

        /// <summary>
        /// Add name and value pair
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <typeparam name="TValue"></typeparam>
        public void Add<TValue>(string name, TValue value)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;
            if (value == null || value.Equals(default(TValue)) || string.IsNullOrWhiteSpace(value.ToString()))
                return;
            _stringBuilder.Append($"{name}:{value}");
        }

        /// <summary>
        /// Flush cache
        /// </summary>
        public void FlushCache()
        {
            _stringBuilder.Clear();
        }

        /// <summary>
        /// Output
        /// </summary>
        /// <returns></returns>
        public string Output()
        {
            if (_stringBuilder.Length == 0)
                return string.Empty;
            return _stringBuilder.ToString().TrimEnd().TrimEnd(',');
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Output();
        }
    }
}