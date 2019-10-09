using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Domain.Core;

namespace Cosmos.Domain.ChangeTracking
{
    /// <summary>
    /// Change tracking context
    /// </summary>
    public sealed class ChangeTrackingContext
    {
        private readonly ChangedValueDescriptorCollection _changedValueCollection;

        /// <summary>
        /// Create a new instance of <see cref="ChangeTrackingContext"/>.
        /// </summary>
        public ChangeTrackingContext()
        {
            _changedValueCollection = new ChangedValueDescriptorCollection();
        }

        /// <summary>
        /// Create a new instance of <see cref="ChangeTrackingContext"/>.
        /// </summary>
        /// <param name="collection"></param>
        public ChangeTrackingContext(ChangedValueDescriptorCollection collection)
        {
            _changedValueCollection = collection == null
                ? new ChangedValueDescriptorCollection()
                : new ChangedValueDescriptorCollection(collection);
        }

        /// <summary>
        /// Add property name, description, value before changed and value after changed
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="description"></param>
        /// <param name="valueBeforeChange"></param>
        /// <param name="valueAfterChange"></param>
        /// <typeparam name="TValue"></typeparam>
        public void Add<TValue>(string propertyName, string description, TValue valueBeforeChange,
            TValue valueAfterChange)
        {
            if (Equals(valueBeforeChange, valueAfterChange))
                return;

            var stringBeforeChange = valueBeforeChange.SafeString().ToLower().Trim();
            var stringAfterChange = valueAfterChange.SafeString().ToLower().Trim();
            if (stringBeforeChange == stringAfterChange)
                return;

            _changedValueCollection.Add(propertyName, description, stringBeforeChange, stringAfterChange);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="leftObj"></param>
        /// <param name="rightObj"></param>
        /// <typeparam name="TObject"></typeparam>
        public void Add<TObject>(IChangeTrackable<TObject> leftObj, TObject rightObj)
            where TObject : IDomainObject
        {
            if (Equals(leftObj, null))
                return;
            if (Equals(rightObj, null))
                return;

            _changedValueCollection.AddRange(leftObj.GetChanges(rightObj));
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="newValue"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public void Add<TObject, TProperty, TValue>(Expression<Func<TObject, TProperty>> expression, TValue newValue)
            where TObject : IDomainObject
        {
            var name = Lambdas.GetName(expression);
            var desc = Reflections.GetDescription(Lambdas.GetMember(expression));
            var value = Lambdas.GetValue(expression);
            Add(name, desc, value.CastTo<TValue>(), newValue);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="leftObjs"></param>
        /// <param name="rightObjs"></param>
        /// <typeparam name="TObject"></typeparam>
        public void Add<TObject>(IEnumerable<IChangeTrackable<TObject>> leftObjs, IEnumerable<TObject> rightObjs)
            where TObject : IDomainObject
        {
            if (Equals(leftObjs, null))
                return;
            if (Equals(rightObjs, null))
                return;

            var leftObjList = leftObjs.ToList();
            var rightObjList = rightObjs.ToList();

            var length = leftObjList.Count > rightObjList.Count
                ? rightObjList.Count
                : leftObjList.Count;

            for (var i = 0; i < length; i++)
                Add(leftObjList[i], rightObjList[i]);
        }

        /// <summary>
        /// Populate
        /// </summary>
        /// <param name="collection"></param>
        public void Populate(ChangedValueDescriptorCollection collection)
        {
            _changedValueCollection.Populate(collection);
        }

        /// <summary>
        /// Flush cache
        /// </summary>
        public void FlushCache()
        {
            _changedValueCollection.FlushCache();
        }

        /// <summary>
        /// Get changed value descriptor
        /// </summary>
        /// <returns></returns>
        public ChangedValueDescriptorCollection GetChangedValueDescriptor()
        {
            return _changedValueCollection;
        }

        /// <summary>
        /// Output
        /// </summary>
        /// <returns></returns>
        public string Output()
        {
            return _changedValueCollection.ToString();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Output();
        }
    }
}