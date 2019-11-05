using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cosmos.Validations
{
    /// <summary>
    /// Validation exception
    /// </summary>
    [Serializable]
    public class ValidationException : CosmosException
    {
        private const string ValidationFlag = "__VALID_FLG";
        private const string ValidationMessageInfoKey = "__VALIDATION_MESSAGES";
        private readonly IEnumerable<string> _validationMessage = Enumerable.Empty<string>();

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        public ValidationException()
        {
            Flag = ValidationFlag;
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="message"></param>
        public ValidationException(string message) : base(message, ValidationFlag) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="flag"></param>
        public ValidationException(string message, string flag) : base(message, flag) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ValidationException(string message, Exception innerException) : base(message, ValidationFlag, innerException) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="flag"></param>
        /// <param name="innerException"></param>
        public ValidationException(string message, string flag, Exception innerException) : base(message, flag, innerException) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="validationMessage"></param>
        public ValidationException(IEnumerable<string> validationMessage) : base(string.Empty, ValidationFlag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="validationMessage"></param>
        /// <param name="flag"></param>
        public ValidationException(IEnumerable<string> validationMessage, string flag) : base(string.Empty, flag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="validationMessage"></param>
        public ValidationException(string message, IEnumerable<string> validationMessage) : base(message, ValidationFlag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="validationMessage"></param>
        /// <param name="flag"></param>
        public ValidationException(string message, IEnumerable<string> validationMessage, string flag) : base(message, flag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public ValidationException(long errorCode, string message) : base(errorCode, message, ValidationFlag) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="flag"></param>
        public ValidationException(long errorCode, string message, string flag) : base(errorCode, message, flag) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ValidationException(long errorCode, string message, Exception innerException) : base(errorCode, message, ValidationFlag, innerException) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="flag"></param>
        /// <param name="innerException"></param>
        public ValidationException(long errorCode, string message, string flag, Exception innerException) : base(errorCode, message, flag, innerException) { }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="validationMessage"></param>
        public ValidationException(long errorCode, IEnumerable<string> validationMessage) : base(errorCode, string.Empty, ValidationFlag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="validationMessage"></param>
        /// <param name="flag"></param>
        public ValidationException(long errorCode, IEnumerable<string> validationMessage, string flag) : base(errorCode, string.Empty, flag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="validationMessage"></param>
        public ValidationException(long errorCode, string message, IEnumerable<string> validationMessage) : base(errorCode, message, ValidationFlag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="validationMessage"></param>
        /// <param name="flag"></param>
        public ValidationException(long errorCode, string message, IEnumerable<string> validationMessage, string flag) : base(errorCode, message, flag)
        {
            _validationMessage = validationMessage ?? throw new ArgumentNullException(nameof(validationMessage));
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="streamingContext"></param>
        protected ValidationException(SerializationInfo info, StreamingContext streamingContext) : base(info, streamingContext)
        {
            _validationMessage = (IEnumerable<string>) info.GetValue(ValidationMessageInfoKey, typeof(IEnumerable<string>));
            Flag = ValidationFlag;
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="options"></param>
        public ValidationException(CosmosExceptionOptions options) : base(options)
        {
            if (options != null && options.ExtraErrors.TryGetValue(ValidationMessageInfoKey, out var value) && value is IEnumerable<string> messages)
                _validationMessage = messages;
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext streamingContext)
        {
            base.GetObjectData(info, streamingContext);
            info.AddValue(ValidationMessageInfoKey, _validationMessage);
        }

        /// <summary>
        /// Gets validation message
        /// </summary>
        public IEnumerable<string> ValidationMessage => _validationMessage;

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Message != null)
            {
                sb.Append(Message);
            }

            if (ValidationMessage != null)
            {
                foreach (var message in ValidationMessage)
                {
                    sb.AppendLine();
                    sb.Append("  ");
                    sb.Append(message);
                }
            }

            return sb.Length > 0 ? sb.ToString() : base.ToString();
        }
    }
}