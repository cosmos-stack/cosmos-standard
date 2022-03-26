namespace Cosmos.Validation;

/// <summary>
/// Validation exception extensions. <br />
/// 验证异常扩展
/// </summary>
public static class ValidationExceptionExtensions
{
    /// <summary>
    /// Throw as ValidationException. <br />
    /// 作为 ValidationException 抛出
    /// </summary>
    /// <param name="exception"></param>
    /// <exception cref="ValidationException"></exception>
    public static void ThrowAsValidationError(this ArgumentNullException exception)
    {
        if (exception is null)
            return;
        ValidationErrors.NullAndRaise(exception);
    }

    /// <summary>
    /// Throw as ValidationException. <br />
    /// 作为 ValidationException 抛出
    /// </summary>
    /// <param name="exception"></param>
    public static void ThrowAsValidationError(this ArgumentOutOfRangeException exception)
    {
        if (exception is null)
            return;
        ValidationErrors.OutOfRangeAndRaise(exception);
    }

    /// <summary>
    /// Throw as ValidationException. <br />
    /// 作为 ValidationException 抛出
    /// </summary>
    /// <param name="exception"></param>
    public static void ThrowAsValidationError(this ArgumentInvalidException exception)
    {
        if (exception is null)
            return;
        ValidationErrors.InvalidAndRaise(exception);
    }
}