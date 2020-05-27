namespace Cosmos.Domain.ChangeTracking
{
    /// <summary>
    /// To describe what value has been changed
    /// </summary>
    public class ChangedValueDescriptor
    {
        /// <summary>
        /// Create a new instance of <see cref="ChangedValueDescriptor"/>.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="description"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public ChangedValueDescriptor(string propertyName, string description, string oldValue, string newValue)
        {
            PropertyName = propertyName;
            Description = description;
            ValueBeforeChange = oldValue;
            ValueAfterChange = newValue;
        }

        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Value before change
        /// </summary>
        public string ValueBeforeChange { get; }

        /// <summary>
        /// Value after change
        /// </summary>
        public string ValueAfterChange { get; }

        /// <inheritdoc />
        public override string ToString() => $"{PropertyName}({Description}), old value is {ValueBeforeChange} and new value is {ValueAfterChange}";
    }
}