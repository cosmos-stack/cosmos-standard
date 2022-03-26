using System.Runtime.Serialization;
using System.Text;
using Cosmos.Text;
using Cosmos.Exceptions;

namespace Cosmos.Validation;

/// <summary>
/// Validation exception <br />
/// 验证异常
/// </summary>
[Serializable]
public class ValidationException : CosmosException, IHasValidationErrors
{
    private const string VALIDATION_FLAG = "__VALID_FLG";
    private const string VALIDATION_MESSAGE_INFO_KEY = "__VALIDATION_MESSAGES";
    private readonly IEnumerable<string> _validationMessage = Enumerable.Empty<string>();

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    public ValidationException()
    {
        Flag = VALIDATION_FLAG;
    }

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="message"></param>
    public ValidationException(string message) : base(message, VALIDATION_FLAG) { }

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
    public ValidationException(string message, Exception innerException) : base(message, VALIDATION_FLAG, innerException) { }

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
    public ValidationException(IEnumerable<string> validationMessage) : base(string.Empty, VALIDATION_FLAG)
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
    public ValidationException(string message, IEnumerable<string> validationMessage) : base(message, VALIDATION_FLAG)
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
    /// <param name="messageVal"></param>
    public ValidationException(StructuredStringVal messageVal) : base(messageVal.Value, VALIDATION_FLAG)
    {
        _validationMessage = messageVal.Children.Select(node => node.ToString());
    }

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="messageVal"></param>
    /// <param name="flag"></param>
    public ValidationException(StructuredStringVal messageVal, string flag) : base(messageVal.Value, flag)
    {
        _validationMessage = messageVal.Children.Select(node => node.ToString());
    }

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="message"></param>
    public ValidationException(long errorCode, string message) : base(errorCode, message, VALIDATION_FLAG) { }

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
    public ValidationException(long errorCode, string message, Exception innerException) : base(errorCode, message, VALIDATION_FLAG, innerException) { }

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
    public ValidationException(long errorCode, IEnumerable<string> validationMessage) : base(errorCode, string.Empty, VALIDATION_FLAG)
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
    public ValidationException(long errorCode, string message, IEnumerable<string> validationMessage) : base(errorCode, message, VALIDATION_FLAG)
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
    /// <param name="errorCode"></param>
    /// <param name="messageVal"></param>
    public ValidationException(long errorCode, StructuredStringVal messageVal) : base(errorCode, messageVal.Value, VALIDATION_FLAG)
    {
        _validationMessage = messageVal.Children.Select(node => node.ToString());
    }

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="messageVal"></param>
    /// <param name="flag"></param>
    public ValidationException(long errorCode, StructuredStringVal messageVal, string flag) : base(errorCode, messageVal.Value, flag)
    {
        _validationMessage = messageVal.Children.Select(node => node.ToString());
    }

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="streamingContext"></param>
    protected ValidationException(SerializationInfo info, StreamingContext streamingContext) : base(info, streamingContext)
    {
        _validationMessage = (IEnumerable<string>) info.GetValue(VALIDATION_MESSAGE_INFO_KEY, typeof(IEnumerable<string>));
        Flag = VALIDATION_FLAG;
    }

    /// <summary>
    /// Create a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="options"></param>
    public ValidationException(ExceptionOptions options) : base(options)
    {
        if (options != null && options.ExtraErrors.TryGetValue(VALIDATION_MESSAGE_INFO_KEY, out var value) && value is IEnumerable<string> messages)
            _validationMessage = messages;
    }

    /// <inheritdoc />
    public override void GetObjectData(SerializationInfo info, StreamingContext streamingContext)
    {
        base.GetObjectData(info, streamingContext);
        info.AddValue(VALIDATION_MESSAGE_INFO_KEY, _validationMessage);
    }

    /// <summary>
    /// Gets validation message
    /// </summary>
    public IEnumerable<string> ValidationMessage => _validationMessage;

    /// <inheritdoc />
    public override string GetFullMessage() => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder();

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (Message is not null)
        {
            sb.Append(Message);
        }

        if (ValidationMessage is not null)
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