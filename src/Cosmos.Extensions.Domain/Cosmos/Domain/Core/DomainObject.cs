using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cosmos.Domain.ChangeTracking;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain.Core
{
    /// <summary>
    /// Domain object
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public abstract class DomainObject<TObject> : IDomainObject, IValidatable<TObject>, IChangeTrackable<TObject>
        where TObject : class, IDomainObject, IValidatable<TObject>
    {
        private readonly ValidationContext<TObject> _validationContext;
        private readonly DescriptionContext _descriptionContext;
        private readonly ChangeTrackingContext _changeTrackingContext;

        /// <summary>
        /// Create a new instance of <see cref="DomainObject{T}"/>.
        /// </summary>
        protected DomainObject()
        {
            _validationContext = new ValidationContext<TObject>(AssignableType(this));
            _descriptionContext = new DescriptionContext();
            _changeTrackingContext = new ChangeTrackingContext();
        }

        #region Validation

        /// <inheritdoc />
        public void SetValidateHandler(IValidationHandler handler)
        {
            _validationContext.SetHandler(op => op.HandleAll(handler));
        }

        /// <inheritdoc />
        public void AddStrategy(IValidateStrategy<TObject> strategy)
        {
            _validationContext.AddStrategy(strategy);
        }

        /// <inheritdoc />
        public void AddStrategyList(IEnumerable<IValidateStrategy<TObject>> strategies)
        {
            _validationContext.AddStrategyList(strategies);
        }

        /// <inheritdoc />
        public ValidationResultCollection Validate()
        {
            _validationContext.Validate();
            return _validationContext.GetValidationResultCollection();
        }

        #endregion

        #region Change Tracking

        /// <summary>
        /// Add changed
        /// </summary>
        /// <param name="newObj"></param>
        protected virtual void AddChanges(TObject newObj) { }

        /// <summary>
        /// Add changes
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="newValue"></param>
        /// <typeparam name="TProperty"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        protected void AddChange<TProperty, TValue>(Expression<Func<TObject, TProperty>> expression, TValue newValue)
        {
            _changeTrackingContext.Add(expression, newValue);
        }

        /// <summary>
        /// Add change
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="description"></param>
        /// <param name="valueBeforeChange"></param>
        /// <param name="valueAfterChange"></param>
        /// <typeparam name="TValue"></typeparam>
        protected void AddChange<TValue>(string propertyName, string description, TValue valueBeforeChange,
            TValue valueAfterChange)
        {
            _changeTrackingContext.Add(propertyName, description, valueBeforeChange, valueAfterChange);
        }

        /// <summary>
        /// Add change
        /// </summary>
        /// <param name="objectBeforeChangeTrackable"></param>
        /// <param name="objectAfterChange"></param>
        protected void AddChange(IChangeTrackable<TObject> objectBeforeChangeTrackable, TObject objectAfterChange)
        {
            _changeTrackingContext.Add(objectBeforeChangeTrackable, objectAfterChange);
        }

        /// <summary>
        /// Add change
        /// </summary>
        /// <param name="leftObjs"></param>
        /// <param name="rightObjs"></param>
        protected void AddChange(IEnumerable<IChangeTrackable<TObject>> leftObjs, IEnumerable<TObject> rightObjs)
        {
            _changeTrackingContext.Add(leftObjs, rightObjs);
        }

        /// <summary>
        /// Get changes
        /// </summary>
        /// <param name="newObj"></param>
        /// <returns></returns>
        public ChangedValueDescriptorCollection GetChanges(TObject newObj)
        {
            _changeTrackingContext.FlushCache();
            if (Equals(newObj, null))
                return _changeTrackingContext.GetChangedValueDescriptor();
            AddChanges(newObj);
            return _changeTrackingContext.GetChangedValueDescriptor();
        }

        #endregion

        #region Description

        /// <summary>
        /// Add description
        /// </summary>
        protected virtual void AddDescription() { }

        /// <summary>
        /// Add description
        /// </summary>
        /// <param name="description"></param>
        protected void AddDescription(string description)
        {
            _descriptionContext.Add(description);
        }

        /// <summary>
        /// Add description
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <typeparam name="TValue"></typeparam>
        protected void AddDescription<TValue>(string name, TValue value)
        {
            _descriptionContext.Add(name, value);
        }

        #endregion

        #region Misc

        private TObject AssignableType(DomainObject<TObject> me) => me as TObject;

        #endregion

        /// <inheritdoc />
        public override string ToString()
        {
            _descriptionContext.FlushCache();
            AddDescription();
            return _descriptionContext.Output();
        }
    }
}