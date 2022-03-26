using System.Runtime.Serialization;

namespace System;

/// <summary>
/// The exception that is thrown when a invalid parameter is passed to a method that does not accept it as a valid argument.
/// </summary>
public class ArgumentInvalidException : ArgumentException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.ArgumentInvalidException"></see> class.
    /// </summary>
    public ArgumentInvalidException() { }

    /// <summary>Initializes a new instance of the <see cref="T:System.ArgumentInvalidException"></see> class with serialized data.</summary>
    /// <param name="info">The object that holds the serialized object data.</param>
    /// <param name="context">An object that describes the source or destination of the serialized data.</param>
    protected ArgumentInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    /// <summary>Initializes a new instance of the <see cref="T:System.ArgumentInvalidException"></see> class with the name of the parameter that causes this exception.</summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    public ArgumentInvalidException(string paramName) : base(paramName) { }

    /// <summary>Initializes a new instance of the <see cref="T:System.ArgumentInvalidException"></see> class with a specified error message and the exception that is the cause of this exception.</summary>
    /// <param name="message">The error message that explains the reason for this exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentInvalidException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>Initializes an instance of the <see cref="T:System.ArgumentInvalidException"></see> class with a specified error message and the name of the parameter that causes this exception.</summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    /// <param name="message">A message that describes the error.</param>
    public ArgumentInvalidException(string paramName, string message) : base(paramName, message) { }
}