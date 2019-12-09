using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Validations.Abstractions;
using FluentValidation.Results;

namespace Cosmos.Validations {
    /// <summary>
    /// Validation result collection
    /// </summary>
    public class ValidationResultCollection : IValidationResult {
        private const string NONAME = "unamed";
        private readonly List<ValidationResult> _results;
        private readonly IDictionary<string, List<ValidationResult>> _resultsFlaggedByStrategy;

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        public ValidationResultCollection() {
            _results = new List<ValidationResult>();
            _resultsFlaggedByStrategy = new Dictionary<string, List<ValidationResult>>();
            UpdateResultFlaggedByStrategy(NONAME, new List<ValidationResult>());
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(ValidationResult result) : this() {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlaggedByStrategy(NONAME, result);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(ValidationResult result, string strategyName) : this() {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlaggedByStrategy(strategyName, result);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(IEnumerable<ValidationResult> results) : this() {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlaggedByStrategy(NONAME, results.ToList());
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(IEnumerable<ValidationResult> results, string strategyName) : this() {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlaggedByStrategy(strategyName, results.ToList());
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(ValidationResultCollection collection) : this() {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            ErrorCode = collection.ErrorCode;
            Flag = collection.Flag;
            _results = collection._results;
            UpdateResultFlaggedByStrategy(collection);
        }

        /// <inheritdoc />
        public int Count => _results.Select(x => x.Errors.Count).Sum();

        /// <inheritdoc />
        public bool IsValid => _results.All(result => result.IsValid);

        /// <inheritdoc />
        public long ErrorCode { get; set; } = 1001;

        /// <inheritdoc />
        public string Flag { get; set; } = "__EMPTY_FLG";

        /// <inheritdoc />
        public void Add(ValidationResult result) {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
        }

        /// <inheritdoc />
        public void AddRange(IEnumerable<ValidationResult> results) {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
        }

        /// <inheritdoc />
        public string ToMessage() {
            var builder = new StringBuilder();

            if (IsValid)
                builder.Append("No errors were found during verification.");
            else if (Count == 1)
                builder.Append("An error was found during verification, please check the details.");
            else
                builder.Append($"{Count} errors were found during verification, please check the details.");

            builder.AppendLine();
            builder.Append($" (code: {ErrorCode}, Flag: {Flag})");

            return builder.ToString();
        }

        /// <inheritdoc />
        public IEnumerable<string> ToValidationMessages() {
            return IsValid ? Enumerable.Empty<string>() : __getErrorStringList();

            // ReSharper disable once InconsistentNaming
            IEnumerable<string> __getErrorStringList() {
                foreach (var error in _results.SelectMany(result => result.Errors)) {
                    yield return $"{error.PropertyName}, {error.ErrorMessage}";
                }
            }
        }

        private StringBuilder GetErrorString(int spaceCount = 0) {
            var space = Strings.Repeat(' ', spaceCount);

            var sb = new StringBuilder();

            foreach (var error in _results.SelectMany(result => result.Errors)) {
                sb.AppendLine($"{space}{error.PropertyName}, {error.ErrorMessage}");
            }

            return sb;
        }

        /// <inheritdoc />
        public IEnumerator<ValidationResult> GetEnumerator() {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public override string ToString() {
            var builder = new StringBuilder();

            builder.AppendLine(ToMessage());
            builder.AppendLine("Detail(s):");

            builder.Append(GetErrorString(6));
            builder.AppendLine();

            return builder.ToString();
        }

        private void UpdateResultFlaggedByStrategy(ValidationResultCollection coll) {
            foreach (var set in coll._resultsFlaggedByStrategy) {
                UpdateResultFlaggedByStrategy(set.Key, set.Value);
            }
        }

        private void UpdateResultFlaggedByStrategy(string name, List<ValidationResult> results) {
            if (_resultsFlaggedByStrategy.ContainsKey(name)) {
                _resultsFlaggedByStrategy[name].AddRange(results);
            }
            else {
                _resultsFlaggedByStrategy.Add(name, results);
            }
        }

        private void UpdateResultFlaggedByStrategy(string name, ValidationResult result) {
            if (_resultsFlaggedByStrategy.ContainsKey(name)) {
                _resultsFlaggedByStrategy[name].Add(result);
            }
            else {
                _resultsFlaggedByStrategy.Add(name, new List<ValidationResult> {result});
            }
        }

        internal ValidationResultCollection Filter(Action<IEnumerable<ValidationResult>> filter) {
            var ret = _results;
            filter?.Invoke(ret);

            return ret.Count == 0 ? null : new ValidationResultCollection(ret);
        }

        internal ValidationResultCollection Filter(string strategyName) {
            if (string.IsNullOrWhiteSpace(strategyName))
                strategyName = NONAME;

            return _resultsFlaggedByStrategy.TryGetValue(strategyName, out var ret)
                ? new ValidationResultCollection(ret)
                : null;
        }
    }
}