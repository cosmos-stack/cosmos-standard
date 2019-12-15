using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Domain.ChangeTracking {
    /// <summary>
    /// Changed value descriptor collection
    /// </summary>
    public class ChangedValueDescriptorCollection : IEnumerable<ChangedValueDescriptor> {
        private readonly IList<ChangedValueDescriptor> _list;
        private readonly IList<string> _changedNameList;

        /// <summary>
        /// Create a new instance of <see cref="ChangedValueDescriptorCollection"/>.
        /// </summary>
        public ChangedValueDescriptorCollection() {
            _list = new List<ChangedValueDescriptor>();
            _changedNameList = new List<string>();
        }

        /// <summary>
        /// Create a new instance of <see cref="ChangedValueDescriptorCollection"/>.
        /// </summary>
        /// <param name="descriptors"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ChangedValueDescriptorCollection(ChangedValueDescriptorCollection descriptors) : this() {
            if (descriptors == null) throw new ArgumentNullException(nameof(descriptors));
            Populate((IEnumerable<ChangedValueDescriptor>) descriptors);
        }

        /// <summary>
        /// Create a new instance of <see cref="ChangedValueDescriptorCollection"/>.
        /// </summary>
        /// <param name="descriptors"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ChangedValueDescriptorCollection(IEnumerable<ChangedValueDescriptor> descriptors) : this() {
            if (descriptors == null) throw new ArgumentNullException(nameof(descriptors));
            Populate(descriptors);
        }

        /// <inheritdoc />
        public IEnumerator<ChangedValueDescriptor> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Add descriptor
        /// </summary>
        /// <param name="descriptor"></param>
        public void Add(ChangedValueDescriptor descriptor) {
            if (descriptor == null || string.IsNullOrWhiteSpace(descriptor.Description)) return;
            if (_changedNameList.Contains(descriptor.PropertyName)) return;
            _list.Add(descriptor);
            _changedNameList.Add(descriptor.PropertyName);
        }

        /// <summary>
        /// Add property name, description, old-value and new-value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="description"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void Add(string propertyName, string description, string oldValue, string newValue) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;
            if (_changedNameList.Contains(propertyName)) return;
            _list.Add(new ChangedValueDescriptor(propertyName, description, oldValue, newValue));
            _changedNameList.Add(propertyName);
        }

        /// <summary>
        /// Add a set of descriptors
        /// </summary>
        /// <param name="descriptors"></param>
        public void AddRange(IEnumerable<ChangedValueDescriptor> descriptors) {
            if (descriptors == null) return;

            foreach (var descriptor in descriptors)
                Add(descriptor);
        }

        /// <summary>
        /// Populate descriptors
        /// </summary>
        /// <param name="descriptors"></param>
        public void Populate(IEnumerable<ChangedValueDescriptor> descriptors) {
            if (descriptors == null || !descriptors.Any()) return;

            var filtedDiscriptors = descriptors.Where(x => !_changedNameList.Contains(x.PropertyName)).ToList();

            if (!filtedDiscriptors.Any())
                return;

            foreach (var item in filtedDiscriptors)
                Add(item);
        }

        /// <summary>
        /// Flush cache
        /// </summary>
        public void FlushCache() {
            _list.Clear();
            _changedNameList.Clear();
        }

        /// <inheritdoc />
        public override string ToString() {
            if (!_list.Any()) return string.Empty;
            var sb = new StringBuilder();
            foreach (var item in _list)
                sb.AppendLine(item.ToString());
            return sb.ToString();
        }
    }
}